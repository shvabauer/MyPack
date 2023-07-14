using UnityEngine;

using Zenject;

using MyPack.Networking.Http.Commands.Base;
using MyPack.Networking.Http.Queries.Base;
using MyPack.Networking.Settings;

namespace MyPack.Networking.DI
{
    public class NetworkInstaller : MonoInstaller
    {
        [SerializeField] private NetworkSettings _networkSettings;

        public override void InstallBindings()
        {
            Container.Bind<NetworkSettings>().FromScriptableObject(_networkSettings).AsCached();

            Container.BindInterfacesTo<QueryProcessor>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesTo<CommandProcessor>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesTo<Network>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}