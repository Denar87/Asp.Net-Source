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
    public partial class ColorInfo : System.Web.UI.Page
    {
        Color_BLL objColor_BLL = new Color_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetColors();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void btnColorSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtColor.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Color Name!')", true);

                }           
                else
                {
                    LC_Color objColor = new LC_Color();
                    objColor.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    objColor.Edit_Date = DateTime.Now;
                    objColor.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objColor.ColorName = txtColor.Text;
                    objColor.Status = drpStatus.SelectedItem.Text;

                    if (btnColorSubmit.Text == "Submit")
                    {

                        if (IsExist(objColor.ColorName))
                        {

                            int result = objColor_BLL.InsertColor(objColor);
                            if (result == 1)
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        }
                    }
                    else
                    {
                        if (hidColorName.Value != txtColor.Text)
                        {
                            if (IsExist(objColor.ColorName))
                            {
                                int colorId = Convert.ToInt32(hidColorId.Value);
                                int result = objColor_BLL.UpdateColor(objColor, colorId);
                                if (result == 1)
                                {

                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                                }
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                            }
                        }
                        else
                        {
                            int colorId = Convert.ToInt32(hidColorId.Value);
                            int result = objColor_BLL.UpdateColor(objColor, colorId);
                            if (result == 1)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                            }
                        }
                    }
                    GetColors();
                    ClearColorsUi();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetColors()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var colors = objColor_BLL.GetAllColor(OCODE).ToList();
                if (colors.Count > 0)
                {
                    grdColor.DataSource = colors.ToList();
                    grdColor.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearColorsUi()
        {
            try
            {
                txtColor.Text = "";
                drpStatus.ClearSelection();
                btnColorSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool IsExist(string Cname)
        {
            try
            {
                ERPSSL_MerchandisingEntities _context = new ERPSSL_MerchandisingEntities();

                LC_Color objColor = new LC_Color();

                bool status = false;
                int count = (from col in _context.LC_Color
                             where col.ColorName == Cname
                             select col.ColorId).Count();
                if (count == 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void imgbtnColorEdit_Click1(object sender, ImageClickEventArgs e)
        {
            List<LC_Color> colors = new List<LC_Color>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string colorId = "";
                Label lblSectionId = (Label)grdColor.Rows[row.RowIndex].FindControl("lblColorId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    colorId = lblSectionId.Text.ToString();
                    colors = objColor_BLL.GetColorInfoByColorId(colorId, OCODE);

                    if (colors.Count > 0)
                    {                     
                        var col = colors.FirstOrDefault();
                        hidColorId.Value = col.ColorId.ToString();
                        hidColorName.Value = txtColor.Text = col.ColorName;
                        drpStatus.SelectedValue = col.Status;

                        if (btnColorSubmit.Text == "Submit")
                        {
                            btnColorSubmit.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdColor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdColor.PageIndex = e.NewPageIndex;
            GetColors();
        }
    }
}