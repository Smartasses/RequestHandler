using RequestHandler.Example.Contracts;
using System;

namespace RequestHandler.Example.Host.RequestHandlers
{
    class GetTheTimeRequestHandler : IRequestHandler<GetTheTimeRequest, GetTheTimeResponse>
    {
        public GetTheTimeResponse Process(GetTheTimeRequest request)
        {
            return new GetTheTimeResponse
            {
                Time = DateTime.Now
            };
        }
    }
}