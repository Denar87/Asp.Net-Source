using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Procurement.BLL;
using System.Data;
using System.Collections;
using System.Drawing;

namespace ERPSSL.Procurement
{
    public partial class QuotationMatrix : System.Web.UI.Page
    {
        private static DataTable stdtToApprove = new DataTable();
        private static DataTable stdtApproved = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequisitionMatrix();
            }
        }

        private void LoadRequisitionMatrix()
        {
            //Table Matrix = new Table();
            DataSet ds = new DataSet();
            ds = QuotationBll.GetQuotationMatrixData();
            DataTable pr = ds.Tables[0];
            DataTable sup = ds.Tables[1];
            DataTable mat = ds.Tables[2];
            TableRow tr1 = new TableRow();
            Hashtable ht = new Hashtable();
            int i = 1;

            TableCell Ph = new TableCell();
            Ph.Text = "Items";
            Ph.Font.Bold = true;
            Ph.Width = 200;
            Ph.HorizontalAlign = HorizontalAlign.Center;
            Ph.BackColor = Color.DeepSkyBlue;
            tr1.Cells.Add(Ph);
            foreach (DataRow dr in sup.Rows)
            {
                //// Top head
                TableCell tc = new TableCell();
                tc.Text = dr["SupplierName"].ToString();
                tc.Font.Bold = true;
                tc.Width = 150;
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.BackColor = Color.DeepSkyBlue;
                tc.BorderColor = Color.DimGray;
                tc.Height = 40;
                //tc.Range.ParagraphFormat.Alignment =  WdParagraphAlignment.wdAlignParagraphCenter;
                ht.Add(i.ToString(), dr["SupplierCode"].ToString());
                tr1.Cells.Add(tc);
                i++;
            }

            tr1.BorderWidth = 1;
            tr1.BorderColor = Color.Gray;
            Matrix.Rows.Add(tr1);
            string PrDrNo = string.Empty;
            //string LowestSupCode = string.Empty;
            decimal minCpu = 0;
            int x = 0;
            foreach (DataRow dr0 in pr.Rows)
            {
                minCpu = 0;
                TableRow tr = new TableRow();
                for (int j = 0; j <= i - 1; j++)
                {

                    if (j == 0)
                    {
                        // left head
                        TableCell c1 = new TableCell();
                        c1.Text = pr.Rows[x]["ProductName"].ToString(); // +"<br/>"; +pr.Rows[x]["BarCode"].ToString();
                        PrDrNo = pr.Rows[x]["BarCode"].ToString();
                        minCpu = GetLowestBidder(PrDrNo, mat);
                        c1.BorderColor = Color.Gray;
                        c1.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c1);
                        tr.BackColor = Color.LightGray;
                        tr.BorderWidth = 1;
                        tr.BorderColor = Color.Gray;

                    }
                    else
                    {
                        TableCell c = new TableCell();
                        string valueText = GetCPU(j, ht, PrDrNo, mat);
                        c.Text = valueText;
                        try
                        {
                            if (int.Parse(valueText) == minCpu)
                            {
                                c.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                c.BackColor = Color.WhiteSmoke;
                            }
                        }
                        catch
                        {
                            c.BackColor = Color.WhiteSmoke;
                        }

                        c.HorizontalAlign = HorizontalAlign.Center;
                        tr.Cells.Add(c);
                        tr.BorderWidth = 1;
                        tr.BorderColor = Color.Gray;
                    }

                }
                Matrix.Rows.Add(tr);
                x++;
            }

            //Matrix.DataBind();
            // Panel1.Controls.Add(Matrix);
        }

        private decimal GetLowestBidder(string PrDrNo, DataTable mat)
        {
            decimal minCPU = 0;
            string minSupCode = string.Empty;
            int l = 1;
            foreach (DataRow dr in mat.Rows)
            {
                if (dr["BarCode"].ToString() == PrDrNo)
                {
                    if (l == 1)
                    {
                        minCPU = Decimal.Parse(dr["CPU"].ToString());
                        minSupCode = dr["SupplierCode"].ToString();
                    }
                    else
                    {

                        if (minCPU > Decimal.Parse(dr["CPU"].ToString()))
                        {
                            minCPU = Decimal.Parse(dr["CPU"].ToString());
                            minSupCode = dr["SupplierCode"].ToString();
                        }
                    }
                    l++;
                }

            }
            //return minSupCode;
            return minCPU;

        }

        private string GetCPU(int j, Hashtable ht, string PrDrNo, DataTable mat)
        {
            string sCode = ht[j.ToString()].ToString();
            int value = FindCPU(sCode, PrDrNo, mat);
            if (value == 0)
            {
                return "NA";
            }
            else
            {
                return value.ToString();
            }
        }

        private int FindCPU(string sCode, string PrDrNo, DataTable mat)
        {
            int v = 0;
            foreach (DataRow dr in mat.Rows)
            {
                if (dr["BarCode"].ToString() == PrDrNo && dr["SupplierCode"].ToString() == sCode)
                {
                    v = int.Parse(dr["CPU"].ToString());
                    return v;
                }
            }
            return v;
        }

    }
}