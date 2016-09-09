using Blog.DomainService.Tag;
using Blog.Operation.Tag.Interface;

namespace Blog.Operation.Tag
{
    public class TagOperation:BaseOperation<Domain.Tag>,ITagOperation
    {
        public TagOperation(TagService tagService):base(tagService)
        {

        }
    }
}
