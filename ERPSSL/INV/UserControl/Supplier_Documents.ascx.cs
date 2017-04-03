using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.INV.UserControl
{
    public partial class Supplier_Documents : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string FILE_NAME = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Description = txtDescription.Text;
            string Remarks = txtRemarks.Text;

            if (btn_Submit.Text == "Submit")
            {
                lblDocmsg.Text = "Document Saved";
            }
        }
    }
}