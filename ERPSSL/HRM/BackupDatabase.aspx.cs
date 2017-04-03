using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class BackupDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        SqlConnection con = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            con.ConnectionString = @"Server=CRESCENT-PC;database=ERPSSL_Crescent;uid=sa;pwd=ssl@1234;";

            string backupDIR = "E:\\BackupDB";
            if (!System.IO.Directory.Exists(backupDIR))
            {
                System.IO.Directory.CreateDirectory(backupDIR);
            }
            try
            {
                con.Open();
                sqlcmd = new SqlCommand("backup database ERPSSL_Crescent to disk='" + backupDIR + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", con);
                sqlcmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Database Backup successfully!')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}