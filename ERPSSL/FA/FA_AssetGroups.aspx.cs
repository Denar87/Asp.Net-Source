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
    public partial class FA_AssetGroups : System.Web.UI.Page
    {
        AssetConfiguration_BLL AssetConfigBll = new AssetConfiguration_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGroups();
            }
        }
          private void LoadGroups()
        {
             
            grdAssetGroups.DataSource = AssetConfigBll.GetAllGroups();
            grdAssetGroups.DataBind();
            
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GroupCode", txtGroupCode.Text.ToUpper());
            ht.Add("GroupName", txtAssetGroupName.Text);
            ht.Add("ACDepreciationRate", txtACDepRate.Text);
            ht.Add("TaxDepreciationRate", txtTxDepRate.Text);
            ht.Add("Tangibility", ddlTangibility.SelectedItem.Text);
            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
            ht.Add("SystemUserId", ((SessionUser)Session["SessionUser"]).UserId);
            //ht.Add("OCode", "8989");
            //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");

            if (hdfAssetGroup.Value =="Edit")
            {
                if (AssetConfigBll.SaveGroup(ht))
                {
                    LoadGroups();
                    
                    ClearForm();
                    lblMessage.Text = "<font color='green'>Group has been saved successfully !</font>";
                }
                else
                {
                    lblMessage.Text = "<font color='red'>Error in saving group! Please try again</font>"; ;
                }
            }
            else
            {
                if (AssetConfigBll.GroupCodeExist(txtGroupCode.Text) == false)
                {

                    if (AssetConfigBll.SaveGroup(ht))
                    {
                        LoadGroups();
                        ClearForm();
                        lblMessage.Text = "<font color='green'>Group has been Updated successfully !</font>";
                    }
                    else
                    {
                        lblMessage.Text = "<font color='red'>Error in Update group! Please try again</font>"; ;
                    }
                }
                else
                {
                    lblMessage.Text = "<font color='red'>Group code already exists. Please try a new one.</font>"; ;
                }
            }
        }

        //Clear
        private void ClearForm()
        {
            txtACDepRate.Text = string.Empty;
            txtTxDepRate.Text = string.Empty;
            txtAssetGroupName.Text = string.Empty;
            txtGroupCode.Text = string.Empty;
            txtGroupCode.Enabled = true;
            hdfAssetGroup.Value = string.Empty;
            grdAssetGroups.SelectedIndex = -1;
            ddlTangibility.ClearSelection();
           
        }

        //deleting row

        protected void imgbtnDelete_Clik(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                
                string GroupCode = "";
                Label lblGroupCode = (Label)grdAssetGroups.Rows[row.RowIndex].FindControl("lblGroupCode");
                if (lblGroupCode != null)
                {

                    GroupCode = lblGroupCode.Text;
                    if (AssetConfigBll.DeleteGroup(GroupCode))
                    {
                        lblMessage.Text = "Row Data Successfully Delete from Record";
                        lblMessage.ForeColor = Color.Maroon;
                        LoadGroups();
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
            LoadGroups();

        }

        //data show
        protected void imgBtnEdit_Click(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                string GroupCode = "";
                Label lblGroupCode = (Label)grdAssetGroups.Rows[row.RowIndex].FindControl("lblGroupCode");
                if (lblGroupCode != null)
                {
              
                    GroupCode = lblGroupCode.Text;
                    DataTable dt = AssetConfigBll.GetGroupById(GroupCode);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtGroupCode.Text = dr["GroupCode"].ToString();
                        txtAssetGroupName.Text = dr["GroupName"].ToString();
                        txtACDepRate.Text = dr["ACDepreciationRate"].ToString();
                        txtTxDepRate.Text = dr["TaxDepreciationRate"].ToString();
                        ddlTangibility.SelectedItem.Text = dr["Tangibility"].ToString();
                        txtGroupCode.Enabled = false;
                        hdfAssetGroup.Value = "Edit";
                        
                        //btnSubmit.Text = "Update";
                    }

                }
            }
            catch
            {
            }
            LoadGroups();

        }

        //paging

        protected void grdAssetGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdAssetGroups.PageIndex = e.NewPageIndex;
                LoadGroups();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}