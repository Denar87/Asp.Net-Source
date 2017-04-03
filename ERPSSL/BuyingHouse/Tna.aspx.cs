using ERPSSL.LC.DAL;
using ERPSSL.Production.BLL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class Tna : System.Web.UI.Page
    {
        TnaBLL _tnabll = new TnaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadStyleList();
                    LoadBrandList();
                    LoadDepartmentList();
                    LoadBuyerList();
                    LoadFactoryList();
                    ShowTNAList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadStyleList()
        {
            try
            {
                var row = _tnabll.GetStyleList();
                if (row.Count > 0)
                {
                    ddlStyle.DataSource = row.ToList();
                    ddlStyle.DataTextField = "StyleName";
                    ddlStyle.DataValueField = "StyleId";
                    ddlStyle.DataBind();
                    ddlStyle.AppendDataBoundItems = false;
                    ddlStyle.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadBrandList()
        {
            try
            {
                var row = _tnabll.GetBrandList();
                if (row.Count > 0)
                {
                    ddlBrand.DataSource = row.ToList();
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataValueField = "BrandId";
                    ddlBrand.DataBind();
                    ddlBrand.AppendDataBoundItems = false;
                    ddlBrand.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadDepartmentList()
        {
            try
            {
                var row = _tnabll.GetDepartmentList();
                if (row.Count > 0)
                {
                    ddlDepartment.DataSource = row.ToList();
                    ddlDepartment.DataTextField = "DPT_NAME";
                    ddlDepartment.DataValueField = "DPT_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.AppendDataBoundItems = false;
                    ddlDepartment.Items.Insert(0, new ListItem("--Select One--", "0"));
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
                var row = _tnabll.GetBuyerList();
                if (row.Count > 0)
                {
                    ddlBuyerName.DataSource = row.ToList();
                    ddlBuyerName.DataTextField = "Buyer_Name";
                    ddlBuyerName.DataValueField = "Buyer_ID";
                    ddlBuyerName.DataBind();
                    ddlBuyerName.AppendDataBoundItems = false;
                    ddlBuyerName.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadFactoryList()
        {
            try
            {
                var row = _tnabll.GetFactoryList();
                if (row.Count > 0)
                {
                    ddlFactoryName.DataSource = row.ToList();
                    ddlFactoryName.DataTextField = "FactoryName";
                    ddlFactoryName.DataValueField = "FactoryId";
                    ddlFactoryName.DataBind();
                    ddlFactoryName.AppendDataBoundItems = false;
                    ddlFactoryName.Items.Insert(0, new ListItem("--Select One--", "0"));
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
                Prod_TNA _ObjProdTna = new Prod_TNA();
                _ObjProdTna.StyleId = Convert.ToInt32(ddlStyle.SelectedValue);
                _ObjProdTna.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                _ObjProdTna.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                _ObjProdTna.Intake = txtIntake.Text;
                _ObjProdTna.Description = txtDescription.Text;
                _ObjProdTna.Buyer_ID = Convert.ToInt32(ddlBuyerName.SelectedValue);
                _ObjProdTna.ReceivedFromBuyer =Convert.ToDateTime( txtReceivedFromBuyer.Text);
                _ObjProdTna.FactoryId = Convert.ToInt32(ddlFactoryName.SelectedValue);
                _ObjProdTna.SendingDateToFactory =Convert.ToDateTime( txtSendingDateToFactory.Text);
                _ObjProdTna.SampleDeadline = Convert.ToDateTime(txtSampleDeadline.Text);
                _ObjProdTna.FactoryQty = Convert.ToDouble(txtFactoryQty.Text);
                _ObjProdTna.FactoryPrice = Convert.ToDecimal(txtFactoryPrice.Text);
                _ObjProdTna.ReceivedQty = Convert.ToDouble(txtReceivedQty.Text);
                _ObjProdTna.ReceivedFromFactory = Convert.ToDateTime(txtReceivedFromFactory.Text);
                _ObjProdTna.SendToBuyer = Convert.ToDateTime(txtSendToBuyer.Text);
                _ObjProdTna.BuyerQty = Convert.ToDouble(txtBuyerQty.Text);
                _ObjProdTna.Remark = txtRemark.Text;
                _ObjProdTna.Create_Date = DateTime.Now;
                _ObjProdTna.Create_User = (((SessionUser)Session["SessionUser"]).UserId);
                _ObjProdTna.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSave.Text != "Update")
                {
                    int result = _tnabll.Insert(_ObjProdTna);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _ObjProdTna.Edit_Date = DateTime.Now;
                    _ObjProdTna.Edit_User = (((SessionUser)Session["SessionUser"]).UserId); ;
                    _ObjProdTna.ID = Convert.ToInt16(hidtnaId.Value);
                    int result = _tnabll.Update(_ObjProdTna);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                ShowTNAList();
                ClearAllController();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllController()
        {
            ddlStyle.ClearSelection();
            ddlBrand.ClearSelection();
            ddlDepartment.ClearSelection();
            txtIntake.Text = "";
            txtDescription.Text = "";
            ddlBuyerName.ClearSelection();
            txtReceivedFromBuyer.Text = "";
            ddlFactoryName.ClearSelection();
            txtSendingDateToFactory.Text = "";
            txtSampleDeadline.Text = "";
            txtFactoryQty.Text = "0";
            txtFactoryPrice.Text = "0";
            txtReceivedQty.Text = "0";
            txtReceivedFromFactory.Text = "";
            txtSendToBuyer.Text = "";
            txtBuyerQty.Text = "0";
            txtRemark.Text = "";
            btnSave.Text = "Submit";
        }
        private void ShowTNAList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<ProductionR> _TnaL = _tnabll.GetTnaList(Ocode);
                if (_TnaL.Count > 0)
                {
                    grdTna.DataSource = _TnaL;
                    grdTna.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblID = (Label)grdTna.Rows[row.RowIndex].FindControl("lblID");
                int Id = Convert.ToInt16(lblID.Text);
                Prod_TNA _tS = _tnabll.GetTnaLById(Id);
                if (_tS != null)
                {
                    hidtnaId.Value = _tS.ID.ToString();
                    ddlStyle.SelectedValue = _tS.StyleId.ToString();
                    ddlBrand.SelectedValue = _tS.BrandId.ToString();
                    ddlDepartment.SelectedValue = _tS.DepartmentId.ToString();
                    txtIntake.Text = _tS.Intake;
                    txtDescription.Text = _tS.Description;
                    ddlBuyerName.SelectedValue = _tS.Buyer_ID.ToString();
                    txtReceivedFromBuyer.Text = _tS.ReceivedFromBuyer.ToString();
                    ddlFactoryName.SelectedValue = _tS.FactoryId.ToString();
                    txtSendingDateToFactory.Text = _tS.SendingDateToFactory.ToString();
                    txtSampleDeadline.Text = _tS.SampleDeadline.ToString();
                    txtFactoryQty.Text = _tS.FactoryQty.ToString();
                    txtFactoryPrice.Text = _tS.FactoryPrice.ToString();
                    txtReceivedQty.Text = _tS.ReceivedQty.ToString();
                    txtReceivedFromFactory.Text = _tS.ReceivedFromFactory.ToString();
                    txtSendToBuyer.Text = _tS.SendToBuyer.ToString();
                    txtBuyerQty.Text = _tS.BuyerQty.ToString();
                    txtRemark.Text = _tS.Remark;
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