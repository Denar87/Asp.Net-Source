using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.UserControls
{
    public partial class AssignToEdit : System.Web.UI.UserControl
    {
        DEPARTMENT_BLL departmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_DAL empSetupDal = new EmployeeSetup_DAL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportingBoosDepartment();
                string employeeId = Convert.ToString(Session["EID"]);
                GetAssignToByEmployeeId(employeeId);
            }
        }

        private void GetAssignToByEmployeeId(string employeeId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<RAssignBossName> bossNames = new List<RAssignBossName>();
                bossNames = empSetupDal.GetBossNameById(employeeId, OCODE).ToList();
                if (bossNames.Count > 0)
                {
                    foreach (RAssignBossName name in bossNames)
                    {
                        if (name.FirstReportingBoss != null && name.SecondReportingBoss != null && name.thridReportingBoss != null)
                        {
                            lblFirstPerson.Text = name.FirstReportingBoss.ToString();
                            lblSecend.Text = name.SecondReportingBoss.ToString();
                            lblThridPerson.Text = name.thridReportingBoss.ToString();
                        }
                        else if (name.FirstReportingBoss != null && name.SecondReportingBoss != null)
                        {
                            lblFirstPerson.Text = name.FirstReportingBoss.ToString();
                            lblSecend.Text = name.SecondReportingBoss.ToString();
                        }
                        else if (name.FirstReportingBoss != null && name.thridReportingBoss != null)
                        {
                            lblFirstPerson.Text = name.FirstReportingBoss.ToString();
                            lblThridPerson.Text = name.thridReportingBoss.ToString();
                        }
                        else if (name.thridReportingBoss != null && name.SecondReportingBoss != null)
                        {
                            lblSecend.Text = name.SecondReportingBoss.ToString();
                            lblFirstPerson.Text = name.FirstReportingBoss.ToString();
                        }
                        else if (name.FirstReportingBoss != null)
                        {
                            lblFirstPerson.Text = name.FirstReportingBoss.ToString();
                        }
                        else if (name.SecondReportingBoss != null)
                        {
                            lblSecend.Text = name.SecondReportingBoss.ToString();
                        }
                        else if (name.thridReportingBoss != null)
                        {
                            lblThridPerson.Text = name.thridReportingBoss.ToString();
                        }



                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ReportingBoosDepartment()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpFirstReportingDepartment.DataSource = row.ToList();
                    drpFirstReportingDepartment.DataTextField = "DPT_NAME";
                    drpFirstReportingDepartment.DataValueField = "DPT_ID";
                    drpFirstReportingDepartment.DataBind();
                    drpFirstReportingDepartment.Items.Insert(0, new ListItem("--Select--"));


                    drpwownSecondDepartmetn.DataSource = row.ToList();
                    drpwownSecondDepartmetn.DataTextField = "DPT_NAME";
                    drpwownSecondDepartmetn.DataValueField = "DPT_ID";
                    drpwownSecondDepartmetn.DataBind();
                    drpwownSecondDepartmetn.Items.Insert(0, new ListItem("--Select--"));

                    drpdwnThridDepartment.DataSource = row.ToList();
                    drpdwnThridDepartment.DataTextField = "DPT_NAME";
                    drpdwnThridDepartment.DataValueField = "DPT_ID";
                    drpdwnThridDepartment.DataBind();
                    drpdwnThridDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ddlReportingTo_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = ddlReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtRptBossDsg.Text = assign.DeginationName.ToString();
                    txtbxAssignToId.Text = assign.EID.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void txtbxAssignToId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = txtbxAssignToId.Text;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    allDepartment();
                    allReportingBoss();
                    txtRptBossDsg.Text = assign.DeginationName.ToString();
                    drpFirstReportingDepartment.SelectedValue = assign.DepartmentId.ToString();
                    ddlReportingTo.SelectedValue = assign.EID;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void allDepartment()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpFirstReportingDepartment.DataSource = row.ToList();
                    drpFirstReportingDepartment.DataTextField = "DPT_NAME";
                    drpFirstReportingDepartment.DataValueField = "DPT_ID";
                    drpFirstReportingDepartment.DataBind();
                    drpFirstReportingDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        protected void txtbxSecondEdit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = txtbxSecondEdit.Text;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    AllDepartmentForSecondReportingBoss();
                    AllReportingBossUseSecondReportingBoss();
                    txtbxSecondDesignation.Text = assign.DeginationName.ToString();
                    drpwownSecondDepartmetn.SelectedValue = assign.DepartmentId.ToString();
                    drpSecondReportingTo.SelectedValue = assign.EID;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void AllReportingBossUseSecondReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                drpSecondReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
                drpSecondReportingTo.DataTextField = "FirstName";
                drpSecondReportingTo.DataValueField = "EID";
                drpSecondReportingTo.DataBind();
                drpSecondReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void AllDepartmentForSecondReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpwownSecondDepartmetn.DataSource = row.ToList();
                    drpwownSecondDepartmetn.DataTextField = "DPT_NAME";
                    drpwownSecondDepartmetn.DataValueField = "DPT_ID";
                    drpwownSecondDepartmetn.DataBind();
                    drpwownSecondDepartmetn.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void allReportingBoss()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ddlReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
                ddlReportingTo.DataTextField = "FirstName";
                ddlReportingTo.DataValueField = "EID";
                ddlReportingTo.DataBind();
                ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }


        protected void drpFirstReportingDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int departmentId = Convert.ToInt16(drpFirstReportingDepartment.SelectedValue);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                if (personalInfos.Count > 0)
                {
                    ddlReportingTo.DataSource = personalInfos;
                    ddlReportingTo.DataTextField = "FulllName";
                    ddlReportingTo.DataValueField = "EID";
                    ddlReportingTo.DataBind();
                    ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void drpwownSecondDepartmetn_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int departmentId = Convert.ToInt16(drpwownSecondDepartmetn.SelectedValue);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                if (personalInfos.Count > 0)
                {
                    drpSecondReportingTo.DataSource = personalInfos;
                    drpSecondReportingTo.DataTextField = "FulllName";
                    drpSecondReportingTo.DataValueField = "EID";
                    drpSecondReportingTo.DataBind();
                    drpSecondReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void drpSecondReportingTo_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = drpSecondReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtbxSecondDesignation.Text = assign.DeginationName.ToString();
                    drpwownSecondDepartmetn.SelectedValue = assign.DepartmentId.ToString();
                    txtbxSecondEdit.Text = assign.EID.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void txtbxThirdEditPerson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = txtbxThirdEditPerson.Text;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    AllDepartmentForThridReportingBoss();
                    AllReportingBossUseThridReportingBoss();

                    txtbxThirdDesignation.Text = assign.DeginationName.ToString();
                    drpdwnThridDepartment.SelectedValue = assign.DepartmentId.ToString();
                    drpdwnThirdReportingBoss.SelectedValue = assign.EID;
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        private void AllReportingBossUseThridReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                drpdwnThirdReportingBoss.DataSource = empSetupDal.GetPersonInfo().ToList();
                drpdwnThirdReportingBoss.DataTextField = "FirstName";
                drpdwnThirdReportingBoss.DataValueField = "EID";
                drpdwnThirdReportingBoss.DataBind();
                drpdwnThirdReportingBoss.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void AllDepartmentForThridReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpdwnThridDepartment.DataSource = row.ToList();
                    drpdwnThridDepartment.DataTextField = "DPT_NAME";
                    drpdwnThridDepartment.DataValueField = "DPT_ID";
                    drpdwnThridDepartment.DataBind();
                    drpdwnThridDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void drpdwnThirdReportingBoss_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = drpdwnThirdReportingBoss.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtbxThirdDesignation.Text = assign.DeginationName.ToString();
                    drpdwnThridDepartment.SelectedValue = assign.DepartmentId.ToString();
                    txtbxThirdEditPerson.Text = assign.EID.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void drpdwnThridDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int departmentId = Convert.ToInt16(drpdwnThridDepartment.SelectedValue);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                if (personalInfos.Count > 0)
                {
                    drpdwnThirdReportingBoss.DataSource = personalInfos;
                    drpdwnThirdReportingBoss.DataTextField = "FulllName";
                    drpdwnThirdReportingBoss.DataValueField = "EID";
                    drpdwnThirdReportingBoss.DataBind();
                    drpdwnThirdReportingBoss.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnTrt_Click(object sender, EventArgs e)
        {

            string employeeid = Convert.ToString(Session["EID"]);
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);
            ReportingBoosDepartment();
            if (personalObj != null)
            {
                if (personalObj.ReportingBossId != null)
                {
                    string firstReportingBossId = personalObj.ReportingBossId;
                    GetDepartmentByReportingBossId(firstReportingBossId);
                    ddlReportingTo.SelectedValue = personalObj.ReportingBossId.ToString();
                    txtbxAssignToId.Text = personalObj.ReportingBossId.ToString();

                }
                if (personalObj.SecondReportingBossId != null)
                {
                    string secondReportingBossId = personalObj.SecondReportingBossId;
                    GetDepartmentBySecondReportingBossId(secondReportingBossId);
                    drpSecondReportingTo.SelectedValue = personalObj.SecondReportingBossId;
                    txtbxSecondEdit.Text = personalObj.SecondReportingBossId;

                }
                if (personalObj.ThirdReportingBossId != null)
                {
                    string ThirdReportingBossId = personalObj.ThirdReportingBossId;
                    GetDepartmentByThirdReportingBossId(ThirdReportingBossId);
                    drpdwnThirdReportingBoss.SelectedValue = personalObj.ThirdReportingBossId;
                    txtbxThirdEditPerson.Text = personalObj.ThirdReportingBossId;
                }

            }


            btnAssignTo.Visible = true;
            ModalPopupExtender.Show();
        }

        private void GetAllAsignTo(string department)
        {
            try
            {
                int departmentId = Convert.ToInt32(department);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                if (personalInfos.Count > 0)
                {
                    ddlReportingTo.DataSource = personalInfos;
                    ddlReportingTo.DataTextField = "FulllName";
                    ddlReportingTo.DataValueField = "EID";
                    ddlReportingTo.DataBind();
                    ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetDepartmentByThirdReportingBossId(string ThirdReportingBossId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetDepartmentByReportingBossId(OCODE, ThirdReportingBossId);
                if (row.Count > 0)
                {

                    foreach (HRM_PersonalInformations aitem in row)
                    {
                        drpdwnThridDepartment.SelectedValue = aitem.DepartmentId.ToString();
                        GetAllAsignToForReportingBoss3(aitem.DepartmentId.ToString());
                        GetDesignationForReportingBoss3(ThirdReportingBossId);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetDesignationForReportingBoss3(string ThirdReportingBossId)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = ddlReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(ThirdReportingBossId, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtbxThirdDesignation.Text = assign.DeginationName.ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetAllAsignToForReportingBoss3(string department)
        {
            try
            {
                int departmentId = Convert.ToInt32(department);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                if (personalInfos.Count > 0)
                {
                    drpdwnThirdReportingBoss.DataSource = personalInfos;
                    drpdwnThirdReportingBoss.DataTextField = "FirstName";
                    drpdwnThirdReportingBoss.DataValueField = "EID";
                    drpdwnThirdReportingBoss.DataBind();
                    drpdwnThirdReportingBoss.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetDepartmentBySecondReportingBossId(string secondReportingBossId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetDepartmentByReportingBossId(OCODE, secondReportingBossId);
                if (row.Count > 0)
                {

                    foreach (HRM_PersonalInformations aitem in row)
                    {
                        drpwownSecondDepartmetn.SelectedValue = aitem.DepartmentId.ToString();
                        GetAllAsignToForReportingBoss2(aitem.DepartmentId.ToString());
                        GetDesignationForReportingBoss2(secondReportingBossId);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetDesignationForReportingBoss2(string secondReportingBossId)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = ddlReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(secondReportingBossId, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtbxSecondDesignation.Text = assign.DeginationName.ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetAllAsignToForReportingBoss2(string department)
        {
            try
            {
                int departmentId = Convert.ToInt32(department);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                if (personalInfos.Count > 0)
                {
                    drpSecondReportingTo.DataSource = personalInfos;
                    drpSecondReportingTo.DataTextField = "FulllName";
                    drpSecondReportingTo.DataValueField = "EID";
                    drpSecondReportingTo.DataBind();
                    drpSecondReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetDepartmentByReportingBossId(string firstReportingBossId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetDepartmentByReportingBossId(OCODE, firstReportingBossId);
                if (row.Count > 0)
                {

                    foreach (HRM_PersonalInformations aitem in row)
                    {
                        drpFirstReportingDepartment.SelectedValue = aitem.DepartmentId.ToString();
                        GetAllAsignTo(aitem.DepartmentId.ToString());
                        GetDesignation(firstReportingBossId);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetDesignation(string firstReportingBossId)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = ddlReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(firstReportingBossId, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtRptBossDsg.Text = assign.DeginationName.ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnAssignTo_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                string EmployeeId = Convert.ToString(Session["EID"]);

                personalInfo.ReportingBossId = ddlReportingTo.SelectedValue.ToString();

                personalInfo.SecondReportingBossId = drpSecondReportingTo.SelectedValue.ToString();

                personalInfo.ThirdReportingBossId = drpdwnThirdReportingBoss.SelectedValue.ToString();

                if (EmployeeId != null)
                {
                    int result = employeeSetUpBll.InsertPersonalInfoAssignTo(EmployeeId, personalInfo);
                    if (result == 1)
                    {
                        lblAssignTo.Text = "Data Save Successfully.";

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}