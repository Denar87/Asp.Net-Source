using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using System.IO;
using System.Data.SqlClient;
using System.IO.Compression;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;



namespace ERPSSL.HRM
{
    public partial class servicesContract : System.Web.UI.Page
    {
        #region Objects----------------------------------------
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        SECTION_BLL objSec_BLL = new SECTION_BLL();
        SUB_SECTION_BLL objSubSec_BLL = new SUB_SECTION_BLL();
        DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
        GRADE_BLL objGrd_BLL = new GRADE_BLL();
        LEAVE_BLL objLeave_BLL = new LEAVE_BLL();
        HOLIDAYS_BLL objHoli_BLL = new HOLIDAYS_BLL();
        TIME_SCHEDULE_BLL objTm_BLL = new TIME_SCHEDULE_BLL();

        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        ADMINISTRATION_BLL objAdm_BLL = new ADMINISTRATION_BLL();
        REPORTING_BLL objRpt_BLL = new REPORTING_BLL();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        protected void txtEid_LV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_LV.Text);

                Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeIDDetails(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid_LV.Text = Convert.ToString(objNewEmp.EID);
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                    //txtServiceDetails.Text = objNewEmp.CONTRACT;
                    //BindGridEmployee(Convert.ToInt64(lblHiddenId.Text));

                    BindGridEmployee(employeeID);
                    var resultCt = objEmp_BLL.GetEmployeeContract(employeeID, OCODE).ToList();
                    if (resultCt.Count > 0)
                    {
                        var objNewEmpCt = resultCt.First();
                        txtServiceDetails.Text = objNewEmpCt.CONTRACT;
                    }
                    else
                    {
                        //NO RECORDS FOUND.
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string FILE_TITLE = txtFileTitle.Text.Trim();
                string employeeID = Convert.ToString(txtEid_LV.Text);
                Int64 EMP_ID = Convert.ToInt64(lblHiddenId.Text);
                string EDIT_USER = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);
                DateTime EDIT_DATE = DateTime.Now;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                String FILE_TYPE = Path.GetExtension(FileUpload.FileName);
                string[] sizes = { "B", "KB", "MB", "GB" };
                double len = Convert.ToDouble(FileUpload.PostedFile.ContentLength);
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }

                string FILE_SIZE = String.Format("{0:0.##} {1}", len, sizes[order]);
                string FILE_NAME = Path.GetFileName(FileUpload.PostedFile.FileName);

                EnsureTrackDirectoriesExist(OCODE);
                string DB_FILE_PATH = "" + OCODE.ToString() + "\\" + FILE_NAME;

                //sets the image Save to Folder
                FileUpload.SaveAs(Server.MapPath("../HRM/File/" + OCODE.ToString() + "/" + FILE_NAME));


                string SP_SQL = "ENTER_SERVICE_CONTRACT_FILE @EID,@FILE_TITLE,@FILE_TYPE,@FILE_PATH,@FILE_SIZE,@EDIT_USER,@EDIT_DATE,@OCODE";

                //var ParamEMP_ID = new SqlParameter("EMP_ID", EMP_ID);
                var ParamemployeeID = new SqlParameter("EID", employeeID);
                var ParamFILE_TITLE = new SqlParameter("FILE_TITLE", FILE_TITLE);
                var ParamFILE_TYPE = new SqlParameter("FILE_TYPE", FILE_TYPE);
                var ParamDB_FILE_PATH = new SqlParameter("FILE_PATH", DB_FILE_PATH);
                var ParamFILE_SIZE = new SqlParameter("FILE_SIZE", FILE_SIZE);
                var ParamEDIT_USER = new SqlParameter("EDIT_USER", EDIT_USER);
                var ParamEDIT_DATE = new SqlParameter("EDIT_DATE", EDIT_DATE);
                var ParamOCODE = new SqlParameter("OCODE", OCODE);

                using (var _context = new ERPSSLHBEntities())
                {
                    Int32 result = _context.ExecuteStoreCommand(SP_SQL, ParamemployeeID, ParamFILE_TITLE, ParamFILE_TYPE, ParamDB_FILE_PATH, ParamFILE_SIZE, ParamEDIT_USER, ParamEDIT_DATE, ParamOCODE);
                    pnl_result.Visible = true;
                    lblMessage.Text = "Saved Successfully";
                    lblTrnsMessage.ForeColor = System.Drawing.Color.Green;
                    BindGridEmployee(employeeID);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        public void EnsureTrackDirectoriesExist(string OCODE)
        {
            if (!System.IO.Directory.Exists(Server.MapPath("../HRM/File/" + OCODE.ToString())))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("../HRM/File/" + OCODE.ToString()));
            }
        }

        void BindGridEmployee(string employeeID)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var emp = objEmp_BLL.GetCurrent_Employees(OCODE).ToList();

                using (var _context = new ERPSSLHBEntities())
                {
                    var query = (from hl in _context.HRM_EMPLOYEE_DOCUMENTS
                                 where hl.OCODE == OCODE && hl.EID == employeeID
                                 select hl).OrderByDescending(hl => hl.FILE_ID).ToList();
                    var list = query.ToList();

                    if (list.Count() > 0)
                    {
                        grd_File.DataSource = list;
                        grd_File.DataBind();
                    }
                    else
                    {
                        var obj = new List<HRM_EMPLOYEE_DOCUMENTS>();
                        obj.Add(new HRM_EMPLOYEE_DOCUMENTS());

                        // Bind the DataTable which contain a blank row to the GridView
                        grd_File.DataSource = obj;
                        grd_File.DataBind();

                        int columnsCount = grd_File.Columns.Count;
                        grd_File.Rows[0].Cells.Clear();// clear all the cells in the row
                        grd_File.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grd_File.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                        grd_File.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grd_File.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grd_File.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grd_File.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }


        protected void btnDload_Click(object sender, EventArgs e)
        {
            //using (ZipFiles zip=new ZipFiles())
            //{
            //    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            //    zip.AddDirectoryByName("File");
            //    foreach (GridViewRow row in grd_File.Rows)
            //    {
            //        if ((row.FindControl("cbRows") as CheckBox).Checked)
            //        {
            //            string filePath = (row.FindControl("lblFilePath") as Label).Text;
            //            zip.AddFile(filePath, "File");
            //        }
            //    }
            //    Response.Clear();
            //    Response.BufferOutput = false;
            //    string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            //    Response.ContentType = "application/zip";
            //    Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            //    zip.Save(Response.OutputStream);
            //    Response.End();
            //}
        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            using (var _context = new ERPSSLHBEntities())
            {

                try
                {
                    HRM_SERVICE_CONTRACT obj = new HRM_SERVICE_CONTRACT();
                    //Int64 EMP_ID = Convert.ToInt64(lblHiddenId.Text);
                    string EMP_ID = txtEid_LV.Text;
                    string CONTRACT = txtServiceDetails.Text;

                    string EDIT_USER = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);
                    DateTime EDIT_DATE = DateTime.Now;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    string SP_SQL = "ENTER_SERVICE_CONTRACT @EMP_ID, @CONTRACT, @OCODE";

                    var ParamEid = new SqlParameter("EMP_ID", EMP_ID);
                    var ParamCt = new SqlParameter("CONTRACT", txtServiceDetails.Text);
                    var ParamOc = new SqlParameter("OCODE", OCODE);

                    if (_context.ExecuteStoreCommand(SP_SQL, ParamEid, ParamCt, ParamOc) == 1)
                    {
                        pnl_result.Visible = true;
                        lblMessage.Text = "Saved Successfully";
                        lblTrnsMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void grd_File_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string rootPath = Server.MapPath("../HRM/File/");
            string filePath = (sender as LinkButton).CommandArgument;
            string fullPath = rootPath + filePath;

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fullPath));
            Response.WriteFile(fullPath);
            Response.End();
        }

        protected void DeleteFile(object sender, EventArgs e)
        {
            string employeeID = Convert.ToString(txtEid_LV.Text);
            Int64 EMP_ID = Convert.ToInt64(lblHiddenId.Text);
            //string rootPath = Server.MapPath("../HRM/File/");
            //string filePath = (sender as LinkButton).CommandArgument;
            //string fullPath = rootPath + filePath;

            //File.Delete(fullPath);
            //Response.Redirect(Request.Url.AbsoluteUri);


            ServiceBLL sv = new ServiceBLL();
            LinkButton imgbtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string FilePath = "";
                Label lblfileID = (Label)grd_File.Rows[row.RowIndex].FindControl("lblfileID");
                if (lblfileID != null)
                {
                    FilePath = lblfileID.Text;
                    int result = sv.FilePathDEleting(FilePath);
                    if (result == 1)
                    {
                        BindGridEmployee(employeeID);
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grd_File_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string employeeID = Convert.ToString(txtEid_LV.Text);
            grd_File.PageIndex = e.NewPageIndex;
            BindGridEmployee(employeeID);

        }
    }
}