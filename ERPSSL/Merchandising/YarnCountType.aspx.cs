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
    public partial class YarnCountType : System.Web.UI.Page
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        YarnCountTypeBLL aYarnCountTypeBLL = new YarnCountTypeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadAllYarnCountType();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblID = (Label)yarnCountTypeInfo.Rows[row.RowIndex].FindControl("lblID");

            int entryId = Convert.ToInt32(lblID.Text);

            LC_YarnCountType aLC_YarnCountType = new LC_YarnCountType();

            aLC_YarnCountType = aYarnCountTypeBLL.GetSingleData(entryId);

            yarncontTypeHiddenField.Value = aLC_YarnCountType.Id.ToString();
            yarnCountTypeTextBox.Text = aLC_YarnCountType.YarnCountType;

            saveButton.Text = "Update";
        }

        public void LoadAllYarnCountType()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            List<LC_YarnCountType> dataList = aYarnCountTypeBLL.LoadDataForGrid(ocode);

            if (dataList.Count > 0)
            {
                yarnCountTypeInfo.DataSource = dataList.ToList();
                yarnCountTypeInfo.DataBind();
            }
            else
            {
                yarnCountTypeInfo.DataSource = null;
                yarnCountTypeInfo.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {


                if (saveButton.Text == "Save")
                {
                    LC_YarnCountType aLC_YarnCountType = new LC_YarnCountType();
                    aLC_YarnCountType.YarnCountType = yarnCountTypeTextBox.Text;
                    aLC_YarnCountType.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_YarnCountType.CreateDate = DateTime.Now;
                    aLC_YarnCountType.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aYarnCountTypeBLL.SaveData(aLC_YarnCountType);

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
                    LC_YarnCountType aLC_YarnCountType = new LC_YarnCountType();
                    aLC_YarnCountType.YarnCountType = yarnCountTypeTextBox.Text;
                    aLC_YarnCountType.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_YarnCountType.EditDate = DateTime.Now;
                    aLC_YarnCountType.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int idForUpdate = Convert.ToInt32(yarncontTypeHiddenField.Value);

                    int result = aYarnCountTypeBLL.UpdateData(aLC_YarnCountType, idForUpdate);

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

            yarnCountTypeTextBox.Text = "";
            LoadAllYarnCountType();
            saveButton.Text = "Save";
        }
    }
}