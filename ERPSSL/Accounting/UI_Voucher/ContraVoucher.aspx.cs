using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Financial_MgtSystem_BLL;
using System.Drawing;
using Financial_MgtSystem_BOL;
using System.Globalization;
using System.Threading;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Voucher
{
    public partial class ContraVoucher : System.Web.UI.Page
    {
        grp_GroupHead_BLL objGrp_BL = new grp_GroupHead_BLL();
        cmp_CompanyProject_BLL objCmp_DAL = new cmp_CompanyProject_BLL();
        leg_Ledgers_BLL objLeg_BLL = new leg_Ledgers_BLL();
        vch_Voucher_BLL objVch_BLL = new vch_Voucher_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;

        string VoucherType = "CONTRA";
        string Voucherdate = string.Empty;
        string CmbSelectType = string.Empty;
        string LedgerCode = string.Empty;
        string Nature = string.Empty;
        public static int CurrentID = 1;
        public static List<Listvch_Details> objVch_List = new List<Listvch_Details>();
        public static float dGTotal = 0, cGTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {

                this.Form.DefaultButton = this.btnSubmit.UniqueID;

                Voucherdate = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                RoleID = Session["RoleID"].ToString();
                PageID = "25";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                //    //txtCrdTotal.Text = "Cr." + cGTotal.ToString();
                //    //txtdbtTotal.Text = "Dr." + dGTotal.ToString();

                if (!IsPostBack)
                {
                    GetCompanyProjectCurrency();
                    GetvoucherNumber();
                    this.BindListData();
                    GetLedgerListByType("Dr./Cr.");
                }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}

            }
            else
            {
                HttpContext.Current.Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void BindListData()
        {
            try
            {
                //dtg_ACT.DataSource = objVch_List;
                dtg_ACT.DataSource = Session["entries_cv"];
                dtg_ACT.DataBind();
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void GetCompanyProjectCurrency()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);
                DataTable dt = objCmp_DAL.CompanyProjectCurrency(ht);
                if (dt.Rows.Count > 0)
                {
                    cmbCurrency.DataSource = dt;
                    cmbCurrency.DataValueField = "Currency_ID";
                    cmbCurrency.DataTextField = "Currency_Name";
                    cmbCurrency.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void GetvoucherNumber()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Voucher_Type", VoucherType);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);
                DataTable dt = objVch_BLL.Get_AC_VoucherNumber(ht);
                if (dt.Rows.Count > 0)
                {
                    ht.Clear();
                    txtVoucherNo.Text = dt.Rows[0]["Voucher_No"].ToString();
                }
                else
                {
                    ht.Clear();
                    this.messagePanel.Visible = true;
                    this.lblMessage.Text = "Nothing Found!!";
                    this.messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    e.Row.ToolTip = "Click to select row";
                    e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.dgLedger_List, "Select$" + e.Row.RowIndex);
                }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
        protected void txtParticulars_TextChanged(object sender, EventArgs e)
        {
            TextBox txtParticulars = (TextBox)sender;
            if (txtParticulars.Text != string.Empty)
            {
                string SearchKey = txtParticulars.Text;
                GetLedgerListBy_KeySearch(SearchKey);
            }
        }
        private void GetLedgerListBy_KeySearch(string SearchKey)
        {
            try
            {
                Control control = null;
                if (dtg_ACT.FooterRow != null)
                {
                    control = dtg_ACT.FooterRow;
                }
                else
                {
                    control = dtg_ACT.Controls[0].Controls[0];
                }

                DropDownList cmbNature = null;
                cmbNature = control.FindControl("cmbNature") as DropDownList;
                string resultNature = cmbNature.Text;

                Hashtable ht = new Hashtable();
                if (SearchKey != string.Empty)
                {
                    ht.Add("VoucherType", VoucherType);
                    ht.Add("Nature", resultNature);
                    ht.Add("Search_Key", SearchKey);
                    ht.Add("Company_Code", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    DataTable dt = objLeg_BLL.SearchLedgerList_KeySearch(ht);
                    if (dt.Rows.Count > 0)
                    {
                        ht.Clear();
                        dgLedger_List.DataSource = dt;
                        dgLedger_List.DataBind();
                    }
                    else
                    {
                        ht.Clear();
                        CmbSelectType = string.Empty;
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Nothing Found!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void dgLedger_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Control control = null;
                if (dtg_ACT.FooterRow != null)
                {
                    control = dtg_ACT.FooterRow;
                }
                else
                {
                    control = dtg_ACT.Controls[0].Controls[0];
                }

                if (dgLedger_List.Rows.Count > 0)
                {
                    DropDownList cmbNature = null;
                    cmbNature = control.FindControl("cmbNature") as DropDownList;
                    Nature = cmbNature.Text;

                    TextBox Particulars = null;
                    Particulars = control.FindControl("txtParticulars") as TextBox;
                    Particulars.Text = dgLedger_List.SelectedRow.Cells[1].Text;

                    TextBox Cheque = null;
                    Cheque = control.FindControl("txtChequeNo") as TextBox;
                    Cheque.Text = "N/A";

                    TextBox Debit = null;
                    Debit = control.FindControl("txtDebit") as TextBox;

                    TextBox Credit = null;
                    Credit = control.FindControl("txtCredit") as TextBox;

                    foreach (GridViewRow row in dgLedger_List.Rows)
                    {
                        if (row.RowIndex == dgLedger_List.SelectedIndex)
                        {
                            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                            row.ToolTip = string.Empty;

                            Session["LedgerCode"] = dgLedger_List.DataKeys[row.RowIndex].Values[0].ToString();
                        }
                        else
                        {
                            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            row.ToolTip = "Click to select this row.";
                        }
                    }

                    if (Nature != "Dr./Cr.")
                    {
                        if (Nature == "DEBIT")
                        {
                            Debit.Text = "";
                            Debit.Focus();
                            Credit.Text = "0.00";

                            Debit.Enabled = true;
                            Debit.ReadOnly = false;
                            Credit.Enabled = false;
                        }

                        if (Nature == "CREDIT")
                        {
                            Credit.Text = "";
                            Credit.Focus();
                            Debit.Text = "0.00";

                            Debit.Enabled = false;
                            Credit.ReadOnly = false;
                            Credit.Enabled = true;
                        }
                    }
                    else
                    {
                        messagePanel.Visible = true;
                        lblMessage.Text = "Please Select Dr./Cr. Type!!";
                        messagePanel.BackColor = Color.Green;
                        this.lblMessage.ForeColor = Color.White;
                        Session["LedgerCode"] = null;
                    }

                }
                else
                {
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "No Company Found!";
                    this.lblMessage.ForeColor = Color.Maroon;
                }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void Add(object sender, EventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
                {
                    Listvch_Details objList = new Listvch_Details();
                    Control control = null;

                    if (dtg_ACT.FooterRow != null)
                    {
                        control = dtg_ACT.FooterRow;
                    }
                    else
                    {
                        control = dtg_ACT.Controls[0].Controls[0];
                    }

                    objList.Voucher_Details_ID = CurrentID;
                    objList.Nature = Convert.ToString((control.FindControl("cmbNature") as DropDownList).Text);
                    objList.Ledger_Code = Convert.ToString(Session["LedgerCode"]);
                    objList.Particulars = Convert.ToString((control.FindControl("txtParticulars") as TextBox).Text);
                    objList.ChequeNo = Convert.ToString((control.FindControl("txtChequeNo") as TextBox).Text);
                    objList.Debit = Convert.ToDouble((control.FindControl("txtDebit") as TextBox).Text);
                    objList.Credit = Convert.ToDouble((control.FindControl("txtCredit") as TextBox).Text);

                    if (Session["LedgerCode"] != null)
                    {
                        objVch_List.Add(objList);
                        CurrentID = CurrentID + 1;

                        Session["entries_cv"] = objVch_List;

                        this.BindListData();
                        GrandTotal_Dr();
                        GrandTotal_Cr();
                        Session["LedgerCode"] = null;
                        this.messagePanel.Visible = true;
                        lblMessage.Text = "Ledger Added to List!!";
                        this.messagePanel.BackColor = Color.Green;
                        this.lblMessage.ForeColor = Color.White;
                    }
                    else
                    {
                        this.messagePanel.Visible = true;
                        lblMessage.Text = "Unable to add with Empty Ledger!!";
                        this.messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                }
                else
                {
                    Response.Redirect("..\\..\\Default.aspx");
                }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}

            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void SaveVoucher()
        {
            try
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                Voucherdate = String.Format("{0:MM/dd/yyyy}", dtpVoucherDate.Text);
                //---------------------Voucher Master-------
                string Narration = string.Empty;
                if (txtNarration.Text == string.Empty)
                {
                    Narration = txtVoucherNo.Text + "," + textInfo.ToUpper(VoucherType) + "," + txtCrdTotal.Text;
                }
                else
                {
                    Narration = txtNarration.Text;
                }

                Hashtable ht = new Hashtable();
                ht.Add("VoucherNo", txtVoucherNo.Text);
                ht.Add("VoucherType", VoucherType);
                ht.Add("Voucher_Total", Convert.ToDouble(Session["dGTotal_cv"]));
                ht.Add("Narration", Narration);
                ht.Add("Currency", cmbCurrency.SelectedItem.Text);
                ht.Add("Voucher_Date", Voucherdate);
                //--------------------------
                ht.Add("Edit_User", Session["UserID"]);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                bool status = objVch_BLL.Save_Voucher(ht);

                var myList = (List<Listvch_Details>)Session["entries_cv"];

                if (status == true)
                {
                    foreach (Listvch_Details vch in myList)
                    {
                        Hashtable htIn = new Hashtable();
                        htIn.Add("VoucherType", VoucherType);
                        htIn.Add("VoucherNo", Convert.ToString(txtVoucherNo.Text));
                        htIn.Add("Nature", vch.Nature.ToString());
                        htIn.Add("Ledger_Code", vch.Ledger_Code.ToString());
                        htIn.Add("Particulars", vch.Particulars.ToString());
                        htIn.Add("ChequeNo", vch.ChequeNo);
                        htIn.Add("Debit", Convert.ToDouble(vch.Debit));
                        htIn.Add("Credit", Convert.ToDouble(vch.Credit));
                        htIn.Add("Voucher_Date", dtpVoucherDate.Text);
                        htIn.Add("Narration", Narration);
                        //--------------------------
                        htIn.Add("Edit_User", Session["UserID"]);
                        htIn.Add("Company_Code", Session["CompanyCode"]);
                        htIn.Add("OCode", Session["OCode"]);
                        objVch_BLL.Save_VoucherDetails(htIn);
                    }

                    objVch_List.Clear();
                    CurrentID = 1;
                    this.BindListData();
                    this.GetvoucherNumber();
                    ht.Clear();
                    txtNarration.Text = string.Empty;
                    cGTotal = 0;
                    dGTotal = 0;
                    Session["entries_cv"] = null;
                    Session["dGTotal_cv"] = null;
                    Session["cGTotal_cv"] = null;
                    messagePanel.Visible = true;
                    lblMessage.Text = "Voucher Saved Successfully!!";
                    messagePanel.BackColor = Color.Green;
                    this.lblMessage.ForeColor = Color.White;

                }
                else
                {
                    ht.Clear();
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "Voucher Creation Failed!!";
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private bool IsValid()
        {
            try
            {
                if ((Convert.ToDouble(Session["dGTotal_cv"]) == 0) && (Convert.ToDouble(Session["cGTotal_cv"]) == 0))
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Debit Amount and Credit Amount Can't be Empty!!";
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
                    return false;
                }

                if ((Convert.ToDouble(Session["dGTotal_cv"]) != Convert.ToDouble(Session["cGTotal_cv"])))
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Debit Amount and Credit Amount nedd to be Equal!!";
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
                    return false;
                }
            }
            catch (Exception ex)
            {
                messagePanel.Visible = true;
                lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }

            return true;
        }

        protected void btnVchList_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[0].ToString() == "True")
            //{
            Session["VoucherType"] = null;
            Session["VoucherType"] = VoucherType;
            Response.Redirect("..\\UI_Voucher\\VoucherList.aspx");
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void btnReset_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            objVch_List.Clear();
            CurrentID = 1;
            this.BindListData();
            cGTotal = 0;
            dGTotal = 0;
            Session["entries_cv"] = null;
            Session["dGTotal_cv"] = null;
            Session["cGTotal_cv"] = null;
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}

        }

        protected void dtg_ACT_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (GetPermission[2].ToString() == "True")
            //{
            try
            {
                Label IndexID = (Label)dtg_ACT.Rows[e.RowIndex].FindControl("lblSerial");
                int Id = Convert.ToInt16(IndexID.Text);
                objVch_List.RemoveAll(a => a.Voucher_Details_ID == Id);
                dtg_ACT.EditIndex = -1;
                this.BindListData();
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}

        }

        protected void dtg_ACT_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //if (GetPermission[1].ToString() == "True")
            //{

            try
            {
                dtg_ACT.EditIndex = e.NewEditIndex;
                this.BindListData();
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}

        }

        protected void dtg_ACT_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label IndexID = (Label)dtg_ACT.Rows[e.RowIndex].FindControl("lblSerial");
                int Id = Convert.ToInt16(IndexID.Text);

                Label cmbNatureUpdate = (Label)dtg_ACT.Rows[e.RowIndex].FindControl("lblNature");
                string Nature = cmbNatureUpdate.Text;

                TextBox txtChequeNo = (TextBox)dtg_ACT.Rows[e.RowIndex].FindControl("txtChequeNoEdit");
                string ChequeNo = txtChequeNo.Text;

                TextBox CntrlDebit = (TextBox)dtg_ACT.Rows[e.RowIndex].FindControl("txtDebitEdit");
                double txtDebit = 0.00;

                TextBox CntrlCredit = (TextBox)dtg_ACT.Rows[e.RowIndex].FindControl("txtCreditEdit");
                double txtCredit = 0.00;

                if (Nature != null)
                {
                    if (Nature == "DEBIT")
                    {
                        txtDebit = Convert.ToDouble(CntrlDebit.Text);
                        txtCredit = 0.00;
                    }

                    if (Nature == "CREDIT")
                    {
                        txtDebit = 0.00;
                        txtCredit = Convert.ToDouble(CntrlCredit.Text);
                    }
                }

                foreach (var item in objVch_List.FindAll(a => a.Voucher_Details_ID == Id))
                {
                    item.ChequeNo = ChequeNo;
                    item.Debit = txtDebit;
                    item.Credit = Convert.ToDouble(txtCredit);
                }

                dtg_ACT.EditIndex = -1;
                this.BindListData();
                GrandTotal_Dr();
                GrandTotal_Cr();

            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void dtg_ACT_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_ACT.EditIndex = -1;
            this.BindListData();
        }

        protected void dtg_ACT_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void cmbNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Control control = null;
                if (dtg_ACT.FooterRow != null)
                {
                    control = dtg_ACT.FooterRow;
                }
                else
                {
                    control = dtg_ACT.Controls[0].Controls[0];
                }

                DropDownList cmbNature = null;
                cmbNature = control.FindControl("cmbNature") as DropDownList;
                string resultType = cmbNature.Text;
                GetLedgerListByType(resultType);
            }
            catch (Exception ex)
            {
                messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void cmbNature_DataBound(object sender, EventArgs e)
        {

        }

        private void GetLedgerListByType(string resultType)
        {
            try
            {
                Hashtable ht = new Hashtable();
                if (resultType != string.Empty)
                {
                    ht.Add("VoucherType", VoucherType);
                    ht.Add("Search_Key", resultType);
                    ht.Add("Company_Code", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    DataTable dt = objLeg_BLL.SearchLedgerListByType(ht);
                    if (dt.Rows.Count > 0)
                    {
                        ht.Clear();

                        dgLedger_List.DataSource = dt;
                        dgLedger_List.DataBind();
                    }
                    else
                    {
                        ht.Clear();
                        CmbSelectType = string.Empty;
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Nothing Found!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void GrandTotal_Dr()
        {
            try
            {
                dGTotal = 0f;
                for (int i = 0; i < dtg_ACT.Rows.Count; i++)
                {
                    String total = (dtg_ACT.Rows[i].FindControl("lblDebit") as Label).Text;
                    dGTotal += Convert.ToSingle(total);
                    Session["dGTotal_cv"] = dGTotal.ToString();
                }
                txtdbtTotal.Text = "Dr." + Session["dGTotal_cv"].ToString();
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void GrandTotal_Cr()
        {
            try
            {
                cGTotal = 0f;
                for (int i = 0; i < dtg_ACT.Rows.Count; i++)
                {
                    String total = (dtg_ACT.Rows[i].FindControl("lblCredit") as Label).Text;
                    cGTotal += Convert.ToSingle(total);
                    Session["cGTotal_cv"] = cGTotal.ToString();
                }
                txtCrdTotal.Text = "Cr." + Session["cGTotal_cv"].ToString();
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void txtCrdTotal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                if (IsValid())
                {
                    if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
                    {
                        this.SaveVoucher();
                    }
                    else
                    {
                        Response.Redirect("..\\..\\Default.aspx");
                    }
                }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Gateway\\Index.aspx");
        }

    }
}