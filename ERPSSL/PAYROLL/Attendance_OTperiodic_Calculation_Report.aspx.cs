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
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.PAYROLL
{
    public partial class Attendance_OTperiodic_Calculation_Report : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegion1List();
                    //txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    //txtDateTo.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void GerRegion1List()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion1.DataSource = row.ToList();
                    ddlRegion1.DataTextField = "RegionName";
                    ddlRegion1.DataValueField = "RegionID";
                    ddlRegion1.DataBind();
                    ddlRegion1.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void drpdwnResion1ForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                BridOfficeByResion1(ResionId);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void BridOfficeByResion1(int ResionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice1.DataSource = row.ToList();
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlOffice1.DataSource = null;
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);

                var row = objOfficeBLL.GetDeptByOfficeId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDept1.DataSource = row.ToList();
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlDept1.DataSource = null;
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnDepartment1SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDept1.SelectedValue);
                var row = SectionBll.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSection.DataSource = row;
                    ddlSection.DataTextField = "SEC_NAME";
                    ddlSection.DataValueField = "SEC_ID";
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //private void BindShiftCodeByDepartment(int ResionId, int OfficeId, int departmentId)
        //{
        //    var row = objOfficeBLL.GetShiftCodeByDept(ResionId, OfficeId, departmentId).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlShiftCode.DataSource = row.ToList();
        //        ddlShiftCode.DataTextField = "ShiftCode";
        //        ddlShiftCode.DataValueField = "ScheduleId";
        //        ddlShiftCode.DataBind();
        //        ddlShiftCode.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //    else
        //    {
        //        ddlShiftCode.DataSource = null;
        //        ddlShiftCode.DataTextField = "ShiftCode";
        //        ddlShiftCode.DataValueField = "ScheduleId";
        //        ddlShiftCode.DataBind();
        //        ddlShiftCode.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //}


        protected void ddlSection_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int sectionId = Convert.ToInt16(ddlSection.SelectedValue);
                var row = subSectionBll.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSubSections.DataSource = row;
                    ddlSubSections.DataTextField = "SUB_SEC_NAME";
                    ddlSubSections.DataValueField = "SUB_SEC_ID";
                    ddlSubSections.DataBind();
                    ddlSubSections.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }



        protected void ddlSubSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
            //int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
            //int departmentId = Convert.ToInt32(ddlDept1.SelectedValue);
            //BindShiftCodeByDepartment(RegionId, OfficeId, departmentId);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //HRM_TimeInoutOTCalculation objOTperiodic = new HRM_TimeInoutOTCalculation();
                //objOTperiodic.DateFrom = Convert.ToDateTime(txtDateFrom.Text);
                //objOTperiodic.DateTo = Convert.ToDateTime(txtDateTo.Text);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //objAtt_BLL.InsertOTperiodic(objOTperiodic);

                var result = objAtt_BLL.UpdateOTperiodic_ByDate01to15(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), OCODE);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                    //lblMessage.Text = "Data Update successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtDateFrom.Text = "";
                    txtDateTo.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processeing Error!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var result = objAtt_BLL.UpdateOTperiodic_ByDate16to31(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), OCODE);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                    //lblMessage.Text = "Data Update successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtDateFrom.Text = "";
                    txtDateTo.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processeing Error!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //List<REmployee> employees = new List<REmployee>();
                List<Attendance_Viewer> empAtendance = new List<Attendance_Viewer>();
                string fromDate = txtDateFrom.Text;
                string toDate = txtDateTo.Text;
                if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                {
                    empAtendance = aAttendance_RPT_Bll.GetrdAttendanceOTRegisterReportBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "DSAttendanceandOTRegister";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_AttendanceAndOTRegisterBySubSection.rdlc";
                        Session["rptTitle"] = "Attendance and OT Register";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Processed!')", true);
                    }
                }
                if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                {
                    empAtendance = aAttendance_RPT_Bll.GetrdAttendanceOTRegisterReportBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "DSAttendanceandOTRegister";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_AttendanceAndOTRegisterBySection.rdlc";
                        Session["rptTitle"] = "Attendance and OT Register";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Processed!')", true);
                    }
                }
                if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                {
                    empAtendance = aAttendance_RPT_Bll.GetrdAttendanceOTRegisterReportByDepartment(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "DSAttendanceandOTRegister";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_AttendanceAndOTRegisterByDepartment.rdlc";
                        Session["rptTitle"] = "Attendance and OT Register";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Processed!')", true);
                    }
                }
                else
                {
                    empAtendance = aAttendance_RPT_Bll.GetrdAttendanceOTRegisterReport(fromDate, toDate).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "DSAttendanceandOTRegister";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_AttendanceAndOTRegister.rdlc";
                        Session["rptTitle"] = "Attendance and OT Register";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Processed!')", true);
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