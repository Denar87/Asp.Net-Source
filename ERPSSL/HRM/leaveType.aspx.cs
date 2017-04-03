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
    public partial class leaveType : System.Web.UI.Page
    {
        LEAVE_BLL objLeave_BLL = new LEAVE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getLeaveTypes();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getLeaveTypes()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objLeave_BLL.GetAllLeaveType(OCODE).ToList();
                if (row.Count > 0)
                {
                    gridviewLeaveType.DataSource = row.ToList();
                    gridviewLeaveType.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnLeaveTypeSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtbxLeaveType.Text == "")
                {
                    //   lblMessage.Text = "";
                    //   lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func(Please Select Leave Type!'')", true);
                }
                else if (txtbxLeaveDays.Text == "")
                {
                    //   lblMessage.Text = "";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Leave Days!')", true);
                }


                else
                {
                    HRM_LEAVE_TYPE objLev = new HRM_LEAVE_TYPE();

                    objLev.LEV_TYPE = txtbxLeaveType.Text;
                    objLev.LEV_DAYS = Convert.ToInt32(txtbxLeaveDays.Text);
                    objLev.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objLev.EDIT_DATE = DateTime.Now;
                    objLev.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    if (btnLeaveTypeSubmit.Text == "Submit")
                    {
                        if (IsExist(objLev))
                        {
                            int result = objLeave_BLL.InsertLeaveType(objLev);
                            if (result == 1)
                            {
                                //  lblMessage.Text = "Data Save successfully!";
                                //  lblMessage.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                            }
                        }
                        else
                        {
                            // lblMessage.Text = "";
                            // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        }

                    }
                    else
                    {
                        int leaveTypeId = Convert.ToInt32(hidLeaveId.Value);
                        int result = objLeave_BLL.UpdateLeaveType(objLev, leaveTypeId);
                        if (result == 1)
                        {
                            //    lblMessage.Text = "Data Update successfully!";
                            //   lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        }

                    }
                    getLeaveTypes();
                    ClearAllTextbox();

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private bool IsExist(HRM_LEAVE_TYPE _LeaveType)
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();

                bool status = false;
                int count = (from rgn in _context.HRM_LEAVE_TYPE
                             where rgn.LEV_TYPE == _LeaveType.LEV_TYPE && rgn.LEV_DAYS == _LeaveType.LEV_DAYS
                             select rgn.LEV_TYPE).Count();
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

        private void ClearAllTextbox()
        {
            try
            {
                txtbxLeaveDays.Text = "";
                txtbxLeaveType.Text = "";
                btnLeaveTypeSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnLeaveTypeEdit_Click(object sender, EventArgs e)
        {
            List<HRM_LEAVE_TYPE> LeaveTypes = new List<HRM_LEAVE_TYPE>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string leavetypeId = "";
                Label lblLeaveTypeId = (Label)gridviewLeaveType.Rows[row.RowIndex].FindControl("lblLeaveId");
                if (lblLeaveTypeId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    leavetypeId = lblLeaveTypeId.Text;
                    LeaveTypes = objLeave_BLL.getLeaveTypeByLeaveIdandOcode(leavetypeId, OCODE);

                    if (LeaveTypes.Count > 0)
                    {
                        foreach (HRM_LEAVE_TYPE LeaveType in LeaveTypes)
                        {
                            hidLeaveId.Value = LeaveType.LEV_ID.ToString();
                            txtbxLeaveType.Text = LeaveType.LEV_TYPE;
                            txtbxLeaveDays.Text = LeaveType.LEV_DAYS.ToString();

                        }
                        if (btnLeaveTypeSubmit.Text == "Submit")
                        {
                            btnLeaveTypeSubmit.Text = "Update";
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