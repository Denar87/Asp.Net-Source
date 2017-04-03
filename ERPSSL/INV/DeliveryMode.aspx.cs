using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV
{
    public partial class DeliveryMode : System.Web.UI.Page
    {

        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        DeleveryModeBLL aDeleveryModeBLL = new DeleveryModeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDeleveryMode();
            }
        }

        private void GetAllDeleveryMode()
        {
            try
            {
                List<Inv_DeliveryMode> Delevery = aDeleveryModeBLL.GetAllDeleveryMode();
                if (Delevery.Count > 0)
                {
                    grdDelivery.DataSource = Delevery;
                    grdDelivery.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_DeliveryMode aDeleveryMode = new Inv_DeliveryMode();

                aDeleveryMode.Delivery_Mode = txtDelivery.Text;

                if (btnSubmit.Text == "Submit")
                {
                    int DeleveryModeCount = (from DMode in _context.Inv_DeliveryMode
                                             where DMode.Delivery_Mode == aDeleveryMode.Delivery_Mode
                                             select DMode.DeliveryMode_Id).Count();

                    aDeleveryMode.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aDeleveryMode.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                    aDeleveryMode.EditDate = DateTime.Now;

                    if (DeleveryModeCount == 0)
                    {
                        int result = aDeleveryModeBLL.InsertDeleveryMode(aDeleveryMode);
                        if (result == 1)
                        {
                          //  lblMessage.Text = "Data Saved Successfully";
                         //   lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                            GetAllDeleveryMode();
                            txtDelivery.Text = "";
                        }
                        else
                        {
                           // lblMessage.Text = "Data Saving Failure";
                           // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
                       // lblMessage.Text = "Data Already Exist";
                       // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                        txtDelivery.Focus();
                        btnSubmit.Text = "Submit";
                    }
                }
                else
                {
                    int ID = Convert.ToInt32(hdfDeliveryID.Value);

                    int result = aDeleveryModeBLL.UpdateDeleveryMode(aDeleveryMode, ID);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Data Updated Sucessfully";
                       // lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                        GetAllDeleveryMode();
                        txtDelivery.Text = "";
                        btnSubmit.Text = "Submit";
                    }
                    else
                    {
                       // lblMessage.Text = "Data Updating failure";
                       // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void ImgEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_DeliveryMode> Delevery = new List<Inv_DeliveryMode>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ID = "";
                Label lblId = (Label)grdDelivery.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    ID = lblId.Text;
                    Delevery = aDeleveryModeBLL.GetDModeId(ID);

                    if (Delevery.Count > 0)
                    {
                        foreach (Inv_DeliveryMode aDMode in Delevery)
                        {
                            hdfDeliveryID.Value = aDMode.DeliveryMode_Id.ToString();
                            txtDelivery.Text = aDMode.Delivery_Mode;

                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdDelivery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDelivery.PageIndex = e.NewPageIndex;
            GetAllDeleveryMode();
        }

    }
}