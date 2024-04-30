using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class RolesConfig : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var UserRoleId = "271b09bb-36ab-4b08-b7e4-6c81195c7002";
            var AdminRoleId = "05e0d63e-18a3-4cf0-b31c-62f56a137605";
            var ShopOwnerRoleId = "ff7c2b8d-dff6-4d29-b1e0-2875e9c9c22b";
            var SupportRoleId = "3a5f66d2-06f6-4f20-8fb4-37a883037e9d";

            var Roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = UserRoleId,
                    Name = "userRole",
                    NormalizedName = "userRole".ToUpper(),
                    ConcurrencyStamp = UserRoleId
                },
                new IdentityRole()
                {
                    Id = AdminRoleId,
                    Name = "adminRole",
                    NormalizedName = "adminRole".ToUpper(),
                    ConcurrencyStamp = AdminRoleId
                },
                new IdentityRole()
                {
                    Id = ShopOwnerRoleId,
                    Name = "shopOwnerRole",
                    NormalizedName = "shopOwnerRole".ToUpper(),
                    ConcurrencyStamp = ShopOwnerRoleId
                },
                new IdentityRole()
                {
                    Id = SupportRoleId,
                    Name = "supportRole",
                    NormalizedName = "supportRole".ToUpper(),
                    ConcurrencyStamp = SupportRoleId
                }
            };
            builder.HasData(Roles);
        }
    }
}
