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
    public partial class PackageItemInformation : System.Web.UI.Page
    {
        ItemInfoBLL aInfoBll = new ItemInfoBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllPackageName();
                GetAllPackageItemName();
                //BindItemPackage();
            }

        }

        protected void GetAllPackageName()
        {
            try
            {
                var row = aInfoBll.GetAlLPackage();
                if (row.Count > 0)
                {
                    ddlPackageName.DataSource = row.ToList();
                    ddlPackageName.DataTextField = "ItemName";
                    ddlPackageName.DataValueField = "Id";
                    ddlPackageName.DataBind();
                    ddlPackageName.AppendDataBoundItems = false;
                    ddlPackageName.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch
            {

            }
        }

        protected void GetAllPackageItemName()
        {
            try
            {
                var row = aInfoBll.GetAllPackageItemName();
                if (row.Count > 0)
                {
                    ddlPackageItemName.DataSource = row.ToList();
                    ddlPackageItemName.DataTextField = "ItemName";
                    ddlPackageItemName.DataValueField = "Id";
                    ddlPackageItemName.DataBind();
                    ddlPackageItemName.AppendDataBoundItems = false;
                    ddlPackageItemName.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        void ClearData()
        {
            //ddlPackageName.ClearSelection();
            ddlPackageItemName.ClearSelection();
            txtQty.Text = "";
            txtprice.Text = "0";
        }

        protected void btnPackageInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Tbl_PackageItemInfo packageItemInfo = new Tbl_PackageItemInfo();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                packageItemInfo.OCode = OCODE;
                packageItemInfo.EditDate = DateTime.Now;
                packageItemInfo.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                packageItemInfo.PackageID = Convert.ToInt16(ddlPackageName.SelectedValue);
                packageItemInfo.PackageName = ddlPackageName.SelectedItem.Text;
                packageItemInfo.PackageItemID = Convert.ToInt16(ddlPackageItemName.SelectedValue);
                packageItemInfo.PackageItemName = ddlPackageItemName.SelectedItem.Text;
                packageItemInfo.Price = Convert.ToDecimal(txtprice.Text);
                packageItemInfo.Quantity = Convert.ToInt16(txtQty.Text);
                if (chkStatus.Checked)
                {
                    packageItemInfo.Status = true;
                }
                else
                {
                    packageItemInfo.Status = false;
                }


                //if (ddlProjectName.SelectedItem.Text == "---Select One---" && ddlDepartment.SelectedItem.Text == "---Select One---" && ddlStoreIncharge.SelectedItem.Text == "")
                //{
                //    lblMessage.Text = "<font color='red'>Fill Required Fields</font>";
                //    return;
                //}

                if (ddlPackageItemName.SelectedItem.Text == "---Select One---")
                {
                    lblMessage.Text = "<font color='red'>Package and Item is Required</font>";
                    return;
                }
                if (ddlPackageName.SelectedItem.Text == "---Select One---")
                {
                    lblMessage.Text = "";
                    lblMessage.Text = "<font color='red'>Item is Required</font>";
                    return;
                }

                if (btnPackageInfo.Text == "Submit")
                {
                    aInfoBll.SavePackageInfo(packageItemInfo);
                    //lblMessage.Text = "Data Saved Successfully";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true); 
                    GridItemShowByPackageName();
                    //BindItemPackage();
                    ClearData();
                    txtprice.Text = "0";
                }
                else
                {
                    aInfoBll.UpdateStore(packageItemInfo, Convert.ToInt16(hdfPackageID.Value));
                   // lblMessage.Text = "Data Updated Successfully";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true); 
                    GridItemShowByPackageName();
                    //BindItemPackage();
                    ClearData();
                    txtprice.Text = "0";
                    btnPackageInfo.Text = "Submit";
                }
            }
            catch
            {


            }
        }

        protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            List<Tbl_PackageItemInfo> PackageInformation = new List<Tbl_PackageItemInfo>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string PackageId = "";
                Label lblPackageID = (Label)grdPackageInfo.Rows[row.RowIndex].FindControl("lblPackageID");
                if (lblPackageID != null)
                {
                    PackageId = lblPackageID.Text;
                    PackageInformation = aInfoBll.GetId(PackageId);

                    if (PackageInformation.Count > 0)
                    {
                        foreach (Tbl_PackageItemInfo apackage in PackageInformation)
                        {
                            hdfPackageID.Value = apackage.PackageItemInfo_ID.ToString();
                            ddlPackageName.SelectedItem.Text = apackage.PackageName;
                            ddlPackageItemName.SelectedItem.Text = apackage.PackageItemName.ToString();
                            txtprice.Text = apackage.Price.ToString();
                            txtQty.Text = apackage.Quantity.ToString();
                            chkStatus.Checked = apackage.Status.Value;
                        }
                        if (btnPackageInfo.Text == "Submit")
                        {
                            btnPackageInfo.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdPackageInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPackageInfo.PageIndex = e.NewPageIndex;
            BindItemPackage();
        }

        private void BindItemPackage()
        {

            try
            {
                List<Tbl_PackageItemInfo> list = aInfoBll.GetPackageInfo();
                //var list = aStore_BLL.GetStore().ToList();
                if (list.Count > 0)
                {
                    grdPackageInfo.DataSource = list;
                    grdPackageInfo.DataBind();
                }
            }
            catch
            {

            }
        }


        protected void ddlPackageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridItemShowByPackageName();

        }

        private void GridItemShowByPackageName()
        {
            int ID = Convert.ToInt16(ddlPackageName.SelectedValue);
            //try
            //{
            List<Tbl_PackageItemInfo> list = aInfoBll.GetPackageInfobyID(ID);
            if (list.Count > 0)
            {
                grdPackageInfo.DataSource = list;
                grdPackageInfo.DataBind();
            }
            //}
            //catch
            //{

            //}
        }
    }
}