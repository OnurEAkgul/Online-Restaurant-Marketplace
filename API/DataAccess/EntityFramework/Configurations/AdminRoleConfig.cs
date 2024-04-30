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
    public class AdminRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {

            builder.HasKey(ur => new { ur.UserId, ur.RoleId }); // Define the composite primary key

            //RoleIds
            var UserRoleId = "271b09bb-36ab-4b08-b7e4-6c81195c7002";
            var AdminRoleId = "05e0d63e-18a3-4cf0-b31c-62f56a137605";
            var ShopOwnerRoleId = "ff7c2b8d-dff6-4d29-b1e0-2875e9c9c22b";
            var SupportRoleId = "3a5f66d2-06f6-4f20-8fb4-37a883037e9d";

            //AdminUserId
            var AdminUserId = "9acbb401-b8ae-4ec8-9286-29e6dae86360";
            
            var AdminRole = new List<IdentityUserRole<string>>
            {
                new()
                {
                    UserId=AdminUserId,
                    RoleId=AdminRoleId
                },
                new()
                {

                    UserId=AdminUserId,
                    RoleId=UserRoleId
                },
                new()
                {

                    UserId=AdminUserId,
                    RoleId=ShopOwnerRoleId
                },
                 new()
                {

                    UserId=AdminUserId,
                    RoleId=SupportRoleId
                }
            };
            builder.HasData(AdminRole);
        }
    }
}
