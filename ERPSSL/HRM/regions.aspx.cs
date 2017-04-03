using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class regions : System.Web.UI.Page
    {
        Region_BLL objRegion_BLl = new Region_BLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getRegions();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getRegions()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var regions = objRegion_BLl.GetAllRegions(OCODE).ToList();
                if (regions.Count > 0)
                {
                    gridviewRegions.DataSource = regions.ToList();
                    gridviewRegions.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void gridViewOffice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewRegions.PageIndex = e.NewPageIndex;
            getRegions();

        }


        protected void btnRegionSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtbxRegionName.Text == "")
                {
                    //lblMessage.Text = "Please Input Region Name!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Region Name!')", true);

                }
                else if (txtbxResgionCode.Text == "")
                {
                    //lblMessage.Text = "Please Input Region Code!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Region Code!')", true);
                }
                else if (txtbxResgionCode.Text.Length > 3 || txtbxResgionCode.Text.Length < 3)
                {
                    //lblMessage.Text = "Region Code Minimum Length 3!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Region Code Minimum Length 3!')", true);
                }
                else
                {
                    HRM_Regions objRegion = new HRM_Regions();
                    objRegion.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objRegion.EDIT_DATE = DateTime.Now;
                    objRegion.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objRegion.RegionName = txtbxRegionName.Text;
                    objRegion.RegionCode = txtbxResgionCode.Text;




                    if (btnRegionSubmit.Text == "Submit")
                    {

                        if (IsExist(objRegion.RegionName))
                        {

                            int result = objRegion_BLl.InsertRegion(objRegion);
                            if (result == 1)
                            {
                                //lblMessage.Text = "Data Save successfully!";
                                //lblMessage.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                            }
                        }
                        else
                        {
                            //lblMessage.Text = "Data Already Exists!";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        }
                    }
                    else
                    {
                        if (hidRegionName.Value != txtbxRegionName.Text)
                        {
                            if (IsExist(objRegion.RegionName))
                            {
                                int RegionId = Convert.ToInt32(hidRegionId.Value);
                                int result = objRegion_BLl.UpdateUpdateRegion(objRegion, RegionId);
                                if (result == 1)
                                {
                                    //lblMessage.Text = "Data Update successfully!";
                                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                                }
                            }
                            else
                            {
                                //lblMessage.Text = "Data Already Exists!";
                                //lblMessage.ForeColor = System.Drawing.Color.Red;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                            }

                        }
                        else
                        {


                            int RegionId = Convert.ToInt32(hidRegionId.Value);
                            int result = objRegion_BLl.UpdateUpdateRegion(objRegion, RegionId);
                            if (result == 1)
                            {
                                //lblMessage.Text = "Data Update successfully!";
                                //lblMessage.ForeColor = System.Drawing.Color.Green;
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                            }
                        }




                    }
                    getRegions();
                    ClearRegionsUi();
                    //}
                    //else
                    //{
                    //    lblMessage.Text = "Data Already Exist!";
                    //    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //}
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }



        private bool IsExist(string Rname)
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();
                HRM_Regions objRegion = new HRM_Regions();
                bool status = false;
                int count = (from rgn in _context.HRM_Regions
                             where rgn.RegionName == Rname
                             select rgn.RegionID).Count();
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

        private void ClearRegionsUi()
        {
            try
            {
                txtbxRegionName.Text = "";
                txtbxResgionCode.Text = "";
                btnRegionSubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnRegionEdit_Click(object sender, EventArgs e)
        {
            List<HRM_Regions> Regions = new List<HRM_Regions>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string regionId = "";
                Label lblSectionId = (Label)gridviewRegions.Rows[row.RowIndex].FindControl("lblRegionId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    regionId = lblSectionId.Text;
                    Regions = objRegion_BLl.getRegionsByRegionIdandCode(regionId, OCODE);

                    if (Regions.Count > 0)
                    {
                        foreach (HRM_Regions region in Regions)
                        {
                            hidRegionId.Value = region.RegionID.ToString();
                            hidRegionName.Value = txtbxRegionName.Text = region.RegionName;
                            txtbxResgionCode.Text = region.RegionCode;
                            if (btnRegionSubmit.Text == "Submit")
                            {
                                btnRegionSubmit.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}