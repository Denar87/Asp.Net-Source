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
    public partial class OT_CalculationDatewise : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    //txtDateTo.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            txtDateTo.Text = txtDateFrom.Text;
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
                        var row = objAtt_BLL.GetAllOTByDate(OCODE, Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text)).ToList();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<string> ShiftCodes = objAtt_BLL.GetAllShiftCode(OCODE).ToList();
                foreach (string ashiftcode in ShiftCodes)
                {
                    var result = objAtt_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), ashiftcode);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('OT Processed Successfully')", true);
                        BindGridEmployeeAttendance();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('OT Processing Failure!')", true);
                        GridViewEMP_AT.DataSource = null;
                        GridViewEMP_AT.DataBind();
                    }
                }

                //ot process log
                DateTime fromdate = Convert.ToDateTime(txtDateFrom.Text.Trim());
                DateTime todate = Convert.ToDateTime(txtDateTo.Text.Trim());
                Guid USERID = ((SessionUser)Session["SessionUser"]).UserId;

                var ParamempID1 = new SqlParameter("@DateFrom", fromdate);
                var ParamempID2 = new SqlParameter("@DateTo", todate);
                var ParamempID3 = new SqlParameter("@Edit_User", USERID);
                var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
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

    }
}