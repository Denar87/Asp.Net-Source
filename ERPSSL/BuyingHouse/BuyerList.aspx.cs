using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;

namespace ERPSSL.BuyingHouse
{
    public partial class BuyerList : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetBuyerList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchBuyer(string prefixText, int count)
        {

            using (var _context = new ERPSSL_LCEntities())
            {
                var Buyers = (from b in _context.Com_Buyer_Setup
                                 where (b.Buyer_Name.StartsWith(prefixText))
                                 select b).DistinctBy(x => x.Buyer_Name);

                List<String> BuyersList = new List<String>();

                foreach (var Buyer in Buyers)
                {
                    BuyersList.Add(Buyer.Buyer_Name);
                }

                //System.Threading.Thread.Sleep(500);
                return BuyersList;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetBuyerList();

        }
        private void GetBuyerList()
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    string name = txtSearch.Text;
                    List<Com_Buyer_Setup> BuyerList = _Buyerbll.GetBuyerByName(name);
                    if (BuyerList.Count > 0)
                    {
                        grdBuyer.DataSource = BuyerList;
                        grdBuyer.DataBind();
                    }
                    else
                    {

                        var obj = new List<Com_Buyer_Setup>();
                        obj.Add(new Com_Buyer_Setup());

                        // Bind the DataTable which contain a blank row to the GridView
                        grdBuyer.DataSource = obj;
                        grdBuyer.DataBind();

                        int columnsCount = grdBuyer.Columns.Count;
                        grdBuyer.Rows[0].Cells.Clear();// clear all the cells in the row
                        grdBuyer.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grdBuyer.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                        grdBuyer.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grdBuyer.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grdBuyer.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grdBuyer.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

                    }
                }
                else
                {
                    string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    List<Com_Buyer_Setup> BuyerList = _Buyerbll.GetBuyerList(Ocode);
                    if (BuyerList.Count > 0)
                    {
                        grdBuyer.DataSource = BuyerList;
                        grdBuyer.DataBind();
                    }
                    else
                    {

                        var obj = new List<Com_Buyer_Setup>();
                        obj.Add(new Com_Buyer_Setup());

                        // Bind the DataTable which contain a blank row to the GridView
                        grdBuyer.DataSource = obj;
                        grdBuyer.DataBind();

                        int columnsCount = grdBuyer.Columns.Count;
                        grdBuyer.Rows[0].Cells.Clear();// clear all the cells in the row
                        grdBuyer.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grdBuyer.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                        grdBuyer.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grdBuyer.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grdBuyer.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grdBuyer.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}