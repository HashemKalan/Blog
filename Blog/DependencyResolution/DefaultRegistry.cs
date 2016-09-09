using StructureMap.Configuration.DSL;
using System.Web;
using StructureMap.Graph;
using System.Security.Principal;
using System.Security.Claims;
using StructureMap.Pipeline;
using Blog.DataAccess.Interface;
using Blog.DataAccess.Context;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Blog.Domain;
using Blog.DomainService.User;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Blog.DomainService.User.Interface;
using StructureMap.Web;
namespace Blog.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {                        
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.With(new ControllerConvention());
            });            

            this.For<IIdentity>().Use(() => getIdentity());

            this.For<IUnitOfWork>()
                .HybridHttpOrThreadLocalScoped()
                .Use<DataBaseContext>();
            // Remove these 2 lines if you want to use a connection string named connectionString1, defined in the web.config file.
            //.Ctor<string>("connectionString")
            //.Is("Data Source=(local);Initial Catalog=TestDbIdentity;Integrated Security = true");

            this.For<DataBaseContext>().HybridHttpOrThreadLocalScoped()
               .Use(context => (DataBaseContext)context.GetInstance<IUnitOfWork>());
            this.For<DbContext>().HybridHttpOrThreadLocalScoped()
               .Use(context => (DataBaseContext)context.GetInstance<IUnitOfWork>());

            this.For<IUserStore<ApplicationUser, string>>()
                .HybridHttpOrThreadLocalScoped()
                .Use<UserStore<ApplicationUser>>();

            this.For<IRoleStore<IdentityRole, string>>()
                .HybridHttpOrThreadLocalScoped()
                .Use<RoleStore<IdentityRole, string, IdentityUserRole>>();            
            this.For<IAuthenticationManager>()
                  .Use(() => HttpContext.Current.GetOwinContext().Authentication);

            this.For<IApplicationSignInManager>()
                  .HybridHttpOrThreadLocalScoped()
                  .Use<ApplicationSignInManager>();

            this.For<IApplicationRoleManager>()
                  .HybridHttpOrThreadLocalScoped()
                  .Use<ApplicationRoleManager>();

            // map same interface to different concrete classes
            this.For<IIdentityMessageService>().Use<SmsService>();
            this.For<IIdentityMessageService>().Use<EmailService>();

            this.For<IApplicationUserManager>().HybridHttpOrThreadLocalScoped()
               .Use<ApplicationUserManager>()
               .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
               .Ctor<IIdentityMessageService>("emailService").Is<EmailService>()
               .Setter(userManager => userManager.SmsService).Is<SmsService>()
               .Setter(userManager => userManager.EmailService).Is<EmailService>();

            this.For<ApplicationUserManager>().HybridHttpOrThreadLocalScoped()
               .Use(context => (ApplicationUserManager)context.GetInstance<IApplicationUserManager>());

            //config.For<IDataProtectionProvider>().Use(()=> app.GetDataProtectionProvider()); // In Startup class
        }
        private static IIdentity getIdentity()
        {
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                return HttpContext.Current.User.Identity;
            }

            return ClaimsPrincipal.Current != null ? ClaimsPrincipal.Current.Identity : null;
        }
    }
}