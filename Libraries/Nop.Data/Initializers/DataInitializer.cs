using Nop.Domain.Users;
using System;
using System.Data.Entity;
using System.Linq;

namespace Nop.Data.Initializers
{
    public class DataMaster
    {
        public static void Initial(DbContext context)
        {
            var userRoleSet = context.Set<UserRole>();

            if (!userRoleSet.Any())
            {
                AddUserRole(context, new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Administrators,
                    SystemName = SystemUserRoleNames.Administrators,
                    EnablePasswordLifetime = true
                }, new User[] {
                });

                AddUserRole(context, new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.ForumModerators,
                    SystemName = SystemUserRoleNames.ForumModerators,
                    EnablePasswordLifetime = true
                }, new User[] { });

                AddUserRole(context, new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Registered,
                    SystemName = SystemUserRoleNames.Registered,
                    EnablePasswordLifetime = true
                }, new User[] {
                    new User
                    {
                        UserGuid = Guid.NewGuid(),
                        Active = true,
                        CreatedOnUtc = DateTime.UtcNow,
                        LastActivityDateUtc = DateTime.UtcNow,
                        IsSystemAccount = true,
                        Username = SystemUserNames.BackgroundTask,
                        SystemName =  SystemUserNames.BackgroundTask
                    }
                });

                AddUserRole(context, new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Vendors,
                    SystemName = SystemUserRoleNames.Vendors,
                    EnablePasswordLifetime = true
                }, new User[] { });

                AddUserRole(context, new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Guests,
                    SystemName = SystemUserRoleNames.Guests,
                    EnablePasswordLifetime = false
                }, new User[] { });

            }

        }

        private static void AddUserRole(DbContext context, UserRole userRole, User[] users)
        {
            var userRoleSet = context.Set<UserRole>();
            var userSet = context.Set<User>();

            userRoleSet.Add(userRole);

            foreach (var item in users)
            {
                item.UserRoles.Add(userRole);
                userSet.Add(item);
            }
        }
    }
}
