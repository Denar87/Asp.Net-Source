using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
//using ERPSSL.LC.DAL;

namespace ERPSSL.Marketing
{
    public partial class WorkOrderDetails : System.Web.UI.Page
    {

        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();

        ProjectBLL aProjectBLL = new ProjectBLL();
        StageBLL aStageBLL = new StageBLL();
        Boolean handoverConditins;

        ProjectDAL aProjectDAL = new ProjectDAL();
        StageDAL aStageDAL = new StageDAL();

        WorkOrderDetailsBLL aWorkOrderDetailsBLL = new WorkOrderDetailsBLL();
        WorkOrderDetailsDAL aWorkOrderDetailsDAL = new WorkOrderDetailsDAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    GetWorkOrderDetailsForGridView();
                    ShowMarketingInfoInGridView();
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
                var allClient = from m in _context.MRK_MarketingInfo
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



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchClientName2(string prefixText, int count)
        {
            using (var _context = new ERPSSL_Marketing_Entities())
            {
                var allClient = from m in _context.MRK_MarketingInfo
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



        public void GetWorkOrderDetailsForGridView()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MarketingWorkOrder> aMarketingWorkOrder = aWorkOrderDetailsBLL.GetAllWorkOrderDetails(OCode); 

                if (aMarketingWorkOrder.Count > 0)
                {
                    WorkOrderGridView.DataSource = aMarketingWorkOrder;
                    WorkOrderGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetWorkOrderDetailsForGridViewByClientName()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                string clientName = searchTextBox2.Text.Trim();

                List<MarketingWorkOrder> aMarketingWorkOrder = aWorkOrderDetailsBLL.GetAllWorkOrderDetailsbyClientName(OCode, clientName);

               
                    WorkOrderGridView.DataSource = aMarketingWorkOrder;
                    WorkOrderGridView.DataBind();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowMarketingInfoInGridByClientName()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                string clientName = searchTextBox.Text.Trim();

                //string LcNo = txtFillAotuLCNo.Text.Trim();

                List<MRK_MarketingInfo> aMarketingInfoLoad = aWorkOrderDetailsBLL.GetALLMArketingInfoByClientName(clientName, OCode);

                //List<LC_MasterLC> lcload = aWorkOrderDetailsBLL.GetALLMArketingInfoByClientName.(clientName, OCode);

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

        public void ShowMarketingInfoInGridView()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MRK_MarketingInfo> aMarketingInfoLoad = aWorkOrderDetailsBLL.GetALLMarketingInfoInGridView(OCode);

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

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                

                Label lblID = (Label)marketingInfoGrid.Rows[row.RowIndex].FindControl("lblID");
                int marketingInfoId = Convert.ToInt16(lblID.Text);
                List<MarketingProjectStage> aMarketingProjectStage = aWorkOrderDetailsBLL.GetInvidualMarketingInfoList(marketingInfoId);
                if (aMarketingProjectStage.Count != 0 )
                {
                    foreach (MarketingProjectStage aMarketingProjectStages in aMarketingProjectStage)
                    {
                        HidMarketingInfoId.Value = aMarketingProjectStages.MarketingInfoId.ToString();
                        visitDateTextBox.Text = aMarketingProjectStages.VisitDate.ToString("MM/dd/yyyy");
                        clientNameTextBox.Text = aMarketingProjectStages.Client.ToString();
                        contactPersonTextBox.Text = aMarketingProjectStages.ContactPerson.ToString();
                        designationTextBox.Text = aMarketingProjectStages.Designation.ToString();
                        contactNumberTextBox.Text = aMarketingProjectStages.ContactNumber.ToString();
                        //emailTextBox.Text = aMarketingProjectStages.Email.ToString();
                        //addressTextBox.Text = aMarketingProjectStages.Address.ToString();
                        projectTextBox.Text = aMarketingProjectStages.ProjectName.ToString();
                        referenceTextBox.Text = aMarketingProjectStages.ReferenceName.ToString();
                        moduleTextBox.Text = aMarketingProjectStages.Module.ToString();
                        marketingPersonTextBox.Text = aMarketingProjectStages.MArketingPersonName.ToString();
                        remarksTextBox.Text = aMarketingProjectStages.Remarks.ToString();

                        

                    }
                    
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
                if (saveButton.Text == "Submit")
                {

                    
                    if (handoverStatusDropDownList.Text == "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Handover Status')", true);
                    }
                    else if(warrentyPeriodTextBox.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Warranty Period (Months)')", true);
                    }
                    else if(handoverStatusDropDownList.Text != "--Select--")
                    {
                        if (handoverStatusDropDownList.Text == "Yes")
                        {
                            handoverConditins = true;
                        }
                        else if (handoverStatusDropDownList.Text == "No")
                        {
                            handoverConditins = false;
                        }

                        MRK_WorkOrder aMRK_WorkOrder = new MRK_WorkOrder();

                        aMRK_WorkOrder.MarketingInfoId = Convert.ToInt32(HidMarketingInfoId.Value);
                        aMRK_WorkOrder.WorkOrderDate = Convert.ToDateTime(workOrderDateTextBox.Text);
                        aMRK_WorkOrder.CompletionPeriod = workCompletionPeriodTextBox.Text;
                        aMRK_WorkOrder.ProposedAmount = Convert.ToDecimal(proposedAmountTextBox.Text);
                        aMRK_WorkOrder.SigningAmount = Convert.ToDecimal(signingAmountTextBox.Text);
                        aMRK_WorkOrder.RemainingAmount = Convert.ToDecimal(remainingAmountTextBox.Text);
                        aMRK_WorkOrder.PaymentCondition = paymentConditionTextBox.Text;
                        aMRK_WorkOrder.AMC_Condition = amcConditionTextBox.Text;
                        aMRK_WorkOrder.DevelopmentDept = developmentDepartmentTextBox.Text;
                        aMRK_WorkOrder.HandoverStatus = handoverConditins;
                        aMRK_WorkOrder.Remarks = remarksTextBox.Text;
                        aMRK_WorkOrder.WarrantyPeriod = Convert.ToInt32(warrentyPeriodTextBox.Text);
                        aMRK_WorkOrder.AMCDAte = Convert.ToDateTime(amcDateTextBox.Text);
                        aMRK_WorkOrder.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                        aMRK_WorkOrder.Create_Date = DateTime.Now;
                        aMRK_WorkOrder.OCODE = ((SessionUser)Session["SessionUser"]).OCode;




                        int result = aWorkOrderDetailsBLL.SaveWorkOrderInfo(aMRK_WorkOrder);


                        MRK_Transaction aMRK_Transaction = new MRK_Transaction();
                        aMRK_Transaction.WorkOrderId = result;
                        aMRK_Transaction.CollectionDate = Convert.ToDateTime(workOrderDateTextBox.Text);
                        aMRK_Transaction.CollectionAmount = Convert.ToDecimal(signingAmountTextBox.Text);
                        aMRK_Transaction.Remarks = remarksTextBox.Text;
                        aMRK_Transaction.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                        aMRK_Transaction.Create_Date = DateTime.Now;
                        aMRK_Transaction.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        int result2 = aWorkOrderDetailsBLL.SaveWorkOrderToTransaction(aMRK_Transaction);


                        List<LC_InputType> inputTypeList = new List<LC_InputType>();
                        inputTypeList = aWorkOrderDetailsBLL.GetAllTask();



                        

                        foreach(LC_InputType typeList in inputTypeList)
                        {
                            MRK_Task_Details aMRK_Task_Details = new MRK_Task_Details();
                            aMRK_Task_Details.WorkOrderId = (int)result;
                            aMRK_Task_Details.Remarks = "";
                            aMRK_Task_Details.Comments = "";
                            aMRK_Task_Details.Date = DateTime.Now;
                            aMRK_Task_Details.Task = typeList.Input_Name;
                            aMRK_Task_Details.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                            aMRK_Task_Details.Create_Date = DateTime.Now;
                            aMRK_Task_Details.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                            _context.MRK_Task_Details.AddObject(aMRK_Task_Details);
                            _context.SaveChanges();
                        }

                        
                        if (result2 == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }


                    }

                }
                else if (saveButton.Text == "Update")
                {

                    if (handoverStatusDropDownList.Text == "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Handover Status')", true);
                    }
                    else if (handoverStatusDropDownList.Text != "--Select--")
                    {
                        if (handoverStatusDropDownList.Text == "Yes")
                        {
                            handoverConditins = true;
                        }
                        else if (handoverStatusDropDownList.Text == "No")
                        {
                            handoverConditins = false;
                        }



                        MRK_WorkOrder aMRK_WorkOrder = new MRK_WorkOrder();

                        aMRK_WorkOrder.MarketingInfoId = Convert.ToInt32(HidMarketingInfoId.Value);
                        aMRK_WorkOrder.WorkOrderDate = Convert.ToDateTime(workOrderDateTextBox.Text);
                        aMRK_WorkOrder.CompletionPeriod = workCompletionPeriodTextBox.Text;
                        aMRK_WorkOrder.ProposedAmount = Convert.ToDecimal(proposedAmountTextBox.Text);
                        aMRK_WorkOrder.SigningAmount = Convert.ToDecimal(signingAmountTextBox.Text);
                        aMRK_WorkOrder.RemainingAmount = Convert.ToDecimal(remainingAmountTextBox.Text);
                        aMRK_WorkOrder.Remarks = remarksTextBox.Text;
                        aMRK_WorkOrder.PaymentCondition = paymentConditionTextBox.Text;
                        aMRK_WorkOrder.AMC_Condition = amcConditionTextBox.Text;
                        aMRK_WorkOrder.DevelopmentDept = developmentDepartmentTextBox.Text;
                        aMRK_WorkOrder.HandoverStatus = handoverConditins;
                        aMRK_WorkOrder.WarrantyPeriod = Convert.ToInt32(warrentyPeriodTextBox.Text);
                        aMRK_WorkOrder.AMCDAte = Convert.ToDateTime(amcDateTextBox.Text);
                        aMRK_WorkOrder.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                        aMRK_WorkOrder.Edit_Date = DateTime.Now;
                        aMRK_WorkOrder.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        int workOrderId = Convert.ToInt16(HiddenFieldWorkOrderId.Value);
                        int result = aWorkOrderDetailsBLL.UpdateWorkOrderInfo(aMRK_WorkOrder, workOrderId);

                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        }

                    }

                    

                   
                }
                ClearAllControl();
                GetWorkOrderDetailsForGridView();

            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<officeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

            GetWorkOrderDetailsForGridView();

        }

        protected void proposedAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (signingAmountTextBox.Text != null)
                {
                    decimal proposedAmount = Convert.ToDecimal(proposedAmountTextBox.Text);
                    decimal signingAmount = Convert.ToDecimal(signingAmountTextBox.Text);

                    decimal remainingAmount = Convert.ToDecimal(proposedAmount - signingAmount);
                    remainingAmountTextBox.Text = remainingAmount.ToString();
                }
                
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        protected void signingAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (proposedAmountTextBox.Text != null)
                {
                    decimal proposedAmount = Convert.ToDecimal(proposedAmountTextBox.Text);
                    decimal signingAmount = Convert.ToDecimal(signingAmountTextBox.Text);

                    decimal remainingAmount = Convert.ToDecimal(proposedAmount - signingAmount);
                    remainingAmountTextBox.Text = remainingAmount.ToString();
                }
               
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        protected void WorkOrderGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            WorkOrderGridView.PageIndex = e.NewPageIndex;
            GetWorkOrderDetailsForGridView();
        }

        protected void imgButtonEidtWordOrder_Click(object sender, ImageClickEventArgs e)
        {

            workOrderDateTextBox.Enabled = false;
            workCompletionPeriodTextBox.Enabled = false;
            proposedAmountTextBox.Enabled = false;
            signingAmountTextBox.Enabled = false;

            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                Label lblID_WorkOrder = (Label)WorkOrderGridView.Rows[row.RowIndex].FindControl("lblID_work_order");

                int workOrderId = Convert.ToInt16(lblID_WorkOrder.Text);

                MarketingWorkOrder aMarketingWorkOrder = aWorkOrderDetailsBLL.GetSingaleWorkOrderDeatils(workOrderId);
                if (aMarketingWorkOrder != null)
                {
                    HiddenFieldWorkOrderId.Value = aMarketingWorkOrder.WoID.ToString();
                    workOrderDateTextBox.Text = aMarketingWorkOrder.WorkOrderDate.ToString("MM/dd/yyyy");
                    workCompletionPeriodTextBox.Text = aMarketingWorkOrder.CompletionPeriod.ToString();
                    proposedAmountTextBox.Text = aMarketingWorkOrder.ProposedAmount.ToString();
                    signingAmountTextBox.Text = aMarketingWorkOrder.SigningAmount.ToString();
                    remainingAmountTextBox.Text = aMarketingWorkOrder.RemainingAmount.ToString();
                    remarksTextBox.Text = aMarketingWorkOrder.Remarks.ToString();
                    warrentyPeriodTextBox.Text = aMarketingWorkOrder.WarrantyPeriod.ToString();
                    amcDateTextBox.Text = aMarketingWorkOrder.AMCDate.ToString("MM/dd/yyyy");

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
            paymentConditionTextBox.Text = "";
            amcConditionTextBox.Text = "";
            developmentDepartmentTextBox.Text = "";
            warrentyPeriodTextBox.Text = "";
            amcDateTextBox.Text = "";
            handoverStatusDropDownList.Text = "--Select--";
           
        }

        protected void warrentyPeriodTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //Calculate the AMC month
                int toMonth = Convert.ToInt32(warrentyPeriodTextBox.Text);

                int nowMonth = DateTime.Now.Month;
                int nowYear = DateTime.Now.Year;
                int nowDay = DateTime.Now.Day;

                // Find prevous year and month

                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month,nowDay);
                var first = month.AddMonths(toMonth);
                var finalUpdate = first.AddDays(1);

                amcDateTextBox.Text = finalUpdate.ToString("MM/dd/yyyy");
            }
            catch (Exception)
            {

                amcDateTextBox.Text = "";
            }
        }

        protected void searchTextBox2_TextChanged(object sender, EventArgs e)
        {
            GetWorkOrderDetailsForGridViewByClientName();
        }

      
        
    }
}