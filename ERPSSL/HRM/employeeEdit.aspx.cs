using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ERPSSL.HRM
{
    public partial class employeeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getImage();
                    GetSignature();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetSignature()
        {
            HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
            GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
            string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            imgSinature.ImageUrl = "EmployeeSignature.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
        }
        private void getImage()
        {
            HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
            GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
            string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
        }

        //protected void btnimageUpload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
        //        using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
        //        {
        //            HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);

        //                int iFileSize = file.ContentLength;
        //                if ((FileUpload1.HasFile) && (iFileSize > 1000000))  // 1MB approx (actually less though)
        //                {
        //                        string myStringAlert = " File is too big!! Max file size 100kb!!! Please Resize !!!!";
        //                        lblImagemessage.Text = myStringAlert;
        //                        return;
        //                }
        //                else
        //                {

        //                        if (FileUpload1.HasFile)
        //                        {                            
        //                            GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
        //                            string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

        //                            HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
        //                            obj.EMP_PHOTO = personalInfo.EMP_PHOTO = FileUpload1.FileBytes;
        //                            _context.SaveChanges();
        //                            Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
        //                            lblImagemessage.Text = "Image Save Successfully";

        //                        }
        //                }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //protected void btnSignature_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
        //        using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
        //        {
        //            HttpPostedFile file = (HttpPostedFile)(FileUpload2.PostedFile);

        //                int iFileSize = file.ContentLength;
        //                if ((FileUpload2.HasFile) && (iFileSize > 10000))  // 1MB approx (actually less though)
        //                {
        //                        string myStringAlert = " File is too big!! Max file size 100kb!!! Please Resize !!!!";
        //                        lblImagemessage.Text = myStringAlert;
        //                        return;
        //                }
        //                else
        //                {

        //                        if (FileUpload2.HasFile)
        //                        {
        //                            // personalInfo.EID = Convert.ToString(Session["EID"]);
        //                            GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
        //                            string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

        //                            HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
        //                            obj.EMP_Singnature = personalInfo.EMP_Singnature = FileUpload2.FileBytes;
        //                            _context.SaveChanges();
        //                            imgSinature.ImageUrl = "EmployeeSignature.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
        //                            lblImagemessage.Text = "Singnature Save Successfully";

        //                        }
        //                }
        //        }
        //    }

        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //protected void btnNominee_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
        //        using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
        //        {
        //            HttpPostedFile file = (HttpPostedFile)(FileUpload3.PostedFile);

        //            byte[] pic = null;
        //            int len = FileUpload3.PostedFile.ContentLength;
        //            if (len > 0)
        //            {
        //                pic = new byte[len];
        //                FileUpload3.PostedFile.InputStream.Read(pic, 0, len);
        //            }

        //            if (FileUpload3.HasFile)
        //            {
        //                pic = ResizeImageFile(pic, 300);
        //                // personalInfo.EID = Convert.ToString(Session["EID"]);
        //                GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
        //                string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

        //                HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
        //                obj.Nomine_Photo = personalInfo.Nomine_Photo = pic;
        //                _context.SaveChanges();
        //                imgSinature.ImageUrl = "NomineeImageHandaler.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
        //                lblImagemessage.Text = "Image Save Successfully";
        //            }
        //        }
        //    }

        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        protected void btnimageUpload_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);

                    byte[] pic = null;
                    int len = FileUpload1.PostedFile.ContentLength;
                    if (len > 0)
                    {
                        pic = new byte[len];
                        FileUpload1.PostedFile.InputStream.Read(pic, 0, len);
                    }

                    if (FileUpload1.HasFile)
                    {
                        pic = ResizeImageFile(pic, 300);
                        GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
                        string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
                        obj.EMP_PHOTO = personalInfo.EMP_PHOTO = pic;
                        _context.SaveChanges();
                        Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
                        //  lblImagemessage.Text = "Image Save Successfully!";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSignature_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    HttpPostedFile file = (HttpPostedFile)(FileUpload2.PostedFile);

                    byte[] pic = null;
                    int len = FileUpload2.PostedFile.ContentLength;
                    if (len > 0)
                    {
                        pic = new byte[len];
                        FileUpload2.PostedFile.InputStream.Read(pic, 0, len);
                    }

                    if (FileUpload2.HasFile)
                    {
                        pic = ResizeImageFile(pic, 300);
                        // personalInfo.EID = Convert.ToString(Session["EID"]);
                        GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
                        string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
                        obj.EMP_Singnature = personalInfo.EMP_Singnature = pic;
                        _context.SaveChanges();
                        imgSinature.ImageUrl = "EmployeeSignature.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
                        // lblImagemessage.Text = "Image Save Successfully!";

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnNominee_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    HttpPostedFile file = (HttpPostedFile)(FileUpload3.PostedFile);

                    byte[] pic = null;
                    int len = FileUpload3.PostedFile.ContentLength;
                    if (len > 0)
                    {
                        pic = new byte[len];
                        FileUpload3.PostedFile.InputStream.Read(pic, 0, len);
                    }

                    if (FileUpload3.HasFile)
                    {
                        pic = ResizeImageFile(pic, 300);
                        // personalInfo.EID = Convert.ToString(Session["EID"]);
                        GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
                        string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
                        obj.Nomine_Photo = personalInfo.Nomine_Photo = pic;
                        _context.SaveChanges();
                        imagenominee.ImageUrl = "NomineeImageHandaler.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
                        // lblImagemessage.Text = "Image Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        public static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            try
            {
                using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
                {
                    Size newSize = CalculateDimensions(oldImage.Size, targetSize);
                    using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format16bppRgb555))
                    {
                        using (Graphics canvas = Graphics.FromImage(newImage))
                        {
                            canvas.SmoothingMode = SmoothingMode.AntiAlias;
                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                            MemoryStream m = new MemoryStream();
                            newImage.Save(m, ImageFormat.Jpeg);
                            return m.GetBuffer();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }
    }
}