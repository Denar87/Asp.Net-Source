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
    public partial class VisitStatusUpdate : System.Web.UI.Page
    {
        VisitStatusUpdateBLL aVisitStatusUpdateBLL = new VisitStatusUpdateBLL();
        VisitStatusUpdateDAL aVisitStatusUpdateDAL = new VisitStatusUpdateDAL();
        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();

        static int availableList = 0;
        

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
                var allClient = from m in _context.MRK_MarketingInfo
                                where ((m.Client.Contains(prefixText)) && m.StageId <= 2)
                                select m;
                List<String> clientList = new List<String>();


                foreach (var clientName in allClient)
                {
                    clientList.Add(clientName.Client);
                }

                if (clientList.Count == 0)
                {
                    availableList = 0;
                }
                else 
                {
                    availableList = 1;
                }

                return clientList;
            }
        }

        protected void clientNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (availableList == 0)
            {

            }
            else
            {
                try
                {
                    string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                    string clientName = clientNameTextBox.Text;

                    MarketingProjectStage aMarketingProjectStage = aVisitStatusUpdateBLL.GetInvidualMarketingInfoList(OCode, clientName);
                    if (aMarketingProjectStage != null)
                    {

                        HidMarketingInfoId.Value = aMarketingProjectStage.MarketingInfoId.ToString();
                        visitDateTextBox.Text = aMarketingProjectStage.VisitDate.ToString("MM/dd/yyyy");
                        //clientNameTextBox.Text = aMarketingProjectStage.Client.ToString();
                        contactPersonTextBox.Text = aMarketingProjectStage.ContactPerson.ToString();
                        designationTextBox.Text = aMarketingProjectStage.Designation.ToString();
                        contactNumberTextBox.Text = aMarketingProjectStage.ContactNumber.ToString();
                        emailTextBox.Text = aMarketingProjectStage.Email.ToString();
                        addressTextBox.Text = aMarketingProjectStage.Address.ToString();
                        projectTextBox.Text = aMarketingProjectStage.ProjectName.ToString();
                        moduleTextBox.Text = aMarketingProjectStage.Module.ToString();
                        marketingPersonTextBox.Text = aMarketingProjectStage.MArketingPersonName.ToString();
                        referenceTextBox.Text = aMarketingProjectStage.ReferenceName.ToString();
                        remarksTextBox.Text = aMarketingProjectStage.Remarks.ToString();
                        stageTextBox.Text = aMarketingProjectStage.StageName.ToString();

                    }


                    // Finding WorkId of Marketing Info 
                    int marketingInfoId = Convert.ToInt32(HidMarketingInfoId.Value);
                    //int workOrderId = aVisitStatusUpdateBLL.GetWorkOrderId(marketingInfoId);

                    //if (workOrderId != 0)
                    //{
                    // Check WorkId At Task Details Table
                    List<int> taskIdList = new List<int>();
                    taskIdList = aVisitStatusUpdateBLL.getTaskIdList(marketingInfoId);

                    if (taskIdList.Count == 0)
                    {
                        List<LC_InputType> inputTypeList = new List<LC_InputType>();
                        inputTypeList = aVisitStatusUpdateBLL.GetAllTask();

                        foreach (LC_InputType typeList in inputTypeList)
                        {
                            MRK_Task_Details aMRK_Task_Details = new MRK_Task_Details();
                            aMRK_Task_Details.WorkOrderId = marketingInfoId;
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

                        LoadTaskToGrid();

                    }
                    else
                    {
                        LoadTaskToGrid();
                    }
                    //}
                    //else
                    //{
                    //    GridTask.DataSource = null;
                    //}




                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

           
        }

        public void LoadTaskToGrid()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            
            //Select Order Id
            int marketingInfoId = Convert.ToInt32(HidMarketingInfoId.Value); 
            //int OrderId = aVisitStatusUpdateBLL.GetOrderId(marketingInfoId);
            //HiddenFieldworkOrderId.Value = OrderId.ToString();

            //Load to grid view
            List<MRK_Task_Details> aTaskList = new List<MRK_Task_Details>();

            aTaskList = aVisitStatusUpdateBLL.GetTaskDetailsByWorkOrderNo(marketingInfoId, OCODE).ToList();


            if (aTaskList.Count > 0)
            {
                GridTask.DataSource = aTaskList;
                GridTask.DataBind();
            }
        }

       
        protected void GridTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridTask.PageIndex = e.NewPageIndex;
                LoadTaskToGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridTask_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridTask.EditIndex = -1;
                LoadTaskToGrid();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void GridTask_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    DropDownList ddlStatus = null;
        //   // DropDownList ddlResposiblePerson = null;

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        ddlStatus = e.Row.FindControl("ddlStatus") as DropDownList;
        //        ddlResposiblePerson = e.Row.FindControl("ddlResposiblePerson") as DropDownList;

        //    }
        //    if (ddlStatus != null)
        //    {
        //        ddlStatus.DataBind();
        //        ddlStatus.Items.Insert(0, new ListItem("Pending", "Pending"));
        //        ddlStatus.Items.Insert(1, new ListItem("Done", "Done"));
        //        ddlStatus.Items.Insert(2, new ListItem("On going", "On going"));

        //        ItemList dr = e.Row.DataItem as ItemList;

        //        ddlStatus.SelectedValue = dr.Status;

        //    }
        //    if (ddlResposiblePerson != null)
        //    {

        //        var result = masterBLL.GetAllResposiblePerson();
        //        ddlResposiblePerson.DataSource = result;
        //        ddlResposiblePerson.DataTextField = "FirstName";
        //        ddlResposiblePerson.DataValueField = "EID";
        //        ddlResposiblePerson.DataBind();
        //        ddlResposiblePerson.Items.Insert(0, new ListItem("Select One", "0"));





        //        ItemList dr = e.Row.DataItem as ItemList;

        //        ddlResposiblePerson.SelectedItem.Text = dr.Responsible_Person;

        //      //  Label lblResposiblePerson = ((Label)row.FindControl("lblResposiblePerson"));
        //        //DataRowView dr = e.Row.DataItem as DataRowView;
        //        //ddlResposiblePerson.SelectedValue = dr["lblResposiblePerson"].ToString();
        //}


        protected void GridTask_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridTask.EditIndex = e.NewEditIndex;
                LoadTaskToGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridTask_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridTask.Rows[e.RowIndex];


            Label lblID = (Label)row.FindControl("lblID");
            // Label lblID = (Label)row.FindControl("Label1");
            int ID = Convert.ToInt32(lblID.Text);
            TextBox txtTergetQty = ((TextBox)row.FindControl("txtTergetQty"));
            TextBox txtSchedule_Date = ((TextBox)row.FindControl("txtSchedule_Date"));


            TextBox txtRemarks = ((TextBox)row.FindControl("txtRemarks"));
            TextBox txtComments = ((TextBox)row.FindControl("txtComments"));


            MRK_Task_Details aMRK_Task_Details = new MRK_Task_Details();


            aMRK_Task_Details.WorkOrderId = Convert.ToInt32(HiddenFieldworkOrderId.Value);

            DateTime? nullabledate = null;


            aMRK_Task_Details.Date = txtSchedule_Date.Text == "" ? nullabledate : Convert.ToDateTime(txtSchedule_Date.Text);
            aMRK_Task_Details.Remarks = txtRemarks.Text;
            aMRK_Task_Details.Comments = txtComments.Text;
            aMRK_Task_Details.EditDate = DateTime.Today;
            aMRK_Task_Details.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
            aMRK_Task_Details.OCode = ((SessionUser)Session["SessionUser"]).OCode;

            int result1 = aVisitStatusUpdateBLL.UpdateTaskDetails(aMRK_Task_Details, ID);

            if (result1 == 1)
            {


                //GridTask.EditIndex = -1;
                //LoadTaskDetails();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);

            }
        }




    }
}