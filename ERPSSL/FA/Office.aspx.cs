using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL;

namespace ERPSSL.FA
{
    public partial class Office : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        Region_BLL objRegion_BLl = new Region_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GerRegionList();
                GetOfficeListForGridview();
            }
        }

        protected void drpRegion_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int regionId = Convert.ToInt32(drpRegion.SelectedValue);
                HRM_Regions objRegion = new HRM_Regions();
                objRegion = objRegion_BLl.gerRegionCodeByRegionId(regionId);
                if (objRegion != null)
                {
                    lblRegionCode.Text = objRegion.RegionCode + "-";
                }
            }
            catch
            {


            }

        }

        protected void gridViewOffice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewOffice.PageIndex = e.NewPageIndex;
            GetOfficeListForGridview();

        }


        private void GerRegionList()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllDepartment(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpRegion.DataSource = row.ToList();
                    drpRegion.DataTextField = "RegionName";
                    drpRegion.DataValueField = "RegionID";
                    drpRegion.DataBind();
                    drpRegion.Items.Insert(0, new ListItem("---Select One---"));
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetOfficeListForGridview()
        {


            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_Office> objHRMoffice = new List<HRM_Office>();

                objHRMoffice = objOfficeBLL.GetOffices(OCODE).ToList();
                if (objHRMoffice.Count > 0)
                {
                    gridViewOffice.DataSource = objHRMoffice;
                    gridViewOffice.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        protected void imgbtnEdit_Clik(object sender, EventArgs e)
        {
            HRM_Office objOffice = new HRM_Office();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string officeId = "";
                Label lblOfficeId = (Label)gridViewOffice.Rows[row.RowIndex].FindControl("lblOfficeId");
                if (lblOfficeId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    officeId = lblOfficeId.Text;
                    objOffice = objOfficeBLL.GetOfficeById(officeId, OCODE);

                    if (objOffice != null)
                    {
                        hidOfficeId.Value = objOffice.OfficeID.ToString();
                        drpRegion.SelectedValue = objOffice.RegionId.ToString();
                        hidOfficeName.Value = txtbxOfficeName.Text = objOffice.OfficeName.ToString();
                        txtbxAddress.Text = objOffice.OfficeAddress.ToString();
                        string officeCode = objOffice.OfficeCode.ToString();
                        string[] occode = officeCode.Split('-');
                        lblRegionCode.Text = occode[0] + "-";
                        txtbxOfficeCode.Text = occode[1];


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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (drpRegion.SelectedItem.ToString() == "--Select--")
                {
                    //  lblMessage.Text = "";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region!')", true);
                }
                else if (txtbxOfficeName.Text == "")
                {
                    // lblMessage.Text = "";
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input  Office Name!')", true);
                }

                else if (txtbxOfficeCode.Text == "")
                {
                    //  lblMessage.Text = "";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input  Office Code!')", true);
                }
                else if (txtbxOfficeCode.Text.Length < 3)
                {
                    // lblMessage.Text = "";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Office Code Minimum Length 3!')", true);
                }
                else if (txtbxAddress.Text == "")
                {
                    //   lblMessage.Text = "";
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input  Office Address!')", true);
                }

                else
                {

                    HRM_Office objOffice = new HRM_Office();
                    objOffice.RegionId = Convert.ToInt32(drpRegion.SelectedValue.ToString());
                    objOffice.OfficeName = txtbxOfficeName.Text;
                    string FullCode = lblRegionCode.Text + txtbxOfficeCode.Text;
                    objOffice.OfficeCode = FullCode;
                    objOffice.OfficeAddress = txtbxAddress.Text;
                    objOffice.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objOffice.EDIT_DATE = DateTime.Now;
                    objOffice.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    if (btnSave.Text == "Submit")
                    {
                        if (IsExist(objOffice.OfficeName))
                        {

                            int result = objOfficeBLL.SaveOffice(objOffice);
                            if (result == 1)
                            {
                                //   lblMessage.Text = "Data Save successfully!";
                                //    lblMessage.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);

                            }
                        }
                        else
                        {
                            // lblMessage.Text = "";
                            // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        }

                    }
                    else
                    {
                        if (hidOfficeName.Value != txtbxOfficeName.Text)
                        {
                            if (IsExist(objOffice.OfficeName, objOffice.RegionId))
                            {
                                int officeId = Convert.ToInt32(hidOfficeId.Value);
                                int result = objOfficeBLL.UpdateOffice(objOffice, officeId);
                                if (result == 1)
                                {
                                    // lblMessage.Text = "Data Update successfully!";
                                    // lblMessage.ForeColor = System.Drawing.Color.Green;
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                                }

                            }
                            else
                            {
                                //   lblMessage.Text = "";
                                //   lblMessage.ForeColor = System.Drawing.Color.Red;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                            }
                        }

                        else
                        {
                            int officeId = Convert.ToInt32(hidOfficeId.Value);
                            int result = objOfficeBLL.UpdateOffice(objOffice, officeId);
                            if (result == 1)
                            {
                                //   lblMessage.Text = "Data Update successfully!";
                                //    lblMessage.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                            }
                        }

                    }
                    GetOfficeListForGridview();
                    ClearAllControl();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsExist(string Oname, int RId)
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();

                bool status = false;
                int count = (from rgn in _context.HRM_Office
                             where rgn.OfficeName == Oname && rgn.RegionId == RId
                             select rgn.OfficeName).Count();
                if (count == 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool IsExist(string Oname)
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();

                bool status = false;
                int count = (from rgn in _context.HRM_Office
                             where rgn.OfficeName == Oname
                             select rgn.OfficeName).Count();
                if (count == 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearAllControl()
        {
            GerRegionList();
            txtbxOfficeName.Text = "";
            txtbxOfficeCode.Text = "";
            txtbxAddress.Text = "";

        }

    }
}