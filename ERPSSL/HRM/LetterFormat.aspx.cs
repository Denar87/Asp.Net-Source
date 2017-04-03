using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class LetterFormat : System.Web.UI.Page
    {
        LatterFormatBLL latterFormateBll = new LatterFormatBLL();
        LetterTypeBLL letterTypeBllObj = new LetterTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getLatterFormates();
                    GetLetterType();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetLetterType()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = letterTypeBllObj.GetAllLetterTypes(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpType.DataSource = row.ToList();
                    drpType.DataTextField = "LatterType";
                    drpType.DataValueField = "LatterTypeId";
                    drpType.DataBind();
                    drpType.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getLatterFormates()
        {
            try
            {
                String OCOde = ((SessionUser)Session["SessionUser"]).OCode;
                List<LatterFormate> latterFormates = latterFormateBll.getLatterFormates(OCOde);
                if (latterFormates.Count > 0)
                {
                    gridviewLatterFormate.DataSource = latterFormates;
                    gridviewLatterFormate.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnLetterFormate_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_LETTER_FORMAT latterForObj = new HRM_LETTER_FORMAT();
                latterForObj.LTR_Title = txtTitle.Text;
                latterForObj.LTR_Type = Convert.ToInt32(drpType.SelectedValue);
                latterForObj.LTR_Details = txtLatterDetails.Text;
                latterForObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                latterForObj.EDIT_DATE = DateTime.Now;
                latterForObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnLetterFormate.Text == "Submit")
                {
                    int result = latterFormateBll.SaveLatterFormate(latterForObj);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Save Successfully";
                        pnl_result.Visible = true;
                        ClearAllControll();
                    }
                }
                else
                {
                    int latterId = Convert.ToInt32(hidLatterFormateId.Value);
                    int result = latterFormateBll.UpdateLatterFormate(latterForObj, latterId);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Update Successfully";
                        pnl_result.Visible = true;
                        ClearAllControll();
                    }
                }
                ClearAllControll();
                getLatterFormates();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControll()
        {
            txtLatterDetails.Text = "";
            txtTitle.Text = "";
            btnLetterFormate.Text = "Submit";
        }

        protected void imgbtnLatterFormate_Click(object sender, EventArgs e)
        {
            List<HRM_LETTER_FORMAT> latterFormates = new List<HRM_LETTER_FORMAT>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string latterFormateId = "";
                Label lbllatterFormateId = (Label)gridviewLatterFormate.Rows[row.RowIndex].FindControl("lblLatterId");
                if (lbllatterFormateId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    latterFormateId = lbllatterFormateId.Text;
                    latterFormates = latterFormateBll.GetLatterFormateByLatterFormateID(latterFormateId, OCODE);

                    if (latterFormates.Count > 0)
                    {
                        foreach (HRM_LETTER_FORMAT latterFormate in latterFormates)
                        {
                            hidLatterFormateId.Value = latterFormate.LTR_ID.ToString();
                            txtTitle.Text = latterFormate.LTR_Title;
                            drpType.SelectedValue = latterFormate.LTR_Type.ToString();
                            txtLatterDetails.Text = latterFormate.LTR_Details;
                            if (btnLetterFormate.Text == "Submit")
                            {
                                btnLetterFormate.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}