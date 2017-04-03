using ERPSSL.Production.BLL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Production
{
    public partial class PackingList : System.Web.UI.Page
    {
        CuttingBLL _cuttingbll = new CuttingBLL();
        PlanningBLL _PlanningBLL = new PlanningBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                  
                    LoadOrders();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void LoadOrders()
        {
            if (txtOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<OrderDetails> result = _PlanningBLL.GetOrdersDetails(OCODE);
                if (result.Count > 0)
                {
                    grdOrderDetails.DataSource = result.ToList();
                    grdOrderDetails.DataBind();
                }
                else
                {
                    var obj = new List<OrderDetails>();
                    obj.Add(new OrderDetails());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdOrderDetails.DataSource = obj;
                    grdOrderDetails.DataBind();

                    int columnsCount = grdOrderDetails.Columns.Count;
                    grdOrderDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdOrderDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdOrderDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                    grdOrderDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdOrderDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdOrderDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdOrderDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtOrderNo.Text;
                List<OrderDetails> orders = _PlanningBLL.GetOrdersDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdOrderDetails.DataSource = orders.ToList();
                    grdOrderDetails.DataBind();
                }
                else
                {
                    var obj = new List<OrderDetails>();
                    obj.Add(new OrderDetails());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdOrderDetails.DataSource = obj;
                    grdOrderDetails.DataBind();

                    int columnsCount = grdOrderDetails.Columns.Count;
                    grdOrderDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdOrderDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdOrderDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                    grdOrderDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdOrderDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdOrderDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdOrderDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }

            }


        }

        protected void imgbtnOrderDetails_Click(object sender, ImageClickEventArgs e)
        {
 
        }

        protected void txtOrderNo_OnTextChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }
       

       
      

        protected void grdCutting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rowLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

    }
}