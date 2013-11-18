using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler.Helper
{
    class ServiceContractValidator
    {
        private readonly Type _contractType;

        public ServiceContractValidator(Type contractType)
        {
            _contractType = contractType;
        }

        public void Validate()
        {
            if ((from method in _contractType.GetMethods()
                 let parameters = method.GetParameters()
                 where parameters.Count() != 1 || method.ReturnType == typeof(void)
                 select 1)
                .Any())
            {
                throw new InvalidOperationException("To use request handling, the parameter should have exactly one request and one response");
            }
        }
    }
}
