using RequestHandler.Helper;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace RequestHandler.Wcf
{
    class InstanceProvider : IInstanceProvider
    {
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var contractTypes = instanceContext.Host.Description.Endpoints.Select(x => x.Contract.ContractType);
            var type = Service.GetOrCreateImplementation(contractTypes.ToArray());
            return Activator.CreateInstance(type);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
