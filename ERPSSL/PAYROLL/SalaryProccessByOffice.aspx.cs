using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using AjaxControlToolkit;
using ERPSSL.PAYROLL.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.PAYROLL
{
    public partial class SalaryProccessByOffice : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Office_BLL objOfficeBLL = new Office_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        Salary_Proccess_BLL aSalary_Proccess_BLL = new Salary_Proccess_BLL();
        TIME_SCHEDULE_BLL aTIME_SCHEDULE_BLL = new TIME_SCHEDULE_BLL();
        SalaryUpdate_BLL salaryupdateBll = new SalaryUpdate_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetRegionList();
                    lblTotalPayable.Text = "";
                    //txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    //txtDateTo.Text = DateTime.Today.ToShortDateString();
                    GetSalaryIncrementLog();
                    GetEmployeesForSalaryIncrement();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetEmployeesForSalaryIncrement()
        {
            try
            {
                List<SalaryIncrementR> slaryIncrementRes = new List<SalaryIncrementR>();
                DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
                SalaryIncrementBLL _salaryIncrementBll = new SalaryIncrementBLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_PersonalInformations> personalInformations = salaryupdateBll.GetEmployeesForSalaryIncrement(OCODE);
                DateTime serverDate = _salaryIncrementBll.GetServerDate();
                List<HRM_PersonalInformations> personalInfoes = _salaryIncrementBll.GetAllEmployess(OCODE);
                List<HRM_DESIGNATIONS> designationes = _salaryIncrementBll.GetAllDesgination(OCODE);
                foreach (HRM_PersonalInformations aitem in personalInformations)
                {
                    if (serverDate >= aitem.ConfiramtionDate && aitem.ConfiramtionDateStatus == false)
                    {
                        SalaryIncrementR _salaryIncrementR = new SalaryIncrementR();
                        int? desId = personalInfoes.Where(x => x.EID == aitem.EID).FirstOrDefault().DesginationId;
                        string desName = designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().DEG_NAME;
                        string grade = designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().GRADE;
                        decimal? EffectiveSalary = aitem.EffectiveSlary;

                        bool Status = CheckDesignation(desName, grade, EffectiveSalary);
                        if (Status == false)
                        {
                            InsertDesgination(desName, grade, EffectiveSalary);
                        }
                        HRM_DESIGNATIONS _Desobj = objDeg_BLL.GetDesignationIdByDesNameGradAndGoss(desName, grade, EffectiveSalary);
                        if (_Desobj != null)
                        {
                            _salaryIncrementR.Eid = aitem.EID;
                            _salaryIncrementR.Grade = grade;
                            _salaryIncrementR.SalaryIncrementStatus = "Effective Salary";
                            _salaryIncrementR.EffectiveDate = aitem.ConfiramtionDate;
                            _salaryIncrementR.previousSalary = aitem.Salary;
                            _salaryIncrementR.Slary = Convert.ToDecimal(EffectiveSalary);
                            _salaryIncrementR.DesId = _Desobj.DEG_ID;
                            _salaryIncrementR.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                            _salaryIncrementR.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            _salaryIncrementR.EDIT_DATE = DateTime.Now;
                            slaryIncrementRes.Add(_salaryIncrementR);
                        }
                        if (slaryIncrementRes.Count > 0)
                        {
                            int result = _salaryIncrementBll.AutomaticSalaryUpdateByEffectiveDate(slaryIncrementRes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetSalaryIncrementLog()
        {
            DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
            SalaryIncrementBLL _salaryIncrementBll = new SalaryIncrementBLL();
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_SalaryIncrement> salaryIncrements = _salaryIncrementBll.GetSalaryIncrementLog(OCODE);
                DateTime serverDate = _salaryIncrementBll.GetServerDate();
                List<HRM_PersonalInformations> personalInfoes = _salaryIncrementBll.GetAllEmployess(OCODE);
                List<HRM_DESIGNATIONS> designationes = _salaryIncrementBll.GetAllDesgination(OCODE);
                List<SalaryIncrementR> slaryIncrementRes = new List<SalaryIncrementR>();
                foreach (HRM_SalaryIncrement aitem in salaryIncrements)
                {
                    if (serverDate >= aitem.EffectiveDate)
                    {
                        SalaryIncrementR _salaryIncrementR = new SalaryIncrementR();
                        int? desId = personalInfoes.Where(x => x.EID == aitem.EID).FirstOrDefault().DesginationId;
                        string desName = designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().DEG_NAME;
                        string grade = designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().GRADE;
                        decimal? Gosssalary = aitem.IncrementSalary; //designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().GROSS_SAL;
                        bool Status = CheckDesignation(desName, grade, Gosssalary);

                        if (Status == false)
                        {
                            InsertDesgination(desName, grade, Gosssalary);

                        }
                        HRM_DESIGNATIONS _Desobj = objDeg_BLL.GetDesignationIdByDesNameGradAndGoss(desName, grade, Gosssalary);
                        if (_Desobj != null)
                        {
                            _salaryIncrementR.Eid = aitem.EID;
                            _salaryIncrementR.IncrementDate = aitem.IncrementDate;
                            _salaryIncrementR.Grade = grade;
                            _salaryIncrementR.SalaryIncrementStatus = "Salary Increment";
                            _salaryIncrementR.EffectiveDate = aitem.EffectiveDate;
                            _salaryIncrementR.previousSalary = aitem.previousSalary;
                            _salaryIncrementR.Slary = Convert.ToDecimal(aitem.IncrementSalary);
                            _salaryIncrementR.DesId = _Desobj.DEG_ID;
                            _salaryIncrementR.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                            _salaryIncrementR.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            _salaryIncrementR.EDIT_DATE = DateTime.Now;
                            slaryIncrementRes.Add(_salaryIncrementR);
                        }
                    }
                }
                if (slaryIncrementRes.Count > 0)
                {
                    int result = _salaryIncrementBll.AutomaticSalaryUpdate(slaryIncrementRes);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void InsertDesgination(string desName, string grade, decimal? Gosssalary)
        {
            try
            {
                DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
                double gross_Salary = Convert.ToDouble(Gosssalary);

                double medical = 250;

                double taransport = 200;
                double food = 650;
                double withoutMedical = (gross_Salary - (medical + taransport + food));
                double Basic = (withoutMedical) / 1.4;
                double houseRent = (Basic * 40) / 100;

                HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                designationObj.DEG_NAME = desName.ToString();
                designationObj.GRADE = grade;
                designationObj.GROSS_SAL = Convert.ToDecimal(gross_Salary);
                designationObj.HOUSE_RENT = Convert.ToDecimal(houseRent);
                designationObj.BASIC = Convert.ToDecimal(Basic);
                designationObj.MEDICAL = Convert.ToDecimal(medical);
                designationObj.FOOD_ALLOW = Convert.ToDecimal(0.00);
                designationObj.CONVEYANCE = Convert.ToDecimal(0.00);
                designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                designationObj.EDIT_DATE = DateTime.Now;
                designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = objDeg_BLL.InsertDeignation(designationObj);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool CheckDesignation(string Desgination, string Grad, decimal? Gosssalary)
        {
            bool Status = false;
            try
            {
                SalaryIncrementBLL _salaryIncrementBll = new SalaryIncrementBLL();
                Status = _salaryIncrementBll.CheckDesignation(Desgination, Grad, Gosssalary);
                return Status;
            }
            catch (Exception ex)
            {
            }
            return Status;
        }

        private void GetRegionList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion.DataSource = row.ToList();
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();
                    ddlRegion.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BindOfficeByRegion(int RegionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(RegionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice.DataSource = row.ToList();
                    ddlOffice.DataTextField = "OfficeName";
                    ddlOffice.DataValueField = "OfficeID";
                    ddlOffice.DataBind();
                    ddlOffice.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                BindOfficeByRegion(RegionId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        void BindGridEmployeeSalaryByOffice()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                List<Salary_Viewer> empSalary = new List<Salary_Viewer>();

                empSalary = aSalary_Proccess_BLL.Get_SalProccess_TempByOffice(Convert.ToDateTime(txtDateFrom.Text), Convert.ToInt16(ddlOffice.SelectedValue)).ToList();
                if (empSalary.Count > 0)
                {
                    GridViewEMP_AT.DataSource = empSalary.ToList();
                    GridViewEMP_AT.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Processed!')", true);
                    GridViewEMP_AT.DataSource = null;
                    GridViewEMP_AT.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //List<HRM_Pay_Salary> paySalaryBydate = aSalary_Proccess_BLL.GetPaySalaryByDate(Convert.ToDateTime(txtDateFrom.Text));

                //if (paySalary.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Salary already processed for this time period!')", true);
                //    txtDateFrom.Text = "";
                //    txtDateTo.Text = "";
                //    txtTotalDay.Text = "";
                //    txtWeekend.Text = "";
                //    txtHoliday.Text = "";
                //}
                //else
                //{
                int officeID = Convert.ToInt16(ddlOffice.Text);
                List<string> ShiftCodes = aSalary_Proccess_BLL.GetShiftCodeByOfficeID(officeID);

                // re-update advance deduction status
                var salaryYear = DateTime.Parse(txtDateFrom.Text).Year;
                var salaryMonth = DateTime.Parse(txtDateFrom.Text).Month;
                Guid Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails = new HRM_AdvanceSalaryDetails();
                aHRM_AdvanceSalaryDetails.Month = salaryMonth;
                aHRM_AdvanceSalaryDetails.Year = salaryYear;
                aHRM_AdvanceSalaryDetails.AdvanceDeduction = false;
                aHRM_AdvanceSalaryDetails.EDIT_DATE = DateTime.Now;
                aHRM_AdvanceSalaryDetails.EDIT_USER = Edit_User;
                aSalary_Proccess_BLL.UpdateAdvanceDeductStatus(aHRM_AdvanceSalaryDetails);
                //

                foreach (string ashiftcode in ShiftCodes)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    var result = aTIME_SCHEDULE_BLL.GetAllScheduleByCode(OCODE, ashiftcode);
                    if (result.Count > 0)
                    {
                        var objWeekend = result.First();
                        txtWeekend1.Text = objWeekend.Weekend1.ToString();
                        txtWeekend2.Text = objWeekend.Weekend2.ToString();
                    }

                    //get weekend

                    int i = 0, j = 0;

                    DateTime DateFrom = Convert.ToDateTime(txtDateFrom.Text);
                    DateTime DateTo = Convert.ToDateTime(txtDateTo.Text);

                    while (DateFrom <= DateTo)
                    {
                        string week1 = DateFrom.DayOfWeek.ToString();
                        if (DateFrom.DayOfWeek.ToString() == txtWeekend1.Text)
                        {
                            i = i + 1;
                        }
                        if (DateFrom.DayOfWeek.ToString() == txtWeekend2.Text)
                        {
                            j = j + 1;
                        }
                        DateFrom = DateFrom.AddDays(1);
                    }

                    txtWeekend.Text = (i + j).ToString();

                    //insert salary proccessed data to temp table

                    var result2 = aSalary_Proccess_BLL.InsertSalary_ProccessByOffice(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), Convert.ToInt16(txtTotalDay.Text), Convert.ToInt16(txtWeekend.Text), Convert.ToInt16(txtHoliday.Text), ashiftcode, OCODE, Edit_User, Convert.ToInt16(ddlOffice.SelectedValue));

                    if (result2 == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Salary processed temporarily')", true);
                        //lblMessage.Text = "Salary proccessed successfully";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        BindGridEmployeeSalaryByOffice();

                        var empSalary = aSalary_Proccess_BLL.Get_SalProccess_TempByOffice(Convert.ToDateTime(txtDateFrom.Text), Convert.ToInt16(ddlOffice.SelectedValue)).FirstOrDefault();
                        //lblTotalPayable.Text = empSalary.Total_Net_Payable.ToString();
                    }
                }
            }
            //}
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void GridViewEMP_AT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEMP_AT.PageIndex = e.NewPageIndex;
            BindGridEmployeeSalaryByOffice();
        }

        public int GetTotalDay(DateTime from, DateTime to)
        {
            var totalDays = 1;
            for (var date = from; date < to; date = date.AddDays(1))
            {
                totalDays++;
            }
            return totalDays;
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            txtTotalDay.Text = GetTotalDay(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text)).ToString();

            //get holiday
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            var result = aSalary_Proccess_BLL.GetHoliday(OCODE, txtDateFrom.Text, txtDateTo.Text);
            if (result.Count > 0)
            {
                var objHoliday = result.First();
                txtHoliday.Text = objHoliday.Total_Other_Holiday.ToString();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewEMP_AT.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No processed salary in the list!')", true);
                    return;
                }

                List<HRM_PaySalary_Temp> aHRM_PaySalary_Temp = new List<HRM_PaySalary_Temp>();
                aHRM_PaySalary_Temp = aSalary_Proccess_BLL.GetSalaryTemp(((SessionUser)Session["SessionUser"]).OCode, Convert.ToDateTime(txtDateFrom.Text));

                foreach (HRM_PaySalary_Temp salary_temp in aHRM_PaySalary_Temp)
                {
                    HRM_Pay_Salary salaryPay = new HRM_Pay_Salary();
                    salaryPay.EmpId = salary_temp.EmpId;
                    salaryPay.EID = salary_temp.EID;
                    salaryPay.Worked_Day = salary_temp.Worked_Day;
                    salaryPay.Total_Day_Of_Month = salary_temp.Total_Day_Of_Month;
                    salaryPay.Over_Time = salary_temp.Over_Time;
                    salaryPay.OT_Compliance = salary_temp.OT_Compliance;
                    salaryPay.OT_Extra = salary_temp.OT_Extra;

                    salaryPay.Work_Holiday = salary_temp.Work_Holiday;
                    salaryPay.Other_Holiday = salary_temp.Other_Holiday;
                    salaryPay.Total_Leave = salary_temp.Total_Leave;
                    salaryPay.Salary_Month = salary_temp.Salary_Month;
                    salaryPay.Date_Processed = salary_temp.Date_Processed;
                    salaryPay.Total_Basic_New = salary_temp.Total_Basic_New;
                    salaryPay.Payable_Salary = salary_temp.Payable_Salary;

                    salaryPay.Total_Gross_Sal_Compliance = salary_temp.Total_Gross_Sal_Compliance;
                    salaryPay.Net_Payable_Compliance = salary_temp.Net_Payable_Compliance;

                    salaryPay.Total_Gross_Sal = salary_temp.Total_Gross_Sal;
                    salaryPay.Net_Payable = salary_temp.Net_Payable;
                    salaryPay.Total_Tax = salary_temp.Total_Tax;
                    salaryPay.Total_Bonus = salary_temp.Total_Bonus;
                    salaryPay.Total_LateDeduction_Cost = salary_temp.Total_LateDeduction_Cost;
                    salaryPay.Total_Leave_Cost = salary_temp.Total_Leave_Cost;
                    salaryPay.Total_Absent_Cost = salary_temp.Total_Absent_Cost;
                    salaryPay.Pay_Status = salary_temp.Pay_Status;
                    salaryPay.Edit_User = salary_temp.Edit_User;
                    salaryPay.Edit_Date = salary_temp.Edit_Date;
                    salaryPay.OCode = salary_temp.OCode;
                    salaryPay.OT_Rate = salary_temp.OT_Rate;

                    salaryPay.OT_Compliance_Amount = salary_temp.OT_Compliance_Amount;
                    salaryPay.OT_Extra_Amount = salary_temp.OT_Extra_Amount;
                    salaryPay.OT_Taka = salary_temp.OT_Taka;
                    
                    salaryPay.Attendance_Bonus = salary_temp.Attendance_Bonus;

                    salaryPay.Total_Deduction = salary_temp.Total_Deduction;
                    salaryPay.Total_Compliance_Deduction = salary_temp.Total_Compliance_Deduction;

                    salaryPay.P = salary_temp.P;
                    salaryPay.L = salary_temp.L;
                    salaryPay.SL = salary_temp.SL;
                    salaryPay.CL = salary_temp.CL;
                    salaryPay.ML = salary_temp.ML;
                    salaryPay.AL = salary_temp.AL;
                    salaryPay.LWP = salary_temp.LWP;
                    salaryPay.Absent_Day = salary_temp.Absent_Day;
                    salaryPay.Absent_Deduction = salary_temp.Absent_Deduction;
                    salaryPay.TotalDeductDay = salary_temp.TotalDeductDay;
                    salaryPay.Other_Deduction = salary_temp.Other_Deduction;
                    salaryPay.Salary_Punishment = salary_temp.Salary_Punishment;

                    salaryPay.Night_Bill = salary_temp.Night_Bill;
                    salaryPay.Holiday_Bill = salary_temp.Holiday_Bill;
                    salaryPay.Total_Benifit = salary_temp.Total_Benifit;

                    salaryPay.Stamp = salary_temp.Stamp;
                    salaryPay.AdvanceDeduction = salary_temp.AdvanceDeduction;

                    salaryPay.IsSalaryHeldup = salary_temp.IsSalaryHeldup;

                    //delete previous proccessed dated data
                    //List<HRM_Pay_Salary> paySalaryBydate = aSalary_Proccess_BLL.GetPaySalaryByDate_ByEID(Convert.ToDateTime(txtDateFrom.Text), salaryPay.EID);
                    //if (paySalaryBydate.Count > 0)
                    //{
                    aSalary_Proccess_BLL.DeletePaySalaryByEIDandMonth(salaryPay.EID, Convert.ToDateTime(salaryPay.Salary_Month));
                    //}

                    aSalary_Proccess_BLL.InsertPaySalary(salaryPay); // insert salary proccessed data from temp to original table

                    aSalary_Proccess_BLL.DeleteSalaryTemp(salary_temp.PaySalary_Temp_ID); //delete temp table data

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Salary processed successfully')", true);

                    //txtDateFrom.Text = "";
                    txtDateTo.Text = "";
                    ddlRegion.ClearSelection();
                    ddlOffice.ClearSelection();
                    txtWeekend.Text = "";
                    txtWeekend1.Text = "";
                    txtWeekend2.Text = "";
                    txtTotalDay.Text = "";
                    txtHoliday.Text = "";
                    lblTotalPayable.Text = "";

                    GridViewEMP_AT.DataSource = null;
                    GridViewEMP_AT.DataBind();
                }

                // create voucher to temp table

                //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                //string Company_Code = "CMP201507251";
                //string ModuleName = "Payroll";
                //string ModuleType = "Salary";
                //string VoucherType = "JOURNAL";

                //var row = aSalary_Proccess_BLL.GetTotalPayableByDate(Convert.ToDateTime(txtDateFrom.Text)).ToList();
                //if (row.Count > 0)
                //{
                //    var Total = row.First();
                //    aSalary_Proccess_BLL.Enter_VoucherDetailsForTotalSalary(OCODE, Company_Code, Edit_User, ModuleName, ModuleType, VoucherType, Convert.ToDecimal(Total.TotalPayable),"n/a");
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}