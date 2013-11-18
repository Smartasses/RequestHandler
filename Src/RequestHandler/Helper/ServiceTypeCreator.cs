using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.ServiceModel.Description;
using RequestHandler.Configuration;

namespace RequestHandler.Helper
{
    class ServiceTypeCreator
    {
        private static readonly ModuleBuilder ModuleBuilder;

        static ServiceTypeCreator()
        {
            var assemblyName = new AssemblyName(String.Format("RequestHandler.GeneratedTypes"));
            var moduleName = string.Format("{0}.dll", assemblyName.Name);

            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder = assembly.DefineDynamicModule(moduleName, false);
        }

        public static Type CreateServiceTypeImplementing(params Type[] interfaces)
        {
            var serviceName = interfaces.SelectMany(x => x.GetCustomAttributes(typeof (ServiceNameAttribute), true))
                .OfType<ServiceNameAttribute>()
                .Select(x => x.FullName)
                .SingleOrDefault()
                ?? String.Format("RequestHandler.GeneratedTypes.RequestHandlerService_" + Guid.NewGuid().ToString().Replace("-", ""));

            var methodImplementer = new MethodImplementer();
            var type = ModuleBuilder.DefineType(serviceName,
                TypeAttributes.Class |
                TypeAttributes.AnsiClass |
                TypeAttributes.Sealed |
                TypeAttributes.NotPublic);

            foreach (var serviceContract in interfaces.Where(x => x != typeof(IMetadataExchange)))
            {
                var validator = new ServiceContractValidator(serviceContract);
                validator.Validate();

                type.AddInterfaceImplementation(serviceContract);

                foreach (var method in serviceContract.GetMethods())
                {
                    methodImplementer.ImplementMethod(method, serviceContract, type);
                }
            }

            return type.CreateType();
        }
    }
}