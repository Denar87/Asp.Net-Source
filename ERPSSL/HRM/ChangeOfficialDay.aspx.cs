using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using AjaxControlToolkit;
using ERPSSL.HRM.DAL;
using ERPSSL;

namespace ERPSSL.HRM
{
    public partial class ChangeOfficialDay : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                    txtAttDate.Text = DateTime.Today.ToShortDateString();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                HRM_OfficialDay OfficialDayObj = new HRM_OfficialDay();
                OfficialDayObj.Official_Date = Convert.ToDateTime(txtAttDate.Text);
                OfficialDayObj.Working_Day = ddlWorkingDay.Text;
                OfficialDayObj.OT_Applicable = Convert.ToBoolean(ddlOTAppliocable.SelectedValue);
                OfficialDayObj.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                OfficialDayObj.Edit_Date = DateTime.Now;
                OfficialDayObj.OCode = OCODE;

                var result = objAtt_BLL.GetAllOfficeDay(OCODE, Convert.ToDateTime(txtAttDate.Text));
                if (result.Count > 0)
                {
                    objAtt_BLL.UpdateOffialType(OfficialDayObj, Convert.ToDateTime(txtAttDate.Text));  //update working day
                }
                else
                {
                    objAtt_BLL.InsertOffialType(OfficialDayObj);
                }

                HRM_ATTENDANCE attendanceDay = new HRM_ATTENDANCE();
                attendanceDay.Working_Day = ddlWorkingDay.Text;

                var result1 = objAtt_BLL.UpdateAtt_WorkingDay(OCODE, txtAttDate.Text, ddlWorkingDay.Text);
                if (result1 == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    //lblMessage.Text = "Data Update successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating Error!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                HRM_OfficialDay_Individual OfficialDayIndvidual = new HRM_OfficialDay_Individual();
                OfficialDayIndvidual.Official_Date = Convert.ToDateTime(txtDate.Text);
                OfficialDayIndvidual.Working_Day = ddlday.Text;
                OfficialDayIndvidual.OT_Applicable = Convert.ToBoolean(ddlOT.SelectedValue);
                OfficialDayIndvidual.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                OfficialDayIndvidual.Edit_Date = DateTime.Now;
                OfficialDayIndvidual.OCode = OCODE;
                OfficialDayIndvidual.EID = txtEid_TRNS.Text;

                var result = objAtt_BLL.GetAllOfficeDayById(OCODE, txtEid_TRNS.Text, Convert.ToDateTime(txtDate.Text));
                if (result.Count > 0)
                {
                    objAtt_BLL.UpdateOffialTypeById(OfficialDayIndvidual, Convert.ToDateTime(txtDate.Text), txtEid_TRNS.Text);  //update working day
                }
                else
                {
                    objAtt_BLL.InsertOfficeTypeIndividual(OfficialDayIndvidual);
                }

                HRM_ATTENDANCE attendanceDay = new HRM_ATTENDANCE();
                attendanceDay.Working_Day = ddlday.Text;



                var result1 = objAtt_BLL.UpdateAtt_WorkingDayById(OCODE, txtEid_TRNS.Text, txtDate.Text, ddlday.Text);
                if (result1 == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    //lblMessage.Text = "Data Update successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating Error!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtEid_TRNS_TextChanged(object sender, EventArgs e)
        {
            if (txtEid_TRNS.Text != "")
            {
                try
                {
                    string id = txtEid_TRNS.Text;
                    employeeDetails(id);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
            else
            {

            }

        }

        public void employeeDetails(string id)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(id);

                var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    // Emp_IMG_TRNS.Visible = true;
                    //  Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    var objNewEmp = result.First();
                    txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    //  Emp_IMG_TRNS.Visible = false;
                    txtEid_TRNS.Text = "";
                    txtEmpName_TRNS.Text = "";
                    txtDepartment.Text = "";
                    txtDesignation.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}