using Blog.Domain;
using System.Collections.Generic;

namespace Blog.ViewModel
{ 
    public class Tag
    {
        public string Text { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
