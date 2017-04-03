using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Configuration;
using System.Data;
using System.Collections;

namespace ERPSSL.INV.BLL
{
    public class Inv_StoreBLL
    {
        CompanyDAL companyDal = new CompanyDAL();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal string GetCompanyIdByCode(string companycode)
        {
            string Code = "";

            try
            {
                Code = ado.AggRetrive("select CompanyId from Inv_Company where CompanyCode = '" + companycode + "'", conn).ToString();
            }
            catch { }
            return Code;
        }

        internal int InsertCompany(Inv_Company companyObj)
        {
            return companyDal.InsertCompany(companyObj);
        }

        internal List<Inv_Company> GetCompnay(string OCODE)
        {
            return companyDal.GetCompnay(OCODE);
        }

        internal List<Inv_Company> GetOtherStore(string OCODE)
        {
            return companyDal.GetOtherStore(OCODE);
        }

        internal List<Inv_Company> GetCheckCentralStore(string OCODE, string companyType)
        {
            return companyDal.GetCheckCentralStore(OCODE, companyType);
        }


        internal List<Inv_Company> GetcompanyInfoIdandOcode(string companyId, string OCODE)
        {
            return companyDal.GetcompanyInfoIdandOcode(companyId, OCODE);
        }
        internal List<Inv_Company> GetcompanyByCode(string companyCode)
        {
            return companyDal.GetcompanyByCode(companyCode);
        }
        internal int UpdateCompany(Inv_Company companyObj, int comapnyId)
        {
            return companyDal.UpdateCompany(comapnyId, companyObj);
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

        //internal static DataTable GetCompanyInformationByOCode(string OCode)
        //{
        //    DataTable dataBySQLString = new DataTable();
        //    try
        //    {
        //        Hashtable ht = new Hashtable();
        //        ht.Add("OCode", OCode);
        //        dataBySQLString = DataAccessEX.GetDataBySQLString(ht, "select CompanyName,CompanyAddress,ACDepreciationMethod, TaxDepreciationMethod,CorporateTaxRate from FA_Company where OCode =@OCode");
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Log(ex);
        //    }
        //    return dataBySQLString;
        //}


        internal string GetCompanyNameByCode(string CompanyCode)
        {
            string Code = "";

            try
            {
                Code = ado.AggRetrive("select CompanyName from Inv_Company where CompanyCode = '"+CompanyCode+"'", conn).ToString();
            }
            catch { }
            return Code;
        }

        internal string GetCountOcodeNo(string companyType)
        {

            int maxid = 0;
            try
            {


                maxid = Int32.Parse(ado.AggRetrive("select COUNT(distinct OCODE) from [Inv_Company] where CompanyType='"+companyType+"'", conn).ToString());
               
            }
            catch
            {
            }
            return (maxid + 100).ToString();
        }
    }
}