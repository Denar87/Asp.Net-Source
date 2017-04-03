using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.IO;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.Adminpanel.UserControls
{
    public partial class ModuleSetup : System.Web.UI.UserControl
    {
        ModulBLL modulBll = new ModulBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                moduleImage.Visible = false;
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                GetModules(Ocode);
            }

        }

        private void GetModules(string Ocode)
        {
            try
            {
                List<tbl_Module> modules = modulBll.GetAllModules(Ocode);
                if (modules.Count > 0)
                {
                    gridviewModul.DataSource = modules;
                    gridviewModul.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {

                tbl_Module modulOb = new tbl_Module();
                modulOb.ModuleName = txtModuleName.Text;
                modulOb.ModuleURL = txtUrl.Text;
                modulOb.ModuleOrder = Convert.ToInt16(txtbxModuleOrder.Text);
                modulOb.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                modulOb.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                modulOb.EDIT_DATE = DateTime.Now;            
                if (drpdownStatus.SelectedItem.ToString() == "True")
                {
                    modulOb.Status = true;
                }
                else
                {
                    modulOb.Status = false;
                }

                if (BtnSave.Text == "Save Module")
                {
                    int imageNumber = 0;
                    string PPImg = "";

                    string path = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["AttachmentPath"] + "/ModuleIcon/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string[] filePaths = Directory.GetFiles(Server.MapPath("~" + "/ModuleIcon/"));
                    List<ListItem> files = new List<ListItem>();

                    foreach (string filePath in filePaths)
                    {
                        string fileName = Path.GetFileName(filePath);
                        files.Add(new ListItem(fileName, "~" + "/ModuleIcon/" + fileName));

                    }
                    imageNumber = files.Count;
                    FileUpload FilePP = new FileUpload();
                    FilePP = FileUpload1;
                    if (FilePP.HasFile)
                    {
                        imageNumber++;
                        PPImg = imageNumber + FilePP.FileName;
                        path = path + @"\" + PPImg;
                        FilePP.PostedFile.SaveAs(path);
                    }

                    modulOb.ModuleIcon = PPImg;
                    int result = modulBll.SaveModul(modulOb);
                    if (result == 1)
                    {
                        //lblStatus.Text = "Module Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Module Save Successfully')", true);
                        ClearAllControll();

                    }
                }
                else
                {
                    //string ImageLication = "~" + "/ModuleIcon/" + hidModulImageIcon.Value;
                    //File.Delete(Server.MapPath(ImageLication));
                    string PPImg = "";
                    FileUpload FilePP1 = new FileUpload();
                    FilePP1 = FileUpload1;
                    if (FilePP1.FileName == "")
                    {
                        modulOb.ModuleIcon = hidModulImageIcon.Value;
                    }
                    else
                    {
                        int imageNumber = 0;

                        string path = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["AttachmentPath"] + "/ModuleIcon/");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string[] filePaths = Directory.GetFiles(Server.MapPath("~" + "/ModuleIcon/"));
                        List<ListItem> files = new List<ListItem>();

                        foreach (string filePath in filePaths)
                        {
                            string fileName = Path.GetFileName(filePath);
                            files.Add(new ListItem(fileName, "~" + "/ModuleIcon/" + fileName));

                        }
                        imageNumber = files.Count;
                        FileUpload FilePP = new FileUpload();
                        FilePP = FileUpload1;
                        if (FilePP.HasFile)
                        {
                            imageNumber++;
                            PPImg = imageNumber + FilePP.FileName;
                            path = path + @"\" + PPImg;
                            FilePP.PostedFile.SaveAs(path);
                        }
                        modulOb.ModuleIcon ="ModuleIcon/"+PPImg;
                    }
                    string ModulId = hidModuleId.Value;

                    int result = modulBll.UpdateModul(modulOb, ModulId);
                    if (result == 1)
                    {
                       // lblStatus.Text = "Module Update Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Module Update Successfully')", true);
                        ClearAllControll();
                    }


                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearAllControll()
        {
            drpdownStatus.ClearSelection();
            txtModuleName.Text = "";
            txtUrl.Text = "";
            hidModuleId.Value = "";
            hidModulImageIcon.Value = "";
            ModulImage.ImageUrl = null;
            moduleImage.Visible = false;          
            txtbxModuleOrder.Text = "";
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            GetModules(Ocode);
            BtnSave.Text = "Save Module";

        }
        protected void imgbtnModulEdit_Click(object sender, EventArgs e)
        {
            List<tbl_Module> modules = new List<tbl_Module>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string modulId = "";
                Label lblModulId = (Label)gridviewModul.Rows[row.RowIndex].FindControl("lblModulId");
                if (lblModulId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    modulId = lblModulId.Text;
                    modules = modulBll.GetModuleById(modulId, OCODE);

                    if (modules.Count > 0)
                    {
                        moduleImage.Visible = true;
                        foreach (tbl_Module module in modules)
                        {
                            txtModuleName.Text = module.ModuleName;
                            txtUrl.Text = module.ModuleURL;
                            txtbxModuleOrder.Text = module.ModuleOrder.ToString();
                            hidModuleId.Value = module.ModuleID.ToString();
                            hidModulImageIcon.Value = module.ModuleIcon.ToString();
                            drpdownStatus.SelectedValue = module.Status.ToString();
                            

                            ModulImage.ImageUrl = "~" + "/ModuleIcon/" + module.ModuleIcon;

                            if (BtnSave.Text == "Save Module")
                            {
                                BtnSave.Text = "Update Module";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void gridviewModul_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewModul.PageIndex = e.NewPageIndex;
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            GetModules(Ocode);
        }

    }
}