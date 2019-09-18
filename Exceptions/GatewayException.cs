using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace StockportGovUK.AspNetCore.Gateways
{
    public class GatewayException : System.Exception
    {
        public string ResourceReferenceProperty { get; set; }

        public GatewayException() 
        { 

        }

        public GatewayException(string message) : base(message) 
        { 

        }
        
        public GatewayException(string message, System.Exception inner) : base(message, inner) 
        { 

        }

        protected GatewayException(SerializationInfo info, StreamingContext context) : base(info, context) 
        { 
            ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }
    }
}
