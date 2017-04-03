using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class IncomeHeadDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetHeaderes();
                    GetIncomeHeaderDetails();
                    GetChargeableDetails();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetChargeableDetails()
        {
            try
            {
                IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _incomeHeadbll.GetChargeableDetails(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpChargeableDetails.DataSource = row.ToList();
                    drpChargeableDetails.DataTextField = "IncomeHeaderDetils";
                    drpChargeableDetails.DataValueField = "IncomeHeaderDetailsID";
                    drpChargeableDetails.DataBind();
                    drpChargeableDetails.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetIncomeHeaderDetails()
        {
            IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<IncomeHeadDetailsV> IncomeDetails = _incomeHeadbll.GetIncomeHeaderDetails(OCODE);
                if (IncomeDetails.Count > 0)
                {
                    grdIncomeHeadDeatails.DataSource = IncomeDetails;
                    grdIncomeHeadDeatails.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetHeaderes()
        {
            try
            {
                IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _incomeHeadbll.GetIncomeHead(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpIncomeHead.DataSource = row.ToList();
                    drpIncomeHead.DataTextField = "IncomeHeader";
                    drpIncomeHead.DataValueField = "IncomeHeaderID";
                    drpIncomeHead.DataBind();
                    drpIncomeHead.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnIncomeHeadDeatils_Click(object sender, EventArgs e)
        {
            HRM_IncomeHeaderDetails _HrmIncomeHeaderDetails = new HRM_IncomeHeaderDetails();
            IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
            try
            {
                _HrmIncomeHeaderDetails.IncomeHeaderID = Convert.ToInt16(drpIncomeHead.SelectedValue.ToString());
                _HrmIncomeHeaderDetails.IncomeHeaderDetils = txtbxIncomeHeadDetails.Text.Trim();
                _HrmIncomeHeaderDetails.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _HrmIncomeHeaderDetails.EDIT_DATE = DateTime.Now;
                _HrmIncomeHeaderDetails.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (txtbxChargeable.Text != "")
                {
                    _HrmIncomeHeaderDetails.ChargeablePar = Convert.ToDouble(txtbxChargeable.Text);
                }
                else
                {
                    double valu = 0;
                    _HrmIncomeHeaderDetails.ChargeablePar = Convert.ToDouble(valu);
                }

                if (drpChargeableDetails.SelectedItem.ToString() != "--Select--")
                {
                    _HrmIncomeHeaderDetails.ChargeableDeatils = Convert.ToInt16(drpChargeableDetails.SelectedValue.ToString());

                }
                if (drpLessPuluss.SelectedItem.ToString() != "---Select---")
                {
                    _HrmIncomeHeaderDetails.PlussORLess = drpLessPuluss.SelectedItem.ToString();
                }





                if (btnIncomeHeadDeatils.Text == "Submit")
                {
                    int result = _incomeHeadbll.SaveIncomeHeaderDetails(_HrmIncomeHeaderDetails);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                }
                else
                {
                    _HrmIncomeHeaderDetails.IncomeHeaderDetailsID = Convert.ToInt16(hidIncomeHeadDetilsId.Value);
                    int result = _incomeHeadbll.UpdateIncomeHeaderDetails(_HrmIncomeHeaderDetails);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                }
                GetIncomeHeaderDetails();
                ClerController();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClerController()
        {
            btnIncomeHeadDeatils.Text = "Submit";
            txtbxIncomeHeadDetails.Text = "";
            drpIncomeHead.ClearSelection();
        }
        protected void imgIncomeHeadDetailsEdit_Click(object sender, EventArgs e)
        {

            HRM_IncomeHeaderDetails _HrmIncomeHeaderDetails = new HRM_IncomeHeaderDetails();
            IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                Label lblIncomeHeadDetialsId = (Label)grdIncomeHeadDeatails.Rows[row.RowIndex].FindControl("lblINcomeHeadDeailsId");
                if (lblIncomeHeadDetialsId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    string IncomeHeaderID = lblIncomeHeadDetialsId.Text;



                    _HrmIncomeHeaderDetails = _incomeHeadbll.GetIncomeHeaderDetilsBYId(IncomeHeaderID, OCODE);

                    if (_HrmIncomeHeaderDetails != null)
                    {
                        hidIncomeHeadDetilsId.Value = _HrmIncomeHeaderDetails.IncomeHeaderDetailsID.ToString();
                        txtbxIncomeHeadDetails.Text = _HrmIncomeHeaderDetails.IncomeHeaderDetils.ToString();
                        drpIncomeHead.SelectedValue = _HrmIncomeHeaderDetails.IncomeHeaderID.ToString();
                        if (btnIncomeHeadDeatils.Text == "Submit")
                        {
                            btnIncomeHeadDeatils.Text = "Update";
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