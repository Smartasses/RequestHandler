using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RequestHandler.UnitTests.TestContracts;

namespace RequestHandler.UnitTests.Helpers
{
    public abstract class WcfUnitTestBase
    {
        protected void ExecuteClassic(Action<IServiceContract> actionOnService)
        {
            ServiceHostHelper.Execute(() => ServiceHostHelper.CreateServiceHostFromFactory(new OutOfIISServiceHostFactory(), typeof(OldSchoolService).AssemblyQualifiedName), actionOnService);
        }
        protected void ExecuteRequestHandler(Action<IServiceContract> actionOnService)
        {
            ServiceHostHelper.Execute(() => ServiceHostHelper.CreateServiceHostFromFactory(new Wcf.ServiceHostFactory(), typeof(IServiceContract).AssemblyQualifiedName), actionOnService);
        }
    }
}
