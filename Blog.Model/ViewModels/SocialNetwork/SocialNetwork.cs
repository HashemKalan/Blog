using Blog.Domain;

namespace Blog.ViewModel
{
    public class SocialNetwork : BaseModel
    {
        public string FaceBookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedinLink { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
