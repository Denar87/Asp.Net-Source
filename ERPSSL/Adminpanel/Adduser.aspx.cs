using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.HRM.BLL;


namespace ERPSSL.Adminpanel
{
    public partial class Adduser : System.Web.UI.Page
    {
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        UserBLL usrBll = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                txtbxPassword.Attributes.Add("autocomplete", "off");
                txtbxConformePassword.Attributes.Add("autocomplete", "off");
                txtbxEmail.Attributes.Add("autocomplete", "off");
                if (!IsPostBack)
                {
                    getadduser();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_User userObj = new tbl_User();
                tbl_UserPassword userPassword = new tbl_UserPassword();


                //    ;
                //if (drpdownStatus.SelectedValue == "Y")
                //{
                //    userObj.IsActive = true;
                //}
                //else
                //{
                //    userObj.IsActive = false;
                //}
                if (Label1.Text != "User Name Already Exist!")
                {
                    userObj.Use_Email = txtbxEmail.Text;
                    if (BtnSave.Text == "Submit")
                    {

                        if (txtbxPassword.Text == txtbxConformePassword.Text)
                        {
                            //string Md5 = txtbxPassword.Text;
                            // string Md5Password = Md5EncriptPassword(Md5);

                            userPassword.Password = txtbxPassword.Text;
                            userPassword.EditDate = DateTime.Now;
                            userPassword.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                            Guid guid = Guid.NewGuid();
                            userObj.UserID = guid;
                            userPassword.UserID = guid;
                            userObj.EID = txtbxEID.Text;
                            userObj.LoginName = txtbxUserName.Text;
                            userObj.UserFullName = txtbxUsrFullName.Text;
                            userObj.OCode = "8989";
                            userObj.EditDate = DateTime.Now;
                            userObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                            userObj.IsActive = Convert.ToBoolean(drpdownStatus.SelectedValue);

                            int result = usrBll.SaveUser(userObj);
                            if (result == 1)
                            {
                                int res = usrBll.SaveUsrPassword(userPassword);
                                if (res == 1)
                                {
                                    //lblMessage.Text = "User Save Successfully.";
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('User Save Successfully.')", true);
                                }
                            }

                        }
                        else
                        {
                            //lblStatus.Text = "Password Not Match";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Password Not Match')", true);
                        }


                    }
                    else
                    {

                        userObj.EID = txtbxEID.Text;
                        userObj.LoginName = txtbxUserName.Text;
                        userObj.UserFullName = txtbxUsrFullName.Text;
                        userObj.OCode = "8989";
                        userObj.EditDate = DateTime.Now;
                        userObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        userObj.IsActive = Convert.ToBoolean(drpdownStatus.SelectedValue);
                        string usereId = hidEID.Value;
                        int result = usrBll.Updateuser(userObj, usereId);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Updated Successfully";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text",
                                "func('User Updated Successfully')", true);
                        }

                    }


                    getadduser();
                    ClearUI();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('User Name Already Exist!')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearUI()
        {
            Label1.Text = "";
            eidlbl.Visible = true;
            txtbxEID.Visible = true;
            password.Visible = true;
            Conpassword.Visible = true;
            txtbxPassword.Text = "";
            txtbxEID.Text = "";
            txtbxEmail.Text = "";
            txtbxUserName.Text = "";
            txtbxUsrFullName.Text = "";
            drpdownStatus.ClearSelection();
            BtnSave.Text = "Submit";


        }

        //private string Md5Decript(string Md5Password)
        //{
        //    byte[] cipherTextBytes = Convert.FromBase64String(Md5Password);
        //    byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        //    var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

        //    var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
        //    var memoryStream = new MemoryStream(cipherTextBytes);
        //    var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        //    byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        //    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());

        //}

        //private string Md5EncriptPassword(string Md5Data)
        //{
        //    byte[] plainTextBytes = Encoding.UTF8.GetBytes(Md5Data);

        //    byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        //    var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
        //    var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

        //    byte[] cipherTextBytes;

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //        {
        //            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        //            cryptoStream.FlushFinalBlock();
        //            cipherTextBytes = memoryStream.ToArray();
        //            cryptoStream.Close();
        //        }
        //        memoryStream.Close();
        //    }
        //    return Convert.ToBase64String(cipherTextBytes);
        //}


        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            string Requested = txtbxUserName.Text;
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            GlobalClass.IsEidValid = usrBll.CheckUserExitance(OCODE, Requested);
            if (GlobalClass.IsEidValid > 0)
            {
                Checkusername.Visible = true;
                imgstatus.ImageUrl = "resources/ico/cross.png";
                Label1.Text = "User Name Already Exist!";
                Label1.ForeColor = System.Drawing.Color.Red;
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Checkusername.Visible = true;
                imgstatus.ImageUrl = "resources/ico/cross.png";
                Label1.Text = "User Name Accepted!";
                Label1.ForeColor = System.Drawing.Color.Green;
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void getadduser()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var adduser = usrBll.GetAlluser(OCODE).ToList();
                if (adduser.Count > 0)
                {
                    gridviewadduser.DataSource = adduser.ToList();
                    gridviewadduser.DataBind();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void imgbtnUsernEdit_Click(object sender, EventArgs e)
        {
            ClearUI();
            List<tbl_User> Users = new List<tbl_User>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string eId = "";
                Label lblUserID = (Label)gridviewadduser.Rows[row.RowIndex].FindControl("lblEID");
                if (lblUserID != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    eId = lblUserID.Text;
                    Users = usrBll.Getuser(eId, OCODE);

                    if (Users.Count > 0)
                    {
                        foreach (tbl_User user in Users)
                        {
                            hidEID.Value = user.EID;
                            txtbxEID.Text = user.EID;
                            txtbxUserName.Text = user.LoginName;
                            txtbxUsrFullName.Text = user.UserFullName;
                            txtbxEmail.Text = user.Use_Email;

                            if (user.IsActive == true)
                            {
                                drpdownStatus.SelectedValue = "true";
                            }
                            else
                            {
                                drpdownStatus.SelectedValue = "false";
                            }

                            if (BtnSave.Text == "Submit")
                            {

                                //eidlbl.Visible = false;
                                txtbxEID.Enabled = false;
                                txtbxUserName.Enabled = false;
                                password.Visible = false;
                                Conpassword.Visible = false;
                                BtnSave.Text = "Update";
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
    }
}