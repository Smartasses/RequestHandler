using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Services;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RequestHandler.UnitTests.TestContracts;

namespace RequestHandler.UnitTests.Helpers
{
    class ServiceHostHelper
    {
        private static Uri endpoint = new Uri("http://localhost:8080/hello");

        public static ServiceHost CreateServiceHostFromFactory(ServiceHostFactory factory, string constructorString)
        {
            return (ServiceHost) factory.CreateServiceHost(constructorString, new[] {endpoint});
        }
        public static void Execute<TService>(Func<ServiceHost> createServiceHost, Action<TService> service)
        {
            HostService(createServiceHost, () => CreateClient(service));
        }
        private static void HostService(Func<ServiceHost> createServiceHost, Action executeWhenReady)
        {
            using (var host = createServiceHost())
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                var contractDescription = ContractDescription.GetContract(typeof(IServiceContract));
                var endpointAddress = new EndpointAddress(endpoint);
                host.Description.Endpoints.Add(new ServiceEndpoint(contractDescription, new BasicHttpBinding(), endpointAddress));
                host.AddServiceEndpoint(typeof(IMetadataExchange), new BasicHttpBinding(), "MEX");
                //host.AddServiceEndpoint(typeof(IServiceContract).FullName, new BasicHttpBinding(), endpoint);
                host.Open();

                executeWhenReady();

                host.Close();
            }
        }
        private static void CreateClient<TService>(Action<TService> executeWhenReady)
        {
            var myBinding = new BasicHttpBinding();

            var myEndpoint = new EndpointAddress(endpoint);

            var myChannelFactory = new ChannelFactory<TService>(myBinding, myEndpoint);

            var agent = myChannelFactory.CreateChannel();

            executeWhenReady(agent);

            ((IClientChannel)agent).Close();

            myChannelFactory.Close();
        }
    }
}
