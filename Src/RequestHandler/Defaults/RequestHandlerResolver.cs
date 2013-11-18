using System;
using System.Collections.Generic;
using System.Linq;
using RequestHandler.Configuration;

namespace RequestHandler.Defaults
{
    class RequestHandlerResolver : IRequestHandlerResolver
    {
        private readonly Lazy<IDictionary<Type, Type>> _requestHandlers;

        public RequestHandlerResolver()
        {
            _requestHandlers = new Lazy<IDictionary<Type, Type>>(() => AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(x => typeof (IRequestHandler).IsAssignableFrom(x) && !x.IsAbstract && x.IsClass)
                .SelectMany(
                    type =>
                        type.GetInterfaces()
                            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (IRequestHandler<,>)),
                    (type, inter) => new {Type = type, Interface = inter})
                .ToDictionary(x => x.Interface, x => x.Type));
        }
        public Type GetRequestHandler<TRequest, TResponse>()
        {
            return _requestHandlers.Value[typeof(IRequestHandler<TRequest, TResponse>)];
        }
    }
}