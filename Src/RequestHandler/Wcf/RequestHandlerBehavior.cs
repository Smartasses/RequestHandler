using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace RequestHandler.Wcf
{
    public class RequestHandlerBehavior : IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (var endpointDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>().SelectMany(x => x.Endpoints))
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider = new InstanceProvider();
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase,
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
    }
}
