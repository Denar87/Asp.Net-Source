using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class AMC : System.Web.UI.Page
    {

        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();

        ProjectBLL aProjectBLL = new ProjectBLL();
        StageBLL aStageBLL = new StageBLL();
        Boolean handoverConditins;

        ProjectDAL aProjectDAL = new ProjectDAL();
        StageDAL aStageDAL = new StageDAL();

        WorkOrderDetailsBLL aWorkOrderDetailsBLL = new WorkOrderDetailsBLL();
        WorkOrderDetailsDAL aWorkOrderDetailsDAL = new WorkOrderDetailsDAL();

        AMC_BLL aAMC_BLL = new AMC_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    ShowMarketingInfoInGridView();
                    GetWorkOrderAMCDetailsForGridView();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchClientName(string prefixText, int count)
        {

            using (var _context = new ERPSSL_Marketing_Entities())
            {
                var allClient = from w in _context.MRK_WorkOrder
                                join m in _context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                                where w.AMCDAte <= DateTime.Now
                                && ((m.Client.Contains(prefixText)))
                                select m;




                List<String> clientList = new List<String>();

                if (allClient.ToList().Count > 0)
                {
                    clientList.AddRange(allClient.Select(x => x.Client).AsEnumerable());
                }




                return clientList;
            }
        }



        private void ShowMarketingInfoInGridByClientName()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                string clientName = searchTextBox.Text.Trim();

                List<MRK_MarketingInfo> aMarketingInfoLoad = aAMC_BLL.GetAllMarketingInfoByClientName(clientName, OCode);

                if (aMarketingInfoLoad.Count > 0)
                {
                    marketingInfoGrid.DataSource = aMarketingInfoLoad;
                    marketingInfoGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GetWorkOrderAMCDetailsForGridView()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MarketingWorkOrderAMC> aMarketingWorkOrderAMC = aAMC_BLL.GetAllWorkOrderAMCDetails(OCode);

                if (aMarketingWorkOrderAMC.Count > 0)
                {
                    WorkOrderGridView.DataSource = aMarketingWorkOrderAMC;
                    WorkOrderGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowMarketingInfoInGridByClientName();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ShowMarketingInfoInGridView()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MRK_MarketingInfo> aMarketingInfoLoad = aAMC_BLL.GetALLMarketingInfoInGridView(OCode);

                if (aMarketingInfoLoad.Count > 0)
                {
                    marketingInfoGrid.DataSource = aMarketingInfoLoad;
                    marketingInfoGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {

            //try
            //{
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                Label lblID = (Label)marketingInfoGrid.Rows[row.RowIndex].FindControl("lblID");

                int marketingId = Convert.ToInt16(lblID.Text);

                MarketingWorkOrder aMarketingWorkOrder = aAMC_BLL.GetSingaleWorkOrderDeatils(marketingId);
                if (aMarketingWorkOrder != null)
                {
                    HiddenFieldWorkOrderId.Value = aMarketingWorkOrder.WoID.ToString();
                    workOrderDateTextBox.Text = aMarketingWorkOrder.WorkOrderDate.ToString("MM/dd/yyyy");
                    workCompletionPeriodTextBox.Text = aMarketingWorkOrder.CompletionPeriod.ToString();
                    proposedAmountTextBox.Text = aMarketingWorkOrder.ProposedAmount.ToString();
                    signingAmountTextBox.Text = aMarketingWorkOrder.SigningAmount.ToString();
                    remainingAmountTextBox.Text = aMarketingWorkOrder.RemainingAmount.ToString();
                    remarksTextBox.Text = aMarketingWorkOrder.Remarks.ToString();
                    //warrentyPeriodTextBox.Text = aMarketingWorkOrder.WarrantyPeriod.ToString();
                    amcDateTextBox.Text = aMarketingWorkOrder.AMCDate.ToString("MM/dd/yyyy");
                    paymentConditionTextBox.Text = aMarketingWorkOrder.PaymentCondition.ToString();

                    HidMarketingInfoId.Value = aMarketingWorkOrder.MarketingInfoId.ToString();
                    visitDateTextBox.Text = aMarketingWorkOrder.VisitDate.ToString("MM/dd/yyyy");
                    clientNameTextBox.Text = aMarketingWorkOrder.Client.ToString();
                    contactPersonTextBox.Text = aMarketingWorkOrder.ContactPerson.ToString();
                    designationTextBox.Text = aMarketingWorkOrder.Designation.ToString();
                    contactNumberTextBox.Text = aMarketingWorkOrder.ContactNumber.ToString();
                    //emailTextBox.Text = aMarketingWorkOrder.Email.ToString();
                    //addressTextBox.Text = aMarketingWorkOrder.Address.ToString();
                    projectTextBox.Text = aMarketingWorkOrder.ProjectName.ToString();
                    moduleTextBox.Text = aMarketingWorkOrder.Module.ToString();
                    //paymentConditionTextBox.Text = aMarketingWorkOrder.PaymentCondition.ToString();
                    amcConditionTextBox.Text = aMarketingWorkOrder.AMC_Condition.ToString();

                    if (aMarketingWorkOrder.HandoverStatus == true)
                    {
                        handoverStatusDropDownList.Text = "Yes";
                    }
                    else
                    {
                        handoverStatusDropDownList.Text = "No";
                    }


                    marketingPersonTextBox.Text = aMarketingWorkOrder.MarketingPersonName.ToString();

                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveButton.Text == "Submit")
                {
                    MRK_AMC aMRK_AMC = new MRK_AMC();

                    aMRK_AMC.WorkOrderId = Convert.ToInt32(HidMarketingInfoId.Value);
                    aMRK_AMC.AMC_Condition = amcConditionTextBox.Text;
                    aMRK_AMC.AMC_Type = amcTypeDropDownList.Text;
                    aMRK_AMC.Amount = Convert.ToDecimal(amountTextBox.Text);
                    aMRK_AMC.EndDate = Convert.ToDateTime(amcEndDate.Text);
                    aMRK_AMC.BillingStatus = "No";
                    aMRK_AMC.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    aMRK_AMC.Create_Date = DateTime.Now;
                    aMRK_AMC.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aAMC_BLL.SaveAMCInfo(aMRK_AMC);


                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }



                }
                else if (saveButton.Text == "Update")
                {

                    MRK_AMC aMRK_AMC = new MRK_AMC();


                    aMRK_AMC.WorkOrderId = Convert.ToInt32(HiddenFieldWorkOrderId.Value);
                    aMRK_AMC.AMC_Condition = amcConditionTextBox.Text;
                    aMRK_AMC.AMC_Type = amcTypeDropDownList.Text;
                    aMRK_AMC.Amount = Convert.ToDecimal(amountTextBox.Text);
                    aMRK_AMC.EndDate = Convert.ToDateTime(amcEndDate.Text);
                    aMRK_AMC.BillingStatus = "No";
                    aMRK_AMC.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    aMRK_AMC.Edit_Date = DateTime.Now;
                    aMRK_AMC.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int AMCId = Convert.ToInt16(HiddenFieldWorkOrderId.Value);
                    int result = aAMC_BLL.UpdateAMCInfo(aMRK_AMC, AMCId);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }

                }
                ClearAllControl();
                GetWorkOrderAMCDetailsForGridView();

            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<officeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

            // GetWorkOrderDetailsForGridView();
        }


        public void ClearAllControl()
        {
            workOrderDateTextBox.Text = "";
            workCompletionPeriodTextBox.Text = "";
            proposedAmountTextBox.Text = "";
            signingAmountTextBox.Text = "";
            remainingAmountTextBox.Text = "";
            remarksTextBox.Text = "";
            visitDateTextBox.Text = "";
            clientNameTextBox.Text = "";
            contactPersonTextBox.Text = "";
            designationTextBox.Text = "";
            contactNumberTextBox.Text = "";
            //emailTextBox.Text = "";
            //addressTextBox.Text = "";
            projectTextBox.Text = "";
            marketingPersonTextBox.Text = "";
            moduleTextBox.Text = "";
            //paymentConditionTextBox.Text = "";
            amcConditionTextBox.Text = "";
            //developmentDepartmentTextBox.Text = "";
            //warrentyPeriodTextBox.Text = "";
            amcDateTextBox.Text = "";
            handoverStatusDropDownList.Text = "--Select--";

            amcDateTextBox.Text = null;
            amcConditionTextBox.Text = null;
            amcEndDate.Text = null;
            amountTextBox.Text = null;
            amcTypeDropDownList.SelectedValue = "--Select--";
            paymentConditionTextBox.Text = "";

        }

        protected void imgButtonEditeAMC_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                Label lblID_AMC = (Label)WorkOrderGridView.Rows[row.RowIndex].FindControl("lblID_AMC");

                int AMCId = Convert.ToInt16(lblID_AMC.Text);

                MarketingWorkOrderAMC aMarketingWorkOrderAMC = aAMC_BLL.GetSingaleAMCDeatils(AMCId);

                if (aMarketingWorkOrderAMC != null)
                {
                    HiddenFieldAMCId.Value = aMarketingWorkOrderAMC.AMCId.ToString();
                    amcDateTextBox.Text = aMarketingWorkOrderAMC.AMCDate.ToString("MM/dd/yyyy");
                    amcConditionTextBox.Text = aMarketingWorkOrderAMC.AMC_Condition.ToString();
                    amcEndDate.Text = aMarketingWorkOrderAMC.AMC_EndDate.ToString("MM/dd/yyyy");
                    amountTextBox.Text = aMarketingWorkOrderAMC.AMC_Amount.ToString("0.00");
                    amcTypeDropDownList.SelectedValue = aMarketingWorkOrderAMC.AMC_Type.ToString();


                    workOrderDateTextBox.Text = aMarketingWorkOrderAMC.WorkOrderDate.ToString("MM/dd/yyyy");
                    workCompletionPeriodTextBox.Text = aMarketingWorkOrderAMC.CompletionPeriod.ToString();
                    proposedAmountTextBox.Text = aMarketingWorkOrderAMC.ProposedAmount.ToString();
                    signingAmountTextBox.Text = aMarketingWorkOrderAMC.SigningAmount.ToString();
                    remainingAmountTextBox.Text = aMarketingWorkOrderAMC.RemainingAmount.ToString();
                    remarksTextBox.Text = aMarketingWorkOrderAMC.Remarks.ToString();

                    paymentConditionTextBox.Text = aMarketingWorkOrderAMC.PaymentCondition.ToString();

                    HidMarketingInfoId.Value = aMarketingWorkOrderAMC.MarketingInfoId.ToString();
                    HiddenFieldWorkOrderId.Value = aMarketingWorkOrderAMC.WoID.ToString();

                    visitDateTextBox.Text = aMarketingWorkOrderAMC.VisitDate.ToString("MM/dd/yyyy");
                    clientNameTextBox.Text = aMarketingWorkOrderAMC.Client.ToString();
                    contactPersonTextBox.Text = aMarketingWorkOrderAMC.ContactPerson.ToString();
                    designationTextBox.Text = aMarketingWorkOrderAMC.Designation.ToString();
                    contactNumberTextBox.Text = aMarketingWorkOrderAMC.ContactNumber.ToString();

                    projectTextBox.Text = aMarketingWorkOrderAMC.ProjectName.ToString();
                    moduleTextBox.Text = aMarketingWorkOrderAMC.Module.ToString();


                    if (aMarketingWorkOrderAMC.HandoverStatus == true)
                    {
                        handoverStatusDropDownList.Text = "Yes";
                    }
                    else
                    {
                        handoverStatusDropDownList.Text = "No";
                    }


                    marketingPersonTextBox.Text = aMarketingWorkOrderAMC.MarketingPersonName.ToString();

                    if (saveButton.Text == "Submit")
                    {
                        saveButton.Text = "Update";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}