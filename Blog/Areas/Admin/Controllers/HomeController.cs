using Blog.Controllers;
using Blog.DomainService.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {

        }        
        public ActionResult Index()
        {
            
            return View();
        }
    }
}