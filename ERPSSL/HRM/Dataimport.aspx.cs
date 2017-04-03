using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class Dataimport : System.Web.UI.Page
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    duMessage.Visible = false;
                    ShowDuplicateData();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try{
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

        public void btnConformation_Click(object sender, EventArgs e)
        {
            try
            {
                int result = employeeSetUpBll.DeleteDublicate();

                if (result == 1)
                {
                    List<Hrm_PersonalInfoTemp> Pinfoes = getEmpInfo();
                    UpdateEmp(Pinfoes);
                    Pinfoes.Clear();

                    GetEmployeesList();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
            int result = employeeSetUpBll.DeleteTempData();
            if (result == 1)
            {
                lblMessage.Text = " Data Delete Successfully.";
                ShowDuplicateData();
                duMessage.Visible = false;
                gridGridviewDublicate.DataSource = null;
                gridGridviewDublicate.DataBind();
            }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void GetEmployeesList()
        {
            try
            {
                List<Hrm_PersonalInfoTemp> sPinfoes = new List<Hrm_PersonalInfoTemp>();
                sPinfoes = null;
                sPinfoes = employeeSetUpBll.getEmpInfoForSave();
                SaveFinalTable(sPinfoes);
                int result = employeeSetUpBll.DeleteTempData();
                if (result == 1)
                {
                    lblMessage.Text = " Data Import Successfully .";
                    ShowDuplicateData();
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void SaveFinalTable(List<Hrm_PersonalInfoTemp> sPinfoes)
        {

            try
            {

                foreach (Hrm_PersonalInfoTemp aitem in sPinfoes)
                {
                    HRM_PersonalInformations neaitem = new HRM_PersonalInformations();
                    neaitem.EID = aitem.EID;
                    neaitem.FirstName = aitem.FirstName;
                    neaitem.BIO_MATRIX_ID = aitem.BIO_MATRIX_ID;
                    neaitem.LastName = aitem.LastName;
                    neaitem.Gender = aitem.Gender;
                    neaitem.BloodGroup = aitem.BloodGroup;
                    neaitem.Religion = aitem.Religion;
                    neaitem.NationalID = aitem.NationalID;
                    neaitem.FatherName = aitem.FatherName;
                    neaitem.MotherName = aitem.MotherName;
                    neaitem.PresentAddress = aitem.PresentAddress;
                    neaitem.PermanenAddress = aitem.PermanenAddress;
                    neaitem.Nationality = aitem.Nationality;
                    neaitem.ContactNumber = aitem.ContactNumber;
                    neaitem.EmergencyContactNo = aitem.EmergencyContactNo;
                    neaitem.EmergencyContactPerson = aitem.EmergencyContactPerson;
                    neaitem.NomineeName = aitem.NomineeName;
                    neaitem.SubSectionId = Convert.ToInt32(aitem.SubSection);
                    neaitem.SectionId = Convert.ToInt32(aitem.Section);
                    neaitem.DesginationId = Convert.ToInt32(aitem.Desgination);
                    neaitem.DepartmentId = Convert.ToInt32(aitem.Department);
                    neaitem.RegionsId = Convert.ToInt32(aitem.Regions);
                    neaitem.OfficeId = Convert.ToInt32(aitem.Office);
                    neaitem.Salary = Convert.ToDecimal(aitem.Salary);

                    if (aitem.DateOfBrith != null)
                    {
                        string[] dateotBrithd = aitem.DateOfBrith.Split('/');
                        if (dateotBrithd.Length > 0)
                        {

                            string day = dateotBrithd[0];
                            string moth = dateotBrithd[1];
                            string year = dateotBrithd[2].Substring(0, 4);

                            if (Convert.ToInt16(moth) > 12)
                            {
                                string mothDayyear = day + "/" + moth + "/" + year.ToString();
                                neaitem.DateOfBrith = Convert.ToDateTime(mothDayyear);
                            }
                            else
                            {
                                string mothDayyear = moth + "/" + day + "/" + year.ToString();
                                neaitem.DateOfBrith = Convert.ToDateTime(mothDayyear);
                            }



                        }
                    }


                    //  neaitem.DateOfBrith = aitem.DateOfBrith;
                    neaitem.MaritalStatus = aitem.MaritalStatus;
                    neaitem.Grade = aitem.Grade;
                    neaitem.OCODE = aitem.OCODE;
                    neaitem.OTApplicable = aitem.OTApplicable;
                    // neaitem.JoiningDate = aitem.JoiningDateFromU;

                    if (aitem.JoiningDateFromU != null)
                    {
                        //string[] dateotjoinDate = aitem.JoiningDateFromU.Split('/');
                        //if (dateotjoinDate.Length > 0)
                        //{
                        //    string day = dateotjoinDate[0];
                        //    string moth = dateotjoinDate[1];
                        //    string year = dateotjoinDate[2].Substring(0,4);

                        //    if (Convert.ToInt16(moth) > 12)
                        //    {
                        //        string mothDayyear = moth + "/" + day + "/" + year.ToString();
                        //        neaitem.DateOfBrith = Convert.ToDateTime(mothDayyear);
                        //    }
                        //    else
                        //    {
                        //        string mothDayyear = moth + "/" + day + "/" + year.ToString();
                        //        neaitem.JoiningDate = Convert.ToDateTime(mothDayyear);
                        //    }
                        //}
                        neaitem.JoiningDate = Convert.ToDateTime(aitem.JoiningDateFromU);
                    }

                    neaitem.EMP_TERMIN_STATUS = false;
                    neaitem.EMP_TRANSFER_STATUS = false;
                    neaitem.EDIT_USER = aitem.EDIT_USER;
                    neaitem.EDIT_DATE = aitem.EDIT_DATE;
                    _context.HRM_PersonalInformations.AddObject(neaitem);
                    _context.SaveChanges();
                }
                //_context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        private void ImporttoSQL(string sPath)
        {
            try{
            //http://codedisplay.com/how-to-import-excel-sheet-data-into-sql-server-table-using-asp-net-c-vb-net/
            // Connect to Excel 2007 earlier version
            //string sSourceConstr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\AgentList.xls; Extended Properties=""Excel 8.0;HDR=YES;""";
            // Connect to Excel 2007 (and later) files with the Xlsx file extension 
            string sSourceConstr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", sPath);
            string sDestConstr = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
            OleDbConnection sSourceConnection = new OleDbConnection(sSourceConstr);
            using (sSourceConnection)
            {
                string sql = string.Format("Select [E-ID],[Bio Matrix-ID],[Frist Name],[Last Name],[Gender],[Date of Birth],[Religion],[Blood Group],[Region],[Office],[Department],[Section],[Section Line],[Designation],[Joning Date],[Grade],[Gross Salary],[OT Applicable(Yes/No)],[Contact No],[Fathers Name],[Mothers Name],[Permanent Address],[Present Address],[Emergency Contact No],[Emergency Contact Person],[Marital Status],[Nationality],[N-ID],[Nominee Name] FROM [{0}]", "Sheet1$");
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

                        SaveDeg();
                        ShowDuplicateData();
                    }
                }
            }
            }catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //private void SaveDepartment()
        //{
        //    try
        //    {
        //        string usrId = ((SessionUser)Session["SessionUser"]).UserId.ToString();
        //        string date = DateTime.Now.ToString();
        //        string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<Hrm_PersonalInfoTemp> Pinfoes = getEmpInfo();
        //        employeeSetUpBll.SaveDepartment(usrId, date, Ocode, Pinfoes);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}




        private void SaveDeg()
        {
            try{
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

        private void ShowDuplicateData()
        {
            List<Hrm_PersonalInfoTemp> persones = employeeSetUpBll.GetDublicateList();


            if (persones.Count > 0)
            {
                gridGridviewDublicate.DataSource = persones;
                gridGridviewDublicate.DataBind();
                duMessage.Visible = true;
            }
        }

        private void UpdateEmp(List<Hrm_PersonalInfoTemp> Pinfoes)
        {

            try
            {
                string ocdoe = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                Guid userid = ((SessionUser)Session["SessionUser"]).UserId;
                string date = DateTime.Now.ToString();


                foreach (Hrm_PersonalInfoTemp aitem in Pinfoes)
                {
                    using (var _context = new ERPSSLHBEntities())
                    {
                        var eid = new SqlParameter("@EmpId", aitem.EID);
                        var region = new SqlParameter("@Region", aitem.Regions);
                        var office = new SqlParameter("@Office", aitem.Office);
                        var department = new SqlParameter("@Department", aitem.Department);
                        var degination = new SqlParameter("@DesignationName", aitem.Desgination);
                        var section = new SqlParameter("@secion", aitem.Section);
                        var subseciton = new SqlParameter("@SubSection", aitem.SubSection);
                        var ocode = new SqlParameter("@ocode", ocdoe);
                        var editdate = new SqlParameter("@editDate", date);
                        var edituser = new SqlParameter("@editUser", userid);
                        var salary = new SqlParameter("@Salary", aitem.Salary);
                        var grade = new SqlParameter("@grade", aitem.Grade);
                        var ot = new SqlParameter("@OTstatis", aitem.OTApplicableFU);
                        string SP_SQL = "HRM_RODSSUpdateForPersonalInfoTemp @EmpId,@Region,@Office,@Department,@DesignationName,@secion,@SubSection,@ocode,@editDate,@editUser,@Salary,@grade,@OTstatis";
                        _context.ExecuteStoreCommand(SP_SQL, eid, region, office, department, degination, section, subseciton, ocode, editdate, edituser, salary, grade, ot);
                    }
                }
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

        protected void gridGridviewDublicate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridGridviewDublicate.PageIndex = e.NewPageIndex;
            ShowDuplicateData();


        }
    }
}