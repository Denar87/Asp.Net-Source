using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.ERP_Accounting.BLL;
using ERPSSL.ERP_Accounting.Repository;
using System.Drawing;

namespace ERPSSL.ERP_Accounting
{
    public partial class AllVoucherList : System.Web.UI.Page
    {
        Voucher_Bll aVoucher_Bll = new Voucher_Bll();
        string approval = string.Empty;
        string Edit_User, CompanyCode, OCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(((SessionUser)Session["SessionUser"]).UserId) != null && Convert.ToString(((SessionUser)Session["SessionUser"]).Company_Code) != null && Convert.ToString(((SessionUser)Session["SessionUser"]).OCode) != null)
            {
                Edit_User = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);
                CompanyCode = ((SessionUser)Session["SessionUser"]).Company_Code;
                OCode = ((SessionUser)Session["SessionUser"]).OCode;
                approval = "UN_AP";

                if (!IsPostBack)
                {
                    GetAllVoucher(approval);
                    txtVoucherDate.Text = DateTime.Now.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void GetAllVoucher(string approval)
        {
            grdAllVoucherList.DataSource = aVoucher_Bll.GetAllVoucher(approval, CompanyCode, OCode);
            grdAllVoucherList.DataBind();
        }

        protected void rdbUnaproved_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                approval = "UN_AP";
                //Session["VoucherNo"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
                GetAllVoucher(approval);
                //BtnDiscard.Enabled = true;
                //BtnApprove.Enabled = true;
            }
            catch (Exception ex)
            {
                //this.messagePanel.Visible = true;
                //this.lblMessage.Text = ex.Message.ToString();
                //this.messagePanel.BackColor = Color.Red;
                //this.lblMessage.ForeColor = Color.White;
            }
        }

        //protected void rdbChecked_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        approval = "CHK";
        //        //Session["VoucherNo"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
        //        GetAllVoucher(approval);
        //        //BtnDiscard.Enabled = true;
        //        //BtnApprove.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //this.messagePanel.Visible = true;
        //        //this.lblMessage.Text = ex.Message.ToString();
        //        //this.messagePanel.BackColor = Color.Red;
        //        //this.lblMessage.ForeColor = Color.White;
        //    }
        //}

        protected void rdbAproved_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                approval = "AP";
                //Session["VoucherNo"] = null; Session["VoucherDate"] = null; Session["Approval"] = null; Session["Narration"] = null;
                GetAllVoucher(approval);
                //if (approval == "AP")
                //{
                //    BtnDiscard.Enabled = false;
                //    BtnApprove.Enabled = false;
                //}
                //else
                //{
                //    BtnDiscard.Enabled = true;
                //    BtnApprove.Enabled = true;
                //}
            }
            catch (Exception ex)
            {
                //this.messagePanel.Visible = true;
                //this.lblMessage.Text = ex.Message.ToString();
                //this.messagePanel.BackColor = Color.Red;
                //this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void grdAllVoucherList_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
           
            try
            {
                if (grdAllVoucherList.Rows.Count > 0)
                {
                    if (rdbAproved.Checked)
                    {
                        approval = "AP";
                    }
                    else
                    {
                        approval = "UN_AP";
                    }

                    ///
                    foreach (GridViewRow row in grdAllVoucherList.Rows)
                    {
                        if (row.RowIndex == grdAllVoucherList.SelectedIndex)
                        {
                            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                            row.ToolTip = string.Empty;
                            Session["Voucher_No"] = null; 
                            Session["Voucher_Date"] = null;
                            Session["Approval"] = null;
                            Session["Narration"] = null;
                            Session["Voucher_No"] = grdAllVoucherList.SelectedRow.Cells[0].Text;
                            Session["Voucher_Date"] = grdAllVoucherList.SelectedRow.Cells[1].Text;
                            Session["Approval"] = approval;
                            Session["Narration"] = grdAllVoucherList.SelectedRow.Cells[4].Text;
                            txtVoucherNo.Text = grdAllVoucherList.SelectedRow.Cells[0].Text;
                            txtVoucherDate.Text = grdAllVoucherList.SelectedRow.Cells[1].Text;
                        }
                        else
                        {
                            row.BackColor = ColorTranslator.FromHtml("#eee");
                            row.ToolTip = "Click to select this row.";
                        }
                    }
                    if (Session["Voucher_No"].ToString() != "No Record Found!")
                    {
                        Response.Redirect("..\\ERP_Accounting\\AllVoucherDetails.aspx");
                    }
                }
                else
                {
                    //this.lblMessage.Text = "No Company Found!";
                    //this.lblMessage.ForeColor = Color.Maroon;
                }
            }
            catch (Exception ex)
            {
                //this.messagePanel.Visible = true;
                //this.lblMessage.Text = ex.Message.ToString();
                //this.messagePanel.BackColor = Color.Red;
                //this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void imgbtnEdit_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            Label lblVoucherNo = (Label)grdAllVoucherList.Rows[row.RowIndex].FindControl("lblVoucher_NO");
            string lblvoucherno = lblVoucherNo.Text;
                if (grdAllVoucherList.Rows.Count > 0)
                {
                    if (rdbAproved.Checked)
                    {
                        approval = "AP";
                    }
                    else
                    {
                        approval = "UN_AP";
                    }

                    ///
                    foreach (GridViewRow row1 in grdAllVoucherList.Rows)
                    {

                        Label voucherNO = ((Label)row1.FindControl("lblVoucher_NO"));
                        
                        if (lblvoucherno == voucherNO.Text)
                        {
                          
                            row1.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                            row1.ToolTip = string.Empty;
                            Session["Voucher_No"] = null;
                            Session["Voucher_Date"] = null;
                            Session["Approval"] = null;
                            Session["Narration"] = null;
                            Session["Voucher_No"] = row1.Cells[1].Text;
                            Session["Voucher_Date"] = row1.Cells[2].Text;
                            Session["Approval"] = approval;
                            Session["Narration"] = row1.Cells[5].Text;
                            txtVoucherNo.Text = row1.Cells[1].Text;
                            txtVoucherDate.Text = row1.Cells[2].Text;
                        }
                        else
                        {
                            row1.BackColor = ColorTranslator.FromHtml("#eee");
                            row1.ToolTip = "Click to select this row.";
                        }
                    }
                    if (Session["Voucher_No"].ToString() != "No Record Found!")
                    {
                        Response.Redirect("..\\ERP_Accounting\\AllVoucherDetails.aspx");
                    }
                }
                else
                {
                    //this.lblMessage.Text = "No Company Found!";
                    //this.lblMessage.ForeColor = Color.Maroon;
                }
            }
            
        

        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //LoadRequisitions("");
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            //LoadRequisitionsAllPending("");
        }

        protected void grdAllVoucherList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAllVoucherList.PageIndex = e.NewPageIndex;
                GetAllVoucher(approval);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

    }
}