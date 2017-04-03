using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.LC
{
    public partial class Measurement_Parameter : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetFinishGoodsList();
                    GetMeasurementParameterList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetFinishGoodsList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_FinishGoods> FinishGoodsList = _Buyerbll.GetFinishGoodsListGetBuyerList(Ocode);
                if (FinishGoodsList.Count > 0)
                {
                    ddlFinishGoods.DataSource = FinishGoodsList.ToList();
                    ddlFinishGoods.DataTextField = "FinishGoods_Name";
                    ddlFinishGoods.DataValueField = "FinishGoods_Id";
                    ddlFinishGoods.DataBind();
                    ddlFinishGoods.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void GetMeasurementParameterList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<ItemList> Parameter = _Buyerbll.GetMagermentParameterList(Ocode);
                if (Parameter.Count > 0)
                {
                    grdMeasurement_Parameter.DataSource = Parameter;
                    grdMeasurement_Parameter.DataBind();
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
                LC_Measurement_Parameter _Magerment_Parameter = new LC_Measurement_Parameter();
                _Magerment_Parameter.Measurement_Name = txtMagerment_Parameter.Text;
                _Magerment_Parameter.FinishGoods_Id = Convert.ToInt32(ddlFinishGoods.SelectedValue);
                _Magerment_Parameter.CreateDate = DateTime.Today;
                _Magerment_Parameter.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);
                _Magerment_Parameter.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);



                if (btnSave.Text != "Update")
                {
                    int result = _Buyerbll.InsertMagerment_Parameter(_Magerment_Parameter);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Measurement Parameter Saved Successfully')", true);
                    }
                }
                else
                {
                    _Magerment_Parameter.Measurement_Id = Convert.ToInt16(hidMParameter_Id.Value);
                    _Magerment_Parameter.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    int result = _Buyerbll.UpdateMagerment_Parameter(_Magerment_Parameter);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Measurement Parameter Updated Successfully')", true);
                    }
                }
                GetMeasurementParameterList();
                ClearAllController();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearAllController()
        {
            txtMagerment_Parameter.Text = "";
            //ddlFinishGood.SelectedItem.Text = "---Select One---";

            btnSave.Text = "Submit";
        }

        protected void imgButtonEidt_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                Label lblMagerment_Id = (Label)grdMeasurement_Parameter.Rows[row.RowIndex].FindControl("lblMagerment_Id");
                int Magerment_Id = Convert.ToInt16(lblMagerment_Id.Text);
                LC_Measurement_Parameter _MParameter = _Buyerbll.GetMagermentById(Magerment_Id);
                if (_MParameter != null)
                {
                    txtMagerment_Parameter.Text = _MParameter.Measurement_Name;
                    ddlFinishGoods.Text = Convert.ToString(_MParameter.FinishGoods_Id);

                    hidMParameter_Id.Value = _MParameter.Measurement_Id.ToString();
                }
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMeasurement_Parameter_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMeasurement_Parameter.PageIndex = e.NewPageIndex;
            GetMeasurementParameterList();
        }

        protected void ddlFinishGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                int finishGoods = Convert.ToInt16(ddlFinishGoods.SelectedValue);
                List<ItemList> Goods = _Buyerbll.MeasurementParameter(Ocode, finishGoods).ToList();
                if (Goods.Count > 0)
                {
                    grdMeasurement_Parameter.DataSource = Goods;
                    grdMeasurement_Parameter.DataBind();

                }
                else
                {
                    grdMeasurement_Parameter.DataSource = null;
                    grdMeasurement_Parameter.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}