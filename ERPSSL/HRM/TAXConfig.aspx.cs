using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class TAXConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {

                if (!IsPostBack)
                {
                    GetTaxConfig();
                    SetTaxType();
                    GetTaxLibilityConfig();
                    GerRegion1List();

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GerRegion1List()
        {
            try
            {
                Office_BLL objOfficeBLL = new Office_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion1.DataSource = row.ToList();
                    ddlRegion1.DataTextField = "RegionName";
                    ddlRegion1.DataValueField = "RegionID";
                    ddlRegion1.DataBind();
                    ddlRegion1.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetTaxLibilityConfig()
        {
            TAXBLL _txtbll = new TAXBLL();
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            List<TaxLiabilityConfigV> TaxLiabilityConfigVes = _txtbll.GetTaxLibilityConfig(Ocode);
            if (TaxLiabilityConfigVes.Count > 0)
            {
                grdviewTaxLiabilityTypes.DataSource = TaxLiabilityConfigVes;
                grdviewTaxLiabilityTypes.DataBind();
            }
        }

        private void SetTaxType()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            TAXBLL _txtbll = new TAXBLL();
            List<HRM_LiabilityType> HRM_LiabilityTypes = _txtbll.GetTaxConfig(Ocode);
            if (HRM_LiabilityTypes.Count > 0)
            {
                drptaxLiablityType.DataSource = HRM_LiabilityTypes;
                drptaxLiablityType.DataTextField = "Type";
                drptaxLiablityType.DataValueField = "TAXTypeAutoID";
                drptaxLiablityType.DataBind();
                drptaxLiablityType.Items.Insert(0, new ListItem("---Select One---"));
            }

        }

        private void GetTaxConfig()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            TAXBLL _txtbll = new TAXBLL();
            List<HRM_LiabilityType> HRM_LiabilityTypes = _txtbll.GetTaxConfig(Ocode);
            if (HRM_LiabilityTypes.Count > 0)
            {
                grdTaxType.DataSource = HRM_LiabilityTypes.ToList();
                grdTaxType.DataBind();
            }
        }

        protected void btnTaxConfig_Clcik(object sender, EventArgs e)
        {
            try
            {
                TAXBLL _txtbll = new TAXBLL();
                HRM_LiabilityType _TaxLiabilityType = new HRM_LiabilityType();
                _TaxLiabilityType.Type = txtbxTaxLiablityType.Text.Trim();
                _TaxLiabilityType.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _TaxLiabilityType.EDIT_DATE = DateTime.Now;
                _TaxLiabilityType.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnTaxConfig.Text == "Submit")
                {
                    int result = _txtbll.TAXTypeSave(_TaxLiabilityType);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully')", true);
                    }
                }
                else
                {
                    _TaxLiabilityType.TAXTypeAutoID = Convert.ToInt16(hidTaxId.Value);
                    int result = _txtbll.TAXTypeUpdate(_TaxLiabilityType);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully')", true);
                    }

                }
                GetTaxConfig();
                ClearUI();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {
            txtbxTaxLiablityType.Text = "";
            btnTaxConfig.Text = "Submit";
        }

        protected void imgbtnTypeEdit_Click(object sender, EventArgs e)
        {
            TAXBLL _txtbll = new TAXBLL();
            HRM_LiabilityType _TaxLiabilityType = new HRM_LiabilityType();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string txttypeId = "";
                Label lblTaxType = (Label)grdTaxType.Rows[row.RowIndex].FindControl("lblTaxType");
                if (lblTaxType != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    txttypeId = lblTaxType.Text;
                    _TaxLiabilityType = _txtbll.getTaxTypeByTaxIdandocode(txttypeId, OCODE);

                    if (_TaxLiabilityType != null)
                    {

                        hidTaxId.Value = _TaxLiabilityType.TAXTypeAutoID.ToString();
                        txtbxTaxLiablityType.Text = _TaxLiabilityType.Type.ToString();
                        if (btnTaxConfig.Text == "Submit")
                        {
                            btnTaxConfig.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //-----------------------Taxconfig
        protected void btnTAXLiabilityConfig_click(object sender, EventArgs e)
        {
            try
            {
                TAXBLL _txtbll = new TAXBLL();
                HRM_TAXLiabilityConfig _hrmtabliabilityconfig = new HRM_TAXLiabilityConfig();
                _hrmtabliabilityconfig.IncomeFrom = Convert.ToDecimal(txtbxIncomeFrom.Text.Trim());
                _hrmtabliabilityconfig.IncomeTo = Convert.ToDecimal(txtbxIncomeTo.Text.Trim());
                _hrmtabliabilityconfig.OfTax = txtbxOfTax.Text.ToString();
                _hrmtabliabilityconfig.TAXTypeAutoID = Convert.ToInt16(drptaxLiablityType.SelectedValue.ToString());
                _hrmtabliabilityconfig.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _hrmtabliabilityconfig.EDIT_DATE = DateTime.Now;
                _hrmtabliabilityconfig.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnTAXLiabilityConfig.Text == "Submit")
                {
                    int result = _txtbll.TAXLiabilitySave(_hrmtabliabilityconfig);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully')", true);
                    }
                }
                else
                {
                    _hrmtabliabilityconfig.TAXLiabilityConfigID = Convert.ToInt16(hidConfigId.Value);
                    int result = _txtbll.TAXLiabilityUpdatee(_hrmtabliabilityconfig);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully')", true);
                    }

                }
                ClearUIOfTaxConfigControll();
                GetTaxLibilityConfig();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        private void ClearUIOfTaxConfigControll()
        {

            drptaxLiablityType.ClearSelection();
            txtbxIncomeFrom.Text = "";
            txtbxIncomeTo.Text = "";
            txtbxOfTax.Text = "";
        }

        protected void imgbtnTaxLiabilityEdit_Click(object sender, EventArgs e)
        {

            TAXBLL _txtbll = new TAXBLL();
            HRM_TAXLiabilityConfig _TaxLiabilityConfig = new HRM_TAXLiabilityConfig();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string txtconfid = "";
                Label lblTaxType = (Label)grdviewTaxLiabilityTypes.Rows[row.RowIndex].FindControl("lblTaxLiabiltyConfiID");
                if (lblTaxType != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    txtconfid = lblTaxType.Text;
                    _TaxLiabilityConfig = _txtbll.getTaxConfigInfoById(txtconfid, OCODE);

                    if (_TaxLiabilityConfig != null)
                    {

                        hidConfigId.Value = _TaxLiabilityConfig.TAXLiabilityConfigID.ToString();
                        drptaxLiablityType.SelectedValue = _TaxLiabilityConfig.TAXTypeAutoID.ToString();
                        txtbxIncomeFrom.Text = _TaxLiabilityConfig.IncomeFrom.ToString();
                        txtbxIncomeTo.Text = _TaxLiabilityConfig.IncomeTo.ToString();
                        txtbxOfTax.Text = _TaxLiabilityConfig.OfTax.ToString();
                        if (btnTAXLiabilityConfig.Text == "Submit")
                        {
                            btnTAXLiabilityConfig.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        // Tab/PF
        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpdwnDepartment1SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                SECTION_BLL SectionBll = new SECTION_BLL();
                Attendance_BLL _attendancebll = new Attendance_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDept1.SelectedValue);
                var row = SectionBll.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSection.DataSource = row;
                    ddlSection.DataTextField = "SEC_NAME";
                    ddlSection.DataValueField = "SEC_ID";
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlSection_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int sectionId = Convert.ToInt16(ddlSection.SelectedValue);
                var row = subSectionBll.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSubSections.DataSource = row;
                    ddlSubSections.DataTextField = "SUB_SEC_NAME";
                    ddlSubSections.DataValueField = "SUB_SEC_ID";
                    ddlSubSections.DataBind();
                    ddlSubSections.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {

            try
            {
                Attendance_BLL _attendancebll = new Attendance_BLL();
                if (txtbxEid.Text != "")
                {
                    string eid = Convert.ToString(txtbxEid.Text);
                    List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByID(eid);
                    if (employess.Count > 0)
                    {
                        grdview.DataSource = employess;
                        grdview.DataBind();
                    }
                }
                else
                {
                    if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                    {

                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeID(DeptId);
                        if (employess.Count > 0)
                        {
                            grdview.DataSource = employess;
                            grdview.DataBind();
                        }

                    }
                    else
                    {
                        int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                        int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                        int sction = Convert.ToInt32(ddlSection.SelectedValue);
                        int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);
                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction);
                        if (employess.Count > 0)
                        {
                            grdview.DataSource = employess;
                            grdview.DataBind();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpdwnResion1ForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                BridOfficeByResion1(ResionId);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void BridOfficeByResion1(int ResionId)
        {
            try
            {
                Office_BLL objOfficeBLL = new Office_BLL();
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice1.DataSource = row.ToList();
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlOffice1.DataSource = null;
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
        {
            try
            {
                Office_BLL objOfficeBLL = new Office_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);

                var row = objOfficeBLL.GetDeptByOfficeId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDept1.DataSource = row.ToList();
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlDept1.DataSource = null;
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btn_Confirm_Clcik(object sender, EventArgs e)
        {
            TAXBLL _txtbll = new TAXBLL();
            List<HRM_TAXPFApplicable> taxPfapplicables = new List<HRM_TAXPFApplicable>();
            CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));
            if (headerChkBox.Checked == true)
            {
                foreach (GridViewRow gvRow in grdview.Rows)
                {
                    HRM_TAXPFApplicable _taxPaApplicable = new HRM_TAXPFApplicable();

                    Label lbleid = ((Label)gvRow.FindControl("lblEID"));
                    CheckBox rowLevelTaxChkBox = ((CheckBox)gvRow.FindControl("rowLevelTAXCheckBox"));
                    CheckBox rowPFChkBox = ((CheckBox)gvRow.FindControl("rowLevelPFCheckBox"));
                    CheckBox rowMaleChkBox = ((CheckBox)gvRow.FindControl("rowLevelMaleCheckBox"));
                    CheckBox rowfFeMaleChkBox = ((CheckBox)gvRow.FindControl("rowLevelFeMaleCheckBox"));
                    CheckBox rowfSeniorChkBox = ((CheckBox)gvRow.FindControl("rowLevelSeniorCitizenCheckBox"));
                    CheckBox rowDisabledcheckBox = ((CheckBox)gvRow.FindControl("rowLevelDisabledCheckBox"));
                    CheckBox rowFreedomFeightercheckBox = ((CheckBox)gvRow.FindControl("rowLevelFreedomFeighterCheckBox"));


                    _taxPaApplicable.EID = lbleid.Text;
                    _taxPaApplicable.TAXStatus = rowLevelTaxChkBox.Checked;
                    _taxPaApplicable.PFStatus = rowPFChkBox.Checked;
                    _taxPaApplicable.MaleStatus = rowMaleChkBox.Checked;
                    _taxPaApplicable.FemaleStatus = rowfFeMaleChkBox.Checked;
                    _taxPaApplicable.SeniorCitizen = rowfSeniorChkBox.Checked;
                    _taxPaApplicable.Disabled = rowDisabledcheckBox.Checked;
                    _taxPaApplicable.DisabledFreedomFighter = rowFreedomFeightercheckBox.Checked;

                    _taxPaApplicable.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    _taxPaApplicable.EDIT_DATE = DateTime.Now;
                    _taxPaApplicable.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    taxPfapplicables.Add(_taxPaApplicable);

                }
            }
            else
            {
                foreach (GridViewRow gvRow in grdview.Rows)
                {

                    CheckBox rowLeabveCheck = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                    if (rowLeabveCheck.Checked == true)
                    {

                        HRM_TAXPFApplicable _taxPaApplicable = new HRM_TAXPFApplicable();

                        Label lbleid = ((Label)gvRow.FindControl("lblEID"));
                        CheckBox rowLevelTaxChkBox = ((CheckBox)gvRow.FindControl("rowLevelTAXCheckBox"));
                        CheckBox rowPFChkBox = ((CheckBox)gvRow.FindControl("rowLevelPFCheckBox"));
                        CheckBox rowMaleChkBox = ((CheckBox)gvRow.FindControl("rowLevelMaleCheckBox"));
                        CheckBox rowfFeMaleChkBox = ((CheckBox)gvRow.FindControl("rowLevelFeMaleCheckBox"));
                        CheckBox rowfSeniorChkBox = ((CheckBox)gvRow.FindControl("rowLevelSeniorCitizenCheckBox"));
                        CheckBox rowDisabledcheckBox = ((CheckBox)gvRow.FindControl("rowLevelDisabledCheckBox"));
                        CheckBox rowFreedomFeightercheckBox = ((CheckBox)gvRow.FindControl("rowLevelFreedomFeighterCheckBox"));


                        _taxPaApplicable.EID = lbleid.Text;
                        _taxPaApplicable.TAXStatus = rowLevelTaxChkBox.Checked;
                        _taxPaApplicable.PFStatus = rowPFChkBox.Checked;
                        _taxPaApplicable.MaleStatus = rowMaleChkBox.Checked;
                        _taxPaApplicable.FemaleStatus = rowfFeMaleChkBox.Checked;
                        _taxPaApplicable.SeniorCitizen = rowfSeniorChkBox.Checked;
                        _taxPaApplicable.Disabled = rowDisabledcheckBox.Checked;
                        _taxPaApplicable.DisabledFreedomFighter = rowFreedomFeightercheckBox.Checked;

                        _taxPaApplicable.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        _taxPaApplicable.EDIT_DATE = DateTime.Now;
                        _taxPaApplicable.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        taxPfapplicables.Add(_taxPaApplicable);
                    }
                }
            }

            int result = _txtbll.SaveTaxPFApplicableList(taxPfapplicables);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully')", true);
            }

        }

        protected void headerTAXLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerTAXLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelTAXCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelTAXCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void headerPFLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {


            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerPFLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelPFCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelPFCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void headerMaleLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerMaleLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelMaleCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelMaleCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }
        protected void headerFeMaleLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerFeMaleLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelFeMaleCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelFeMaleCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headerSeniorCitizenLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headeSeniorCitizenLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelSeniorCitizenCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelSeniorCitizenCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void headeDisabledLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headeDisabledLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelDisabledCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelDisabledCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headeDisabledFreedomFeihterLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headeDisabledFreedomFeighterLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelFreedomFeighterCheckBox"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelFreedomFeighterCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}