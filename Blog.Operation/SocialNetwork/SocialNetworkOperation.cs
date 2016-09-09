using Blog.DomainService.SocialNetwork;
using Blog.Operation.SocialNetwork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Operation.SocialNetwork
{
    public class SocialNetworkOperation : BaseOperation<Domain.SocialNetwork>, ISocialNetworkOperation
    {
        public SocialNetworkOperation(SocialNetworkService socialNetworkService):base(socialNetworkService)
        {

        }
    }
}
