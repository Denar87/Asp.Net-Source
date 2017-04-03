using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;

namespace ERPSSL.BuyingHouse
{
    public partial class InputType : System.Web.UI.Page
    {
        InputTypeBLL inputTypeBll = new InputTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    try
                    {
                        GetDepartment();
                        ShowInputType();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetDepartment()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var row = inputTypeBll.GetDepartment(Ocode);
            if (row.Count > 0)
            {
                ddlDept.DataSource = row.ToList();
                ddlDept.DataTextField = "InputDept_NAME";
                ddlDept.DataValueField = "InputDept_ID";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, new ListItem("---Select One---", "0"));
            }
        }

        protected void btnInputTypeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
                    LC_InputType InputTypeObj = new LC_InputType();
                    if (chkDept.Checked == true)
                    {
                        LC_Input_Department InputDeptObj = new LC_Input_Department();
                        InputTypeObj.Use_Dept = txtDept.Text;
                        string inputDept = InputTypeObj.Use_Dept;
                        InputDeptObj.InputDept_NAME = inputDept;
                        InputDeptObj.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                        InputDeptObj.CreateDate = DateTime.Now;
                        InputDeptObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        var result = inputTypeBll.InsertInputDepartment(InputDeptObj);
                    }
                    else
                    {
                        InputTypeObj.Use_Dept = ddlDept.SelectedItem.Text;
                    }
                    
                    InputTypeObj.Input_Name = txtbxInputType.Text;
                    InputTypeObj.Sl_No = Convert.ToInt32(txtSerial.Text);
                    InputTypeObj.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    InputTypeObj.CreateDate = DateTime.Now;
                    InputTypeObj.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                    if (btnInputTypeSubmit.Text == "Submit")
                    {
                        int result = inputTypeBll.InsertInputType(InputTypeObj);

                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }
                    }
                    else
                    {

                        int itemID = Convert.ToInt32(hidInputid.Value);
                        int results = inputTypeBll.UpdateInputType(InputTypeObj, itemID);

                        if (results == 1)
                        {
                            //lblMessage.Text = "Data Update Successfully";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                            btnInputTypeSubmit.Text = "Submit";
                        }
                    }
                    ClearUI();
                    ShowInputType();
                    chkDept.Checked = false;
                    txtDept.Visible = false;
                    ddlDept.Visible = true;
                    GetDepartment();
                }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ClearUI()
        {
            txtbxInputType.Text = "";
            ddlDept.ClearSelection();
            txtSerial.Text = "";
            txtDept.Text = "";
        }
        private void ShowInputType()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_InputType> InputType = inputTypeBll.GetALLInputType(OCode);
                if (InputType.Count > 0)
                {
                    gridviewInputType.DataSource = InputType;
                    gridviewInputType.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgbtnInputTypeEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblID = (Label)gridviewInputType.Rows[row.RowIndex].FindControl("lblInputTypeId");
                int itemID = Convert.ToInt32(lblID.Text);
                Session["lblID"]=lblID.Text;
                LC_InputType _InputType = inputTypeBll.GetInputByID(itemID);
                if (_InputType != null)
                {
                    hidInputid.Value = _InputType.InputType_Id.ToString();
                    ddlDept.SelectedItem.Text = _InputType.Use_Dept;
                    txtbxInputType.Text = _InputType.Input_Name;
                    txtSerial.Text = _InputType.Sl_No.ToString();
                    btnInputTypeSubmit.Text = "Update";
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void txtDept_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtDept.Text != "")
        //    {
        //        LC_Input_Department InputDeptObj = new LC_Input_Department();
        //        InputDeptObj.InputDept_NAME = txtDept.Text;

        //        InputDeptObj.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
        //        InputDeptObj.CreateDate = DateTime.Now;
        //        InputDeptObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        int result = inputTypeBll.InsertInputDepartment(InputDeptObj);
        //    }
        //}

        protected void chkDept_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDept.Checked == true)
            {
                ddlDept.Visible = false;
                txtDept.Visible = true;
            }
            else
            {
                ddlDept.Visible = true;
                txtDept.Visible = false;
            }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Dept = ddlDept.SelectedItem.Text;
            var row = inputTypeBll.GetallDeptByDeptName(Dept);
            if (row.Count > 0)
            {
                gridviewInputType.DataSource = row;
                gridviewInputType.DataBind();
            }
        }
        protected void gridviewInputType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewInputType.PageIndex = e.NewPageIndex;
            ShowInputType();
        }
    }
}