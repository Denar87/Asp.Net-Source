
using ERPSSL.BuyingHouse.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class Principal : System.Web.UI.Page
    {
        PrincipalBLL _PrincipalBLL = new PrincipalBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetPrincipalList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Principal _ObjPrincipal = new LC_Principal();
                _ObjPrincipal.PrincipalName = txtPrincipalName.Text;
                _ObjPrincipal.Address = txtAddress.Text;
                _ObjPrincipal.Country = ddlCountry.SelectedItem.Text;
                _ObjPrincipal.CreateDate = DateTime.Now;
                _ObjPrincipal.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);
                _ObjPrincipal.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSave.Text != "Update")
                {
                    int result = _PrincipalBLL.InsertPrincipal(_ObjPrincipal);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _ObjPrincipal.EditDate = DateTime.Now;
                    _ObjPrincipal.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    _ObjPrincipal.Principal_Id = Convert.ToInt16(hidPrincId.Value);
                    int result = _PrincipalBLL.UpdatePrincipal(_ObjPrincipal);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                GetPrincipalList();
                ClearAllController();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetPrincipalList()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_Principal> _BrandL = _PrincipalBLL.LoadPrincipalList(OCode);
                if (_BrandL.Count > 0)
                {
                    grdPrincipal.DataSource = _BrandL;
                    grdPrincipal.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllController()
        {
            txtPrincipalName.Text = "";
            txtAddress.Text = "";
            ddlCountry.ClearSelection();
            btnSave.Text = "Submit";
        }

       
        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblPrincipalId = (Label)grdPrincipal.Rows[row.RowIndex].FindControl("lblPrincipalId");
                int Id = Convert.ToInt16(lblPrincipalId.Text);
                LC_Principal _PrincipalS = _PrincipalBLL.GetPrincipalLById(Id);
                if (_PrincipalS != null)
                {
                    hidPrincId.Value = _PrincipalS.Principal_Id.ToString();
                    txtPrincipalName.Text = _PrincipalS.PrincipalName;
                    txtAddress.Text = _PrincipalS.Address;
                    GetPrincipalList();
                    ddlCountry.SelectedItem.Text = _PrincipalS.Country;
                }
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}