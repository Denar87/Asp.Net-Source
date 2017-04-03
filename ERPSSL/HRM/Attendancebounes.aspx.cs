using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class Attendancebounes : System.Web.UI.Page
    {
        AttendancebonusBLL attendancebonusbll = new AttendancebonusBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getOffices();
                    getDesgination();
                    GetAttenanceBonusList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        private void GetAttenanceBonusList()
        {
            try
            {
                try
                {
                    string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    var row = attendancebonusbll.GetAttendanceBonusList(OCODE).ToList();
                    if (row.Count > 0)
                    {
                        gridviewattendanceBonus.DataSource = row.ToList();
                        gridviewattendanceBonus.DataBind();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void getDesgination()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = attendancebonusbll.GetDesgination(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpDesination.DataSource = row.ToList();
                    drpDesination.DataTextField = "DEG_NAME";
                    drpDesination.DataValueField = "DEG_NAME";
                    drpDesination.DataBind();
                    drpDesination.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        private void getOffices()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = attendancebonusbll.GetAllOffice(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpdwnOffice.DataSource = row.ToList();
                    drpdwnOffice.DataTextField = "OfficeName";
                    drpdwnOffice.DataValueField = "OfficeID";
                    drpdwnOffice.DataBind();
                    drpdwnOffice.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAttendanceBounes_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_AttendanceBouns hrmAttendanceBouns = new HRM_AttendanceBouns();
                hrmAttendanceBouns.AttendanceDays1 = Convert.ToInt16(txtbxFirstAttendanceDay.Text);
                hrmAttendanceBouns.AttendanceDays2 = Convert.ToInt16(txtbxSecondAttendanceDayes.Text);
                hrmAttendanceBouns.Desgination = drpDesination.SelectedValue.ToString();
                hrmAttendanceBouns.Amount1 = Convert.ToDecimal(txtbxFirstAttendanceAmount.Text);
                hrmAttendanceBouns.Amount2 = Convert.ToDecimal(txtbxSecondAttendanceAmount.Text);
                hrmAttendanceBouns.OfficeId = Convert.ToInt16(drpdwnOffice.SelectedValue);

                hrmAttendanceBouns.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                hrmAttendanceBouns.EDIT_DATE = DateTime.Now;
                hrmAttendanceBouns.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnAttendanceBounes.Text == "Submit")
                {
                    int result = attendancebonusbll.SaveAttendanceBonus(hrmAttendanceBouns);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Data Save Successfully !";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully !')", true);
                    }
                }
                else
                {
                    int id = Convert.ToInt16(hidAttenBounsId.Value);
                    int result = attendancebonusbll.UpdateAttendanceBonus(hrmAttendanceBouns, id);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Update Save Successfully !";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Update Save Successfully !')", true);
                    }
                }
                GetAttenanceBonusList();
                ClearAllControll();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControll()
        {
            try
            {
                getOffices();
                getDesgination();
                txtbxFirstAttendanceDay.Text = "";
                txtbxSecondAttendanceDayes.Text = "";
                txtbxFirstAttendanceAmount.Text = "";
                txtbxSecondAttendanceAmount.Text = "";
                btnAttendanceBounes.Text = "Submit";

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewattendanceBonus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewattendanceBonus.PageIndex = e.NewPageIndex;
            GetAttenanceBonusList();

        }

        protected void imgbtnAttendanceBonus_Click(object sender, EventArgs e)
        {
            List<HRM_AttendanceBouns> attendanceBouns = new List<HRM_AttendanceBouns>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string atId = "";
                Label lblAttId = (Label)gridviewattendanceBonus.Rows[row.RowIndex].FindControl("lblAttendanceBounsId");
                if (lblAttId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    atId = lblAttId.Text;
                    attendanceBouns = attendancebonusbll.getAttendanceBounsId(atId, OCODE);

                    if (attendanceBouns.Count > 0)
                    {
                        foreach (HRM_AttendanceBouns aitem in attendanceBouns)
                        {
                            hidAttenBounsId.Value = aitem.attendanceBounsId.ToString();
                            drpdwnOffice.SelectedValue = aitem.OfficeId.ToString();
                            drpDesination.SelectedValue = aitem.Desgination.ToString();
                            txtbxFirstAttendanceDay.Text = aitem.AttendanceDays1.ToString();
                            txtbxFirstAttendanceAmount.Text = aitem.Amount1.ToString();
                            txtbxSecondAttendanceDayes.Text = aitem.AttendanceDays2.ToString();
                            txtbxSecondAttendanceAmount.Text = aitem.Amount2.ToString();

                            if (btnAttendanceBounes.Text == "Submit")
                            {
                                btnAttendanceBounes.Text = "Update";
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
    }
}