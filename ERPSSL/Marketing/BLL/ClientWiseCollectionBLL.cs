using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class ClientWiseCollectionBLL
    {
        ClientWiseCollectionDAL aClientWiseCollectionDAL = new ClientWiseCollectionDAL();

        internal List<string> Get_ClientWiseList(string OCODE)
        {
            return aClientWiseCollectionDAL.Get_ClientWiseList(OCODE);
        }

        internal List<MarketingWorkOrderTransaction> GetClientWiseTransaction(string OCODE, string clientName)
        {
            return aClientWiseCollectionDAL.GetClientWiseTransaction(OCODE, clientName);
        }
    }
}