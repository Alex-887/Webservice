using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Webservice_Berthouzoz_Favre
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebservice_Berthouzoz_Favre" in both code and config file together.
    [ServiceContract]
    public interface IWebservice_Berthouzoz_Favre
    {
        [OperationContract]
        double ChargeCard(double amount, double balance);
    }
}
