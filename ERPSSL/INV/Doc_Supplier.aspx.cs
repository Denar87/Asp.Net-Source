using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.INV
{
    public partial class Doc_Supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string FILE_NAME = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Description = txtDescription.Text;
                string Remarks = txtRemarks.Text;

                if (btn_Submit.Text == "Submit")
                {
                    lblDocmsg.Text = "Document Saved";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }
    }
}