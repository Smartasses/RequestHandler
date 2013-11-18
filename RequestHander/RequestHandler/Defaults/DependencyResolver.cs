using System;
using RequestHandler.Configuration;

namespace RequestHandler.Defaults
{
    class DependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return Activator.CreateInstance(serviceType);
        }
    }
}
