using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class BuyerSetup : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //GetCounteryName();
                    GetBuyerList();
                    LoadPrincipalList();
                    LoadBuyerList();
                    LoadBuyingDepartmentList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchBuyerName(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var Q = from lcN in _context.Com_Buyer_Setup
                        where ((lcN.Buyer_Name.Contains(prefixText)))
                        select lcN;
                List<String> List = new List<String>();
                foreach (var BL in Q)
                {
                    List.Add(BL.Buyer_Name);
                }
                return List;
            }
        }

        private void LoadPrincipalList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<Com_Buyer_Setup> List = _Buyerbll.GetBuyerList(Ocode);
                if (List.Count > 0)
                {
                    ddlPrincipalName.DataSource = List.ToList();
                    ddlPrincipalName.DataTextField = "PrincipalName";
                    ddlPrincipalName.DataValueField = "PrincipalName";
                    ddlPrincipalName.DataBind();
                    ddlPrincipalName.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadBuyerList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<Com_Buyer_Setup> List = _Buyerbll.GetBuyerList(Ocode);
                if (List.Count > 0)
                {
                    ddlBuyer.DataSource = List.ToList();
                    ddlBuyer.DataTextField = "Buyer_Name";
                    ddlBuyer.DataValueField = "Buyer_Name";
                    ddlBuyer.DataBind();
                    ddlBuyer.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadBuyingDepartmentList()
        {
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<LC_BuyerDepartment> List = _Buyerbll.GetBuyerDepartmentList(Ocode);
            if (List.Count > 0)
            {
                ddlBuyingDepartment.DataSource = List.ToList();
                ddlBuyingDepartment.DataTextField = "BuyerDepartment_Name";
                ddlBuyingDepartment.DataValueField = "BuyerDepartment_Id";
                ddlBuyingDepartment.DataBind();
                ddlBuyingDepartment.Items.Insert(0, new ListItem("---Select One---"));
            }
        }

        private void GetBuyerList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                
                if (txtS_BuyerName.Text != "")
                {
                    string BuyerNameL = txtS_BuyerName.Text;
                    List<BuyerR> BuyerList = _Buyerbll.GetBuyerListByName(Ocode, BuyerNameL);
                    grdBuyer.DataSource = BuyerList;
                    grdBuyer.DataBind();
                }
                else
                {
                    List<BuyerR> BuyerList = _Buyerbll.GetBuyerListAll(Ocode);
                    grdBuyer.DataSource = BuyerList;
                    grdBuyer.DataBind();
                }
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
                int BuyDept = 0;
                Com_Buyer_Setup _buyerobj = new Com_Buyer_Setup();

                LC_BuyerDepartment _LC_BuyerDepartment = new LC_BuyerDepartment();

                if (chkBuyingDepartment.Checked == true)
                {
                    int count = (from Bd in _Context.LC_BuyerDepartment
                                 where Bd.BuyerDepartment_Name == _LC_BuyerDepartment.BuyerDepartment_Name
                                 select Bd.BuyerDepartment_Name).Count();
                    if (count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Buyer Department already Exist')", true);
                        return;
                    }
                    _LC_BuyerDepartment.BuyerDepartment_Name = txtBuyingDepartment.Text;
                    _LC_BuyerDepartment.Create_Date = DateTime.Today;
                    _LC_BuyerDepartment.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _LC_BuyerDepartment.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = _Buyerbll.AddBuyerDepartment(_LC_BuyerDepartment);
                    BuyDept = result;
                }
                if (chkPrincipalName.Checked == true)
                {
                    _buyerobj.PrincipalName = txtPrincipalName.Text;
                }
                else
                {
                    _buyerobj.PrincipalName = ddlPrincipalName.SelectedValue;
                }
                _buyerobj.Address = txtbxAddress.Text;
                _buyerobj.Country = ddlCountry.SelectedItem.Text;

                if (chkBuyer.Checked == true)
                {
                    _buyerobj.Buyer_Name = txtBuyer.Text;
                }
                else
                {
                    _buyerobj.Buyer_Name = ddlBuyer.SelectedValue;
                }
                if (chkBuyingDepartment.Checked == true)
                {
                    _buyerobj.BuyingDepartmentId = BuyDept;
                }
                else
                {
                    _buyerobj.BuyingDepartmentId = Convert.ToInt32(ddlBuyingDepartment.SelectedValue);
                }

                _buyerobj.Phone = txtbxPhone.Text.Trim();
                _buyerobj.Email = txtEmail.Text;

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

            txtbxPhone.Text = "";
            txtEmail.Text = "";
            chkPrincipalName.Checked = false;
            chkBuyer.Checked = false;
            chkBuyingDepartment.Checked = false;
            txtPrincipalName.Text = "";
            txtBuyer.Text = "";
            txtBuyingDepartment.Text = "";

            txtPrincipalName.Visible = false;
            txtBuyer.Visible = false;
            txtBuyingDepartment.Visible = false;

            ddlPrincipalName.Visible = true;
            ddlBuyer.Visible = true;
            ddlBuyingDepartment.Visible = true;
            //drpCountery.ClearSelection();
            ddlPrincipalName.ClearSelection();
            ddlBuyer.ClearSelection();
            ddlBuyingDepartment.ClearSelection();
            ddlCountry.ClearSelection();
            drpSataus.ClearSelection();
            txtbxAddress.Text = "";
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
                    hidBueyId.Value = _buyerSetup.Buyer_ID.ToString();
                    ddlPrincipalName.SelectedValue = _buyerSetup.PrincipalName;
                    ddlCountry.SelectedItem.Text = _buyerSetup.Country;
                    ddlBuyer.SelectedValue = _buyerSetup.Buyer_Name;
                    LoadBuyingDepartmentList();
                    ddlBuyingDepartment.SelectedValue = _buyerSetup.BuyingDepartmentId.ToString();
                    txtbxAddress.Text = _buyerSetup.Address.ToString();
                    txtbxPhone.Text = _buyerSetup.Phone.ToString();
                    txtEmail.Text = _buyerSetup.Email.ToString();
                    txtDeliveryAddress.Text = _buyerSetup.Delivery_Address;
                    txtNotifyParty.Text = _buyerSetup.NotifyParty;
                    txtDestinationAddress.Text = _buyerSetup.Destination_Address;
                    drpSataus.SelectedValue = _buyerSetup.Status.ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkBuyingDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBuyingDepartment.Checked == true)
            {
                txtBuyingDepartment.Visible = true;
                ddlBuyingDepartment.Visible = false;
            }
            else
            {
                txtBuyingDepartment.Visible = false;
                ddlBuyingDepartment.Visible = true;
            }
        }

        protected void chkBuyer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBuyer.Checked == true)
            {
                txtBuyer.Visible = true;
                ddlBuyer.Visible = false;
            }
            else
            {
                txtBuyer.Visible = false;
                ddlBuyer.Visible = true;
            }
        }

        protected void chkPrincipalName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrincipalName.Checked == true)
            {
                txtPrincipalName.Visible = true;
                ddlPrincipalName.Visible = false;
            }
            else
            {
                txtPrincipalName.Visible = false;
                ddlPrincipalName.Visible = true;
            }
        }

        protected void txtS_BuyerName_TextChanged(object sender, EventArgs e)
        {
            GetBuyerList();
        }
    }
}