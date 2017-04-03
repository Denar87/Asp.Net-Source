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

namespace ERPSSL.PAYROLL
{
    public partial class Salary_Deduction : System.Web.UI.Page
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
        Salary_Proccess_BLL aSalary_Proccess_BLL = new BLL.Salary_Proccess_BLL();
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
                    divDeductDay.Visible = false;
                    GerRegion1List();
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

        private void CheckIsDeducted()
        {
            try
            {
                //int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                //int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                //int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                //int sction = Convert.ToInt32(ddlSection.SelectedValue);
                //int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);
                Attendance_BLL _attendancebll = new Attendance_BLL();
                //List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetSalaryDeductionByEID(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtDate.Text));

                DateTime deductionDate = Convert.ToDateTime(txtDate.Text);
                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetSalaryDeductionByEID(deductionDate);

                if (employess.Count > 0)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                        CheckBox Checkbox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        DropDownList ddl = ((DropDownList)gvRow.FindControl("ddlSalaryDeductType"));

                        string eid = lblEID.Text;
                        var ispage = employess.FirstOrDefault(x => x.EID == eid && x.SalaryDeductDate == deductionDate);
                        if (ispage != null)
                        {
                            double? mm = ispage.salaryDeductDay;
                            if (mm > 0.5)
                            {
                                ddl.SelectedValue = "Full Day";
                            }
                            else
                            {
                                ddl.SelectedValue = "Half Day";
                            }

                            Checkbox.Checked = true;
                        }
                        else
                        {
                            Checkbox.Checked = false;
                        }
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
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region')", true);
                    return;
                }
                else if (ddlOffice1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Office')", true);
                    return;
                }
                else if (ddlDept1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Department')", true);
                    return;
                }
                else if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Deduction Date')", true);
                    return;
                }
                else
                {
                    try
                    {
                        
                        Attendance_BLL _attendancebll = new Attendance_BLL();
                        if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                        {
                            int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByDepartmentID(RegionId, OfficeId, DeptId, Convert.ToDateTime(txtDate.Text));

                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                                //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.Is_Holiday = aitem.Is_Holiday;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EMP_ID).ToList();

                            if (ascendingnewemployees.Count > 0)
                            {
                                grdview.DataSource = ascendingnewemployees;
                                grdview.DataBind();
                                CheckIsDeducted();
                            }
                        }
                        else
                        {
                            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                            int sction = Convert.ToInt32(ddlSection.SelectedValue);
                            int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtDate.Text));
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                                //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                aemployee.Is_Holiday = aitem.Is_Holiday;
                                newemployess.Add(aemployee);
                            }
                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EMP_ID).ToList();

                            if (assendingnewemployess.Count > 0)
                            {
                                grdview.DataSource = assendingnewemployess;
                                grdview.DataBind();
                                CheckIsDeducted();
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
                HRM_Salary_Deduction _Deduction = new HRM_Salary_Deduction();

                if (ckIndividualSalaryDeduction.Checked)  //individual
                {
                    if (txtbxEID.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter E-ID!')", true);
                        return;
                    }
                    if (txtDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Deduction Date!')", true);
                        return;
                    }
                    if (ddlDeductDay.SelectedItem.ToString() == "Select Deduct Type")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Deduct Type!')", true);
                        return;
                    }
                                    

                    //HRM_Salary_Deduction _Deduction = new HRM_Salary_Deduction();

                    //Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                    //TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));
                    //DropDownList deductionName = ((DropDownList)gvRow.FindControl("ddlSalaryDeductType"));
                    string date = txtDate.Text.ToString();
                    string eid = txtbxEID.Text.ToString();

                    var deduction = aSalary_Proccess_BLL.GetSalaryDeductionByEID_Date(eid.ToString(), date).ToList();

                      if (deduction.Count() == 0)
                        {
                            _Deduction.EID = eid;
                            _Deduction.Salary_DeductDate = Convert.ToDateTime(txtDate.Text);
                            _Deduction.Remark = txtbxremark.Text;
                            _Deduction.Salary_DeductType = "Half Day";

                            if (ddlDeductDay.SelectedItem.Text == "Half Day")
                            {
                                _Deduction.Salary_DeductDay = 0.5;
                            }
                            else
                            {
                                _Deduction.Salary_DeductDay = 1.0;
                            }
                            _Deduction.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            _Deduction.EditDate = DateTime.Now;
                            _Deduction.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                            _context.HRM_Salary_Deduction.AddObject(_Deduction);
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
                            ClearUI();
                        }
                        else
                        {
                            HRM_Salary_Deduction _Deduction1 = new HRM_Salary_Deduction();
                            try
                            {
                                DateTime DeductDate = Convert.ToDateTime(date.ToString());

                                _Deduction1 = _context.HRM_Salary_Deduction.Where(c => c.EID == eid && c.Salary_DeductDate == DeductDate).First();
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                            }
                            _Deduction1.Salary_DeductType = ddlDeductDay.SelectedItem.Text;
                            if (ddlDeductDay.SelectedItem.Text == "Half Day")
                            {
                                _Deduction1.Salary_DeductDay = 0.5;
                            }
                            else
                            {
                                _Deduction1.Salary_DeductDay = 1.0;
                            }

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
                            ClearUI();
                        }
                   

                }   
                else    //dpt wise process
                {
                    if (grdview.Rows.Count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                    }

                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        //HRM_Salary_Deduction _Deduction = new HRM_Salary_Deduction();

                        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                        TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));
                        DropDownList deductionName = ((DropDownList)gvRow.FindControl("ddlSalaryDeductType"));
                        string date = txtDate.Text.ToString();
                        string eid = lblEID.Text.ToString();

                        var deduction = aSalary_Proccess_BLL.GetSalaryDeductionByEID_Date(eid.ToString(), date).ToList();

                        if (rowChkBox.Checked == true)
                        {
                            if (deduction.Count() == 0)
                            {
                                _Deduction.EID = lblEID.Text;
                                _Deduction.Salary_DeductDate = Convert.ToDateTime(txtDate.Text);
                                _Deduction.Remark = txtbxremark.Text;
                                _Deduction.Salary_DeductType = deductionName.Text;

                                if (deductionName.Text == "Half Day")
                                {
                                    _Deduction.Salary_DeductDay = 0.5;
                                }
                                else
                                {
                                    _Deduction.Salary_DeductDay = 1.0;
                                }
                                _Deduction.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                _Deduction.EditDate = DateTime.Now;
                                _Deduction.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                                _context.HRM_Salary_Deduction.AddObject(_Deduction);
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
                                //ClearUI();
                            }
                            else
                            {
                                HRM_Salary_Deduction _Deduction1 = new HRM_Salary_Deduction();
                                try
                                {
                                    DateTime DeductDate = Convert.ToDateTime(date.ToString());

                                    _Deduction1 = _context.HRM_Salary_Deduction.Where(c => c.EID == eid && c.Salary_DeductDate == DeductDate).First();
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                }

                                _Deduction1.Salary_DeductType = deductionName.Text;
                                if (deductionName.Text == "Half Day")
                                {
                                    _Deduction1.Salary_DeductDay = 0.5;
                                }
                                else
                                {
                                    _Deduction1.Salary_DeductDay = 1.0;
                                }

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
                                //ClearUI();
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

            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            txtDate.Text = "";
            txtbxEID.Text = "";
            txtbxName.Text = "";
            txtbxDepartment.Text = "";
            ddlDeductDay.ClearSelection();
            txtbxDesgination.Text = "";

            grdview.DataSource = null;
            grdview.DataBind();
        }

        protected void grdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // if (e.Row.RowType == DataControlRowType.DataRow)
            // {
            if (!string.IsNullOrEmpty(e.Row.Cells[6].Text))
            {
                if (e.Row.Cells[6].Text == "Weekend Day")
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Wheat;
                }
                //else
                //{
                //    e.Row.Cells[3].ForeColor = System.Drawing.Color.Black;
                //    e.Row.Cells[3].BackColor = System.Drawing.Color.Orange;
                //}
            }
        }
        // }
        protected void txtbxEID_TextChangeEvent(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtbxEID.Text);
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ckIndividualSalaryDeduction_click(object sender, EventArgs e)
        {
            try
            {
                if (ckIndividualSalaryDeduction.Checked)
                {
                    txtbxEID.Text = "";
                    region.Visible = false;
                    office.Visible = false;
                    department.Visible = false;
                    section.Visible = false;
                    subSection.Visible = false;
                    divEid.Visible = true;
                    divDesgination.Visible = true;
                    divName.Visible = true;
                    divIndiDepartment.Visible = true;
                    btnProcess.Visible = false;
                    divDeductDay.Visible = true;
                }
                else
                {
                    txtbxEID.Text = "";
                    region.Visible = true;
                    office.Visible = true;
                    department.Visible = true;
                    section.Visible = true;
                    subSection.Visible = true;
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
                    btnProcess.Visible = true;
                    divDeductDay.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}
