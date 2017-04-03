using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV
{
    public partial class ProductGroup : System.Web.UI.Page
    {
        GroupBLL groupBll = new GroupBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetAllProductGroup();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetAllProductGroup()
        {
            try
            {
                List<Inv_ProductGroup> groups = groupBll.GetAllGroup();
                if (groups.Count > 0)
                {
                    grdProductGroup.DataSource = groups;
                    grdProductGroup.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_ProductGroup groupObj = new Inv_ProductGroup();
                groupObj.GroupName = txtGroupName.Text;

                //if (groupBll.GetGroupByName(groupObj.GroupName) != null)
                //{
                //    lblMessage.Text = "Data Already in the List";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //    txtGroupName.Text = "";
                //    return;
                //}

                int Groupcount = (from grp in _context.Inv_ProductGroup
                                  where grp.GroupName == groupObj.GroupName
                                  select grp.GroupId).Count();
                if (Groupcount == 0)
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        //groupObj.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        groupObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                        int result = groupBll.InsertGroup(groupObj);
                        if (result == 1)
                        {
                            // lblMessage.Text = "Data Saved Successfully";
                            // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }
                        else
                        {
                            // lblMessage.Text = "Data Saving Failure";
                            //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
                        int groupId = Convert.ToInt32(hdfProductGroupID.Value);

                        int result = groupBll.UpdateGroup(groupObj, groupId);
                        if (result == 1)
                        {
                            //  lblMessage.Text = "Data Updated Successfully";
                            //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        }
                        else
                        {
                            // lblMessage.Text = "Data Updating failure";
                            //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                        }
                    }
                    GetAllProductGroup();
                    txtGroupName.Text = "";
                    txtGroupName.Focus();
                    btnSubmit.Text = "Submit";
                }
                else
                {
                    //lblMessage.Text = "Data Already Exist";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                    txtGroupName.Text = "";
                    txtGroupName.Focus();
                    btnSubmit.Text = "Submit";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ImgGroupEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_ProductGroup> groups = new List<Inv_ProductGroup>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string groupId = "";
                Label lblGroupId = (Label)grdProductGroup.Rows[row.RowIndex].FindControl("lblGroupId");
                if (lblGroupId != null)
                {
                    groupId = lblGroupId.Text;
                    groups = groupBll.GetGroupById(groupId);

                    if (groups.Count > 0)
                    {
                        foreach (Inv_ProductGroup agroup in groups)
                        {
                            hdfProductGroupID.Value = agroup.GroupId.ToString();
                            txtGroupName.Text = agroup.GroupName;
                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdProductGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductGroup.PageIndex = e.NewPageIndex;
            GetAllProductGroup();
        }
    }
}