namespace MyPack.Networking.Http.Responses
{
    public class CreateUserResponse : IResponse
    {
        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }
}