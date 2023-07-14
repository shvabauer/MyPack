using System.Collections.Generic;

using MyPack.Networking.Models;

namespace MyPack.Networking.Http.Responses
{
    public class GetAllUsersResponse : IResponse
    {
        public List<UserData> Data { get; set; } = new();
    }
}