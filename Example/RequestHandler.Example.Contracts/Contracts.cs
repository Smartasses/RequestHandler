using RequestHandler.Configuration;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace RequestHandler.Example.Contracts
{
    [ServiceContract, ServiceName("RequestHandler.Example.Host.ExampleOne")]
    public interface ITimeService
    {
        [OperationContract]
        GetTheTimeResponse GetTheTime(GetTheTimeRequest request);
    }

    [DataContract]
    public class GetTheTimeRequest
    {

    }
    [DataContract]
    public class GetTheTimeResponse
    {
        [DataMember]
        public DateTime Time { get; set; }
    }
}
