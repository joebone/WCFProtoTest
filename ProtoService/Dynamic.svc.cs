using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProtoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Dynamic" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Dynamic.svc or Dynamic.svc.cs at the Solution Explorer and start debugging.
    public class Dynamic : IDynamic
    {
        public void DoWork()
        {
        }
    }
}
