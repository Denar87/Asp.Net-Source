using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class ReasonTypeBLL
    {
        ReasonTypeDAL reasonDalObj = new ReasonTypeDAL();
        internal int InsertReasonType(HRM_ReasonType reasonTypeObj)
        {
            return reasonDalObj.InsertReasonType(reasonTypeObj);           

        }

        internal int UpdateReasonType(HRM_ReasonType reasonTypeObj, int reasonTypeId)
        {
            return reasonDalObj.UpdateReasonType(reasonTypeObj, reasonTypeId);      
        }

        internal List<HRM_ReasonType> GetReasonType(string Ocode)
        {
            return reasonDalObj.GetReasonType(Ocode);  
        }

        internal List<HRM_ReasonType> GeReasonTypes(string reasonTypeId, string OCODE)
        {
            return reasonDalObj.GeReasonTypes(reasonTypeId, OCODE); 
        }
    }
}