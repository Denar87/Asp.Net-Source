﻿using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class LastMonthVisit : System.Web.UI.Page
    {
        MarketingInfoBLL aMarketingInfoBLL = new MarketingInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    LoadLastMonthVisit();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }


        public void LoadLastMonthVisit()
        {
            List<MarketingProjectStage> aLastMonthVisitList = aMarketingInfoBLL.GetLastMonthVisitList();

            grdorder.DataSource = aLastMonthVisitList;
            grdorder.DataBind();
        }

        protected void imgbtnOrderSheetEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

            Label lblMarketingId_No = (Label)grdorder.Rows[row.RowIndex].FindControl("lblMarketingId_No");

            int MarketingId_No = Convert.ToInt16(lblMarketingId_No.Text);


            Session["MarketingId"] = MarketingId_No;

            Response.Redirect("ViewLastMonthVisit.aspx");
        }


    }
}