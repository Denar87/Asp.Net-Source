using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.HRM.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.BuyingHouse.BLL;

namespace ERPSSL.BuyingHouse
{
    public partial class New_User : System.Web.UI.Page
    {
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        DESIGNATION_BLL designationBll = new DESIGNATION_BLL();
        GRADE_BLL gradeBll = new GRADE_BLL();
        New_UserBLL _NewUserBll = new New_UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegions();
                    GetAllDesignation();
                    GetAssetUserlist();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetAssetUserlist()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<RFEmployee> employees = new List<RFEmployee>();
                employees = _NewUserBll.GetEmployees(OCODE).ToList();
                if (employees.Count > 0)
                {
                    grdemployees.DataSource = employees;
                    grdemployees.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnGo_Click(object sender, EventArgs e)
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string[] EmpSrachItem = this.txtEmpSearch.Text.Split(' ');
                List<RFEmployee> employees = new List<RFEmployee>();

                employees = _NewUserBll.GetSearchEmployeesList(OCODE, EmpSrachItem[0]).ToList();
                if (employees.Count > 0)
                {
                    grdemployees.DataSource = employees;
                    grdemployees.DataBind();
                }
                else
                {
                    grdemployees.DataSource = null;
                    grdemployees.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {

            using (var _context = new ERPSSL_LCEntities())
            {
                var employees = from emp in _context.HRM_PersonalInformations
                                where ((emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false) && (emp.FirstName.StartsWith(prefixText) || emp.LastName.StartsWith(prefixText) || emp.EID.StartsWith(prefixText) || emp.Gender.StartsWith(prefixText) || emp.ContactNumber.StartsWith(prefixText) || emp.Email.StartsWith(prefixText)))
                                select emp;

                List<String> employeeList = new List<String>();

                foreach (var employee in employees)
                {
                    employeeList.Add(employee.FirstName + " " + employee.LastName);
                }

                //System.Threading.Thread.Sleep(500);
                return employeeList;
            }
        }

        protected void grdemployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdemployees.PageIndex = e.NewPageIndex;
            GetAssetUserlist();

        }


        protected void GetAllDesignation()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = designationBll.GetAllDesignation(OCODE);
                if (row.Count > 0)
                {
                    ddlDesignations.DataSource = row.ToList();
                    ddlDesignations.DataTextField = "DEG_NAME";
                    ddlDesignations.DataValueField = "DEG_ID";
                    ddlDesignations.DataBind();
                    ddlDesignations.AppendDataBoundItems = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void GerRegions()
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
            catch (Exception)
            {
                throw;
            }
        }
        private void BridOfficeByResion1(int ResionId)
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
        protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
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
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            string Requested_Eid = txtEmployeeId.Text;
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            GlobalClass.IsEidValid = employeeSetUpBll.CheckEidExitance(OCODE, Requested_Eid);
            if (GlobalClass.IsEidValid > 0)
            {
                Checkusername.Visible = true;
                imgstatus.ImageUrl = "../resources/ico/cross.png";
                lblStatus.Text = "E-ID Conflict!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Checkusername.Visible = true;
                imgstatus.ImageUrl = "../resources/ico/tick.png";
                lblStatus.Text = "E-ID Accepted!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                System.Threading.Thread.Sleep(2000);
            }
        }

        protected void ddlSection_SelecttedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void ddlSubSections_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                HRM_PersonalInformations _personalInfo = new HRM_PersonalInformations();
                _personalInfo.RegionsId = Convert.ToInt32(ddlRegion1.SelectedValue);
                _personalInfo.OfficeId = Convert.ToInt16(ddlOffice1.SelectedValue);
                _personalInfo.DepartmentId = Convert.ToInt16(ddlDept1.SelectedValue);
                _personalInfo.SectionId = Convert.ToInt16(ddlSection.SelectedValue);
                _personalInfo.DesginationId = Convert.ToInt16(ddlDesignations.SelectedValue);
                _personalInfo.Grade = "A";
                _personalInfo.Salary = 10000;
                _personalInfo.FirstName = txtUserName.Text;
                _personalInfo.EID = txtEmployeeId.Text;
                _personalInfo.Email = txtEmail.Text;
                _personalInfo.ContactNumber = txtPhone.Text;
                _personalInfo.EMP_TERMIN_STATUS = false;
                _personalInfo.EMP_TRANSFER_STATUS = false;
                _personalInfo.EMP_Retired_Status = false;
                _personalInfo.EMP_Resignation_Status = false;
                _personalInfo.EMP_Dismissal_Status = false;
                _personalInfo.EMP_Died_Status = false;
                _personalInfo.EMP_Other = false;
                _personalInfo.EMP_Dis_Continution_Status = false;
                _personalInfo.EDIT_DATE = DateTime.Now;
                _personalInfo.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = _NewUserBll.SaveAsset_User(_personalInfo);
                if (result == 1)
                {
                    GetAssetUserlist();
                    Clear();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully.')", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Clear()
        {
            ddlRegion1.ClearSelection();
            ddlOffice1.ClearSelection();
            ddlDept1.ClearSelection();
            ddlSection.ClearSelection();
            //ddlSubSections.ClearSelection();
            ddlDesignations.ClearSelection();
            txtUserName.Text = "";
            txtEmployeeId.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }
}