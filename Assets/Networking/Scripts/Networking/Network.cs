using System;
using System.Collections.Generic;

using UnityEngine;

using Zenject;

using MyPack.Networking.Http.Queries;
using MyPack.Networking.Http.Queries.Base;
using MyPack.Networking.Http.Commands;
using MyPack.Networking.Http.Commands.Base;
using MyPack.Networking.Http.Responses;
using MyPack.Networking.Http.Requests;
using MyPack.Networking.Models;
using MyPack.Networking.Settings;

namespace MyPack.Networking
{
    public class Network : MonoBehaviour, INetwork
    {

        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private NetworkSettings _networkSettings;

        public int AdminPinCode { get; set; }

        [Inject]
        private void Construct(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, NetworkSettings networkSettings)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
            _networkSettings = networkSettings;
        }

        public void CreateUser(CreateUserData data, Action<CreateUserResponse> callback)
        {
            _commandProcessor.ProcessCommand(new CreateUserCommand(new CreateUserRequest
            {
                Name = data.Name,
                Job = data.Job
            }, callback, _networkSettings));
        }

        public void GetAllUsers(string str, Action<GetAllUsersResponse> action)
        {
            var request = new Dictionary<string, string>()
            {
                { "", str },
            };
            _queryProcessor.ProcessQuery(new GetAllUsersQuery(request, action, _networkSettings));
        }
    }
}