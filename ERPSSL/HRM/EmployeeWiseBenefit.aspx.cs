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
    public partial class EmployeeWiseBenefit : System.Web.UI.Page
    {
        Increment_BLL objIncrementBll = new Increment_BLL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillRegion();
                    GetBeneFitType();
                    txtEid_TRNS.ReadOnly = true;
                    txtEmpName_TRNS.ReadOnly = true;
                    txtDepartment.ReadOnly = true;
                    txtDesignation.ReadOnly = true;
                    string bebefitID = Convert.ToString(Session["EmployeeBenefitID"]);
                    if (bebefitID != "")
                    {
                        bebefitId.Value = bebefitID;
                        GetBenefitId(bebefitID);
                        btnSaveEmployeeWiseBebefit.Text = "Update";
                        ddlRegion.Enabled = false;
                        ddlOffice.Enabled = false;
                        drpDepartment.Enabled = false;
                        Session.Remove("EmployeeBenefitID");
                    }
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetBenefitId(string bebefitID)
        {
            try
            {

                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = employeeBenefitbll.GetBeneFitListById(OCODE, bebefitID).ToList();
                if (row.Count > 0)
                {
                    foreach (HRM_EmployeeWiseBenefit aitem in row)
                    {
                        employeeDetails(aitem.EID);
                        txtbxAmount.Text = aitem.Amount.ToString();
                        drpBenefitType.SelectedValue = aitem.BenefitTypeId.ToString();
                        txtbxEffectiveDate.Text = aitem.EffectiveDate.ToString();


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetBeneFitType()
        {

            try
            {

                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = employeeBenefitbll.GetBeneFitType(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpBenefitType.DataSource = row.ToList();
                    drpBenefitType.DataTextField = "Benefittype";
                    drpBenefitType.DataValueField = "BenefittypeId";
                    drpBenefitType.DataBind();
                    drpBenefitType.Items.Insert(0, new ListItem("--Select--", "0"));
                }
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
                    ddlRegion.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
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
                    ddlOffice.Items.Insert(0, new ListItem("--Select--"));
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
                    drpDepartment.Items.Insert(0, new ListItem("--Select--"));
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
                    drpEmployee.Items.Insert(0, new ListItem("--Select--"));
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
                    Emp_IMG_TRNS.Visible = true;
                    Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    var objNewEmp = result.First();
                    txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    Emp_IMG_TRNS.Visible = false;
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

        protected void btnSaveEmployeeWiseBebefit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_EmployeeWiseBenefit employeeWiseBenefitObj = new HRM_EmployeeWiseBenefit();

                employeeWiseBenefitObj.EID = drpEmployee.SelectedValue.ToString();
                employeeWiseBenefitObj.BenefitTypeId = Convert.ToInt16(drpBenefitType.SelectedValue);
                employeeWiseBenefitObj.Amount = Convert.ToDecimal(txtbxAmount.Text);
                employeeWiseBenefitObj.EffectiveDate = Convert.ToDateTime(txtbxEffectiveDate.Text);
                employeeWiseBenefitObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                employeeWiseBenefitObj.EDIT_DATE = DateTime.Now;
                employeeWiseBenefitObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnSaveEmployeeWiseBebefit.Text == "Update")
                {
                    string id = bebefitId.Value;
                    int result = employeeBenefitbll.UpdateUserWiseBebefit(employeeWiseBenefitObj, id);
                    if (result == 1)
                    {
                        Response.Redirect("EmployeeWiseBenefitList.aspx");
                    }

                }
                else
                {
                    employeeWiseBenefitObj.ResionId = Convert.ToInt16(ddlRegion.SelectedValue);
                    employeeWiseBenefitObj.OfficeId = Convert.ToInt16(ddlOffice.SelectedValue);
                    employeeWiseBenefitObj.DepartmentId = Convert.ToInt16(drpDepartment.SelectedValue.ToString());

                    int result = employeeBenefitbll.SaveUserWiseBebefit(employeeWiseBenefitObj);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Data Save Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                }
                btnSaveEmployeeWiseBebefit.Text = "Submit";
                Response.Redirect("EmployeeWiseBenefitList.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}