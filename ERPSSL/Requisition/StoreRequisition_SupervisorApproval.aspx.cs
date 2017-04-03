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

namespace ERPSSL.INV
{
    public partial class StoreRequisition_SupervisorApproval : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadRequisitions("");
                    // LoadAllSupervisor1List();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void LoadAllSupervisor1List()
        //{
        //    string OCode = ((SessionUser)Session["SessionUser"]).OCode;
        //    var assignSupervisorList = aRequisionBll.GetAllSupervisor1List(OCode).OrderBy(x => x.Supervisor1_EID).ToList();

        //    ddlSupervisor1EID.DataSource = assignSupervisorList;
        //    ddlSupervisor1EID.DataValueField = "Supervisor1_EID";
        //    ddlSupervisor1EID.DataTextField = "EmployeeInfo";
        //    ddlSupervisor1EID.DataBind();
        //    ddlSupervisor1EID.Items.Insert(0, new ListItem("Select One", "0"));
        //}

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetPendingStoreRequisition(ReqNo, "Manager");
            grdRequisition.DataBind();
        }

        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetStoreRequisitionData(ReqNo, "Manager");
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
                    grvReqItemList.DataSource = aChallanBll.GetStoreRequisitionData(reqNo, "Manager");
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

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                List<PRQ_Requisitions> lstPRQ_Requisitions = new List<PRQ_Requisitions>();
                //bool status = true;
                bool CheckStatus = false;

                foreach (GridViewRow gvRow in grvReqItemList.Rows)
                {

                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    if (rowChkBox.Checked == true)
                    {
                        CheckStatus = true;
                    }
                }

                if (CheckStatus)
                {
                    foreach (GridViewRow gvr in grvReqItemList.Rows)
                    {
                        PRQ_Requisitions objPRQ_Requisitions = new PRQ_Requisitions();
                        Label lblReqNo = (Label)gvr.FindControl("lblReqNo");
                        Label lblBarcode = (Label)gvr.FindControl("lblBarcode");

                        TextBox txtApproveQty = (TextBox)gvr.FindControl("txtApproveQty");
                        int ApproveQty = int.Parse(txtApproveQty.Text);

                        DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
                        string Status = ddlStatus.SelectedItem.Text;
                        if (ddlStatus.SelectedItem.Text == "Re-Forward")
                        {
                            objPRQ_Requisitions.Status = "Re-Forward";
                            objPRQ_Requisitions.IsAcceptedByManager = false;
                            objPRQ_Requisitions.IsAcceptedByHead = false;
                        }
                        else if (ddlStatus.SelectedItem.Text == "Approved")
                        {
                            objPRQ_Requisitions.Status = "Pending";
                            objPRQ_Requisitions.ManagerApproveQty = ApproveQty;
                            objPRQ_Requisitions.IsAcceptedByManager = true;
                        }
                        else if (ddlStatus.SelectedItem.Text == "Cancel")
                        {
                            objPRQ_Requisitions.Status = "Cancel";
                            objPRQ_Requisitions.IsAcceptedByManager = false;
                        }
                        else if (ddlStatus.SelectedItem.Text == "Pending")
                        {
                            objPRQ_Requisitions.Status = "Pending";
                            objPRQ_Requisitions.IsAcceptedByManager = true;
                        }


                        objPRQ_Requisitions.ManagerApproveQty = ApproveQty;
                        objPRQ_Requisitions.ReqNo = lblReqNo.Text;
                        objPRQ_Requisitions.BarCode = Convert.ToInt16(lblBarcode.Text);
                        // objPRQ_Requisitions.Supervisor_EID = ddlSupervisor1EID.SelectedValue;
                        string EID = ((SessionUser)Session["SessionUser"]).EID;
                        objPRQ_Requisitions.Supervisor_EID = EID;

                        lstPRQ_Requisitions.Add(objPRQ_Requisitions);
                    }

                    int result = aRequisionBll.StoreReqApprovalBySupervisor(lstPRQ_Requisitions);
                    LoadRequisitions("");
                    grvReqItemList.DataSource = null;
                    grvReqItemList.DataBind();
                    //LoadRequisitionsItem(reqNo);
                    //lblMessage.Text = "Requisition Approved Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition approved successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item Selected!')", true);

                }
            }
            catch (Exception ex)
            {
                //lblMessage.Text = "<font color='red'>Error in approval! Please try again</font>";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grvReqItemList.HeaderRow.FindControl("headerLevelCheckBox"));
                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grvReqItemList.Rows)
                    {

                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox     

                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grvReqItemList.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        //protected void txtApproveQty_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Label lblBalance = (Label)grvReqItemList.FindControl("lblReq");
        //       // Label lblItem = (Label)grvReqItemList.FindControl("lblItem");
        //      //  Label lblTotalAppQty = (Label)grvReqItemList.FindControl("lblTotalAppQty");

        //        TextBox txtApproveQty = (TextBox)grvReqItemList.FindControl("txtApproveQty");
        //        int ApproveQty = int.Parse(txtApproveQty.Text);

        //        if (ApproveQty > Convert.ToInt16(lblBalance.Text) )
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Approve quantity can not be larger than Request Qty!')", true);
        //            //lblMessage.Text = "<font color='red'>'" + lblItem.Text + "' approve quantity can not be larger than stock!</font>";
        //            //return;
        //        }
        //    }
        //    catch { }
        //}
        protected void rowLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {


            foreach (GridViewRow gvRow in grvReqItemList.Rows)
            {
                CheckBox chk = (CheckBox)gvRow.FindControl("rowLevelCheckBox");

                if (chk.Checked)
                {
                    TextBox lblBalanceQuantity = ((TextBox)gvRow.FindControl("txtApproveQty"));
                    Label lblReqQuantity = ((Label)gvRow.FindControl("lblReq"));
                    if (lblBalanceQuantity.Text != "")
                    {

                        double balancequantity = Convert.ToDouble(lblBalanceQuantity.Text);
                        double lblQty = Convert.ToDouble(lblReqQuantity.Text);
                        if (balancequantity <= 0)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                            rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox       
                        }
                        else
                        {
                            if (lblQty < balancequantity)
                            {
                                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                                rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox    
                            }

                        }
                    }
                    else
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox    
                    }

                }

            }

        }

    }
}