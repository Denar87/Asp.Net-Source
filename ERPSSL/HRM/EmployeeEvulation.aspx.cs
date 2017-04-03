using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ERPSSL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class EmployeeEvulation : System.Web.UI.Page
    {
        #region ----------- Objects -------------------

        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        ADMINISTRATION_BLL objAdm_BLL = new ADMINISTRATION_BLL();

        #endregion

        Int32 total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                lblTotal.Text = "00";

                if (!IsPostBack)
                {
                    BindGridEmployeeEvaluatione();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        #region--RATING--------------------------------

        protected void Rating_AbsErro_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingAttendance_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingAccuracy_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingCo_operation_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }

        protected void RatingHabbit_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }

        protected void RatingInitiative_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingInnovation_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingKnowledge_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingOrderliness_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        protected void RatingReliability_Changed(object sender, RatingEventArgs e)
        {
            Thread.Sleep(400);
        }
        #endregion

        protected void txtEid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = txtEid.Text;
                Emp_IMG.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                var result = objEmp_BLL.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    //NO RECORDS FOUND.
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnEmpEvulation_Click(object sender, EventArgs e)
        {
            //---------rating-1---------------
            try
            {
                int AbsErro = 0;
                switch (Rating_AbsErro.CurrentRating)
                {
                    case 1: AbsErro = 1; break;
                    case 2: AbsErro = 2; break;
                    case 3: AbsErro = 3; break;
                    case 4: AbsErro = 4; break;
                    case 5: AbsErro = 5; break;
                    //case 6: AbsErro = 6; break;
                    //case 7: AbsErro = 7; break;
                    //case 8: AbsErro = 8; break;
                    //case 9: AbsErro = 9; break;
                    //case 10: AbsErro = 10; break;
                }

                //---------rating-2---------------
                int Attendance = 0;
                switch (RatingAttendance.CurrentRating)
                {
                    case 1: Attendance = 1; break;
                    case 2: Attendance = 2; break;
                    case 3: Attendance = 3; break;
                    case 4: Attendance = 4; break;
                    case 5: Attendance = 5; break;
                    //case 6: Attendance = 6; break;
                    //case 7: Attendance = 7; break;
                    //case 8: Attendance = 8; break;
                    //case 9: Attendance = 9; break;
                    //case 10: Attendance = 10; break;
                }

                //---------rating-3---------------
                int Accuracy = 0;
                switch (RatingAccuracy.CurrentRating)
                {
                    case 1: Accuracy = 1; break;
                    case 2: Accuracy = 2; break;
                    case 3: Accuracy = 3; break;
                    case 4: Accuracy = 4; break;
                    case 5: Accuracy = 5; break;
                    //case 6: Accuracy = 6; break;
                    //case 7: Accuracy = 7; break;
                    //case 8: Accuracy = 8; break;
                    //case 9: Accuracy = 9; break;
                    //case 10: Accuracy = 10; break;
                }

                //---------rating-4---------------
                int Co_operation = 0;
                switch (RatingAccuracy.CurrentRating)
                {
                    case 1: Co_operation = 1; break;
                    case 2: Co_operation = 2; break;
                    case 3: Co_operation = 3; break;
                    case 4: Co_operation = 4; break;
                    case 5: Co_operation = 5; break;
                    //case 6: Co_operation = 6; break;
                    //case 7: Co_operation = 7; break;
                    //case 8: Co_operation = 8; break;
                    //case 9: Co_operation = 9; break;
                    //case 10: Co_operation = 10; break;
                }

                //---------rating-5---------------
                int Habbit = 0;
                switch (RatingHabbit.CurrentRating)
                {
                    case 1: Habbit = 1; break;
                    case 2: Habbit = 2; break;
                    case 3: Habbit = 3; break;
                    case 4: Habbit = 4; break;
                    case 5: Habbit = 5; break;
                    //case 6: Habbit = 6; break;
                    //case 7: Habbit = 7; break;
                    //case 8: Habbit = 8; break;
                    //case 9: Habbit = 9; break;
                    //case 10: Habbit = 10; break;
                }

                //---------rating-6---------------
                int Initiative = 0;
                switch (RatingInitiative.CurrentRating)
                {
                    case 1: Initiative = 1; break;
                    case 2: Initiative = 2; break;
                    case 3: Initiative = 3; break;
                    case 4: Initiative = 4; break;
                    case 5: Initiative = 5; break;
                    //case 6: Initiative = 6; break;
                    //case 7: Initiative = 7; break;
                    //case 8: Initiative = 8; break;
                    //case 9: Initiative = 9; break;
                    //case 10: Initiative = 10; break;
                }

                //---------rating-7---------------
                int Innovation = 0;
                switch (RatingInnovation.CurrentRating)
                {
                    case 1: Innovation = 1; break;
                    case 2: Innovation = 2; break;
                    case 3: Innovation = 3; break;
                    case 4: Innovation = 4; break;
                    case 5: Innovation = 5; break;
                    //case 6: Innovation = 6; break;
                    //case 7: Innovation = 7; break;
                    //case 8: Innovation = 8; break;
                    //case 9: Innovation = 9; break;
                    //case 10: Innovation = 10; break;
                }

                //---------rating-8---------------
                int Knowledge = 0;
                switch (RatingKnowledge.CurrentRating)
                {
                    case 1: Knowledge = 1; break;
                    case 2: Knowledge = 2; break;
                    case 3: Knowledge = 3; break;
                    case 4: Knowledge = 4; break;
                    case 5: Knowledge = 5; break;
                    //case 6: Knowledge = 6; break;
                    //case 7: Knowledge = 7; break;
                    //case 8: Knowledge = 8; break;
                    //case 9: Knowledge = 9; break;
                    //case 10: Knowledge = 10; break;
                }

                //---------rating-9---------------
                int Orderliness = 0;
                switch (RatingOrderliness.CurrentRating)
                {
                    case 1: Orderliness = 1; break;
                    case 2: Orderliness = 2; break;
                    case 3: Orderliness = 3; break;
                    case 4: Orderliness = 4; break;
                    case 5: Orderliness = 5; break;
                    //case 6: Orderliness = 6; break;
                    //case 7: Orderliness = 7; break;
                    //case 8: Orderliness = 8; break;
                    //case 9: Orderliness = 9; break;
                    //case 10: Orderliness = 10; break;
                }
                //---------rating-10---------------
                int Reliability = 0;
                switch (RatingReliability.CurrentRating)
                {
                    case 1: Reliability = 1; break;
                    case 2: Reliability = 2; break;
                    case 3: Reliability = 3; break;
                    case 4: Reliability = 4; break;
                    case 5: Reliability = 5; break;
                    //case 6: Reliability = 6; break;
                    //case 7: Reliability = 7; break;
                    //case 8: Reliability = 8; break;
                    //case 9: Reliability = 9; break;
                    //case 10: Reliability = 10; break;
                }


                total = 2 * (Reliability + Orderliness + Knowledge + Innovation + Initiative + Habbit + Co_operation + Accuracy + Attendance + AbsErro);
                lblTotal.Text = Convert.ToString(total);
                HRM_EVALUATION objEvl = new HRM_EVALUATION();
                objEvl.EID = txtEid.Text;
                objEvl.ABSENCERROR = 2 * (Convert.ToInt32(AbsErro));
                objEvl.ACCURACY = 2 * (Convert.ToInt32(Accuracy));
                objEvl.HABBIT = 2 * (Convert.ToInt32(Habbit));
                objEvl.INNOVATION = 2 * (Convert.ToInt32(Innovation));
                objEvl.ORDERLINES = 2 * (Convert.ToInt32(Orderliness));
                objEvl.ATTENDANCE = 2 * (Convert.ToInt32(Attendance));
                objEvl.CO_OPERATION = 2 * (Convert.ToInt32(Co_operation));
                objEvl.INITIATIVE = 2 * (Convert.ToInt32(Initiative));
                objEvl.KNOWLEDGE = 2 * (Convert.ToInt32(Knowledge));
                objEvl.RELIABILITY = 2 * (Convert.ToInt32(Reliability));
                objEvl.OUT_OF = Convert.ToInt32(100);
                //          objEvl.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                //           objEvl.EDIT_DATE = DateTime.Now;
                //    objEvl.OCODE = "8989";
                objEvl.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = objAdm_BLL.InsertEmployeeEvaluation(objEvl);
                if (result == 1)
                {
                    lblMessage.Text = "Record Added successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;
                    BindGridEmployeeEvaluatione();
                    ClearAll();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAll()
        {
            txtEid.Text = "";
            txtEmpName.Text = "";
            lblHiddenId.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";
        }

        #region   ------------- EVALUATION GRID -------------------

        void BindGridEmployeeEvaluatione()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var row = objAdm_BLL.GetEmployeeEvaluation(OCODE).ToList();
                if (row.Count > 0)
                {
                    GridViewEMP_EVL.DataSource = row.ToList();
                    GridViewEMP_EVL.DataBind();
                }
                else
                {
                    var obj = new List<HRM_EVALUATION>();
                    obj.Add(new HRM_EVALUATION());

                    // Bind the DataTable which contain a blank row to the GridView
                    GridViewEMP_EVL.DataSource = obj;
                    GridViewEMP_EVL.DataBind();

                    int columnsCount = GridViewEMP_EVL.Columns.Count;
                    GridViewEMP_EVL.Rows[0].Cells.Clear();// clear all the cells in the row
                    GridViewEMP_EVL.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    GridViewEMP_EVL.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                    GridViewEMP_EVL.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridViewEMP_EVL.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    GridViewEMP_EVL.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    GridViewEMP_EVL.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void GridViewEMP_EVL_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewEMP_EVL.PageIndex = e.NewPageIndex;
                BindGridEmployeeEvaluatione();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        #endregion
    }
}