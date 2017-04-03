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
    public partial class ViewCurrentMonthVisit : System.Web.UI.Page
    {

        MarketingInfoBLL aMarketingInfoBLL = new MarketingInfoBLL();
        ProjectBLL aProjectBLL = new ProjectBLL();
        StageBLL aStageBLL = new StageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    if (Session["MarketingId"].ToString() == null)
                    {

                    }
                    else
                    {
                        LoadData();

                        LoadMarketingPerson();

                        LoadReference();

                        LoadProjectsList();

                        LoadStageList();
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
            MRK_MarketingInfo aMRK_MarketingInfo = new MRK_MarketingInfo();
            string marketingInfoIds = "";
            try
            {

                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                marketingInfoIds = Session["MarketingId"].ToString();

                aMRK_MarketingInfo = aMarketingInfoBLL.GetMarketingInfoForEdit(marketingInfoIds, OCODE);

                if (aMRK_MarketingInfo != null)
                {

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

                }

            }
            catch (Exception ex)
            {

                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<HRM_SalaryIncrement_Details>.SetLog(ex, EID);
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
    }
}