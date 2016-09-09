using Blog.Domain;
using Blog.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Blog.ViewModel
{
    public class Post : BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public PostStatus PostStatus { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
    }
}
