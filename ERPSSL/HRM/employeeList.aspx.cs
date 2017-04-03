using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;
using ERPSSL;

namespace ERPSSL.HRM
{
    public partial class employeeList : System.Web.UI.Page
    {
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    System.Threading.Thread.Sleep(5000);
                    ////GetEmployeeList();
                    ////BindGridTransferedEmployee();
                    ////GetSeparationList();
                    // BridGridTerminatedEmployees();
                    //GetRetiredEmployee();
                    //  GetResignation();
                    ////GetAllEmploye();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetSeparationList()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> employees = new List<REmployee>();
                employees = employeeBll.GetEmployeeSeparation(OCODE).ToList();
                if (employees.Count > 0)
                {
                    GridviewSeparation.DataSource = employees;
                    GridviewSeparation.DataBind();
                }
            }
            catch (Exception ex)
            {

                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        //private void GetResignation()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<REmployee> employees = new List<REmployee>();
        //        employees = employeeBll.GetResignation(OCODE).ToList();
        //        if (employees.Count > 0)
        //        {
        //            gridviewResignation.DataSource = employees;
        //            gridviewResignation.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        //private void GetRetiredEmployee()
        //{


        //        try
        //        {
        //            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //            List<REmployee> employees = new List<REmployee>();
        //            employees = employeeBll.GetRetiredEmployee(OCODE).ToList();
        //            if (employees.Count > 0)
        //            {
        //                gridTetired.DataSource = employees;
        //                gridTetired.DataBind();
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }

        //}

        //protected void gridTetired_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        gridTetired.PageIndex = e.NewPageIndex;
        //        GetRetiredEmployee();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //protected void gridviewResignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        gridviewResignation.PageIndex = e.NewPageIndex;
        //        GetResignation();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }                       
        //}

        private void GetAllEmploye()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> employees = new List<REmployee>();
                employees = employeeBll.GetAllEmploye(OCODE).ToList();
                if (employees.Count > 0)     
                {
                    GridivewAllEmployes.DataSource = employees;
                    GridivewAllEmployes.DataBind();
                }
            }
            catch (Exception ex)
            {

                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void grdemployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdemployees.PageIndex = e.NewPageIndex;
            GetEmployeeList();
        }

        protected void GridViewEMP_TRNS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEMP_TRNS.PageIndex = e.NewPageIndex;
            BindGridTransferedEmployee();

        }

        //protected void GridViewEMP_TR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //        GridViewEMP_TR.PageIndex = e.NewPageIndex;
        //        BridGridTerminatedEmployees();

        //}

        protected void GridivewAllEmployes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridivewAllEmployes.PageIndex = e.NewPageIndex;
            GetAllEmploye();

        }
        protected void GridviewSeparation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewSeparation.PageIndex = e.NewPageIndex;
            GetSeparationList();
        }

        //private void BridGridTerminatedEmployees()
        //{

        //    try
        //    {

        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<REmployee> employees = new List<REmployee>();
        //        employees = employeeBll.GetTerminatedEmployees(OCODE).ToList();
        //            if (employees.Count > 0)
        //            {
        //                GridViewEMP_TR.DataSource = employees;
        //                GridViewEMP_TR.DataBind();
        //            }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }


        //}
        void BindGridTransferedEmployee()
        {
            //try
            //{
            //    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //    string OCODE = "8989";
            //    var emp = objEmp_BLL.GetTransfered_Employees(OCODE).ToList();
            //    if (emp.Count() > 0)
            //    {
            //        GridViewEMP_TRNS.DataSource = emp;
            //        GridViewEMP_TRNS.DataBind();
            //    }
            //    else
            //    {
            //        var obj = new List<HRM_EMPLOYEES>();
            //        obj.Add(new HRM_EMPLOYEES());

            //        // Bind the DataTable which contain a blank row to the GridView
            //        GridViewEMP_TRNS.DataSource = obj;
            //        GridViewEMP_TRNS.DataBind();

            //        int columnsCount = GridViewEMP_TRNS.Columns.Count;
            //        GridViewEMP_TRNS.Rows[0].Cells.Clear();// clear all the cells in the row
            //        GridViewEMP_TRNS.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
            //        GridViewEMP_TRNS.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


            //        GridViewEMP_TRNS.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            //        GridViewEMP_TRNS.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            //        GridViewEMP_TRNS.Rows[0].Cells[0].Font.Bold = true;

            //        //set No Results found to the new added cell
            //        GridViewEMP_TRNS.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> TransferEmployes = new List<REmployee>();

                TransferEmployes = employeeBll.GetTransFerEmployeeEmployees(OCODE).ToList();
                if (TransferEmployes.Count > 0)
                {
                    GridViewEMP_TRNS.DataSource = TransferEmployes;
                    GridViewEMP_TRNS.DataBind();
                }
            }
            catch (Exception ex)
            {

                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }
        private void GetEmployeeList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> employees = new List<REmployee>();
                employees = employeeBll.GetEmployees(OCODE).ToList();
                if (employees.Count > 0)
                {
                    grdemployees.DataSource = employees;
                    grdemployees.DataBind();
                }
            }
            catch (Exception ex)
            {

                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //string EmpSearch = this.txtEmpSearch.Text;
            //using (var _context = new ERPSSLHBEntities())
            //{
            //    var query = (from emp in _context.HRM_PersonalInformations
            //                 where (emp.FirstName == EmpSearch
            //                    || emp.LastName == EmpSearch
            //                    || emp.EID == EmpSearch
            //                    || emp.FirstName + " " + emp.FirstName == EmpSearch)
            //                 select emp).OrderByDescending(emp => emp.EmpId);

            //    this.grdemployees.DataSource = query.ToList();
            //    grdemployees.DataBind();
            //}

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> employees = new List<REmployee>();

                if (txtEmpSearch.Text != "")
                {
                    string[] EmpSrachItem = this.txtEmpSearch.Text.Split('-');
                    employees = employeeBll.GetSearchEmployeesList(OCODE, EmpSrachItem[0]).ToList();
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
                else
                {
                    GetEmployeeList();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
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
                    employeeList.Add(employee.FirstName + "-" + employee.LastName);
                }

                //System.Threading.Thread.Sleep(500);
                return employeeList;
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchAllAllEmploye(string prefixText, int count)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var employees = from emp in _context.HRM_PersonalInformations
                                where emp.FirstName.StartsWith(prefixText) || emp.LastName.StartsWith(prefixText) || emp.EID.StartsWith(prefixText) || emp.Gender.StartsWith(prefixText) || emp.ContactNumber.StartsWith(prefixText) || emp.Email.StartsWith(prefixText)
                                select emp;

                List<String> employeeList = new List<String>();

                foreach (var employee in employees)
                {
                    employeeList.Add(employee.FirstName + "-" + employee.LastName);
                }

                //System.Threading.Thread.Sleep(500);
                return employeeList;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchSeparationEmploye(string prefixText, int count)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var employees = from emp in _context.HRM_PersonalInformations
                                where ((emp.EMP_TERMIN_STATUS == true || emp.EMP_Retired_Status == true || emp.EMP_Resignation_Status == true || emp.EMP_Dismissal_Status == true || emp.EMP_Died_Status == true || emp.EMP_Dis_Continution_Status == true || emp.EMP_Other == true) && (emp.FirstName.StartsWith(prefixText) || emp.LastName.StartsWith(prefixText) || emp.EID.StartsWith(prefixText) || emp.Gender.StartsWith(prefixText) || emp.ContactNumber.StartsWith(prefixText) || emp.Email.StartsWith(prefixText)))
                                select emp;

                List<String> employeeList = new List<String>();

                foreach (var employee in employees)
                {
                    employeeList.Add(employee.FirstName + "-" + employee.LastName);
                }

                //System.Threading.Thread.Sleep(500);
                return employeeList;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchTransferEmployee(string prefixText, int count)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var employees = from emp in _context.HRM_PersonalInformations
                                where (emp.EMP_TRANSFER_STATUS == true && (emp.FirstName.StartsWith(prefixText) || emp.LastName.StartsWith(prefixText) || emp.EID.StartsWith(prefixText) || emp.Gender.StartsWith(prefixText) || emp.ContactNumber.StartsWith(prefixText) || emp.Email.StartsWith(prefixText)))
                                select emp;

                List<String> employeeList = new List<String>();

                foreach (var employee in employees)
                {
                    employeeList.Add(employee.FirstName + "-" + employee.LastName);
                }

                //System.Threading.Thread.Sleep(500);
                return employeeList;
            }
        }


        protected void imgbtnEmployeeEdit_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string aEid = "";
                Label lblEid = (Label)GridivewAllEmployes.Rows[row.RowIndex].FindControl("lblEmployeeIdId");
                if (lblEid != null)
                {
                    aEid = lblEid.Text;
                    Session["EID"] = aEid;
                    Response.Redirect("employeeEdit.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }



        protected void btnSeparationImageEidt_Click(object sender, EventArgs e)
        {
            try
            {

                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                Label lblEid = (Label)GridviewSeparation.Rows[row.RowIndex].FindControl("lblEmployeeIdId");
                string EID = Convert.ToString(lblEid.Text);
                hidEid.Value = EID;


                ModalPopupExtender.Show();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnJobTermntUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();
                HRM_JOB_TERMINATE obj = new HRM_JOB_TERMINATE();
                obj.EID = hidEid.Value;
                obj.TERMINATE_DATE = Convert.ToDateTime(txtTerminateDate.Text);
                obj.Termination_Status = true;
                obj.REMARKS = txtRemarks_TRM.Text;
                obj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                obj.EDIT_DATE = DateTime.Now;
                obj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (drpstatus.SelectedItem.ToString() != "------- Select --------")
                {
                    if (drpstatus.SelectedItem.ToString() != "Active")
                    {

                        // int employeeID = Convert.ToInt32(lblHiddenIdTR.Text);
                        //obj.EmpId = employeeID;

                        if (drpstatus.SelectedItem.ToString() == "Resignation")
                        {
                            obj.Status = "Resignation";
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Termination")
                        {
                            obj.Status = "Termination";
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Retirement")
                        {
                            obj.Status = "Retirement";
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Dismissal")
                        {
                            obj.Status = "Dismissal";
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Died")
                        {
                            obj.Status = "Died";
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Dis-Continution")
                        {
                            obj.Status = "Dis-Continution";
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Others")
                        {
                            obj.Status = "Others";
                        }


                        //--------------------------------
                        HRM_PersonalInformations objEmpUpdate = _context.HRM_PersonalInformations.First(x => x.EID == obj.EID);

                        objEmpUpdate.EMP_TERMIN_STATUS = false;
                        objEmpUpdate.EMP_Retired_Status = false;
                        objEmpUpdate.EMP_Resignation_Status = false;
                        objEmpUpdate.EMP_Dismissal_Status = false;
                        objEmpUpdate.EMP_Died_Status = false;
                        objEmpUpdate.EMP_Dis_Continution_Status = false;
                        objEmpUpdate.EMP_Other = false;

                        if (drpstatus.SelectedItem.ToString() == "Termination")
                        {
                            objEmpUpdate.EMP_TERMIN_STATUS = true;
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Retirement")
                        {
                            objEmpUpdate.EMP_Retired_Status = true;
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Resignation")
                        {
                            objEmpUpdate.EMP_Resignation_Status = true;
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Dismissal")
                        {
                            objEmpUpdate.EMP_Dismissal_Status = true;
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Died")
                        {
                            objEmpUpdate.EMP_Died_Status = true;
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Dis-Continution")
                        {
                            objEmpUpdate.EMP_Dis_Continution_Status = true;
                        }
                        else if (drpstatus.SelectedItem.ToString() == "Others")
                        {
                            objEmpUpdate.EMP_Other = true;
                        }



                        //  _context.HRM_JOB_TERMINATE.AddObject(obj);



                        _context.SaveChanges();
                        //lblTrMessage.Text = "Record Added successfully!";
                        //lblTrMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Separation Successfully!')", true);
                        ClearAll();
                        GetSeparationList();

                    }
                    else
                    {
                        HRM_PersonalInformations objEmpUpdate1 = _context.HRM_PersonalInformations.First(x => x.EID == obj.EID);
                        objEmpUpdate1.EMP_TERMIN_STATUS = false;
                        objEmpUpdate1.EMP_Retired_Status = false;
                        objEmpUpdate1.EMP_Resignation_Status = false;
                        objEmpUpdate1.EMP_Dismissal_Status = false;
                        objEmpUpdate1.EMP_Died_Status = false;
                        objEmpUpdate1.EMP_Dis_Continution_Status = false;
                        objEmpUpdate1.EMP_Other = false;

                        HRM_JOB_TERMINATE objEmpUpdate = _context.HRM_JOB_TERMINATE.First(x => x.EID == obj.EID);
                        objEmpUpdate.Status = "Re-Active";
                        objEmpUpdate.TERMINATE_DATE = Convert.ToDateTime(txtTerminateDate.Text);

                        _context.SaveChanges();
                        //lblTrMessage.Text = "Record Added successfully!";
                        //lblTrMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Active Successfully!')", true);
                        ClearAll();
                        GetSeparationList();
                    }
                }
                else
                {
                    //lblTrMessage.Text = "Please Select Status";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Status')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }
        private void ClearAll()
        {
            drpstatus.ClearSelection();
            txtRemarks_TRM.Text = "";
            txtTerminateDate.Text = "";
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxTranserfer.Text != "")
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string[] EmpSrachItem = this.txtbxTranserfer.Text.Split('-');
                    List<REmployee> employees = new List<REmployee>();

                    employees = employeeBll.GetTransferListBySearchitem(OCODE, EmpSrachItem[0]).ToList();
                    if (employees.Count > 0)
                    {
                        GridViewEMP_TRNS.DataSource = employees;
                        GridViewEMP_TRNS.DataBind();
                    }
                    else
                    {
                        GridViewEMP_TRNS.DataSource = null;
                        GridViewEMP_TRNS.DataBind();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else
                {
                    BindGridTransferedEmployee();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }


        protected void btnSepartaion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxSeparation.Text != "")
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string[] EmpSrachItem = this.txtbxSeparation.Text.Split('-');
                    List<REmployee> employees = new List<REmployee>();

                    employees = employeeBll.GetSeparationSearchEmployeesList(OCODE, EmpSrachItem[0]).ToList();
                    if (employees.Count > 0)
                    {
                        GridviewSeparation.DataSource = employees;
                        GridviewSeparation.DataBind();
                    }
                    else
                    {
                        GridviewSeparation.DataSource = null;
                        GridviewSeparation.DataBind();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else
                {
                    GetSeparationList();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnallEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxSearchAllEmployee.Text != "")
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string[] EmpSrachItem = this.txtbxSearchAllEmployee.Text.Split('-');
                    List<REmployee> employees = new List<REmployee>();

                    employees = employeeBll.GeAlltSearchEmployeesList(OCODE, EmpSrachItem[0]).ToList();
                    if (employees.Count > 0)
                    {
                        GridivewAllEmployes.DataSource = employees;
                        GridivewAllEmployes.DataBind();
                    }
                    else
                    {
                        GridivewAllEmployes.DataSource = null;
                        GridivewAllEmployes.DataBind();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else
                {
                    GetAllEmploye();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}





