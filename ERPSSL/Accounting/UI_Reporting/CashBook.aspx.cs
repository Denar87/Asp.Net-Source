﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BOL;
using System.Drawing;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class CashBook : System.Web.UI.Page
    {
        rpt_CashBook_BLL objLCashBLL = new rpt_CashBook_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string dateFrom, dateTo, GetType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                GetType = "A";
                //------------------------------------------------------
                RoleID = Session["RoleID"].ToString();
                PageID = "8";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetCashBook(dateFrom, dateTo, GetType);
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

        private void GetCashBook(string dateFrom, string dateTo, string GetType)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                Hashtable ht = new Hashtable();
                ht.Add("GetType", GetType);
                ht.Add("DateFrom", dateFrom);
                ht.Add("DateTo", dateTo);
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);

                DataTable dt = objLCashBLL.GetCashBook(ht);
                if (dt.Rows.Count > 0)
                {
                    dtg_list.DataSource = dt;
                    dtg_list.DataBind();
                }
                else
                {
                    ht.Clear();
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "No record Found!!";
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
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
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                if (Convert.ToDateTime(dateFrom) <= Convert.ToDateTime(dateTo))
                {
                    if (rdbViewAll.Checked)
                    {
                        dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                        dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                        GetType = "A";
                    }
                    else
                    {
                        dateFrom = String.Format("{0:MM/dd/yyyy}", dtpFrom.Text);
                        dateTo = String.Format("{0:MM/dd/yyyy}", dtpTo.Text);
                        GetType = "p";
                    }

                    GetCashBook(dateFrom, dateTo, GetType);
                }
                else
                {
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "To Date should be greater than From Date.";
                    this.lblMessage.ForeColor = Color.White;
                    messagePanel.BackColor = Color.Red;
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
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                string rptCriteria = string.Empty;
                if (Convert.ToDateTime(dateFrom) <= Convert.ToDateTime(dateTo))
                {
                    if (rdbViewAll.Checked)
                    {
                        dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                        dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                        GetType = "A";
                        rptCriteria = "All Records.";
                    }
                    else
                    {
                        dateFrom = String.Format("{0:MM/dd/yyyy}", dtpFrom.Text);
                        dateTo = String.Format("{0:MM/dd/yyyy}", dtpTo.Text);
                        GetType = "p";
                        rptCriteria = "All Records of " + dateFrom + " to " + dateTo;
                    }

                    PrintCashBook(dateFrom, dateTo, GetType, rptCriteria);
                }
                else
                {
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "To Date should be greater than From Date.";
                    this.lblMessage.ForeColor = Color.White;
                    messagePanel.BackColor = Color.Red;
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
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void PrintCashBook(string dateFrom, string dateTo, string GetType, string rptCriteria)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("DateTo", dateTo);
            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLCashBLL.Rpt_GetCashBook(ht);
            if (dt.Rows.Count > 0)
            {
                Session["ReportTitle"] = "Cash Book";
                Session["ReportCriteria"] = rptCriteria;
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_CashBook";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\CashBook.rdlc";
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
                this.lblMessage.Text = "No record Found!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void rdbViewdtod_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
            dtpTo.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
        }

    }
}