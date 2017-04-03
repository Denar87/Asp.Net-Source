using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;

namespace ERPSSL.FA
{
    public partial class DepreciationCharge : System.Web.UI.Page
    {
        Depreciation_BLL objDepreciationBll = new Depreciation_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.txtUpToDate.Text = DateTime.Today.ToShortDateString();
                this.FillLastDepreciationDate();
            }

        }

        private void FillLastDepreciationDate()
        {
            try
            {
                string oCode = ((SessionUser)base.Session["SessionUser"]).OCode.ToString();                
                //string oCode = "8989";
                this.lblLastDepreciationDate.Text = objDepreciationBll.GetLastDepreciationDate(oCode);
            }
            catch
            {
            }
        }

        protected void btnCalculateDepreciation_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime upToDate = DateTime.Parse(this.txtUpToDate.Text);
                string OCode = ((SessionUser)base.Session["SessionUser"]).OCode.ToString();
                string systemUserId = ((SessionUser)base.Session["SessionUser"]).UserId.ToString();               
                //string systemUserId = "E077F2DC-9C9B-4C12-B4B4-8578C591CB51";
                //string OCode = "8989";
                if (objDepreciationBll.CalculateDepreciation("Temp", upToDate, OCode, systemUserId))
                {
                    //this.LoadTemporaryDepreciationData(systemUserId);
                    this.lblDepreciationStatus.Text = "<font color='green'>Depreciation has been charged successfully</font>";
                    //this.btnPost.Visible = false;
                }
                else
                {
                    this.lblDepreciationStatus.Text = "<font color='red'>Error in posting depreciation.</font>";
                }
            }
            catch
            {
                
            }
        }
    }
}