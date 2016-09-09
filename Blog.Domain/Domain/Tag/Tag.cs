using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class Tag:BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
