using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.LC
{
    public partial class Factory : System.Web.UI.Page
    {
        FactoryBLL _factorybLL = new FactoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //GetFactoryList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void GetFactoryList()
        //{
        //    try
        //    {
        //        string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
        //        List<LC_Factory> _FactoryL = _factorybLL.LoadFactoryList(Ocode);
        //        if (_FactoryL.Count > 0)
        //        {
        //            grdFactory.DataSource = _FactoryL;
        //            grdFactory.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Factory _lcFactory = new LC_Factory();
                _lcFactory.FactoryName = txtFactoryName.Text;
                _lcFactory.FactoryCode = txtFactoryCode.Text;
                _lcFactory.ContactPerson1 = txtContactPerson.Text;
                _lcFactory.FactoryAddress = txtFactoryAddress.Text;
                _lcFactory.FactoryMobile = txtFactoryMobile.Text;
                _lcFactory.FactoryEmail = txtFactoryEmail.Text;

                _lcFactory.CreateDate = DateTime.Now;
                _lcFactory.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);
                _lcFactory.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSave.Text != "Update")
                {
                    int result = _factorybLL.InsertFactory(_lcFactory);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _lcFactory.EditDate = DateTime.Now;
                    _lcFactory.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    _lcFactory.FactoryId = Convert.ToInt16(hidFactoryd.Value);
                    int result = _factorybLL.UpdateFactory(_lcFactory);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                //GetFactoryList();
                ClearAllController();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllController()
        {
            txtFactoryName.Text = "";
            txtFactoryMobile.Text = "";
            txtFactoryEmail.Text = "";
            txtFactoryCode.Text = "";
            txtFactoryAddress.Text = "";
            txtContactPerson.Text = "";
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblFactoryId = (Label)grdFactory.Rows[row.RowIndex].FindControl("lblFactoryId");
                int fqId = Convert.ToInt16(lblFactoryId.Text);
                LC_Factory _FactoryS = _factorybLL.GetFactoryLById(fqId);
                if (_FactoryS != null)
                {
                    hidFactoryd.Value = _FactoryS.FactoryId.ToString();
                    txtFactoryName.Text = _FactoryS.FactoryName;
                    txtFactoryCode.Text = _FactoryS.FactoryCode;
                    txtContactPerson.Text = _FactoryS.ContactPerson1;
                    txtFactoryEmail.Text = _FactoryS.FactoryEmail;
                    txtFactoryMobile.Text = _FactoryS.FactoryMobile;
                    txtFactoryAddress.Text = _FactoryS.FactoryAddress;
                }
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}