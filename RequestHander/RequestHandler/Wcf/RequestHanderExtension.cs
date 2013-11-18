using System;
using System.ServiceModel.Configuration;

namespace RequestHandler.Wcf
{
    public class RequestHanderExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new RequestHandlerBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof (RequestHandlerBehavior); }
        }
    }
}
