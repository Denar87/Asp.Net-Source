using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class YarnCount : System.Web.UI.Page
    {
        YarnCount_BLL obj_Yarn_BLL = new YarnCount_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetYarnCount();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void btnYarnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtYarnCount.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Yarn Count!')", true);

                }
                else
                {
                    LC_Yarn_Count objyarn = new LC_Yarn_Count();

                    objyarn.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objyarn.Yarn_Count = txtYarnCount.Text;
                    objyarn.Status = drpStatus.SelectedItem.Text;

                    if (btnYarnSubmit.Text == "Submit")
                    {

                        if (IsExist(objyarn.Yarn_Count))
                        {
                            objyarn.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                            objyarn.CreateDate = DateTime.Now;
                            int result = obj_Yarn_BLL.InsertYarnCount(objyarn);
                            if (result == 1)
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        }
                    }
                    else
                    {
                        if (hidYarnName.Value != txtYarnCount.Text)
                        {
                            if (IsExist(objyarn.Yarn_Count))
                            {
                                objyarn.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                                objyarn.EDIT_DATE = DateTime.Now;

                                int yarnId = Convert.ToInt32(hidYarnId.Value);
                                int result = obj_Yarn_BLL.UpdateYarnCount(objyarn, yarnId);
                                if (result == 1)
                                {

                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                                }
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                            }

                        }
                        else
                        {
                            objyarn.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            objyarn.EDIT_DATE = DateTime.Now;

                            int yarnId = Convert.ToInt32(hidYarnId.Value);
                            int result = obj_Yarn_BLL.UpdateYarnCount(objyarn, yarnId);
                            if (result == 1)
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                            }
                        }




                    }
                    GetYarnCount();
                    ClearYarnCountUi();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetYarnCount()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var yarns = obj_Yarn_BLL.GetAllYarnCount(OCODE).ToList();
                if (yarns.Count > 0)
                {

                    gridYarnCount.DataSource = yarns.ToList();
                    gridYarnCount.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearYarnCountUi()
        {
            try
            {               
                txtYarnCount.Text = "";
                drpStatus.ClearSelection();
                btnYarnSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool IsExist(string yarnCount)
        {
            try
            {
                ERPSSL_MerchandisingEntities _context = new ERPSSL_MerchandisingEntities();

                LC_Yarn_Count objYarn = new LC_Yarn_Count();

                bool status = false;
                int count = (from yarn in _context.LC_Yarn_Count
                             where yarn.Yarn_Count == yarnCount
                             select yarn.YarnCount_ID).Count();
                if (count == 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void gridYarnCount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridYarnCount.PageIndex = e.NewPageIndex;
            GetYarnCount();
        }

        protected void imgbtnYarnCountEdit_Click1(object sender, ImageClickEventArgs e)
        {
            List<LC_Yarn_Count> yarnCnt = new List<LC_Yarn_Count>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string yarnId = "";
                Label lblSectionId = (Label)gridYarnCount.Rows[row.RowIndex].FindControl("lblYarnCountId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    yarnId = lblSectionId.Text.ToString();
                    yarnCnt = obj_Yarn_BLL.GetYarnCountInfoByYarnId(yarnId, OCODE);

                    if (yarnCnt.Count > 0)
                    {
                        var yarn = yarnCnt.FirstOrDefault();
                        hidYarnId.Value = yarn.YarnCount_ID.ToString();
                        hidYarnName.Value = txtYarnCount.Text = yarn.Yarn_Count;
                        drpStatus.SelectedValue = yarn.Status;


                        if (btnYarnSubmit.Text == "Submit")
                        {
                            btnYarnSubmit.Text = "Update";
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