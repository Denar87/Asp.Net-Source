using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data.SqlClient;

namespace ERPSSL.INV.DAL
{
    public class IChallanDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();


        public int Update_IChalanTemp(Guid UserId, string barcode, double delivaryQty)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var Parma1 = new SqlParameter("@UserId", UserId);
                    var Param2 = new SqlParameter("@BarCode", barcode);
                    var Param3 = new SqlParameter("@DeliveryQty", delivaryQty);
                    string SP_SQL = "Inv_IChallan_Temp_Update @UserId,@BarCode,@DeliveryQty";


                    _context.ExecuteStoreCommand(SP_SQL, Parma1, Param2, Param3);

                    return 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Inv_IChallan_Temp> GetDataByIChallan_Tem(string ChallanNo, string barcode)
        {
            try
            {
                var groups = (from grp in _context.Inv_IChallan_Temp
                              where grp.ChallanNo == ChallanNo && grp.BarCode == barcode
                              select grp).OrderBy(x => x.Id);
                return groups.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<Inv_Damage> GetDataInv_Damage(string ocode)
        {
            try
            {
                var groups = (from grp in _context.Inv_Damage
                              where grp.OCode == ocode
                              select grp).OrderBy(x => x.Id);
                return groups.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<Inv_Damage> GetDataInv_DamageDateWise(string formDate, string ToDate)
        {
            try
            {
                DateTime form = Convert.ToDateTime(formDate);
                DateTime to = Convert.ToDateTime(ToDate);
                var groups = (from grp in _context.Inv_Damage
                              where grp.DamageDate >= form
                              where grp.DamageDate <= to
                              select grp).OrderBy(x => x.Id);
                return groups.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //internal Inv_BuyCentral LoadByCentralData(string p1, string p2)
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //}

        internal int Insert(Inv_IChallan_Temp _ObjIchalanT)
        {
            try
            {
                _context.Inv_IChallan_Temp.AddObject(_ObjIchalanT);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_IChallan_Temp> GetIssueeGrid(int ID, string OCode)
        {
            try
            {
                var pus = (from po in _context.Inv_IChallan_Temp
                           where po.Id == ID && po.OCode == OCode
                           select po).OrderBy(x => x.ChallanNo);
                return pus.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_BuyCentral> GetBlQtyfromBuyCentral(string OCode, int PId)
        {
            try
            {
                var pus = (from po in _context.Inv_BuyCentral
                           where po.OCode == OCode  && po.ProductId==PId
                           select po);
                return pus.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_BuyCentral> Get_ItemBalance_ById_Store(string OCode, int PId, string storeCode)
        {
            try
            {
                var pus = (from po in _context.Inv_BuyCentral
                           where po.OCode == OCode && po.ProductId == PId && po.Store_Code==storeCode
                           select po);
                return pus.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal int InsertStD(Inv_IChallan_Temp _ObjIchalanT)
        {
            try
            {
                _context.Inv_IChallan_Temp.AddObject(_ObjIchalanT);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_IChallan_Temp> GetDataByIChallan_TemUserWise(Guid userId, string BarCode)
        {
            try
            {
                var groups = (from grp in _context.Inv_IChallan_Temp
                              where grp.EditUser == userId && grp.BarCode == BarCode
                              select grp).OrderBy(x => x.Id);
                return groups.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}