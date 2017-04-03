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
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using Microsoft.Reporting.WebForms;
using System.Drawing;

namespace ERPSSL.Requisition
{
    public partial class PurchaseRequisition_AdminApproval : System.Web.UI.Page
    {
        int m = 0;

        IChallanBLL aChallanBll = new IChallanBLL();
        IChallanBLL ic = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        RChallanBLL rChallanBll = new RChallanBLL();
        Office_BLL officeBll = new Office_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeInfo();
                //LoadRequisitions("");
              //  FillDepartment();
                FillDepartmentbyReq();
             //   FillDepartmentByOffice();
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void GetEmployeeInfo()
        {
            try
            {
                string eid = ((SessionUser)Session["SessionUser"]).EID;
                if (eid != null)
                {
                    EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);

                    List<AssignTo> assignTos = new List<AssignTo>();
                    assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                    foreach (AssignTo assign in assignTos)
                    {
                        hdnAdminEID.Value = ((SessionUser)Session["SessionUser"]).EID;
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
                    }
                }
            }
            catch
            {
            }
        }
        private void FillDepartment()
        {
            ddlDepartment.DataSource = ic.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        }

        private void FillDepartmentbyReq()
        {
            ddlDepartment.DataSource = ic.GetDepartmentListByReqNo();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        }
        
        private void FillDepartmentByOffice()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            ddlDepartment.DataSource = officeBll.GetDepartmentByOffice(int.Parse(hdnOfficeID.Value), OCODE);
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        }
        private void LoadRequisitions(string ReqNo)
        {
            string DPT_CODE = ddlDepartment.SelectedValue;
            string Status = ddlStatus.SelectedItem.Text;
            string FromDate = txtFromDate.Text;
            string ToDate = txtToDate.Text;
            grdRequisition.DataSource = RequisionBll.GetPendingPurchaseRequisitionForAdmin(ReqNo, "Head", DPT_CODE, Status, FromDate, ToDate);
            grdRequisition.DataBind();
        }

        private void LoadRequisitionsearch()
        {
            string ReqNo = "";
            string DPT_CODE = ddlDepartment.SelectedValue;
            string Status = ddlStatus.SelectedItem.Text;
            string FromDate = txtFromDate.Text;
            string ToDate = txtToDate.Text;
            if (ddlDepartment.SelectedValue != "" && ddlStatus.SelectedItem.Text != "--Select One--" && txtFromDate.Text != "" && txtToDate.Text != "")
            {
                if (ddlStatus.SelectedItem.Text == "Pending")
                {
                    DataTable dt = new DataTable();
                    dt = RequisionBll.GetPendingPurchaseRequisitionForAdmin(ReqNo, "Head", DPT_CODE, Status, FromDate, ToDate);
                    if (dt.Rows.Count > 0)
                    {
                        grdRequisition.DataSource = dt;
                        grdRequisition.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                        grdRequisition.DataSource = null;
                        grdRequisition.DataBind();
                    }
                }
                else if (ddlStatus.SelectedItem.Text == "Approve")
                {
                    DataTable dt = new DataTable();
                    dt = RequisionBll.GetPendingPurchaseRequisitionForAdminApprove(ReqNo, "Head", DPT_CODE, Status, FromDate, ToDate);
                    if (dt.Rows.Count > 0)
                    {
                        grdRequisition.DataSource = dt;
                        grdRequisition.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                        grdRequisition.DataSource = null;
                        grdRequisition.DataBind();
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = RequisionBll.GetPendingPurchaseRequisitionForAdminAllStatus(ReqNo, "Head", DPT_CODE, Status, FromDate, ToDate);
                    if (dt.Rows.Count > 0)
                    {
                        grdRequisition.DataSource = dt;
                        grdRequisition.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                        grdRequisition.DataSource = null;
                        grdRequisition.DataBind();
                    }


                }

            }
            else if (ddlDepartment.SelectedValue != "0" && txtFromDate.Text != "" && txtToDate.Text != "" && ddlStatus.SelectedItem.Text == "--Select One--")
            {
                DataTable dt = new DataTable();
                dt = RequisionBll.GetPendingPurchaseRequisitionForAdminByDPT(ReqNo, "Head", DPT_CODE, FromDate, ToDate);
                if (dt.Rows.Count > 0)
                {
                    grdRequisition.DataSource = dt;
                    grdRequisition.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                    grdRequisition.DataSource = null;
                    grdRequisition.DataBind();
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Department or Status!')", true);
                grdRequisition.DataSource = null;
                grdRequisition.DataBind();

            }
        }


        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetPurchaseRequisitionData(ReqNo, "Head");
            grvReqItemList.DataBind();
        }

        protected void grdRequisition_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                DataTable dt = new DataTable();
                string reqNo = e.CommandArgument.ToString();
                Session["RequisitionNo"] = reqNo;
                if (e.CommandName == "select")
                {
                    grvReqItemList.DataSource = aChallanBll.GetPurchaseRequisitionData(reqNo, "Head");
                    grvReqItemList.DataBind();

                    //dt = aChallanBll.GetStoreRequisitionData(reqNo, "Manager");
                    //LoadRequisitionsItem("");
                }
            }
            catch { }
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
                    Label lblBalance = (Label)gvr.FindControl("lblBalance");
                    Label lblItem = (Label)gvr.FindControl("lblItem");
                    Label lblTotalAppQty = (Label)gvr.FindControl("lblTotalAppQty");

                    TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");


                    TextBox txtApproveQty = (TextBox)gvr.FindControl("txtApproveQty");
                    int ApproveQty = int.Parse(txtApproveQty.Text);

                    TextBox txtPrice = (TextBox)gvr.FindControl("txtPrice");
                    int itemPrice = int.Parse(txtPrice.Text);

                    DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
                    string Status = ddlStatus.SelectedItem.Text;

                    objPRQ_Requisitions.HeadApproveQty = ApproveQty;
                    objPRQ_Requisitions.Price = itemPrice;

                    if (ddlStatus.SelectedItem.Text == "Re-Forward")
                    {
                        objPRQ_Requisitions.IsAcceptedByManager = false;
                        objPRQ_Requisitions.IsAcceptedByHead = false;
                    }
                    else if (ddlStatus.SelectedItem.Text == "Approve")
                    {
                        objPRQ_Requisitions.IsAcceptedByManager = true;
                        objPRQ_Requisitions.IsAcceptedByHead = true;
                    }
                    else
                    {
                        objPRQ_Requisitions.IsAcceptedByHead = false;
                        objPRQ_Requisitions.IsAcceptedByManager = true;
                    }
                    objPRQ_Requisitions.Remarks = txtRemarks.Text;
                    objPRQ_Requisitions.ReqNo = lblReqNo.Text;
                    objPRQ_Requisitions.BarCode = Convert.ToInt16(lblBarcode.Text);
                    objPRQ_Requisitions.Status = Status;
                    objPRQ_Requisitions.Admin_EID = hdnAdminEID.Value; //Approved By

                    //if (ApproveQty > (Convert.ToInt16(lblBalance.Text) - Convert.ToInt16(lblTotalAppQty.Text)))
                    //{
                    //    lblMessage.Text = "<font color='red'>'" + lblItem.Text + "' approve quantity can not be larger than stock!</font>";
                    //    return;
                    //}

                    //if (ApproveQty >= Convert.ToInt16(lblTotalAppQty.Text))
                    //{
                    //    lblMessage.Text = "<font color='red'>" + lblItem.Text + " approve quantity exceeded!</font>";
                    //    return;
                    //}

                    lstPRQ_Requisitions.Add(objPRQ_Requisitions);
                }

                int result = aRequisionBll.PurchaseReqApprovalByAdmin(lstPRQ_Requisitions);
                LoadRequisitions("");
                grvReqItemList.DataSource = null;
                grvReqItemList.DataBind();
                //LoadRequisitionsItem(reqNo);
                //lblMessage.Text = "Data Recorded Successfully.";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data recorded successfully')", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding Failure!')", true);
                //lblMessage.Text = "<font color='red'>Data Adding Failure!</font>";
            }
        }

        protected void txtApproveQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblBalance = (Label)grvReqItemList.FindControl("lblBalance");
                Label lblItem = (Label)grvReqItemList.FindControl("lblItem");
                Label lblTotalAppQty = (Label)grvReqItemList.FindControl("lblTotalAppQty");

                TextBox txtApproveQty = (TextBox)grvReqItemList.FindControl("txtApproveQty");
                int ApproveQty = int.Parse(txtApproveQty.Text);

                if (ApproveQty > (Convert.ToInt16(lblBalance.Text) - Convert.ToInt16(lblTotalAppQty.Text)))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Approve quantity can not be larger than stock!')", true);
                    //lblMessage.Text = "<font color='red'>'" + lblItem.Text + "' approve quantity can not be larger than stock!</font>";
                    //return;
                }
            }
            catch { }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            string ReqNo = Session["RequisitionNo"].ToString();
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DataTable dataSource = rChallanBll.GetStoreRequisitionRPT(ReqNo, Ocode);
            ReportViewerPurchase.LocalReport.DataSources.Clear();
            ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
            ReportViewerPurchase.LocalReport.DataSources.Add(reportDataset);
            ReportViewerPurchase.LocalReport.ReportPath = Server.MapPath("Reports/AdminApp_PurchaseRequisition.rdlc");
            ReportViewerPurchase.LocalReport.Refresh();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequisitionsearch();
        }


        protected void grvReqItemList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label IndexID = (Label)grvReqItemList.Rows[e.RowIndex].FindControl("lblReqNo");
            string Id = IndexID.Text;

            TextBox txtprice = (TextBox)grvReqItemList.Rows[e.RowIndex].FindControl("txtPrice");
            string price = txtprice.Text;

            TextBox txtqty = (TextBox)grvReqItemList.Rows[e.RowIndex].FindControl("txtApproveQty");
            string qty = txtqty.Text;

            Label lblTotal = (Label)grvReqItemList.Rows[e.RowIndex].FindControl("lblTotal");
            string total = lblTotal.Text;

            total = price + qty;
            grvReqItemList.EditIndex = -1;

        }



        protected void txtApproveQty_Changed(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvr in grvReqItemList.Rows)
                {
                    TextBox txtprice = (TextBox)gvr.FindControl("txtPrice");
                    int price = Convert.ToInt32(txtprice.Text);

                    TextBox txtqty = (TextBox)gvr.FindControl("txtApproveQty");
                    int qty = Convert.ToInt32(txtqty.Text);

                    Label lblTotal = (Label)gvr.FindControl("lblTotal");
                    string total = lblTotal.Text;

                    total = Convert.ToString(price * qty);
                    lblTotal.Text = Convert.ToString(total);

                    m = Convert.ToInt16(m + int.Parse(total));

                    Control control = null;
                    if (grvReqItemList.FooterRow != null)
                    {
                        control = grvReqItemList.FooterRow;
                    }
                    else
                    {
                        control = grvReqItemList.Controls[0].Controls[0];
                    }

                    if (grvReqItemList.Rows.Count > 0)
                    {
                        Label lblsalary_ = null;
                        lblsalary_ = control.FindControl("lblsalary") as Label;
                        lblsalary_.Text ="Total Price:"+ m.ToString();
                        lblsalary_.ForeColor = Color.Green;
                    }
                }

            }
            catch { }
        }

        protected void txtPrice_Changed(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvr in grvReqItemList.Rows)
                {
                    TextBox txtprice = (TextBox)gvr.FindControl("txtPrice");
                    int price = Convert.ToInt32(txtprice.Text);

                    TextBox txtqty = (TextBox)gvr.FindControl("txtApproveQty");
                    int qty = Convert.ToInt32(txtqty.Text);

                    Label lblTotal = (Label)gvr.FindControl("lblTotal");
                    string total = lblTotal.Text;

                    total = Convert.ToString(price * qty);
                    lblTotal.Text = Convert.ToString(total);

                    m = Convert.ToInt16(m + int.Parse(total));

                    Control control = null;
                    if (grvReqItemList.FooterRow != null)
                    {
                        control = grvReqItemList.FooterRow;
                    }
                    else
                    {
                        control = grvReqItemList.Controls[0].Controls[0];
                    }

                    if (grvReqItemList.Rows.Count > 0)
                    {
                        Label lblsalary_ = null;
                        lblsalary_ = control.FindControl("lblsalary") as Label;
                        lblsalary_.Text ="Total Price:"+ m.ToString();
                        lblsalary_.ForeColor = Color.Blue;
                        
                    }
                }

            }
            catch { }
        }


        protected void grvReqItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label Salary = (Label)e.Row.FindControl("lblTotal");
            //    m = m + int.Parse(Salary.Text);
            //}

            //Control control = null;
            //if (grvReqItemList.FooterRow != null)
            //{
            //    control = grvReqItemList.FooterRow;
            //}
            //else
            //{
            //    control = grvReqItemList.Controls[0].Controls[0];
            //}

            //if (grvReqItemList.Rows.Count > 0)
            //{
            //    Label lblsalary_ = null;
            //    lblsalary_ = control.FindControl("lblsalary") as Label;
            //    lblsalary_.Text = m.ToString();
            //}

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label Salary = (Label)e.Row.FindControl("lblTotal");

            //    m = m + int.Parse(Salary.Text);

            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lblTotalPrice = (Label)e.Row.FindControl("lblsalary");

            //    lblTotalPrice.Text = m.ToString();
            //}

        }

        private void SearcheByStatus()
        {
           // string ReqNo = "";
            string Status = ddlStatus.SelectedItem.Text;
            DataTable dt = new DataTable();
            dt = RequisionBll.GetPendingListForManager("Head", Status);
            if (dt.Rows.Count > 0)
            {
                grdRequisition.DataSource = dt;
                grdRequisition.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                grdRequisition.DataSource = null;
                grdRequisition.DataBind();
            }
        }

        private void SearcheByDPT()
        {
            //string ReqNo = "";
            string DPT_CODE = ddlDepartment.SelectedValue;
            DataTable dt = new DataTable();
            dt = RequisionBll.GetPendingPurchaseRequisitionForAdminByDPTCasceding("Head", DPT_CODE);
            if (dt.Rows.Count > 0)
            {
                grdRequisition.DataSource = dt;
                grdRequisition.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                grdRequisition.DataSource = null;
                grdRequisition.DataBind();
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearcheByStatus();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearcheByDPT();
        }

    }

}