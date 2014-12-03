using ProtoBuf.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Routing;

namespace ProtoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1

    {

        /// <summary>
        /// Initializes a new instance of the Service1 class.
        /// </summary>
        public Service1()
        {

            // porotbuf "manual" : http://www.codeproject.com/Articles/642677/Protobuf-net-the-unofficial-manual

            //http://blogs.msdn.com/b/dmetzgar/archive/2011/03/29/protocol-buffers-and-wcf.aspx
            //http://www.drdobbs.com/windows/working-with-protobuf-wcf-services/240159282



            System.ServiceModel.ServiceHost hh = (ServiceHost)OperationContext.Current.Host;
            var binding = new WSHttpBinding();
            //http://msdn.microsoft.com/en-us/library/ms731080%28v=vs.110%29.aspx

            //A first chance exception of type 'System.InvalidOperationException' occurred in System.ServiceModel.dll
            //Additional information: Endpoints cannot be added after the ServiceHost has been opened/faulted/aborted/closed.
            ServiceEndpoint endpoint = hh.AddServiceEndpoint( //this.serviceHost.AddServiceEndpoint(
               typeof(IService1), binding, "OrderService");
            endpoint.Behaviors.Add(new ProtoEndpointBehavior());




            //var nroute = new System.Web.Routing.Route.ServiceRoute("ProtoSrv", new ServiceFactory(), typeof(Service1));

            //System.ServiceModel.Activation.ServiceHostFactory
            //http://msdn.microsoft.com/en-us/library/aa395224.aspx

            var nroute = new ServiceRoute("ProtoSrv", new ServiceHostFactory(), typeof(Service1));

            RouteTable.Routes.Add(nroute);

        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
