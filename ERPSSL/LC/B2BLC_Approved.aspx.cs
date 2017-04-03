using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC
{
    public partial class B2BLC_Approved : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getdateforLoad();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void getdateforLoad()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            List<ItemList> result = _orderSheetbll.GetBackToBackByOCode(Ocode);
            if (result.Count > 0)
            {
                gridBackToBack.DataSource = result;
                gridBackToBack.DataBind();
              

            }
            else
            {
                gridBackToBack.DataSource = null;
                gridBackToBack.DataBind();
            }
        
        }

     

       
        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grvOrderSheetEntry.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

       
      

     

        protected void gridBackToBack_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                string id = Convert.ToString(e.CommandArgument);
                var result = _orderSheetbll.GetBackToBackByID(id);
                if (result.Count > 0)
                {
                    grvOrderSheetEntry.DataSource = result;
                    grvOrderSheetEntry.DataBind();


                }
                else
                {
                    grvOrderSheetEntry.DataSource = null;
                    grvOrderSheetEntry.DataBind();
                }

            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                List<LC_BackToBack> lstLC_BackToBack = new List<LC_BackToBack>();
                if (txtAccNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Approved no')", true);
                    return;
                }
                if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Insert Date')", true);
                    return;
                }

                foreach (GridViewRow gvr in grvOrderSheetEntry.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvr.FindControl("rowLevelCheckBox"));
                    if (rowChkBox.Checked == true)
                    {
                        LC_BackToBack objLC_BackToBack = new LC_BackToBack();
                        Label lblId = (Label)gvr.FindControl("Id");
                        Label lblblProductId = (Label)gvr.FindControl("lblProductId");
                        Label lblBalanceQty = (Label)gvr.FindControl("lblBalanceQty");

                        DropDownList ddlStatus = (DropDownList)gvr.FindControl("ddlStatus");
                        string Status = ddlStatus.SelectedItem.Text;


                        objLC_BackToBack.B2BId = Convert.ToInt32(lblId.Text);

                        if (ddlStatus.SelectedItem.Text == "Approved")
                        {
                            objLC_BackToBack.ApproveStatus = "Approved";
                        }
                        else
                        {
                            objLC_BackToBack.ApproveStatus = "Pending";
                        }
                        objLC_BackToBack.ApproveDate = Convert.ToDateTime(txtDate.Text.ToString());
                        objLC_BackToBack.ApproveNo = txtAccNo.Text;
                        //objLC_BackToBack.EditUser =((Guid)Session["UserID"]);

                        lstLC_BackToBack.Add(objLC_BackToBack);
                    }
                }

                int result = _orderSheetbll.BackToBackApprove(lstLC_BackToBack);
                getdateforLoad();
                grvOrderSheetEntry.DataSource = null;
                grvOrderSheetEntry.DataBind();
                //LoadRequisitionsItem(reqNo);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data recorded successfully')", true);
                //lblMessage.Text = "Data Recorded Successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
                // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding Failure!')", true);
                //lblMessage.Text = "<font color='red'>Data Adding Failure!</font>";
            }
        }
       

       
    }
}