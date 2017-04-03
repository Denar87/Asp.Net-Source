using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class gradeScale : System.Web.UI.Page
    {
        GRADE_BLL objGrd_BLL = new GRADE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    BindGridGrade();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }
        void BindGridGrade()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objGrd_BLL.GetAllGrade(OCODE).ToList();
                if (row.Count > 0)
                {
                    GridViewGRADE.DataSource = row.ToList();
                    GridViewGRADE.DataBind();
                }
                else
                {
                    var obj = new List<HRM_GRADE>();
                    obj.Add(new HRM_GRADE());

                    // Bind the DataTable which contain a blank row to the GridView
                    GridViewGRADE.DataSource = obj;
                    GridViewGRADE.DataBind();

                    int columnsCount = GridViewGRADE.Columns.Count;
                    GridViewGRADE.Rows[0].Cells.Clear();// clear all the cells in the row
                    GridViewGRADE.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    GridViewGRADE.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                    GridViewGRADE.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridViewGRADE.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    GridViewGRADE.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    GridViewGRADE.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void btnNewInsert_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            ModalPopupExtender.Show();
        }
        protected void GridViewGRADE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewGRADE.PageIndex = e.NewPageIndex;
                BindGridGrade();
            }
           catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void GridViewGRADE_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //int gradeID = Convert.ToInt32(GridViewGRADE.DataKeys[e.RowIndex].Value);
                //using (HRMgt_Entities context = new HRMgt_Entities())
                //{
                //    HRM_GRADE obj = context.HRM_GRADE.First(x => x.GRADE_ID == gradeID);
                //    context.HRM_GRADE.DeleteObject(obj);
                //    context.SaveChanges();
                //    BindGridGrade();
                //    lblMessageUpanel.Text = "Record ID " + gradeID + " Deleted successfully!";
                //    lblMessageUpanel.ForeColor = System.Drawing.Color.Red;
                //    pnl_result.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void GridViewGRADE_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GradeEdit")
            {
                //btnSubmit.Text = "Update";
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                //--------------
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                lblID.Text = GridViewGRADE.DataKeys[gvrow.RowIndex].Value.ToString();

                drpStep.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
                txtGrade.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
                txtGrsSal.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                txtHouseRent.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                txtBasic.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                txtMedical.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
                txtConveyance.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
                txtFoodAllowance.Text = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
                txtOthers.Text = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
                txtRemarks.Text = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);
                ModalPopupExtender.Show();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);
                decimal HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                decimal BASIC = Convert.ToDecimal(txtBasic.Text);
                decimal MEDICAL = Convert.ToDecimal(txtMedical.Text);
                decimal CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                decimal FOOD_ALLOW = Convert.ToDecimal(txtFoodAllowance.Text);
                decimal OTHERS = Convert.ToDecimal(txtOthers.Text);

                decimal TOTAL = (BASIC + HOUSE_RENT + MEDICAL + CONVEYANCE + FOOD_ALLOW + OTHERS);

                if (GROSS_SAL == TOTAL)
                {
                    int gradeId = Convert.ToInt32(lblID.Text);
                    System.Threading.Thread.Sleep(2000);

                    HRM_GRADE objGrd = new HRM_GRADE();
                    objGrd.STEP = Convert.ToInt32(drpStep.SelectedValue);
                    objGrd.GRADE = txtGrade.Text;

                    objGrd.GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);

                    objGrd.HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                    objGrd.BASIC = Convert.ToDecimal(txtBasic.Text);
                    objGrd.MEDICAL = Convert.ToDecimal(txtMedical.Text);
                    objGrd.CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                    objGrd.FOOD_ALLOW = Convert.ToDecimal(txtFoodAllowance.Text);
                    objGrd.OTHERS = Convert.ToDecimal(txtOthers.Text);

                    objGrd.REMARKS = Convert.ToString(txtRemarks.Text);

                    objGrd.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objGrd.EDIT_DATE = DateTime.Now;
                    objGrd.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = objGrd_BLL.UpdateGrade(objGrd, gradeId);
                    if (result == 1)
                    {
                        lblModalMessage.Text = "Record Updated successfully!";
                        lblModalMessage.ForeColor = System.Drawing.Color.Green;
                        BindGridGrade();
                    }
                }
                else
                {
                    lblModalMessage.Text = "Gross Total is not Equal to Misc. Total!";
                    lblModalMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
         catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);
                decimal HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                decimal BASIC = Convert.ToDecimal(txtBasic.Text);
                decimal MEDICAL = Convert.ToDecimal(txtMedical.Text);
                decimal CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                decimal FOOD_ALLOW = Convert.ToDecimal(txtFoodAllowance.Text);
                decimal OTHERS = Convert.ToDecimal(txtOthers.Text);

                decimal TOTAL = (BASIC + HOUSE_RENT + MEDICAL + CONVEYANCE + FOOD_ALLOW + OTHERS);

                if (GROSS_SAL == TOTAL)
                {
                    System.Threading.Thread.Sleep(2000);

                    HRM_GRADE objGrd = new HRM_GRADE();
                    objGrd.STEP = Convert.ToInt32(drpStep.SelectedValue);
                    objGrd.GRADE = txtGrade.Text;

                    objGrd.GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);

                    objGrd.HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                    objGrd.BASIC = Convert.ToDecimal(txtBasic.Text);
                    objGrd.MEDICAL = Convert.ToDecimal(txtMedical.Text);
                    objGrd.CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                    objGrd.FOOD_ALLOW = Convert.ToDecimal(txtFoodAllowance.Text);
                    objGrd.OTHERS = Convert.ToDecimal(txtOthers.Text);

                    objGrd.REMARKS = Convert.ToString(txtRemarks.Text);

                    objGrd.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objGrd.EDIT_DATE = DateTime.Now;
                    objGrd.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = objGrd_BLL.InsertGrade(objGrd);
                    if (result == 1)
                    {
                        lblModalMessage.Text = "Record Added successfully!";
                        lblModalMessage.ForeColor = System.Drawing.Color.Green;
                        BindGridGrade();
                    }
                }
                else
                {
                    lblModalMessage.Text = "Gross Total is not Equal to Misc. Total!";
                    lblModalMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
           catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}