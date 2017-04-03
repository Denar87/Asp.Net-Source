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
    public partial class ConstructionType : System.Web.UI.Page
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        ConstructionTypeBLL aConstructionTypeBLL = new ConstructionTypeBLL(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadAllConstructionType();
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
                    LC_ConstructionType aLC_ConstructionType = new LC_ConstructionType();
                    aLC_ConstructionType.ConstructionType = constructionTypeTextBox.Text;
                    aLC_ConstructionType.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_ConstructionType.CreateDate = DateTime.Now;
                    aLC_ConstructionType.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aConstructionTypeBLL.SaveData(aLC_ConstructionType);

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
                    LC_ConstructionType aLC_ConstructionType = new LC_ConstructionType();
                    aLC_ConstructionType.ConstructionType = constructionTypeTextBox.Text;
                    aLC_ConstructionType.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_ConstructionType.EditDate = DateTime.Now;
                    aLC_ConstructionType.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int idForUpdate = Convert.ToInt32(constructionTypeHiddenField.Value);

                    int result = aConstructionTypeBLL.UpdateData(aLC_ConstructionType, idForUpdate);

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

            constructionTypeTextBox.Text = "";
            LoadAllConstructionType();
            saveButton.Text = "Save";

        }

        public void LoadAllConstructionType()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            List<LC_ConstructionType> dataList = aConstructionTypeBLL.LoadDataForGrid(ocode);

            if (dataList.Count > 0)
            {
                constructionTypeInfo.DataSource = dataList.ToList();
                constructionTypeInfo.DataBind();
            }
            else
            {
                constructionTypeInfo.DataSource = null;
                constructionTypeInfo.DataBind();
            }
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblID = (Label)constructionTypeInfo.Rows[row.RowIndex].FindControl("lblID");

            int entryId = Convert.ToInt32(lblID.Text);

            LC_ConstructionType aLC_ConstructionType = new LC_ConstructionType();

            aLC_ConstructionType = aConstructionTypeBLL.GetSingleData(entryId);

            constructionTypeHiddenField.Value = aLC_ConstructionType.Id.ToString();
            constructionTypeTextBox.Text = aLC_ConstructionType.ConstructionType;

            saveButton.Text = "Update";

        }
    }
}