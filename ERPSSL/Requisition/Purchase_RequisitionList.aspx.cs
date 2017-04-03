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

namespace ERPSSL.Requisition
{
    public partial class Purchase_RequisitionList : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetEmployeeInfo();
                LoadRequisitions("");
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
                        hdnEID.Value = ((SessionUser)Session["SessionUser"]).EID;
                        //txtEID.Text = ((SessionUser)Session["SessionUser"]).EID;
                        //txtDesignation.Text = assign.DeginationName.ToString();
                        //txtDepartment.Text = assign.DepartmentName.ToString();
                        //hdnDEPT_CODE.Value = assign.DPT_CODE;
                        //ddlDepartment.SelectedItem.Text = assign.DepartmentName.ToString();
                        //ddlDepartment.SelectedValue = assign.DPT_CODE.ToString();
                    }
                    //List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    //foreach (HRM_PersonalInformations aperson in personanlInfo)
                    //{
                    //txtEmployee.Text = aperson.FirstName + " " + aperson.LastName;
                    //LoadEmployeeList();
                    //ddlEmployee.SelectedValue = aperson.EID;
                    //hidReportingBossID.Value = aperson.ReportingBossId;
                    //}
                }
            }
            catch
            {
            }
        }

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetAll_PurchaseReqList(ReqNo, "Head", hdnEID.Value, txtFromDate.Text, txtToDate.Text);
            grdRequisition.DataBind();
        }

        private void LoadRequisitionsearch()
        {
            string ReqNo = "";
            DataTable dt = new DataTable();
            dt = RequisionBll.GetAll_PurchaseReqList(ReqNo, "Head", hdnEID.Value, txtFromDate.Text, txtToDate.Text);
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

        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetAllPurchaseRequisitionData(ReqNo, "Head");
            grvReqItemList.DataBind();
        }

        protected void grdRequisition_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Label ReqNo = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblReqNo");
                lblMessage.Text = "";
                DataTable dt = new DataTable();
                string reqNo = e.CommandArgument.ToString();
                Session["RequisitionNo"] = reqNo;

                if (e.CommandName == "select")
                {
                    grvReqItemList.DataSource = aChallanBll.GetAllPurchaseRequisitionData(reqNo, "Head");
                    grvReqItemList.DataBind();
                    //dt = aChallanBll.GetStoreRequisitionData(reqNo, "Manager");
                    //LoadRequisitionsItem("");
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
                if (Session["RequisitionNo"] != null && grvReqItemList.Rows.Count != 0)
                {

                    Response.Redirect("UpdatePurchaseRequisition.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please search & select a requisition first!')", true);
                    //lblMessage.Text = "<font color='red'>Please Select a Requisition from List</font>";
                }

            }
            catch
            {

            }
            //try
            //{
            //    List<PRQ_Requisitions> lstPRQ_Requisitions = new List<PRQ_Requisitions>();

            //    foreach (GridViewRow gvr in grvReqItemList.Rows)
            //    {
            //        PRQ_Requisitions objPRQ_Requisitions = new PRQ_Requisitions();
            //        Label lblReqNo = (Label)gvr.FindControl("lblReqNo");
            //        Label lblBarcode = (Label)gvr.FindControl("lblBarcode");
            //        Label lblBalance = (Label)gvr.FindControl("lblBalance");
            //        Label lblItem = (Label)gvr.FindControl("lblItem");
            //        Label lblTotalAppQty = (Label)gvr.FindControl("lblTotalAppQty");

            //        TextBox txtApproveQty = (TextBox)gvr.FindControl("txtApproveQty");
            //        int ApproveQty = int.Parse(txtApproveQty.Text);

            //        DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
            //        string Status = ddlStatus.SelectedItem.Text;

            //        objPRQ_Requisitions.HeadApproveQty = ApproveQty;
            //        objPRQ_Requisitions.IsAcceptedByHead = true;
            //        objPRQ_Requisitions.ReqNo = lblReqNo.Text;
            //        objPRQ_Requisitions.BarCode = Convert.ToInt16(lblBarcode.Text);
            //        objPRQ_Requisitions.Status = Status;
            //        objPRQ_Requisitions.Admin_EID = hdnAdminEID.Value; //Approved By

            //        //if (ApproveQty > (Convert.ToInt16(lblBalance.Text) - Convert.ToInt16(lblTotalAppQty.Text)))
            //        //{
            //        //    lblMessage.Text = "<font color='red'>'" + lblItem.Text + "' approve quantity can not be larger than stock!</font>";
            //        //    return;
            //        //}



            //        //if (ApproveQty >= Convert.ToInt16(lblTotalAppQty.Text))
            //        //{
            //        //    lblMessage.Text = "<font color='red'>" + lblItem.Text + " approve quantity exceeded!</font>";
            //        //    return;
            //        //}

            //        lstPRQ_Requisitions.Add(objPRQ_Requisitions);
            //    }

            //    int result = aRequisionBll.StoreReqApprovalByAdmin(lstPRQ_Requisitions);
            //    LoadRequisitions("");
            //    grvReqItemList.DataSource = null;
            //    grvReqItemList.DataBind();
            //    //LoadRequisitionsItem(reqNo);
            //    lblMessage.Text = "Requisition Approved Successfully.";
            //}
            //catch
            //{
            //    lblMessage.Text = "<font color='red'>Error in approval! Please try again</font>";
            //}
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequisitionsearch();
        }
    }
}