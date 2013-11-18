using System;

namespace RequestHandler.Configuration
{
    public static class RequestHandlerResolver
    {
        static RequestHandlerResolver()
        {
            Current = new Defaults.RequestHandlerResolver();
        }
        public static IRequestHandlerResolver Current { get; private set; }
        public static void Set(IRequestHandlerResolver typeResolver)
        {
            if (typeResolver == null)throw new ArgumentNullException("typeResolver");
            Current = typeResolver;
        }
    }
}
