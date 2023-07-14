using System.Net;

namespace MyPack.Networking.Http.Commands.Base
{
    public class ApiCommandBase<TRequest, TResult> : ApiBase<TRequest, TResult>
    {
        protected ApiCommandBase(TRequest request) : base(request)
        {
            HttpMethod = WebRequestMethods.Http.Post;
        }
    }
}