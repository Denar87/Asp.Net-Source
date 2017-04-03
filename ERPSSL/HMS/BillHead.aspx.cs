using ERPSSL.HMS.BLL;
using ERPSSL.HMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HMS
{
    public partial class BillHead : System.Web.UI.Page
    {
        BillHead_BLL objHead_BLL = new BillHead_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetBillHeadInfo();
                    GetBillCategoryList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
      
        protected void btnBillHeadSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtHead.Text == "")
                {
                    
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Bill Head !!')", true);

                }
                else if (ddlCategory.SelectedItem.Text =="")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Bill Category !!')", true);
                }
                else if (txtPrice.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Price!!')", true);
                }
                else
                {
                    HMS_BillHead objHead = new HMS_BillHead();
                    
                    objHead.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objHead.Bill_Head_Name = txtHead.Text;
                    objHead.HMS_CategoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString ());
                    objHead.Price =Convert.ToDecimal(txtPrice.Text);

                    if (btnBillHeadSubmit.Text == "Submit")
                    {
                        int catId = Convert.ToInt32(objHead.HMS_CategoryId);

                        if (IsExist(objHead.Bill_Head_Name,catId))
                        {
                            objHead.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                            objHead.Create_Date = DateTime.Now;
                            int result = objHead_BLL.InsertBillHead(objHead);
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
                        if (hidHeadName.Value != txtHead.Text)
                        {
                            int catId = Convert.ToInt32(objHead.HMS_CategoryId);

                            if (IsExist(objHead.Bill_Head_Name,catId))
                            {
                                objHead.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                                objHead.Edit_Date = DateTime.Now;

                                int headId = Convert.ToInt32(hidHeadId.Value);
                                int result = objHead_BLL.UpdateBillHead(objHead, headId);
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
                            objHead.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                            objHead.Edit_Date = DateTime.Now;

                            int headId = Convert.ToInt32(hidHeadId.Value);
                            int result = objHead_BLL.UpdateBillHead(objHead, headId);
                            if (result == 1)
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                            }
                        }




                    }
                    GetBillHeadInfo();
                    ClearBillHeadUi();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetBillHeadInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var head = objHead_BLL.GetBillHead(OCODE).ToList();
                if (head.Count > 0)
                {
                    
                    gridviewBillHead.DataSource = head.ToList();
                    gridviewBillHead.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearBillHeadUi()
        {
            try
            {
                txtHead.Text = "";
                ddlCategory.ClearSelection();
                txtPrice.Text = "";
                btnBillHeadSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool IsExist(string headName, int catId)
        {
            try
            {
                ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

                bool status = false;
                int count = (from head in _context.HMS_BillHead
                             where head.Bill_Head_Name == headName && head.HMS_CategoryId ==catId 
                             select head.HMS_Bill_Head_Id).Count();
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



        protected void imgbtnBillCategoryEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<HMS_BillHead> objhead = new List<HMS_BillHead>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string headId = "";
                Label lblSectionId = (Label)gridviewBillHead.Rows[row.RowIndex].FindControl("lblHeadId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    headId = lblSectionId.Text.ToString();
                    objhead = objHead_BLL.GetBillHeadByheadId(headId, OCODE);
                    
                    if (objhead.Count > 0)
                    {
                        var bill = objhead.FirstOrDefault();
                        hidHeadId.Value = bill.HMS_Bill_Head_Id.ToString();
                        hidHeadName.Value = txtHead.Text = bill.Bill_Head_Name;
                        txtPrice.Text = bill.Price.ToString ();
                        ddlCategory.SelectedValue =bill.HMS_CategoryId.ToString ();
                        if (btnBillHeadSubmit.Text == "Submit")
                        {
                            btnBillHeadSubmit.Text = "Update";
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetBillCategoryList()
        {
            try
            {
                List<HMS_BillCategory> row = objHead_BLL.GetCategoryList();
                
                if (row != null)
                {
                    ddlCategory.DataSource = row.ToList();
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "HMS_CategoryId";
                    ddlCategory.DataBind();
                    ddlCategory.AppendDataBoundItems = false;
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gridviewBillHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewBillHead.PageIndex = e.NewPageIndex;
            GetBillHeadInfo();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            var billHead = objHead_BLL.GetBillHead(OCODE).ToList();

            if (billHead.Count > 0)
            {
                Session["rptDs"] = "ds_allBillHead";
                Session["rptDt"] = billHead;
                Session["rptFile"] = "/HMS/Reports/HMS_Rpt_AllBillHead.rdlc";
                Session["rptTitle"] = "All Bill Head";
                Response.Redirect("Report_Viewer.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
            }
        }
  
    }
}