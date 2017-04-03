﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.FA
{
    public partial class Departments : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    GetResionForDepartment();
                    GetAllDepartmentforGridview();
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
                        drpdwnResionForDepartment.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gridviewDepartmetn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
                 gridviewDepartmetn.PageIndex = e.NewPageIndex;
                 GetAllDepartmentforGridview();

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
        private void BridOfficeByResion(int ResionId)
        {
            var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
            if (row.Count > 0)
            {
                    drpdwnOffice.DataSource = row.ToList();
                    drpdwnOffice.DataTextField = "OfficeName";
                    drpdwnOffice.DataValueField = "OfficeID";
                    drpdwnOffice.DataBind();
                    drpdwnOffice.Items.Insert(0, new ListItem("---Select One---"));
            }
            else
            {
                    drpdwnOffice.DataSource = null;
                    drpdwnOffice.DataTextField = "OfficeName";
                    drpdwnOffice.DataValueField = "OfficeID";
                    drpdwnOffice.DataBind();
                    drpdwnOffice.Items.Insert(0, new ListItem("---Select One---"));
            }
        }
        protected void drpdwnOffice_SelecttedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                    int officeId = Convert.ToInt32(drpdwnOffice.SelectedValue);
                    HRM_Office objOffice = new HRM_Office();
                    objOffice = objOfficeBLL.GetOfficeCodeByOfficeId(officeId);
                    if (objOffice != null)
                    {
                        lblOfficeCode.Text = objOffice.OfficeCode + "-";
                    }
            }
            catch
            {


            }

        }
        protected void btnDepartmentSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                    if (drpdwnResionForDepartment.SelectedItem.ToString() == "---Select One---")
                    {
                         //   lblMessage.Text = "";
                         //   lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region!')", true);
                    }


                    else if (txtbxDepartemntName.Text == "")
                    {
                         //   lblMessage.Text = "";
                        //    lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Department Name!')", true);
                    }
                    else if (txtbxDepartmentCode.Text == "")
                    {
                           // lblMessage.Text = "P";
                          //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('lease Input Department Code!')", true);

                    }
                    else if (txtbxDepartmentCode.Text.Length < 3)
                    {
                          //  lblMessage.Text = "";
                          //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Department Code Minmum Length 3!')", true);
                    }
                    else
                    {
                            if (drpdwnOffice.SelectedItem.ToString() == "---Select One---")
                            {

                                  //  lblMessage.Text = "";
                               //     lblMessage.ForeColor = System.Drawing.Color.Red;
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Office')", true);
                            }
                        else
                        {

                                HRM_DEPARTMENTS objDepartment = new HRM_DEPARTMENTS();                     
                                objDepartment.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                                objDepartment.EDIT_DATE = DateTime.Now;                       
                                objDepartment.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                                objDepartment.Office_ID = Convert.ToInt32(drpdwnOffice.SelectedValue.ToString());
                                objDepartment.DPT_NAME = txtbxDepartemntName.Text;
                                objDepartment.ResionId = Convert.ToInt32(drpdwnResionForDepartment.SelectedValue.ToString());
                                string offcode = lblOfficeCode.Text + txtbxDepartmentCode.Text;

                                objDepartment.DPT_CODE = offcode;

                            if (btnDepartmentSubmit.Text == "Submit")
                            {
                                if (IsExist(objDepartment.DPT_NAME, objDepartment.DPT_CODE))
                                {
                                    int result = objDept_BLL.InsertDepartment(objDepartment);

                                    if (result == 1)
                                    {
                                        // lblMessage.Text = "Data Save successfully!";
                                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
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
                                    int DepartmentId = Convert.ToInt32(hidDepartmentId.Value);

                                    int result = objDept_BLL.UpdateDepartment(objDepartment, DepartmentId);

                                    if (result == 1)
                                    {
                                      //  lblMessage.Text = "Data Update successfully!";
                                       // lblMessage.ForeColor = System.Drawing.Color.Green;
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                                    }

                            }

                        GetAllDepartmentforGridview();
                        ClearDepartmentUi();

                        }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsExist(string Dname,string DCode)
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();

                bool status = false;
                int count = (from rgn in _context.HRM_DEPARTMENTS
                             where rgn.DPT_NAME == Dname && rgn.DPT_CODE == DCode
                             select rgn.DPT_NAME).Count();
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
        private void GetAllDepartmentforGridview()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<Department> department = new List<Department>();
                department = objDept_BLL.GetDepartment(OCODE).ToList();
                if (department.Count > 0)
                {
                    gridviewDepartmetn.DataSource = department;
                    gridviewDepartmetn.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void ClearDepartmentUi()
        {
            //drpdwnOffice.Items.Insert(0, new ListItem("--Select--"));
            //drpdwnResionForDepartment.Items.Insert(0, new ListItem("--Select--"));
         
                txtbxDepartemntName.Text = "";
                lblOfficeCode.Text = "";
                txtbxDepartmentCode.Text = "";
        }

        protected void imgbtnDepartmentEdit_Click(object sender, EventArgs e)
        {
            HRM_DEPARTMENTS objectDepartment = new HRM_DEPARTMENTS();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string deparId = "";
                Label lblDepartmentId = (Label)gridviewDepartmetn.Rows[row.RowIndex].FindControl("lblDepartmetn");
                    if (lblDepartmentId != null)
                    {
                             string OCODE = ((SessionUser)Session["SessionUser"]).OCode;                  
                            deparId = lblDepartmentId.Text;
                            objectDepartment = objDept_BLL.GetDepartmentByDepartmentId(deparId, OCODE);

                            if (objectDepartment != null)
                            {
                                hidDepartmentId.Value = objectDepartment.DPT_ID.ToString();
                                drpdwnResionForDepartment.SelectedValue = objectDepartment.ResionId.ToString();
                                int resionId = Convert.ToInt32(objectDepartment.ResionId.ToString());
                                BridOfficeByResion(resionId);
                                drpdwnOffice.SelectedValue = objectDepartment.Office_ID.ToString();
                                txtbxDepartemntName.Text = objectDepartment.DPT_NAME.ToString();

                                string officeCode = objectDepartment.DPT_CODE.ToString();
                                string[] occode = officeCode.Split('-');
                                lblOfficeCode.Text = occode[0] + "-" + occode[1] + "-";
                                txtbxDepartmentCode.Text = occode[2];


                                    if (btnDepartmentSubmit.Text == "Submit")
                                    {
                                          btnDepartmentSubmit.Text = "Update";
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
