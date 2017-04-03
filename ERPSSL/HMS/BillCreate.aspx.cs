using ERPSSL.HMS.BLL;
using ERPSSL.HMS.DAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;

namespace ERPSSL.HMS
{
    public partial class BillCreate : System.Web.UI.Page
    {
        PatientEntry_DAL obj_Dal = new PatientEntry_DAL();
        private ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();
        PatientBillEntry_BLL obj_Bll = new PatientBillEntry_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                    GetBillCategoryList();
                    GetBillHeadList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetBillCategoryList()
        {
            try
            {
                List<HMS_BillCategory> row = obj_Dal.GetBillCategoryList();

                if (row != null)
                {
                    ddlCategory.DataSource = row.ToList();
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "HMS_CategoryId";
                    ddlCategory.DataBind();
                    ddlCategory.AppendDataBoundItems = false;
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void GetBillHeadList()
        {
            try
            {
                List<HMS_BillHead> row = obj_Dal.GetBillHeadList();

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

        protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = ddlHead.SelectedItem.Text;
            int id = Convert.ToInt32(ddlCategory.SelectedValue);

            var _Price = (from head in _context.HMS_BillHead
                          where head.Bill_Head_Name == name && head.HMS_CategoryId == id
                          select head.Price).FirstOrDefault().ToString();

            txtPrice.Text = String.Format("{0:0.00}", _Price);

        }

        protected void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    lblMessage.Text = "";
                    string id = txtId.Text;
                    PatientDetailsById(id);
                    int pat_Id = Convert.ToInt32(txtId.Text);

                    var dischrge = (from date in _context.HMS_PatientCollectionSummary
                                    where date.PatientID == pat_Id
                                    select date).Take(10).ToList();

                    var disDate = dischrge.Last();
                    var abc = disDate.DisChargeDate.ToString();

                    if (abc == "" || abc == null)
                    {

                        BillCalculation(pat_Id);
                        GetPatient_BillInfo();
                    }
                    else
                    {
                       // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('The patient is Discharged !!')", true);
                       // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('The patient is Discharged');", true);
                        lblMessage.Text = "The patient is Discharged";
                    }


                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
        }

       

        private void PatientDetailsById(string id)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string patientID = Convert.ToString(id);

            var result = obj_Dal.GetPatientByPatientId(patientID, OCODE);


            if (result.Count > 0)
            {

                var objPatient = result.First();

                txtId.Text = Convert.ToString(objPatient.PatientID);
                txtName.Text = objPatient.PatientName;
                txtAge.Text = objPatient.Age;
                ddlAgeFormat.SelectedValue = objPatient.M_Y_D;
                ddlBlood.SelectedValue = objPatient.BloodGroup;
                txtMobile.Text = objPatient.Mobile;
            }
            else
            {
                txtId.Text = "";
                txtName.Text = "";
                txtAge.Text = "";
                ddlAgeFormat.ClearSelection();
                ddlBlood.ClearSelection();
                txtMobile.Text = "";

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Patient Not Found!')", true);
            }
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                try
                {
                    string patname = txtName.Text;
                    PatientDetailsByName(patname);

                    var dischrge = (from date in _context.HMS_PatientCollectionSummary
                                    where date.HMS_PatientInfo.PatientName == patname
                                    select date).Take(10).ToList();

                    var disDate = dischrge.Last();
                    var abc = disDate.DisChargeDate.ToString();

                    if (abc == "" || abc == null)
                    {

                        GetPatient_BillInfo();
                        int pat_Id = Convert.ToInt32(txtId.Text);
                        BillCalculation(pat_Id);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('The Patient is Discharged!!')", true);
                        lblMessage.Text = "The patient is Discharged";
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
        }

        private void PatientDetailsByName(string name)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            var result = obj_Dal.GetPatientByPatientName(name, OCODE);


            if (result.Count > 0)
            {

                var objPatient = result.First();

                txtId.Text = Convert.ToString(objPatient.PatientID);
                txtName.Text = objPatient.PatientName;
                txtAge.Text = objPatient.Age;
                ddlAgeFormat.SelectedValue = objPatient.M_Y_D;
                ddlBlood.SelectedValue = objPatient.BloodGroup;
                txtMobile.Text = objPatient.Mobile;
            }
            else
            {
                txtId.Text = "";
                txtName.Text = "";
                txtAge.Text = "";
                ddlAgeFormat.ClearSelection();
                ddlBlood.ClearSelection();
                txtMobile.Text = "";

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Patient Not Found!')", true);
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchPatientByName(string prefixText, int count)
        {
            using (var _context = new ERPSSL_HMSEntities())
            {
                var patient = from pat in _context.HMS_PatientInfo
                              where (pat.PatientName.StartsWith(prefixText))
                              select pat;

                List<String> patientList = new List<String>();

                foreach (var p in patient)
                {
                    patientList.Add(p.PatientName);
                }


                return patientList;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Category !!')", true);

            }
            else if (ddlHead.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Bill Head !!')", true);
            }
            else if (txtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please input Patient ID !!')", true);
            }
            else if (txtCollectionDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please input Collection Date !!')", true);
            }
            else if (txtQty.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please input Quantity !!')", true);
            }
            else if (txtTotalAmt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please input Total Amount !!')", true);
            }
            else
            {
                HMS_PatientBillInfo objBill = new HMS_PatientBillInfo();

                objBill.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                objBill.PatientId = Convert.ToInt32(txtId.Text);
                objBill.Bill_Category_Id = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
                objBill.Bill_Head_Id = Convert.ToInt32(ddlHead.SelectedValue.ToString());
                objBill.Amount = Convert.ToDecimal(txtPrice.Text);
                objBill.CollectionDate = Convert.ToDateTime(txtCollectionDate.Text);
                objBill.Qty = Convert.ToInt32(txtQty.Text);
                objBill.TotalAmount = Convert.ToDecimal(txtTotalAmt.Text);
                objBill.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                objBill.Create_Date = DateTime.Now;
                int result = obj_Bll.InsertPatientBill(objBill);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully !')", true);
                    int id = Convert.ToInt32(txtId.Text);
                    BillCalculation(id);
                    ClearPatient_BillUi();
                    GetPatient_BillInfo();
                }
            }
        }

        private void GetPatient_BillInfo()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int PatientId = Convert.ToInt32(txtId.Text);

                var bill = obj_Bll.GetPatientBillInfoList(PatientId, OCODE).ToList();

                GridViewBillInfo.DataSource = bill.ToList();
                GridViewBillInfo.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearPatient_BillUi()
        {
            try
            {

                ddlCategory.ClearSelection();
                ddlHead.ClearSelection();
                txtPrice.Text = "";
                txtQty.Text = "";
                txtTotalAmt.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void BillCalculation(int patient_Id)
        {
            var sum = (from amt in _context.HMS_PatientBillInfo
                       where amt.PatientId == patient_Id
                       select amt.TotalAmount).Sum();

            txtTotal.Text = String.Format("{0:0.00}", sum);


            var paidAmt = (from amount in _context.HMS_PatientCollectionSummary
                           where amount.PatientID == patient_Id
                           select amount.CollectionAmount).Sum();

            txtPaid.Text = String.Format("{0:0.00}", paidAmt);


            var serviceChrg = (from chrg in _context.HMS_PatientCollectionSummary
                               where chrg.PatientID == patient_Id
                               select chrg.ServiceCharge_Percent).Sum();

            var discount = (from disc in _context.HMS_PatientCollectionSummary
                            where disc.PatientID == patient_Id
                            select disc.Discount_Percent).Sum();

            Double charg = Convert.ToDouble(serviceChrg);
            Double _disc = Convert.ToDouble(discount);

            txtServiceAmt.Text = String.Format("{0:0.00}", charg);
            txtDiscountAmt.Text = String.Format("{0:0.00}", _disc);
            Double paid = Convert.ToDouble(txtPaid.Text);
            Double total = Convert.ToDouble(txtTotal.Text);

            Double totalBill = (total + charg) - (paid + _disc);

            txtDue.Text = String.Format("{0:0.00}", totalBill);

            Double netAmt = (total + charg) - _disc;
            txtNetAmount.Text = String.Format("{0:0.00}", netAmt);

            txtReceiveAmt.Text = "";


        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Double charge = Convert.ToDouble(txtServiceCharge.Text) / 100;
            Double bill = Convert.ToDouble(txtTotal.Text);
            Double chargeAmt = (bill * charge);
            txtServiceAmt.Text = String.Format("{0:0.00}", chargeAmt);

            Double discount = Convert.ToDouble(txtDiscount.Text) / 100;
            Double discAmt = (bill * discount);
            txtDiscountAmt.Text = String.Format("{0:0.00}", discAmt);

            Double paidAmt = Convert.ToDouble(txtPaid.Text);

            Double totalBill = (bill + chargeAmt) - (paidAmt + discAmt);

            txtDue.Text = String.Format("{0:0.00}", totalBill);
            txtNetAmount.Text = String.Format("{0:0.00}", totalBill);

        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            Double price = Convert.ToDouble(txtPrice.Text);
            int qty = Convert.ToInt32(txtQty.Text);
            Double totalAmt = qty * price;

            txtTotalAmt.Text = String.Format("{0:0.00}", totalAmt);
        }

        protected void txtServiceCharge_TextChanged(object sender, EventArgs e)
        {
            Double charge = Convert.ToDouble(txtServiceCharge.Text) / 100;
            Double bill = Convert.ToDouble(txtTotal.Text);
            Double chargeAmt = (bill * charge);
            txtServiceAmt.Text = String.Format("{0:0.00}", chargeAmt);

            Double discount = Convert.ToDouble(txtDiscount.Text) / 100;
            Double discAmt = (bill * discount);
            txtDiscountAmt.Text = String.Format("{0:0.00}", discAmt);

            Double paidAmt = Convert.ToDouble(txtPaid.Text);

            Double totalBill = (bill + chargeAmt) - (paidAmt + discAmt);

            txtDue.Text = String.Format("{0:0.00}", totalBill);
            txtNetAmount.Text = String.Format("{0:0.00}", totalBill);

        }

        protected void btnBillAdd_Click(object sender, EventArgs e)
        {
            if (txtReceiveAmt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please input Receive Amount !!')", true);
            }
            else if (txtCollectionDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please input Collection Date !!')", true);
            }
            else
            {
                int patId = Convert.ToInt32(txtId.Text);

                var visDate = (from date in _context.HMS_PatientInfo
                               where date.PatientID == patId
                               select date).First();


                HMS_PatientCollectionSummary objBill = new HMS_PatientCollectionSummary();

                objBill.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                objBill.PatientID = Convert.ToInt32(txtId.Text);
                objBill.CollectionDate = Convert.ToDateTime(txtCollectionDate.Text);
                objBill.CollectionAmount = Convert.ToDecimal(txtReceiveAmt.Text);
                objBill.ServiceCharge_Percent = Convert.ToDecimal(txtServiceAmt.Text);
                objBill.Discount_Percent = Convert.ToDecimal(txtDiscountAmt.Text);

                if (txtDischargDate.Text != "")
                {
                    DateTime dischrg = Convert.ToDateTime(txtDischargDate.Text);
                    objBill.DisChargeDate = dischrg;
                    TimeSpan difference = dischrg - Convert.ToDateTime(visDate.VisitDate);
                    var days = difference.TotalDays;
                    objBill.Duration = days.ToString();
                }

                objBill.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                objBill.Create_Date = DateTime.Now;
                int result = obj_Bll.InsertCollectionBill(objBill);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully !')", true);
                    int pat_Id = Convert.ToInt32(txtId.Text);
                    BillCalculation(pat_Id);
                    ClearBillUi();
                }
            }

        }

        public void ClearBillUi()
        {
            txtReceiveAmt.Text = "";
            txtServiceCharge.Text = "";
            txtDiscount.Text = "";
            txtCollectionDate.Text = "";
            txtNetAmount.Text = "";
        }

        protected void btnRemoveImg_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string P_Id = "";
                Label lblSectionId = (Label)GridViewBillInfo.Rows[row.RowIndex].FindControl("lblId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    P_Id = lblSectionId.Text.ToString();
                    int result = obj_Bll.DeletePatientBillHead(P_Id, OCODE);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Deleted Successfully !')", true);
                        int id = Convert.ToInt32(txtId.Text);
                        BillCalculation(id);
                        GetPatient_BillInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void txtPrint_Click(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            int _patientId = Convert.ToInt32(txtId.Text);

            var bill = obj_Bll.GetPatientBillInfoForReport(_patientId, OCODE).ToList().DistinctBy(x => x.Bill_Head_Name);

            if (bill != null)
            {
                Session["rptDs"] = "ds_BillInfo";
                Session["rptDt"] = bill;
                Session["rptFile"] = "/HMS/reports/HMS_Rpt_PatientBillInfo.rdlc";
                //  Session["rptTitle"] = "Patient Bill Receipt";

                string rptDs = Convert.ToString(Session["rptDs"]);
                var reportDataSource = new ReportDataSource
                {
                    Name = rptDs,
                    Value = Session["rptDt"]
                };
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(Convert.ToString(Session["rptFile"]));
                //   ReportParameter prm_1 = new ReportParameter("datePrint", Convert.ToString(DateTime.Now.Date));
                //  ReportParameter prm_2 = new ReportParameter("rptTitle", Convert.ToString(Session["rptTitle"]));
                //  ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_2 });
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
            }
        }

        protected void chkStleWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStleWise.Checked == true)
            {
                txtDischargDate.Visible = true;
            }
            else
            {
                txtDischargDate.Visible = false;
            }
        }

        protected void txtDiscountAmt_TextChanged(object sender, EventArgs e)
        {

            Double bill = Convert.ToDouble(txtTotal.Text);

            Double chargeAmt = Convert.ToDouble(txtServiceAmt.Text);
            Double discAmt = Convert.ToDouble(txtDiscountAmt.Text);


            Double paidAmt = Convert.ToDouble(txtPaid.Text);

            Double totalBill = (bill + chargeAmt) - (paidAmt + discAmt);

            txtDue.Text = String.Format("{0:0.00}", totalBill);
            txtNetAmount.Text = String.Format("{0:0.00}", totalBill);
        }


    }
}