using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class section : System.Web.UI.Page
    {
        SECTION_BLL objSec_BLL = new SECTION_BLL();
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {

                if (!IsPostBack)
                {
                    //DepartmentList();
                    GetScections();
                    GetResionForDepartment();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }


        protected void gridviewSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewSection.PageIndex = e.NewPageIndex;
            GetScections();

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

        protected void drpdwnOffice_SelecttedIndexChanged(object sender, EventArgs e)
        {
            int officeId = Convert.ToInt16(drpdwnOffice.SelectedValue);
            GetDepartmentByOfficeID(officeId);
        }


        private void GetDepartmentByOfficeID(int officeId)
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
        private void GetScections()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //List<HRM_SECTIONS> objSection = new List<HRM_SECTIONS>();
                List<Section> objsection = new List<Section>();
                objsection = objSec_BLL.GetSections(OCODE).ToList();
                if (objsection.Count > 0)
                {
                    gridviewSection.DataSource = objsection;
                    gridviewSection.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void DepartmentList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objDept_BLL.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpDepartment.DataSource = row.ToList();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (drpdwnResionForDepartment.SelectedItem.ToString() == "--Select--")
                {
                    //    lblMessage.Text = "";
                    //    lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Resion!')", true);
                }


                else if (drpdwnOffice.SelectedItem.ToString() == "--Select--")
                {
                    //  lblMessage.Text = "";
                    //   lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Office!')", true);
                }

                else if (drpDepartment.SelectedItem.ToString() == "--Select--")
                {
                    // lblMessage.Text = "";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Department!')", true);
                }
                else if (txtbxSection.Text == "")
                {
                    //      lblMessage.Text = "";
                    //      lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input  Section Name!')", true);
                }


                else
                {

                    HRM_SECTIONS objsection = new HRM_SECTIONS();
                    objsection.DPT_ID = Convert.ToInt32(drpDepartment.SelectedValue.ToString());
                    objsection.OfficeID = Convert.ToInt32(drpdwnOffice.SelectedValue.ToString());
                    objsection.RegionID = Convert.ToInt32(drpdwnResionForDepartment.SelectedValue.ToString());
                    objsection.DPT_ID = Convert.ToInt32(drpDepartment.SelectedValue.ToString());
                    objsection.SEC_NAME = txtbxSection.Text;
                    objsection.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objsection.EDIT_DATE = DateTime.Now;
                    objsection.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    if (btnSave.Text == "Submit")
                    {

                        int result = objSec_BLL.SaveSection(objsection);
                        if (result == 1)
                        {
                            //    lblMessage.Text = "Data Save successfully!";
                            //    lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                        }

                    }
                    else
                    {
                        int sectionId = Convert.ToInt32(hidSectionId.Value);
                        int result = objSec_BLL.UpdateOffice(objsection, sectionId);
                        if (result == 1)
                        {
                            //  lblMessage.Text = "Data Update successfully!";
                            //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        }

                    }

                    //DepartmentList();
                    GetScections();
                    drpDepartment.ClearSelection();
                    drpdwnOffice.ClearSelection();
                    drpdwnResionForDepartment.ClearSelection();
                    txtbxSection.Text = "";
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
            HRM_SECTIONS objSection = new HRM_SECTIONS();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string sectionId = "";
                Label lblSectionId = (Label)gridviewSection.Rows[row.RowIndex].FindControl("lblSection");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    string sId = lblSectionId.Text;

                    //int result = objSec_BLL.DeleteSection(sId);
                    //if (result == 1)
                    //{
                    //    lblMessage.Text = "Data Update successfully!";
                    //    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //    GetScections();
                    //}



                    objSection = objSec_BLL.GetSctionBySectionId(sId, OCODE);

                    if (objSection != null)
                    {
                        hidSectionId.Value = objSection.SEC_ID.ToString();
                        txtbxSection.Text = objSection.SEC_NAME;
                        GetResionForDepartment();
                        drpdwnResionForDepartment.SelectedValue = objSection.RegionID.ToString();
                        BridOfficeByResion(Convert.ToInt16(drpdwnResionForDepartment.SelectedValue));
                        drpdwnOffice.SelectedValue = objSection.OfficeID.ToString();
                        GetDepartmentByOfficeID(Convert.ToInt16(drpdwnOffice.SelectedValue));
                        drpDepartment.SelectedValue = objSection.DPT_ID.ToString();

                        // drpDepartment.SelectedValue = objSection.DPT_ID.ToString();

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