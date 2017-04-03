using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using ERPSSL.HRM.DAL;

namespace ERPSSL.Marketing
{
    public partial class MarketingInfo : System.Web.UI.Page
    {

        ERPSSL_Marketing_Entities _Context = new ERPSSL_Marketing_Entities();



        MarketingInfoBLL aMarketingInfoBLL = new MarketingInfoBLL();
        ProjectBLL aProjectBLL = new ProjectBLL();
        StageBLL aStageBLL = new StageBLL();
        int currentReferenceId;
        int currentProjectId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    LoadProjectsList();
                    LoadStageList();
                    GetMarketingInfoGridView();
                    LoadMarketingPerson();
                    LoadReference();
                    referenceTextBox.Visible = false;
                    projectTextBox.Visible = false;
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }

        }



        static int availableList = 0;

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



        protected void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Reference---------------------------------
                if (referenceCheckBox.Checked == true)
                {
                    MRK_Reference aMRK_Reference = new MRK_Reference();
                    aMRK_Reference.ReferenceName = referenceTextBox.Text;
                    aMRK_Reference.ReferenceNumber = "";
                    aMRK_Reference.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    aMRK_Reference.Create_Date = DateTime.Now;
                    aMRK_Reference.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    currentReferenceId = aMarketingInfoBLL.Savereference(aMRK_Reference);
                }
                else
                {
                    currentReferenceId = Convert.ToInt32(referenceDropDownList.SelectedValue.ToString());
                }


                //Project-----------------------------------------
                if (projectCheckBox.Checked == true)
                {
                    MRK_Project aMRK_Project = new MRK_Project();
                    aMRK_Project.ProjectName = projectTextBox.Text;
                    aMRK_Project.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    aMRK_Project.Create_Date = DateTime.Now;
                    aMRK_Project.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    currentProjectId = aMarketingInfoBLL.Saveproject(aMRK_Project);
                }
                else
                {
                    currentProjectId = Convert.ToInt32(projectDropDownList.SelectedValue.ToString());
                }



                if (visitDateTextBox.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Visit Date')", true);
                    return;
                }
                else if (clientNameTextBox.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Client Name!')", true);
                }
                else if (contactNumberTextBox.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Contact Number!')", true);
                }
                else if (projectDropDownList.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Project!')", true);
                }
                else if (stageDropDownList.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Stage!')", true);
                }
                else
                {
                    if (submitButton.Text == "Submit")
                    {
                        MRK_MarketingInfo aMRK_MarketingInfo = new MRK_MarketingInfo();
                        aMRK_MarketingInfo.VisitDate = Convert.ToDateTime(visitDateTextBox.Text);
                        aMRK_MarketingInfo.Client = clientNameTextBox.Text;
                        aMRK_MarketingInfo.ContactPerson = contactPersonTextBox.Text;
                        aMRK_MarketingInfo.Designation = designationTextBox.Text;
                        aMRK_MarketingInfo.ContactNumber = contactNumberTextBox.Text;
                        aMRK_MarketingInfo.Email = emailTextBox.Text;
                        aMRK_MarketingInfo.Address = addressTextBox.Text;
                        aMRK_MarketingInfo.ProjectId = currentProjectId;
                        aMRK_MarketingInfo.Module = moduleTextBox.Text;
                        aMRK_MarketingInfo.StageId = Convert.ToInt32(stageDropDownList.SelectedValue.ToString());
                        aMRK_MarketingInfo.MarketingPersonId = marketingPersonDropDownList.SelectedValue.ToString();
                        aMRK_MarketingInfo.ReferenceId = currentReferenceId;
                        aMRK_MarketingInfo.Remarks = remarksTextBox.Text;
                        aMRK_MarketingInfo.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                        aMRK_MarketingInfo.Create_Date = DateTime.Now;
                        aMRK_MarketingInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        int result = aMarketingInfoBLL.SaveMarketingInfo(aMRK_MarketingInfo);


                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }
                    }
                    else if (submitButton.Text == "Update")
                    {

                        MRK_MarketingInfo aMRK_MarketingInfo = new MRK_MarketingInfo();
                        aMRK_MarketingInfo.VisitDate = Convert.ToDateTime(visitDateTextBox.Text);
                        aMRK_MarketingInfo.Client = clientNameTextBox.Text;
                        aMRK_MarketingInfo.ContactPerson = contactPersonTextBox.Text;
                        aMRK_MarketingInfo.Designation = designationTextBox.Text;
                        aMRK_MarketingInfo.ContactNumber = contactNumberTextBox.Text;
                        aMRK_MarketingInfo.Email = emailTextBox.Text;
                        aMRK_MarketingInfo.Address = addressTextBox.Text;
                        aMRK_MarketingInfo.ProjectId = currentProjectId;
                        aMRK_MarketingInfo.Module = moduleTextBox.Text;
                        aMRK_MarketingInfo.StageId = Convert.ToInt32(stageDropDownList.SelectedValue.ToString());
                        aMRK_MarketingInfo.MarketingPersonId = marketingPersonDropDownList.SelectedValue.ToString();
                        aMRK_MarketingInfo.ReferenceId = currentReferenceId;
                        aMRK_MarketingInfo.Remarks = remarksTextBox.Text;
                        aMRK_MarketingInfo.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                        aMRK_MarketingInfo.Edit_Date = DateTime.Now;
                        aMRK_MarketingInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        int marketingInfoId = Convert.ToInt16(hidMarketingInfoId.Value);
                        int result = aMarketingInfoBLL.UpdateMarketingInfo(aMRK_MarketingInfo, marketingInfoId);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                            GetMarketingInfoGridView();
                            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                        }

                    }

                    ClearAllControl();


                    referenceCheckBox.Checked = false;
                    referenceTextBox.Visible = false;
                    referenceDropDownList.Visible = true;

                    projectCheckBox.Checked = false;
                    projectTextBox.Visible = false;
                    projectDropDownList.Visible = true;


                }
                GetMarketingInfoGridView();



            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<officeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void GetMarketingInfoGridView()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //List<aMr> salaryIncrementDetailList = new List<GradeR>();

                List<MarketingProjectStage> MRK_MarketingInfoLists = new List<MarketingProjectStage>();

                MRK_MarketingInfoLists = aMarketingInfoBLL.GetAllMarketingInfoList(OCODE).ToList();

                if (MRK_MarketingInfoLists.Count > 0)
                {
                    marketingInfoGridView.DataSource = MRK_MarketingInfoLists;
                    marketingInfoGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<officeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetMarketingInfoGridViewByClientName()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                string clientName = searchTextBox.Text;
                //List<aMr> salaryIncrementDetailList = new List<GradeR>();

                List<MarketingProjectStage> MRK_MarketingInfoLists = new List<MarketingProjectStage>();

                MRK_MarketingInfoLists = aMarketingInfoBLL.GetAllMarketingInfoListByClientName(OCODE, clientName).ToList();

                if (MRK_MarketingInfoLists.Count > 0)
                {
                    marketingInfoGridView.DataSource = MRK_MarketingInfoLists;
                    marketingInfoGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<officeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void LoadMarketingPerson()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<MarketingProjectStage> aMarketingProjectStage = new List<MarketingProjectStage>();

                aMarketingProjectStage = aMarketingInfoBLL.Get_AllPersonList(OCODE);

                if (aMarketingProjectStage.Count > 0)
                {
                    marketingPersonDropDownList.DataSource = aMarketingProjectStage;
                    marketingPersonDropDownList.DataTextField = "MArketingPersonName";
                    marketingPersonDropDownList.DataValueField = "MarketingPersonId";
                    marketingPersonDropDownList.DataBind();
                    marketingPersonDropDownList.Items.Insert(0, new ListItem("--Select--", "1"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        public void LoadReference()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<MRK_Reference> aMRK_Reference = new List<MRK_Reference>();

                aMRK_Reference = aMarketingInfoBLL.Get_AllReferenceList(OCODE);

                if (aMRK_Reference.Count > 0)
                {
                    referenceDropDownList.DataSource = aMRK_Reference;
                    referenceDropDownList.DataTextField = "ReferenceName";
                    referenceDropDownList.DataValueField = "ReferenceId";
                    referenceDropDownList.DataBind();
                    referenceDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        private void LoadProjectsList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<MRK_Project> aMRK_Project = new List<MRK_Project>();

                aMRK_Project = aProjectBLL.Get_AllProjectList(OCODE);

                if (aMRK_Project.Count > 0)
                {
                    projectDropDownList.DataSource = aMRK_Project;
                    projectDropDownList.DataTextField = "ProjectName";
                    projectDropDownList.DataValueField = "ProjectId";
                    projectDropDownList.DataBind();
                    projectDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadStageList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<MRK_Stage> MRK_StageList = new List<MRK_Stage>();

                MRK_StageList = aStageBLL.GetAllStagesList(OCODE);

                if (MRK_StageList.Count > 0)
                {
                    stageDropDownList.DataSource = MRK_StageList;
                    stageDropDownList.DataTextField = "StageName";
                    stageDropDownList.DataValueField = "StageId";
                    stageDropDownList.DataBind();
                    stageDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            MRK_MarketingInfo aMRK_MarketingInfo = new MRK_MarketingInfo();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            if (referenceCheckBox.Checked == true)
            {
                referenceCheckBox.Checked = false;
                referenceTextBox.Visible = false;
                referenceDropDownList.Visible = true;
            }

            if (projectCheckBox.Checked == true)
            {
                projectCheckBox.Checked = false;
                projectTextBox.Visible = false;
                projectDropDownList.Visible = true;
            }


            try
            {
                string marketingInfoIds = "";
                Label lblMarketingInfo = (Label)marketingInfoGridView.Rows[row.RowIndex].FindControl("lblMarketingInfo");
                if (lblMarketingInfo != null)
                {
                    string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    marketingInfoIds = lblMarketingInfo.Text;

                    aMRK_MarketingInfo = aMarketingInfoBLL.GetMarketingInfoForEdit(marketingInfoIds, OCODE);

                    if (aMRK_MarketingInfo != null)
                    {

                        hidMarketingInfoId.Value = aMRK_MarketingInfo.MarketingInfoId.ToString();
                        visitDateTextBox.Text = aMRK_MarketingInfo.VisitDate.ToString();
                        clientNameTextBox.Text = aMRK_MarketingInfo.Client.ToString();
                        contactPersonTextBox.Text = aMRK_MarketingInfo.ContactPerson.ToString();
                        designationTextBox.Text = aMRK_MarketingInfo.Designation.ToString();
                        contactNumberTextBox.Text = aMRK_MarketingInfo.ContactNumber.ToString();
                        emailTextBox.Text = aMRK_MarketingInfo.Email.ToString();
                        addressTextBox.Text = aMRK_MarketingInfo.Address.ToString();
                        projectDropDownList.SelectedValue = aMRK_MarketingInfo.ProjectId.ToString();
                        moduleTextBox.Text = aMRK_MarketingInfo.Module.ToString();
                        stageDropDownList.SelectedValue = aMRK_MarketingInfo.StageId.ToString();
                        referenceDropDownList.SelectedValue = aMRK_MarketingInfo.ReferenceId.ToString();
                        remarksTextBox.Text = aMRK_MarketingInfo.Remarks.ToString();
                        marketingPersonDropDownList.SelectedValue = aMRK_MarketingInfo.MarketingPersonId.ToString();


                        if (submitButton.Text == "Submit")
                        {
                            submitButton.Text = "Update";
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<HRM_SalaryIncrement_Details>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }


        }

        public void ClearAllControl()
        {
            visitDateTextBox.Text = "";
            clientNameTextBox.Text = "";
            contactPersonTextBox.Text = "";
            designationTextBox.Text = "";
            contactNumberTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            moduleTextBox.Text = "";
            remarksTextBox.Text = "";

            LoadProjectsList();
            LoadStageList();
        }

        protected void marketingInfoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            marketingInfoGridView.PageIndex = e.NewPageIndex;
            GetMarketingInfoGridView();
        }

        protected void referenceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (referenceCheckBox.Checked == true)
            {
                referenceDropDownList.Visible = false;
                referenceTextBox.Visible = true;
            }
            else
            {
                referenceDropDownList.Visible = true;
                referenceTextBox.Visible = false;
            }

        }

        protected void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            GetMarketingInfoGridViewByClientName();
        }

        protected void projectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (projectCheckBox.Checked == true)
            {
                projectDropDownList.Visible = false;
                projectTextBox.Visible = true;
            }
            else
            {
                projectDropDownList.Visible = true;
                projectTextBox.Visible = false;
            }
        }

    }
}