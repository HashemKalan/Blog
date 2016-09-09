using Blog.DomainService.Post;
using Blog.Operation.Post.Interface;

namespace Blog.Operation.Post
{
    public class PostOperation : BaseOperation<Domain.Post>, IPostOperation
    {
        public PostOperation(PostService postService) : base(postService)
        {

        }
    }
}
