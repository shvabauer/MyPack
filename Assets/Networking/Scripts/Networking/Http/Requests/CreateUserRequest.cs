namespace MyPack.Networking.Http.Requests
{
    public class CreateUserRequest : IRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }
}