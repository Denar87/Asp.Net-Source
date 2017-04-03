using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using ERPSSL.INV.DAL;

namespace ERPSSL.Requisition
{
    public partial class PurchaseRequisition_Supervisor2Approval : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequisitions("");
            }
        }

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetPendingPurchaseRequisition(ReqNo, "Manager2");
            grdRequisition.DataBind();
        }

        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetPurchaseRequisitionData(ReqNo, "Manager2");
            grvReqItemList.DataBind();
        }

        protected void grdRequisition_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                DataTable dt = new DataTable();
                string reqNo = e.CommandArgument.ToString();
                if (e.CommandName == "select")
                {
                    grvReqItemList.DataSource = aChallanBll.GetPurchaseRequisitionData(reqNo, "Manager2");
                    grvReqItemList.DataBind();
                }
            }
            catch { }


            //try
            //{
            //    lblMessage.Text = "";
            //    DataTable dt = new DataTable();

            //    int Id = Convert.ToInt32(e.CommandArgument.ToString());
            //    if (e.CommandName == "select")
            //    {
            //        dt = aChallanBll.GetStoreRequisitionData(Id, "Manager");
            //        hdnId.Value = dt.Rows[0][1].ToString();
            //        txtReqNo.Text = dt.Rows[0][3].ToString();
            //        txtProduct.Text = dt.Rows[0][5].ToString();
            //        txtBrand.Text = dt.Rows[0][6].ToString();
            //        txtStyle.Text = dt.Rows[0][7].ToString();
            //        txtUnit.Text = dt.Rows[0][13].ToString();
            //        txtRequestQTY.Text = dt.Rows[0][12].ToString();
            //        txtApproveQty.Text = dt.Rows[0][12].ToString();
            //        txtBalQTY.Text = dt.Rows[0][15].ToString();
            //        txtRemarks.Text = dt.Rows[0][16].ToString();
            //    }
            //}
            //catch { }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                List<PRQ_Requisitions> lstPRQ_Requisitions = new List<PRQ_Requisitions>();

                foreach (GridViewRow gvr in grvReqItemList.Rows)
                {
                    PRQ_Requisitions objPRQ_Requisitions = new PRQ_Requisitions();
                    Label lblReqNo = (Label)gvr.FindControl("lblReqNo");
                    Label lblBarcode = (Label)gvr.FindControl("lblBarcode");

                    TextBox txtApproveQty = (TextBox)gvr.FindControl("txtApproveQty");
                    int ApproveQty = int.Parse(txtApproveQty.Text);

                    //DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
                    //string Status = ddlStatus.SelectedItem.Text;

                    objPRQ_Requisitions.Manager2ApproveQty = ApproveQty;
                    objPRQ_Requisitions.IsAcceptedByManager2 = true;
                    objPRQ_Requisitions.ReqNo = lblReqNo.Text;
                    objPRQ_Requisitions.BarCode = Convert.ToInt16(lblBarcode.Text);
                    //objPRQ_Requisitions.Status = Status;

                    lstPRQ_Requisitions.Add(objPRQ_Requisitions);
                }

                int result = aRequisionBll.PurchaseReqApprovalBySupervisor2(lstPRQ_Requisitions);
                LoadRequisitions("");
                grvReqItemList.DataSource = null;
                grvReqItemList.DataBind();
                //LoadRequisitionsItem(reqNo);
                //lblMessage.Text = "Requisition Approved Successfully.";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition approved successfully')", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in approval!')", true);
                //lblMessage.Text = "<font color='red'>Error in approval! Please try again</font>";
            }
        }

    }
}