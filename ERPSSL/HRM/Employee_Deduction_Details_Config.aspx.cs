using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM;
using ERPSSL.HRM.DAL;
using ERPSSL.PAYROLL.BLL;
using ERPSSL.PAYROLL.DAL.Repository;
using System.Globalization;

namespace ERPSSL.HRM
{
    public partial class Employee_Deduction_Details_Config : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        TAXBLL aTAXBLL = new TAXBLL();
        EmployeeSetup_BLL aEmployeeSetup_BLL = new EmployeeSetup_BLL();

        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GerRegion1List();
                LoadMonth();
                //load 30 year
                int i = DateTime.Now.Year;
                for (i = i - 1; i <= DateTime.Now.Year + 30; i++)
                    ddlYearList.Items.Add(Convert.ToString(i));
            }
        }

        private void LoadMonth()
        {
            ddlMonthList.Items.Add(new ListItem("Select", 0.ToString()));
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)
            {
                ddlMonthList.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            }
            ddlMonthList.SelectedItem.Text = "";
            ddlMonthList.SelectedValue = "";
            //ddlMonthList.Items.Insert(0, new ListItem("--Select--"));
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

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
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
                if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region')", true);
                }

                else
                {
                    Attendance_BLL _attendancebll = new Attendance_BLL();

                    // by subsection
                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                        int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                        int sction = Convert.ToInt32(ddlSection.SelectedValue);
                        int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);

                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction, DateTime.Now);
                        List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                        foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                        {
                            HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                            aemployee.EID = aitem.EID;
                            // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                            aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                            aemployee.DEG_NAME = aitem.DEG_NAME;
                            aemployee.Salary_Month = ddlMonthList.SelectedItem.Text;
                            aemployee.Salary_Year = Convert.ToInt32(ddlYearList.SelectedValue);
                            aemployee.Is_Holiday = aitem.Is_Holiday;
                            aemployee.Tax_Amount = aitem.Tax_Amount;
                            newemployess.Add(aemployee);
                        }
                        List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                        if (assendingnewemployess.Count > 0)
                        {
                            grdview.DataSource = assendingnewemployess;
                            grdview.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            grdview.DataSource = null;
                            grdview.DataBind();
                        }
                    }

                    //by section
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text == "--Select--")
                    {
                        int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                        int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                        int section = Convert.ToInt32(ddlSection.SelectedValue);

                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeBySectionId(ResionId, OfficeId, DeptId, section, DateTime.Now);
                        List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                        foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                        {
                            HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                            aemployee.EID = aitem.EID;
                            // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                            aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                            aemployee.DEG_NAME = aitem.DEG_NAME;
                            aemployee.Salary_Month = ddlMonthList.SelectedItem.Text;
                            aemployee.Salary_Year = Convert.ToInt32(ddlYearList.SelectedValue);
                            aemployee.Is_Holiday = aitem.Is_Holiday;
                            aemployee.Tax_Amount = aitem.Tax_Amount;
                            newemployess.Add(aemployee);
                        }
                        List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                        if (assendingnewemployess.Count > 0)
                        {
                            grdview.DataSource = assendingnewemployess;
                            grdview.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            grdview.DataSource = null;
                            grdview.DataBind();
                        }
                    }

                    //by department
                    else if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                    {
                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeID(DeptId);
                        List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                        foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                        {
                            HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                            aemployee.EID = aitem.EID;
                            // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                            aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                            aemployee.DEG_NAME = aitem.DEG_NAME;
                            aemployee.Is_Holiday = aitem.Is_Holiday;
                            aemployee.Salary_Month = ddlMonthList.SelectedItem.Text;
                            aemployee.Salary_Year = Convert.ToInt32(ddlYearList.SelectedValue);
                            aemployee.Tax_Amount = aitem.Tax_Amount;
                            newemployess.Add(aemployee);
                        }

                        List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EID).ToList();

                        if (ascendingnewemployees.Count > 0)
                        {
                            grdview.DataSource = ascendingnewemployees;
                            grdview.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            grdview.DataSource = null;
                            grdview.DataBind();
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for process!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdview.Rows.Count < 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                }

                foreach (GridViewRow gvRow in grdview.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    HRM_Pay_Salary_Tax aHRM_Pay_Salary_Tax = new HRM_Pay_Salary_Tax();

                    Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                    TextBox txtTaxAmount = ((TextBox)gvRow.FindControl("txtTaxAmount"));

                    string eid = lblEID.Text.ToString();

                    var deduction = aTAXBLL.Get_Salary_Tax_ByEIDandDate(eid.ToString(), ddlMonthList.SelectedItem.Text, Convert.ToInt16(ddlYearList.SelectedValue)).ToList();

                    if (rowChkBox.Checked == true)
                    {
                        // tax insert
                        if (deduction.Count() == 0)
                        {
                            aHRM_Pay_Salary_Tax.EID = lblEID.Text;
                            aHRM_Pay_Salary_Tax.Tax_Month = ddlMonthList.SelectedItem.Text;
                            aHRM_Pay_Salary_Tax.Tax_Year = Convert.ToInt16(ddlYearList.SelectedValue);
                            aHRM_Pay_Salary_Tax.Remarks = txtbxremark.Text;
                            aHRM_Pay_Salary_Tax.Tax_Amount = Convert.ToDecimal(txtTaxAmount.Text);
                            aHRM_Pay_Salary_Tax.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            aHRM_Pay_Salary_Tax.EditDate = DateTime.Now;
                            aHRM_Pay_Salary_Tax.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                            _context.HRM_Pay_Salary_Tax.AddObject(aHRM_Pay_Salary_Tax);
                            _context.SaveChanges();

                            //update personalinfo
                            HRM_PersonalInformations aHRM_PersonalInformations = new HRM_PersonalInformations();
                            aHRM_PersonalInformations.Tax_Amount = Convert.ToDecimal(txtTaxAmount.Text);
                            aHRM_PersonalInformations.EDIT_DATE = DateTime.Now;
                            aHRM_PersonalInformations.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;

                            aEmployeeSetup_BLL.Update_PersonalInfo_DeductionDetails(aHRM_PersonalInformations, eid);

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);

                            grdview.DataSource = null;
                            grdview.DataBind();
                        }

                        //tax update
                        else
                        {
                            HRM_Pay_Salary_Tax _HRM_Pay_Salary_Tax = new HRM_Pay_Salary_Tax();
                            
                            _HRM_Pay_Salary_Tax = _context.HRM_Pay_Salary_Tax.Where(c => c.EID == eid).First();
                            _HRM_Pay_Salary_Tax.Tax_Amount = Convert.ToDecimal(txtTaxAmount.Text);
                            _HRM_Pay_Salary_Tax.Remarks = txtbxremark.Text;
                            _HRM_Pay_Salary_Tax.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            _HRM_Pay_Salary_Tax.EditDate = DateTime.Now;
                            _HRM_Pay_Salary_Tax.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                            _context.SaveChanges();

                            //update personalinfo
                            HRM_PersonalInformations aHRM_PersonalInformations = new HRM_PersonalInformations();
                            aHRM_PersonalInformations.Tax_Amount = Convert.ToDecimal(txtTaxAmount.Text);
                            aHRM_PersonalInformations.EDIT_DATE = DateTime.Now;
                            aHRM_PersonalInformations.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;

                            aEmployeeSetup_BLL.Update_PersonalInfo_DeductionDetails(aHRM_PersonalInformations, eid);

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                            grdview.DataSource = null;
                            grdview.DataBind();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {
            //ddlRegion1.ClearSelection();
            //ddlOffice1.ClearSelection();
            //ddlDept1.ClearSelection();
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            grdview.DataSource = null;
            grdview.DataBind();
        }
    }
}
