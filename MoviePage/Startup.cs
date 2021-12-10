using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviePage.API.Requirements;
using MoviePage.DataAccess.Data;
using MoviePage.Extensions;
using MoviePage.Infrastructure;
using MoviePage.Models;
using MoviePage.Models.Configurations;
using MoviePage.Services.Handlers;
using MoviePage.Services.Interfaces;
using MoviePage.Services.Movies.Commands;
using MoviePage.Services.Movies.Queries;
using MoviePage.Services.Wrappers;
using MoviePage.SignalRHub;
using MoviePage.Utility.Helper;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor(); //Register the httpcontext accessor
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>)); //Register the pipeline
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PaginationPipe<,>)); //Register the pipeline

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ReadDatabase")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDbContext<ApplicationWriteDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("WriteDatabase"));
            });
            services.AddIdentity<Account, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddEntityFrameworkStores<ApplicationWriteDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddCookie((o) =>
                {
                    o.Cookie.HttpOnly = true;
                    o.LoginPath = string.Empty;
                    o.AccessDeniedPath = string.Empty;
                    o.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    };
                }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Secret:Token_Key").Value)),
                    RequireAudience = false,
                    ValidateIssuer = false,
                };
                opt.SaveToken = true;
                opt.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var access_token = context.Request.Query["access_token"];
                        var path = context.Request.Path;
                        if(!string.IsNullOrEmpty(access_token) && (path.StartsWithSegments("/notification"))){
                            context.Token = access_token;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            /* Custom authorization */
            //services.AddAuthorization(opt =>
            //{
            //    var defaultAuthBuilder = new AuthorizationPolicyBuilder();

            //    var policyBuilder = defaultAuthBuilder.AddRequirements(new JwtRequirement()).Build(); //Adding requirement into authorization builder, don't forget to define server scope for handler

            //    opt.DefaultPolicy = policyBuilder;
            //});
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(typeof(IRequestWrapper<>).Assembly);
           
            services.AddControllersWithViews().AddNewtonsoftJson(opt =>
            {
                opt.UseCamelCasing(false);
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddCors();
            services.AddSignalR();
            services.RegisterServices();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CQRS.WebApi",
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                Console.WriteLine(Environment.GetEnvironmentVariable("GOOGLE"));
                Console.WriteLine(Configuration["GOOGLE"]);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.Use(async (ctx, next) =>
            //{
            //    await next();
            //    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
            //    {
            //        //Re-execute the request so the user gets the error page
            //        string originalPath = ctx.Request.Path.Value;
            //        ctx.Items["originalPath"] = originalPath;
            //        ctx.Request.Path = "/error/404";
            //        await next();
            //    }
            //});
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.WebApi");
            });
            app.UseCors(opt =>
            {
                opt.WithOrigins("http://localhost:4200").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
            });
            //app.UseStatusCodePagesWithReExecute("/Customer/Home/Error", "?statusCode={0}");
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

           
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notification");
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
