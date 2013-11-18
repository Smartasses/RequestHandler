using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;

namespace RequestHandler.Helper
{
    class Service
    {
        private static readonly IDictionary<string, Type> _createdTypes;

        static Service()
        {
            _createdTypes = new Dictionary<string, Type>();
        }

        public static Type GetOrCreateImplementation(params Type[] interfaces)
        {
            var key = string.Join(" - ", interfaces.Where(x => x != typeof(IMetadataExchange))
                .Select(x => string.Format("{0} {1:08X}", x.AssemblyQualifiedName, x.GetHashCode())));

            Type result;
            if (!_createdTypes.TryGetValue(key, out result))
            {
                result = ServiceTypeCreator.CreateServiceTypeImplementing(interfaces);

                _createdTypes.Add(key, result);
            }
            return result;
        }
    }

}
