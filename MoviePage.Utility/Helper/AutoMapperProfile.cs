using AutoMapper;
using MoviePage.Models;
using MoviePage.Models.Dtos.Actors;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Models.Dtos.Genres;
using MoviePage.Models.Dtos.Movies;
using MoviePage.Models.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Utility.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Movie, MovieDTO>()
                .ForMember(mem => mem.OnShowing, opts => opts.MapFrom(src => src.MovieSchedules.Any(movie => movie.Start >= DateTime.Now || movie.End >= DateTime.Now)))
                .ForMember(mem => mem.Rating, opts =>
                {
                    opts.Condition(src => src.Votes.Count() > 0);
                    opts.MapFrom(src => src.Votes.CalculateAverage(ele => ele.Star));
                })
                .ForMember(mem => mem.TotalRating, opts => opts.MapFrom(src => src.Votes.Count()));
            CreateMap<Movie, DetailMovieDTO>()
                  .ForMember(mem => mem.Rating, opts =>
                  {
                      opts.Condition(src => src.Votes.Count() > 0);
                      opts.MapFrom(src => src.Votes.CalculateAverage(ele => ele.Star));
                  });
            CreateMap<Movie, CreateMovieDTO>();
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<UpdateMovieDTO, Movie>()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<MovieActor, MovieActorDTO>()
              .ForMember(mem => mem.Age, opt => opt.MapFrom(src => src.Actor.Age))
              .ForMember(mem => mem.FullName, opt => opt.MapFrom(src => src.Actor.FullName))
              .ForMember(mem => mem.Avatar, opt => opt.MapFrom(src => src.Actor.Avatar));
            CreateMap<MovieActorDTO, MovieActor>();
            CreateMap<MovieDirector, MovieDirectorDTO>()
                .ForMember(mem => mem.FullName, opt => opt.MapFrom(src => src.Director.FullName))
                .ForMember(mem => mem.Age, opt => opt.MapFrom(src => src.Director.Age))
                .ForMember(mem => mem.Avatar, opt => opt.MapFrom(src => src.Director.Avatar));
            CreateMap<MovieDirectorDTO, MovieDirector>();

            CreateMap<Actor, ActorDTO>();
            CreateMap<CreateActorDTO, Actor>();
            CreateMap<UpdateActorDTO, Actor>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMem) => srcMem != null));

            CreateMap<Actor, DetailActorDTO>()
                .ForMember(mem => mem.Movies, opts => opts.MapFrom(src => src.Movies.Select(sel => sel.Movie)));

            CreateMap<Director, DirectorDTO>();
            CreateMap<CreateDirectorDTO, Director>();

            CreateMap<MovieGenres, GenreDTO>()
                .ForMember(mem => mem.GenreName, opts => opts.MapFrom(src => src.Genres.GenresName));

            CreateMap<MovieTag, TagDTO>()
                .ForMember(mem => mem.TagName, opts => opts.MapFrom(src => src.Tag.TagName));
        }
    }
}
