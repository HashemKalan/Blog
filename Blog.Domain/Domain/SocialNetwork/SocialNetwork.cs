using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class SocialNetwork : BaseEntity
    {
        public int Id { get; set; }
        public string FaceBookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedinLink { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}
