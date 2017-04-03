using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC
{
    public partial class Estimate_Approval : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();

        LC_RequisitionBLL aLC_RequisitionBLL = new LC_RequisitionBLL();
        LC_ReportBLL aLC_ReportBLL = new LC_ReportBLL();

        GroupBLL groupBll = new GroupBLL();
        EstimatingBLL estimating = new EstimatingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //GetEstimatedSummaryByDate();
                    txtFromDate.Text = DateTime.Today.ToShortDateString();
                    txtToDate.Text = DateTime.Today.ToShortDateString();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                    btnPrint.Visible = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void GetApproved_EstimatedSummaryByDate()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            
            var result = aLC_RequisitionBLL.Get_AllEstimatedSummaryList(Ocode).Where(x => x.OrderDate >= fromDate && x.OrderDate <= toDate && x.Estimation_Approval==false).ToList();

            if (result.Count > 0)
            {
                grvEstimatedSummary.DataSource = result;
                grvEstimatedSummary.DataBind();
            }
            else
            {
                grvEstimatedSummary.DataSource = null;
                grvEstimatedSummary.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
            }
        }
    
        //protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CheckBox headerChkBox = ((CheckBox)grvOrderSheetEntry.HeaderRow.FindControl("headerLevelCheckBox"));

        //        if (headerChkBox.Checked == true)
        //        {
        //            foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
        //            {
        //                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
        //                rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
        //            }
        //        }
        //        else
        //        {
        //            foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
        //            {
        //                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
        //                rowChkBox.Checked = false;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //} 

        protected void gridBackToBack_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                string id = Convert.ToString(e.CommandArgument);
                var result = aLC_RequisitionBLL.Get_AllEstimateDetailsList(id);
                if (result.Count > 0)
                {
                    gridApprovalDetails.DataSource = result;
                    gridApprovalDetails.DataBind();
                }
                else
                {
                    gridApprovalDetails.DataSource = null;
                    gridApprovalDetails.DataBind();
                }
                txtEstimateNo.Text = id;
                btnPrint.Visible = true;
            }
          
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Approved Date!')", true);
                    return;
                }
                else
                {
                    DateTime date = Convert.ToDateTime(txtDate.Text);
                    var result = estimating.EstimatingApproved(txtEstimateNo.Text.ToString(),date);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Estimate Approved Successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding Failure!')", true);
                //lblMessage.Text = "<font color='red'>Data Adding Failure!</font>";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetApproved_EstimatedSummaryByDate();
        }

        protected void grvEstimatedSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEstimatedSummary.PageIndex = e.NewPageIndex;
            GetApproved_EstimatedSummaryByDate();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {

            string EstimatingCostID = txtEstimateNo.Text;
            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);


            List<Rep_Estimate> EstimatingCost = aLC_ReportBLL.Get_RPT_Cost_Estimating(EstimatingCostID, OCODE);
            var Fabric = aLC_RequisitionBLL.Get_AllEstimateDetailsList(EstimatingCostID).Where(x => x.GroupId == 1);
            var Accessories = aLC_RequisitionBLL.Get_AllEstimateDetailsList(EstimatingCostID).Where(x => x.GroupId == 2);


            if (EstimatingCost.Count > 0)
            {
                Session["rptDs"] = "Cost_Estimating";
                Session["rptDs1"] = "FabricDetails";
                Session["rptDs2"] = "AccessoriesDetails";
                Session["rptDt"] = EstimatingCost;
                Session["rptDt1"] = Fabric;
                Session["rptDt2"] = Accessories;
                Session["rptFile"] = "/LC/Reports/LC_RPT_Cost_Estimating.rdlc";
                Session["rptTitle"] = "Employee Wise Leave Info";
                Response.Redirect("ReportViewer.aspx");
            }

        }
       
    }
}