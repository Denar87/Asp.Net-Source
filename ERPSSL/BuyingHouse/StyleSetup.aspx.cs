using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class StyleSetup : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        public static List<StyleSize> objStyleSize = new List<StyleSize>();
        public static int CurrentID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetStyleList();
                    //LoadMonth();
                    //int i = DateTime.Now.Year;
                    //for (i = i - 1; i <= DateTime.Now.Year + 30; i++)
                    //    ddlyears.Items.Add(Convert.ToString(i));
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void LoadMonth()
        //{
        //    ddlMonth.Items.Add(new ListItem("Select", 0.ToString()));
        //    var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        //    for (int i = 0; i < months.Length - 1; i++)
        //    {
        //        ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        //    }
        //    ddlMonth.SelectedItem.Text = "";
        //    ddlMonth.SelectedValue = "";
        //}

        private void GetStyleList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_Style> style = _Buyerbll.GetStyleList(Ocode);
                if (style.Count > 0)
                {
                    grdStyle.DataSource = style;
                    grdStyle.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Style _Style = new LC_Style();
                _Style.StyleName = txtStyle.Text;
                _Style.Specification = txtSpecification.Text;
                _Style.HS_Code = txtHSCode.Text;

                _Style.MenLadies = txtMenLadies.Text;
                _Style.TopBottom = txtTopBottom.Text;
                _Style.ProductDescription = txtProductDescription.Text;
                _Style.Fabrics = txtFabrics.Text;
                _Style.Accessories = txtAccessories.Text;
                _Style.CountryOfProduction = ddlCountry.SelectedItem.Text;
                if (txtPrice.Text == "")
                {
                    _Style.Price = 0;
                }
                else
                {
                    _Style.Price = Convert.ToDouble(txtPrice.Text);
                }

                byte[] pic = SetImage();
                _Style.Style_Photo = pic;
                //UploadStyleImage(_Style);
                _Style.CreateDate = DateTime.Today;
                _Style.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);
                _Style.CreateDate = DateTime.Today;
                _Style.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSave.Text != "Update")
                {
                    int result = _Buyerbll.InsertStyle(_Style);

                    if (result == 1)
                    {
                        //LC_Size sLC_Size = new LC_Size();

                        var myList = (List<StyleSize>)Session["entries_rv"];
                        foreach (StyleSize size in myList)
                        {
                            LC_Size sLC_Size = new LC_Size();

                            sLC_Size.Size_From = size.SizeFrom;
                            sLC_Size.Style_No = txtStyle.Text;
                            sLC_Size.Size_To = size.SizeTo;
                            sLC_Size.Size_Type = size.type;

                            int result1 = _Buyerbll.InsertSize(sLC_Size);

                        }
                        objStyleSize.Clear();
                        CurrentID = 1;
                        this.BindListData();
                        Session["entries_rv"] = null;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Style Saved Successfully')", true);
                    }
                }
                else
                {
                    _Style.StyleId = Convert.ToInt16(hidBueyId.Value);
                    _Style.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    int result = _Buyerbll.UpdateStyle(_Style);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Style Updated Successfully')", true);
                    }
                }
                GetStyleList();
                ClearAllController();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllController()
        {
            txtStyle.Text = "";
            txtSpecification.Text = "";
            txtHSCode.Text = "";
            txtMenLadies.Text = "";
            txtTopBottom.Text = "";
            txtProductDescription.Text = "";
            txtFabrics.Text = "";
            txtAccessories.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Submit";
        }

        protected void imgButtonEidt_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                Label lblBuyerId = (Label)grdStyle.Rows[row.RowIndex].FindControl("lblByerId");
                int ByeryId = Convert.ToInt16(lblBuyerId.Text);
                LC_Style _buyerSetup = _Buyerbll.GetStyleById(ByeryId);
                if (_buyerSetup != null)
                {
                    hidBueyId.Value = _buyerSetup.StyleId.ToString();

                    txtStyle.Text = _buyerSetup.StyleName;
                    txtSpecification.Text = _buyerSetup.Specification;
                    txtHSCode.Text = _buyerSetup.HS_Code;
                    txtMenLadies.Text = _buyerSetup.MenLadies;
                    txtTopBottom.Text = _buyerSetup.TopBottom;
                    txtProductDescription.Text = _buyerSetup.ProductDescription;
                    txtFabrics.Text = _buyerSetup.Fabrics;
                    txtAccessories.Text = _buyerSetup.Accessories;
                    ddlCountry.SelectedValue = Convert.ToString(_buyerSetup.CountryOfProduction);
                    txtPrice.Text = Convert.ToString(_buyerSetup.Price);
                }
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] SetImage()
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
            }
            return pic;
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

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            StyleSize objList = new StyleSize();
            objList.Size_Id = CurrentID;
            objList.SizeFrom = txtSizeFrom.Text;
            objList.SizeTo = txtSizeTo.Text;
            objList.type = ddlType.SelectedItem.Text;

            objStyleSize.Add(objList);
            CurrentID = CurrentID + 1;
            Session["entries_rv"] = objStyleSize;
            this.BindListData();
        }

        private void BindListData()
        {
            try
            {
                //dtg_ACT.DataSource = objVch_List;
                GridSize.DataSource = Session["entries_rv"];
                GridSize.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                //this.messagePanel.Visible = true;
                //this.lblMessage.Text = ex.Message.ToString();
                //this.messagePanel.BackColor = Color.Red;
                //this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void imgButtonDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                Label lblSerial = (Label)GridSize.Rows[row.RowIndex].FindControl("lblSerial");
                int Id = Convert.ToInt16(lblSerial.Text);
                objStyleSize.RemoveAll(a => a.Size_Id == Id);
                GridSize.EditIndex = -1;
                this.BindListData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                //this.messagePanel.Visible = true;
                //this.lblMessage.Text = ex.Message.ToString();
                //this.messagePanel.BackColor = Color.Red;
                //this.lblMessage.ForeColor = Color.White;
            }
        }



        //private void UploadStyleImage(LC_Style _Style)
        //{
        //    try
        //    {
        //        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        //        using (ERPSSL_LCEntities _context = new ERPSSL_LCEntities())
        //        {
        //            HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);

        //            byte[] pic = null;
        //            int len = FileUpload1.PostedFile.ContentLength;
        //            if (len > 0)
        //            {
        //                pic = new byte[len];
        //                FileUpload1.PostedFile.InputStream.Read(pic, 0, len);
        //            }

        //            if (FileUpload1.HasFile)
        //            {
        //                pic = ResizeImageFile(pic, 300);

        //                // personalInfo.EID = Convert.ToString(Session["EID"]);
        //                string StyleName = txtStyle.Text;
        //                string OCODE = _Style.OCode = ((SessionUser)Session["SessionUser"]).OCode;

        //                LC_Style objlcS = _context.LC_Style.First(x => x.StyleName == _Style.StyleName);
        //                objlcS.Style_Photo = _Style.Style_Photo = pic;
        //                _context.SaveChanges();
        //                imgUploadStyle.ImageUrl = "EmployeeIMG.ashx?eId=" + StyleName + "&oCode=" + OCODE;
        //                //lblImagemessage.Text = "Image Save Successfully";
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void btnimageUpload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        //        LC_Style personalInfo = new LC_Style();
        //        using (ERPSSL_LCEntities _context = new ERPSSL_LCEntities())
        //        {
        //            HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);

        //            byte[] pic = null;
        //            int len = FileUpload1.PostedFile.ContentLength;
        //            if (len > 0)
        //            {
        //                pic = new byte[len];
        //                FileUpload1.PostedFile.InputStream.Read(pic, 0, len);
        //            }

        //            if (FileUpload1.HasFile)
        //            {
        //                pic = ResizeImageFile(pic, 300);

        //                // personalInfo.EID = Convert.ToString(Session["EID"]);
        //                string styleLL  = Convert.ToString(Session["EID"]);
        //                string OCODE = personalInfo.OCode = ((SessionUser)Session["SessionUser"]).OCode;

        //                LC_Style obj = _context.LC_Style.First(x => x.StyleId == personalInfo.StyleId);
        //                obj.Style_Photo = personalInfo.Style_Photo = pic;
        //                _context.SaveChanges();
        //                imgUploadStyle.ImageUrl = "EmployeeIMG.ashx?eId=" + styleLL + "&oCode=" + OCODE;
        //                //lblImagemessage.Text = "Image Save Successfully";
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        //{
        //    try
        //    {
        //        using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
        //        {
        //            Size newSize = CalculateDimensions(oldImage.Size, targetSize);
        //            using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format16bppRgb555))
        //            {
        //                using (Graphics canvas = Graphics.FromImage(newImage))
        //                {
        //                    canvas.SmoothingMode = SmoothingMode.AntiAlias;
        //                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //                    canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
        //                    MemoryStream m = new MemoryStream();
        //                    newImage.Save(m, ImageFormat.Jpeg);
        //                    return m.GetBuffer();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static Size CalculateDimensions(Size oldSize, int targetSize)
        //{
        //    Size newSize = new Size();
        //    if (oldSize.Height > oldSize.Width)
        //    {
        //        newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
        //        newSize.Height = targetSize;
        //    }
        //    else
        //    {
        //        newSize.Width = targetSize;
        //        newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
        //    }
        //    return newSize;
        //}
    }
}