using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Blog.DataAccess.Interface;
using Blog.Domain;
using Blog.DomainService.User.Interface;
using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.DomainService.User
{
    public class ApplicationRoleManager : RoleManager<IdentityRole, string>, IApplicationRoleManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IRoleStore<IdentityRole, string> _roleStore;
        private readonly IDbSet<ApplicationUser> _users;
        public ApplicationRoleManager(IUnitOfWork uow, IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
            _uow = uow;
            _roleStore = roleStore;
            _users = _uow.DbSet<ApplicationUser>();
        }

        public IdentityRole FindRoleByName(string roleName)
        {
            return this.FindByName(roleName); // RoleManagerExtensions
        }

        public IdentityResult CreateRole(IdentityRole role)
        {
            return this.Create(role); // RoleManagerExtensions
        }

        public IList<IdentityUserRole> GetCustomUsersInRole(string roleName)
        {
            return this.Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
            // = this.FindByName(roleName).Users
        }

        public IList<ApplicationUser> GetApplicationUsersInRole(string roleName)
        {
            var roleUserIdsQuery = from role in this.Roles
                                  where role.Name == roleName
                                  from user in role.Users
                                  select user.UserId;
            return _users.Where(applicationUser => roleUserIdsQuery.Contains(applicationUser.Id))
                         .ToList();
        }

        public IList<IdentityRole> FindUserRoles(string userId)
        {
            var userRolesQuery = from role in this.Roles
                        from user in role.Users
                        where user.UserId == userId
                        select role;

            return userRolesQuery.OrderBy(x => x.Name).ToList();
        }

        public string[] GetRolesForUser(string userId)
        {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any())
            {
                return new string[] { };
            }

            return roles.Select(x => x.Name).ToArray();
        }

        public bool IsUserInRole(string userId, string roleName)
        {
            var userRolesQuery = from role in this.Roles
                        where role.Name == roleName
                        from user in role.Users
                        where user.UserId == userId
                        select role;
            var userRole = userRolesQuery.FirstOrDefault();
            return userRole != null;
        }

        public Task<List<IdentityRole>> GetAllIdentityRolesAsync()
        {
            return this.Roles.ToListAsync();
        }        
    }
}