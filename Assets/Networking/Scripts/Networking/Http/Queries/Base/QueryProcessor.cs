using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

using Zenject;

using MyPack.Networking.Http.Responses;
using MyPack.Networking.Settings;

namespace MyPack.Networking.Http.Queries.Base
{
    public class QueryProcessor : MonoBehaviour, IQueryProcessor
    {
        private NetworkSettings _networkSettings;

        [Inject]
        private void Construct(NetworkSettings networkSettings)
        {
            _networkSettings = networkSettings;
        }

        public void ProcessQuery<TResult>(ApiBase<Dictionary<string, string>, TResult> api) where TResult : class, IResponse
        {
            StartCoroutine(GetRequest(api));
        }

        private IEnumerator GetRequest<TResult>(ApiBase<Dictionary<string, string>, TResult> api)
            where TResult : class, IResponse
        {
            var url = _networkSettings.CurrentUrl + api.Url;
            //url = $"{url}?record_id{string.Join("&", api.Request.Select(x => $"{x.Key}={x.Value}"))}";
            //url = $"{url}";

            var uwr = new UnityWebRequest(url, api.HttpMethod);
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