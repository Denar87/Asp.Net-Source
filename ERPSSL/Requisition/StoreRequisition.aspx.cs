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
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.INV.DAL;
using HRM_PersonalInformations = ERPSSL.HRM.DAL.HRM_PersonalInformations;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class StoreRequisition : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        ProductBLL productBll = new ProductBLL();
        RChallanBLL rChallanBll = new RChallanBLL();
        Office_BLL officeBll = new Office_BLL();
        RequisionBll aRequisionBll = new RequisionBll();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                   // FillStyle();
                    GetEmployeeInfo();
                    FillProductGroup();
                    FillDepartmentByOffice();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        //public void FillStyle()
        //{
        //    ddlProgram.DataSource = ic.GetListProgram();
        //    ddlProgram.DataValueField = "ProgramID";
        //    ddlProgram.DataTextField = "ProgramName";
        //    ddlProgram.DataBind();
        //    ddlProgram.Items.Insert(0, new ListItem("--Select Program--", "0"));  //Style is use as program for SME-F
        //}

        private void LoadEmployeeList()
        {
            ddlEmployee.DataSource = ic.GetEmployeeList();
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
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

                    List<AssignTo> assignTos = new List<AssignTo>();
                    assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                    foreach (AssignTo assign in assignTos)
                    {
                        txtEID.Text = ((SessionUser)Session["SessionUser"]).EID;
                        txtDesignation.Text = assign.DeginationName.ToString();
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
                        ddlDepartment.SelectedValue = assign.DPT_CODE.ToString();
                    }
                    List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    foreach (HRM_PersonalInformations aperson in personanlInfo)
                    {
                        LoadEmployeeList();
                        ddlEmployee.SelectedValue = aperson.EID;
                        hidReportingBossID.Value = aperson.ReportingBossId;
                    }
                }
            }

            catch
            {
            }
        }

        private void FillDepartmentByOffice()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            var row = officeBll.GetDepartmentByOffice(int.Parse(hdnOfficeID.Value), OCODE);
            ddlDepartment.DataSource = row;
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

        //private void BindRequisitionNo()
        //{
        //    if (ddlDepartment.SelectedValue != "0" && txtDate.Text != "")
        //    {
        //        try
        //        {
        //            DateTime date;
        //            try
        //            {
        //                date = DateTime.Parse(txtDate.Text);
        //            }
        //            catch
        //            {
        //                date = DateTime.Today;
        //            }

        //            txtRequisitionNo.Text = ic.GetNewRequisitionNo("DPT", "", ddlDepartment.SelectedValue, ddlEmployee.SelectedValue, date);
        //        }
        //        catch { }
        //    }
        //}

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

        //protected void txtDate_TextChanged(object sender, EventArgs e)
        //{
        //    BindRequisitionNo();
        //}

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;
                string pronductNameandBrand = ddlProduct.SelectedItem.ToString();
                string[] values = pronductNameandBrand.Split('-');

                string EID = txtEID.Text;
                string Barocode = ddlProduct.SelectedValue;

                string BarCode = ddlProduct.SelectedValue;
                string Quantity = txtQuantity.Text;
                string ReqDate = txtDate.Text;

                if (BarCode == "" || Quantity == "" || ReqDate == "" || ddlDepartment.SelectedValue == "0" || ddlEmployee.SelectedValue == "0")
                {
                    return;
                }


                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string barCode = ddlProduct.SelectedValue.ToString();
                var result1 = productBll.GetProductById(Convert.ToInt32(ddlProduct.SelectedValue));
                double inputBalance = Convert.ToDouble(txtQuantity.Text);
                var details = productBll.GetProductBalanceByIdForReq(Convert.ToInt32(ddlProduct.SelectedValue));
                var details2 = productBll.GetProductBalanceForRequisition(Convert.ToInt32(ddlProduct.SelectedValue));
                double? reqQty = 0;
                double? balanceqty = 0;
                if (details2 != null)
                {
                    reqQty = details2.PrqBalanceQuanity;
                }
                else
                {
                    reqQty = 0;
                }
                if (details != null)
                {
                    balanceqty = details.BalanceQuanity;
                }
                else
                {
                    balanceqty = 0;
                }


                if (reqQty + inputBalance > balanceqty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Stock Not Available!')", true);
                    return;

                }

                if (int.Parse(txtQuantity.Text) <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition quantity cannot be zero or negative!')", true);
                    //lblMessage.Text = "<font color='red'>Sorry! Invalid data. Requisition quantity cannot be zero or negative. Please enter correct data</font>";
                    return;
                }
                if (BtnSave.Text == "Add")
                {

                    Hashtable ht = new Hashtable();
                    //ht.Add("ReqNo", txtRequisitionNo.Text);
                    ht.Add("ReqType", "Store");
                    ht.Add("CompanyCode", "");
                    ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                    //ht.Add("DPT_CODE", hdnDEPT_CODE.Value);
                    ht.Add("EID", ddlEmployee.SelectedValue);
                    //ht.Add("EID", txtEID.Text);
                    ht.Add("GroupId", ddlProductGroup.SelectedValue);
                    ht.Add("BarCode", ddlProduct.SelectedValue);
                    ht.Add("Qty", txtQuantity.Text);
                    ht.Add("ReqDate", txtDate.Text);
                    ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                    ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                    ht.Add("RecomendBy", "");
                   // ht.Add("Program", ddlProgram.SelectedValue);
                    ht.Add("Reason_Justification", "");
                    ht.Add("RequisitionFor", txtRequisitionFor.Text);
                    ht.Add("Location", txtLocation.Text);

                    ht.Add("Remarks", txtRemarks.Text);
                    ht.Add("Supervisor_EID", hidReportingBossID.Value);
                    ht.Add("EditUser", ((SessionUser)Session["SessionUser"]).UserId.ToString());
                    ht.Add("EditDate", DateTime.Now);

                    PRQ_Requisition_Temp reqItem = aRequisionBll.GetReq_temp_ItemByProductInfo(txtEID.Text, Convert.ToInt16(ddlProduct.SelectedValue), userId);
                    if (reqItem != null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item already in the list!')", true);
                        return;
                    }



                    if (RequisionBll.PRQ_AddStoreRequisitionTemp(ht))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition for this item added successfully')", true);
                        //lblMessage.Text = "<font color='green'>Requisition for this item added successfully!</font>";
                        //Load_Requisitions(txtRequisitionNo.Text);
                        LoadRequisitions(txtEID.Text);

                        ClearForm();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in adding requisition!')", true);
                        //lblMessage.Text = "<font color='red'>Error in adding requisition! Please try again</font>";
                    }
                }
                if (BtnSave.Text == "Update")
                {
                    DataTable dt = new DataTable();
                    //string ReqNo = txtRequisitionNo.Text;
                    // string Barocde =ddlProduct.SelectedValue;
                    dt = RequisionBll.GetBarCode(EID, BarCode);
                    if (dt.Rows.Count > 0)
                    {
                        Hashtable ht = new Hashtable();
                        //ht.Add("ReqNo", txtRequisitionNo.Text);
                        ht.Add("ReqType", "Store");
                        ht.Add("CompanyCode", "");
                        ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                        //ht.Add("DPT_CODE", hdnDEPT_CODE.Value);
                        ht.Add("EID", ddlEmployee.SelectedValue);
                        //ht.Add("EID", txtEID.Text);
                        //if (ddlProduct.SelectedValue == "")
                        //{

                        //    ht.Add("BarCode", HiddenField2.Value);
                        //}
                        //else
                        //{
                        ht.Add("BarCode", BarCode);
                        //}


                        //if (txtQuantity.Text == "")
                        //{

                        //    ht.Add("Qty", HiddenField1.Value);
                        //}
                        //else
                        //{

                        ht.Add("Qty", txtQuantity.Text);
                        //}

                        ht.Add("ReqDate", txtDate.Text);
                        ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                        ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                        ht.Add("RecomendBy", "");
                        ht.Add("RequisitionFor", txtRequisitionFor.Text);
                        ht.Add("Location", txtLocation.Text);
                        ht.Add("Remarks", txtRemarks.Text);
                        ht.Add("Supervisor_EID", hidReportingBossID.Value);
                       // ht.Add("Program", ddlProgram.SelectedValue);


                        bool result = RequisionBll.updateStoreRequisitions(ht);
                        if (result == false)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition for this item updated successfully')", true);
                            //Load_Requisitions(txtRequisitionNo.Text);
                            LoadRequisitions(txtEID.Text);
                            ClearForm();
                            BtnSave.Text = "Add";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in adding requisition!')", true);
                            //lblMessage.Text = "<font color='red'>Error in adding requisition! Please try again</font>";
                        }
                    }
                }
            }

            catch { }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            if (grdRequisition.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No item selected for requisition!')", true);
                return;
            }
            BindRequisitionNo();
            //if (RequisionBll.AddStore_Requisition(ht))
            RequisionBll aReqBll = new RequisionBll();
            var result = aReqBll.AddTempToStoreReq(txtRequisitionNo.Text.ToString());
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition added successfully')", true);
                //lblMessage.Text = "<font color='green'>Requisition for this item added successfully!</font>";
                //LoadRequisitions(txtRequisitionNo.Text);
                ClearFullForm();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in adding requisition!')", true);
                //lblMessage.Text = "<font color='red'>Error in adding requisition! Please try again</font>";
            }
        }

        private void ClearForm()
        {
            ddlProductGroup.ClearSelection();
            ddlProduct.Items.Clear();
            //txtExpectedDate.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtRemarks.Text = "";
            //txtBrand.Text = string.Empty;
            //hidReportingBossID.Value = "";
        }

        private void ClearFullForm()
        {
            ddlProductGroup.ClearSelection();
            ddlProduct.Items.Clear();
            txtExpectedDate.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtRemarks.Text = "";
            txtDate.Text = DateTime.Today.ToShortDateString();
            //hidReportingBossID.Value = "";
            txtUnit.Text = "";
            txtRequisitionFor.Text = "";
            txtLocation.Text = "";
            //txtRequisitionNo.Text = "";
            grdRequisition.DataSource = null;
            grdRequisition.DataBind();
        }

        private void LoadRequisitions(string EID)
        {
            Guid userId = ((SessionUser)Session["SessionUser"]).UserId;
            grdRequisition.DataSource = RequisionBll.GetStoreRequisition(userId, EID, "DPT");
            grdRequisition.DataBind();
        }

        private void Load_Requisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.Get_Store_Requisition(ReqNo, "DPT");
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
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string barCode = ddlProduct.SelectedValue.ToString();
            var result = productBll.GetProductById(Convert.ToInt32(ddlProduct.SelectedValue));
            List<Inv_BuyCentral> center = productBll.GetProductBalance(Convert.ToInt32(ddlProduct.SelectedValue)).ToList();

            var details = productBll.GetProductBalanceById(Convert.ToInt32(ddlProduct.SelectedValue));

            if (center.Count > 0)
            {
                var objects = center.First();
                if (details.BalanceQuanity <= 0)
                {
                    txtQuantity.Text = "";
                    txtQuantity.Enabled = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Stock Not Available!')", true);
                }
                else
                {
                    txtQuantity.Enabled = true;
                }
            }
            else
            {
                txtQuantity.Text = "";
                txtQuantity.Enabled = false;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Stock Not Available!')", true);

            }
            if (result.Count > 0)
            {
                var objProduct = result.First();
                txtUnit.Text = objProduct.UnitName;
            }

        }

        protected void grdRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "dlt")
                {
                    ic.DeleteRequisitionTempById(id);
                    LoadRequisitions(txtEID.Text);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition item deleted successfully')", true);
                }
                if (e.CommandName == "edt")
                {
                    {
                        DataTable dt = new DataTable();
                        dt = ic.GetDataEditRequisition(id);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ddlProductGroup.SelectedValue = dr["GroupId"].ToString();
                                FillProductName();
                                ddlProduct.SelectedValue = dr["BarCode"].ToString();
                                txtUnit.Text = dr["UnitName"].ToString();
                                //ddlProduct.SelectedValue = dr["BarCode"].ToString();
                                //HiddenField2.Value = dr["BarCode"].ToString();
                                txtQuantity.Text = dr["Qty"].ToString();
                                txtRemarks.Text = dr["Remarks"].ToString();
                                BtnSave.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch { }
        }

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtEID.Text.Trim() != "")
                {
                    HRM_PersonalInformations _personalInfo = employeeBll.GetPersonalInfoByEID(txtEID.Text);
                    DataTable dt = ic.FindEmployee(txtEID.Text.Trim());
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                        txtDesignation.Text = employeeBll.GetDesginationName(_personalInfo.DesginationId);
                        LoadEmployeeList(dr["DPT_CODE"].ToString());
                        ddlEmployee.SelectedValue = txtEID.Text.Trim();
                        hidReportingBossID.Value = dr["ReportingBossId"].ToString();
                    }
                }
            }
            catch { }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ic.GetEmployeeDesignation(ddlEmployee.SelectedValue.ToString());
            txtDesignation.Text = dt.Rows[0][0].ToString();
            txtEID.Text = ddlEmployee.SelectedValue.ToString();
            //hidReportingBossID.Value = dt.Rows[0][0].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                hidReportingBossID.Value = dr["ReportingBossId"].ToString();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string ReqNo = txtRequisitionNo.Text;
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DataTable dataSource = rChallanBll.GetStoreRequisitionRPT(ReqNo, Ocode);
            ReportViewerPurchase.LocalReport.DataSources.Clear();
            ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
            ReportViewerPurchase.LocalReport.DataSources.Add(reportDataset);
            ReportViewerPurchase.LocalReport.ReportPath = Server.MapPath("Reports/StoreRequisition.rdlc");
            ReportViewerPurchase.LocalReport.Refresh();
        }

    }
}