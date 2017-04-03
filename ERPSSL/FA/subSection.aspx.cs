using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;

namespace ERPSSL.FA
{
    public partial class subSection : System.Web.UI.Page
    {
        SUB_SECTION_BLL objSubSec_BLL = new SUB_SECTION_BLL();
        SECTION_BLL objSecBll = new SECTION_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // GetSections();
                GetResionForDepartment();
                GetSubSections();
            }
        }
        protected void drpdwnResionForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(drpdwnResionForDepartment.SelectedValue);
                BridOfficeByResion(ResionId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void gridviewSubSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewSubSection.PageIndex = e.NewPageIndex;
            GetSubSections();

        }

        private void BridOfficeByResion(int ResionId)
        {
            var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
            if (row.Count > 0)
            {
                drpdwnOffice.DataSource = row.ToList();
                drpdwnOffice.DataTextField = "OfficeName";
                drpdwnOffice.DataValueField = "OfficeID";
                drpdwnOffice.DataBind();
                drpdwnOffice.Items.Insert(0, new ListItem("--Select--"));
            }
            else
            {
                drpdwnOffice.DataSource = null;
                drpdwnOffice.DataTextField = "OfficeName";
                drpdwnOffice.DataValueField = "OfficeID";
                drpdwnOffice.DataBind();
                drpdwnOffice.Items.Insert(0, new ListItem("--Select--"));
            }
        }
        protected void drpdwnOffice_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                int officeId = Convert.ToInt16(drpdwnOffice.SelectedValue);
                SetDepartmentByOfficeId(officeId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetDepartmentByOfficeId(int officeId)
        {


            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<HRM_DEPARTMENTS> departments = objDept_BLL.GetDepartmentByOfficeId(officeId, OCODE);
                if (departments.Count > 0)
                {

                    drpDepartment.DataSource = departments.ToList();

                    drpDepartment.DataTextField = "DPT_NAME";
                    drpDepartment.DataValueField = "DPT_ID";
                    drpDepartment.DataBind();
                    drpDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        //protected void drpdwnOffice_SelecttedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
        //        int officeId = Convert.ToInt16(drpdwnOffice.SelectedValue);
        //        List<HRM_DEPARTMENTS> departments = objDept_BLL.GetDepartmentByOfficeId(officeId, OCODE);
        //        if (departments.Count > 0)
        //        {

        //            drpDepartment.DataSource = departments.ToList();

        //            drpDepartment.DataTextField = "DPT_NAME";
        //            drpDepartment.DataValueField = "DPT_ID";
        //            drpDepartment.DataBind();
        //            drpDepartment.Items.Insert(0, new ListItem("--Select--"));
        //        }



        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void drpDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            
                int departmentId = Convert.ToInt16(drpDepartment.SelectedValue);
                SetSection(departmentId);
               

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetSection(int departmentId)
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<HRM_SECTIONS> sectiones = objSecBll.GetSectionByDepartmentId(OCODE, departmentId);
                if (sectiones.Count > 0)
                {
                    drpSection.DataSource = sectiones.ToList();
                    drpSection.DataTextField = "SEC_NAME";
                    drpSection.DataValueField = "SEC_ID";
                    drpSection.DataBind();
                    drpSection.Items.Insert(0, new ListItem("--Select--"));

                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }




        private void GetResionForDepartment()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = objOfficeBLL.GetAllDepartment(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpdwnResionForDepartment.DataSource = row.ToList();
                    drpdwnResionForDepartment.DataTextField = "RegionName";
                    drpdwnResionForDepartment.DataValueField = "RegionID";
                    drpdwnResionForDepartment.DataBind();
                    drpdwnResionForDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetSubSections()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<SubSection> objsection = new List<SubSection>();
                objsection = objSubSec_BLL.GetSub_Sections(OCODE).ToList();
                if (objsection.Count > 0)
                {
                    gridviewSubSection.DataSource = objsection.ToList();
                    gridviewSubSection.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetSections()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            var row = objSecBll.GetAllSection(OCODE).ToList();
            if (row.Count > 0)
            {
                drpSection.DataSource = row.ToList();
                drpSection.DataTextField = "SEC_NAME";
                drpSection.DataValueField = "SEC_ID";
                drpSection.DataBind();

                drpSection.DataBind();
                drpSection.Items.Insert(0, new ListItem("--Select--"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (drpdwnResionForDepartment.SelectedItem.ToString() == "--Select--")
                {
                 //   lblMessage.Text = "";
                  //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region!')", true);
                }
                else if (drpdwnOffice.SelectedItem.ToString() == "--Select--")
                {
                  //  lblMessage.Text = "";
                  //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Office!')", true);
                }
                else if (drpDepartment.SelectedItem.ToString() == "--Select--")
                {
                  //  lblMessage.Text = "";
                  //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Department!')", true);
                }

               else if (drpSection.SelectedItem.ToString() == "--Select--")
                {
                 //   lblMessage.Text = "";
                 //   lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Section!')", true);
                }
                else if (txtbxSubSection.Text == "")
                {
                 //   lblMessage.Text = "";
                 //   lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input  Sub-Section Name!')", true);
                }


                else
                {
                    HRM_SUB_SECTIONS objSubsection = new HRM_SUB_SECTIONS();


                    objSubsection.SUB_SEC_NAME = txtbxSubSection.Text;
                    objSubsection.SEC_ID = Convert.ToInt32(drpSection.SelectedValue.ToString());
                    objSubsection.RegionID = Convert.ToInt32(drpdwnResionForDepartment.SelectedValue.ToString());
                    objSubsection.OfficeID = Convert.ToInt32(drpdwnOffice.SelectedValue.ToString());
                    objSubsection.DepartmentID = Convert.ToInt32(drpDepartment.SelectedValue.ToString());
                    objSubsection.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objSubsection.EDIT_DATE = DateTime.Now;
                    objSubsection.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    if (btnSave.Text == "Submit")
                    {

                        int result = objSubSec_BLL.InsertSub_Section(objSubsection);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Save successfully!";
                           // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);

                        }

                    }
                    else
                    {
                        int sectionId = Convert.ToInt32(hidSubSectionId.Value);
                        int result = objSubSec_BLL.UpdateSub_Section(objSubsection, sectionId);
                        if (result == 1)
                        {
                           // lblMessage.Text = "Data Update successfully!";
                          //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        }

                    }

                    GetSubSections();             
                    drpDepartment.ClearSelection();
                    drpSection.ClearSelection();
                    drpdwnOffice.ClearSelection();
                    drpdwnResionForDepartment.ClearSelection();
                    txtbxSubSection.Text = "";
                    btnSave.Text = "Submit";

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void imgbtnDepartmentEdit_Click(object sender, EventArgs e)
        {
            HRM_SUB_SECTIONS objSubSection = new HRM_SUB_SECTIONS();

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string subSectionID = "";
                Label lblSubSectionId = (Label)gridviewSubSection.Rows[row.RowIndex].FindControl("lblSubSection");
                if (lblSubSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    subSectionID = lblSubSectionId.Text;
                    objSubSection = objSubSec_BLL.GetSubSectionById(subSectionID, OCODE);
                    //int result = objSubSec_BLL.DleteSubSectionById(OCODE, subSectionID);
                    //if (result == 1)
                    //{
                    //    lblMessage.Text = "Data Delete successfully!";
                    //    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //    GetSubSections();
                    //}

                    if (objSubSection != null)
                    {
                        hidSubSectionId.Value = objSubSection.SUB_SEC_ID.ToString();
                        txtbxSubSection.Text = objSubSection.SUB_SEC_NAME;
                        GetResionForDepartment();
                        drpdwnResionForDepartment.SelectedValue = objSubSection.RegionID.ToString();
                        BridOfficeByResion(Convert.ToInt16(drpdwnResionForDepartment.SelectedValue));
                        drpdwnOffice.SelectedValue = objSubSection.OfficeID.ToString();
                        SetDepartmentByOfficeId(Convert.ToInt16(drpdwnOffice.SelectedValue));
                        drpDepartment.SelectedValue = objSubSection.DepartmentID.ToString();
                        SetSection(Convert.ToInt16(drpDepartment.SelectedValue));
                        drpSection.SelectedValue = objSubSection.SEC_ID.ToString();
                        //drpSection.SelectedValue = objSubSection.SEC_ID.ToString();

                        if (btnSave.Text == "Submit")
                        {
                            btnSave.Text = "Update";
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}