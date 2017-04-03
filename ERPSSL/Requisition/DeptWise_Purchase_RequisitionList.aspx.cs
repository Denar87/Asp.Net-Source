using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;
using ERPSSL.Procurement.DAL;
using System.IO;

namespace ERPSSL.Requisition
{
    public partial class DeptWise_Purchase_RequisitionList : System.Web.UI.Page
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        IChallanBLL aChallanBll = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        Office_BLL officeBll = new Office_BLL();
        IChallanBLL ic = new IChallanBLL();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetEmployeeInfo();
                //LoadRequisitions("");
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
                FillDepartmentByOffice();
                //GetFiles();


            }
        }

        private void GetEmployeeInfo()
        {
            try
            {
                string eid = ((SessionUser)Session["SessionUser"]).EID;
                if (eid != null)
                {
                    EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);

                    List<AssignTo> assignTos = new List<AssignTo>();
                    assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                    foreach (AssignTo assign in assignTos)
                    {
                        //hdnEID.Value = ((SessionUser)Session["SessionUser"]).EID;
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
                        //txtEID.Text = ((SessionUser)Session["SessionUser"]).EID;
                        //txtDesignation.Text = assign.DeginationName.ToString();
                        //txtDepartment.Text = assign.DepartmentName.ToString();
                        //hdnDEPT_CODE.Value = assign.DPT_CODE;
                        //ddlDepartment.SelectedItem.Text = assign.DepartmentName.ToString();
                        //ddlDepartment.SelectedValue = assign.DPT_CODE.ToString();
                    }
                    //List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    //foreach (HRM_PersonalInformations aperson in personanlInfo)
                    //{
                    //txtEmployee.Text = aperson.FirstName + " " + aperson.LastName;
                    //LoadEmployeeList();
                    //ddlEmployee.SelectedValue = aperson.EID;
                    //hidReportingBossID.Value = aperson.ReportingBossId;
                    //}
                }
            }
            catch
            {
            }
        }

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetAll_PurchaseReqList(ReqNo, "Head", hdnEID.Value, txtFromDate.Text, txtToDate.Text);
            grdRequisition.DataBind();
        }
        //search shabda

        private void LoadRequisitionsItem(string ReqNo)
        {
            grvReqItemList.DataSource = aChallanBll.GetAllPurchaseRequisitionData(ReqNo, "Head");
            grvReqItemList.DataBind();
        }

        protected void grdRequisition_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Label ReqNo = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblReqNo");
                lblMessage.Text = "";
                DataTable dt = new DataTable();
                string reqNo = e.CommandArgument.ToString();
                Session["RequisitionNo"] = reqNo;

                if (e.CommandName == "select")
                {
                    grvReqItemList.DataSource = aChallanBll.GetAllPurchaseRequisitionData(reqNo, "Head");
                    grvReqItemList.DataBind();
                    GetFiles();
                    //dt = aChallanBll.GetStoreRequisitionData(reqNo, "Manager");
                    //LoadRequisitionsItem("");
                }
            }
            catch { }



        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["RequisitionNo"] != null && grvReqItemList.Rows.Count != 0)
                {

                    Response.Redirect("DeptWise_UpdatePurchaseRequisition.aspx");
                    Session["RequisitionNo"] = null;
                }
                else
                {
                    //  lblMessage.Text = "<font color='red'>Please Select a Requisition from List</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please search & select a requisition!')", true);
                }
            }
            catch
            {

            }

        }

        protected void txtApproveQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblBalance = (Label)grvReqItemList.FindControl("lblBalance");
                Label lblItem = (Label)grvReqItemList.FindControl("lblItem");
                Label lblTotalAppQty = (Label)grvReqItemList.FindControl("lblTotalAppQty");

                TextBox txtApproveQty = (TextBox)grvReqItemList.FindControl("txtApproveQty");
                int ApproveQty = int.Parse(txtApproveQty.Text);

                if (ApproveQty > (Convert.ToInt16(lblBalance.Text) - Convert.ToInt16(lblTotalAppQty.Text)))
                {
                    lblMessage.Text = "<font color='red'>'" + lblItem.Text + "' approve quantity can not be larger than stock!</font>";
                    return;
                }
            }
            catch { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequisitionsearch();
        }

        private void FillDepartmentByOffice()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            ddlDepartment.DataSource = officeBll.GetDepartmentByOffice(int.Parse(hdnOfficeID.Value), OCODE);
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                //BindRequisitionNo();
            }
            catch { }
        }
        private void LoadEmployeeList(string DeptCode)
        {

            DeptCode = ddlDepartment.SelectedValue;
            ddlEmployee.DataSource = ic.GetEmployeeListByDept(DeptCode);
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
        }
        private void LoadEmployeeLists()
        {
            ddlEmployee.DataSource = ic.GetEmployeeList();
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
        }

        private void LoadRequisitionsearch()
        {
            string Depts = ddlDepartment.SelectedValue;
            string ReqNo = "";
            DataTable dt = new DataTable();
            dt = RequisionBll.GetAll_PurchaseReqListByDepartment(ReqNo, "Head", ddlEmployee.SelectedValue, txtFromDate.Text, txtToDate.Text, Depts);
            if (dt.Rows.Count > 0)
            {
                grdRequisition.DataSource = dt;
                grdRequisition.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No purchase requisition found!')", true);
                grdRequisition.DataSource = dt;
                grdRequisition.DataBind();
            }

        }

        private void GetFiles()
        {
            DataTable dt = new DataTable();
            string ReqNo = Session["RequisitionNo"].ToString();
            string OCode = "8989";
            dt = ic.GetFile(ReqNo, OCode);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string rootPath = Server.MapPath("/Requisition/Req_Document/");
          //  string filePath = (sender as LinkButton).CommandArgument;
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                Label lblfilepath = (Label)gvr.FindControl("lblFile_path");
              
                Session["File"] = lblfilepath.Text; 
            }

            string filePath = Session["File"].ToString();
            string fullPath = rootPath + filePath;

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fullPath));
            Response.WriteFile(fullPath);
            Response.End();


            //try
            //{
            //    byte[] bytes;
            //    string fileName, contentType;
            //    string Ocode = "8989";
            //    string File = (sender as LinkButton).CommandArgument;
            //    // string File = Session["RequisitionNo"].ToString();
            //    //DataTable dt = new DataTable();

            //    // var q = aChallanBll.GetFile(File,Ocode);
            //    var query = (from D in _context.PRQ_Requisitions
            //                 where D.OCode == Ocode && D.ReqNo == File
            //                 select D);

            //    foreach (var aitem in query)
            //    {
            //        //PRQ_Requisitions aitem = new PRQ_Requisitions();
            //        bytes = (byte[])aitem.Req_File;
            //        if (bytes != null)
            //        {
            //            contentType = aitem.RFile_Type;
            //            fileName = aitem.RFile_Name;

            //            Response.Clear();
            //            Response.Buffer = true;
            //            Response.Charset = "";
            //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //            Response.ContentType = contentType;
            //            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            //            Response.BinaryWrite(bytes);
            //            Response.Flush();
            //            Response.End();
            //        }
            //        else
            //        {
            //            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition file not available!')", true);
            //            lblMessage.Text = "Requisition file not available ";
            //        }

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
       

    }
}