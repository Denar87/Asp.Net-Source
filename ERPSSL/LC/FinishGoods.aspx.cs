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
    public partial class FinishGoods : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                    GetFinishGoodsList();
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
                List<LC_FinishGoods> style = _Buyerbll.GetFinishGoodsList(Ocode);
                if (style.Count > 0)
                {
                    grdFinishGoods.DataSource = style;
                    grdFinishGoods.DataBind();
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
                LC_FinishGoods _FinishGoods = new LC_FinishGoods();
                _FinishGoods.FinishGoods_Name = txtFinishGoods.Text;
                _FinishGoods.CreateDate = DateTime.Today;
                _FinishGoods.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);              
                _FinishGoods.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                

                if (btnSave.Text != "Update")
                {
                    int result = _Buyerbll.InsertFinishGoods(_FinishGoods);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Finish Goods Saved Successfully')", true);
                    }
                }
                else
                {
                    _FinishGoods.FinishGoods_Id = Convert.ToInt16(hidFinishGoods_Id.Value);
                    _FinishGoods.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    int result = _Buyerbll.UpdateFinishGoods(_FinishGoods);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Finish Goods Updated Successfully')", true);
                    }
                }
                GetFinishGoodsList();
                ClearAllController();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearAllController()
        {
            txtFinishGoods.Text = "";
            
            btnSave.Text = "Submit";
        }

        protected void imgButtonEidt_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                Label lblFinishGoods_Id = (Label)grdFinishGoods.Rows[row.RowIndex].FindControl("lblFinishGoods_Id");
                int FinishGoods_Id = Convert.ToInt16(lblFinishGoods_Id.Text);
                LC_FinishGoods _FinishGoodsSetup = _Buyerbll.GetFinishGoodsById(FinishGoods_Id);
                if (_FinishGoodsSetup != null)
                {
                    txtFinishGoods.Text = _FinishGoodsSetup.FinishGoods_Name;

                    hidFinishGoods_Id.Value = _FinishGoodsSetup.FinishGoods_Id.ToString();
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