using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class EmployeeTermination : System.Web.UI.Page
    {
        #region ------------- Reference Object --------------

        Office_BLL objOffice_BLL = new Office_BLL();
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        SECTION_BLL objSec_BLL = new SECTION_BLL();
        SUB_SECTION_BLL objSubSec_BLL = new SUB_SECTION_BLL();
        DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
        GRADE_BLL objGrd_BLL = new GRADE_BLL();
        ADMINISTRATION_BLL objAdm_BLL = new ADMINISTRATION_BLL();
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        Attendance_BLL aAttendance_BLL = new Attendance_BLL();

        ERPSSLHBEntities context = new ERPSSLHBEntities();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        //private void BindGridEmployeeTermination()
        //{
        //    try
        //    {
        //     string OCODE = ((SessionUser)Session["SessionUser"]).OCode;                

        //        using (ERPSSLHBEntities context = new ERPSSLHBEntities())
        //        {
        //                if (context.HRM_JOB_TERMINATE.Count() > 0)
        //                {
        //                        var query = (from ter in context.HRM_JOB_TERMINATE
        //                                     where ter.OCODE == OCODE
        //                                     select ter).OrderByDescending(ter => ter.TERMINATE_ID);

        //                        GridViewEMP_TR.DataSource = query;
        //                        GridViewEMP_TR.DataBind();
        //                }
        //                else
        //                {
        //                        var obj = new List<HRM_JOB_TERMINATE>();
        //                        obj.Add(new HRM_JOB_TERMINATE());

        //                        // Bind the DataTable which contain a blank row to the GridView
        //                        GridViewEMP_TR.DataSource = obj;
        //                        GridViewEMP_TR.DataBind();

        //                        int columnsCount = GridViewEMP_TR.Columns.Count;
        //                        GridViewEMP_TR.Rows[0].Cells.Clear();// clear all the cells in the row
        //                        GridViewEMP_TR.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
        //                        GridViewEMP_TR.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


        //                        GridViewEMP_TR.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //                        GridViewEMP_TR.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        //                        GridViewEMP_TR.Rows[0].Cells[0].Font.Bold = true;

        //                        //set No Results found to the new added cell
        //               //         GridViewEMP_TR.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

        //                }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        protected void btnJobTermntSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_JOB_TERMINATE obj = new HRM_JOB_TERMINATE();
                List<HRM_JOB_TERMINATE> jobterminates = new List<HRM_JOB_TERMINATE>();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (drpstatus.SelectedItem.ToString() != "------- Select --------")
                {

                    List<HRM_ATTENDANCE> lstHRM_ATTENDANCE = aAttendance_BLL.GetAttendanceInfo_DateWise(Convert.ToDateTime(txtTerminateDate.Text)).Where(x => x.EID == txtEid_TR.Text && x.Status == "P").ToList();

                    if (lstHRM_ATTENDANCE.Count == 0)
                    {
                        string eid = obj.EID = txtEid_TR.Text;
                        obj.TERMINATE_DATE = Convert.ToDateTime(txtTerminateDate.Text);
                        obj.REMARKS = txtRemarks_TRM.Text;
                        obj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        obj.EDIT_DATE = DateTime.Now;
                        obj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        obj.Termination_Status = true;

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
                        HRM_PersonalInformations objEmpUpdate = context.HRM_PersonalInformations.First(x => x.EID == obj.EID);
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

                        objEmpUpdate.Seperation_Date = Convert.ToDateTime(txtTerminateDate.Text);

                        if (btnJobTermntSubmit.Text == "Submit")
                        {
                            int count = (from terminat in context.HRM_JOB_TERMINATE
                                         where terminat.TERMINATE_DATE == obj.TERMINATE_DATE && terminat.EID == obj.EID
                                         select terminat.TERMINATE_DATE).Count();
                            if (count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Separation Date Already Exists!')", true);
                                return;
                            }
                            context.HRM_JOB_TERMINATE.AddObject(obj);
                            context.SaveChanges();
                        }
                        else
                        {
                            int terminationid = Convert.ToInt32(hidTerminationid.Value);
                            string employeeid = hidEid.Value;
                            var result = objEmp_BLL.GetEmployeeDetailsID(employeeid, OCODE).ToList();

                            if (result.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Active Employee separated information can not be update!')", true);
                                return;
                            }

                            HRM_JOB_TERMINATE objHRM_JOB_TERMINATE = context.HRM_JOB_TERMINATE.First(x => x.TERMINATE_ID == terminationid && x.EID == employeeid);
                            objHRM_JOB_TERMINATE.TERMINATE_DATE = obj.TERMINATE_DATE;
                            objHRM_JOB_TERMINATE.Status = obj.Status;
                            objHRM_JOB_TERMINATE.REMARKS = obj.REMARKS;
                            context.SaveChanges();
                        }

                        #region Commented Code

                        //aAttendance_BLL.Delete_Attendance_ByEID_Date(txtEid_TR.Text, Convert.ToDateTime(txtTerminateDate.Text));

                        //DateTime CurrentDate = DateTime.Now;
                        //DateTime SeparationDate = Convert.ToDateTime(txtTerminateDate.Text);

                        //List<HRM_ATTENDANCE> attendences = (from att in context.HRM_ATTENDANCE
                        //                                    where att.EID == eid && (att.Attendance_Date >= SeparationDate && att.Attendance_Date <= CurrentDate)
                        //                                    select att).ToList();

                        //if (attendences.Count > 0)
                        //{
                        //    foreach (HRM_ATTENDANCE aitem in attendences)
                        //    {
                        //        HRM_ATTENDANCE _att = context.HRM_ATTENDANCE.First(a => a.EID == aitem.EID && a.Attendance_Date == aitem.Attendance_Date);

                        //        context.HRM_ATTENDANCE.DeleteObject(_att);
                        //        context.SaveChanges();
                        //    }
                        //}

                        //lblTrMessage.Text = "Record Added successfully!";
                        //lblTrMessage.ForeColor = System.Drawing.Color.Green;
                        #endregion

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Added successfully')", true);
                        jobterminates.Add(obj);
                        GetEmployee_Separation_Details(txtEid_TR.Text, OCODE);

                        ClearAll();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is present in this day!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Status!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetEmployee_Separation_Details(string employeeID, string OCODE)
        {
            var separateEmployee = objEmp_BLL.GetEmployee_Separation_Details(employeeID, OCODE).ToList();
            if (separateEmployee.Count > 0)
            {
                GridViewEMP_TR.DataSource = separateEmployee;
                GridViewEMP_TR.DataBind();
                GridViewEMP_TR.Rows[0].BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Seperation Data Found!')", true);
                GridViewEMP_TR.DataSource = null;
                GridViewEMP_TR.DataBind();
            }
        }

        private void BindGridEmployeeTermination(List<HRM_JOB_TERMINATE> jobterminates)
        {
            try
            {
                GridViewEMP_TR.DataSource = jobterminates;
                GridViewEMP_TR.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAll()
        {
            Emp_IMG_TR.Visible = false;
            //txtEid_TR.Text = "";
            //txtDepartment.Text = "";
            //txtDesignation.Text = "";
            //txtEmpName_TR.Text = "";
            txtRemarks_TRM.Text = "";
            txtTerminateDate.Text = "";
        }

        protected void txtEid_TR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region Old Code Comented Here


                //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string employeeID = Convert.ToString(txtEid_TR.Text);

                //var result = objEmp_BLL.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                //if (result.Count > 0)
                //{
                //    Emp_IMG_TR.Visible = true;
                //    Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                //    var objNewEmp = result.First();
                //    txtEmpName_TR.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                //    txtDepartment.Text = objNewEmp.DPT_NAME;
                //    txtDesignation.Text = objNewEmp.DEG_NAME;
                //}
                //else
                //{
                //    txtDesignation.Text = "";
                //    txtDepartment.Text = "";
                //    txtEmpName_TR.Text = "";
                //    Emp_IMG_TR.Visible = false;
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                //}
                #endregion

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_TR.Text);

                //active employee
                //var result = objEmp_BLL.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                //if (result.Count > 0)
                //{
                //    Emp_IMG_TR.Visible = true;
                //    Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                //    var objNewEmp = result.First();
                //    txtEmpName_TR.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                //    txtDepartment.Text = objNewEmp.DPT_NAME;
                //    txtDesignation.Text = objNewEmp.DEG_NAME;

                //    GetSeparetedEmlployee(employeeID, OCODE);
                //}

                //else
                //{

                //load individual employee from all employee
                var Employee = objEmp_BLL.Get_EmployeeDetailsByEID(employeeID, OCODE).ToList();

                if (Employee.Count > 0)
                {
                    Emp_IMG_TR.Visible = true;
                    Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    var objNewEmp = Employee.First();
                    //txtEmpName_TR.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtEmpName_TR.Text = objNewEmp.EmployeeFullName;
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                    //txtTerminateDate.Text = ConvertDate(Convert.ToString(objNewEmp.TERMINATE_DATE));
                    //drpstatus.SelectedItem.Text = objNewEmp.Status;

                    GetEmployee_Separation_Details(employeeID, OCODE);
                }
                else
                {
                    txtDesignation.Text = "";
                    txtDepartment.Text = "";
                    txtEmpName_TR.Text = "";
                    Emp_IMG_TR.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No record found!')", true);
                }
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }

        protected void imgbtnEmployeeEdit_Click(object sender, EventArgs e)
        {
            HRM_JOB_TERMINATE objHRM_JOB_TERMINATE = new HRM_JOB_TERMINATE();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                Label lblEmployeeIdId = (Label)GridViewEMP_TR.Rows[row.RowIndex].FindControl("lblEmployeeIdId");
                Label lblTERMINATE_DATE = (Label)GridViewEMP_TR.Rows[row.RowIndex].FindControl("lblTERMINATE_DATE");
                Label lblStatus = (Label)GridViewEMP_TR.Rows[row.RowIndex].FindControl("lblStatus");
                Label lblREMARKS = (Label)GridViewEMP_TR.Rows[row.RowIndex].FindControl("lblREMARKS");
                if (lblEmployeeIdId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    string eId = lblEmployeeIdId.Text;

                    objHRM_JOB_TERMINATE = objEmp_BLL.GetSeparationDate(eId, OCODE);

                    if (objHRM_JOB_TERMINATE != null)
                    {
                        hidEid.Value = objHRM_JOB_TERMINATE.EID.ToString();
                        hidTerminationid.Value = objHRM_JOB_TERMINATE.TERMINATE_ID.ToString();
                        txtTerminateDate.Text = ConvertDate(lblTERMINATE_DATE.Text);
                        drpstatus.SelectedItem.Text = lblStatus.Text;
                        txtRemarks_TRM.Text = lblREMARKS.Text;

                        if (btnJobTermntSubmit.Text == "Submit")
                        {
                            btnJobTermntSubmit.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void GridViewEMP_TR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //            GridViewEMP_TR.PageIndex = e.NewPageIndex;
        //            BindGridEmployeeTermination();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}