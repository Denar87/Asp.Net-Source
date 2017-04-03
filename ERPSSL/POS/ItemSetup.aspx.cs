using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.POS.BLL;
using ERPSSL.POS.DAL;

namespace ERPSSL.POS
{
    public partial class ItemSetup : System.Web.UI.Page
    {
        BLL.ITEM_BLL objItem_BLL = new BLL.ITEM_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["SessionUser"]) == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindItem();
                }
            }

        }

        void BindItem()
        {
            try
            {
                var dept = objItem_BLL.GetTicketItem().ToList();
                if (dept.Count > 0)
                {
                    GridViewItem.DataSource = dept.ToList();
                    GridViewItem.DataBind();
                }
                else
                {
                    var obj = new List<LU_Tbl_Item>();
                    obj.Add(new LU_Tbl_Item());

                    // Bind the DataTable which contain a blank row to the GridView
                    GridViewItem.DataSource = obj;
                    GridViewItem.DataBind();

                    int columnsCount = GridViewItem.Columns.Count;
                    GridViewItem.Rows[0].Cells.Clear();// clear all the cells in the row
                    GridViewItem.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    GridViewItem.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    GridViewItem.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridViewItem.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    GridViewItem.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    GridViewItem.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void GridViewItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewItem.PageIndex = e.NewPageIndex;
                BindItem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridViewItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNewItem")
            {
                GridViewRow row = GridViewItem.FooterRow;
                TextBox txtItemNameNew = row.FindControl("txtItemNameNew") as TextBox;
                TextBox txtDescription = row.FindControl("txtDescription") as TextBox;
                TextBox txtItemPriceNew = row.FindControl("txtItemPriceNew") as TextBox;

                TextBox txtItemDiscountAmountNew = row.FindControl("txtItemDiscountAmountNew") as TextBox;
                DropDownList ddlItemGroupNew = row.FindControl("ddlItemGroupNew") as DropDownList;
                CheckBox CheckBoxStatusNew = row.FindControl("CheckBoxStatusNew") as CheckBox;

                TextBox txtItemVatNew = row.FindControl("txtItemVatNew") as TextBox;
                if (txtItemNameNew != null)
                {
                    LU_Tbl_Item objItem = new LU_Tbl_Item();
                    objItem.ItemName = txtItemNameNew.Text;
                    objItem.Description = txtDescription.Text;
                    objItem.Price = Convert.ToDecimal(txtItemPriceNew.Text);
                    objItem.ItemGroupName = ddlItemGroupNew.Text;
                    objItem.VAT = Convert.ToDecimal(txtItemVatNew.Text);
                    objItem.DiscountAmount = Convert.ToDecimal(txtItemDiscountAmountNew.Text);
                    objItem.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objItem.EDIT_DATE = DateTime.Now;
                    objItem.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objItem.EDIT_DATE = DateTime.Now;

                    bool status;
                    if (CheckBoxStatusNew.Checked == true)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }

                    objItem.Status = status;

                    //objDept.ItemGroupName= ((SessionUser)Session["SessionUser"]).UserId;
                    //objDept. = DateTime.Now;
                    //objDept.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = objItem_BLL.InsertItem(objItem);
                    if (result == 1)
                    {
                       // lblMessage.Text = "Record Added successfully!";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                       // lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Added successfully!')", true); 
                        BindItem();
                    }
                }
            }
        }

        protected void GridViewItem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewItem.EditIndex = e.NewEditIndex;
                BindItem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridViewItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewItem.Rows[e.RowIndex];
            TextBox txtItemName = row.FindControl("txtItemName") as TextBox;
            TextBox txtDescription = row.FindControl("txtDescription") as TextBox;
            TextBox txtItemPrice = row.FindControl("txtItemPrice") as TextBox;

            TextBox txtItemDiscountAmount = row.FindControl("txtItemDiscountAmount") as TextBox;
            DropDownList ddlItemGroup = row.FindControl("ddlItemGroup") as DropDownList;
            CheckBox CheckBoxStatus = row.FindControl("CheckBoxStatus") as CheckBox;

            TextBox txtItemVatAmount = row.FindControl("txtItemVatAmount") as TextBox;

            if (txtItemName != null)
            {
                int itemId = Convert.ToInt32(GridViewItem.DataKeys[e.RowIndex].Value);

                LU_Tbl_Item objItem = new LU_Tbl_Item();
                objItem.ItemName = txtItemName.Text;
                objItem.Description = txtDescription.Text;
                objItem.Price = Convert.ToDecimal(txtItemPrice.Text); 
                objItem.ItemGroupName = ddlItemGroup.Text;
                objItem.DiscountAmount = Convert.ToDecimal(txtItemDiscountAmount.Text);
                objItem.VAT = Convert.ToDecimal(txtItemVatAmount.Text);

                objItem.EDIT_DATE = DateTime.Now;

                bool status;
                if (CheckBoxStatus.Checked == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                objItem.Status = status;

                int result = objItem_BLL.UpdateItem(objItem, itemId);
                if (result == 1)
                {
                  //  lblMessage.Text = "Record Updated successfully!";
                  //  lblMessage.ForeColor = System.Drawing.Color.Green;
                   // lblMessage.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Updated successfully!')", true); 
                    GridViewItem.EditIndex = -1;
                    BindItem();
                }
            }
        }

        protected void GridViewItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int itemId = Convert.ToInt32(GridViewItem.DataKeys[e.RowIndex].Value);

            if (objItem_BLL.DeleteItem(itemId))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Ticket Deleted successfully!')", true);
                BindItem();
            }

        }

        protected void GridViewItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewItem.EditIndex = -1;
                BindItem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

    }
}