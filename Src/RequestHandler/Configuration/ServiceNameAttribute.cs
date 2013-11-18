using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler.Configuration
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ServiceNameAttribute : Attribute
    {
        public ServiceNameAttribute(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; private set; }
    }
}
