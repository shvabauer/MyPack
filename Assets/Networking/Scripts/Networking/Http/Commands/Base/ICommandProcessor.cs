namespace MyPack.Networking.Http.Commands.Base
{
    public interface ICommandProcessor
    {
        void ProcessCommand<TRequest, TResult>(ApiBase<TRequest, TResult> api);
    }
}