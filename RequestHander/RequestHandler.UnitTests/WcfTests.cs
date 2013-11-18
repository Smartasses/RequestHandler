using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RequestHandler.UnitTests.Helpers;
using RequestHandler.UnitTests.TestContracts;

namespace RequestHandler.UnitTests
{
    [TestClass]
    public class WcfTests : WcfUnitTestBase
    {
        [TestMethod]
        public void Operations_CalledClassic_ResponseReceived()
        {
            ExecuteClassic(agent =>
            {
                Assert.IsNotNull(agent.OperationOne(new OperationOneRequest()));
                Assert.IsNotNull(agent.OperationTwo(new OperationTwoRequest()));
            });
        }
        [TestMethod]
        public void Operations_CalledRequestHandler_ResponseReceived()
        {
            ExecuteRequestHandler(agent =>
            {
                Assert.IsNotNull(agent.OperationOne(new OperationOneRequest()));
                Assert.IsNotNull(agent.OperationTwo(new OperationTwoRequest()));
            });
        }

    }
}
