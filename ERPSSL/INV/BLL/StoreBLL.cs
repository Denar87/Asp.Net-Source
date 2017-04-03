using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.BLL
{
    public class StoreBLL
    {
        StoreDAL repository_DAL=new StoreDAL();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString; 

        public int SaveStore(Inv_Store astore)
        {
            return repository_DAL.SaveStore(astore);
        }
        public int UpdateStore(Inv_Store astore, string Id)
        {
            return repository_DAL.UpdateStore(astore, Id);
        }
        public List<Inv_Store> GetStoreId(string StoreId)
        {
            return repository_DAL.GetStoreeById(StoreId);
        }
        

        internal List<Inv_Store> GetStore()
        {
            return repository_DAL.GetStore();
        }

        internal List<Inv_Store> GetStoreByProjectID(string ProjectName)
        {
            return repository_DAL.GetStoreByProjectID(ProjectName);
        }
        internal List<Inv_Store> GetStoreByProjectCodeByLocation(string OCODE)
        {
            return repository_DAL.GetStoreByProjectCodeByLocation(OCODE);
        }
        internal DataTable GetCentralCompany()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_Company where CompanyType='CENTRAL'", conn);
            }
            catch { }
            return dt;
        }
        internal List<Inv_Store> GetStorByOcode(string OCODE)
        {
            return repository_DAL.GetStorByOcode(OCODE);
        }

        internal List<StoreInCharge> GetProgram(string OCODE)
        {
            return repository_DAL.GetProgram(OCODE);
        }

    }
}