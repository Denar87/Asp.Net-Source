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
    public partial class Composition : System.Web.UI.Page
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        CompositionBLL aCompositionBLL = new CompositionBLL(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadAllCompositionType();
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
                    LC_Composition aLC_Composition = new LC_Composition();
                    aLC_Composition.Composition = CompositionTextBox.Text;
                    aLC_Composition.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_Composition.CreateDate = DateTime.Now;
                    aLC_Composition.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aCompositionBLL.SaveData(aLC_Composition);

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
                    LC_Composition aLC_Composition = new LC_Composition();
                    aLC_Composition.Composition = CompositionTextBox.Text;
                    aLC_Composition.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_Composition.EditDate = DateTime.Now;
                    aLC_Composition.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int idForUpdate = Convert.ToInt32(compositionHiddenField.Value);

                    int result = aCompositionBLL.UpdateData(aLC_Composition, idForUpdate);

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

            CompositionTextBox.Text = "";
            LoadAllCompositionType();
            saveButton.Text = "Save";

        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblID = (Label)CompositionInfo.Rows[row.RowIndex].FindControl("lblID");

            int entryId = Convert.ToInt32(lblID.Text);

            LC_Composition aLC_Composition = new LC_Composition();

            aLC_Composition = aCompositionBLL.GetSingleData(entryId);

            compositionHiddenField.Value = aLC_Composition.Id.ToString();
            CompositionTextBox.Text = aLC_Composition.Composition;

            saveButton.Text = "Update";
        }

        public void LoadAllCompositionType()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            List<LC_Composition> dataList = aCompositionBLL.LoadDataForGrid(ocode);

            if (dataList.Count > 0)
            {
                CompositionInfo.DataSource = dataList.ToList();
                CompositionInfo.DataBind();
            }
            else
            {
                CompositionInfo.DataSource = null;
                CompositionInfo.DataBind();
            }
        }
    }
}