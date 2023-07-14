using System;
using System.Collections.Generic;

using MyPack.Networking.Http.Queries.Base;
using MyPack.Networking.Http.Responses;
using MyPack.Networking.Settings;

namespace MyPack.Networking.Http.Queries
{
    public class GetAllUsersQuery : ApiQueryBase<GetAllUsersResponse>
    {
        public GetAllUsersQuery(Dictionary<string, string> request, Action<GetAllUsersResponse> callback, NetworkSettings networkSettings) : base(request)
        {
            Callback = callback;
            Url = networkSettings.GetDataQueryURL;
        }
    }
}