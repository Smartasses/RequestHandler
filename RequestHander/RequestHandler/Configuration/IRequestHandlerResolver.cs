using System;

namespace RequestHandler.Configuration
{
    public interface IRequestHandlerResolver
    {
        Type GetRequestHandler<TRequest, TResponse>();
    }
}