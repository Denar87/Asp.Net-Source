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
using ERPSSL.INV.DAL;
using ERPSSL.Procurement.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.BLL;

namespace ERPSSL.Requisition
{
    public partial class AssignEmployeeSupervisor : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        ProductBLL productBll = new ProductBLL();
        Office_BLL officeBll = new Office_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeList();
                LoadEmployeeList1();
                LoadEmployeeList2();
                FillDepartment();
                GetEmployeeInfo();
                FillDepartmentByOffice();
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
                        //txtEID.Text = ((SessionUser)Session["SessionUser"]).EID;
                        //txtDesignation.Text = assign.DeginationName.ToString();
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
                        //txtDepartment.Text = assign.DepartmentName.ToString();
                        //hdnDEPT_CODE.Value = assign.DPT_CODE;
                        //ddlDepartment.SelectedItem.Text = assign.DepartmentName.ToString();
                        //ddlDepartment.SelectedValue = assign.DPT_CODE.ToString();
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
            ddlDepartment.DataSource = officeBll.GetDepartmentByOffice(int.Parse(hdnOfficeID.Value), OCODE);
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        }

        private void FillDepartment()
        {
            ddlDepartment.DataSource = ic.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
            }
            catch { }
        }

        private void LoadEmployeeList(string DeptCode)
        {
            ddlEmployee.DataSource = ic.GetEmployeeList(DeptCode);
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void LoadEmployeeList()
        {
            ddlSupervisorEID.DataSource = ic.GetAllEmployeeList();
            ddlSupervisorEID.DataValueField = "EID";
            ddlSupervisorEID.DataTextField = "EMP_NAME";
            ddlSupervisorEID.DataBind();
            ddlSupervisorEID.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void LoadEmployeeList1()
        {
            ddlSupervisor2EID.DataSource = ic.GetAllEmployeeList();
            ddlSupervisor2EID.DataValueField = "EID";
            ddlSupervisor2EID.DataTextField = "EMP_NAME";
            ddlSupervisor2EID.DataBind();
            ddlSupervisor2EID.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void LoadEmployeeList2()
        {
            ddlSupervisor3EID.DataSource = ic.GetAllEmployeeList();
            ddlSupervisor3EID.DataValueField = "EID";
            ddlSupervisor3EID.DataTextField = "EMP_NAME";
            ddlSupervisor3EID.DataBind();
            ddlSupervisor3EID.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRQ_Requisitions aPRQ_Requisitions = new PRQ_Requisitions();

                var result = aRequisionBll.GetRequisitionInfo(txtEID.Text);
                if (result.Count > 0)
                {
                    var objRequisitionInfo = result.First();
                    aPRQ_Requisitions.Old_Supervisor_EID = objRequisitionInfo.Supervisor_EID;
                }

                aPRQ_Requisitions.Supervisor_EID = ddlSupervisorEID.SelectedValue;

                aRequisionBll.UpdateSupervisor(aPRQ_Requisitions, txtEID.Text);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Supervisor updated successfully for this employee')", true);
                //lblMessage.Text = "Supervisor updated successfully for this employee.";
                ClearForm();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Supervisor updating failed!')", true);
                //lblMessage.Text = "<font color='red'>Supervisor update failed!</font>";
            }
        }

        private void ClearForm()
        {
            ddlDepartment.ClearSelection();
            ddlEmployee.Items.Clear();
            txtEID.Text = "";
            //txtSupervisorEID.Text = "";
            ddlSupervisorEID.ClearSelection();
        }

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                if (txtEID.Text.Trim() != "")
                {
                    DataTable dt = ic.FindEmployee(txtEID.Text.Trim());
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                        LoadEmployeeList(dr["DPT_CODE"].ToString());
                        ddlEmployee.SelectedValue = txtEID.Text.Trim();
                    }
                }
            }
            catch { }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtEID.Text = ddlEmployee.SelectedValue.ToString();
        }

        protected void ddlSupervisorEID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtSupervisorEID.Text = ddlSupervisorEID.SelectedValue.ToString();
        }

        //protected void txtSupervisorEID_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtSupervisorEID.Text.Trim() != "")
        //        {
        //            DataTable dt = ic.FindEmployee(txtSupervisorEID.Text.Trim());
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                //ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
        //                //LoadEmployeeList(dr["DPT_CODE"].ToString());
        //                ddlSupervisorEID.SelectedValue = txtSupervisorEID.Text.Trim();
        //            }
        //        }
        //    }
        //    catch { }
        //}

    }
}