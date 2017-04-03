using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Financial_MgtSystem_BOL;
using System.Data;
using Financial_MgtSystem_BLL;
using System.Drawing;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Voucher
{
    public partial class VoucherDetails : System.Web.UI.Page
    {
        vch_Voucher_BLL objVch_BLL = new vch_Voucher_BLL();
        rpt_VoucherDetails objRptVch_BLL = new rpt_VoucherDetails();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string VoucherType = string.Empty;
        string Approval = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null) && (Session["VoucherType"] != null))
            {
                VoucherType = Convert.ToString(Session["VoucherType"]);
                Approval = Convert.ToString(Session["Approval"]);
                txtVoucherNo.Text = Convert.ToString(Session["VoucherNo"]);
                dtpVoucherDate.Text = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Session["VoucherDate"]));

                RoleID = Session["RoleID"].ToString();
                PageID = "29";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetVoucherDetails();
                    if (Approval == "AP")
                    {
                        BtnDiscard.Enabled = false;
                        BtnApprove.Enabled = false;
                    }
                    else
                    {
                        BtnDiscard.Enabled = true;
                        BtnApprove.Enabled = true;
                    }
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

        private void GetVoucherDetails()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("VoucherApproval", Approval);
                ht.Add("VoucherType", VoucherType);
                ht.Add("Voucher_No", Session["VoucherNo"]);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objVch_BLL.GetVoucherDetails(ht);
                if (dt.Rows.Count > 0)
                {
                    dtg_list.DataSource = dt;
                    dtg_list.DataBind();
                    txtNarration.Text = Session["Narration"].ToString();
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

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
                {
                    if (Approval == "AP")
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("VoucherType", VoucherType);
                        ht.Add("Voucher_No", Session["VoucherNo"]);
                        ht.Add("Company_Code", Session["CompanyCode"]);
                        ht.Add("OCode", Session["OCode"]);

                        DataTable dt = objRptVch_BLL.Rpt_GetVoucherDetails(ht);
                        if (dt.Rows.Count != 0)
                        {
                            Session["ReportTitle"] = VoucherType + " VOUCHER";
                            Session["ReportCriteria"] = " Voucher No: " + Session["VoucherNo"].ToString() + "," + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(Session["VoucherDate"]));
                            Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                            Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                            Session["OrganizationContact"] = "Email:" + GlobalClass_BOL.E_mail + ", Phone:" + GlobalClass_BOL.Phone;
                            Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                            Session["rptDs"] = "ds_VoucherDetails";
                            Session["rptDt"] = dt;
                            Session["rptFile"] = "..\\UI_ReportsFile\\VoucherDetails.rdlc";
                            //Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx");
                            if (!Request.IsAuthenticated)
                            {
                                Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx?ReturnURL=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)); // dont forget to use urlencode
                            }
                        }
                        else
                        {
                            ht.Clear();
                            messagePanel.Visible = true;
                            this.lblMessage.Text = "Nothing Found!!";
                            messagePanel.BackColor = Color.Red;
                            this.lblMessage.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Unable to print an Unapproved Voucher!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                }
                else
                {
                    Response.Redirect("..\\..\\Default.aspx");
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

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Voucher\\VoucherList.aspx");
        }

        protected void BtnApprove_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Session["VoucherNo"] != null) && (Session["VoucherDate"] != null))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Voucher_Date", Session["VoucherDate"]);
                    ht.Add("VoucherNo", Session["VoucherNo"]);
                    ht.Add("Approve_UserID", Session["UserID"]);
                    //--------------------------
                    ht.Add("Edit_User", Session["UserID"]);
                    ht.Add("Company_Code", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    bool status = objVch_BLL.Approve_Voucher(ht);
                    if (status == true)
                    {
                        lblMessage.Text = "Voucher Number " + GlobalClass_BOL.VoucherNo + " Approved!";
                        messagePanel.Visible = true;
                        messagePanel.BackColor = Color.Green;
                        lblMessage.ForeColor = Color.White;
                        GlobalClass_BOL.VoucherNo = null;
                        Response.Redirect("..\\UI_Voucher\\VoucherList.aspx");
                    }
                }
                else
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Select Different Voucher Number!";
                    messagePanel.BackColor = Color.Red;
                    lblMessage.ForeColor = Color.White;
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

        protected void BtnDiscard_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Session["VoucherNo"] != null) && (Session["VoucherDate"] != null))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Voucher_Date", Session["VoucherDate"]);
                    ht.Add("VoucherNo", Session["VoucherNo"]);
                    ht.Add("Approve_UserID", Session["UserID"]);
                    //--------------------------
                    ht.Add("Edit_User", Session["UserID"]);
                    ht.Add("Company_Code", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    bool status = objVch_BLL.Discard_Voucher(ht);
                    if (status == true)
                    {
                        lblMessage.Text = "Voucher Number " + GlobalClass_BOL.VoucherNo + " Discarded!";
                        messagePanel.Visible = true;
                        messagePanel.BackColor = Color.Red;
                        lblMessage.ForeColor = Color.White;
                        Response.Redirect("..\\UI_Voucher\\VoucherList.aspx");
                    }
                }
                else
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Select Different Voucher Number!";
                    messagePanel.BackColor = Color.Red;
                    lblMessage.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Session["VoucherNo"] != null) && (Session["VoucherDate"] != null))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Voucher_Date", Session["VoucherDate"]);
                    ht.Add("VoucherNo", Session["VoucherNo"]);
                    ht.Add("Narration", txtNarration.Text.Trim());
                    //--------------------------
                    ht.Add("Edit_User", Session["UserID"]);
                    ht.Add("Company_Code", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    bool status = objVch_BLL.Update_Voucher(ht);
                    if (status == true)
                    {
                        lblMessage.Text = "Voucher Number " + GlobalClass_BOL.VoucherNo + " Updated!";
                        messagePanel.Visible = true;
                        messagePanel.BackColor = Color.Green;
                        lblMessage.ForeColor = Color.White;
                    }
                }
                else
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Select Different Voucher Number!";
                    messagePanel.BackColor = Color.Red;
                    lblMessage.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
    }
}