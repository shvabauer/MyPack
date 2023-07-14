using System;

using UnityEngine;

namespace MyPack.Networking.Settings
{
    [CreateAssetMenu(fileName = "NetworkSettings", menuName = "ScriptableObjects/Network/NetworkSettings", order = 1)]
    public class NetworkSettings : ScriptableObject
    {
        [SerializeField] private string _host;
        [SerializeField] private int _port;

        [SerializeField] private string _setDataCommandURL;
        [SerializeField] private string _getDataQueryURL;

        public string Host => _host;
        public int Port => _port;
        public string SetDataCommandURL => _setDataCommandURL;
        public string GetDataQueryURL => _getDataQueryURL;

        public Uri CurrentUrl
        {
            get
            {
                var url = BuildHost(_host, _port);
                return url;
            }
        }

        private Uri BuildHost(string host, int port)
        {
            UriBuilder uriBuilder;

            if (port != 0)
            {
                uriBuilder = new UriBuilder(host)
                {
                    Port = port
                };
            }
            else
            {
                uriBuilder = new UriBuilder(host);
            }

            return uriBuilder.Uri;
        }
    }
}