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
    public partial class FactoryList : System.Web.UI.Page
    {
        FactoryBLL _factorybLL = new FactoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetFactoryList();
                    //GenerateFactoryCOde();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchFactory(string prefixText, int count)
        {

            using (var _context = new ERPSSL_LCEntities())
            {
                var factories = (from f in _context.LC_Factory
                                 where (f.FactoryName.StartsWith(prefixText))
                                 select f).DistinctBy(x => x.FactoryName);

                List<String> factoryList = new List<String>();

                foreach (var factory in factories)
                {
                    factoryList.Add(factory.FactoryName);
                }

                //System.Threading.Thread.Sleep(500);
                return factoryList;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetFactoryList();

        }
        private void GetFactoryList()
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    string name = txtSearch.Text;
                    List<LC_Factory> _FactoryL = _factorybLL.LoadFactoryListByName(name);
                    if (_FactoryL.Count > 0)
                    {
                        grdFactory2.DataSource = _FactoryL;
                        grdFactory2.DataBind();
                    }
                    else
                    {

                        var obj = new List<LC_Factory>();
                        obj.Add(new LC_Factory());

                        // Bind the DataTable which contain a blank row to the GridView
                        grdFactory2.DataSource = obj;
                        grdFactory2.DataBind();

                        int columnsCount = grdFactory2.Columns.Count;
                        grdFactory2.Rows[0].Cells.Clear();// clear all the cells in the row
                        grdFactory2.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grdFactory2.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                        grdFactory2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grdFactory2.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grdFactory2.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grdFactory2.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

                    }
                }
                else
                {

                    string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    List<LC_Factory> _FactoryL = _factorybLL.LoadFactoryList(Ocode);
                    if (_FactoryL.Count > 0)
                    {
                        grdFactory2.DataSource = _FactoryL;
                        grdFactory2.DataBind();
                    }
                    else
                    {

                        var obj = new List<LC_Factory>();
                        obj.Add(new LC_Factory());

                        // Bind the DataTable which contain a blank row to the GridView
                        grdFactory2.DataSource = obj;
                        grdFactory2.DataBind();

                        int columnsCount = grdFactory2.Columns.Count;
                        grdFactory2.Rows[0].Cells.Clear();// clear all the cells in the row
                        grdFactory2.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grdFactory2.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                        grdFactory2.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grdFactory2.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grdFactory2.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grdFactory2.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                    
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}