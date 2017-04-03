using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class IncomeHead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetIncomeHeader();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetIncomeHeader()
        {

            try
            {
                IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _incomeHeadbll.GetIncomeHead(OCODE).ToList();
                if (row.Count > 0)
                {
                    grdIncomeHead.DataSource = row.ToList();
                    grdIncomeHead.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnIncomeHead_Click(object sender, EventArgs e)
        {
            try
            {
                IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
                HRM_IncomeHeader _IncomeHeader = new HRM_IncomeHeader();
                _IncomeHeader.IncomeHeader = txtbxIncomeHead.Text.Trim();
                _IncomeHeader.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _IncomeHeader.EDIT_DATE = DateTime.Now;
                _IncomeHeader.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnIncomeHead.Text == "Submit")
                {
                    int result = _incomeHeadbll.SaveIncomeHeader(_IncomeHeader);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                }
                else
                {
                    _IncomeHeader.IncomeHeaderID = Convert.ToInt16(hidIncomeHeadId.Value);
                    int result = _incomeHeadbll.UpdateHeader(_IncomeHeader);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);

                    }

                }
                GetIncomeHeader();
                ClearController();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearController()
        {
            btnIncomeHead.Text = "Submit";
            txtbxIncomeHead.Text = "";
        }
        protected void imgIncomeHeadEdit_Click(object sender, EventArgs e)
        {
            IncomeHeadBLL _incomeHeadbll = new IncomeHeadBLL();
            HRM_IncomeHeader _IncomeHeader = new HRM_IncomeHeader();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string incomeHeadID = "";
                Label lblIncomeHeaderId = (Label)grdIncomeHead.Rows[row.RowIndex].FindControl("lblIncomeHead");
                if (lblIncomeHeaderId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    incomeHeadID = lblIncomeHeaderId.Text;
                    _IncomeHeader = _incomeHeadbll.GetInocmeHeadById(incomeHeadID, OCODE);

                    hidIncomeHeadId.Value = _IncomeHeader.IncomeHeaderID.ToString();
                    txtbxIncomeHead.Text = _IncomeHeader.IncomeHeader.ToString();
                    if (_IncomeHeader != null)
                    {

                        if (btnIncomeHead.Text == "Submit")
                        {
                            btnIncomeHead.Text = "Update";
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