using System.Text;
using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;

using Zenject;

using MyPack.Networking.Settings;

namespace MyPack.Networking.Http.Commands.Base
{
    public class CommandProcessor : MonoBehaviour, ICommandProcessor
    {
        private NetworkSettings _networkSettings;

        [Inject]
        private void Construct(NetworkSettings networkSettings)
        {
            _networkSettings = networkSettings;
        }

        public void ProcessCommand<TRequest, TResult>(ApiBase<TRequest, TResult> api)
        {
            StartCoroutine(PostRequest(api));
        }

        private IEnumerator PostRequest<TRequest, TResult>(ApiBase<TRequest, TResult> api)
        {
            var uwr = new UnityWebRequest(_networkSettings.CurrentUrl + api.Url, api.HttpMethod);
            var jsonToSend = new UTF8Encoding().GetBytes(JsonConvert.SerializeObject(api.Request));

            uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                api.ProcessFailed(uwr.error);
            }
            else
            {
                api.ProcessSuccessful(uwr.downloadHandler.text);
            }
        }
    }
}