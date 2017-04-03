using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class EmployeeCategory : System.Web.UI.Page
    {
        //EmployeeTypeBLL employTypeObj = new EmployeeTypeBLL();
        EmployeeCategoryBLL emplobyeeCategoryBll = new EmployeeCategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getEmployeeCategoryes();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getEmployeeCategoryes()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_EmployeeCategory> EmployeeCategoryes = emplobyeeCategoryBll.getEmployeeCategoryes(Ocode);
                if (EmployeeCategoryes.Count > 0)
                {
                    gridviewEmployeeType.DataSource = EmployeeCategoryes;
                    gridviewEmployeeType.DataBind();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void btnEmployeeTypeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_EmployeeCategory employeeTypeObj = new HRM_EmployeeCategory();
                employeeTypeObj.EmployeeTypeName = txtbxCategoryName.Text;
                employeeTypeObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                employeeTypeObj.EDIT_DATE = DateTime.Now;
                employeeTypeObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnEmployeeTypeSubmit.Text == "Submit")
                {

                    int result = emplobyeeCategoryBll.InsertEmployeeCategory(employeeTypeObj);
                    if (result == 1)
                    {
                        //  lblMessage.Text = "Data Save successfully!";
                        // lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }

                }
                else
                {
                    int leaveTypeId = Convert.ToInt32(hidEmployeeTypeId.Value);
                    int result = emplobyeeCategoryBll.UpdateEmployeeCategory(employeeTypeObj, leaveTypeId);
                    if (result == 1)
                    {
                        //    lblMessage.Text = "Data Update successfully!";
                        //    lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    }

                }
                getEmployeeCategoryes();
                ClearAllControll();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControll()
        {
            try
            {
                txtbxCategoryName.Text = "";
                btnEmployeeTypeSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnEmployeeTypeEdit_Click(object sender, EventArgs e)
        {
            List<HRM_EmployeeCategory> LeaveTypes = new List<HRM_EmployeeCategory>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string employeeTypeId = "";
                Label lblEmployeeTypeId = (Label)gridviewEmployeeType.Rows[row.RowIndex].FindControl("lblEmployeeCategory");
                if (lblEmployeeTypeId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    employeeTypeId = lblEmployeeTypeId.Text;
                    LeaveTypes = emplobyeeCategoryBll.GeEmployeeCategoroyesById(employeeTypeId, OCODE);

                    if (LeaveTypes.Count > 0)
                    {
                        foreach (HRM_EmployeeCategory employeeCategoryes in LeaveTypes)
                        {
                            hidEmployeeTypeId.Value = employeeCategoryes.EmployeeCategory.ToString();
                            txtbxCategoryName.Text = employeeCategoryes.EmployeeTypeName.ToString();


                        }
                        if (btnEmployeeTypeSubmit.Text == "Submit")
                        {
                            btnEmployeeTypeSubmit.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewEmployeeType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewEmployeeType.PageIndex = e.NewPageIndex;
            getEmployeeCategoryes();
        }
    }
}