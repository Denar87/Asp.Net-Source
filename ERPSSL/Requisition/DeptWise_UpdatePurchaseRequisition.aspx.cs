using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.BLL;

namespace ERPSSL.Requisition
{
    public partial class DeptWise_UpdatePurchaseRequisition : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        ProductBLL productBll = new ProductBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        Office_BLL officeBll = new Office_BLL();
        UnitBLL unitBll = new UnitBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllUnit();
                BindRequisitionNo();
                GetEmployeeInfo();
                FillProductGroup();
                FillDepartmentByOffice();
                //FillDepartment();
                txtDate.Text = DateTime.Today.ToShortDateString();
                txtExpectedDate.Text = DateTime.Today.ToShortDateString();

                ShowRequisitionData();
                ShowRequisitionDataForGrid();
            }
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
                        //txtEID.Text = ((SessionUser)Session["SessionUser"]).EID;
                        //txtDesignation.Text = assign.DeginationName.ToString();
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
                        //txtDepartment.Text = assign.DepartmentName.ToString();
                        //hdnDEPT_CODE.Value = assign.DPT_CODE;
                        //ddlDepartment.SelectedItem.Text = assign.DepartmentName.ToString();
                        //ddlDepartment.SelectedValue = assign.DPT_CODE.ToString();
                    }
                    //List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    //foreach (HRM_PersonalInformations aperson in personanlInfo)
                    // {
                    //txtEmployee.Text = aperson.FirstName + " " + aperson.LastName;
                    //LoadEmployeeList();
                    //ddlEmployee.SelectedValue = aperson.EID;
                    //hidReportingBossID.Value = aperson.ReportingBossId;
                    // }
                }
            }
            catch
            {
            }
        }

        //shabda...
        private void ShowRequisitionData()
        {
            string QNO = Session["RequisitionNo"].ToString();
            DataTable dt = new DataTable();
            dt = RequisionBll.GetStoreRequisitions(QNO);
            if (dt.Rows.Count != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //txtEID.Text = dr["EID"].ToString();
                    txtRequisitionNo.Text = dr["ReqNo"].ToString();
                    txtDate.Text = Convert.ToDateTime(dr["ReqDate"]).ToShortDateString();
                    txtRequisitionNo.Text = dr["ReqNo"].ToString();

                    txtExpectedDate.Text = Convert.ToDateTime(dr["DesiredRcvDate"]).ToShortDateString();
                    LoadEmployeeLists();
                    ddlEmployee.SelectedValue = dr["EID"].ToString();
                    FillDepartment();
                    ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                    txtDesignation.Text = dr["DEG_NAME"].ToString();


                    // ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();

                    txtJustification.Text = dr["Reason_Justification"].ToString();

                    BtnSave.Text = "Update";

                }
            }
        }

        private void ShowRequisitionDataForGrid()
        {
            string QNO = Session["RequisitionNo"].ToString();
            DataTable dt = new DataTable();
            dt = RequisionBll.GetRequisitionGrid(QNO);
            if (dt.Rows.Count != null)
            {

                grdRequisition.DataSource = dt;
                grdRequisition.DataBind();
            }
        }

        protected void GetAllUnit()
        {
            try
            {

                var row = unitBll.GetAllUnit();
                if (row.Count > 0)
                {
                    ddlUnit.DataSource = row.ToList();
                    ddlUnit.DataTextField = "UnitName";
                    ddlUnit.DataValueField = "UnitId";
                    ddlUnit.DataBind();
                    ddlUnit.AppendDataBoundItems = false;
                    ddlUnit.Items.Insert(0, new ListItem("Unit", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
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

        private void FillProductGroup()
        {
            ddlProductGroup.DataSource = ic.GetListGroup();
            ddlProductGroup.DataValueField = "GroupId";
            ddlProductGroup.DataTextField = "GroupName";
            ddlProductGroup.DataBind();
            ddlProductGroup.Items.Insert(0, new ListItem("Select Item Group", "0"));
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

        private void BindRequisitionNo()
        {
            //if (txtDepartment.Text != "" && txtDate.Text != "")
            //{
            try
            {
                DateTime date;
                try
                {
                    date = DateTime.Parse(txtDate.Text);
                }
                catch
                {
                    date = DateTime.Today;
                }

                txtRequisitionNo.Text = ic.GetNewRequisitionNo("DPT", "", ddlDepartment.SelectedValue, ddlEmployee.SelectedValue, date);
            }
            catch { }
            //}
        }

        private void LoadEmployeeList(string DeptCode)
        {
            ddlEmployee.DataSource = ic.GetEmployeeListByDept(DeptCode);
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
        }

        private void LoadEmployeeLists()
        {
            ddlEmployee.DataSource = ic.GetEmployeeList();
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
        }



        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            BindRequisitionNo();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //shabda
                if (BtnSave.Text == "Update")
                {
                    if (ddlProduct.SelectedValue == "")
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("ReqNo", txtRequisitionNo.Text);
                        ht.Add("ReqType", "Purchase");
                        ht.Add("CompanyCode", "");
                        ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                        ht.Add("EID", ddlEmployee.SelectedValue);
                        ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                        ht.Add("RecomendBy", "n/a");
                        ht.Add("Reason_Justification", txtJustification.Text);
                        ht.Add("ReqDate", txtDate.Text);
                        ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                        ht.Add("Remarks", txtRemarks.Text);

                        if (RequisionBll.updatepurchaseRequisition(ht) == false)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updated successfully')", true);
                            ShowRequisitionDataForGrid();
                            ClearForm();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updating error!')", true);
                            //lblMessage.Text = "<font color='red'>Error in updating requisition! Please try again</font>";
                        }
                    }
                    else if (Convert.ToInt32(ddlProduct.SelectedValue) == 0)
                    {

                        Hashtable ht = new Hashtable();
                        ht.Add("ReqNo", txtRequisitionNo.Text);
                        ht.Add("ReqType", "Purchase");
                        ht.Add("CompanyCode", "");
                        ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                        ht.Add("EID", ddlEmployee.SelectedValue);
                        ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                        ht.Add("RecomendBy", "n/a");
                        ht.Add("Reason_Justification", txtJustification.Text);
                        ht.Add("ReqDate", txtDate.Text);
                        ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                        ht.Add("Remarks", txtRemarks.Text);

                        if (RequisionBll.updatepurchaseRequisition(ht) == false)
                        {
                            ClearForm();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updated successfully')", true);
                            ShowRequisitionDataForGrid();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updating error!')", true);
                            //lblMessage.Text = "<font color='red'>Error in updating requisition! Please try again</font>";
                        }
                    }
                    else if (Convert.ToInt32(ddlProductGroup.SelectedValue) != 0 && Convert.ToInt32(ddlProduct.SelectedValue) != 0)
                    {
                        DataTable dt = new DataTable();
                        string ReqNo = txtRequisitionNo.Text;
                        string Barocde = ddlProduct.SelectedValue;
                        dt = RequisionBll.GetBarCode(ReqNo, Barocde);
                        if (dt.Rows.Count > 0)
                        {
                            Hashtable ht = new Hashtable();
                            ht.Add("ReqNo", txtRequisitionNo.Text);
                            ht.Add("ReqType", "Purchase");
                            ht.Add("CompanyCode", "");
                            ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                            ht.Add("EID", ddlEmployee.SelectedValue);
                            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                            ht.Add("RecomendBy", "n/a");
                            ht.Add("Reason_Justification", txtJustification.Text);
                            ht.Add("ReqDate", txtDate.Text);
                            ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                            ht.Add("Remarks", txtRemarks.Text);

                            ht.Add("Qty", txtQuantity.Text);
                            ht.Add("BarCode", ddlProduct.SelectedValue);

                            if (RequisionBll.updatePurchaseRequisitions(ht) == false)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updated successfully')", true);
                                ShowRequisitionDataForGrid();
                                ClearForm();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updating error!')", true);
                                //lblMessage.Text = "<font color='red'>Error in updating requisition! Please try again</font>";
                            }
                        }
                        else
                        {
                            Hashtable ht = new Hashtable();
                            ht.Add("ReqNo", txtRequisitionNo.Text);
                            ht.Add("ReqType", "Purchase");
                            ht.Add("CompanyCode", "");
                            ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                            ht.Add("EID", ddlEmployee.SelectedValue);
                            ht.Add("BarCode", ddlProduct.SelectedValue);
                            ht.Add("Qty", txtQuantity.Text);
                            ht.Add("ReqDate", txtDate.Text);
                            ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                            ht.Add("RecomendBy", "n/a");
                            ht.Add("Reason_Justification", txtJustification.Text);
                            ht.Add("Remarks", txtRemarks.Text);
                            if (RequisionBll.AddPurchaseRequisition(ht))
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updated successfully')", true);
                                LoadRequisitions(txtRequisitionNo.Text);
                                ClearForm();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition updating error!')", true);
                                //lblMessage.Text = "<font color='red'>Error in updating requisition! Please try again</font>";
                            }
                        }
                    }

                }
            }
            catch { }
        }

        private void ClearForm()
        {
            ddlProductGroup.ClearSelection();
            ddlProduct.ClearSelection();
            ddlUnit.ClearSelection();
            //txtExpectedDate.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtRemarks.Text = "";
            txtDescription.Text = string.Empty;
            txtBalanceQty.Text = "";
        }

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetStoreRequisition(ReqNo, "DPT");
            grdRequisition.DataBind();
        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ddlProduct.Enabled = true;
            FillProductName();
        }

        private void FillProductName()
        {
            if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
            {
                ddlProduct.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlProductGroup.SelectedValue));
                ddlProduct.DataValueField = "ProductId";
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select Item", "0"));
            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string barCode = ddlProduct.SelectedValue.ToString();
            var result = productBll.GetProductById(Convert.ToInt32(ddlProduct.SelectedValue));
            if (result.Count > 0)
            {
                var objProduct = result.First();
                ddlUnit.SelectedValue = objProduct.UnitId.ToString();
                //txtUnit.Text = objProduct.UnitName;
                txtDescription.Text = objProduct.StyleAndSize;
            }

            var stock = productBll.GetProductStockById(Convert.ToInt32(ddlProduct.SelectedValue));

            if (stock.Count > 0)
            {
                var objstock = stock.First();
                txtBalanceQty.Text = Convert.ToString(objstock.BalanceQuanity);
            }
            else
            {
                txtBalanceQty.Text = "0";
            }
        }

        protected void grdRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "dlt")
                {
                    ic.DeleteRequisitionById(id);
                    LoadRequisitions(txtRequisitionNo.Text);
                }

            }
            catch { }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ic.GetEmployeeDesignation(ddlEmployee.SelectedValue.ToString());
            txtDesignation.Text = dt.Rows[0][0].ToString();
            //txtEID.Text = ddlEmployee.SelectedValue.ToString();
        }

        protected void txtDescription_TextChanged(object sender, EventArgs e)
        {
            var stock = productBll.GetProductStockByIdandDescription(Convert.ToInt32(ddlProduct.SelectedValue), txtDescription.Text);

            if (stock.Count > 0)
            {
                var objstock = stock.First();
                txtBalanceQty.Text = Convert.ToString(objstock.BalanceQuanity);
            }
            else
            {
                txtBalanceQty.Text = "0";
            }
        }

        protected void grdRequisitions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            // string ReqNo = txtRequisitionNo.Text;
            if (e.CommandName == "dlt")
            {
                ic.DeleteRequisitionById(id);
                LoadRequisitions(txtRequisitionNo.Text);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition item deleted successfully')", true);
            }
            if (e.CommandName == "edt")
            {
                {
                    DataTable dt = new DataTable();
                    dt = ic.GetDataEditRequisition(id);
                    if (dt.Rows.Count != null)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            ddlProductGroup.SelectedValue = dr["GroupId"].ToString();
                            FillProductName();
                            ddlProduct.SelectedValue = dr["BarCode"].ToString();
                            ddlUnit.SelectedValue = dr["UnitId"].ToString();
                            //ddlProduct.SelectedValue = dr["BarCode"].ToString();
                            //HiddenField2.Value = dr["BarCode"].ToString();
                            txtQuantity.Text = dr["Qty"].ToString();
                            txtRemarks.Text = dr["Remarks"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeptWise_Purchase_RequisitionList.aspx");
        }
    }
}