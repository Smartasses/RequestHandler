using System;

namespace RequestHandler.Configuration
{
    public static class DependencyResolver
    {
        static DependencyResolver()
        {
            Current = new Defaults.DependencyResolver();
        }
        public static IDependencyResolver Current { get; private set; }

        public static void Set(IDependencyResolver resolver)
        {
            if (resolver == null) throw new ArgumentNullException("resolver");
            Current = resolver;
        }
    }
}