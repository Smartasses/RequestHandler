using RequestHandler.Example.Contracts;

namespace RequestHandler.Example.Host
{
    public class ExampleThree : ITimeService
    {
        public GetTheTimeResponse GetTheTime(GetTheTimeRequest request)
        {
            return Processor<GetTheTimeRequest, GetTheTimeResponse>.Process(request);
        }
    }
}
