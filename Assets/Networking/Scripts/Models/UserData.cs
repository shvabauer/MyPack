using System;

namespace MyPack.Networking.Models
{
    [Serializable]
    public class UserData
    {
        public uint Id;
        public string Email;
        public string First_name;
        public string Last_name;
        public string Avatar;
    }
}