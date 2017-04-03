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
    public partial class Factory : System.Web.UI.Page
    {
        FactoryBLL _factorybLL = new FactoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetFactoryList();
                    //GenerateFactoryCOde();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchFactoryName(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllFN = from lcN in _context.LC_Factory
                            where ((lcN.FactoryName.Contains(prefixText)))
                            select lcN;
                List<String> FNList = new List<String>();
                foreach (var FNL in AllFN)
                {
                    FNList.Add(FNL.FactoryName);
                }
                return FNList;
            }
        }

        private void GetFactoryList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                string F_Name = txtS_FactoryName.Text;

                if (txtS_FactoryName.Text != "")
                {
                    List<LC_Factory> _FactoryLN = _factorybLL.LoadFactoryListBySName(Ocode, F_Name);

                    grdFactory1.DataSource = _FactoryLN;
                    grdFactory1.DataBind();
                }
                else
                {
                    List<LC_Factory> _FactoryL = _factorybLL.LoadFactoryList(Ocode);

                    grdFactory1.DataSource = _FactoryL;
                    grdFactory1.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                LC_Factory _lcFactory = new LC_Factory();

                _lcFactory.FactoryName = txtFactoryName.Text;
                _lcFactory.FactoryCountry = ddlCountry.SelectedItem.Text;
                GenerateFactoryCOde();

                _lcFactory.FactoryCode = txtFactoryCode.Text;
                _lcFactory.ContactPerson1 = txtContactPerson1.Text;
                _lcFactory.CP1_Designation = txtP1Designation.Text;
                _lcFactory.CP1_ContactNumber = txtP1ContactNo.Text;
                _lcFactory.CP1_Email = txtP1Email.Text;

                _lcFactory.ContactPerson2 = txtContactPerson2.Text;
                _lcFactory.CP2_Designation = txtP2Designation.Text;
                _lcFactory.CP2_ContactNumber = txtP2ContactNo.Text;
                _lcFactory.CP2_Email = txtP2Email.Text;

                _lcFactory.FactoryAddress = txtFactoryAddress.Text;
                _lcFactory.FactoryMobile = txtFactoryContactNumber.Text;
                _lcFactory.FactoryEmail = txtFactoryEmail.Text;
                _lcFactory.FactoryWeb = txtFactoryWeb.Text;
                if (rdbFactoryIsActive.Checked == true)
                {
                    _lcFactory.FactoryStatus = true;
                }
                else
                {
                    _lcFactory.FactoryStatus = false;
                }
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
                GetFactoryList();
                ClearAllController();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerateFactoryCOde()
        {
            try
            {
                string CountryCode = ddlCountry.SelectedValue;
                string FacCode = txtFactoryName.Text.Substring(0, 3);
                //string FacCode = FactoryName["0,3"].ToString("0,3");
                txtFactoryCode.Text = _factorybLL.GetNewFactoryCode(CountryCode, FacCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ClearAllController()
        {
            ddlCountry.ClearSelection();
            txtFactoryName.Text = "";
            txtFactoryContactNumber.Text = "";
            txtFactoryEmail.Text = "";
            txtFactoryCode.Text = "";
            txtFactoryAddress.Text = "";
            txtContactPerson1.Text = "";
            txtP1Designation.Text = "";
            txtP1ContactNo.Text = "";
            txtP1Email.Text = "";
            txtContactPerson2.Text = "";
            txtP2Designation.Text = "";
            txtP2ContactNo.Text = "";
            txtP2Email.Text = "";
            txtFactoryWeb.Text = "";
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblFactoryId = (Label)grdFactory1.Rows[row.RowIndex].FindControl("lblFactoryId");
                int fqId = Convert.ToInt16(lblFactoryId.Text);
                LC_Factory _FactoryS = _factorybLL.GetFactoryLById(fqId);
                if (_FactoryS != null)
                {
                    hidFactoryd.Value = _FactoryS.FactoryId.ToString();
                    txtFactoryName.Text = _FactoryS.FactoryName;
                    ddlCountry.SelectedItem.Text = _FactoryS.FactoryCountry;
                    txtFactoryCode.Text = _FactoryS.FactoryCode;

                    txtP1Designation.Text = _FactoryS.CP1_Designation;
                    txtP1ContactNo.Text = _FactoryS.CP1_ContactNumber;
                    txtP1Email.Text = _FactoryS.CP1_Email;
                    txtContactPerson2.Text = _FactoryS.ContactPerson2;
                    txtP2Designation.Text = _FactoryS.CP2_Designation;
                    txtP2ContactNo.Text = _FactoryS.CP2_ContactNumber;
                    txtP2Email.Text = _FactoryS.CP2_Email;

                    txtContactPerson1.Text = _FactoryS.ContactPerson1;
                    txtFactoryEmail.Text = _FactoryS.FactoryEmail;
                    txtFactoryContactNumber.Text = _FactoryS.FactoryMobile;
                    txtFactoryAddress.Text = _FactoryS.FactoryAddress;
                    txtFactoryWeb.Text = _FactoryS.FactoryWeb;

                }
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtS_FactoryName_TextChanged(object sender, EventArgs e)
        {
            GetFactoryList();
        }
    }
}