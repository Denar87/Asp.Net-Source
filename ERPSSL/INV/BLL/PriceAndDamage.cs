using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Configuration;
using System.Collections;
using System.Data;
namespace ERPSSL.INV.BLL
{
    public class PriceAndDamage
    {
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal bool ChangePrice(Hashtable ht)
        {
            try
            {
                ado.ExecuteCommand(ht, "INV_ChangePrice", conn);
                return true;
            }
            catch {
                return false;
            }
        }


        internal string GetNewDamageChalanNo(string code, DateTime day)
        {
            int count = 0;
            string challanNo = code + day.Year + day.Month + day.Day;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(Id) from Inv_Damage where DamageDate ='" + day + "' and CompanyCode = '" + code + "'", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
            }
            catch { }

            return challanNo;
        }

        internal DataTable Damage(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_AddDamage", conn);
            }
            catch { }
            return dt;
        }

        //internal bool Damage(Hashtable ht)
        //{
        //    try
        //    {
        //        ado.ExecuteCommand(ht, "INV_AddDamage", conn);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        internal string GetDamageChalanNo(string code, DateTime day)
        {
            int count = 0;
            string challanNo = code + day.Year + day.Month + day.Day;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(Id) from Inv_Damage where DamageDate ='" + day + "' and Store_Code = '" + code + "'", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
            }
            catch { }

            return challanNo;
        }
    }
}