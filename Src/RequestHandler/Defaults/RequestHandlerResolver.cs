using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RequestHandler.Configuration;

namespace RequestHandler.Defaults
{
    class RequestHandlerResolver : IRequestHandlerResolver
    {
        private readonly Lazy<IDictionary<Type, Type>> _requestHandlers;

        public RequestHandlerResolver()
        {
            _requestHandlers = new Lazy<IDictionary<Type, Type>>(() => GetTypesToLoad()
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

        public IEnumerable<Type> GetTypesToLoad()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var typesFromAssembly = Enumerable.Empty<Type>();
                try
                {
                    typesFromAssembly = assembly.GetTypes();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Exception occured while requesting types: {0}", ex);
                }

                foreach (var type in typesFromAssembly)
                {
                    yield return type;
                }
            }
        }
    }
}