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
    public partial class BuyerSetup : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetCounteryName();
                    GetBuyerList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetBuyerList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<Com_Buyer_Setup> BuyerList = _Buyerbll.GetBuyerList(Ocode);
                if (BuyerList.Count > 0)
                {
                    grdBuyer.DataSource = BuyerList;
                    grdBuyer.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetCounteryName()
        {
            try
            {
                drpCountery.DataSource = _Buyerbll.GetCounteryName();
                drpCountery.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Com_Buyer_Setup _buyerobj = new Com_Buyer_Setup();
                _buyerobj.Type = drpBuyerType.SelectedValue.ToString();
                _buyerobj.Buyer_Name = txtbxBuyerName.Text.Trim();
                _buyerobj.Contact_Person = txtbxContractPerson.Text.Trim();
                _buyerobj.Mobile = txtbxCellNo.Text.Trim();
                _buyerobj.Phone = txtbxPhone.Text.Trim();
                _buyerobj.Email = txtEmail.Text;
                _buyerobj.Counter = drpCountery.SelectedValue.ToString().Trim();
                _buyerobj.Address = txtbxAddress.Text.Trim();
                _buyerobj.Buyer_Address = txtBuyerAddress.Text;
                _buyerobj.Land_Address = txtLandAddress.Text;
                _buyerobj.Sea_Address = txtSeaAddress.Text;
                _buyerobj.Delivery_Address = txtDeliveryAddress.Text.Trim();
                _buyerobj.Destination_Address = txtDestinationAddress.Text.Trim();
                _buyerobj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                _buyerobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _buyerobj.EDIT_DATE = DateTime.Now;
                _buyerobj.Consignee = txtConsignee.Text;
                _buyerobj.NotifyParty = txtNotifyParty.Text;

                if (drpSataus.SelectedItem.ToString() == "True")
                {
                    _buyerobj.Status = true;
                }
                else
                {
                    _buyerobj.Status = false;
                }

                if (btnSave.Text != "Update")
                {
                    int result = _Buyerbll.Save(_buyerobj);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Buyer Saved Successfully')", true);
                    }
                }
                else
                {
                    _buyerobj.Buyer_ID = Convert.ToInt16(hidBueyId.Value);
                    int result = _Buyerbll.Update(_buyerobj);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Buyer Updated Successfully')", true);
                    }
                }
                GetBuyerList();
                ClearAllController();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearAllController()
        {
            txtbxBuyerName.Text = "";
            txtbxContractPerson.Text = "";
            drpBuyerType.ClearSelection();
            txtbxCellNo.Text = "";
            txtbxPhone.Text = "";
            txtEmail.Text = "";
            drpCountery.ClearSelection();
            drpSataus.ClearSelection();
            txtbxAddress.Text = "";
            txtBuyerAddress.Text = "";
            txtSeaAddress.Text = "";
            txtLandAddress.Text = "";
            txtNotifyParty.Text = "";
            txtDeliveryAddress.Text = "";
            txtDestinationAddress.Text = "";
            txtConsignee.Text = "";
            btnSave.Text = "Submit";
        }

        protected void imgButtonEidt_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                Label lblBuyerId = (Label)grdBuyer.Rows[row.RowIndex].FindControl("lblByerId");
                int ByeryId = Convert.ToInt16(lblBuyerId.Text);
                Com_Buyer_Setup _buyerSetup = _Buyerbll.GetBuyerById(ByeryId);
                if (_buyerSetup != null)
                {
                    drpBuyerType.SelectedValue = _buyerSetup.Type.ToString();
                    txtbxAddress.Text = _buyerSetup.Address.ToString();
                    txtbxBuyerName.Text = _buyerSetup.Buyer_Name.ToString();
                    txtbxContractPerson.Text = _buyerSetup.Contact_Person.ToString();
                    txtbxCellNo.Text = _buyerSetup.Mobile.ToString();
                    txtbxPhone.Text = _buyerSetup.Phone.ToString();
                    txtEmail.Text = _buyerSetup.Email.ToString();
                    txtDeliveryAddress.Text = _buyerSetup.Delivery_Address;
                    txtDestinationAddress.Text = _buyerSetup.Destination_Address;
                    txtSeaAddress.Text = _buyerSetup.Sea_Address;
                    txtLandAddress.Text = _buyerSetup.Land_Address;
                    txtBuyerAddress.Text = _buyerSetup.Buyer_Address;
                        
                    drpSataus.SelectedValue = _buyerSetup.Status.ToString();
                    drpCountery.SelectedValue = _buyerSetup.Counter.ToString();

                    btnSave.Text = "Update";
                    hidBueyId.Value = _buyerSetup.Buyer_ID.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}