using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.POS.BLL;
using ERPSSL.POS.DAL;

namespace ERPSSL.POS
{
    public partial class ItemSync : System.Web.UI.Page
    {
        ItemInfoBLL aInfoBll = new ItemInfoBLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllFoodItem();
                GetAllInventoryItem();
                BindItemListInfo();
                //BindItemPackage();
            }
        }

        protected void GetAllFoodItem()
        {
            try
            {
                var row = aInfoBll.GetAllFoodItem();
                if (row.Count > 0)
                {
                    ddlFoodItem.DataSource = row.ToList();
                    ddlFoodItem.DataTextField = "ItemName";
                    ddlFoodItem.DataValueField = "Id";
                    ddlFoodItem.DataBind();
                    ddlFoodItem.AppendDataBoundItems = false;
                    ddlFoodItem.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch
            {
               
            }
        }

        protected void GetAllInventoryItem()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = aInfoBll.GetAllInventoryItem(OCODE);
                if (row.Count > 0)
                {
                    ddlInventoryItem.DataSource = row.ToList();
                    ddlInventoryItem.DataTextField = "ProductName";
                    ddlInventoryItem.DataValueField = "ProductId";
                    ddlInventoryItem.DataBind();
                    ddlInventoryItem.AppendDataBoundItems = false;
                    ddlInventoryItem.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        void ClearData()
        {
            ddlFoodItem.ClearSelection(); 
            ddlInventoryItem.ClearSelection(); 
        }

        protected void btnItemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt16(ddlFoodItem.SelectedValue);
                LU_Tbl_Item lutblitem = new LU_Tbl_Item();
                lutblitem.InventoryItemID = Convert.ToInt16(ddlInventoryItem.SelectedValue); 
                aInfoBll.UpdateInventoryProduct(lutblitem, Id);
             //   lblMessage.Text = "Data Updated Successfully";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true); 
                BindItemListInfo();
                GetAllFoodItem();
            }
            catch (Exception)
            {
                
                throw;
            }

            
        }

        protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            //lblMessage.Text = "";
            //List<Tbl_PackageItemInfo> PackageInformation = new List<Tbl_PackageItemInfo>();
            //ImageButton imgbtn = (ImageButton)sender;
            //GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            //try
            //{
            //    string PackageId = "";
            //    Label lblPackageID = (Label)grdPackageInfo.Rows[row.RowIndex].FindControl("lblPackageID");
            //    if (lblPackageID != null)
            //    {
            //        PackageId = lblPackageID.Text;
            //        PackageInformation = aInfoBll.GetId(PackageId);

            //        if (PackageInformation.Count > 0)
            //        {
            //            foreach (Tbl_PackageItemInfo apackage in PackageInformation)
            //            {
            //                hdfPackageID.Value = apackage.PackageItemInfo_ID.ToString();
            //                ddlPackageName.SelectedItem.Text = apackage.PackageName;
            //                ddlPackageItemName.SelectedItem.Text = apackage.PackageItemName.ToString();
            //                txtprice.Text = apackage.Price.ToString();
            //                txtQty.Text = apackage.Quantity.ToString(); 
            //            }
            //            if (btnPackageInfo.Text == "Submit")
            //            {
            //                btnPackageInfo.Text = "Update";
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void grdPackageInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grdPackageInfo.PageIndex = e.NewPageIndex;
            //BindItemPackage();
        }

        private void BindItemListInfo()
        {

            try
            {
                List<LU_Tbl_Item> list = aInfoBll.GetItemList(); 
                if (list.Count > 0)
                {
                    grdItemList.DataSource = list;
                    grdItemList.DataBind();
                }
            }
            catch
            {

            }
        }


        //protected void ddlFoodItem_SelectedIndexChanged_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int ID = Convert.ToInt16(ddlFoodItem.SelectedValue);
        //    //try
        //    //{
        //        List<Tbl_PackageItemInfo> list = aInfoBll.GetPackageInfobyID(ID);
        //        if (list.Count > 0)
        //        {
        //            grdPackageInfo.DataSource = list;
        //            grdPackageInfo.DataBind();
        //        }
        //    //}
        //    //catch
        //    //{

        //    //}
        //}
    }
}