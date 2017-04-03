using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;

namespace ERPSSL.Adminpanel
{
    public partial class UserAccess : System.Web.UI.Page
    {
        UserAccessBLL UserAccessBllObj = new UserAccessBLL();
        RoleBLL roleBll = new RoleBLL();
        PageBLL pageBll = new PageBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getUserList();
                    GetRole();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetRole()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<tbl_UserRole> userRole = roleBll.GetRoles(Ocode);
                if (userRole.Count > 0)
                {
                    drpRole.DataSource = userRole;
                    drpRole.DataTextField = "RoleName";
                    drpRole.DataValueField = "RoleID";
                    drpRole.DataBind();
                    drpRole.Items.Insert(0, new ListItem("--Select--", "0"));

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getUserList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<tbl_User> useres = UserAccessBllObj.GetUser(Ocode);
                if (useres.Count > 0)
                {
                    drpUserName.DataSource = useres;
                    drpUserName.DataTextField = "UserFullName";
                    drpUserName.DataValueField = "UserID";
                    drpUserName.DataBind();
                    drpUserName.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void drpRole_change(object sender, EventArgs e)
        {
            try
            {

                int role = Convert.ToInt32(drpRole.SelectedValue);
                string UserName = drpUserName.SelectedValue.ToString();
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<PPermissionList> pageParmissiones = pageBll.getPagePermissionByRoleId(Ocode, role);

                if (pageParmissiones.Count > 0)
                {
                    gridviewPagePermissiones.DataSource = pageParmissiones;
                    gridviewPagePermissiones.DataBind();
                    GetUserAccessByRoleAndUserID(role, UserName, Ocode);

                }
                else
                {
                    gridviewPagePermissiones.DataSource = null;
                    gridviewPagePermissiones.DataBind();
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetUserAccessByRoleAndUserID(int role, string UserName, string Ocode)
        {
            try
            {
                List<tbl_UserAccess> UserAccess = pageBll.GetUserAccessByRoleAndUserID(role, UserName, Ocode);

                if (UserAccess.Count > 0)
                {

                    foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                    {

                        Label lblPagePermissionId = ((Label)gvRow.FindControl("lblPageId"));
                        CheckBox Checkbox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        int pageId = Convert.ToInt16(lblPagePermissionId.Text);
                        var ispage = UserAccess.FirstOrDefault(x => x.PageID == pageId);
                        if (ispage != null)
                        {
                            Checkbox.Checked = true;
                        }
                        else
                        {
                            Checkbox.Checked = false;

                        }



                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerChkBox = ((CheckBox)gridviewPagePermissiones.HeaderRow.FindControl("headerLevelCheckBox"));

            if (headerChkBox.Checked == true)
            {
                foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    rowChkBox.Checked = true;//((CheckBox)sender).Checked;       
                }
            }
            else
            {
                foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                    rowChkBox.Checked = false;
                }
            }
        }
        protected void BtnSave_Clcik(object sender, EventArgs e)
        {
            try
            {
                List<tbl_UserAccess> UserAccessList = new List<tbl_UserAccess>();
                CheckBox headerChkBox = ((CheckBox)gridviewPagePermissiones.HeaderRow.FindControl("headerLevelCheckBox"));
                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                    {
                        tbl_UserAccess UAccess = new tbl_UserAccess();
                        UAccess.UserID = new Guid(drpUserName.SelectedValue.ToString());
                        UAccess.UserName = drpUserName.SelectedItem.ToString();
                        UAccess.RoleID = Convert.ToInt32(drpRole.SelectedValue.ToString());
                        UAccess.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                        UAccess.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        UAccess.EDIT_DATE = DateTime.Now;

                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        Label lblPagePermissionId = ((Label)gvRow.FindControl("lblPageId"));
                        Label lblcatId = ((Label)gvRow.FindControl("lblcategoryhId"));
                        Label lblMulId = ((Label)gvRow.FindControl("lblModuleId"));

                        CheckBox rowCanVisit = ((CheckBox)gvRow.FindControl("chCanVisit"));
                        CheckBox rowCanEdit = ((CheckBox)gvRow.FindControl("ChCanEdit"));
                        CheckBox rowCanDelete = ((CheckBox)gvRow.FindControl("ChCanDelete"));
                        CheckBox rowcanExecute = ((CheckBox)gvRow.FindControl("ChCanExecute"));

                        UAccess.PageID = Convert.ToInt32(lblPagePermissionId.Text);
                        UAccess.CategoryId = Convert.ToInt32(lblcatId.Text);
                        UAccess.ModuleId = Convert.ToInt32(lblMulId.Text);

                        UAccess.CanVisit = Convert.ToBoolean(rowCanVisit.Checked);
                        UAccess.CanExecute = Convert.ToBoolean(rowcanExecute.Checked);
                        UAccess.CanEdit = Convert.ToBoolean(rowCanEdit.Checked);
                        UAccess.CanDelete = Convert.ToBoolean(rowCanDelete.Checked);

                        UserAccessList.Add(UAccess);
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;       
                    }
                }

                else
                {
                    foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        if (rowChkBox.Checked == true)
                        {
                            tbl_UserAccess UAccess = new tbl_UserAccess();
                            UAccess.UserID = Guid.Parse(drpUserName.SelectedValue.ToString());
                            UAccess.UserName = drpUserName.SelectedItem.ToString();
                            UAccess.RoleID = Convert.ToInt32(drpRole.SelectedValue.ToString());
                            UAccess.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                            UAccess.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            UAccess.EDIT_DATE = DateTime.Now;
                            Label lblPagePermissionId = ((Label)gvRow.FindControl("lblPageId"));
                            Label lblcatId = ((Label)gvRow.FindControl("lblcategoryhId"));
                            Label lblMulId = ((Label)gvRow.FindControl("lblModuleId"));

                            CheckBox rowCanVisit = ((CheckBox)gvRow.FindControl("chCanVisit"));
                            CheckBox rowCanEdit = ((CheckBox)gvRow.FindControl("ChCanEdit"));
                            CheckBox rowCanDelete = ((CheckBox)gvRow.FindControl("ChCanDelete"));
                            CheckBox rowcanExecute = ((CheckBox)gvRow.FindControl("ChCanExecute"));

                            UAccess.PageID = Convert.ToInt32(lblPagePermissionId.Text);
                            UAccess.CategoryId = Convert.ToInt32(lblcatId.Text);
                            UAccess.ModuleId = Convert.ToInt32(lblMulId.Text);

                            UAccess.CanVisit = Convert.ToBoolean(rowCanVisit.Checked);
                            UAccess.CanExecute = Convert.ToBoolean(rowcanExecute.Checked);
                            UAccess.CanEdit = Convert.ToBoolean(rowCanEdit.Checked);
                            UAccess.CanDelete = Convert.ToBoolean(rowCanDelete.Checked);
                            UserAccessList.Add(UAccess);



                        }

                    }

                }
                int result = UserAccessBllObj.SaveUserAccess(UserAccessList);
                if (result == 1)
                {
                    //lblStatus.Text = "Data Save Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void gridviewPagePermissiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewPagePermissiones.PageIndex = e.NewPageIndex;
            int role = Convert.ToInt32(drpRole.SelectedValue);
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<PPermissionList> pageParmissiones = pageBll.getPagePermissionByRoleId(Ocode, role);
            if (pageParmissiones.Count > 0)
            {
                gridviewPagePermissiones.DataSource = pageParmissiones;
                gridviewPagePermissiones.DataBind();
            }
        }

        //protected void gridviewPagePermissiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //    gridviewPagePermissiones.PageIndex = e.NewPageIndex;
        //    GetRole();

        //}
    }
}