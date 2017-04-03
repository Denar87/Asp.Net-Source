using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV
{
    public partial class StoreunitType : System.Web.UI.Page
    {
        ProjectBLL projectBll = new ProjectBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        Store_Unit_TypeBLL aStoreUnitTypeBLL = new Store_Unit_TypeBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
             if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
            if (!IsPostBack)
            {
                GetAllStoreUnit();
            }
            }
             else
             {
                 Response.Redirect("..\\AppGateway\\Login.aspx");
             }
        }

        private void GetAllStoreUnit()
        {
            try
            {
                List<Inv_Store_Unit_Type> storeUnitType = aStoreUnitTypeBLL.GetAllStoreUnit();
                if (storeUnitType.Count > 0)
                {
                    grdStoreUntValue.DataSource = storeUnitType;
                    grdStoreUntValue.DataBind();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Inv_Store_Unit_Type InvStore = new Inv_Store_Unit_Type(); 

                InvStore.Store_UnitType_Name = txtName.Text;
                InvStore.Icon_Path = txtIconPath.Text;
                //InvStore.Description = txtDescription.Text;

                if (txtDescription.Text == "")
                {
                    InvStore.Description = "n/a";
                }
                else
                {
                    InvStore.Description = txtDescription.Text;
                }

                    if (btnSubmit.Text == "Submit")
                    {
                        int storeUnitcount = (from str in _context.Inv_Store_Unit_Type
                                            where str.Store_UnitType_Name == InvStore.Store_UnitType_Name
                                            select str.Store_UnitType_Id).Count();

                        InvStore.EditDate = DateTime.Now;
                        InvStore.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        InvStore.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                      
                        if (storeUnitcount == 0)
                        {
                            int result = aStoreUnitTypeBLL.InsertStoreunit(InvStore);
                        if (result == 1)
                        {
                           // lblMessage.Text = "Data Saved Successfully";
                           // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                            GetAllStoreUnit();
                            txtName.Text = "";
                            txtDescription.Text = "";
                            txtIconPath.Text = "";
                            txtName.Focus(); 
                        }
                        else
                        {
                           // lblMessage.Text = "Data Saving Failure";
                           // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                        }
                        else
                        {
                           // lblMessage.Text = "Data Already Exist";
                          //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                            txtName.Text = "";
                            txtIconPath.Text = "";
                            txtDescription.Text = "";
                            txtName.Focus();
                            btnSubmit.Text = "Submit";
                        }
                    }
                    else
                    {
                        int ID = Convert.ToInt32(hdfID.Value);
                        
                        int result = aStoreUnitTypeBLL.UpdateStoreunit(InvStore, ID);
                        if (result == 1)
                        {
                          //  lblMessage.Text = "Data Updated Sucessfully";
                            //lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                            GetAllStoreUnit();
                            txtName.Text = "";
                            txtDescription.Text = "";
                            txtIconPath.Text = "";
                            txtName.Focus();
                            btnSubmit.Text = "Submit"; 
                        }
                        
                        else
                        {
                           // lblMessage.Text = "Data Updating failure";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                        }
                    }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void ImgEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Store_Unit_Type> StoreUnit = new List<Inv_Store_Unit_Type>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string StoreID = "";
                Label lblId = (Label)grdStoreUntValue.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    StoreID = lblId.Text;
                    StoreUnit = aStoreUnitTypeBLL.GetStorerID(StoreID);

                    if (StoreUnit.Count > 0)
                    {
                        foreach (Inv_Store_Unit_Type aStore in StoreUnit)
                        {
                            hdfID.Value = aStore.Store_UnitType_Id.ToString();
                            txtName.Text = aStore.Store_UnitType_Name;
                            txtIconPath.Text = aStore.Icon_Path;
                            txtDescription.Text = aStore.Description; 
                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdStoreUntValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStoreUntValue.PageIndex = e.NewPageIndex;
            GetAllStoreUnit();
        } 
    }
}