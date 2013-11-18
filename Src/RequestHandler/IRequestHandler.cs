namespace RequestHandler
{
    public interface IRequestHandler<in TRequest, out TResponse> : IRequestHandler
    {
        TResponse Process(TRequest request);
    }

    public interface IRequestHandler
    {
        
    }
}
