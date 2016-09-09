using Blog.Domain.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain
{
    public class ApplicationUser : IdentityUser
    {        
        public string Name { get; set; }                
        public string AboutMe { get; set; }        
        public UserStatus UserStatus { get; set; }
        public virtual SocialNetwork SocialNetwork { get; set; }       
        public virtual ICollection<Post> Posts { get; set; }
    }
}
