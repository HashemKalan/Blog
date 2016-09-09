using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.DomainService.User.Interface
{
    public interface IApplicationRoleManager : IDisposable
    {
        /// <summary>
        /// Used to validate roles before persisting changes
        /// </summary>
        IIdentityValidator<IdentityRole> RoleValidator { get; set; }

        /// <summary>
        /// Create a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> CreateAsync(IdentityRole role);

        /// <summary>
        /// Update an existing role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> UpdateAsync(IdentityRole role);

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        Task<IdentityResult> DeleteAsync(IdentityRole role);

        /// <summary>
        /// Returns true if the role exists
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        Task<bool> RoleExistsAsync(string roleName);

        /// <summary>
        /// Find a role by id
        /// </summary>
        /// <param name="roleId"/>
        /// <returns/>
        Task<IdentityRole> FindByIdAsync(string roleId);

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        Task<IdentityRole> FindByNameAsync(string roleName);


        // Our new custom methods

        IdentityRole FindRoleByName(string roleName);
        IdentityResult CreateRole(IdentityRole role);
        IList<IdentityUserRole> GetCustomUsersInRole(string roleName);
        IList<ApplicationUser> GetApplicationUsersInRole(string roleName);
        IList<IdentityRole> FindUserRoles(string userId);
        string[] GetRolesForUser(string userId);
        bool IsUserInRole(string userId, string roleName);
        Task<List<IdentityRole>> GetAllIdentityRolesAsync();
    }
}