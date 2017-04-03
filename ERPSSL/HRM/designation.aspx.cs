using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class designation : System.Web.UI.Page
    {
        DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getDesignations();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void getDesignations()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objDeg_BLL.GetAllDesignation(OCODE).ToList();
                if (row.Count > 0)
                {
                    gridviewDesignation.DataSource = row.ToList();
                    gridviewDesignation.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //protected void btnDesignationSubmit_Clik(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtbxDesignation.Text == "")
        //        {
        //            lblMessage.Text = "Please Input Designation!";
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //        }

        //        else
        //        {
        //            HRM_DESIGNATIONS objDeg = new HRM_DESIGNATIONS();                   
        //            objDeg.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
        //            objDeg.EDIT_DATE = DateTime.Now;                   
        //            objDeg.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //            objDeg.DEG_NAME = txtbxDesignation.Text;


        //            if (btnDesignationSubmit.Text == "Submit")
        //            {
        //                int result = objDeg_BLL.InsertDeignation(objDeg);
        //                if (result == 1)
        //                {
        //                    lblMessage.Text = "Data Save successfully!";
        //                    lblMessage.ForeColor = System.Drawing.Color.Green;
        //                }
        //            }
        //            else
        //            {
        //                int desginationId = Convert.ToInt32(hidDesignationId.Value);
        //                int result = objDeg_BLL.UpdateDesignation(objDeg, desginationId);
        //                if (result == 1)
        //                {
        //                    lblMessage.Text = "Data Update successfully!";
        //                    lblMessage.ForeColor = System.Drawing.Color.Green;
        //                }
        //            }
        //            getDesignations();
        //            ClearDesignationUi();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        private void ClearDesignationUi()
        {
            try
            {
                txtbxDesignation.Text = "";
                hidDesignationId.Value = "";
                txtbxDesignation.Text = "";
                txtBasic.Text = "";
                txtFoodAllowance.Text = "";
                txtbxGrade.Text = "";
                txtHouseRent.Text = "";
                txtMedical.Text = "";
                txtGrsSal.Text = "";
                txtConveyance.Text = "";
                btnSave.Text = "Save";


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //Logic Change Provide By Masum Vai ---------------------------------Kamruzzaman(30/3/16)
                double gross_Salary = Convert.ToDouble(txtGrsSal.Text);
                double medical = 250;
                double taransport = 200;
                double food = 650;
                double withoutMedical = (gross_Salary - (medical + taransport + food));
                double Basic = (withoutMedical) / 1.4;
                double houseRent = (Basic * 40) / 100;


                txtMedical.Text = medical.ToString("0.00");
                txtHouseRent.Text = houseRent.ToString("0.00");//decimal.Round(houseRent, 2, MidpointRounding.AwayFromZero).ToString();
                txtBasic.Text = Basic.ToString("0.00");// decimal.Round(Basic, 2, MidpointRounding.AwayFromZero).ToString();
                txtConveyance.Text = taransport.ToString("0.00");// decimal.Round(taransport, 2, MidpointRounding.AwayFromZero).ToString();
                txtFoodAllowance.Text = food.ToString("0.00");//decimal.Round(food, 2, MidpointRounding.AwayFromZero).ToString();
                txtGrsSal.Text = gross_Salary.ToString("0.00");
                //decimal conveyance = 200;
                //decimal FoodAll = 650;

                //decimal totalMCF = GROSS_SAL - (medical + conveyance + FoodAll);
                //decimal Rvalue = Convert.ToDecimal(1.4);
                //decimal basic = totalMCF / Rvalue;
                //txtBasic.Text = decimal.Round(basic, 2, MidpointRounding.AwayFromZero).ToString();

                //decimal houseRent = (basic * 40) / 100;
                //txtHouseRent.Text = decimal.Round(houseRent, 2, MidpointRounding.AwayFromZero).ToString();

                //txtMedical.Text = medical.ToString("0.00");
                //txtConveyance.Text = conveyance.ToString("0.00");
                //txtFoodAllowance.Text = FoodAll.ToString("0.00");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewDesignation.PageIndex = e.NewPageIndex;
            getDesignations();

        }
        protected void imgbtnDepartmentEdit_Click(object sender, EventArgs e)
        {
            List<HRM_DESIGNATIONS> designations = new List<HRM_DESIGNATIONS>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string deginationId = "";
                Label lblDesginationId = (Label)gridviewDesignation.Rows[row.RowIndex].FindControl("lblDesignationId");
                if (lblDesginationId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    deginationId = lblDesginationId.Text;
                    designations = objDeg_BLL.GetaDesignationByIdandOcode(deginationId, OCODE);

                    if (designations.Count > 0)
                    {
                        foreach (HRM_DESIGNATIONS adesignation in designations)
                        {
                            hidDesignationId.Value = adesignation.DEG_ID.ToString();
                            txtbxDesignation.Text = adesignation.DEG_NAME;
                            txtBasic.Text = adesignation.BASIC.ToString();
                            txtFoodAllowance.Text = adesignation.FOOD_ALLOW.ToString();
                            txtbxGrade.Text = adesignation.GRADE.ToString();
                            txtHouseRent.Text = adesignation.HOUSE_RENT.ToString();
                            txtMedical.Text = adesignation.MEDICAL.ToString();
                            txtGrsSal.Text = adesignation.GROSS_SAL.ToString();
                            txtConveyance.Text = adesignation.CONVEYANCE.ToString();

                        }
                        if (btnSave.Text == "Save")
                        {
                            btnSave.Text = "Update";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        // FoodAllowance is  Fixed Allowance
        // Other is Alltendance Bouns
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);
                decimal HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                decimal BASIC = Convert.ToDecimal(txtBasic.Text);
                decimal MEDICAL = Convert.ToDecimal(txtMedical.Text);
                decimal Convenc = Convert.ToDecimal(txtConveyance.Text);
                decimal FOOD_ALLOW = Convert.ToDecimal(txtFoodAllowance.Text);
                decimal TOTAL = (BASIC + HOUSE_RENT + MEDICAL + Convenc + FOOD_ALLOW);

                if (GROSS_SAL == TOTAL)
                {
                    HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();

                    designationObj.DEG_NAME = txtbxDesignation.Text;
                    designationObj.GRADE = txtbxGrade.Text;
                    designationObj.GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);
                    designationObj.HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                    designationObj.BASIC = Convert.ToDecimal(txtBasic.Text);
                    designationObj.MEDICAL = Convert.ToDecimal(txtMedical.Text);
                    designationObj.FOOD_ALLOW = Convert.ToDecimal(txtFoodAllowance.Text);
                    designationObj.CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                    designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    designationObj.EDIT_DATE = DateTime.Now;
                    designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    if (btnSave.Text == "Save")
                    {
                        int result = objDeg_BLL.InsertDeignation(designationObj);
                        if (result == 1)
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                        }

                    }
                    else
                    {
                        int desginationId = Convert.ToInt32(hidDesignationId.Value);
                        int result = objDeg_BLL.UpdateDesignation(designationObj, desginationId);
                        if (result == 1)
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                        }

                    }
                    getDesignations();
                    ClearDesignationUi();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Gross Total is not Equal to Misc. Total!')", true);

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}