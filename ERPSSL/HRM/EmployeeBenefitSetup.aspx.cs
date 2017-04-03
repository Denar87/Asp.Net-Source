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
    public partial class EmployeeBenefitSetup : System.Web.UI.Page
    {
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getEmployeeBenefitSetupList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getEmployeeBenefitSetupList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = employeeBenefitbll.getEmployeeBenefitSetupList(OCODE).ToList();
                if (row.Count > 0)
                {
                    gridviewEmployeeBeniftsetup.DataSource = row.ToList();
                    gridviewEmployeeBeniftsetup.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnBenefitSetup_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_EmployeeBenefitSetup employeeBenefitsetupobj = new HRM_EmployeeBenefitSetup();
                employeeBenefitsetupobj.Benefittype = txtbxBenefitType.Text;
                employeeBenefitsetupobj.Description = txtbxDescription.Text;
                employeeBenefitsetupobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                employeeBenefitsetupobj.EDIT_DATE = DateTime.Now;
                employeeBenefitsetupobj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnBenefitSetup.Text == "Submit")
                {
                    //if (IsExist(employeeBenefitsetupobj.Benefittype))
                    //{

                    int result = employeeBenefitbll.SaveEmployeeBenefitSetup(employeeBenefitsetupobj);
                    if (result == 1)
                    {
                        // lblMessage.Text = "Data Save Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                    //}
                    //else
                    //{
                    //    // lblMessage.Text = "";
                    //    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                    //}
                }
                else
                {
                    string benefitTypeId = hidBenefitypeId.Value;
                    int result = employeeBenefitbll.updateEmpoyeeBenefitById(employeeBenefitsetupobj, benefitTypeId);
                    if (result == 1)
                    {
                        // lblMessage.Text = "Data Update Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    }
                }
                getEmployeeBenefitSetupList();
                ClearControl();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }


        }
        //private bool IsExist(string BFname)
        //{
        //    try
        //    {
        //        ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //        bool status = false;
        //        int count = (from rgn in _context.HRM_EmployeeBenefitSetup
        //                     where rgn.Benefittype == BFname
        //                     select rgn.Benefittype).Count();
        //        if (count == 0)
        //        {
        //            status = true;
        //        }

        //        return status;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        private void ClearControl()
        {
            txtbxBenefitType.Text = "";
            txtbxDescription.Text = "";
            btnBenefitSetup.Text = "Submit";
        }
        protected void imgbtnDepartmentEdit_Click(object sender, EventArgs e)
        {
            List<HRM_EmployeeBenefitSetup> benefites = new List<HRM_EmployeeBenefitSetup>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string benefitId = "";
                Label lblbenefit = (Label)gridviewEmployeeBeniftsetup.Rows[row.RowIndex].FindControl("lblemployeeBenefittypeId");
                if (lblbenefit != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    benefitId = lblbenefit.Text;
                    benefites = employeeBenefitbll.GetBenefitInfoById(benefitId, OCODE);

                    if (benefites.Count > 0)
                    {
                        foreach (HRM_EmployeeBenefitSetup aitem in benefites)
                        {
                            hidBenefitypeId.Value = aitem.BenefittypeId.ToString();
                            txtbxBenefitType.Text = aitem.Benefittype;
                            txtbxDescription.Text = aitem.Description;
                            if (btnBenefitSetup.Text == "Submit")
                            {
                                btnBenefitSetup.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewEmployeeBeniftsetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewEmployeeBeniftsetup.PageIndex = e.NewPageIndex;
            getEmployeeBenefitSetupList();
        }
    }
}