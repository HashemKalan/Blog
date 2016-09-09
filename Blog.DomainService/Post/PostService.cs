using Blog.DataAccess.Interface;
using Blog.DomainService.Post.Interface;
namespace Blog.DomainService.Post
{
    public class PostService:BaseService<Domain.Post>,IPostService
    {
        public PostService(IUnitOfWork uow):base(uow)
        {
            
        }        
    }
}
