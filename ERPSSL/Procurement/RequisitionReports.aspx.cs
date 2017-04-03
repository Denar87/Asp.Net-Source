using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Collections;
using ERPSSL.Procurement.BLL;

namespace ERPSSL.Procurement
{
    public partial class RequisitionReports : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCompany();
                FillDepartment();
                FillProductGroup();
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = false;
            }
        }

        public void FillProductGroup()
        {
            ddlItemGroup.DataSource = groupBll.GetAllGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("Select One", "0"));

        }
        public void FillCompany()
        {

            ddlCompany.DataSource = ic.GetCompanyList();
            ddlCompany.DataValueField = "CompanyCode";
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select One", "0"));
        }

        public void FillDepartment()
        {

            ddlDepartment.DataSource = ic.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));

        }
        private void LoadEmployeeList(string DeptCode)
        {
            ddlEmployee.DataSource = ic.GetEmployeeList(DeptCode);
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("Select One", "0"));
        }
        public void FillProductName()
        {

            if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
            {
                ddlItemName.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlItemGroup.SelectedValue));
                ddlItemName.DataValueField = "ProductId";
                ddlItemName.DataTextField = "ProductName";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, new ListItem("Select One", "0"));
            }

        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployeeList(ddlDepartment.SelectedValue);
            ddlEmployee.Enabled = true;
        }

        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductName();
            ddlItemName.Enabled = true;

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = RadioButtonList1.SelectedValue;
            if (RadioButtonList1.SelectedValue == "AllRequisitions")
            {
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = false;
            }
            else if (RadioButtonList1.SelectedValue == "FromSpecificCompany")
            {
                ddlCompany.Enabled = true;
                ddlDepartment.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = false;
            }
            else if (RadioButtonList1.SelectedValue == "FromSpecificDepartment")
            {
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = true;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = false;
            }
            else if (RadioButtonList1.SelectedValue == "FromSpecificEmployee")
            {
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = true;
                ddlEmployee.Enabled = true;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = false;
            }
            else if (RadioButtonList1.SelectedValue == "BySpecificProductGroup")
            {
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = true;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = false;
            }
            else if (RadioButtonList1.SelectedValue == "BySpecificProduct")
            {
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = true;
                ddlItemName.Enabled = true;
                txtRequisitionNo.Enabled = false;
            }
            else if (RadioButtonList1.SelectedValue == "ByRequisitionNumber")
            {
                ddlCompany.Enabled = false;
                ddlDepartment.Enabled = false;
                ddlEmployee.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                txtRequisitionNo.Enabled = true;
            }
            else
            {
                //ddlSupplier.Enabled = false;
                //txtChallanNo.Enabled = false;
                //ddlSupplier.Items.Clear();
            }

        }
        private void BindReport(DataTable dataSource, string typ)
        {
            ReportViewer1.LocalReport.DataSources.Clear();

            if (typ == "AllRequisitions")
            {
                ReportDataSource reportDataset = new ReportDataSource("Requisition_RPT_DS", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllRequisition_RPT.rdlc");
            }
            else if (typ == "FromSpecificCompany")
            {
                ReportDataSource reportDataset = new ReportDataSource("RequisitionsGroupByReqNo", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RequisitionGroupByReqNo.rdlc");
            }
            else if (typ == "FromSpecificDepartment")
            {
                ReportDataSource reportDataset = new ReportDataSource("RequisitionsGroupByReqNo", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RequisitionGroupByReqNo.rdlc");
            }
            else if (typ == "FromSpecificEmployee")
            {
                ReportDataSource reportDataset = new ReportDataSource("RequisitionsGroupByReqNo", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RequisitionGroupByReqNo.rdlc");
            }
            else if (typ == "BySpecificProductGroup")
            {
                ReportDataSource reportDataset = new ReportDataSource("Requisition_RPT_DS", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllRequisition_RPT.rdlc");
            }
            else if (typ == "BySpecificProduct")
            {
                ReportDataSource reportDataset = new ReportDataSource("Requisition_RPT_DS", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllRequisition_RPT.rdlc");
            }
            else if (typ == "ByRequisitionNumber")
            {
                ReportDataSource reportDataset = new ReportDataSource("RequisitionsGroupByReqNo", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RequisitionGroupByReqNo.rdlc");
            }

            ReportViewer1.LocalReport.Refresh();

        }
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string type = RadioButtonList1.SelectedValue;
                Hashtable ht = new Hashtable();
                ht.Add("Type", RadioButtonList1.SelectedValue);
                ht.Add("DateFrom", txtFromDate.Text);
                ht.Add("DateTo", txtFromDate.Text);
                ht.Add("CompanyCode", ddlCompany.SelectedValue);
                ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                ht.Add("EID", ddlEmployee.SelectedValue);
                ht.Add("ProductGroupId", ddlItemGroup.SelectedValue);
                ht.Add("ProductId", ddlItemName.SelectedValue);
                ht.Add("ReqNo", txtRequisitionNo.Text);
                DataTable dt = new DataTable();
                dt = PRQReports.GetRequisitionReportData(ht);
                BindReport(dt, type);
            }
            catch
            {

            }
        }
         
      
    }
}