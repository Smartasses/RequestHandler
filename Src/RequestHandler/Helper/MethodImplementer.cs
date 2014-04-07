using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RequestHandler.Helper
{
    class MethodImplementer
    {
        public void ImplementMethod(MethodInfo method, Type interfaceType, TypeBuilder type)
        {
            var requestType = method.GetParameters().Single().ParameterType;
            var responseType = method.ReturnType;

            var methodName = string.Format("{0}.{1}", interfaceType.Name, method.Name);
            var methodBuilder = type.DefineMethod(methodName,
                MethodAttributes.Private |
                MethodAttributes.HideBySig |
                MethodAttributes.NewSlot |
                MethodAttributes.Virtual,
                responseType,
                new[] { requestType });

            CreateMethodImplementation(requestType, responseType, methodBuilder);

            type.DefineMethodOverride(methodBuilder, method);
        }

        private void CreateMethodImplementation(Type requestType, Type responseType, MethodBuilder methodBuilder)
        {
            var handler = typeof(Processor<,>).MakeGenericType(requestType, responseType);
            var il = methodBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, handler.GetMethod("Process"));
            il.Emit(OpCodes.Ret);
        }
    }
}
