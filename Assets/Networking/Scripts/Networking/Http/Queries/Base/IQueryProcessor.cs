using System.Collections.Generic;

using MyPack.Networking.Http.Responses;

namespace MyPack.Networking.Http.Queries.Base
{
    public interface IQueryProcessor
    {
        void ProcessQuery<TResult>(ApiBase<Dictionary<string, string>, TResult> api)
            where TResult : class, IResponse;
    }
}