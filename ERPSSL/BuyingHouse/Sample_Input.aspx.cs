using ERPSSL.BuyingHouse.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class Sample_Input : System.Web.UI.Page
    {
        SampleDetailsBLL _SampleDetailsbll = new SampleDetailsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadBuyerList();
                    LoadFactoryList();
                    ShowSampleDetailGrid();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadFactoryList()
        {
            try
            {
                var row = _SampleDetailsbll.GetFactoryNameList();
                if (row.Count > 0)
                {
                    ddlFactoryMame.DataSource = row.ToList();
                    ddlFactoryMame.DataTextField = "FactoryName";
                    ddlFactoryMame.DataValueField = "FactoryId";
                    ddlFactoryMame.DataBind();
                    ddlFactoryMame.AppendDataBoundItems = false;
                    ddlFactoryMame.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadBuyerList()
        {
            try
            {
                var row = _SampleDetailsbll.GetBuyerList();
                if (row.Count > 0)
                {
                    ddlBuyer.DataSource = row.ToList();
                    ddlBuyer.DataTextField = "Buyer_Name";
                    ddlBuyer.DataValueField = "Buyer_ID";
                    ddlBuyer.DataBind();
                    ddlBuyer.AppendDataBoundItems = false;
                    ddlBuyer.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearUi()
        {
            ddlBuyer.ClearSelection();
            ddlFactoryMame.ClearSelection();
            txtPreOrderNo.Text = "";
            txtSampleDate.Text = "";
            txtSampleSpecification.Text = "";
            txt1stSampleSentDate.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] res = Session["picUp"] as byte[];
                byte[] pic = SetImage();

                DateTime? SampleDate = null;

                LC_SampleDetails _ObjSampleDetails = new LC_SampleDetails();

                _ObjSampleDetails.Buyer_ID = Convert.ToInt32(ddlBuyer.SelectedValue);
                _ObjSampleDetails.FactoryId = Convert.ToInt32(ddlFactoryMame.SelectedValue);
                _ObjSampleDetails.Pre_OrderNo = txtPreOrderNo.Text;
                if (txtSampleDate.Text == "")
                {
                    _ObjSampleDetails.SampleDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.SampleDate = Convert.ToDateTime(txtSampleDate.Text);
                }
                _ObjSampleDetails.SampleSpecification = txtSampleSpecification.Text;
                _ObjSampleDetails.Pre_OrderNo = txtPreOrderNo.Text;
                if (txt1stSampleSentDate.Text == "")
                {
                    _ObjSampleDetails.First_SampleSentDate = SampleDate;
                }
                else
                {
                    _ObjSampleDetails.First_SampleSentDate = Convert.ToDateTime(txt1stSampleSentDate.Text);
                }

                //if (FileUpload1.FileName == null)
                //{
                if (_ObjSampleDetails.Sample_Photo == res)
                {
                    _ObjSampleDetails.Sample_Photo = pic;
                }
                else
                {
                    _ObjSampleDetails.Sample_Photo = res;
                }
                //}
                //else
                //{
                //    _ObjSampleDetails.Sample_Photo = pic;
                //}
                _ObjSampleDetails.CreateDate = DateTime.Now;
                _ObjSampleDetails.CreateUser = (((SessionUser)Session["SessionUser"]).UserId);
                _ObjSampleDetails.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                if (btnSubmit.Text != "Update")
                {
                    int result = _SampleDetailsbll.Insert(_ObjSampleDetails);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _ObjSampleDetails.EditDate = DateTime.Now;
                    _ObjSampleDetails.EditUser = (((SessionUser)Session["SessionUser"]).UserId); ;
                    _ObjSampleDetails.SampleId = Convert.ToInt16(HidId.Value);
                    int result = _SampleDetailsbll.Update(_ObjSampleDetails);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                ClearUi();
                ShowSampleDetailGrid();
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

        private void ShowSampleDetailGrid()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var _TnaL = _SampleDetailsbll.GetSampleDetailsList(OCode);
                if (_TnaL.Count > 0)
                {
                    grdSampleDetails.DataSource = _TnaL;
                    grdSampleDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgSampleDetailsEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblID = (Label)grdSampleDetails.Rows[row.RowIndex].FindControl("lblID");
                int Id = Convert.ToInt16(lblID.Text);
                LC_SampleDetails _SD = _SampleDetailsbll.GetSDetailsById(Id);
                if (_SD != null)
                {
                    HidId.Value = _SD.SampleId.ToString();
                    ddlBuyer.SelectedValue = _SD.Buyer_ID.ToString();
                    ddlFactoryMame.SelectedValue = _SD.FactoryId.ToString();
                    txtPreOrderNo.Text = _SD.Pre_OrderNo;
                    txtSampleDate.Text = _SD.SampleDate.ToString();
                    txtSampleSpecification.Text = _SD.SampleSpecification;
                    byte[] picUp = SetImage();
                    picUp = _SD.Sample_Photo;
                    Session["picUp"] = picUp;
                    txt1stSampleSentDate.Text = _SD.First_SampleSentDate.ToString();
                }
                btnSubmit.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}