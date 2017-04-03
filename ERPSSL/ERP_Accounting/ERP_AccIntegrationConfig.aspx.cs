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

namespace ERPSSL.ERP_Accounting
{
    public partial class ERP_AccIntegrationConfig : System.Web.UI.Page
    {
        AccConfiguration_BLL objCofg = new AccConfiguration_BLL();
        string ModuleType = string.Empty;
        string VoucherType = string.Empty;
        ModulBLL modulBll = new ModulBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GetModules();
                GetAcConfigurations();
            }

            if (((SessionUser)Session["SessionUser"]).OCode != null)
            {

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }


        private void GetModules()
        {
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<tbl_Module> modules = modulBll.GetModules(Ocode);
            drpModulName.DataSource = modules.ToList();
            drpModulName.DataTextField = "ModuleName";
            drpModulName.DataValueField = "ModuleID";
            drpModulName.DataBind();
            drpModulName.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void GetLedgerList()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string Company_Code = "CMP201507251";

            var dt = objCofg.GetAc_Configuration_Ledger(OCODE, Company_Code, ddlNature.SelectedItem.Text).ToList();
            ddlLedgerName.DataSource = dt;
            ddlLedgerName.DataValueField = "Ledger_Code";
            ddlLedgerName.DataTextField = "Ledger_Name";
            ddlLedgerName.DataBind();
            drpModulName.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void GetAllLedgerList()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string Company_Code = "CMP201507251";

            var dt = objCofg.GetAc_Configuration_Ledger(OCODE, Company_Code).ToList();
            ddlLedgerName.DataSource = dt;
            ddlLedgerName.DataValueField = "Ledger_Code";
            ddlLedgerName.DataTextField = "Ledger_Name";
            ddlLedgerName.DataBind();
            drpModulName.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void GetAc_Configuration(string ModuleType, string VoucherType)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objCofg.GetAc_Configuration(OCODE, ModuleType, VoucherType).ToList();
                if (row.Count > 0)
                {
                    dgGridList.DataSource = row;
                    dgGridList.DataBind();
                }
                else
                {
                    dgGridList.DataSource = null;
                    dgGridList.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetLedgerList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void dgGridList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgGridList.PageIndex = e.NewPageIndex;
            GetAcConfigurations();
        }

        private void ClearControl()
        {
            txtModuleType.Text = "";
            chkIsChangable.Checked = false;
            drpModulName.ClearSelection();
            ddlLedgerName.ClearSelection();
            ddlNature.ClearSelection();
            ddlVoucherType.ClearSelection();
            BtnSave.Text = "Add";
        }

        private void GetAcConfigurations()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objCofg.GetAc_Configuration(OCODE).ToList();
                if (row.Count > 0)
                {
                    dgGridList.DataSource = row;
                    dgGridList.DataBind();
                }
                else
                {
                    dgGridList.DataSource = null;
                    dgGridList.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                tblConf_Module atblConf_Module = new tblConf_Module();
                atblConf_Module.ModuleId = drpModulName.SelectedValue;
                atblConf_Module.ModuleName = drpModulName.SelectedItem.Text;
                atblConf_Module.Item = txtModuleType.Text;
                atblConf_Module.Ledger_Code = ddlLedgerName.SelectedValue;
                atblConf_Module.Particulars = ddlLedgerName.SelectedItem.Text;
                atblConf_Module.TransactionNature = ddlNature.SelectedItem.Text;
                atblConf_Module.Voucher_Type = ddlVoucherType.SelectedItem.Text;
                atblConf_Module.Company_Code = "CMP201507251";
                
                if (chkIsChangable.Checked == true)
                {
                    atblConf_Module.IsChangable = true;
                }
                else
                {
                    atblConf_Module.IsChangable = false;
                }

                atblConf_Module.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                atblConf_Module.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                atblConf_Module.Edit_Date = DateTime.Now;

                if (BtnSave.Text == "Add")
                {
                    int id = Convert.ToInt16(drpModulName.SelectedValue);
                    string ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                    int result = objCofg.SaveERPConfig(atblConf_Module);
                    if (result == 1)
                    {
                        //  lblStatus.Text = "Data Saved Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added Successfully')", true);
                        ClearControl();
                        GetAcConfigurations();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding Error!')", true);
                    }
                    //}
                }
                else
                {
                    int Id = Convert.ToInt32(hidId.Value);
                    int result = objCofg.UpdateAcConfig(atblConf_Module, Id);
                    if (result == 1)
                    {
                        //lblStatus.Text = "Data Updated Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        ClearControl();
                        GetAcConfigurations();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating Error!')", true);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ImgEdit_Click(object sender, EventArgs e)
        {
            List<tblConf_Module> lsttblConf_Module = new List<tblConf_Module>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                Label lblID = (Label)dgGridList.Rows[row.RowIndex].FindControl("lblID");
                if (lblID != null)
                {
                    string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    lsttblConf_Module = objCofg.GetAc_Configuration(OCODE, Convert.ToInt16(lblID.Text));

                    if (lsttblConf_Module.Count > 0)
                    {
                        foreach (tblConf_Module atblConf_Module in lsttblConf_Module)
                        {
                            hidId.Value = atblConf_Module.Id.ToString();
                            drpModulName.SelectedValue = atblConf_Module.ModuleId;
                            txtModuleType.Text = atblConf_Module.Item;
                            ddlNature.SelectedItem.Text = atblConf_Module.TransactionNature;
                            
                            GetAllLedgerList();
                            
                            ddlLedgerName.SelectedValue = atblConf_Module.Ledger_Code;
                            ddlVoucherType.Text = atblConf_Module.Voucher_Type;

                            if (atblConf_Module.IsChangable == true)
                            {
                                chkIsChangable.Checked = true;
                            }
                            else
                            {
                                chkIsChangable.Checked = false;
                            }

                        }
                        if (BtnSave.Text == "Add")
                        {
                            BtnSave.Text = "Update";
                        }

                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}