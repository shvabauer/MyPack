using UnityEngine;
using UnityEngine.UI;

using Zenject;

using MyPack.Networking.Models;

namespace MyPack.Networking
{
    public class TestController : MonoBehaviour
    {
        [SerializeField] private Button _btnCreateUser;
        [SerializeField] private Button _btnGetAllUsers;
        private INetwork _network;

        [Inject]
        private void Construct(INetwork network)
        {
            _network = network;
        }

        private void Start()
        {
            _btnCreateUser.onClick.AddListener(OnCreateUser);
            _btnGetAllUsers.onClick.AddListener(OnGetAllUsers);
        }

        private void OnGetAllUsers()
        {
            _network.GetAllUsers("getAllUsers", response =>
            {
                Debug.Log($"All users fetched");
            });
        }

        private void OnCreateUser()
        {
            var data = new CreateUserData
            {
                Name = "morpheus",
                Job = "leader"
            };

            _network.CreateUser(data, response =>
            {
                Debug.Log($"User created");
            });
        }
    }
}