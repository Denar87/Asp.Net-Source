using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class Brand : System.Web.UI.Page
    {
        BrandBLL _brandbLL = new BrandBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetBrandList();
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
                LC_Brand _lcBrand = new LC_Brand();
                _lcBrand.BrandName = txtBrandName.Text;
                _lcBrand.CreateDate = DateTime.Now;
                _lcBrand.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);
                _lcBrand.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSave.Text != "Update")
                {
                    int result = _brandbLL.InsertStyle(_lcBrand);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _lcBrand.EditDate = DateTime.Now;
                    _lcBrand.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    _lcBrand.BrandId = Convert.ToInt16(hidBrandId.Value);
                    int result = _brandbLL.UpdateStyle(_lcBrand);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                GetBrandList();
                ClearAllController();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetBrandList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_Brand> _BrandL = _brandbLL.LoadBrandList(Ocode);
                if (_BrandL.Count > 0)
                {
                    grdBrand.DataSource = _BrandL;
                    grdBrand.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllController()
        {
            txtBrandName.Text = "";
            btnSave.Text = "Submit";
        }

       
        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblBrandId = (Label)grdBrand.Rows[row.RowIndex].FindControl("lblBrandId");
                int BeandId = Convert.ToInt16(lblBrandId.Text);
                LC_Brand _brandS = _brandbLL.GetBrandLById(BeandId);
                if (_brandS != null)
                {
                    hidBrandId.Value = _brandS.BrandId.ToString();
                    txtBrandName.Text = _brandS.BrandName;
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