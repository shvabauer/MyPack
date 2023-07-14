using System.Net;
using System.Collections.Generic;

using MyPack.Networking.Http.Responses;

namespace MyPack.Networking.Http.Queries.Base
{
    public class ApiQueryBase<TResult> : ApiBase<Dictionary<string, string>, TResult> where TResult : IResponse
    {
        protected ApiQueryBase(Dictionary<string, string> request) : base(request)
        {
            HttpMethod = WebRequestMethods.Http.Get;
        }
    }
}