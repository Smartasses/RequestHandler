using System.ServiceModel;

namespace RequestHandler.UnitTests.TestContracts
{
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        OperationOneResponse OperationOne(OperationOneRequest request);
        [OperationContract]
        OperationTwoResponse OperationTwo(OperationTwoRequest request);
    }
}