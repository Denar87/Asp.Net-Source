using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL.Repository;

namespace ERPSSL.Merchandising
{
    public partial class OrderItems : System.Web.UI.Page
    {

        OrderItemsBLL aOrderItemsBLL = new OrderItemsBLL();

        int gmtItemsId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    WorkOrderId.Text = Session["OederEntryId"].ToString();
                    WorkOrder.Text = "Order No:- " + Session["OrderNo"].ToString();
                    StyleId.Text = Session["StyleId"].ToString();
                    Style.Text = " Style:- " + Session["Style"].ToString();
                    BuyerId.Text = Session["BuyerId"].ToString();
                    Buyer.Text = " Buyer:- " + Session["Buyer"].ToString();
                    OrderQuantity.Text = " Quantity:- " + Session["Quantity"].ToString();

                    LoadGMTItems();
                    LoadDataInGridView();
                    LoadConfirmDataInGridView();
                    LoadColor();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadColor()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Color> row = aOrderItemsBLL.GetAllColor(OCode);

                if (row != null)
                {
                    ddlcolor.DataSource = row.ToList();
                    ddlcolor.DataTextField = "ColorName";
                    ddlcolor.DataValueField = "ColorId";
                    ddlcolor.DataBind();
                    ddlcolor.Items.Insert(0, new ListItem("--Select Color--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gmtItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gmtItemCheckBox.Checked == true)
            {
                gmtItemDropDownList.Visible = false;
                gmtItemTextBox.Visible = true;
            }
            else if (gmtItemCheckBox.Checked == false)
            {
                gmtItemDropDownList.Visible = true;
                gmtItemTextBox.Visible = false;
            }
        }

        //Load  GMT Items--------------------------------------####################------------------------------------------------------
        public void LoadGMTItems()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_GmtItem> row = aOrderItemsBLL.GetAllGMTItems(ocode);

                if (row != null)
                {
                    gmtItemDropDownList.DataSource = row.ToList();
                    gmtItemDropDownList.DataTextField = "Gmt_Name";
                    gmtItemDropDownList.DataValueField = "GmtItem_Id";
                    gmtItemDropDownList.DataBind();
                    gmtItemDropDownList.AppendDataBoundItems = false;
                    gmtItemDropDownList.Items.Insert(0, new ListItem("--Select GMT Items--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Add Items To Temporary Table
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (gmtItemCheckBox.Checked == false)
                {
                    if (gmtItemDropDownList.SelectedItem.Text == "--Select GMT Items--")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select GMT Items');", true);
                        return;
                    }
                    else
                    {
                        gmtItemsId = Convert.ToInt32(gmtItemDropDownList.SelectedValue.ToString());
                    }

                }
                else if (gmtItemCheckBox.Checked == true)
                {

                    if (gmtItemTextBox.Text == "")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert GMT Item');", true);
                        return;
                    }
                    else
                    {
                        LC_GmtItem aLC_GmtItem = new LC_GmtItem();

                        aLC_GmtItem.Gmt_Name = gmtItemTextBox.Text;
                        aLC_GmtItem.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                        aLC_GmtItem.CreateDate = DateTime.Now;
                        aLC_GmtItem.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                        gmtItemsId = aOrderItemsBLL.SaveGMTItems(aLC_GmtItem);
                    }
                }


                LC_Size_Temp aLC_Size_Temp = new LC_Size_Temp();

                aLC_Size_Temp.OrderNo = Convert.ToInt32(WorkOrderId.Text);
                aLC_Size_Temp.StyleNo = Convert.ToInt32(StyleId.Text);
                aLC_Size_Temp.GMTItem = Convert.ToInt32(gmtItemDropDownList.SelectedValue.ToString());
                aLC_Size_Temp.Articale = articleTextBox.Text;
                aLC_Size_Temp.ColorID = Convert.ToInt32(ddlcolor.SelectedValue);
                aLC_Size_Temp.Size = sizeTextBox.Text;
                aLC_Size_Temp.Qty = Convert.ToInt32(quantityTextBox.Text);
                aLC_Size_Temp.Price = Convert.ToDecimal(rateTextBox.Text);
                aLC_Size_Temp.TotalAmount = Convert.ToDecimal(totalAmountTextBox.Text);
                aLC_Size_Temp.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                aLC_Size_Temp.CreateDate = DateTime.Now;
                aLC_Size_Temp.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                int result = aOrderItemsBLL.Save_LC_To_Temp(aLC_Size_Temp);

                if (result != 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Item Added Successfully!!')", true);
                }
                else if (result == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Item Not Added');", true);
                    return;
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Added');", true);
                return;
            }




            LoadDataInGridView();
            clear();

        }


        //------------------------------------------######Code For Load Data In Grid######----------------------------------------------------------------
        public void LoadDataInGridView()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            Guid User = ((SessionUser)Session["SessionUser"]).UserId;
            int workOrderId = Convert.ToInt32(WorkOrderId.Text);

            var loadData = aOrderItemsBLL.LoadDataForGrid(ocode, User, workOrderId);

            if (loadData.Count > 0)
            {
                grdorder.DataSource = loadData.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }

        public void LoadConfirmDataInGridView()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            Guid User = ((SessionUser)Session["SessionUser"]).UserId;
            int workOrderId = Convert.ToInt32(WorkOrderId.Text);

            var loadData = aOrderItemsBLL.LoadConfirmDataForGrid(ocode, User, workOrderId);

            if (loadData.Count > 0)
            {
                AllConfirmOrderGridView.DataSource = loadData.ToList();
                AllConfirmOrderGridView.DataBind();
            }
            else
            {
                AllConfirmOrderGridView.DataSource = null;
                AllConfirmOrderGridView.DataBind();
            }
        }



        protected void rateTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (quantityTextBox.Text == "")
                {
                    totalAmountTextBox.Text = "";
                }
                else if (quantityTextBox.Text != "")
                {
                    totalAmountTextBox.Text = (Convert.ToInt32(quantityTextBox.Text) * Convert.ToDouble(rateTextBox.Text)).ToString("0.00");
                }
            }
            catch
            {
                totalAmountTextBox.Text = "";
            }
        }

        protected void imgbtnDel_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblSizeID = (Label)grdorder.Rows[row.RowIndex].FindControl("lblSizeID");

            int id = Convert.ToInt32(lblSizeID.Text);

            int result = aOrderItemsBLL.DeleteItem(id);

            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Item Deleted Successfully!!')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Deleted!!');", true);
            }

            LoadDataInGridView();
            clear();
        }


        //------------------------------------------------------------Save All Data----------------------------------------------------------------------------
        protected void saveButton_Click(object sender, EventArgs e)
        {
            // --------------------------############## ---------------  First Load Data To The List ---------------------------------------------------------
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            Guid User = ((SessionUser)Session["SessionUser"]).UserId;
            int workOrderId = Convert.ToInt32(WorkOrderId.Text);

            List<ItemsRepo> loadData = aOrderItemsBLL.LoadDataForGrid(ocode, User, workOrderId);

            foreach (ItemsRepo aItemsRepo in loadData)
            {
                LC_Size aLC_Size = new LC_Size();

                aLC_Size.OrderNo = aItemsRepo.OrderNo;
                aLC_Size.StyleNo = aItemsRepo.StyleNo;
                aLC_Size.GMTItem = aItemsRepo.GMTId;
                aLC_Size.Articale = aItemsRepo.ArticleNo;
                aLC_Size.ColorID = aItemsRepo.ColorID;
                aLC_Size.Size = aItemsRepo.Size;
                aLC_Size.Qty = aItemsRepo.Quantity;
                aLC_Size.Price = aItemsRepo.Rate;
                aLC_Size.TotalAmount = aItemsRepo.TotalAmount;
                aLC_Size.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                aLC_Size.CreateDate = DateTime.Now;
                aLC_Size.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                aOrderItemsBLL.SaveIntoOriginal(aLC_Size);

            }

            foreach (ItemsRepo aItemsRepo in loadData)
            {
                aOrderItemsBLL.DeleteItem(aItemsRepo.SizeId);
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Item Confirmed!!')", true);

            LoadDataInGridView();
            LoadConfirmDataInGridView();

        }

        //Clear All Field

        public void clear()
        {
            articleTextBox.Text = "";
            //colorTextBox.Text = "";
            sizeTextBox.Text = "";
            quantityTextBox.Text = "";
            rateTextBox.Text = "";
            totalAmountTextBox.Text = "";

            LoadGMTItems();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewOrderEntry.aspx");
        }

        int totalQuantity = 0;
        decimal totalOfAllTotalAmount = 0;

        protected void AllConfirmOrderGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalQuantity += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                totalOfAllTotalAmount +=  Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                // If row type is footer, show calculated total value
                // Since this example uses sales in dollars, I formatted output as currency
                e.Row.Cells[7].Text =totalQuantity.ToString();
                e.Row.Cells[9].Text = totalOfAllTotalAmount.ToString();

              
            }
        }

        //protected void AllConfirmOrderGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    // check row type

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        totalQuantity += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
        //    }
        //    else if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        // If row type is footer, show calculated total value
        //        // Since this example uses sales in dollars, I formatted output as currency
        //        e.Row.Cells[1].Text = String.Format("{0:c}", totalQuantity);
        //    }
        //}

    }
}