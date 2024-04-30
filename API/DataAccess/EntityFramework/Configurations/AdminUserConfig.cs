using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AdminUserConfig : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var AdminUserId = "9acbb401-b8ae-4ec8-9286-29e6dae86360";

            var AdminUser = new IdentityUser
            {
                Id = AdminUserId,
                Email = "admin@marketplace.com",
                NormalizedEmail = "admin@marketplace.com".ToUpper(),
                UserName = "admin@marketplace.com",
                NormalizedUserName = "admin@marketplace.com".ToUpper(),
            };
            AdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(AdminUser, "123456");
            builder.HasData(AdminUser);

        }
    }

}
