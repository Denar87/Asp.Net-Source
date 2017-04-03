using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class ViewWorkOrderStatus : System.Web.UI.Page
    {

        WorkOrderDetailsBLL aWorkOrderDetailsBLL = new WorkOrderDetailsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    if (Session["WorkOrderId"].ToString() == null)
                    {

                    }
                    else 
                    {
                        LoadData();
                    }
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }

        public void LoadData()
        {
            try
            {
                int workOrderId = Convert.ToInt32(Session["WorkOrderId"].ToString());

                MarketingWorkOrder aMarketingWorkOrder = aWorkOrderDetailsBLL.GetSingaleWorkOrderDeatils(workOrderId);
                if (aMarketingWorkOrder != null)
                {
                    //HiddenFieldWorkOrderId.Value = aMarketingWorkOrder.WoID.ToString();
                    workOrderDateTextBox.Text = aMarketingWorkOrder.WorkOrderDate.ToString("MM/dd/yyyy");
                    workCompletionPeriodTextBox.Text = aMarketingWorkOrder.CompletionPeriod.ToString();
                    proposedAmountTextBox.Text = aMarketingWorkOrder.ProposedAmount.ToString();
                    signingAmountTextBox.Text = aMarketingWorkOrder.SigningAmount.ToString();
                    remainingAmountTextBox.Text = aMarketingWorkOrder.RemainingAmount.ToString();
                    remarksTextBox.Text = aMarketingWorkOrder.Remarks.ToString();
                    warrentyPeriodTextBox.Text = aMarketingWorkOrder.WarrantyPeriod.ToString();
                    amcDateTextBox.Text = aMarketingWorkOrder.AMCDate.ToString("MM/dd/yyyy");

                    //HidMarketingInfoId.Value = aMarketingWorkOrder.MarketingInfoId.ToString();
                    visitDateTextBox.Text = aMarketingWorkOrder.VisitDate.ToString("MM/dd/yyyy");
                    clientNameTextBox.Text = aMarketingWorkOrder.Client.ToString();
                    contactPersonTextBox.Text = aMarketingWorkOrder.ContactPerson.ToString();
                    designationTextBox.Text = aMarketingWorkOrder.Designation.ToString();
                    contactNumberTextBox.Text = aMarketingWorkOrder.ContactNumber.ToString();
                    //emailTextBox.Text = aMarketingWorkOrder.Email.ToString();
                    //addressTextBox.Text = aMarketingWorkOrder.Address.ToString();
                    projectTextBox.Text = aMarketingWorkOrder.ProjectName.ToString();
                    moduleTextBox.Text = aMarketingWorkOrder.Module.ToString();
                    paymentConditionTextBox.Text = aMarketingWorkOrder.PaymentCondition.ToString();
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

                    //if (saveButton.Text == "Submit")
                    //{
                    //    saveButton.Text = "Update";
                    //}

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}