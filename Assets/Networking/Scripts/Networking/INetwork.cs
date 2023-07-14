using System;

using MyPack.Networking.Models;
using MyPack.Networking.Http.Responses;

namespace MyPack.Networking
{
    public interface INetwork
    {
        void CreateUser(CreateUserData data, Action<CreateUserResponse> action);
        void GetAllUsers(string str, Action<GetAllUsersResponse> action);
    }
}