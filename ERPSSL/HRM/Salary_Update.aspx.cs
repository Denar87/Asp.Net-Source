using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using System.Data.SqlClient;
using ERPSSL.HRM.DAL;
using System.Drawing;

namespace ERPSSL
{
    public partial class Salary_Update : System.Web.UI.Page
    {
        SalaryUpdate_BLL salaryupdateBll = new SalaryUpdate_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    ShowDesignation();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        protected void txtEid_LV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_LV.Text);

                var result = salaryupdateBll.GetEmployeeID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    ShowDesignation();
                    Emp_IMG_TRNS.Visible = true;
                    Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    var objNewEmp = result.First();
                    txtEid_LV.Text = Convert.ToString(objNewEmp.EID);
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtEmpName.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    //txtDesignation.Text = objNewEmp.DEG_NAME;
                    DropDownList1.SelectedValue = objNewEmp.DesginationID.ToString();
                    //DropDownList1.SelectedValue = objNewEmp.DEG_NAME;
                    //txtDepartment.ReadOnly = true;
                    //txtDesignation.ReadOnly = true;
                    //txtEmpName.ReadOnly = true;
                    txtGrade.Text = objNewEmp.Grade;
                    //txtGrade.ReadOnly = true;
                    txtCurrent_Salary.Text = Convert.ToString(objNewEmp.salary);
                    //txtCurrent_Salary.ReadOnly = true;
                }
                else
                {
                    Emp_IMG_TRNS.Visible = false;
                    txtEmpName.Text = "";
                    txtDepartment.Text = "";
                    DropDownList1.ClearSelection();
                    txtGrade.Text = "";
                    txtCurrent_Salary.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void Hide()
        {
            txtbxFoodAllowance.ReadOnly = true;
            txtHouseRent.ReadOnly = true;
            txtMedical.ReadOnly = true;
            txtOther.ReadOnly = true;
            txtFixedAlo.ReadOnly = true;
            txtBasic.ReadOnly = true;
            txtConveynce.ReadOnly = true;

        }

        private void Clear()
        {
            txtBasic.Text = "";
            txtConveynce.Text = "";
            txtCurrent_Salary.Text = "";
            txtDepartment.Text = "";
            //txtDesignation.Text = "";
            DropDownList1.ClearSelection();
            txtGrossSalary.Text = "";
            txtEid_LV.Text = "";
            txtEmpName.Text = "";
            txtFixedAlo.Text = "";
            txtGrade.Text = "";
            txtbxFoodAllowance.Text = "";
            txtHouseRent.Text = "";
            txtMedical.Text = "";
            txtOther.Text = "";
            txtUpdate.Text = "";

        }


        protected void txtGrossSalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal gross_Salary = Convert.ToDecimal(txtGrossSalary.Text);

                //decimal medical = 200;

                //decimal withoutMedical = (gross_Salary - medical);

                //decimal houseRent = (withoutMedical * 44) / 100;

                //decimal Basic = (withoutMedical * 56) / 100;


                //txtMedical.Text = medical.ToString("0.00");
                //txtHouseRent.Text = decimal.Round(houseRent, 2, MidpointRounding.AwayFromZero).ToString();
                //txtBasic.Text = decimal.Round(Basic, 2, MidpointRounding.AwayFromZero).ToString();
                //txtConveynce.Text = Convert.ToString("0.00");
                //txtFixedAlo.Text = Convert.ToString("0.00");
                //txtHolidayAlo.Text = Convert.ToString("0.00");
                //txtOther.Text = Convert.ToString("0.00");

                //Salary Matrix Change Provide By Masum Vai ---------------------------------Kamruzzaman(30/3/16)
                double gross_Salary = Convert.ToDouble(txtGrossSalary.Text);
                double medical = 250;
                double taransport = 200;
                double food = 650;
                double withoutMedical = (gross_Salary - (medical + taransport + food));
                double Basic = (withoutMedical) / 1.4;
                double houseRent = (Basic * 40) / 100;


                txtMedical.Text = medical.ToString("0.00");
                txtHouseRent.Text = houseRent.ToString("0.00");//decimal.Round(houseRent, 2, MidpointRounding.AwayFromZero).ToString();
                txtBasic.Text = Basic.ToString("0.00");// decimal.Round(Basic, 2, MidpointRounding.AwayFromZero).ToString();
                txtConveynce.Text = taransport.ToString("0.00");// decimal.Round(taransport, 2, MidpointRounding.AwayFromZero).ToString();
                txtGrossSalary.Text = gross_Salary.ToString("0.00");
                txtbxFoodAllowance.Text = food.ToString("0.00");
                //  txtFoodAllowance.Text = food.ToString("0.00");//decimal.Round(food, 2, MidpointRounding.AwayFromZero).ToString();



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
                Increment_BLL objIncrementBll = new Increment_BLL();
                int DesginationId = Convert.ToInt16(DropDownList1.SelectedValue);
                string Grad = txtGrade.Text.Trim();
                decimal Gosssalary = Convert.ToDecimal(txtGrossSalary.Text.Trim());

                string DesginationName = DropDownList1.SelectedItem.ToString();
                bool Status = CheckDesignation(DesginationName, Grad, Gosssalary);

                if (Status == false)
                {

                    HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                    designationObj.DEG_NAME = DropDownList1.SelectedItem.ToString();
                    designationObj.GRADE = txtGrade.Text;
                    designationObj.GROSS_SAL = Gosssalary;
                    designationObj.HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                    designationObj.BASIC = Convert.ToDecimal(txtBasic.Text);
                    designationObj.MEDICAL = Convert.ToDecimal(txtMedical.Text);
                    designationObj.FOOD_ALLOW = Convert.ToDecimal(txtbxFoodAllowance.Text);
                    designationObj.CONVEYANCE = Convert.ToDecimal(txtConveynce.Text);
                    designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    designationObj.EDIT_DATE = DateTime.Now;
                    designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = objDeg_BLL.InsertDeignation(designationObj);

                }

                HRM_DESIGNATIONS _Desobj = objDeg_BLL.GetDesignationId(DesginationName, Grad, Gosssalary);
                if (_Desobj != null)
                {

                    int desId = _Desobj.DEG_ID;
                    string eid = txtEid_LV.Text;
                    int result = objDeg_BLL.UpdatePersonalInfoForSalaryUpdate(eid, desId, Gosssalary);
                    if (result == 1)
                    {
                        HRM_SalaryUpdate objEmp = new HRM_SalaryUpdate();
                        objEmp.EID = eid;
                        objEmp.CurrendSalary = Gosssalary;
                        objEmp.DegID = DesginationId;
                        objEmp.Grade = Grad;
                        objEmp.EDIT_DATE = DateTime.Now;
                        objEmp.Previoussalary = Convert.ToDecimal(txtCurrent_Salary.Text);
                        objEmp.EDIT_DATE = DateTime.Now;
                        objEmp.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        int resultstatus = objIncrementBll.SalaryUpdate(objEmp);
                        if (resultstatus == 1)
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Salary Update successfully!')", true);
                        }
                    }
                }
                UIClear();
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void UIClear()
        {
            try
            {

                txtEid_LV.Text = "";
                txtEmpName.Text = "";
                txtGrade.Text = "";
                txtDepartment.Text = "";
                DropDownList1.ClearSelection();
                txtCurrent_Salary.Text = "";
                txtBasic.Text = "";
                txtHouseRent.Text = "";
                txtMedical.Text = "";
                txtConveynce.Text = "";
                txtFixedAlo.Text = "";
                txtbxFoodAllowance.Text = "";
                txtOther.Text = "";
                Emp_IMG_TRNS = null;
                txtGrossSalary.Text = "";



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool CheckDesignation(string Desgination, string Grad, decimal Gosssalary)
        {
            bool Status = false;
            try
            {
                Status = salaryupdateBll.CheckDesignation(Desgination, Grad, Gosssalary);
                return Status;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            return Status;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void ShowDesignation()
        {

            try
            {
                var row = salaryupdateBll.GetAllDesignation().ToList();
                if (row.Count > 0)
                {

                    DropDownList1.DataSource = row.ToList();
                    DropDownList1.DataTextField = "DEG_NAME";
                    DropDownList1.DataValueField = "DEG_ID";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {


            }

        }
    }
}