using Blog.Domain;
using Blog.Domain.Enums;
using System.Collections.Generic;

namespace Blog.ViewModel
{
    public class UserInformation : BaseModel
    {
        public string Name { get; set; }
        public string AboutMe { get; set; }
        public UserStatus UserStatus { get; set; }
        public IList<Post> Posts { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
    }
}
