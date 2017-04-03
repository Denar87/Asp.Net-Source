using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV
{
    public partial class Unit : System.Web.UI.Page
    {
        UnitBLL unitBll = new UnitBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetAllUnit();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void GetAllUnit()
        {
            try
            {
                List<Inv_Unit> units = unitBll.GetAllUnit();
                if (units.Count > 0)
                {
                    grdUnit.DataSource = units;
                    grdUnit.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void grdUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnit.PageIndex = e.NewPageIndex;
            GetAllUnit();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_Unit unitObj = new Inv_Unit();
                unitObj.UnitName = txtUnitName.Text;

                int Unitcount = (from unt in _context.Inv_Unit
                                 where unt.UnitName == unitObj.UnitName
                                 select unt.UnitId).Count();
                if (Unitcount == 0)
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        //unitObj.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        unitObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                        int result = unitBll.InsertUnit(unitObj);
                        if (result == 1)
                        {
                            // lblMessage.Text = "Data Saved Successfully";
                            //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);

                        }
                        else
                        {
                            //lblMessage.Text = "Data Saving Failure";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
                        int unitId = Convert.ToInt32(hdfUnitID.Value);

                        int result = unitBll.UpdateUnit(unitObj, unitId);
                        if (result == 1)
                        {
                            // lblMessage.Text = "Data Updated Sucessfully";
                            // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);

                        }
                        else
                        {
                            // lblMessage.Text = "Data Updating failure";
                            //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                        }
                    }
                    GetAllUnit();
                    txtUnitName.Text = "";
                    txtUnitName.Focus();
                    btnSubmit.Text = "Submit";
                }
                else
                {
                    //lblMessage.Text = "Data Already Exist";
                    //  lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                    txtUnitName.Text = "";
                    txtUnitName.Focus();
                    btnSubmit.Text = "Submit";
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ImgUnitEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Unit> units = new List<Inv_Unit>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string unitId = "";
                Label lblUnitId = (Label)grdUnit.Rows[row.RowIndex].FindControl("lblUnitId");
                if (lblUnitId != null)
                {
                    unitId = lblUnitId.Text;
                    units = unitBll.GetUnitById(unitId);

                    if (units.Count > 0)
                    {
                        foreach (Inv_Unit aunit in units)
                        {
                            hdfUnitID.Value = aunit.UnitId.ToString();
                            txtUnitName.Text = aunit.UnitName;

                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
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