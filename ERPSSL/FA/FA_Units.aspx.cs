using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ERPSSL.FA.BLL;
using System.Drawing;
using System.Data;

namespace ERPSSL.FA
{
    public partial class FA_Units : System.Web.UI.Page
    {
        AssetConfiguration_BLL AssetConfigBll = new AssetConfiguration_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUnits();
            }

        }
        private void LoadUnits()
        {
            grdUnit.DataSource = AssetConfigBll.GetUnit();
            grdUnit.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("UnitId", hdnUnitId.Value);
            ht.Add("UnitName", txtUnit.Text);
            ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
            ht.Add("SystemUserId", ((SessionUser)base.Session["SessionUser"]).UserId);
            //ht.Add("OCode", "8989");
            //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
            if (AssetConfigBll.SaveUnit(ht))
            {
                LoadUnits();
                ClearForm();
                lblMessage.Text = "<font color='green'>Unit has been saved successfully !</font>";
            }
            else
            {
                lblMessage.Text = "<font color='red'>Error in updating Unit!</font>";
            }

        }

        //deleting row

        protected void imgbtnDelete_Clik(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                string unitId = "";
                Label lblUnitID = (Label)grdUnit.Rows[row.RowIndex].FindControl("lblUnitId");
                if (lblUnitID != null)
                {

                    unitId = lblUnitID.Text;
                    if (AssetConfigBll.UnitDelete(unitId))
                    {
                        lblMessage.Text = "Row Data Successfully Delete from Record";
                        lblMessage.ForeColor = Color.Maroon;
                        LoadUnits();
                    }
                    else
                    {
                        lblMessage.Text = "Row Data Could Not Delete";
                        lblMessage.ForeColor = Color.Red;
                    }

                }
            }
            catch
            {
            }
            LoadUnits();

        }

        //data show
        protected void imgBtnEdit_Click(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                string unitId = "";
                Label lblUnitID = (Label)grdUnit.Rows[row.RowIndex].FindControl("lblUnitId");
                if (lblUnitID != null)
                {

                    unitId = lblUnitID.Text;
                    DataTable dt = AssetConfigBll.GetUnBiyId(unitId);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtUnit.Text = dr["UnitName"].ToString();
                        hdnUnitId.Value = unitId;
                        //btnSubmit.Text = "Update";
                    }

                }
            }
            catch
            {
            }
            LoadUnits();

        }

        private void ClearForm()
        {
            txtUnit.Text = string.Empty;
            hdnUnitId.Value = string.Empty;

            //grdUnits.SelectedIndex = -1;
        }

        //paging


        protected void grdUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdUnit.PageIndex = e.NewPageIndex;
                LoadUnits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}