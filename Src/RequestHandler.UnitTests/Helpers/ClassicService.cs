using RequestHandler.UnitTests.TestContracts;

namespace RequestHandler.UnitTests.Helpers
{
    class OldSchoolService : IServiceContract
    {
        public OperationOneResponse OperationOne(OperationOneRequest request)
        {
            return new OperationOneResponse();
        }
        public OperationTwoResponse OperationTwo(OperationTwoRequest request)
        {
            return new OperationTwoResponse();
        }
    }

    class OperationOneRequestHandler : IRequestHandler<OperationOneRequest, OperationOneResponse>
    {
        public OperationOneResponse Process(OperationOneRequest request)
        {
            return new OperationOneResponse();
        }
    }
    class OperationTwoRequestHandler : IRequestHandler<OperationTwoRequest, OperationTwoResponse>
    {
        public OperationTwoResponse Process(OperationTwoRequest request)
        {
            return new OperationTwoResponse();
        }
    }
}
