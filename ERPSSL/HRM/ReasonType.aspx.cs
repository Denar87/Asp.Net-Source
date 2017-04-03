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
    public partial class ReasonType : System.Web.UI.Page
    {
        ReasonTypeBLL reasonTypeObj = new ReasonTypeBLL();
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getReasonType();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getReasonType()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_ReasonType> ReasonTypes = reasonTypeObj.GetReasonType(Ocode);
                if (ReasonTypes.Count > 0)
                {
                    gridviewReasonType.DataSource = ReasonTypes;
                    gridviewReasonType.DataBind();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnReasonTypeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_ReasonType ReasonTypeObj = new HRM_ReasonType();
                ReasonTypeObj.ReasonType = txtbxReasonType.Text;
                ReasonTypeObj.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                ReasonTypeObj.Edit_Date = DateTime.Now;
                ReasonTypeObj.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                int Count = (from reason in _context.HRM_ReasonType
                             where reason.ReasonType == ReasonTypeObj.ReasonType
                             select reason.ReasonTypeId).Count();

                if (btnReasonTypeSubmit.Text == "Submit")
                {
                    if (Count != 0)
                    {
                        // lblMessage.Text = "";
                        // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        return;
                    }

                    int result = reasonTypeObj.InsertReasonType(ReasonTypeObj);
                    if (result == 1)
                    {
                        //   lblMessage.Text = "Data Save successfully!";
                        // lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);

                    }
                    else
                    {
                        //   lblMessage.Text = "";
                        // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding failure!')", true);
                    }

                }
                else
                {
                    int leaveTypeId = Convert.ToInt32(hidReasonTypeId.Value);
                    int result = reasonTypeObj.UpdateReasonType(ReasonTypeObj, leaveTypeId);
                    if (result == 1)
                    {
                        // lblMessage.Text = "Data Updated successfully!";
                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);

                    }
                    else
                    {
                        // lblMessage.Text = "";
                        //   lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure!')", true);
                    }
                }
                getReasonType();
                ClearAllControll();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControll()
        {
            try
            {
                txtbxReasonType.Text = "";
                btnReasonTypeSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnReasonTypeEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<HRM_ReasonType> LeaveTypes = new List<HRM_ReasonType>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ReasonTypeId = "";
                Label lblReasonTypeId = (Label)gridviewReasonType.Rows[row.RowIndex].FindControl("lblReasonTypeId");
                if (lblReasonTypeId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    ReasonTypeId = lblReasonTypeId.Text;
                    LeaveTypes = reasonTypeObj.GeReasonTypes(ReasonTypeId, OCODE);

                    if (LeaveTypes.Count > 0)
                    {
                        foreach (HRM_ReasonType ReasonType in LeaveTypes)
                        {
                            hidReasonTypeId.Value = ReasonType.ReasonTypeId.ToString();
                            txtbxReasonType.Text = ReasonType.ReasonType.ToString();


                        }
                        if (btnReasonTypeSubmit.Text == "Submit")
                        {
                            btnReasonTypeSubmit.Text = "Update";
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