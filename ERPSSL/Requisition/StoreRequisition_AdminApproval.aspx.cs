﻿using System;
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

namespace ERPSSL.INV
{
    public partial class StoreRequisition_AdminApproval : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetEmployeeInfo();
                    LoadRequisitions("");
                    //LoadAllSupervisor1List();
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
            grdRequisition.DataSource = RequisionBll.GetPendingStoreRequisition(ReqNo, "Head");
            grdRequisition.DataBind();
        }

        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetStoreRequisitionData(ReqNo, "Head");
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
                if (e.CommandName == "select")
                {
                    grvReqItemList.DataSource = aChallanBll.GetStoreRequisitionData(reqNo, "Head");
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
                        Label lblBalance = (Label)gvr.FindControl("lblBalance");
                        Label lblItem = (Label)gvr.FindControl("lblItem");
                        Label lblTotalAppQty = (Label)gvr.FindControl("lblTotalAppQty");

                        TextBox txtApproveQty = (TextBox)gvr.FindControl("txtApproveQty");
                        int ApproveQty = int.Parse(txtApproveQty.Text);

                        DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
                        string Status = ddlStatus.SelectedItem.Text;

                        objPRQ_Requisitions.HeadApproveQty = ApproveQty;

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
                        else if (ddlStatus.SelectedItem.Text == "Cancel")
                        {
                            objPRQ_Requisitions.Status = "Cancel";
                            objPRQ_Requisitions.IsAcceptedByManager = false;
                        }
                        else
                        {
                            objPRQ_Requisitions.IsAcceptedByHead = false;
                            objPRQ_Requisitions.IsAcceptedByManager = true;
                        }

                        //if (ddlStatus.SelectedItem.Text == "Approve")
                        //{
                        //    objPRQ_Requisitions.IsAcceptedByHead = true;
                        //}
                        //else
                        //{
                        //    objPRQ_Requisitions.IsAcceptedByHead = false;
                        //}
                        objPRQ_Requisitions.ReqNo = lblReqNo.Text;
                        objPRQ_Requisitions.BarCode = Convert.ToInt16(lblBarcode.Text);
                        objPRQ_Requisitions.Status = Status;
                        //objPRQ_Requisitions.Admin_EID = hdnAdminEID.Value; //Approved By
                        // objPRQ_Requisitions.Admin_EID = ddlSupervisor1EID.SelectedValue;
                        string EID = ((SessionUser)Session["SessionUser"]).EID;
                        objPRQ_Requisitions.Admin_EID = EID;
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
                    int result = aRequisionBll.StoreReqApprovalByAdmin(lstPRQ_Requisitions);
                    LoadRequisitions("");
                    grvReqItemList.DataSource = null;
                    grvReqItemList.DataBind();
                    //LoadRequisitionsItem(reqNo);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data recorded successfully')", true);
                    //lblMessage.Text = "Data Recorded Successfully.";
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
        protected void rowLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {


            foreach (GridViewRow gvRow in grvReqItemList.Rows)
            {
                CheckBox chk = (CheckBox)gvRow.FindControl("rowLevelCheckBox");

                if (chk.Checked)
                {
                    TextBox lblBalanceQuantity = ((TextBox)gvRow.FindControl("txtApproveQty"));
                    Label lblReqQuantity = ((Label)gvRow.FindControl("lblBalance"));
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