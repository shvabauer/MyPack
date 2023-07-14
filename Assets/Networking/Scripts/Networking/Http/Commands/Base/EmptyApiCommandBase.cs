using System;
using System.Net;

using MyPack.Networking.Http.Responses;

namespace MyPack.Networking.Http.Commands.Base
{
    public class EmptyApiCommandBase<TRequest> : ApiBase<TRequest, IResponse>
    {
        protected Action EmptyCallback = delegate { };
        protected EmptyApiCommandBase(TRequest request) : base(request)
        {
            HttpMethod = WebRequestMethods.Http.Post;
        }

        public override void ProcessSuccessful(string downloadHandlerText)
        {
            EmptyCallback?.Invoke();
        }
    }
}