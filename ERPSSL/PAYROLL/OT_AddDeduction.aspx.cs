using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using AjaxControlToolkit;
using ERPSSL.HRM.DAL;
using ERPSSL;
using System.Data.SqlClient;

namespace ERPSSL.PAYROLL
{
    public partial class OT_AddDeduction : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        TimeSpan? shifted_TotalHour = TimeSpan.Parse("09:00:00");
        EMPOYEE_BLL Emp_BLL = new EMPOYEE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //BindGridEmployeeAttendance();
                    rdExtraOT.Visible = false;
                    rdExtraOTDeduct.Visible = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        void BindGridEmployeeAttendance()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                using (ERPSSLHBEntities context = new ERPSSLHBEntities())
                {
                    if (context.HRM_ATTENDANCE.Count() > 0)
                    {
                        var row = objAtt_BLL.GetAllAttendance(OCODE).ToList();
                        if (row.Count > 0)
                        {
                            GridViewEMP_AT.DataSource = row.ToList();
                            GridViewEMP_AT.DataBind();
                        }
                    }
                    else
                    {
                        var obj = new List<HRM_ATTENDANCE>();
                        obj.Add(new HRM_ATTENDANCE());

                        // Bind the DataTable which contain a blank row to the GridView
                        GridViewEMP_AT.DataSource = obj;
                        GridViewEMP_AT.DataBind();

                        int columnsCount = GridViewEMP_AT.Columns.Count;
                        GridViewEMP_AT.Rows[0].Cells.Clear();// clear all the cells in the row
                        GridViewEMP_AT.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        GridViewEMP_AT.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        GridViewEMP_AT.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        GridViewEMP_AT.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        GridViewEMP_AT.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        GridViewEMP_AT.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnAttSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Attendance_BLL _attendancebll = new Attendance_BLL();
                List<HRM_ATTENDANCE> attendances = new List<HRM_ATTENDANCE>();

                foreach (GridViewRow gvRow in GridViewEMP_AT.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    HRM_ATTENDANCE obj = new HRM_ATTENDANCE();

                    if (rowChkBox.Checked == true)
                    {
                        Label lblId = ((Label)gvRow.FindControl("lblId"));
                        TextBox txtbxExtraOtAdd = ((TextBox)gvRow.FindControl("OTExtraAdd"));
                        Label lblAttnDate = ((Label)gvRow.FindControl("lblAttnDate"));
                        //Label lbltotalot = ((Label)gvRow.FindControl("lbltotalot"));
                        //double totalOT = Convert.ToDouble(lbltotalot.Text);

                        DateTime otDate = Convert.ToDateTime(lblAttnDate.Text);

                        obj.ATTE_ID = Convert.ToInt32(lblId.Text);
                        int AttId = Convert.ToInt32(obj.ATTE_ID);

                        if (rdExtraOT.Checked)
                        {
                            obj.OT_ExtraAdd = Convert.ToInt32(txtbxExtraOtAdd.Text);
                            // obj.OT_Total = totalOT + Convert.ToDouble(txtbxExtraOtAdd.Text);       
                        }
                        else if (rdExtraOTDeduct.Checked)
                        {
                            obj.OT_Deduction = Convert.ToInt32(txtbxExtraOtAdd.Text);
                            // obj.OT_Total = totalOT - Convert.ToDouble(txtbxExtraOtAdd.Text);
                        }

                        obj.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        obj.Edit_Date = DateTime.Now;
                        obj.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                        var result = objAtt_BLL.UpdateAttendanceOT(obj, AttId);

                        if (result == 1)
                        {
                            //ot process

                            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                            string userId = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);

                            objAtt_BLL.UpdateOT_ByShift_EID(otDate, otDate, hdnEmployeeShiftCode.Value, txtEid_AT.Text);

                            //ot process log
                            var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(otDate));
                            var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(otDate));
                            var ParamempID3 = new SqlParameter("@Edit_User", userId);
                            var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                            var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                            string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                            context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully.')", true);

                            // load grid
                            DateTime fromdate = Convert.ToDateTime(txtfromDate.Text);
                            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                            var row = objAtt_BLL.GetAttendanceByEID(txtEid_AT.Text).Where(x => x.Attendance_Date >= fromdate && x.Attendance_Date <= toDate).ToList();

                            if (row.Count > 0)
                            {
                                GridViewEMP_AT.DataSource = row.ToList();
                                GridViewEMP_AT.DataBind();
                            }
                            else
                            {
                                GridViewEMP_AT.DataSource = null;
                                GridViewEMP_AT.DataBind();
                            }
                            ///

                        }
                    }
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void GridViewEMP_AT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEMP_AT.PageIndex = e.NewPageIndex;
            BindGridEmployeeAttendance();
        }

        void BindGridAttendanceByEID()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                //load all attendance by eid

                //using (ERPSSLHBEntities context = new ERPSSLHBEntities())
                //{
                //    if (context.HRM_ATTENDANCE.Count() > 0)
                //    {
                //        var row = objAtt_BLL.GetAttendanceByEID(OCODE, txtEid_AT.Text).ToList();
                //        if (row.Count > 0)
                //        {
                //            GridViewEMP_AT.DataSource = row.ToList();
                //            GridViewEMP_AT.DataBind();
                //        }
                //    }
                //    else
                //    {
                //        var obj = new List<HRM_ATTENDANCE>();
                //        obj.Add(new HRM_ATTENDANCE());

                //        // Bind the DataTable which contain a blank row to the GridView
                //        GridViewEMP_AT.DataSource = obj;
                //        GridViewEMP_AT.DataBind();

                //        int columnsCount = GridViewEMP_AT.Columns.Count;
                //        GridViewEMP_AT.Rows[0].Cells.Clear();// clear all the cells in the row
                //        GridViewEMP_AT.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                //        GridViewEMP_AT.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                //        GridViewEMP_AT.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                //        GridViewEMP_AT.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                //        GridViewEMP_AT.Rows[0].Cells[0].Font.Bold = true;

                //        //set No Results found to the new added cell
                //        GridViewEMP_AT.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                //    }
                //}

                var result = Emp_BLL.GetEmployeeDetailsIDCard(txtEid_AT.Text, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    Emp_IMG_TR.Visible = true;
                    Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + txtEid_AT.Text + "&oCode=" + OCODE;
                    txtEid_AT.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                    hdnEmployeeShiftCode.Value = objNewEmp.SHIFTCODE;

                    rdExtraOT.Visible = true;
                    rdExtraOTDeduct.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            BindGridAttendanceByEID();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfromDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Date!')", true);
                }
                if (txtEid_AT.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input E-ID!')", true);
                }

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime fromdate = Convert.ToDateTime(txtfromDate.Text);
                DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                using (ERPSSLHBEntities context = new ERPSSLHBEntities())
                {
                    if (context.HRM_ATTENDANCE.Count() > 0)
                    {
                        var row = objAtt_BLL.GetAttendanceByEID(txtEid_AT.Text).Where(x => x.Attendance_Date >= fromdate && x.Attendance_Date <= toDate).ToList();

                        if (row.Count > 0)
                        {
                            GridViewEMP_AT.DataSource = row.ToList();
                            GridViewEMP_AT.DataBind();
                        }
                        else
                        {
                            GridViewEMP_AT.DataSource = null;
                            GridViewEMP_AT.DataBind();
                        }
                    }
                    else
                    {
                        var obj = new List<HRM_ATTENDANCE>();
                        obj.Add(new HRM_ATTENDANCE());

                        // Bind the DataTable which contain a blank row to the GridView
                        GridViewEMP_AT.DataSource = obj;
                        GridViewEMP_AT.DataBind();

                        int columnsCount = GridViewEMP_AT.Columns.Count;
                        GridViewEMP_AT.Rows[0].Cells.Clear();// clear all the cells in the row
                        GridViewEMP_AT.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        GridViewEMP_AT.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        GridViewEMP_AT.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        GridViewEMP_AT.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        GridViewEMP_AT.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        GridViewEMP_AT.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                    }
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
                CheckBox headerChkBox = ((CheckBox)GridViewEMP_AT.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in GridViewEMP_AT.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in GridViewEMP_AT.Rows)
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


    }
}