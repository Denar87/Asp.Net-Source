using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class EmpDataInport : System.Web.UI.Page
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
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
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
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlSubSections_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btn_Confirm_Clcik(object sender, EventArgs e)
        {
            employeeSetUpBll.InsertPresonalInfoTable();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Process Confirm Successfully!')", true);
        }
        protected void btnProcess_Clcik(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {

                    string sPath = Server.MapPath(FileUpload1.FileName);
                    FileUpload1.SaveAs(sPath);
                    ImporttoSQL(sPath);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }


        }
        protected void btnDounload_Click(object sender, EventArgs e)
        {
            try
            {
                string rootPath = Server.MapPath("../HRM/EmployeeDataFromate/");
                string filePath = "DataFormat.xls";
                string fullPath = rootPath + filePath;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filePath);
                Response.WriteFile(fullPath);
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ImporttoSQL(string sPath)
        {
            try
            {
                //http://codedisplay.com/how-to-import-excel-sheet-data-into-sql-server-table-using-asp-net-c-vb-net/
                // Connect to Excel 2007 earlier version
                //string sSourceConstr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\AgentList.xls; Extended Properties=""Excel 8.0;HDR=YES;""";
                // Connect to Excel 2007 (and later) files with the Xlsx file extension 
                string sSourceConstr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", sPath);
                string sDestConstr = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
                OleDbConnection sSourceConnection = new OleDbConnection(sSourceConstr);
                string Region = ddlRegion1.SelectedItem.Text;
                string office = ddlOffice1.SelectedItem.Text;
                string department = ddlDept1.SelectedItem.Text;
                string section = ddlSection.SelectedItem.Text;
                string subsection = ddlSubSections.SelectedItem.Text;

                //and Department='" + department + "' and Office ='" + office + "' and Section ='" + section + "'[Region]='" + Region + "' and [Department] ='" + department + "'

                using (sSourceConnection)
                {
                    string sql = string.Format("Select [E-ID],[Bio Matrix-ID],[Frist Name],[Last Name],[Gender],[Date of Birth],[Religion],[Blood Group],[Region],[Office],[Department],[Section],[Section Line],[Designation],[Joning Date],[Grade],[Gross Salary],[OT Applicable(Yes/No)],[Contact No],[Fathers Name],[Mothers Name],[Permanent Address],[Present Address],[Emergency Contact No],[Emergency Contact Person],[Marital Status],[Nationality],[N-ID],[Nominee Name]  FROM [{0}] where [Region]='" + Region + "'and [Office] ='" + office + "' and [Department] ='" + department + "' and [Section] ='" + section + "' and [Section Line] ='" + subsection + "' and [Designation] is not null and [Grade] is not null and [Gross Salary] is not null and [OT Applicable(Yes/No)] is not null", "Sheet1$");
                    OleDbCommand command = new OleDbCommand(sql, sSourceConnection);
                    sSourceConnection.Open();
                    using (OleDbDataReader dr = command.ExecuteReader())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sDestConstr))
                        {

                            bulkCopy.DestinationTableName = "Hrm_PersonalInfoTemp";
                            bulkCopy.ColumnMappings.Clear();

                            bulkCopy.ColumnMappings.Add("[E-ID]", "EID");
                            bulkCopy.ColumnMappings.Add("[Bio Matrix-ID]", "BIO_MATRIX_ID");

                            bulkCopy.ColumnMappings.Add("[Frist Name]", "FirstName");
                            bulkCopy.ColumnMappings.Add("[Last Name]", "LastName");
                            bulkCopy.ColumnMappings.Add("[Gender]", "Gender");
                            bulkCopy.ColumnMappings.Add("[Blood Group]", "BloodGroup");
                            bulkCopy.ColumnMappings.Add("[Religion]", "Religion");

                            bulkCopy.ColumnMappings.Add("[N-ID]", "NationalID");
                            bulkCopy.ColumnMappings.Add("[Fathers Name]", "FatherName");
                            bulkCopy.ColumnMappings.Add("[Mothers Name]", "MotherName");
                            bulkCopy.ColumnMappings.Add("[Present Address]", "PresentAddress");
                            bulkCopy.ColumnMappings.Add("[Permanent Address]", "PermanenAddress");

                            bulkCopy.ColumnMappings.Add("[Nationality]", "Nationality");
                            bulkCopy.ColumnMappings.Add("[Contact No]", "ContactNumber");
                            bulkCopy.ColumnMappings.Add("[Emergency Contact No]", "EmergencyContactNo");
                            bulkCopy.ColumnMappings.Add("[Emergency Contact Person]", "EmergencyContactPerson");
                            bulkCopy.ColumnMappings.Add("[Nominee Name]", "NomineeName");
                            bulkCopy.ColumnMappings.Add("[Section Line]", "SubSection");

                            bulkCopy.ColumnMappings.Add("[Section]", "Section");
                            bulkCopy.ColumnMappings.Add("[Department]", "Department");
                            bulkCopy.ColumnMappings.Add("[Region]", "Regions");
                            bulkCopy.ColumnMappings.Add("[Office]", "Office");
                            bulkCopy.ColumnMappings.Add("[Designation]", "Desgination");

                            bulkCopy.ColumnMappings.Add("[Grade]", "Grade");
                            bulkCopy.ColumnMappings.Add("[Gross Salary]", "Salary");
                            bulkCopy.ColumnMappings.Add("[Joning Date]", "JoiningDateFromU");
                            bulkCopy.ColumnMappings.Add("[OT Applicable(Yes/No)]", "OTApplicableFU");
                            bulkCopy.ColumnMappings.Add("[Date of Birth]", "DateOfBrith");
                            bulkCopy.ColumnMappings.Add("[Marital Status]", "MaritalStatus");

                            bulkCopy.WriteToServer(dr);
                            sSourceConnection.Close();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully!')", true);
                            SaveDeg();
                            ShowDuplicateData();



                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void SaveDeg()
        {
            try
            {
                string usrId = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                string date = DateTime.Now.ToString();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<Hrm_PersonalInfoTemp> Pinfoes = getEmpInfo();
                employeeSetUpBll.InsertDegi(Pinfoes, usrId, date, Ocode);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private List<Hrm_PersonalInfoTemp> getEmpInfo()
        {
            try
            {
                var query = (from ar in _context.Hrm_PersonalInfoTemp
                             select ar).OrderByDescending(ar => ar.EID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

        private void ShowDuplicateData()
        {
            try
            {
                List<Hrm_PersonalInfoTemp> persones = employeeSetUpBll.GetDublicateList();
                if (persones.Count > 0)
                {
                    gridGridviewDublicate.DataSource = persones;
                    gridGridviewDublicate.DataBind();
                    // duMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void gridGridviewDublicate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridGridviewDublicate.PageIndex = e.NewPageIndex;
            ShowDuplicateData();

        }



    }
}