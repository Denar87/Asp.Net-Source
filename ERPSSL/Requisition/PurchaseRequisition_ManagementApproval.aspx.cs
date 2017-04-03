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
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Drawing;

namespace ERPSSL.Requisition
{
    public partial class PurchaseRequisition_ManagementApproval : System.Web.UI.Page
    {
        int m = 0;
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        RChallanBLL rChallanBll = new RChallanBLL();
        IChallanBLL ic = new IChallanBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetEmployeeInfo();
               // LoadRequisitions("");
                FillDepartmentbyReq();
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
            grdRequisition.DataSource = RequisionBll.GetPendingPurchaseRequisition(ReqNo, "Management");
            grdRequisition.DataBind();
        }


        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetPurchaseRequisitionData(ReqNo, "Management");
            grvReqItemList.DataBind();
        }

        //private void LoadEmployeeList()
        //{
        //    ddlStatus.DataSource = ic.GetEmployeeList();
        //    ddlStatus.DataValueField = "EID";
        //    ddlStatus.DataTextField = "EMP_NAME";
        //    ddlStatus.DataBind();
        //    ddlStatus.Items.Insert(0, new ListItem("---Select One---", "0"));
        //}

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
                    grvReqItemList.DataSource = aChallanBll.GetPurchaseRequisitionData(reqNo, "Management");
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
                List<PRQ_Requisitions> lstPRQ_Requisitions = new List<PRQ_Requisitions>();

                foreach (GridViewRow gvr in grvReqItemList.Rows)
                {
                    PRQ_Requisitions objPRQ_Requisitions = new PRQ_Requisitions();
                    Label lblReqNo = (Label)gvr.FindControl("lblReqNo");
                    Label lblBarcode = (Label)gvr.FindControl("lblBarcode");
                    Label lblBalance = (Label)gvr.FindControl("lblBalance");
                    Label lblItem = (Label)gvr.FindControl("lblItem");
                    Label lblTotalAppQty = (Label)gvr.FindControl("lblTotalAppQty");

                    TextBox txtApproveQty = (TextBox)gvr.FindControl("txtApproveQty");
                    int ApproveQty = int.Parse(txtApproveQty.Text);

                    DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
                    string Status = ddlStatus.SelectedItem.Text;

                    objPRQ_Requisitions.ManagementAppQty = ApproveQty;

                    if (ddlStatus.SelectedItem.Text == "Approve")
                    {
                        objPRQ_Requisitions.IsAcceptedByManagement = true;
                        objPRQ_Requisitions.Management_Status = "Approve";

                    }
                    else
                    {
                        objPRQ_Requisitions.IsAcceptedByManagement = false;
                        objPRQ_Requisitions.Management_Status = "Pending";


                    }
                    objPRQ_Requisitions.ReqNo = lblReqNo.Text;
                   


                    string ReQNo = "Req";
                    String FILE_TYPE = Path.GetExtension(ReqFileUpload.FileName);
                    string FILE_NAME = Path.GetFileName(ReqFileUpload.PostedFile.FileName);
                    string OCODE = "8989";
                    string REQ = lblReqNo.Text;
                    EnsureTrackDirectoriesExist(ReQNo);
                  
                    string DB_FILE_PATH = "" + ReQNo.ToString() + "\\" + REQ + FILE_NAME;
                


                   // ReqFileUpload.SaveAs(Server.MapPath("~/Requisition/Req_Document/" + "/" + FILE_NAME));

                    ReqFileUpload.SaveAs(Server.MapPath("~/Requisition/Req_Document/" + ReQNo.ToString() + "/" + REQ+ FILE_NAME));
                   // objPRQ_Requisitions.Req_File = ReqFileUpload.FileBytes;
                    objPRQ_Requisitions.File_Path = DB_FILE_PATH;


                    objPRQ_Requisitions.BarCode = Convert.ToInt16(lblBarcode.Text);
                    objPRQ_Requisitions.RFile_Name = FILE_NAME;
                    objPRQ_Requisitions.RFile_Type = FILE_TYPE;
                    objPRQ_Requisitions.Status = Status;
                    //objPRQ_Requisitions.Admin_EID = hdnAdminEID.Value; //Approved By

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

                int result = aRequisionBll.PurchaseReqApprovalByManagement(lstPRQ_Requisitions);
                LoadRequisitions("");
                grvReqItemList.DataSource = null;
                grvReqItemList.DataBind();
                //LoadRequisitionsItem(reqNo);
                //lblMessage.Text = "Data Recorded Successfully.";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data recorded successfully')", true);
            }
            catch
            {
                //lblMessage.Text = "<font color='red'>Data Adding Failure!</font>";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data adding failure!')", true);
            }
        }
        public void EnsureTrackDirectoriesExist(string ReQNo)
        {

            if (!System.IO.Directory.Exists(Server.MapPath("~/Requisition/Req_Document/"+ReQNo.ToString())))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Requisition/Req_Document/" + ReQNo.ToString()));
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
            ReportViewerPurchase.LocalReport.ReportPath = Server.MapPath("Reports/ManagmentApp_PurchaseRequisition.rdlc");
            ReportViewerPurchase.LocalReport.Refresh();
        }


        //.....
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
                        lblsalary_.Text = "Total Price:" + m.ToString();
                        lblsalary_.ForeColor = Color.Blue;

                    }
                }

            }
            catch { }
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
                        lblsalary_.Text = "Total Price:" + m.ToString();
                        lblsalary_.ForeColor = Color.Green;
                    }
                }

            }
            catch { }
        }

        private void FillDepartmentbyReq()
        {
            ddlDepartment.DataSource = ic.GetDepartmentListByReqNo();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        }
        private void SearcheByStatus()
        {
            // string ReqNo = "";
            string Status = ddlStatus.SelectedItem.Text;
            DataTable dt = new DataTable();
            dt = RequisionBll.GetPendingListForManagement("Management", Status);
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

        private void SearcheByDepartment()
        {
            // string ReqNo = "";
            string DEPT = ddlDepartment.SelectedValue;
            DataTable dt = new DataTable();
            dt = RequisionBll.GetAllRequisitionByDepartment("Management", DEPT);
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
           SearcheByDepartment();
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
                    dt = RequisionBll.GetPendingPurchaseRequisitionForAdmin(ReqNo, "Management", DPT_CODE, Status, FromDate, ToDate);
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
                    dt = RequisionBll.GetPendingPurchaseRequisitionForAdminApprove(ReqNo, "Management", DPT_CODE, Status, FromDate, ToDate);
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
                    dt = RequisionBll.GetPendingPurchaseRequisitionForAdminAllStatus(ReqNo, "Management", DPT_CODE, Status, FromDate, ToDate);
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
                dt = RequisionBll.GetPendingPurchaseRequisitionForAdminByDPT(ReqNo, "Management", DPT_CODE, FromDate, ToDate);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequisitionsearch();
        }

    }
}