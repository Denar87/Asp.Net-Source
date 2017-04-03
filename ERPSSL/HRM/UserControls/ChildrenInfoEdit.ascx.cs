using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM.UserControls
{
    public partial class ChildrenInfoEdit : System.Web.UI.UserControl
    {
        EmployeeSetup_DAL employeeSetupDal = new EmployeeSetup_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getChildrenInfo();
               
            }

        }

        private void getChildrenInfo()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = Convert.ToString(Session["EID"]);
                var row = employeeSetupDal.GetChildrenInfo(eid, OCODE);
                if (row.Count > 0)
                {
                    gridviewChildrenInfo.DataSource = row.ToList();
                    gridviewChildrenInfo.DataBind();
                }
                else
                {
                    gridviewChildrenInfo.DataSource = null;
                    gridviewChildrenInfo.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtender.Show();             


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void lblChildrenInfo_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string lblChildrenId = "";
                Label lblAId = (Label)gridviewChildrenInfo.Rows[row.RowIndex].FindControl("lblChildrenID");
                if (lblAId != null)
                {

                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    lblChildrenId = lblAId.Text;

                    List<HRM_ChildInfo> childrenes = employeeSetupDal.GetChildrenInfoById(lblChildrenId, OCODE);
                    foreach (HRM_ChildInfo children in childrenes)
                    {
                        childrenId.Value = children.ChildId.ToString();
                        txtbxChildrenName.Text = children.Name;
                        drpChildrenGender.SelectedValue = children.Gender;
                        txbxDBO.Text = children.DOB.ToString();
                        txtbxAge.Text = children.Age.ToString();                       

                    }
                }


                btnAdd.Text = "Update";
                ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Update")
                {

                HRM_ChildInfo childInfo = new HRM_ChildInfo();
                childInfo.Age = Convert.ToInt16(txtbxAge.Text);
                childInfo.Name = txtbxChildrenName.Text;
                childInfo.DOB = Convert.ToDateTime(txbxDBO.Text);
                childInfo.Gender = drpChildrenGender.SelectedItem.ToString();

                int chilId = Convert.ToInt16(childrenId.Value);
                int result = employeeSetupDal.UpdateChildrenInfo(childInfo, chilId);
                if (result == 1)
                {
                    ClearChildrean();
                    lblModalMessage.Text = "Data Update Successfully";
                }
                }
                else
                {
                     HRM_ChildInfo childInfo = new HRM_ChildInfo();
                childInfo.EID = Convert.ToString(Session["EID"]);

                childInfo.Age = Convert.ToInt16(txtbxAge.Text);
                childInfo.Name = txtbxChildrenName.Text;
                childInfo.DOB = Convert.ToDateTime(txbxDBO.Text);
                childInfo.Gender = drpChildrenGender.SelectedItem.ToString();
                childInfo.EDIT_DATE = DateTime.Now;
                childInfo.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                childInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = employeeSetupDal.SaveChildrenInfo(childInfo);
                if (result == 1)
                {
                    ClearChildrean();
                    lblModalMessage.Text = "Data Save Successfully";
                }
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ClearChildrean()
        {
            txtbxAge.Text = "";
            txtbxChildrenName.Text="";
            txbxDBO.Text="";
            drpChildrenGender.ClearSelection();
        }

        protected void txtDob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dateOfBirth = Convert.ToDateTime(txbxDBO.Text);
                var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                var dob = float.Parse(dateOfBirth.ToString("yyyy.MMdd"));
                var age = (int)(now - dob);
                txtbxAge.Text = age.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}