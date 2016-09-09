using Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public PostStatus PostStatus { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public Post()
        {
            this.CreatedDate = DateTime.Now;
            this.PostStatus = PostStatus.Enable;
        }
    }
}
