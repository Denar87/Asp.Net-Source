using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.ERP_Accounting.BLL;
using ERPSSL.ERP_Accounting.DAL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.INV.DAL;

namespace ERPSSL.ERP_Accounting
{
    public partial class ERP_Company : System.Web.UI.Page
    {
        AccConfiguration_BLL objCofg = new AccConfiguration_BLL();
        ERPSSL.Adminpanel.DAL.ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GetEmployeeInfo();
                GetCompany();
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

                    List<AssignTo> assignTos = new List<AssignTo>();
                    assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                    foreach (AssignTo assign in assignTos)
                    {
                        txtEID.Text = ((SessionUser)Session["SessionUser"]).EID;
                    }

                }
            }

            catch
            {
            }
        }


        private void GetCompany()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            var result = objCofg.Get_Company(OCODE);
            if (result.Count() > 0)
            {
                ddlCompany.DataSource = result;
                ddlCompany.DataTextField = "Company_Name";
                ddlCompany.DataValueField = "Company_Code";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem("---Select---", "0"));


            }

        }

        protected void BtnSet_Click(object sender, EventArgs e)
        {
            tbl_User user = new tbl_User();
            List<tbl_User> result = objCofg.GetUser(txtEID.Text).ToList();
            if (result.Count > 0)
            {
                var Result = _context.tbl_User.Where(b => b.EID == txtEID.Text).First();
                if (ddlCompany.SelectedValue != "0")
                {
                    try
                    {
                        Result.Company_Code = ddlCompany.SelectedValue;
                        _context.SaveChanges();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Company')", true);
                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No User In The List')", true);

            }


        }


    }
}