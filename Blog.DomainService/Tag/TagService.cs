using Blog.DataAccess.Interface;
using Blog.DomainService.Tag.Interface;
namespace Blog.DomainService.Tag
{
    public class TagService : BaseService<Domain.Tag>, ITagervice
    {
        public TagService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
