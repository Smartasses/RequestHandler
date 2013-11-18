namespace RequestHandler
{
    public static class Processor<TRequest, TResponse>
    {
        public static TResponse Process(TRequest request)
        {
            var type = Configuration.RequestHandlerResolver.Current.GetRequestHandler<TRequest, TResponse>();
            var instance = (IRequestHandler<TRequest, TResponse>)Configuration.DependencyResolver.Current.GetService(type);
            return instance.Process(request);
        }
    }
}
