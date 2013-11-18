using RequestHandler.Helper;
using System;
using System.ServiceModel;

namespace RequestHandler.Wcf
{
    public class ServiceHostFactory : System.ServiceModel.Activation.ServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var serviceType = Service.GetOrCreateImplementation(Type.GetType(constructorString));
            return CreateServiceHost(serviceType, baseAddresses);
        }
    }
}
