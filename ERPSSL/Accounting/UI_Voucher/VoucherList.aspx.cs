using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BOL;
using System.Collections;
using System.Data;
using System.Drawing;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Voucher
{
    public partial class VoucherList : System.Web.UI.Page
    {
        vch_Voucher_BLL objVch_BLL = new vch_Voucher_BLL();
        cmp_CompanyProject_BLL objCmp_DAL = new cmp_CompanyProject_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string approval = string.Empty;
        string VoucherType = string.Empty;
        string dateFrom;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null) && (Session["VoucherType"] != null))
            {
                approval = "UN_AP";
                VoucherType = Convert.ToString(Session["VoucherType"]);

                RoleID = Session["RoleID"].ToString();
                PageID = "30";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetVoucherList(approval);
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
                Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void GetVoucherList(string approval)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ApprovalStatus", approval);
                ht.Add("VoucherType", VoucherType);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objVch_BLL.GetVoucherList(ht);
                if (dt.Rows.Count > 0)
                {
                    dtg_list.DataSource = dt;
                    dtg_list.DataBind();
                }
                else
                {
                    dtg_list.DataSource = null;
                    dtg_list.DataBind();
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

        protected void rdbUnaproved_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                approval = "UN_AP";
                Session["VoucherNo"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
                GetVoucherList(approval);
                BtnDiscard.Enabled = true;
                BtnApprove.Enabled = true;

            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
        protected void rdbChecked_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                approval = "CHK";
                Session["VoucherNo"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
                GetVoucherList(approval);
                BtnDiscard.Enabled = true;
                BtnApprove.Enabled = true;

            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void rdbAproved_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                approval = "AP";
                Session["VoucherNo"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
                GetVoucherList(approval);
                if (approval == "AP")
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
                    //e.Row.ToolTip = "Click to select row";
                    //e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.dtg_list, "Select$" + e.Row.RowIndex);
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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtg_list.Rows.Count > 0)
                {
                    if (rdbAproved.Checked)
                    {
                        approval = "AP";
                    }
                    else
                    {
                        approval = "UN_AP";
                    }
                    foreach (GridViewRow row in dtg_list.Rows)
                    {
                        if (row.RowIndex == dtg_list.SelectedIndex)
                        {
                            //row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                            row.ToolTip = string.Empty;
                            Session["Voucher_No"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
                            Session["Voucher_No"] = dtg_list.SelectedRow.Cells[0].Text;
                            //Session["VoucherDate"] = dtg_list.SelectedRow.Cells[1].Text;
                            //Session["Approval"] = approval;
                            //Session["Narration"] = dtg_list.SelectedRow.Cells[4].Text;
                            txtVoucherNo.Text = dtg_list.SelectedRow.Cells[0].Text;
                            dtpVoucherDate.Text = dtg_list.SelectedRow.Cells[1].Text;
                        }
                        else
                        {
                            row.BackColor = ColorTranslator.FromHtml("#eee");
                            row.ToolTip = "Click to select this row.";
                        }
                    }
                    if (Session["VoucherNo"].ToString() != "No Record Found!")
                    {
                        Response.Redirect("..\\UI_Voucher\\VoucherDetails.aspx");
                    }
                }
                else
                {
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

        protected void txtVoucherNo_TextChanged(object sender, EventArgs e)
        {
            if (txtVoucherNo.Text != string.Empty)
            {
                string VoucherDate = String.Format("{0:MM/dd/yyyy}", dtpVoucherDate.Text);
                string VoucherNo = txtVoucherNo.Text;
                GetSearchedVoucherList(approval, VoucherNo, VoucherDate);
            }
            else
            {

            }
        }
        private void GetSearchedVoucherList(string approval, string VoucherNo, string VoucherDate)
        {
            try
            {
                if (rdbAproved.Checked)
                {
                    approval = "AP";
                }
                else
                {
                    approval = "UN_AP";
                }
                Hashtable ht = new Hashtable();
                ht.Add("Voucher_No", VoucherNo);
                ht.Add("VoucherDate", VoucherDate);
                ht.Add("ApprovalStatus", approval);
                ht.Add("VoucherType", VoucherType);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objVch_BLL.GetSearchedVoucherList(ht);
                if (dt.Rows.Count > 0)
                {
                    dtg_list.DataSource = dt;
                    dtg_list.DataBind();
                }
                else
                {
                    dtg_list.DataSource = null;
                    dtg_list.DataBind();
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

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            string VoucherDate = string.Empty; string VoucherNo = string.Empty;
            VoucherDate = String.Format("{0:MM/dd/yyyy}", dtpVoucherDate.Text);
            VoucherNo = txtVoucherNo.Text;

            if (VoucherDate == "")
            {
                VoucherDate = "0";
            }

            if (VoucherNo == "")
            {
                VoucherNo = "0";
            }
            GetSearchedVoucherList(approval, VoucherNo, VoucherDate);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Voucher\\" + VoucherType + "Voucher.aspx");
        }

        protected void BtnApprove_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                if (approval != "AP")
                {
                    foreach (GridViewRow grow in dtg_list.Rows)
                    {
                        CheckBox chkedRow = (CheckBox)grow.FindControl("chkbxEditItem_");
                        if (chkedRow.Checked)
                        {
                            string VoucherNo = Convert.ToString(grow.Cells[0].Text);
                            string VoucherDate = Convert.ToString(grow.Cells[1].Text);

                            if ((VoucherNo != string.Empty) && (VoucherDate != string.Empty))
                            {
                                Hashtable ht = new Hashtable();
                                ht.Add("Voucher_Date", VoucherDate);
                                ht.Add("VoucherNo", VoucherNo);
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
                                    GetVoucherList(approval);
                                    GlobalClass_BOL.VoucherNo = null;
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
                    }
                }
                else
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Voucher Number Already Approved!";
                    messagePanel.BackColor = Color.Red;
                    lblMessage.ForeColor = Color.White;
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
                //if (GetPermission[3].ToString() == "True")
                //{
                if (approval != "AP")
                {
                    foreach (GridViewRow grow in dtg_list.Rows)
                    {
                        CheckBox chkedRow = (CheckBox)grow.FindControl("chkbxEditItem_");
                        if (chkedRow.Checked)
                        {
                            string VoucherNo = Convert.ToString(grow.Cells[0].Text);
                            string VoucherDate = Convert.ToString(grow.Cells[1].Text);

                            if ((VoucherNo != string.Empty) && (VoucherDate != string.Empty))
                            {
                                Hashtable ht = new Hashtable();
                                ht.Add("Voucher_Date", VoucherDate);
                                ht.Add("VoucherNo", VoucherNo);
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
                                    GetVoucherList(approval);
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
                    }
                }
                else
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Voucher Number Already Approved!";
                    messagePanel.BackColor = Color.Red;
                    lblMessage.ForeColor = Color.White;
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
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
    }
}