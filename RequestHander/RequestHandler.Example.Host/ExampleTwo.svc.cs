using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RequestHandler.Example.Contracts;

namespace RequestHandler.Example.Host
{
    public class ExampleTwo : ITimeService
    {
        public GetTheTimeResponse GetTheTime(GetTheTimeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
