using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.DataAccess.Configuration
{
    public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasOne(o => o.Account)
            .WithMany(m => m.Roles)
            .HasForeignKey(fk => fk.UserId)
            .IsRequired();
            builder.HasOne(o => o.Role)
            .WithMany(m => m.Accounts)
            .HasForeignKey(fk => fk.RoleId)
            .IsRequired();
        }
    }
}
