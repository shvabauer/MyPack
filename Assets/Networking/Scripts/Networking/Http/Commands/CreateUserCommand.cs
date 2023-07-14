using System;

using MyPack.Networking.Http.Commands.Base;
using MyPack.Networking.Http.Requests;
using MyPack.Networking.Http.Responses;
using MyPack.Networking.Settings;

namespace MyPack.Networking.Http.Commands
{
    public class CreateUserCommand : ApiCommandBase<CreateUserRequest, CreateUserResponse>
    {
        public CreateUserCommand(CreateUserRequest request, Action<CreateUserResponse> callback, NetworkSettings networkSettings) : base(request)
        {
            Callback = callback;
            Url = networkSettings.SetDataCommandURL;
        }
    }
}