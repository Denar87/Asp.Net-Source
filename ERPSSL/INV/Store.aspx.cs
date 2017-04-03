using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class Store : System.Web.UI.Page
    {
        ProjectBLL projectBll = new ProjectBLL();
        DepartmentNameBLL departmentname = new DepartmentNameBLL();
        StoreInchargeBLL storeincharge = new StoreInchargeBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        StoreBLL aStore_BLL = new StoreBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //GetAllProject();
                    //GetAllDepartment();
                    BindStore();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //protected void GetAllProject()
        //{
        //    try
        //    {
        //        var row = projectBll.GetAllProject();
        //        if (row.Count > 0)
        //        {
        //            ddlProjectName.DataSource = row.ToList();
        //            ddlProjectName.DataTextField = "Project_Name";
        //            ddlProjectName.DataValueField = "Project_Id";
        //            ddlProjectName.DataBind();
        //            ddlProjectName.AppendDataBoundItems = false;
        //            ddlProjectName.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void GetAllStore()
        //{
        //    try
        //    {
        //        var row = projectBll.GetAllProject();
        //        if (row.Count > 0)
        //        {
        //            ddlProjectName.DataSource = row.ToList();
        //            ddlProjectName.DataTextField = "Project_Name";
        //            ddlProjectName.DataValueField = "Project_Id";
        //            ddlProjectName.DataBind();
        //            ddlProjectName.AppendDataBoundItems = false;
        //            ddlProjectName.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void GetAllDepartment()
        //{
        //    try
        //    {
        //        var row = departmentname.GetAllDepartment();
        //        if (row.Count > 0)
        //        {
        //            ddlDepartment.DataSource = row.ToList();
        //            ddlDepartment.DataTextField = "DPT_NAME";
        //            ddlDepartment.DataValueField = "DPT_ID";
        //            ddlDepartment.DataBind();
        //            ddlDepartment.AppendDataBoundItems = false;
        //            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void GetStoreIncharge()
        //{
        //    try
        //    {
        //        List<StoreInCharge> row = new List<StoreInCharge>();
        //        row = storeincharge.GetStoreIncharge().ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlStoreIncharge.DataSource = row.ToList();
        //            ddlStoreIncharge.DataTextField = "Store_fullname";
        //            ddlStoreIncharge.DataValueField = "Eid";
        //            ddlStoreIncharge.DataBind();
        //            ddlStoreIncharge.AppendDataBoundItems = false;
        //            ddlStoreIncharge.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        void ClearData()
        {
            txtStoreName.Text = "";
            txtStoreTrack.Text = "";
            txtDescription.Text = "";
            txtLocation.Text = "";
        }

        //protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetStoreIncharge();
        //}

        protected void btnStore_Click(object sender, EventArgs e)
        {
            try
            {
                Inv_Store astore = new Inv_Store();

                if (txtStoreName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Enter Store Name')", true);
                    return;
                }
                if (txtStoreTrack.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Enter Store Code')", true);
                    return;
                }
                astore.StoreName = txtStoreName.Text;
                astore.Store_Code = txtStoreTrack.Text;
                astore.Location = txtLocation.Text;
                astore.Description = txtDescription.Text;

                astore.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                astore.EDIT_DATE = DateTime.Now;
                astore.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;

                if (BtnSave.Text == "Submit")
                {
                    aStore_BLL.SaveStore(astore);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    BindStore();
                    ClearData();
                }
                else
                {
                    aStore_BLL.UpdateStore(astore, hdfStoreID.Value);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    BindStore();
                    ClearData();
                    BtnSave.Text = "Submit";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Store> store = new List<Inv_Store>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string StoreId = "";
                Label lblstoreId = (Label)grdstore.Rows[row.RowIndex].FindControl("lblstoreId");
                if (lblstoreId != null)
                {
                    StoreId = lblstoreId.Text;
                    store = aStore_BLL.GetStoreId(StoreId);

                    if (store.Count > 0)
                    {
                        foreach (Inv_Store astore in store)
                        {
                            hdfStoreID.Value = astore.Store_Id.ToString();
                            txtStoreName.Text = astore.StoreName;
                            txtStoreTrack.Text = astore.Store_Code;
                            txtLocation.Text = astore.Location;
                            txtDescription.Text = astore.Description;
                        }
                        if (BtnSave.Text == "Submit")
                        {
                            BtnSave.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdStoreValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdstore.PageIndex = e.NewPageIndex;
            BindStore();
        }

        private void BindStore()
        {
            try
            {
                List<Inv_Store> list = aStore_BLL.GetStore();
                if (list.Count > 0)
                {
                    grdstore.DataSource = list;
                    grdstore.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}