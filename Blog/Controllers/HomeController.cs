using Blog.DomainService.User.Interface;
using Blog.Operation.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : BaseController
    { 
        // GET: Home
        public ActionResult Index()
        {
            //For Use Identity

            //UserManager.CreateAsync();
            //SignInManager.PasswordSignInAsync();
            //RoleManager.CreateAsync();

            //For Use Other Entities You Can Use Blog.Operation Classes

            return View();
        }        
    }
}