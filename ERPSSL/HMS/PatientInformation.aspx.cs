using ERPSSL.HMS.BLL;
using ERPSSL.HMS.DAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HMS
{
    public partial class PatientInformation : System.Web.UI.Page
    {
        PatientEntry_BLL objPatient_Bll = new PatientEntry_BLL();
        ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetPatientInfo();
                  //  GetBillCategoryList();
                    GetBillHeadList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void GetBillCategoryList()
        //{
        //    try
        //    {
        //        List<HMS_BillCategory> row = objPatient_Bll.GetBillCategoryList();

        //        if (row != null)
        //        {
        //            ddlCategory.DataSource = row.ToList();
        //            ddlCategory.DataTextField = "CategoryName";
        //            ddlCategory.DataValueField = "HMS_CategoryId";
        //            ddlCategory.DataBind();
        //            ddlCategory.AppendDataBoundItems = false;
        //            ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        private void GetBillHeadList()
        {
            try
            {
                List<HMS_BillHead> row = objPatient_Bll.GetBillHeadList();

                if (row != null)
                {
                    ddlHead.DataSource = row.ToList();
                    ddlHead.DataTextField = "Bill_Head_Name";
                    ddlHead.DataValueField = "HMS_Bill_Head_Id";
                    ddlHead.DataBind();
                    ddlHead.AppendDataBoundItems = false;
                    ddlHead.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        protected void gridPatient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPatient.PageIndex = e.NewPageIndex;
            GetPatientInfo();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                
              if (btnSubmit.Text == "Submit")
                {

                    if (txtPatientName.Text == "")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Patient Name !!')", true);

                    }
                    else if (ddlGender.SelectedItem.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Gender !!')", true);
                    }

                    else if (ddlBloodGrp.SelectedItem.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Blood Group !!')", true);
                    }
                    else if (txtAge.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Age!!')", true);
                    }
                    else if (txtMobile.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Mobile !!')", true);
                    }
                    else if (txtVisitDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Visit Date!!')", true);
                    }
                    else
                    {
                        HMS_PatientInfo objPatient = new HMS_PatientInfo();

                        objPatient.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        objPatient.PatientName = txtPatientName.Text;                                   
                        objPatient.Age = txtAge.Text;
                        objPatient.M_Y_D = ddlAgeFormat.SelectedItem.Text;
                        objPatient.Gender = ddlGender.SelectedItem.Text;
                        objPatient.BloodGroup = ddlBloodGrp.SelectedItem.Text;
                        objPatient.MaritalStatus = ddlMarital.SelectedItem.Text;
                        objPatient.Mobile = txtMobile.Text;
                        objPatient.Address = txtAddress.Text;
                        objPatient.GuardianName = txtGuardian.Text;
                        objPatient.GuardianContactNo = txtEmerContact.Text;
                        objPatient.VisitDate = Convert.ToDateTime(txtVisitDate.Text);
                        objPatient.BillCategoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
                        objPatient.BillHeadId = Convert.ToInt32(ddlHead.SelectedValue.ToString());
                        objPatient.Amount = Convert.ToDecimal(txtAmount.Text);                    
                        objPatient.Bed_CabinNo = txtBedNo.Text;
                        objPatient.RefdBy = txtRefdBy.Text;
                        objPatient.Remarks = txtRemarks.Text;

                        objPatient.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                        objPatient.Create_Date = DateTime.Now;
                        int result = objPatient_Bll.InsertPatient(objPatient);
                         
                            if (result == 1)
                                {                               

                                    HMS_PatientCollectionSummary objSummary = new HMS_PatientCollectionSummary();

                                    Session["Patient_Id"] = objPatient.PatientID;

                                    objSummary.PatientID = objPatient.PatientID;                                     
                                    objSummary.CollectionDate = Convert.ToDateTime(txtVisitDate.Text);
                                    objSummary.CollectionAmount = Convert.ToDecimal(txtAmount.Text);
                                    objSummary.AdvanceAmount = Convert.ToDecimal(txtAmount.Text);
                                    objSummary.Discount_Percent = 0;
                                    objSummary.ServiceCharge_Percent = 0;
                                    objSummary.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                                    objSummary.Create_Date = DateTime.Now;
                                    objSummary.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    int aResult = objPatient_Bll.InsertPatientSummary(objSummary);

                                   //----------------------------------------------------------
                                    HMS_PatientBillInfo objBill = new HMS_PatientBillInfo();

                                    objBill.PatientId = objPatient.PatientID;
                                    objBill.Bill_Category_Id = Convert.ToInt32(ddlCategory.SelectedValue.ToString()); ;
                                    objBill.Bill_Head_Id = Convert.ToInt32(ddlHead.SelectedValue.ToString());
                                    objBill.CollectionDate = Convert.ToDateTime(txtVisitDate.Text);
                                    objBill.Amount = Convert.ToDecimal(txtAmount.Text);
                                    objBill.Qty = 1;
                                    objBill.TotalAmount = Convert.ToDecimal(txtAmount.Text);
                                    objBill.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                                    objBill.Create_Date = DateTime.Now;
                                    objBill.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    int bResult = objPatient_Bll.InsertPatientBill(objBill);
                                //---------------------------------------------------------------
                              
                                if (bResult == 1 )
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully !')", true);
                                        btnSubmit.Text = "Print";
                                    }
                              
                                }
                           }
                    }
                    else
                    {
                        gridPatient.Visible = false;

                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        int _patientId =Convert.ToInt32(Session["Patient_Id"]);

                        var Patient = objPatient_Bll.GetPatientInfoForReport(_patientId,OCODE).ToList();

                        if (Patient.Count > 0)
                        {
                            Session["rptDs"] = "ds_PatientInfo";
                            Session["rptDt"] = Patient;
                            Session["rptFile"] = "/HMS/reports/HMS_Rpt_PatientInfo.rdlc";
                           // Session["rptTitle"] = "Patient Money Receipt";
                            
                            string rptDs = Convert.ToString(Session["rptDs"]);
                            var reportDataSource = new ReportDataSource
                            {
                                Name = rptDs,
                                Value = Session["rptDt"]
                            };
                            ReportViewer2.LocalReport.DataSources.Clear();
                            ReportViewer2.LocalReport.DataSources.Add(reportDataSource);
                            ReportViewer2.LocalReport.ReportPath = Server.MapPath(Convert.ToString(Session["rptFile"]));
                            //ReportParameter prm_1 = new ReportParameter("datePrint", Convert.ToString(DateTime.Now.Date));
                            //ReportParameter prm_2 = new ReportParameter("rptTitle", Convert.ToString(Session["rptTitle"]));
                            //ReportViewer2.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_2 });
                            ReportViewer2.LocalReport.Refresh();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    GetPatientInfo();
                    ClearPatientInfo();
              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void GetPatientInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var patient = objPatient_Bll.GetPatientInfoList(OCODE).ToList();
                if (patient.Count > 0)
                {
                    
                    gridPatient.DataSource = patient.ToList();
                    gridPatient.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearPatientInfo()
        {
            try
            {
               txtPatientName.Text = "";
               ddlCategory.ClearSelection();
               ddlAgeFormat.ClearSelection();
               ddlBloodGrp.ClearSelection();
               ddlHead.ClearSelection();
               ddlMarital.ClearSelection();
               ddlGender.ClearSelection();
               txtAddress.Text = "";
               txtAge.Text = "";
               txtAmount.Text = "";
               txtBedNo.Text = "";
               txtEmerContact.Text = "";
               txtGuardian.Text = "";
               txtMobile.Text = "";
               txtRefdBy.Text = "";
               txtVisitDate.Text = "";
               txtRemarks.Text = "";
              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnImgPatientEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<HMS_PatientInfo> objPatient = new List<HMS_PatientInfo>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string P_Id = "";
                Label lblSectionId = (Label)gridPatient.Rows[row.RowIndex].FindControl("lblPatientId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    P_Id = lblSectionId.Text.ToString();
                    objPatient = objPatient_Bll.GetPatientByPatientId(P_Id, OCODE);

                    if (objPatient.Count > 0)
                    {
                        var info = objPatient.FirstOrDefault();
                        hidPatientId.Value = info.PatientID.ToString();
                        hidPatientName.Value = txtPatientName.Text = info.PatientName;
                        txtAge.Text = info.Age.ToString();
                        ddlAgeFormat.SelectedValue = info.M_Y_D;
                        ddlBloodGrp.SelectedValue = info.BloodGroup;
                        ddlGender.SelectedValue = info.Gender;
                        ddlMarital.SelectedValue = info.MaritalStatus;
                        txtAddress.Text = info.Address;
                        txtAmount.Text = info.Amount.ToString();
                        txtGuardian.Text = info.GuardianName;
                        txtEmerContact.Text = info.GuardianContactNo;
                        txtMobile.Text = info.Mobile;
                        txtBedNo.Text = info.Bed_CabinNo;
                        txtVisitDate.Text = info.VisitDate.ToString();
                        txtRefdBy.Text = info.RefdBy;
                        ddlCategory.SelectedValue = info.BillCategoryId.ToString();
                        ddlHead.SelectedValue = info.BillHeadId.ToString();

                        btnSubmit.Visible = false;
                        DisableFields();                      

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void DisableFields()
        {
          txtPatientName.Enabled = false;
          txtAge.Enabled = false;
          ddlAgeFormat.Enabled =false ;
          ddlBloodGrp.Enabled = false;
          ddlGender.Enabled = false;
          ddlMarital.Enabled = false;
          txtAddress.Enabled = false;
          txtAmount.Enabled = false;
          txtGuardian.Enabled = false;
          txtEmerContact.Enabled = false;
          txtMobile.Enabled = false;
          txtBedNo.Enabled = false;
          txtVisitDate.Enabled = false;
          txtRefdBy.Enabled = false;
          ddlCategory.Enabled = false;
          ddlHead.Enabled = false;
        }
    
        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            string name = ddlHead.SelectedItem.Text;
            int id = Convert.ToInt32(ddlCategory.SelectedValue);

            var _Price = (from head in _context.HMS_BillHead
                          where head.Bill_Head_Name == name && head.HMS_CategoryId == id
                          select head.Price).FirstOrDefault().ToString();

            txtAmount.Text = String.Format("{0:0.00}", _Price);
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlCategory.SelectedValue);

            var _BillHead = (from s in _context.HMS_BillHead
                             where s.HMS_CategoryId == id
                             select s).ToList();

            if (_BillHead != null)
            {
                ddlHead.DataSource = _BillHead.ToList();
                ddlHead.DataTextField = "Bill_Head_Name";
                ddlHead.DataValueField = "HMS_Bill_Head_Id";
                ddlHead.DataBind();

            }
        }

      
    }
}