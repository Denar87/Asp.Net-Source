using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Collections;
using System.Drawing;

namespace ERPSSL.FA
{
    public partial class AssetUser : System.Web.UI.Page
    {

        //static string GlobalUserId = "";
        UserSetup_BLL userBll = new UserSetup_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegion();
                LoadUsers();
            }
        }
        //Grid
        private void LoadUsers()
        {

            grdUser.DataSource = userBll.GetAllUsers();
            grdUser.DataBind();
        }

        private void FillRegion()
        {
            ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            ddlRegion.DataValueField = "RegionCode";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }
        //ddl office
        private void FillOffice()
        {
            ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(ddlRegion.SelectedValue);
            ddlOffice.DataValueField = "OfficeCode";
            ddlOffice.DataTextField = "OfficeName";
            ddlOffice.DataBind();
            ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }
        //ddl department
        private void FillDepartments()
        {
            ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(ddlOffice.SelectedValue);
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOffice();
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDepartments();
        }

        protected void txtDepartmentName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            //ht.Add("UserId", GlobalUserId);
            ht.Add("Name", txtUserName.Text);
            ht.Add("DepartmentCode", ddlDepartment.SelectedValue);
            ht.Add("Designation", txtDesignation.Text);
            ht.Add("EmployeeId",Convert.ToString(txtEmployeeId.Text));
            ht.Add("Phone", txtPhone.Text);
            ht.Add("Email", txtEmail.Text);

            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
            ht.Add("SystemUserId", ((SessionUser)Session["SessionUser"]).UserId);
            bool status = userBll.SaveUser(ht);
            if (status == true)
            {
                lblMessage.Text = "Department Save Successfully";
                lblMessage.ForeColor = Color.Green;
                LoadUsers();
                Clear();
            }
            else
            {
                lblMessage.Text = "Error !Department Save";
                lblMessage.ForeColor = Color.Red;
            }
        }
        //paging

        protected void grdUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdUser.PageIndex = e.NewPageIndex;
                LoadUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Clear..
        private void Clear()
        {
            txtDesignation.Text = "";
            txtEmail.Text = "";
            txtEmployeeId.Text = "";
            txtPhone.Text = "";
            txtUserName.Text = "";
            ddlDepartment.ClearSelection();
            ddlOffice.ClearSelection();
            ddlRegion.ClearSelection();
        }

        protected void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {
            bool empResult;
            empResult=userBll.EmployeeIdExist(txtEmployeeId.Text);
            if (empResult == true)
            {
                Label1.Text = "Employee ID Is Already Exist";
                Label1.ForeColor = Color.Red;
            }
            else
            {
                Label1.Text = "";
            }
            
        }

    }
}