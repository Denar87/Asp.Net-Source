using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.PAYROLL
{
    public partial class EmployeeAdvanceSalary : System.Web.UI.Page
    {
        Increment_BLL objIncrementBll = new Increment_BLL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();
        AdvanceSalaryBLL adavanceSalaryBll = new AdvanceSalaryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillRegion();
                    //getAdvanceSlaryCode();

                    string advanceSalaryId = Convert.ToString(Session["employeeAdvanceSalaryId"]);
                    string eAdcode = Convert.ToString(Session["eAdcode"]);
                    if (advanceSalaryId != "" && eAdcode != "")
                    {
                        hiadvanceSalaryId.Value = advanceSalaryId;
                        hiAdCode.Value = eAdcode;
                        GetAdvanceSalaryDetails(advanceSalaryId);
                        btnSaveAdvance.Text = "Update";
                        ddlRegion.Enabled = false;
                        ddlOffice.Enabled = false;
                        drpDepartment.Enabled = false;
                        drpEmployee.Enabled = false;
                        Session.Remove("employeeAdvanceSalaryId");
                        Session.Remove("eAdcode");
                    }

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetAdvanceSalaryDetails(string advanceSalaryId)
        {

            try
            {

                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = employeeBenefitbll.GetAdvanceSalaryDetails(OCODE, advanceSalaryId).ToList();
                if (row.Count > 0)
                {
                    foreach (HRM_AdvanceSalarySummary aitem in row)
                    {
                        employeeDetails(aitem.EID);

                        if (aitem.OfficeId == null && aitem.DepartmentId == null && aitem.ResionId == null)
                        {

                            txtbxTotalAmount.Text = aitem.TotalAmount.ToString();
                            txtbxNoofInslament.Text = aitem.NoOfInstalment.ToString();
                            txtbxEndDate.Text = aitem.EndDate.ToString();
                            txtbxInstalment.Text = aitem.InstalmentAmount.ToString();
                            txtbxStartDate.Text = aitem.StartDate.ToString();
                            txtEid_TRNS.Text = aitem.EID.ToString();
                            if (aitem.Remarks == null)
                            {
                                txtRemarks.Text = "";
                            }
                            else
                            {
                                txtRemarks.Text = aitem.Remarks.ToString();
                            }
                        }
                        else
                        {
                            txtbxTotalAmount.Text = aitem.TotalAmount.ToString();
                            txtbxNoofInslament.Text = aitem.NoOfInstalment.ToString();
                            txtbxEndDate.Text = aitem.EndDate.ToString();
                            txtbxInstalment.Text = aitem.InstalmentAmount.ToString();
                            txtbxStartDate.Text = aitem.StartDate.ToString();
                            ddlRegion.SelectedValue = aitem.ResionId.ToString();
                            if (aitem.Remarks == null)
                            {
                                txtRemarks.Text = "";

                            }
                            else
                            {
                                txtRemarks.Text = aitem.Remarks.ToString();

                            }

                            int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                            FillOffice(RegionId);
                            ddlOffice.SelectedValue = aitem.OfficeId.ToString();
                            LoadDepartment();
                            drpDepartment.SelectedValue = aitem.DepartmentId.ToString();
                            setEmployee();
                            drpEmployee.SelectedValue = aitem.EID.ToString();

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private string getAdvanceSlaryCode()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int count = adavanceSalaryBll.GetLastRowNumber(OCODE);
                int total = count + 1;
                return " AV" + total;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FillRegion()
        {

            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = objIncrementBll.GetAllRegion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion.DataSource = row.ToList();
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();
                    ddlRegion.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
            FillOffice(RegionId);
        }
        private void FillOffice(int RegionId)
        {
            try
            {
                var row = objIncrementBll.GetOfficeByResionId(RegionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice.DataSource = row.ToList();
                    ddlOffice.DataTextField = "OfficeName";
                    ddlOffice.DataValueField = "OfficeID";
                    ddlOffice.DataBind();
                    ddlOffice.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadDepartment();

        }
        private void LoadDepartment()
        {
            try
            {
                int officeID = Convert.ToInt16(ddlOffice.SelectedValue);
                var row = objIncrementBll.GetDepartmentByOfficeId(officeID).ToList();
                if (row.Count > 0)
                {
                    drpDepartment.DataSource = row.ToList();
                    drpDepartment.DataTextField = "DPT_NAME";
                    drpDepartment.DataValueField = "DPT_ID";
                    drpDepartment.DataBind();
                    drpDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int DepartmentId = Convert.ToInt32(drpDepartment.SelectedValue);
                var employees = objIncrementBll.GetEmployeesByDepartmentId(DepartmentId).ToList();
                List<HRM_PersonalInfoInc> employess = new List<HRM_PersonalInfoInc>();
                foreach (var aitm in employees)
                {
                    HRM_PersonalInfoInc _aitem = new HRM_PersonalInfoInc();
                    _aitem.EMP_Name = aitm.FristName + " " + aitm.LastName;
                    _aitem.EID = aitm.EID;
                    employess.Add(_aitem);
                }
                if (employess.Count > 0)
                {

                    drpEmployee.DataSource = employess.ToList();
                    drpEmployee.DataTextField = "EMP_Name";
                    drpEmployee.DataValueField = "EID";
                    drpEmployee.DataBind();
                    drpEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void setEmployee()
        {
            try
            {
                int DepartmentId = Convert.ToInt32(drpDepartment.SelectedValue);
                var employees = objIncrementBll.GetEmployeesByDepartmentId(DepartmentId).ToList();
                if (employees.Count > 0)
                {

                    drpEmployee.DataSource = employees.ToList();
                    drpEmployee.DataTextField = "EMP_Name";
                    drpEmployee.DataValueField = "EID";
                    drpEmployee.DataBind();
                    drpEmployee.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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

        protected void drpEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = txtEid_TRNS.Text = drpEmployee.SelectedValue.ToString();
                employeeDetails(id);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtbxStartDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime statrdate = Convert.ToDateTime(txtbxStartDate.Text);
                int addedmonth = Convert.ToInt16(txtbxNoofInslament.Text);
                statrdate = statrdate.AddMonths(addedmonth);
                txtbxEndDate.Text = statrdate.ToShortDateString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSaveAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_AdvanceSalarySummary advanceSalarySummerybll = new HRM_AdvanceSalarySummary();
                List<HRM_AdvanceSalaryDetails> hrmAdvanceSalaryDetailes = new List<HRM_AdvanceSalaryDetails>();
                if (ddlRegion.SelectedValue != "" && ddlOffice.SelectedValue != "" && drpDepartment.SelectedValue != "" && drpEmployee.SelectedValue != "")
                {
                    advanceSalarySummerybll.OfficeId = Convert.ToInt16(ddlOffice.SelectedValue);
                    advanceSalarySummerybll.DepartmentId = Convert.ToInt16(drpDepartment.SelectedValue);
                    advanceSalarySummerybll.ResionId = Convert.ToInt16(ddlRegion.SelectedValue);
                    advanceSalarySummerybll.EID = txtEid_TRNS.Text;
                    advanceSalarySummerybll.InstalmentAmount = Convert.ToDecimal(txtbxInstalment.Text);
                    advanceSalarySummerybll.NoOfInstalment = Convert.ToInt16(txtbxNoofInslament.Text);
                    advanceSalarySummerybll.StartDate = Convert.ToDateTime(txtbxStartDate.Text);
                    advanceSalarySummerybll.TotalAmount = Convert.ToDecimal(txtbxTotalAmount.Text);
                    advanceSalarySummerybll.EndDate = Convert.ToDateTime(txtbxEndDate.Text);
                    advanceSalarySummerybll.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    advanceSalarySummerybll.EDIT_DATE = DateTime.Now;
                    advanceSalarySummerybll.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    advanceSalarySummerybll.ASCode = getAdvanceSlaryCode();
                    advanceSalarySummerybll.Remarks = txtRemarks.Text;

                }
                else
                {
                    //................HRM_AdvanceSalarySummary......................................//
                    advanceSalarySummerybll.EID = txtEid_TRNS.Text;
                    advanceSalarySummerybll.InstalmentAmount = Convert.ToDecimal(txtbxInstalment.Text);
                    advanceSalarySummerybll.NoOfInstalment = Convert.ToInt16(txtbxNoofInslament.Text);
                    advanceSalarySummerybll.StartDate = Convert.ToDateTime(txtbxStartDate.Text);
                    advanceSalarySummerybll.TotalAmount = Convert.ToDecimal(txtbxTotalAmount.Text);
                    advanceSalarySummerybll.EndDate = Convert.ToDateTime(txtbxEndDate.Text);
                    advanceSalarySummerybll.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    advanceSalarySummerybll.EDIT_DATE = DateTime.Now;
                    advanceSalarySummerybll.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    advanceSalarySummerybll.ASCode = getAdvanceSlaryCode();
                    advanceSalarySummerybll.Remarks = txtRemarks.Text;
                }



                //................HRM_AdvanceSalaryDetails......................................//
                DateTime begin = Convert.ToDateTime(txtbxStartDate.Text);
                DateTime end = Convert.ToDateTime(txtbxEndDate.Text);
                List<DateTime> dates = new List<DateTime>();
                for (DateTime date = begin; date < end; date = date.AddMonths(1))
                {


                    HRM_AdvanceSalaryDetails advanceSalaryDetils = new HRM_AdvanceSalaryDetails();
                    if (ddlRegion.SelectedValue != "" && ddlOffice.SelectedValue != "" && drpDepartment.SelectedValue != "" && drpEmployee.SelectedValue != "")
                    {
                        advanceSalaryDetils.OfficeId = Convert.ToInt16(ddlOffice.SelectedValue);
                        advanceSalaryDetils.DepartmentId = Convert.ToInt16(drpDepartment.SelectedValue);
                        advanceSalaryDetils.ResionId = Convert.ToInt16(ddlRegion.SelectedValue);
                        int month = date.Month;
                        int year = date.Year;
                        advanceSalaryDetils.Month = month;
                        advanceSalaryDetils.Year = year;
                        advanceSalaryDetils.EID = txtEid_TRNS.Text;
                        advanceSalaryDetils.TotalAmount = Convert.ToDecimal(txtbxTotalAmount.Text);
                        advanceSalaryDetils.InstalmentAmount = Convert.ToDecimal(txtbxInstalment.Text);
                        advanceSalaryDetils.NoOfInstalment = Convert.ToInt16(txtbxNoofInslament.Text);
                        advanceSalaryDetils.StartDate = Convert.ToDateTime(txtbxStartDate.Text);
                        advanceSalaryDetils.EndDate = Convert.ToDateTime(txtbxEndDate.Text);
                        advanceSalaryDetils.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        advanceSalaryDetils.EDIT_DATE = DateTime.Now;
                        advanceSalaryDetils.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        advanceSalaryDetils.AdvanceDeduction = false;
                        advanceSalaryDetils.Remarks = txtRemarks.Text;

                    }
                    else
                    {
                        int month = date.Month;
                        int year = date.Year;
                        advanceSalaryDetils.Month = month;
                        advanceSalaryDetils.Year = year;
                        advanceSalaryDetils.EID = txtEid_TRNS.Text;
                        advanceSalaryDetils.TotalAmount = Convert.ToDecimal(txtbxTotalAmount.Text);
                        advanceSalaryDetils.InstalmentAmount = Convert.ToDecimal(txtbxInstalment.Text);
                        advanceSalaryDetils.NoOfInstalment = Convert.ToInt16(txtbxNoofInslament.Text);
                        advanceSalaryDetils.StartDate = Convert.ToDateTime(txtbxStartDate.Text);
                        advanceSalaryDetils.EndDate = Convert.ToDateTime(txtbxEndDate.Text);
                        advanceSalaryDetils.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        advanceSalaryDetils.EDIT_DATE = DateTime.Now;
                        advanceSalaryDetils.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        advanceSalaryDetils.AdvanceDeduction = false;
                        advanceSalaryDetils.Remarks = txtRemarks.Text;
                    }

                    if (btnSaveAdvance.Text == "Update")
                    {
                        advanceSalaryDetils.ASCode = hiAdCode.Value;
                    }
                    else
                    {
                        advanceSalaryDetils.ASCode = getAdvanceSlaryCode();
                    }

                    hrmAdvanceSalaryDetailes.Add(advanceSalaryDetils);
                }

                if (btnSaveAdvance.Text == "Update")
                {
                    int adsalaryId = Convert.ToInt16(hiadvanceSalaryId.Value);
                    int result = adavanceSalaryBll.UpdateAdvanceSlarySummery(adsalaryId, advanceSalarySummerybll);
                    if (result == 1)
                    {
                        string codeId = hiAdCode.Value.ToString();
                        int result1 = adavanceSalaryBll.UpdateAdvanceSalaryDetails(codeId, hrmAdvanceSalaryDetailes);
                        if (result1 == 1)
                        {
                            lblMessage.Text = "Data Update Successfully.";
                        }

                    }
                }
                else
                {

                    int result = adavanceSalaryBll.SaveAdvanceSalarySummery(advanceSalarySummerybll);
                    if (result == 1)
                    {
                        int result1 = adavanceSalaryBll.SaveAdvanceSalaryDetails(hrmAdvanceSalaryDetailes);
                        if (result1 == 1)
                        {
                            lblMessage.Text = "Data Save Successfully.";
                            getAdvanceSlaryCode();
                        }
                    }
                }

                btnSaveAdvance.Text = "Submit";
                Response.Redirect("EmployeeAdvanceSalaryList.aspx");
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



    }
}