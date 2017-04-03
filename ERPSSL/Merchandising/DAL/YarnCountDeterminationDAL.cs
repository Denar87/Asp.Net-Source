using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class YarnCountDeterminationDAL
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal List<LC_FabricNature> GetAllfabNature()
        {
            try
            {
                var ItemName = (from IName in _Context.LC_FabricNature
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_ProductGroup> GetAllConstructionType()
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_ProductGroup
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_Composition> GetAllComposition()
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Composition
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_Yarn_Count> GetAllYarnCount()
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Yarn_Count
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_YarnCountType> GetAllYarnCountType()
        {
            try
            {
                var ItemName = (from IName in _Context.LC_YarnCountType
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int SaveData(LC_YarnDeterminationTemp aLC_YarnDeterminationTemp)
        {
            try
            {
                _Context.LC_YarnDeterminationTemp.AddObject(aLC_YarnDeterminationTemp);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<YarnDeterminationRepo> LoadDataForGrid(string ocode, Guid userIdEccess)
        {
            try
            {
                var yarnDeterminationList = (from yd in _Context.LC_YarnDeterminationTemp
                                             join fn in _Context.LC_FabricNature on yd.FebricNatureId equals fn.Id
                                             join cr in _Context.LC_Color on yd.ColorRangeId equals cr.ColorId
                                             join com in _Context.LC_Composition on yd.CompositionId equals com.Id
                                             join p in _Context.Inv_Product on yd.ProductId equals p.ProductId
                                             join u in _Context.Inv_Unit on p.UnitId equals u.UnitId
                                             join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId

                                             where yd.OCode == ocode && yd.CreateUser == userIdEccess
                                             select new YarnDeterminationRepo
                                             {
                                                 YarnDeterminationId = (int)yd.Id,

                                                 FebricNatureId = (int)fn.Id,
                                                 FebricNature = fn.FabricNature,

                                                 ColorRangeId = (int)cr.ColorId,
                                                 ColorRange = cr.ColorName,

                                                 Construction = g.GroupName,
                                                 ConstructionId  = g.GroupId,

                                                 GSM = yd.GSM,

                                                 CompositionId = (int)com.Id,
                                                 Composition = com.Composition,

                                                 Percentage = yd.Percentage,

                                                 YarnCount = p.Brand,

                                                 YarnCountType = p.StyleAndSize,

                                                 StichLength = yd.StichLength,
                                                 ProcessLoss = yd.ProcessLoss,
                                                 Price = (decimal)yd.Price,
                                                 unitName = u.UnitName,
                                                 ProductId = (int)yd.ProductId
                                             });

                return yarnDeterminationList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_Color> GetAllColor()
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Color
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<YarnDeterminationRepo> LoadAllDataForGrid(string ocode, int fabNatureId, int colorRangeId, int constructionId)
        {
            try
            {
                var yarnDeterminationList = (from yd in _Context.LC_YarnDetermination
                                             join fn in _Context.LC_FabricNature on yd.FebricNatureId equals fn.Id
                                             join cr in _Context.LC_Color on yd.ColorRangeId equals cr.ColorId
                                             join c in _Context.LC_ConstructionType on yd.ConstructionId equals c.Id
                                             join com in _Context.LC_Composition on yd.CompositionId equals com.Id
                                             join yc in _Context.LC_Yarn_Count on yd.YarnCountId equals yc.YarnCount_ID
                                             join yct in _Context.LC_YarnCountType on yd.YarnCountTypeId equals yct.Id

                                             where yd.OCode == ocode && fn.Id == fabNatureId && cr.ColorId == colorRangeId && com.Id == constructionId
                                             select new YarnDeterminationRepo
                                             {
                                                 YarnDeterminationId = (int)yd.Id,

                                                 FebricNatureId = (int)fn.Id,
                                                 FebricNature = fn.FabricNature,

                                                 ColorRangeId = (int)cr.ColorId,
                                                 ColorRange = cr.ColorName,

                                                 ConstructionId = (int)c.Id,
                                                 Construction = c.ConstructionType,

                                                 GSM = yd.GSM,

                                                 CompositionId = (int)com.Id,
                                                 Composition = com.Composition,

                                                 Percentage = yd.Percentage,

                                                 YarnCountId = (int)yc.YarnCount_ID,
                                                 YarnCount = yc.Yarn_Count,

                                                 YarnCountTypeId = (int)yct.Id,
                                                 YarnCountType = yct.YarnCountType,

                                                 StichLength = yd.StichLength,
                                                 ProcessLoss = yd.ProcessLoss
                                             });

                return yarnDeterminationList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal YarnDeterminationRepo GetSingleData(int entryId)
        {
            try
            {
                var yarnDeterminationList = (from yd in _Context.LC_YarnDeterminationTemp
                                             join fn in _Context.LC_FabricNature on yd.FebricNatureId equals fn.Id
                                             join cr in _Context.LC_Color on yd.ColorRangeId equals cr.ColorId
                                             join com in _Context.LC_Composition on yd.CompositionId equals com.Id
                                             join p in _Context.Inv_Product on yd.ProductId equals p.ProductId
                                             join u in _Context.Inv_Unit on p.UnitId equals u.UnitId
                                             join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId


                                             where yd.Id == entryId
                                             select new YarnDeterminationRepo
                                             {

                                                 YarnDeterminationId = (int)yd.Id,

                                                 FebricNatureId = (int)fn.Id,
                                                 FebricNature = fn.FabricNature,

                                                 ColorRangeId = (int)cr.ColorId,
                                                 ColorRange = cr.ColorName,

                                                 ConstructionId = g.GroupId,
                                                 Construction = g.GroupName,

                                                 GSM = yd.GSM,

                                                 CompositionId = (int)com.Id,
                                                 Composition = com.Composition,

                                                 Percentage = yd.Percentage,

                                                 YarnCount = p.Brand,

                                                 YarnCountType = p.StyleAndSize,

                                                 StichLength = yd.StichLength,
                                                 ProcessLoss = yd.ProcessLoss,
                                                 Price = (decimal)yd.Price,
                                                 unitName = u.UnitName,
                                                 ProductId = (int)yd.ProductId

                                             }).SingleOrDefault();

                return yarnDeterminationList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateData(LC_YarnDetermination aLC_YarnDetermination, int yarnDeterminationId)
        {
            try
            {
                LC_YarnDetermination LC_YarnDetermination = _Context.LC_YarnDetermination.First(x => x.Id == yarnDeterminationId);

                LC_YarnDetermination.FebricNatureId = aLC_YarnDetermination.FebricNatureId;
                LC_YarnDetermination.ColorRangeId = aLC_YarnDetermination.ColorRangeId;
                LC_YarnDetermination.ConstructionId = aLC_YarnDetermination.ConstructionId;

                LC_YarnDetermination.GSM = aLC_YarnDetermination.GSM;
                LC_YarnDetermination.CompositionId = aLC_YarnDetermination.CompositionId;
                LC_YarnDetermination.Percentage = aLC_YarnDetermination.Percentage;
                LC_YarnDetermination.YarnCountId = aLC_YarnDetermination.YarnCountId;
                LC_YarnDetermination.YarnCountTypeId = aLC_YarnDetermination.YarnCountTypeId;
                LC_YarnDetermination.StichLength = aLC_YarnDetermination.StichLength;
                LC_YarnDetermination.ProcessLoss = aLC_YarnDetermination.ProcessLoss;
                LC_YarnDetermination.EditUser = aLC_YarnDetermination.EditUser;
                LC_YarnDetermination.EditDate = aLC_YarnDetermination.EditDate;
                LC_YarnDetermination.OCode = aLC_YarnDetermination.OCode;

                _Context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<string> GetAllBrandByConstruction(int groupOfProduct)
        {
            try
            {
                var brandList = (from p in _Context.Inv_Product
                                 join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId

                                 where g.GroupId == groupOfProduct && p.ProductName == "Yarn"

                                 select p.Brand);

                return brandList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Inv_Unit> GetAllUnitByConstruction(int groupOfProduct, string brand, string styleAndSize)
        {
            try
            {
                var unitList = (from p in _Context.Inv_Product

                                join u in _Context.Inv_Unit on p.UnitId equals u.UnitId

                                join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId

                                where g.GroupId == groupOfProduct && p.ProductName == "Yarn" && p.Brand == brand && p.StyleAndSize == styleAndSize

                                select u);

                return unitList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<string> GetAllstyleSizeByConstruction(int groupOfProduct, string brand)
        {
            try
            {
                var styleandSizeList = (from p in _Context.Inv_Product


                                        join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId

                                        where g.GroupId == groupOfProduct && p.ProductName == "Yarn" && p.Brand == brand

                                        select p.StyleAndSize);

                return styleandSizeList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int GetProductId(int groupId, string productName, string brandName, string type, int unitId)
        {
            try
            {
                int productId = (from p in _Context.Inv_Product

                                 where p.GroupId == groupId && p.ProductName == productName && p.Brand == brandName && p.StyleAndSize == type && p.UnitId == unitId

                                 select p.ProductId).SingleOrDefault();

                return productId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int SaveDataOriginal(LC_YarnDetermination aLC_YarnDetermination)
        {
            try
            {
                _Context.LC_YarnDetermination.AddObject(aLC_YarnDetermination);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SaveToDeterminationCost(LC_DeterminationCost aLC_DeterminationCost)
        {
            try
            {
                _Context.LC_DeterminationCost.AddObject(aLC_DeterminationCost);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void DeleteDataFromTemp(int tempEntryId)
        {
            try
            {
                LC_YarnDeterminationTemp Fl = _Context.LC_YarnDeterminationTemp.First(x => x.Id == tempEntryId);
                _Context.LC_YarnDeterminationTemp.DeleteObject(Fl);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void YarnDeterminationRepos()
        {
            int uniqueId = 8700;

            try
            {
                var yarnDeterminationList = (from yd in _Context.LC_YarnDetermination
                                             join fn in _Context.LC_FabricNature on yd.FebricNatureId equals fn.Id
                                             join cr in _Context.LC_Color on yd.ColorRangeId equals cr.ColorId
                                             join com in _Context.LC_Composition on yd.CompositionId equals com.Id
                                             join p in _Context.Inv_Product on yd.ProductId equals p.ProductId
                                             join u in _Context.Inv_Unit on p.UnitId equals u.UnitId
                                             join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId


                                             where yd.UniqueId == uniqueId
                                             select new YarnDeterminationRepo
                                             {

                                                 YarnDeterminationId = (int)yd.Id,

                                                 FebricNatureId = (int)fn.Id,
                                                 FebricNature = fn.FabricNature,

                                                 ColorRangeId = (int)cr.ColorId,
                                                 ColorRange = cr.ColorName,

                                                 ConstructionId = g.GroupId,
                                                 Construction = g.GroupName,

                                                 GSM = yd.GSM,

                                                 CompositionId = (int)com.Id,
                                                 Composition = com.Composition,

                                                 Percentage = yd.Percentage,

                                                 YarnCount = p.Brand,

                                                 YarnCountType = p.StyleAndSize,

                                                 StichLength = yd.StichLength,
                                                 ProcessLoss = yd.ProcessLoss,
                                                 Price = (decimal)yd.Price,
                                                 unitName = u.UnitName,
                                                 ProductId = (int)yd.ProductId

                                             }).GroupBy(x => x.GSM);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridView(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_MerchandisingEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);

                    string SP_SQL = "LC_YarnCostShow @OCODE";
                    return (_context.ExecuteStoreQuery<YarnDeterminationShowRepo>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_DeterminationCost> GetAllCost(string OCODE, Guid createUser, int uniqueId)
        {
            try
            {
                var costs = (from p in _Context.LC_DeterminationCost

                             where p.OCode == OCODE && p.CreateUser == createUser && p.UniqueId == uniqueId

                             select p);

                return costs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<YarnDeterminationRepo> LoadDataForGridFromConfirm(string OCODE, Guid createUser, int uniqueId)
        {
            try
            {
                var yarnDeterminationList = (from yd in _Context.LC_YarnDetermination
                                             join fn in _Context.LC_FabricNature on yd.FebricNatureId equals fn.Id
                                             join cr in _Context.LC_Color on yd.ColorRangeId equals cr.ColorId
                                             join com in _Context.LC_Composition on yd.CompositionId equals com.Id
                                             join p in _Context.Inv_Product on yd.ProductId equals p.ProductId
                                             join u in _Context.Inv_Unit on p.UnitId equals u.UnitId
                                             join g in _Context.Inv_ProductGroup on p.GroupId equals g.GroupId

                                             where yd.OCode == OCODE && yd.CreateUser == createUser && yd.UniqueId == uniqueId
                                             select new YarnDeterminationRepo
                                             {
                                                 YarnDeterminationId = (int)yd.Id,

                                                 FebricNatureId = (int)fn.Id,
                                                 FebricNature = fn.FabricNature,

                                                 ColorRangeId = (int)cr.ColorId,
                                                 ColorRange = cr.ColorName,

                                                 Construction = g.GroupName,

                                                 GSM = yd.GSM,

                                                 CompositionId = (int)com.Id,
                                                 Composition = com.Composition,

                                                 Percentage = yd.Percentage,

                                                 YarnCount = p.Brand,

                                                 YarnCountType = p.StyleAndSize,

                                                 StichLength = yd.StichLength,
                                                 ProcessLoss = yd.ProcessLoss,
                                                 Price = (decimal)yd.Price,
                                                 unitName = u.UnitName,
                                                 ProductId = (int)yd.ProductId
                                             });

                return yarnDeterminationList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal Inv_ProductGroup GetConstructionId(string constructionName)
        {
            try
            {
                Inv_ProductGroup construction = (from p in _Context.Inv_ProductGroup
                                                   where p.GroupName == constructionName
                                                   select p).FirstOrDefault();
                return construction;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridViewByConstruction(string OCODE, int constructionId, Guid createUser)
        {
            try
            {
                using (var _context = new ERPSSL_MerchandisingEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _ConstructionId = new SqlParameter("@ConstructionId", constructionId);
                    var _CreateUser = new SqlParameter("@CreateUser", createUser);

                    string SP_SQL = "LC_YarnCostShowByConstruction @OCODE, @ConstructionId, @CreateUser";
                    return (_context.ExecuteStoreQuery<YarnDeterminationShowRepo>(SP_SQL, _OCode, _ConstructionId, _CreateUser)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridViewByGSM(string OCODE, string GSMNo, Guid createUser)
        {
            try
            {
                using (var _context = new ERPSSL_MerchandisingEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _ConstructionId = new SqlParameter("@GSM", GSMNo);
                    var _CreateUser = new SqlParameter("@CreateUser", createUser);

                    string SP_SQL = "LC_YarnCostShowByGSM @OCODE, @GSM, @CreateUser";
                    return (_context.ExecuteStoreQuery<YarnDeterminationShowRepo>(SP_SQL, _OCode, _ConstructionId, _CreateUser)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal LC_Composition GetCompositionId(string compositionName)
        {
            try
            {
                LC_Composition aLC_Composition = (from p in _Context.LC_Composition
                                                 where p.Composition == compositionName
                                                 select p).FirstOrDefault();
                return aLC_Composition;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridViewByComposition(string OCODE, int compositionId, Guid createUser)
        {
            try
            {
                using (var _context = new ERPSSL_MerchandisingEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _ConstructionId = new SqlParameter("@CompositionId", compositionId);
                    var _CreateUser = new SqlParameter("@CreateUser", createUser);

                    string SP_SQL = "LC_YarnCostShowByComposition @OCODE, @CompositionId, @CreateUser";
                    return (_context.ExecuteStoreQuery<YarnDeterminationShowRepo>(SP_SQL, _OCode, _ConstructionId, _CreateUser)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal List<YarnDeterminationReportRepo> GetAllInformationOfYD(string OCODE, Guid userIdEccess)
        {
            try
            {                                                     
                using (var _context = new ERPSSL_MerchandisingEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _CreateUser = new SqlParameter("@CreateUser", userIdEccess);

                    string SP_SQL = "LC_RPT_YarnDetermination @OCODE, @CreateUser";
                    return (_context.ExecuteStoreQuery<YarnDeterminationReportRepo>(SP_SQL, _OCode, _CreateUser)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}