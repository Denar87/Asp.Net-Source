using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class educationType : System.Web.UI.Page
    {

        EducationTypeBLL _eductaionType = new EducationTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getEducationTypeList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getEducationTypeList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var education = _eductaionType.getEducationTypeList(OCODE).ToList();
                if (education.Count > 0)
                {
                    gridviewEducationType.DataSource = education.ToList();
                    gridviewEducationType.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEducationTypeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_EducationType eductiotypeObj = new HRM_EducationType();

                eductiotypeObj.EducationTypeName = txtbxEducationType.Text.Trim();
                eductiotypeObj.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                eductiotypeObj.Edit_Date = DateTime.Now;
                eductiotypeObj.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnEducationTypeSubmit.Text == "Submit")
                {


                    int result = _eductaionType.SaveEducationType(eductiotypeObj);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                    }

                }
                else
                {
                    string EducatonTypeId = hidEmployeeTypeId.Value;
                    int result = _eductaionType.UpdateEducationType(eductiotypeObj, EducatonTypeId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                    }


                }

                getEducationTypeList();
                txtbxEducationType.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnEducationTypeEdit_Click(object sender, EventArgs e)
        {
            List<HRM_EducationType> EductionTypes = new List<HRM_EducationType>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string educationTypeId = "";
                Label lblEdTypeId = (Label)gridviewEducationType.Rows[row.RowIndex].FindControl("lblEducationTypeId");
                if (lblEdTypeId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    educationTypeId = lblEdTypeId.Text;
                    EductionTypes = _eductaionType.getEducatonTypeById(educationTypeId, OCODE);

                    if (EductionTypes.Count > 0)
                    {
                        foreach (HRM_EducationType edType in EductionTypes)
                        {
                            hidEmployeeTypeId.Value = edType.EducationTypeID.ToString();
                            txtbxEducationType.Text = edType.EducationTypeName;

                            if (btnEducationTypeSubmit.Text == "Submit")
                            {
                                btnEducationTypeSubmit.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewEducationType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        public string educationTypeId { get; set; }
    }
}