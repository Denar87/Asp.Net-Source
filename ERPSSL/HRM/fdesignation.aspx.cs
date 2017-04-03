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
    public partial class fdesignation : System.Web.UI.Page
    {
        DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getDesignations();
                    txtbxHolidayAllowance.Text = "0";
                    txtOthers.Text = "0";
                    txtFiexedAllowance.Text = "0";
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
                txtBasic.Text = "0";
                txtConveyance.Text = "0";
                txtFiexedAllowance.Text = "0";
                txtOthers.Text = "0";
                txtbxGrade.Text = "";
                txtHouseRent.Text = "0";
                txtMedical.Text = "0";
                txtbxHolidayAllowance.Text = "0";
                txtGrsSal.Text = "0";
                btnSave.Text = "Submit";
                txtBasicpr.Text = "0";
                txtConveyancepr.Text = "0";
                txtFoodAllowancepr.Text = "0";
                txtHouseRentpr.Text = "0";
                txtMedicalpr.Text = "0";
                //txtbxHolidayAllowancePr.Text = "";

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
                decimal basic = Convert.ToDecimal(txtGrsSal.Text);
                decimal TotalBaic = (basic * 50) / 100;
                txtBasic.Text = TotalBaic.ToString();
                txtBasicpr.Text = "50";

                decimal basicForHouseRent = Convert.ToDecimal(txtGrsSal.Text);
                decimal TotalHouseRent = (basicForHouseRent * 30) / 100;
                txtHouseRent.Text = TotalHouseRent.ToString();
                txtHouseRentpr.Text = "30";

                decimal basicFortxtMedical = Convert.ToDecimal(txtGrsSal.Text);
                decimal TotaltxtMedical = (basicFortxtMedical * 10) / 100;
                txtMedical.Text = TotaltxtMedical.ToString();
                txtMedicalpr.Text = "10";

                decimal basicFortxtConveyance = Convert.ToDecimal(txtGrsSal.Text);
                decimal TotaltxtConveyance = (basicFortxtConveyance * 10) / 100;
                txtConveyance.Text = TotaltxtConveyance.ToString();
                txtConveyancepr.Text = "10";


                //decimal basicFortxtFiexedAllowance = Convert.ToDecimal(txtGrsSal.Text);
                //decimal TotaltxttxtFiexedAllowance = (basicFortxtFiexedAllowance * 30) / 100;
                //txtFiexedAllowance.Text = TotaltxttxtFiexedAllowance.ToString();
                //txtFoodAllowancepr.Text = "30";


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
                            txtConveyance.Text = adesignation.CONVEYANCE.ToString();
                            txtFiexedAllowance.Text = adesignation.FixedAllowance.ToString();
                            txtOthers.Text = adesignation.AttendanceBonus.ToString();
                            txtbxGrade.Text = adesignation.GRADE.ToString();
                            txtHouseRent.Text = adesignation.HOUSE_RENT.ToString();
                            txtMedical.Text = adesignation.MEDICAL.ToString();
                            txtbxHolidayAllowance.Text = adesignation.Holiday_Allowance.ToString();
                            txtGrsSal.Text = adesignation.GROSS_SAL.ToString();

                        }
                        if (btnSave.Text == "Submit")
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
                decimal CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                decimal FiresdAllowance = Convert.ToDecimal(txtFiexedAllowance.Text);
                decimal OTHERS = Convert.ToDecimal(txtOthers.Text);
                decimal HolidayAllowance = Convert.ToDecimal(txtbxHolidayAllowance.Text);
                decimal TOTAL = (BASIC + HOUSE_RENT + MEDICAL + CONVEYANCE + FiresdAllowance + OTHERS + HolidayAllowance);
                if (GROSS_SAL == TOTAL)
                {
                    HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                    designationObj.DEG_NAME = txtbxDesignation.Text;
                    designationObj.GRADE = txtbxGrade.Text;
                    designationObj.GROSS_SAL = Convert.ToDecimal(txtGrsSal.Text);
                    designationObj.HOUSE_RENT = Convert.ToDecimal(txtHouseRent.Text);
                    designationObj.BASIC = Convert.ToDecimal(txtBasic.Text);
                    designationObj.MEDICAL = Convert.ToDecimal(txtMedical.Text);
                    designationObj.CONVEYANCE = Convert.ToDecimal(txtConveyance.Text);
                    designationObj.FixedAllowance = Convert.ToDecimal(txtFiexedAllowance.Text);
                    designationObj.AttendanceBonus = Convert.ToDecimal(txtOthers.Text);
                    designationObj.Holiday_Allowance = Convert.ToDecimal(txtbxHolidayAllowance.Text);

                    designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    designationObj.EDIT_DATE = DateTime.Now;
                    designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    if (btnSave.Text == "Submit")
                    {
                        int result = objDeg_BLL.InsertDeignation(designationObj);
                        if (result == 1)
                        {
                            //  lblMessage.Text = "Data Added successfully!";
                            //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                        }

                    }
                    else
                    {
                        int desginationId = Convert.ToInt32(hidDesignationId.Value);
                        int result = objDeg_BLL.UpdateDesignation(designationObj, desginationId);
                        if (result == 1)
                        {
                            //   lblMessage.Text = "Data Update successfully!";
                            //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        }

                    }
                    getDesignations();
                    ClearDesignationUi();

                }
                else
                {
                    // lblMessage.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Gross Total is not Equal to Misc. Total!')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}