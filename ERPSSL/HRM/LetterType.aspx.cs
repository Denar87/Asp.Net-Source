using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class LetterType : System.Web.UI.Page
    {
        LetterTypeBLL letterTypeBllObj = new LetterTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetAllLetterTypes();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void GetAllLetterTypes()
        {


            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = letterTypeBllObj.GetAllLetterTypes(OCODE).ToList();
                if (row.Count > 0)
                {
                    gridviewLetterType.DataSource = row.ToList();
                    gridviewLetterType.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void imgbtnDepartmentEdit_Click(object sender, EventArgs e)
        {
            List<HRM_LetterType> letterTypes = new List<HRM_LetterType>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string lerId = "";
                Label lblDesginationId = (Label)gridviewLetterType.Rows[row.RowIndex].FindControl("lblLatterTypeId");
                if (lblDesginationId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    lerId = lblDesginationId.Text;
                    letterTypes = letterTypeBllObj.GetLetterTypeById(lerId, OCODE);

                    if (letterTypes.Count > 0)
                    {
                        foreach (HRM_LetterType aletterType in letterTypes)
                        {
                            hidLetterTypeId.Value = aletterType.LatterTypeId.ToString();
                            txtbxType.Text = aletterType.LatterType;

                        }
                        if (btnLetterTypeSubmit.Text == "Submit")
                        {
                            btnLetterTypeSubmit.Text = "Update";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void btnLetterTypeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxType.Text == "")
                {
                    // lblMessage.Text = "";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input LetterType!')", true);
                }

                else
                {
                    HRM_LetterType leObj = new HRM_LetterType();
                    leObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    leObj.EDIT_DATE = DateTime.Now;
                    leObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    leObj.LatterType = txtbxType.Text;


                    if (btnLetterTypeSubmit.Text == "Submit")
                    {
                        int result = letterTypeBllObj.InsertLetterType(leObj);
                        if (result == 1)
                        {
                            //   lblMessage.Text = "Data Save successfully!";
                            //   lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                        }
                    }
                    else
                    {
                        int letterTypeId = Convert.ToInt32(hidLetterTypeId.Value);
                        int result = letterTypeBllObj.UpdateLetterType(leObj, letterTypeId);
                        if (result == 1)
                        {
                            //     lblMessage.Text = "Data Update successfully!";
                            //     lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        }
                    }
                    ClearControll();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearControll()
        {
            txtbxType.Text = "";
            btnLetterTypeSubmit.Text = "Submit";
            GetAllLetterTypes();

        }

        protected void gridviewLetterType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewLetterType.PageIndex = e.NewPageIndex;
            GetAllLetterTypes();

        }

    }
}