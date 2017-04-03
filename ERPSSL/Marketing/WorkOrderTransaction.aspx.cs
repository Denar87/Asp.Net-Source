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
    public partial class WorkOrderTransaction : System.Web.UI.Page
    {
        WorkOrderTransactionBLL aWorkOrderTransactionBLL = new WorkOrderTransactionBLL();
        WorkOrderDetailsBLL aWorkOrderDetailsBLL = new WorkOrderDetailsBLL();

        public decimal paidAmount = 0;
        public decimal dueAmount;
        public decimal remaininfAmount;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    
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
                                where ((m.Client.Contains(prefixText)))
                                select m;
                List<String> clientList = new List<String>();
                foreach (var clientName in allClient)
                {
                    clientList.Add(clientName.Client);
                }
                return clientList;
            }
        }

        protected void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            showDataFromWorkOrder(searchTextBox.Text);
            getPrevousTransactionInfoById(HiddwnFieldWorkOrderId.Value);
            ShowDataInGrid();
        }

        public void getPrevousTransactionInfoById(string workOrderId)
        {
            int transactionWorkOrderId = Convert.ToInt32(workOrderId);
            
            using(var _Context = new ERPSSL_Marketing_Entities())
            {
                var collectionAmount = from t in _Context.MRK_Transaction
                                       where t.WorkOrderId == transactionWorkOrderId
                                       select t;
                
                foreach (var camount in collectionAmount)
                {
                    paidAmount = paidAmount + Convert.ToDecimal(camount.CollectionAmount);

                }

                paidAmountLabel.Text = paidAmount.ToString("0.00");
                dueAmountLabel.Text = (Convert.ToDecimal(totalAmountLabel.Text) - paidAmount).ToString("0.00");
            }
            
        }

        public void ShowDataInGrid()
        {
            int workOrderId = Convert.ToInt32(HiddwnFieldWorkOrderId.Value);

            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MRK_Transaction> aMRK_Transaction = aWorkOrderTransactionBLL.GetAllTransactionDetails(workOrderId, OCode);

                if (aMRK_Transaction.Count > 0)
                {
                    TransactionGridView.DataSource = aMRK_Transaction;
                    TransactionGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void showDataFromWorkOrder(string clientName)
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                MarketingWorkOrderTransaction aMarketingWorkOrderTransaction = aWorkOrderTransactionBLL.GetSingaleWorkOrderDeatilsByClientName(clientName);

                if (aMarketingWorkOrderTransaction != null)
                {
                    HiddwnFieldWorkOrderId.Value = aMarketingWorkOrderTransaction.WorkOrderId.ToString();
                    workorderDateTextBox.Text = aMarketingWorkOrderTransaction.WorkOrderDate.ToString("MM/dd/yyyy");
                    totalAmountLabel.Text = aMarketingWorkOrderTransaction.ProposedAmount.ToString("0.00");
                    remarksTextBox.Text = aMarketingWorkOrderTransaction.Remarks.ToString();
                    HidMarketingInfoId.Value = aMarketingWorkOrderTransaction.MarketingInfoId.ToString();
                    visitDateTextBox.Text = aMarketingWorkOrderTransaction.VisitDate.ToString("MM/dd/yyyy");
                    clientNameTextBox.Text = aMarketingWorkOrderTransaction.Client.ToString();
                    contactPersonTextBox.Text = aMarketingWorkOrderTransaction.ContactPerson.ToString();
                    designationTextBox.Text = aMarketingWorkOrderTransaction.Designation.ToString();
                    contactNumberTextBox.Text = aMarketingWorkOrderTransaction.ContactNumber.ToString();
                    emailTextBox.Text = aMarketingWorkOrderTransaction.Email.ToString();
                    addressTextBox.Text = aMarketingWorkOrderTransaction.Address.ToString();
                    projectTextBox.Text = aMarketingWorkOrderTransaction.ProjectName.ToString();
                    moduleTextBox.Text = aMarketingWorkOrderTransaction.Module.ToString();
                    marketingPersonTextBox.Text = aMarketingWorkOrderTransaction.MArketingPersonName.ToString();

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                MRK_Transaction aMRK_Transaction = new MRK_Transaction();
                aMRK_Transaction.WorkOrderId = Convert.ToInt32(HiddwnFieldWorkOrderId.Value);
                aMRK_Transaction.CollectionDate = Convert.ToDateTime(collectionDateTextBox.Text);
                aMRK_Transaction.CollectionAmount = Convert.ToDecimal(collectionAmountTextBox.Text);
                aMRK_Transaction.Remarks = remarksTextBox.Text;
                aMRK_Transaction.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                aMRK_Transaction.Create_Date = DateTime.Now;
                aMRK_Transaction.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result1 = aWorkOrderDetailsBLL.SaveWorkOrderToTransaction(aMRK_Transaction);

                if (result1 == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            showDataFromWorkOrder(searchTextBox.Text);
            getPrevousTransactionInfoById(HiddwnFieldWorkOrderId.Value);
            ShowDataInGrid();

            collectionDateTextBox.Text = "";
            collectionAmountTextBox.Text = "";
            remainingAmountTextBox.Text = "";
        }

        protected void collectionAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                remainingAmountTextBox.Text = (Convert.ToDecimal(totalAmountLabel.Text) - (Convert.ToDecimal(paidAmountLabel.Text) + Convert.ToDecimal(collectionAmountTextBox.Text))).ToString();
            }
            catch
            {
                remainingAmountTextBox.Text = "";
            }
        }


      
    }
}