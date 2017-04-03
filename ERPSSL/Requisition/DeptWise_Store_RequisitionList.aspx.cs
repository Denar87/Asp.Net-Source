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

namespace ERPSSL.INV
{
    public partial class DeptWise_Store_RequisitionList : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        IChallanBLL ic = new IChallanBLL();
        Office_BLL officeBll = new Office_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetEmployeeInfo();
                    //LoadRequisitions("");
                    txtFromDate.Text = DateTime.Now.ToShortDateString();
                    txtToDate.Text = DateTime.Now.ToShortDateString();
                    FillDepartmentByOffice();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
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
                        //hdnEID.Value = ((SessionUser)Session["SessionUser"]).EID;
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
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
            grdRequisition.DataSource = RequisionBll.GetAll_StoreReqList(ReqNo, "Head", ddlEmployee.SelectedValue, txtFromDate.Text, txtToDate.Text);
            grdRequisition.DataBind();
        }

        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetAllStoreRequisitionData(ReqNo, "Head");
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
                    grvReqItemList.DataSource = aChallanBll.GetAllStoreRequisitionData(reqNo, "Head");
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
                if (Session["RequisitionNo"] != null && grvReqItemList.Rows.Count != 0)
                {
                    Response.Redirect("DeptWise_UpdateStoreRequisition.aspx");
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

        private void LoadRequisitionsearch()
        {

            string ReqNo = "";
            string Dept = ddlDepartment.SelectedValue;
            DataTable dt = new DataTable();

            dt = RequisionBll.GetAll_StoreReqListByDepartment(ReqNo, "Head", ddlEmployee.SelectedValue, txtFromDate.Text, txtToDate.Text, Dept);
            if (dt.Rows.Count > 0)
            {
                grdRequisition.DataSource = dt;
                grdRequisition.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No store requisition found!')", true);
                grdRequisition.DataSource = null;
                grdRequisition.DataBind();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequisitionsearch();
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

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                //BindRequisitionNo();
            }
            catch { }
        }

        private void LoadEmployeeList(string DeptCode)
        {

            DeptCode = ddlDepartment.SelectedValue;
            ddlEmployee.DataSource = ic.GetEmployeeListByDept(DeptCode);
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
        }
    }
}