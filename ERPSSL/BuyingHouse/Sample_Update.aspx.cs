using ERPSSL.BuyingHouse.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class Sample_Update : System.Web.UI.Page
    {
        SampleDetailsBLL _SampleDetailsbll = new SampleDetailsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    DivUpdate.Visible = false;
                    LoadBuyerList();
                    LoadFactoryList();
                    ShowSampleDetailGrid();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchBuyerAndPreOrder(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllPreOrder = from lcN in _context.LC_SampleDetails
                                  //join B in _context.Com_Buyer_Setup on lcN.Buyer_ID equals B.Buyer_ID
                                  //join F in _context.LC_Factory on lcN.FactoryId equals F.FactoryId
                               where (lcN.Pre_OrderNo.Contains(prefixText))
                               select lcN;
                List<String> PreOrderList = new List<String>();
                foreach (var PreOrder_No in AllPreOrder)
                {
                    PreOrderList.Add(PreOrder_No.Pre_OrderNo);
                }
                return PreOrderList;
            }
        }

        private void LoadFactoryList()
        {
            try
            {
                var row = _SampleDetailsbll.GetFactoryNameList();
                if (row.Count > 0)
                {
                    ddlFactoryMame.DataSource = row.ToList();
                    ddlFactoryMame.DataTextField = "FactoryName";
                    ddlFactoryMame.DataValueField = "FactoryId";
                    ddlFactoryMame.DataBind();
                    ddlFactoryMame.AppendDataBoundItems = false;
                    ddlFactoryMame.Items.Insert(0, new ListItem("--Select One--", "0"));
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
                var row = _SampleDetailsbll.GetBuyerList();
                if (row.Count > 0)
                {
                    ddlBuyer.DataSource = row.ToList();
                    ddlBuyer.DataTextField = "Buyer_Name";
                    ddlBuyer.DataValueField = "Buyer_ID";
                    ddlBuyer.DataBind();
                    ddlBuyer.AppendDataBoundItems = false;
                    ddlBuyer.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowSampleDetailGrid()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var _TnaL = _SampleDetailsbll.GetSampleDetailsList(OCode);
                if (_TnaL.Count > 0)
                {
                    grdSampleDetails.DataSource = _TnaL;
                    grdSampleDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowSampleDetailGridByPreOrderNo()
        {
            try
            {
                string PreOrderNo = txtBuyerAndPreOrder.Text;
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var _TnaL = _SampleDetailsbll.GetSampleDetailsListByPOno(PreOrderNo,OCode);
                if (_TnaL.Count > 0)
                {
                    grdSampleDetails.DataSource = _TnaL;
                    grdSampleDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void imgSampleDetailsEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblID = (Label)grdSampleDetails.Rows[row.RowIndex].FindControl("lblID");
                int Id = Convert.ToInt16(lblID.Text);
                LC_SampleDetails _SD = _SampleDetailsbll.GetSDetailsById(Id);
                if (_SD != null)
                {
                    HidId.Value = _SD.SampleId.ToString();
                    ddlBuyer.SelectedValue = _SD.Buyer_ID.ToString();
                    ddlFactoryMame.SelectedValue = _SD.FactoryId.ToString();
                    txtPreOrderNo.Text = _SD.Pre_OrderNo;
                    txtSampleDate.Text = _SD.SampleDate.ToString();
                    txtSampleSpecification.Text = _SD.SampleSpecification;
                    txt1stSampleSentDate.Text = _SD.First_SampleSentDate.ToString();
                    txtModiReceiveDate.Text = _SD.Modi_ReceiveDate.ToString();

                    txtCounterSampleSendDate.Text = _SD.Counter_SampleSend_Date.ToString();
                    txtSizeSetDate.Text = _SD.SizeSet_Date.ToString();
                    txtCostingSendDate.Text = _SD.Costing_SendDate.ToString();

                    txtProductionApprovedDate.Text = _SD.Production_ApprovedDate.ToString();
                    txtBVTestSubmitDate.Text = _SD.BV_TestSubmitDate.ToString();
                    txtBVTestReleaseDate.Text = _SD.BV_TestReleaseDate.ToString();

                    txtSealingSampleSubmitDate.Text = _SD.SealingSample_SubmitDate.ToString();
                    txtSealingSampleReleaseDate.Text = _SD.SealingSample_RelaseDate.ToString();
                    txtShipmentSampleSendDate.Text = _SD.ShipmentSample_SendDate.ToString();
                    txtShipmentSampleApprovedDate.Text = _SD.ShipmentSample_ApprovedDate.ToString();
                }
                DivUpdate.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LC_SampleDetails _ObjSampleDetails = new LC_SampleDetails();
                
                DateTime? SampleDate = null;

                _ObjSampleDetails.Buyer_ID = Convert.ToInt32(ddlBuyer.SelectedValue);
                _ObjSampleDetails.FactoryId = Convert.ToInt32(ddlFactoryMame.SelectedValue);
                _ObjSampleDetails.Pre_OrderNo = txtPreOrderNo.Text;
                if (txtSampleDate.Text == "")
                {
                    _ObjSampleDetails.SampleDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.SampleDate = Convert.ToDateTime(txtSampleDate.Text);
                }
                _ObjSampleDetails.SampleSpecification = txtSampleSpecification.Text;
                _ObjSampleDetails.Pre_OrderNo = txtPreOrderNo.Text;
                if (txt1stSampleSentDate.Text == "")
                {
                    _ObjSampleDetails.First_SampleSentDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.First_SampleSentDate = Convert.ToDateTime(txt1stSampleSentDate.Text);
                }

                if (txtModiReceiveDate.Text == "")
                {
                    _ObjSampleDetails.Modi_ReceiveDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.Modi_ReceiveDate = Convert.ToDateTime(txtModiReceiveDate.Text);
                }
                
                _ObjSampleDetails.Modi_Status = "True";

                if (txtCounterSampleSendDate.Text == "")
                {
                    _ObjSampleDetails.Counter_SampleSend_Date = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.Counter_SampleSend_Date = Convert.ToDateTime(txtCounterSampleSendDate.Text);
                }

                if (txtSizeSetDate.Text == "")
                {
                    _ObjSampleDetails.SizeSet_Date = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.SizeSet_Date = Convert.ToDateTime(txtSizeSetDate.Text);
                }

                if (txtCostingSendDate.Text == "")
                {
                    _ObjSampleDetails.Costing_SendDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.Costing_SendDate = Convert.ToDateTime(txtCostingSendDate.Text);
                }

                if (txtProductionApprovedDate.Text == "")
                {
                    _ObjSampleDetails.Production_ApprovedDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.Production_ApprovedDate = Convert.ToDateTime(txtProductionApprovedDate.Text);
                }

                if (txtBVTestSubmitDate.Text == "")
                {
                    _ObjSampleDetails.BV_TestSubmitDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.BV_TestSubmitDate = Convert.ToDateTime(txtBVTestSubmitDate.Text);
                }

                if (txtBVTestReleaseDate.Text == "")
                {
                    _ObjSampleDetails.BV_TestReleaseDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.BV_TestReleaseDate = Convert.ToDateTime(txtBVTestReleaseDate.Text);
                }

                if (txtSealingSampleSubmitDate.Text == "")
                {
                    _ObjSampleDetails.SealingSample_SubmitDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.SealingSample_SubmitDate = Convert.ToDateTime(txtSealingSampleSubmitDate.Text);
                }

                if (txtSealingSampleReleaseDate.Text == "")
                {
                    _ObjSampleDetails.SealingSample_RelaseDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.SealingSample_RelaseDate = Convert.ToDateTime(txtSealingSampleReleaseDate.Text);
                }

                if (txtShipmentSampleSendDate.Text == "")
                {
                    _ObjSampleDetails.ShipmentSample_SendDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.ShipmentSample_SendDate = Convert.ToDateTime(txtShipmentSampleSendDate.Text);
                }

                if (txtShipmentSampleApprovedDate.Text == "")
                {
                    _ObjSampleDetails.ShipmentSample_ApprovedDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.ShipmentSample_ApprovedDate = Convert.ToDateTime(txtShipmentSampleApprovedDate.Text);
                }
                

                if (rdbApproved.Checked == true)
                {
                    _ObjSampleDetails.Sample_Status = "Approved";
                }
                else
                {
                    _ObjSampleDetails.Sample_Status = "Decline";
                }
                _ObjSampleDetails.EditDate = DateTime.Now;
                _ObjSampleDetails.EditUser = (((SessionUser)Session["SessionUser"]).UserId);
                _ObjSampleDetails.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSubmit.Text == "Submit")
                {
                    _ObjSampleDetails.SampleId = Convert.ToInt16(HidId.Value);
                    int result = _SampleDetailsbll.SampleUpdate(_ObjSampleDetails);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save failure')", true);
                }
                ClearUi();
                DivUpdate.Visible = false;
                ShowSampleDetailGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearUi()
        {
            ddlBuyer.ClearSelection();
            ddlFactoryMame.ClearSelection();
            txtPreOrderNo.Text = "";
            txtSampleDate.Text = "";
            txtSampleSpecification.Text = "";
            txt1stSampleSentDate.Text = "";
        }

        protected void txtBuyerAndPreOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowSampleDetailGridByPreOrderNo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}