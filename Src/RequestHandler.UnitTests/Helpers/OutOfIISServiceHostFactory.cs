using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace RequestHandler.UnitTests.Helpers
{
    class OutOfIISServiceHostFactory : ServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return this.CreateServiceHost(Type.GetType(constructorString), baseAddresses);
        }
    }
}
