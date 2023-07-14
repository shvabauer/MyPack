using System;

using UnityEngine;

using Newtonsoft.Json;

namespace MyPack.Networking.Http
{
    public class ApiBase<TRequest, TResult>
    {
        public readonly TRequest Request;
        protected Action<TResult> Callback = delegate { };
        protected Action FailCallback = delegate { };

        protected ApiBase(TRequest request)
        {
            Request = request;
        }

        public string Url { get; set; }
        public string HttpMethod { get; set; }

        public virtual void ProcessSuccessful(string downloadHandlerText)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<TResult>(downloadHandlerText);
                Callback?.Invoke(result);
            }
            catch (Exception)
            {
                Debug.Log(typeof(TResult) + "////" + downloadHandlerText);
                throw;
            }
        }

        public virtual void ProcessFailed(string uwrError)
        {
            Debug.Log("Error While Sending: " + uwrError);
            FailCallback?.Invoke();
        }
    }
}