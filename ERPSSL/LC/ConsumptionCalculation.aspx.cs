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
    public partial class ConsumptionCalculation : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
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