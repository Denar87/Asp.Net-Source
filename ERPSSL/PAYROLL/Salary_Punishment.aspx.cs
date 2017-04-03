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

namespace ERPSSL.PAYROLL
{
    public partial class Salary_Punishment : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        Salary_Proccess_BLL aSalary_Proccess_BLL = new Salary_Proccess_BLL();
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                divEid.Visible = false;
                divDesgination.Visible = false;
                divName.Visible = false;
                divIndiDepartment.Visible = false;
                divDiductdayamt.Visible = false;
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
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region!')", true);
                }
                else if (ddlOffice1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Office!')", true);
                    return;
                }
                else if (ddlDept1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Department!')", true);
                    return;
                }
                else if (ddlDeductionType.SelectedItem.ToString() == "-- Select Type--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Deduction Type!')", true);
                }

                else
                {
                    try
                    {
                        Attendance_BLL _attendancebll = new Attendance_BLL();
                        if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
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
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EID).ToList();

                            if (ascendingnewemployees.Count > 0)
                            {
                                grdview.DataSource = ascendingnewemployees;
                                grdview.DataBind();
                            }
                        }
                        else
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
                                newemployess.Add(aemployee);
                            }
                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                            if (assendingnewemployess.Count > 0)
                            {
                                grdview.DataSource = assendingnewemployess;
                                grdview.DataBind();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                //ImageButton imgbtn = (ImageButton)sender;
                //GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                //CheckBox rowChkBox1 = (CheckBox)grdview.Rows[row.RowIndex].FindControl("rowLevelCheckBox");

                if (ckIndividualSalaryPunish.Checked)
                {
                    if (txtbxEID.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter E-ID!')", true);
                        return;
                    }
                    else if (ddlMonthList.SelectedItem.ToString() == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Month!')", true);
                        return;
                    }
                  
                    else if (ddlDeductionType.SelectedItem.ToString() == "-- Select Type--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Deduction Type!')", true);
                    }
                    else if (txtbxDeduct.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter Deduct Amount!')", true);
                        return;
                    }

                    if (ddlDeductionType.SelectedItem.Text == "Day")
                    {
                                                 

                            HRM_Salary_Punishment _punishment = new HRM_Salary_Punishment();
                            string txttotalDeductDayOrAmt = txtbxDeduct.Text;

                            string eid = txtbxEID.Text.ToString();

                            var deduction = aSalary_Proccess_BLL.GetAllSalaryPunishmentByEID(eid.ToString(), ddlMonthList.SelectedItem.Text, Convert.ToInt16(ddlYearList.SelectedValue)).ToList();

                           
                                if (deduction.Count() == 0)
                                {
                                    _punishment.EID = txtbxEID.Text;
                                    _punishment.Salary_Month = ddlMonthList.SelectedItem.Text;
                                    _punishment.Salary_Year = Convert.ToInt16(ddlYearList.SelectedValue);
                                    _punishment.Remark = txtbxremark.Text;
                                    _punishment.TotalDeductDay = Convert.ToDouble(txttotalDeductDayOrAmt);
                                    _punishment.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    _punishment.EditDate = DateTime.Now;
                                    _punishment.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    _context.HRM_Salary_Punishment.AddObject(_punishment);
                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);

                                        //grdview.DataSource = null;
                                        //grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                                else
                                {
                                    HRM_Salary_Punishment _punishment1 = new HRM_Salary_Punishment();
                                    try
                                    {
                                        _punishment1 = _context.HRM_Salary_Punishment.Where(c => c.EID == eid).First();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }

                                    _punishment1.TotalDeductDay = Convert.ToDouble(txttotalDeductDayOrAmt);
                                    _punishment1.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    _punishment1.EditDate = DateTime.Now;
                                    _punishment1.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                        //grdview.DataSource = null;
                                        //grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                            
                        
                    }

                    else
                    {
                      

                            HRM_Pay_Salary_Deduction sHRM_Pay_Salary_Deduction = new HRM_Pay_Salary_Deduction();



                            string txttotalDeductDayOrAmt = txtbxDeduct.Text;

                            string eid = txtbxEID.Text.ToString();

                            var deduction = aSalary_Proccess_BLL.GetAllSalaryPunishmentByAmount(eid.ToString(), ddlMonthList.SelectedItem.Text, Convert.ToInt16(ddlYearList.SelectedValue)).ToList();

                           
                                if (deduction.Count() == 0)
                                {
                                    sHRM_Pay_Salary_Deduction.EID = txtbxEID.Text;
                                    sHRM_Pay_Salary_Deduction.Deduct_Month = ddlMonthList.SelectedItem.Text;
                                    sHRM_Pay_Salary_Deduction.Deduct_Year = Convert.ToInt16(ddlYearList.SelectedValue);
                                    sHRM_Pay_Salary_Deduction.Deduct_Purpose = txtbxremark.Text;
                                    sHRM_Pay_Salary_Deduction.Salary_Deduct_Amount = Convert.ToDecimal(txttotalDeductDayOrAmt);
                                    sHRM_Pay_Salary_Deduction.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                    sHRM_Pay_Salary_Deduction.EditDate = DateTime.Now;
                                    sHRM_Pay_Salary_Deduction.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    _context.HRM_Pay_Salary_Deduction.AddObject(sHRM_Pay_Salary_Deduction);
                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);

                                        //grdview.DataSource = null;
                                        //grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                                else
                                {
                                    HRM_Pay_Salary_Deduction sHRM_Pay_Salary_Deduction1 = new HRM_Pay_Salary_Deduction();
                                    try
                                    {
                                        sHRM_Pay_Salary_Deduction1 = _context.HRM_Pay_Salary_Deduction.Where(c => c.EID == eid).First();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }

                                    sHRM_Pay_Salary_Deduction1.Salary_Deduct_Amount = Convert.ToDecimal(txttotalDeductDayOrAmt);
                                    sHRM_Pay_Salary_Deduction1.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                    sHRM_Pay_Salary_Deduction1.EditDate = DateTime.Now;
                                    sHRM_Pay_Salary_Deduction1.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                        //grdview.DataSource = null;
                                        //grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                           
                       
                    }
                    ClearUI();
                }

                else
                {
                    if (grdview.Rows.Count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                    }
                    if (ddlDeductionType.SelectedItem.Text == "Day")
                    {
                        foreach (GridViewRow gvRow in grdview.Rows)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                            HRM_Salary_Punishment _punishment = new HRM_Salary_Punishment();

                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            TextBox txttotalDeductDayOrAmt = ((TextBox)gvRow.FindControl("txttotalDeductDayOrAmt"));

                            string eid = lblEID.Text.ToString();

                            var deduction = aSalary_Proccess_BLL.GetAllSalaryPunishmentByEID(eid.ToString(), ddlMonthList.SelectedItem.Text, Convert.ToInt16(ddlYearList.SelectedValue)).ToList();

                            if (rowChkBox.Checked == true)
                            {
                                if (deduction.Count() == 0)
                                {
                                    _punishment.EID = lblEID.Text;
                                    _punishment.Salary_Month = ddlMonthList.SelectedItem.Text;
                                    _punishment.Salary_Year = Convert.ToInt16(ddlYearList.SelectedValue);
                                    _punishment.Remark = txtbxremark.Text;
                                    _punishment.TotalDeductDay = Convert.ToDouble(txttotalDeductDayOrAmt.Text);
                                    _punishment.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    _punishment.EditDate = DateTime.Now;
                                    _punishment.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    _context.HRM_Salary_Punishment.AddObject(_punishment);
                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);

                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                                else
                                {
                                    HRM_Salary_Punishment _punishment1 = new HRM_Salary_Punishment();
                                    try
                                    {
                                        _punishment1 = _context.HRM_Salary_Punishment.Where(c => c.EID == eid).First();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }

                                    _punishment1.TotalDeductDay = Convert.ToDouble(txttotalDeductDayOrAmt.Text);
                                    _punishment1.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    _punishment1.EditDate = DateTime.Now;
                                    _punishment1.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        foreach (GridViewRow gvRow in grdview.Rows)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                            HRM_Pay_Salary_Deduction sHRM_Pay_Salary_Deduction = new HRM_Pay_Salary_Deduction();

                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            TextBox txttotalDeductDayOrAmt = ((TextBox)gvRow.FindControl("txttotalDeductDayOrAmt"));

                            string eid = lblEID.Text.ToString();

                            var deduction = aSalary_Proccess_BLL.GetAllSalaryPunishmentByAmount(eid.ToString(), ddlMonthList.SelectedItem.Text, Convert.ToInt16(ddlYearList.SelectedValue)).ToList();

                            if (rowChkBox.Checked == true)
                            {
                                if (deduction.Count() == 0)
                                {
                                    sHRM_Pay_Salary_Deduction.EID = lblEID.Text;
                                    sHRM_Pay_Salary_Deduction.Deduct_Month = ddlMonthList.SelectedItem.Text;
                                    sHRM_Pay_Salary_Deduction.Deduct_Year = Convert.ToInt16(ddlYearList.SelectedValue);
                                    sHRM_Pay_Salary_Deduction.Deduct_Purpose = txtbxremark.Text;
                                    sHRM_Pay_Salary_Deduction.Salary_Deduct_Amount = Convert.ToDecimal(txttotalDeductDayOrAmt.Text);
                                    sHRM_Pay_Salary_Deduction.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                    sHRM_Pay_Salary_Deduction.EditDate = DateTime.Now;
                                    sHRM_Pay_Salary_Deduction.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    _context.HRM_Pay_Salary_Deduction.AddObject(sHRM_Pay_Salary_Deduction);
                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);

                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                                else
                                {
                                    HRM_Pay_Salary_Deduction sHRM_Pay_Salary_Deduction1 = new HRM_Pay_Salary_Deduction();
                                    try
                                    {
                                        sHRM_Pay_Salary_Deduction1 = _context.HRM_Pay_Salary_Deduction.Where(c => c.EID == eid).First();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }

                                    sHRM_Pay_Salary_Deduction1.Salary_Deduct_Amount = Convert.ToDecimal(txttotalDeductDayOrAmt.Text);
                                    sHRM_Pay_Salary_Deduction1.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                    sHRM_Pay_Salary_Deduction1.EditDate = DateTime.Now;
                                    sHRM_Pay_Salary_Deduction1.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                    try
                                    {
                                        _context.SaveChanges();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
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

        private void ClearUI()
        {

            //ddlRegion1.ClearSelection();
            //ddlOffice1.ClearSelection();
            //ddlDept1.ClearSelection();
            txtbxEID.Text = "";
            txtbxName.Text = "";
            txtbxDepartment.Text = "";
            txtbxDesgination.Text = "";
            txtbxDeduct.Text = "";

            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            grdview.DataSource = null;
            grdview.DataBind();

        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchCustomers(string prefixText, int count)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var employees = from emp in _context.HRM_PersonalInformations
                                where ((emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false) && (emp.FirstName.StartsWith(prefixText) || emp.LastName.StartsWith(prefixText) || emp.EID.StartsWith(prefixText) || emp.Gender.StartsWith(prefixText) || emp.ContactNumber.StartsWith(prefixText) || emp.Email.StartsWith(prefixText)))
                                select emp;

                List<String> employeeList = new List<String>();

                foreach (var employee in employees)
                {
                    employeeList.Add(employee.EID + "-" + employee.FirstName + "-" + employee.LastName);
                }

                //System.Threading.Thread.Sleep(500);
                return employeeList;
            }
        }
        protected void txtbxEID_TextChangeEvent(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string employeeID = Convert.ToString(txtbxEID.Text);
                int index = txtbxEID.Text.IndexOf('-');
                string employeeID = txtbxEID.Text.Substring(0, index);
                //Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtbxEID.Text = Convert.ToString(objNewEmp.EID);
                    txtbxName.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtbxDesgination.Text = objNewEmp.DPT_NAME;
                    txtbxDepartment.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Not Available!')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ckIndividualSalaryPunish_click(object sender, EventArgs e)
        {
            try
            {
                if (ckIndividualSalaryPunish.Checked)
                {
                    txtbxEID.Text = "";
                    region.Visible = false;
                    office.Visible = false;
                    department.Visible = false;
                    section.Visible = false;
                    subsection.Visible = false;
                    divEid.Visible = true;
                    divDesgination.Visible = true;
                    divName.Visible = true;
                    divIndiDepartment.Visible = true;
                    //divDeduct.Visible = true;
                    divDiductdayamt.Visible = true;
                    btnProcess.Visible = false;

                }
                else
                {
                    txtbxEID.Text = "";
                    region.Visible = true;
                    office.Visible = true;
                    department.Visible = true;
                    section.Visible = true;
                    subsection.Visible = true;
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
                    btnProcess.Visible = true;
                   // divDeduct.Visible = false;
                    divDiductdayamt.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}
