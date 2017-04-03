using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class Body_Parts : System.Web.UI.Page
    {
        BodyPartBLL _BodyPartBLL = new BodyPartBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    ShowBodyPartsGrid();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void ShowBodyPartsGrid()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_BodyPart> _BodyPartL = _BodyPartBLL.LoadBodyPartList(OCode);
                if (_BodyPartL.Count > 0)
                {
                    grdBodyParts.DataSource = _BodyPartL;
                    grdBodyParts.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LC_BodyPart _BodyParts = new LC_BodyPart();
                _BodyParts.BodyPart= txtBodyParts.Text;
                _BodyParts.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                _BodyParts.Create_Date = DateTime.Now;
                _BodyParts.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnSave.Text != "Update")
                {
                    int result = _BodyPartBLL.SaveBodyPart(_BodyParts);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Failure!')", true);
                    }
                }
                else
                {
                    _BodyParts.Edit_Date = DateTime.Now;
                    _BodyParts.Edit_User = (((SessionUser)Session["SessionUser"]).UserId); ;
                    _BodyParts.BPartId = Convert.ToInt16(hidBodyId.Value);
                    int result = _BodyPartBLL.UpdateBodyPart(_BodyParts);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                ShowBodyPartsGrid();
                ClearUi();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        private void ClearUi()
        {
            txtBodyParts.Text="";
            btnSave.Text = "Submit";
        }
        
        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblBPartId = (Label)grdBodyParts.Rows[row.RowIndex].FindControl("lblBPartId");
                int fqId = Convert.ToInt16(lblBPartId.Text);
                LC_BodyPart _BParts = _BodyPartBLL.GetB_PartLById(fqId);
                if (_BParts != null)
                {
                    hidBodyId.Value = _BParts.BPartId.ToString();
                    txtBodyParts.Text = _BParts.BodyPart;
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