using Blog.DataAccess.Interface;
using Blog.DomainService.SocialNetwork.Interface;
namespace Blog.DomainService.SocialNetwork
{
    public class SocialNetworkService : BaseService<Domain.SocialNetwork>, ISocialNetworkService
    {
        public SocialNetworkService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
