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
    public partial class EmployeeType : System.Web.UI.Page
    {
        EmployeeTypeBLL employTypeObj = new EmployeeTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getEmployeeType();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getEmployeeType()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_EmployeeType> employeeTypes = employTypeObj.GetEmployeeType(Ocode);
                if (employeeTypes.Count > 0)
                {
                    gridviewEmployeeType.DataSource = employeeTypes;
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
                HRM_EmployeeType employeeTypeObj = new HRM_EmployeeType();
                employeeTypeObj.EmployeeTypeName = txtbxEmployeeType.Text;
                employeeTypeObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                employeeTypeObj.EDIT_DATE = DateTime.Now;
                employeeTypeObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnEmployeeTypeSubmit.Text == "Submit")
                {

                    int result = employTypeObj.InsertEmployeeType(employeeTypeObj);
                    if (result == 1)
                    {
                        //  lblMessage.Text = "Data Save successfully!";
                        //   lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }

                }
                else
                {
                    int leaveTypeId = Convert.ToInt32(hidEmployeeTypeId.Value);
                    int result = employTypeObj.UpdateEmployeeType(employeeTypeObj, leaveTypeId);
                    if (result == 1)
                    {
                        //  lblMessage.Text = "Data Update successfully!";
                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    }

                }
                getEmployeeType();
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
                txtbxEmployeeType.Text = "";
                btnEmployeeTypeSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnEmployeeTypeEdit_Click(object sender, EventArgs e)
        {
            List<HRM_EmployeeType> LeaveTypes = new List<HRM_EmployeeType>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string employeeTypeId = "";
                Label lblEmployeeTypeId = (Label)gridviewEmployeeType.Rows[row.RowIndex].FindControl("lblEmployTypeId");
                if (lblEmployeeTypeId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    employeeTypeId = lblEmployeeTypeId.Text;
                    LeaveTypes = employTypeObj.GeEmployeeTypes(employeeTypeId, OCODE);

                    if (LeaveTypes.Count > 0)
                    {
                        foreach (HRM_EmployeeType employeeType in LeaveTypes)
                        {
                            hidEmployeeTypeId.Value = employeeType.EmployeeTypeId.ToString();
                            txtbxEmployeeType.Text = employeeType.EmployeeTypeName.ToString();


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
            getEmployeeType();
        }
    }
}