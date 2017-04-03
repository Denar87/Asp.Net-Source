using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using ERPSSL.Visitor.BLL;

namespace ERPSSL.Visitor
{
    public partial class VisitorList : System.Web.UI.Page
    {
        VisitorInfoBLL sVisitorInfoBLL = new VisitorInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetVisitor();
                fromdate.Visible = false;
                todate.Visible = false;
                Searchbox.Visible = true;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           

            if (ckDatewise.Checked)
            {
                DateTime fromdate = Convert.ToDateTime(txtvisitfrom.Text);
                DateTime todate = Convert.ToDateTime(txtvisitTo.Text);
                List<Visitor_VisitorInfo> visitorList = sVisitorInfoBLL.GetAllVisitorByDate(fromdate, todate);

                if (visitorList.Count > 0)
                {
                    grVisitorInfo.DataSource = visitorList.ToList();
                    grVisitorInfo.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found')", true);
                    grVisitorInfo.DataSource = null;
                    grVisitorInfo.DataBind();
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string SearchItem = txtSearch.Text;
                string[] SearchItem = this.txtSearch.Text.Split('-');
                List<Visitor_VisitorInfo> visitorList = sVisitorInfoBLL.GetAllVisitorBySearchItem(SearchItem[0], OCODE);

                if (visitorList.Count > 0)
                {
                    grVisitorInfo.DataSource = visitorList.ToList();
                    grVisitorInfo.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found')", true);
                    grVisitorInfo.DataSource = null;
                    grVisitorInfo.DataBind();
                }
            }

           
        }

        protected void ckDatewise_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDatewise.Checked)
            {
                fromdate.Visible = true;
                todate.Visible = true;
                Searchbox.Visible = false;

            }
            else
            {
                fromdate.Visible = false;
                todate.Visible = false;
                Searchbox.Visible = true;

            }
        }     
      


    }
}