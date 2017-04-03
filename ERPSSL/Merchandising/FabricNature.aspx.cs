using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class FabricNature : System.Web.UI.Page
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        FabricNatureBLL aFabricNatureBLL = new FabricNatureBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadAllFabricNature();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveButton.Text == "Save")
                {
                    LC_FabricNature aLC_FabricNature = new LC_FabricNature();

                    aLC_FabricNature.FabricNature = fabricNatureTextBox.Text;
                    aLC_FabricNature.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_FabricNature.CreateDate = DateTime.Now;
                    aLC_FabricNature.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aFabricNatureBLL.SaveData(aLC_FabricNature);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Save Successfully!!')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Save!!')", true);
                    }
                }
                else if (saveButton.Text == "Update")
                {
                    LC_FabricNature aLC_FabricNature = new LC_FabricNature();

                    aLC_FabricNature.FabricNature = fabricNatureTextBox.Text;
                    aLC_FabricNature.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_FabricNature.CreateDate = DateTime.Now;
                    aLC_FabricNature.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int idForUpdate = Convert.ToInt32(fabricNatureHiddenField.Value);

                 
                    int result = aFabricNatureBLL.UpdateData(aLC_FabricNature, idForUpdate);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Update Successfully!!')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Update!!')", true);
                    }
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            fabricNatureTextBox.Text = "";
            LoadAllFabricNature();


        }

        public void LoadAllFabricNature()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            List<LC_FabricNature> dataList = aFabricNatureBLL.LoadDataForGrid(ocode);

            if (dataList.Count > 0)
            {
                FabricNatureInfo.DataSource = dataList.ToList();
                FabricNatureInfo.DataBind();
            }
            else
            {
                FabricNatureInfo.DataSource = null;
                FabricNatureInfo.DataBind();
            }
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblID = (Label)FabricNatureInfo.Rows[row.RowIndex].FindControl("lblID");

            int entryId = Convert.ToInt32(lblID.Text);

            LC_FabricNature aLC_FabricNature = new LC_FabricNature();

            aLC_FabricNature = aFabricNatureBLL.GetSingleData(entryId);

            fabricNatureHiddenField.Value = aLC_FabricNature.Id.ToString();
            fabricNatureTextBox.Text = aLC_FabricNature.FabricNature;

            saveButton.Text = "Update";
        }
    }
}