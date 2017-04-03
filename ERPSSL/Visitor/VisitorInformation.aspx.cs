using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Merchandising.DAL.Repository;
using ERPSSL.Visitor.BLL;
using ERPSSL.Visitor.DAL;

namespace ERPSSL.Visitor
{
    public partial class VisitorInformation : System.Web.UI.Page
    {

        VisitorInfoBLL sVisitorInfoBLL = new VisitorInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    lbldate.Text =Convert.ToString(DateTime.Now);
                    GetVisitor();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetVisitor()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            var visitor = sVisitorInfoBLL.GetAllVisitor(OCODE).ToList();
            if (visitor.Count > 0)
            {
                grVisitorInfo.DataSource = visitor.ToList();
                grVisitorInfo.DataBind();
            }

        }      

        //Load  GMT Items--------------------------------------####################------------------------------------------------------
        //public void LoadGMTItems()
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<LC_GmtItem> row = aOrderItemsBLL.GetAllGMTItems(ocode);

        //        if (row != null)
        //        {
        //            gmtItemDropDownList.DataSource = row.ToList();
        //            gmtItemDropDownList.DataTextField = "Gmt_Name";
        //            gmtItemDropDownList.DataValueField = "GmtItem_Id";
        //            gmtItemDropDownList.DataBind();
        //            gmtItemDropDownList.AppendDataBoundItems = false;
        //            gmtItemDropDownList.Items.Insert(0, new ListItem("--Select GMT Items--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
           

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Visitor_VisitorInfo sVisitor_VisitorInfo = new Visitor_VisitorInfo();

            sVisitor_VisitorInfo.VisitorName = txtVisitorName.Text;
            sVisitor_VisitorInfo.FromAddress = txtformAddress.Text;
            sVisitor_VisitorInfo.Phone = txtPhone.Text;
            sVisitor_VisitorInfo.ToWhom = txtToWhom.Text;
            sVisitor_VisitorInfo.Purpose = txtPurpose.Text;
            sVisitor_VisitorInfo.CardNo = Convert.ToInt32(txtcardNo.Text);
            sVisitor_VisitorInfo.InTime = txtInTime.Text;
            sVisitor_VisitorInfo.OutTime = txtOutTime.Text;
            sVisitor_VisitorInfo.VDate = DateTime.Now;

            sVisitor_VisitorInfo.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
            sVisitor_VisitorInfo.Edit_Date = DateTime.Now;
            sVisitor_VisitorInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            sVisitor_VisitorInfo.Create_Date = DateTime.Now;

            if (btnSave.Text == "Save")
            {


                int result = sVisitorInfoBLL.insertVisitorInfo(sVisitor_VisitorInfo);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Insert Successfully')", true);
                    GetVisitor();
                    clear();

                  

                }
            }
            else
            {
                int VisitorId = Convert.ToInt32(hidvisitorid.Value);
                int VisitorUpdate = sVisitorInfoBLL.UpdateVisitorInfo(sVisitor_VisitorInfo, VisitorId);
                if (VisitorUpdate == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    GetVisitor();
                    clear();
                }
            }

          

        }
        public void clear()
        {
            txtVisitorName.Text = "";
            txtformAddress.Text = "";
            txtPhone.Text = "";
            txtToWhom.Text = "";
            txtPurpose.Text = "";
            txtcardNo.Text = "";
            txtInTime.Text = "";
            txtOutTime.Text = "";
        }

        protected void imgbtnVisitorEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<Visitor_VisitorInfo> visitors = new List<Visitor_VisitorInfo>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string visitorId = "";
                Label lblV_ID = (Label)grVisitorInfo.Rows[row.RowIndex].FindControl("lblV_ID");
                if (lblV_ID != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    visitorId = lblV_ID.Text;
                    visitors = sVisitorInfoBLL.getVisitorByVisitoridandCode(visitorId, OCODE);

                    if (visitors.Count > 0)
                    {
                        foreach (Visitor_VisitorInfo visit in visitors)
                        {
                            hidvisitorid.Value = visit.V_ID.ToString();
                            txtVisitorName.Text = visit.VisitorName;
                            txtformAddress.Text = visit.FromAddress;
                            txtPhone.Text = visit.Phone;
                            txtToWhom.Text = visit.ToWhom;
                            txtPurpose.Text = visit.Purpose;
                            txtcardNo.Text = Convert.ToString(visit.CardNo);
                            txtInTime.Text = visit.InTime;
                            txtOutTime.Text = visit.OutTime;

                            if (btnSave.Text == "Save")
                            {
                                btnSave.Text = "Update";
                            }
                        }
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