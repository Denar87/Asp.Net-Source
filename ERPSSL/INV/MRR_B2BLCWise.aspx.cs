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

namespace ERPSSL.INV
{
    public partial class MRR_B2BLCWise : System.Web.UI.Page
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
                    btnProcess.Visible = false;
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
            List<ItemList> result = _orderSheetbll.GetBackToBackForINV(Ocode);
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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void rowLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                {
                    CheckBox chk = (CheckBox)gvRow.FindControl("rowLevelCheckBox");

                    if (chk.Checked)
                    {
                        TextBox lblBalanceQuantity = ((TextBox)gvRow.FindControl("txtReceivedQty"));
                        if (lblBalanceQuantity.Text != "")
                        {

                            double balancequantity = Convert.ToDouble(lblBalanceQuantity.Text);
                            if (balancequantity <= 0)
                            {
                                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                                rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox       
                            }
                        }
                        else
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                            rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridBackToBack_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                if (e.CommandName == "Select")
                {
                    // Retrieve the row index stored in the 
                    // CommandArgument property.
                    string id = Convert.ToString(e.CommandArgument);
                    var result = _orderSheetbll.GetBackToBack_ForINVById(id);
                    if (result.Count > 0)
                    {
                        grvOrderSheetEntry.DataSource = result;
                        grvOrderSheetEntry.DataBind();
                        btnProcess.Visible = true;


                    }
                    else
                    {
                        grvOrderSheetEntry.DataSource = null;
                        grvOrderSheetEntry.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                List<LC_BackToBack> lstLC_BackToBack = new List<LC_BackToBack>();
                bool status = true;
                bool CheckStatus = false;

                foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                {

                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    if (rowChkBox.Checked == true)
                    {
                        CheckStatus = true;
                    }
                }
                if (CheckStatus)
                {

                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                    {

                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        if (rowChkBox.Checked == true)
                        {

                            TextBox txtbxReceive = (TextBox)gvRow.FindControl("txtReceivedQty");
                            if (txtbxReceive.Text != "")
                            {
                                // Label lblLastRceceive = ((Label)gvRow.FindControl("lblLastReceive"));
                                //  double lastReceive = Convert.ToDouble(lblLastRceceive.Text);


                                double ReceiveQty = Convert.ToDouble(txtbxReceive.Text);

                                Label lblOrderQty = ((Label)gvRow.FindControl("lblBalanceQty"));
                                double Poqty = Convert.ToDouble(lblOrderQty.Text);

                                if (ReceiveQty == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Quantity!')", true);
                                    status = false;
                                    break;

                                }
                                else if (ReceiveQty > Poqty)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Quantity!')", true);
                                    status = false;
                                    break;

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Receive Qty!')", true);
                                status = false;
                                break;
                            }
                        }
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

                            objLC_BackToBack.B2BId = Convert.ToInt32(lblId.Text);
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}