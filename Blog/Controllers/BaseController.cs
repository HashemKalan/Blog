using Blog.DomainService.User.Interface;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IApplicationUserManager _userManager;
        protected readonly IApplicationSignInManager _signInManager;
        protected readonly IApplicationRoleManager _roleManager;        
        public BaseController()
        {
            _userManager = ObjectFactory.GetInstance<IApplicationUserManager>();
            _signInManager = ObjectFactory.GetInstance<IApplicationSignInManager>();
            _roleManager = ObjectFactory.GetInstance<IApplicationRoleManager>();
        }
        public IApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager;
            }
        }
        public IApplicationUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }
        public IApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager;
            }
        }
    }
}