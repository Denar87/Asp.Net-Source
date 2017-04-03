using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.ERP_Accounting.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.ERP_Accounting.Repository;
using System.Drawing;
using System.Data.SqlClient;

namespace ERPSSL.ERP_Accounting
{
    public partial class AllVoucherDetails : System.Web.UI.Page
    {
        Voucher_Bll aVoucher_Bll = new Voucher_Bll();
        string approval = string.Empty;
        string Edit_User, CompanyCode, OCode;
        AccConfiguration_BLL objCofg = new AccConfiguration_BLL();
        private ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(((SessionUser)Session["SessionUser"]).UserId) != null && Convert.ToString(((SessionUser)Session["SessionUser"]).Company_Code) != null && Convert.ToString(((SessionUser)Session["SessionUser"]).OCode) != null)
            {
                txtVoucherNo.ReadOnly = true;
                txtVoucherDate.ReadOnly = true;
                Edit_User = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);
                CompanyCode = ((SessionUser)Session["SessionUser"]).Company_Code;
                OCode = ((SessionUser)Session["SessionUser"]).OCode;
                txtVoucherNo.Text = Convert.ToString(Session["Voucher_No"]);
                txtNarration.Text = Convert.ToString(Session["Narration"]);
                txtVoucherDate.Text = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Session["Voucher_Date"]));

                approval = Convert.ToString(Session["Approval"]);
                if (approval == "UN_AP")
                {
                    BtnApprove.Enabled = true;
                    BtnDiscard.Enabled = true;
                }
                else
                {
                    BtnApprove.Enabled = false;
                    BtnDiscard.Enabled = false;
                }

                if (!IsPostBack)
                {
                    GetAllVoucher(approval);
                    txtVoucherDate.Text = DateTime.Now.ToShortDateString();
                    txtNarration.Text = Session["Narration"].ToString();
                }
            }
            else
            {
                Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void GetAllVoucher(string approval)
        {

            grvVoucherDetails.DataSource = aVoucher_Bll.GetAllVoucherDetail(approval, txtVoucherNo.Text, CompanyCode, OCode);
            grvVoucherDetails.DataBind();
            
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

        string id, name, type;
        protected void grvVoucherDetails_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string reqNo = e.CommandArgument.ToString();
                if (e.CommandName == "select")
                {
                    foreach (GridViewRow gvRow in grvVoucherDetails.Rows)
                    {
                        Label lblIdNo = ((Label)gvRow.FindControl("lblIdNo"));
                        Label lblModuleName = ((Label)gvRow.FindControl("lblModuleName"));
                        Label lblModuleType = ((Label)gvRow.FindControl("lblModuleType"));
                        id = lblIdNo.Text;
                        name = lblModuleName.Text;
                        type = lblModuleType.Text;
                    }

                    grvVoucherInfo.DataSource = aVoucher_Bll.GetAllVoucherDetailInfo(id, OCode, name, type);
                    grvVoucherInfo.DataBind();
                }
            }
            catch { }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void grvVoucherDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{
            //    grdRequisition.PageIndex = e.NewPageIndex;

            //    //LoadRequisitions("");
            //    LoadRequisitionsAllPending("");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("..\\ERP_Accounting\\AllVoucherList.aspx");
        }

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                var ParamempID1 = new SqlParameter("@VoucherNo", txtVoucherNo.Text);
                var ParamempID2 = new SqlParameter("@Voucher_Date", txtVoucherDate.Text);
                var ParamempID3 = new SqlParameter("@Approve_UserID", Edit_User);
                var ParamempID4 = new SqlParameter("@Edit_User", Edit_User);
                var ParamempID5 = new SqlParameter("@Company_Code", CompanyCode);
                var ParamempID6 = new SqlParameter("@OCode", OCode);

                string SP_SQL = "Vch_Enter_AC_VoucherApproval @VoucherNo,@Voucher_Date,@Approve_UserID,@Edit_User,@Company_Code,@OCode";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5, ParamempID6);

                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Voucher Number " + txtVoucherNo.Text + " Approved')", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Voucher Approved Successfully')", true);

                grvVoucherDetails.DataSource = aVoucher_Bll.GetAllVoucherDetail(approval, txtVoucherNo.Text, CompanyCode, OCode);
                grvVoucherDetails.DataBind();
            }
            catch
            {

            }
        }

        protected void BtnDiscard_Click(object sender, EventArgs e)
        {

        }

        protected void grvVoucherDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                //foreach (GridViewRow gvRow in grvVoucherDetails.Rows)
                //{
                //    Label lblIsChangable = ((Label)gvRow.FindControl("lblIsChangable"));
                //    changable = Convert.ToBoolean(lblIsChangable.Text);

                //    if (changable == true)
                //    {
                grvVoucherDetails.EditIndex = e.NewEditIndex;
                GetAllVoucher(approval);
                //}
                //else
                //{
                //    grvVoucherDetails.EditIndex = e.NewEditIndex;
                //    DropDownList cmbParticulars = null;
                //    cmbParticulars.DataSource = null;
                //    cmbParticulars.DataTextField = "Ledger_Name";
                //    cmbParticulars.DataValueField = "Ledger_Code";
                //    cmbParticulars.DataBind();
                //    GetAllVoucher(approval);
                //}

                //}

            }
            catch
            {

            }
        }

        protected void grvVoucherDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvVoucherDetails.EditIndex = -1;
            this.GetAllVoucher(approval);
        }

        protected void grvVoucherDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvVoucherDetails.Rows[e.RowIndex];

            Label lblTransactionCode = (Label)row.FindControl("lblTransactionCode");
            string trCode = lblTransactionCode.Text;

            Label lblVoucherNo = (Label)row.FindControl("lblVoucherNo");
            string VoucherNo = lblVoucherNo.Text;

            Label lblIsChangable = ((Label)row.FindControl("lblIsChangable"));
            bool changable = Convert.ToBoolean(lblIsChangable.Text);

            DropDownList cmbParticulars = (DropDownList)row.FindControl("cmbParticulars");
            string ledgerName = cmbParticulars.SelectedItem.Text.ToString();
            string ledgerCode = cmbParticulars.SelectedValue;

            if (ledgerName != null)
            {
                var objGetAc_LedgerNature = objCofg.GetAc_Ledger(OCode, CompanyCode).Where(x => x.Ledger_Code == ledgerCode).FirstOrDefault();

                tblAC_leg_LedgersTransaction_temp objtblAC_leg_LedgersTransaction_temp = new tblAC_leg_LedgersTransaction_temp();
                objtblAC_leg_LedgersTransaction_temp.Voucher_No = VoucherNo;
                objtblAC_leg_LedgersTransaction_temp.Ledger_Code = ledgerCode;
                objtblAC_leg_LedgersTransaction_temp.Particulars = ledgerName;
                objtblAC_leg_LedgersTransaction_temp.Nature = objGetAc_LedgerNature.Ledger_Nature;
                objtblAC_leg_LedgersTransaction_temp.Edit_User = Edit_User;
                objtblAC_leg_LedgersTransaction_temp.Edit_Date = DateTime.Now;

                if (changable == true)
                {
                    int ledgercount = (from ledger in _context.tblAC_leg_LedgersTransaction_temp
                                       where ledger.Ledger_Code == objtblAC_leg_LedgersTransaction_temp.Ledger_Code && ledger.Voucher_No == objtblAC_leg_LedgersTransaction_temp.Voucher_No
                                       select ledger.Transaction_ID).Count();

                    if (ledgercount == 0)
                    {
                        int result = aVoucher_Bll.UpdateACLedger(objtblAC_leg_LedgersTransaction_temp, trCode);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Ledger Name Updated Successfully')", true);
                            grvVoucherDetails.EditIndex = -1;
                            GetAllVoucher(approval);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating Error!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Ledger Already Used For This Voucher!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Access Denied!')", true);
                    grvVoucherDetails.EditIndex = -1;
                    this.GetAllVoucher(approval);
                }
            }
        }

        protected void grvVoucherDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DropDownList cmbParticulars = null;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                cmbParticulars = e.Row.FindControl("cmbParticulars") as DropDownList;
            }

            if (cmbParticulars != null)
            {
                var row = objCofg.GetAc_Ledger(OCode, CompanyCode);

                cmbParticulars.DataSource = row;
                cmbParticulars.DataTextField = "Ledger_Name";
                cmbParticulars.DataValueField = "Ledger_Code";
                cmbParticulars.DataBind();

                cmbParticulars.DataBind();
                cmbParticulars.Items.Insert(0, new ListItem("--Select--"));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    cmbParticulars.SelectedValue = ((tblAC_leg_Ledgers)(e.Row.DataItem)).Ledger_Code.ToString();
                }
            }
        }

        decimal SumAll = 0;

        protected void grvVoucherInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string totalqty = e.Row.Cells[8].Text;

                decimal grandqty = Convert.ToDecimal(totalqty);
                SumAll += grandqty;
            }
            lblTotalQty.Text = SumAll.ToString();


        }



    }
}