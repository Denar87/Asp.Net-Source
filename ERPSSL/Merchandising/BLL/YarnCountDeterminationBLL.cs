using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class YarnCountDeterminationBLL
    {

        YarnCountDeterminationDAL aYarnCountDeterminationDAL = new YarnCountDeterminationDAL();

        internal List<LC_FabricNature> GetAllfabNature(string ocode)
        {
            return aYarnCountDeterminationDAL.GetAllfabNature();
        }

        internal List<Inv_ProductGroup> GetAllConstructionType(string ocode)
        {
            return aYarnCountDeterminationDAL.GetAllConstructionType();
        }

        internal List<LC_Composition> GetAllComposition()
        {
            return aYarnCountDeterminationDAL.GetAllComposition();
        }

        internal List<LC_Yarn_Count> GetAllYarnCount()
        {
            return aYarnCountDeterminationDAL.GetAllYarnCount();
        }

        internal List<LC_YarnCountType> GetAllYarnCountType()
        {
            return aYarnCountDeterminationDAL.GetAllYarnCountType();
        }

        internal int SaveData(LC_YarnDeterminationTemp aLC_YarnDeterminationTemp)
        {
            return aYarnCountDeterminationDAL.SaveData(aLC_YarnDeterminationTemp);
        }

        internal List<YarnDeterminationRepo> LoadDataForGrid(string ocode, Guid userIdEccess)
        {
            return aYarnCountDeterminationDAL.LoadDataForGrid(ocode, userIdEccess);
        }

        internal List<LC_Color> GetAllColor()
        {
            return aYarnCountDeterminationDAL.GetAllColor();
        }

        internal List<YarnDeterminationRepo> LoadAllDataForGrid(string ocode, int fabNatureId, int colorRangeId, int constructionId)
        {
            return aYarnCountDeterminationDAL.LoadAllDataForGrid(ocode, fabNatureId, colorRangeId, constructionId);
        }

        internal YarnDeterminationRepo GetSingleData(int entryId)
        {
            return aYarnCountDeterminationDAL.GetSingleData(entryId);
        }

        internal int UpdateData(LC_YarnDetermination aLC_YarnDetermination, int yarnDeterminationId)
        {
            return aYarnCountDeterminationDAL.UpdateData(aLC_YarnDetermination, yarnDeterminationId);
        }

        internal List<string> GetAllBrandByConstruction(int groupOfProduct)
        {
            return aYarnCountDeterminationDAL.GetAllBrandByConstruction(groupOfProduct);
        }

        internal List<Inv_Unit> GetAllUnitByConstruction(int groupOfProduct, string brand, string styleAndSize)
        {
            return aYarnCountDeterminationDAL.GetAllUnitByConstruction(groupOfProduct, brand, styleAndSize);
        }

        internal List<string> GetAllstyleSizeByConstruction(int groupOfProduct, string brand)
        {
            return aYarnCountDeterminationDAL.GetAllstyleSizeByConstruction(groupOfProduct, brand);
        }

        internal int GetProductId(int groupId, string productName, string brandName, string type, int unitId)
        {
            return aYarnCountDeterminationDAL.GetProductId(groupId, productName, brandName, type, unitId);
        }

        internal int SaveDataOriginal(LC_YarnDetermination aLC_YarnDetermination)
        {
            return aYarnCountDeterminationDAL.SaveDataOriginal(aLC_YarnDetermination);
        }

        internal int SaveToDeterminationCost(LC_DeterminationCost aLC_DeterminationCost)
        {
            return aYarnCountDeterminationDAL.SaveToDeterminationCost(aLC_DeterminationCost);
        }

        internal void DeleteDataFromTemp(int tempEntryId)
        {
            aYarnCountDeterminationDAL.DeleteDataFromTemp(tempEntryId);
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridView(string OCODE)
        {
            return aYarnCountDeterminationDAL.GetAllInformationOfGridView(OCODE);
        }

        internal List<LC_DeterminationCost> GetAllCost(string OCODE, Guid createUser, int uniqueId)
        {
            return aYarnCountDeterminationDAL.GetAllCost(OCODE, createUser, uniqueId);
        }

        internal List<YarnDeterminationRepo> LoadDataForGridFromConfirm(string OCODE, Guid createUser, int uniqueId)
        {
            return aYarnCountDeterminationDAL.LoadDataForGridFromConfirm(OCODE, createUser, uniqueId);
        }

        internal Inv_ProductGroup GetConstructionId(string constructionName)
        {
            return aYarnCountDeterminationDAL.GetConstructionId(constructionName);
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridViewByConstruction(string OCODE, int constructionId, Guid createUser)
        {
            return aYarnCountDeterminationDAL.GetAllInformationOfGridViewByConstruction(OCODE, constructionId, createUser);
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridViewByGSM(string OCODE, string GSMNo, Guid createUser)
        {
            return aYarnCountDeterminationDAL.GetAllInformationOfGridViewByGSM(OCODE, GSMNo, createUser);
        }

        internal LC_Composition GetCompositionId(string compositionName)
        {
            return aYarnCountDeterminationDAL.GetCompositionId(compositionName);
        }

        internal List<YarnDeterminationShowRepo> GetAllInformationOfGridViewByComposition(string OCODE, int compositionId, Guid createUser)
        {
            return aYarnCountDeterminationDAL.GetAllInformationOfGridViewByComposition(OCODE, compositionId, createUser);
        }



        internal List<YarnDeterminationReportRepo> GetAllInformationOfYD(string OCODE, Guid userIdEccess)
        {
            return aYarnCountDeterminationDAL.GetAllInformationOfYD(OCODE, userIdEccess);
        }
    }
}