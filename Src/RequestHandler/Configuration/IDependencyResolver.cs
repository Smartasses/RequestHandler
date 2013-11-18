using System;

namespace RequestHandler.Configuration
{
    public interface IDependencyResolver
    {
        object GetService(Type serviceType);
    }
}