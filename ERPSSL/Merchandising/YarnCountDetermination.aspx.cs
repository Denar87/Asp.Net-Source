using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class YarnCountDetermination : System.Web.UI.Page
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();
        YarnCountDeterminationBLL aYarnCountDeterminationBLL = new YarnCountDeterminationBLL();
        decimal totalPrice = 0;

        decimal constructionFabrics = 0;
        int knitingCost = 0;
        int dryingCost = 0;
        decimal totalCost = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillFabricNature();
                    FillConstruction();
                    FillComposition();
                    //FillYarnCount();
                    //FillYarnCountType();
                    FillColor();

                    LoadDataInGrid();

                    LoadDeterminationDataForLastGrid();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //-------------------------------Use for Search---------------------------------------------------

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchConstruction(string prefixText, int count)
        {
            using (var _context = new ERPSSL_MerchandisingEntities())
            {
                var allClient = from m in _context.Inv_ProductGroup
                                where ((m.GroupName.Contains(prefixText)))
                                select m;
                List<String> clientList = new List<String>();
                foreach (var clientName in allClient)
                {
                    clientList.Add(clientName.GroupName);
                }
                return clientList;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchGSMWeight(string prefixText, int count)
        {
            using (var _context = new ERPSSL_MerchandisingEntities())
            {
                var allClient = from m in _context.LC_YarnDetermination
                                where ((m.GSM.Contains(prefixText)))
                                select m;
                List<String> clientList = new List<String>();
                foreach (var clientName in allClient)
                {
                    clientList.Add(clientName.GSM);
                }
                return clientList;
            }
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchComposition(string prefixText, int count)
        {
            using (var _context = new ERPSSL_MerchandisingEntities())
            {
                var allClient = from m in _context.LC_Composition
                                where ((m.Composition.Contains(prefixText)))
                                select m;
                List<String> clientList = new List<String>();
                foreach (var clientName in allClient)
                {
                    clientList.Add(clientName.Composition);
                }
                return clientList;
            }
        }


        //------------------Fill All DropDownList By Data-------------------------------------------------

        public void FillFabricNature()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_FabricNature> row = aYarnCountDeterminationBLL.GetAllfabNature(ocode);

                if (row != null)
                {
                    fabNatureDropDownList.DataSource = row.ToList();
                    fabNatureDropDownList.DataTextField = "FabricNature";
                    fabNatureDropDownList.DataValueField = "Id";
                    fabNatureDropDownList.DataBind();
                    fabNatureDropDownList.AppendDataBoundItems = false;
                    fabNatureDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillConstruction()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<Inv_ProductGroup> row = aYarnCountDeterminationBLL.GetAllConstructionType(ocode);

                if (row != null)
                {
                    constructionDropDownList.DataSource = row.ToList();
                    constructionDropDownList.DataTextField = "GroupName";
                    constructionDropDownList.DataValueField = "GroupId";
                    constructionDropDownList.DataBind();
                    constructionDropDownList.AppendDataBoundItems = false;
                    constructionDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillComposition()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Composition> row = aYarnCountDeterminationBLL.GetAllComposition();

                if (row != null)
                {
                    compositionDropDownList.DataSource = row.ToList();
                    compositionDropDownList.DataTextField = "Composition";
                    compositionDropDownList.DataValueField = "Id";
                    compositionDropDownList.DataBind();
                    compositionDropDownList.AppendDataBoundItems = false;
                    compositionDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillYarnCount()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Yarn_Count> row = aYarnCountDeterminationBLL.GetAllYarnCount();

                if (row != null)
                {
                    countDropDownList.DataSource = row.ToList();
                    countDropDownList.DataTextField = "Yarn_Count";
                    countDropDownList.DataValueField = "YarnCount_ID";
                    countDropDownList.DataBind();
                    countDropDownList.AppendDataBoundItems = false;
                    countDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillYarnCountType()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_YarnCountType> row = aYarnCountDeterminationBLL.GetAllYarnCountType();

                if (row != null)
                {
                    typeDropDownList.DataSource = row.ToList();
                    typeDropDownList.DataTextField = "YarnCountType";
                    typeDropDownList.DataValueField = "Id";
                    typeDropDownList.DataBind();
                    typeDropDownList.AppendDataBoundItems = false;
                    typeDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillColor()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Color> row = aYarnCountDeterminationBLL.GetAllColor();

                if (row != null)
                {
                    colorRangeDropDownList.DataSource = row.ToList();
                    colorRangeDropDownList.DataTextField = "ColorName";
                    colorRangeDropDownList.DataValueField = "ColorId";
                    colorRangeDropDownList.DataBind();
                    colorRangeDropDownList.AppendDataBoundItems = false;
                    colorRangeDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //--------------------------------------Add Functions Work Here----------------------------------------------------

        protected void addButton_Click(object sender, EventArgs e)
        {
            try
            {

                //Find The Product Id From Inv_Product Table

                int groupId = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());
                string productName = "Yarn";
                string brandName = countDropDownList.Text;
                string type = typeDropDownList.Text;
                int unitId = Convert.ToInt32(UMDropDownList.SelectedValue.ToString());

                int productId = aYarnCountDeterminationBLL.GetProductId(groupId, productName, brandName, type, unitId);

                if (productId != 0)
                {
                    if (addButton.Text == "Add")
                    {
                        LC_YarnDeterminationTemp aLC_YarnDeterminationTemp = new LC_YarnDeterminationTemp();

                        aLC_YarnDeterminationTemp.FebricNatureId = Convert.ToInt32(fabNatureDropDownList.SelectedValue.ToString());
                        aLC_YarnDeterminationTemp.ColorRangeId = Convert.ToInt32(colorRangeDropDownList.SelectedValue.ToString());
                        aLC_YarnDeterminationTemp.ConstructionId = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());
                        aLC_YarnDeterminationTemp.ProductId = productId;
                        aLC_YarnDeterminationTemp.GSM = gSMTextBox.Text;
                        aLC_YarnDeterminationTemp.CompositionId = Convert.ToInt32(compositionDropDownList.SelectedValue.ToString());
                        aLC_YarnDeterminationTemp.Percentage = percentageTextBox.Text;
                        aLC_YarnDeterminationTemp.Price = Convert.ToDecimal(priceTextBox.Text);
                        aLC_YarnDeterminationTemp.StichLength = txtStichLength.Text;
                        aLC_YarnDeterminationTemp.ProcessLoss = txtProcessLoss.Text;
                        aLC_YarnDeterminationTemp.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                        aLC_YarnDeterminationTemp.CreateDate = DateTime.Now;
                        aLC_YarnDeterminationTemp.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                        int result = aYarnCountDeterminationBLL.SaveData(aLC_YarnDeterminationTemp);

                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Save Successfully!!')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Save!!')", true);
                        }

                        fabNatureDropDownList.Enabled = false;
                        constructionDropDownList.Enabled = false;
                        colorRangeDropDownList.Enabled = false;
                        gSMTextBox.Enabled = false;


                    }
                    else if (addButton.Text == "Update")
                    {
                        LC_YarnDetermination aLC_YarnDetermination = new LC_YarnDetermination();

                        aLC_YarnDetermination.FebricNatureId = Convert.ToInt32(fabNatureDropDownList.SelectedValue.ToString());
                        aLC_YarnDetermination.ColorRangeId = Convert.ToInt32(colorRangeDropDownList.SelectedValue.ToString());
                        aLC_YarnDetermination.ConstructionId = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());
                        aLC_YarnDetermination.ProductId = productId;
                        aLC_YarnDetermination.GSM = gSMTextBox.Text;
                        aLC_YarnDetermination.CompositionId = Convert.ToInt32(compositionDropDownList.SelectedValue.ToString());
                        aLC_YarnDetermination.Percentage = percentageTextBox.Text;
                        aLC_YarnDetermination.Price = Convert.ToDecimal(priceTextBox.Text);
                        aLC_YarnDetermination.StichLength = txtStichLength.Text;
                        aLC_YarnDetermination.ProcessLoss = txtProcessLoss.Text;

                        aLC_YarnDetermination.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        aLC_YarnDetermination.EditDate = DateTime.Now;
                        aLC_YarnDetermination.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                        int yarnDeterminationId = Convert.ToInt32(yarnCountTypeIdHiddenField.Value);

                        int result = aYarnCountDeterminationBLL.UpdateData(aLC_YarnDetermination, yarnDeterminationId);

                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Update Successfully!!')", true);
                            return;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Update!!')", true); return;
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Product Id Not Found!!')", true);
                }

                



            }
            catch (Exception ex)
            {
                throw ex;
            }

            FillComposition();

            LoadDataInGrid();

            countDropDownList.DataSource = null;
            typeDropDownList.DataSource = null;
            UMDropDownList.DataSource = null;

            percentageTextBox.Text = "";
            priceTextBox.Text = "";
            txtStichLength.Text = "";
            txtProcessLoss.Text = "";
            

        }


        public void LoadDataInGrid()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            Guid userIdEccess = ((SessionUser)Session["SessionUser"]).UserId;

            List<YarnDeterminationRepo> dataList = aYarnCountDeterminationBLL.LoadDataForGrid(ocode, userIdEccess);



            foreach (YarnDeterminationRepo aYarnDeterminationRepo in dataList)
            {
                totalPrice = totalPrice + aYarnDeterminationRepo.Price;
            }

            if (dataList.Count > 0)
            {
                grdorder.DataSource = dataList.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }

            constructionFinishFebricTextBox.Text = Convert.ToString(totalPrice);
        }

        protected void imgbtnYarnCountDetEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblYarnDetId = (Label)grdorder.Rows[row.RowIndex].FindControl("lblYarnDetId");

            int entryId = Convert.ToInt32(lblYarnDetId.Text);

            YarnDeterminationRepo aYarnDeterminationRepo = new YarnDeterminationRepo();

            aYarnDeterminationRepo = aYarnCountDeterminationBLL.GetSingleData(entryId);

            yarnCountTypeIdHiddenField.Value = aYarnDeterminationRepo.YarnDeterminationId.ToString();
            fabNatureDropDownList.SelectedValue = aYarnDeterminationRepo.FebricNatureId.ToString();
            colorRangeDropDownList.SelectedValue = aYarnDeterminationRepo.ColorRangeId.ToString();
            constructionDropDownList.SelectedValue = aYarnDeterminationRepo.ConstructionId.ToString();

            gSMTextBox.Text = aYarnDeterminationRepo.GSM;
            compositionDropDownList.SelectedValue = aYarnDeterminationRepo.CompositionId.ToString();
            percentageTextBox.Text = aYarnDeterminationRepo.Percentage;
            countDropDownList.Items.Add(aYarnDeterminationRepo.YarnCount.ToString());
            typeDropDownList.Items.Add(aYarnDeterminationRepo.YarnCountType.ToString());
            UMDropDownList.Items.Add(aYarnDeterminationRepo.unitName.ToString());
            priceTextBox.Text = aYarnDeterminationRepo.Price.ToString("0.00");
            txtStichLength.Text = aYarnDeterminationRepo.StichLength;
            txtProcessLoss.Text = aYarnDeterminationRepo.ProcessLoss;

            addButton.Text = "Update";
        }

        protected void constructionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Load Data Into Grid View

            int fabNatureId = Convert.ToInt32(fabNatureDropDownList.SelectedValue.ToString());
            int colorRangeId = Convert.ToInt32(colorRangeDropDownList.SelectedValue.ToString());
            int constructionId = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());

            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            List<YarnDeterminationRepo> dataList = aYarnCountDeterminationBLL.LoadAllDataForGrid(ocode, fabNatureId, colorRangeId, constructionId);

            if (dataList.Count > 0)
            {
                grdorder.DataSource = dataList.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }


            int groupOfProduct = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());


            //Load Brand 

            List<string> brandList = aYarnCountDeterminationBLL.GetAllBrandByConstruction(groupOfProduct);

            if (brandList != null)
            {
                countDropDownList.DataSource = brandList.ToList();
                //fabNatureDropDownList.DataTextField = "FabricNature";
                //fabNatureDropDownList.DataValueField = "Id";
                countDropDownList.DataBind();
                countDropDownList.AppendDataBoundItems = false;
                countDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
            }

            LoadDataInGrid();


        }

        protected void countDropDownList_TextChanged(object sender, EventArgs e)
        {
            //Load type 
            int groupOfProduct = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());


            string brand = countDropDownList.Text; 

            List<string> typeList = aYarnCountDeterminationBLL.GetAllstyleSizeByConstruction(groupOfProduct, brand);

            if (typeList != null)
            {
                typeDropDownList.DataSource = typeList.ToList();
                //fabNatureDropDownList.DataTextField = "FabricNature";
                //fabNatureDropDownList.DataValueField = "Id";
                typeDropDownList.DataBind();
                typeDropDownList.AppendDataBoundItems = false;
                typeDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
            }

            LoadDataInGrid();
        }

    

        protected void typeDropDownList_TextChanged(object sender, EventArgs e)
        {
            //Load Unit 


            int groupOfProduct = Convert.ToInt32(constructionDropDownList.SelectedValue.ToString());


            string brand = countDropDownList.Text;


            string styleAndSize = typeDropDownList.Text;


            List<Inv_Unit> unitList = aYarnCountDeterminationBLL.GetAllUnitByConstruction(groupOfProduct, brand, styleAndSize);

            if (unitList != null)
            {
                UMDropDownList.DataSource = unitList.ToList();
                UMDropDownList.DataTextField = "UnitName";
                UMDropDownList.DataValueField = "UnitId";
                UMDropDownList.DataBind();
                UMDropDownList.AppendDataBoundItems = false;
                UMDropDownList.Items.Insert(0, new ListItem("---Select---", "0"));
            }

            LoadDataInGrid();
        }

        protected void dryingCostTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                totalTextBox.Text = Convert.ToString(Convert.ToDecimal(constructionFinishFebricTextBox.Text) + Convert.ToDecimal(kinitingCostTextBox.Text) + Convert.ToDecimal(dryingCostTextBox.Text));
            }
            catch
            {
                totalTextBox.Text = "";
            }
        }

        protected void kinitingCostTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                totalTextBox.Text = Convert.ToString(Convert.ToDecimal(constructionFinishFebricTextBox.Text) + Convert.ToDecimal(kinitingCostTextBox.Text) + Convert.ToDecimal(dryingCostTextBox.Text));
            }
            catch
            {
                totalTextBox.Text = "";
            }
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {

            int uniqueId = GenerateUniqueId();



            string ocode = ((SessionUser)Session["SessionUser"]).OCode;


            Guid userIdEccess = ((SessionUser)Session["SessionUser"]).UserId;


            List<YarnDeterminationRepo> dataList = aYarnCountDeterminationBLL.LoadDataForGrid(ocode, userIdEccess);

            try
            {
                foreach (YarnDeterminationRepo aYarnDeterminationRepo in dataList)
                {
                    LC_YarnDetermination aLC_YarnDetermination = new LC_YarnDetermination();

                    aLC_YarnDetermination.FebricNatureId = aYarnDeterminationRepo.FebricNatureId;
                    aLC_YarnDetermination.ColorRangeId = aYarnDeterminationRepo.ColorRangeId;
                    aLC_YarnDetermination.ConstructionId = aYarnDeterminationRepo.ConstructionId;
                    aLC_YarnDetermination.ProductId = aYarnDeterminationRepo.ProductId;
                    aLC_YarnDetermination.GSM = aYarnDeterminationRepo.GSM;
                    aLC_YarnDetermination.CompositionId = aYarnDeterminationRepo.CompositionId;
                    aLC_YarnDetermination.Percentage = aYarnDeterminationRepo.Percentage;
                    aLC_YarnDetermination.Price = aYarnDeterminationRepo.Price;
                    aLC_YarnDetermination.StichLength = aYarnDeterminationRepo.StichLength;
                    aLC_YarnDetermination.ProcessLoss = aYarnDeterminationRepo.ProcessLoss;
                    aLC_YarnDetermination.UniqueId = uniqueId;
                    aLC_YarnDetermination.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_YarnDetermination.CreateDate = DateTime.Now;
                    aLC_YarnDetermination.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    aYarnCountDeterminationBLL.SaveDataOriginal(aLC_YarnDetermination);

                }

                foreach (YarnDeterminationRepo aYarnDeterminationRepo in dataList)
                {
                    int tempEntryId = aYarnDeterminationRepo.YarnDeterminationId;

                    aYarnCountDeterminationBLL.DeleteDataFromTemp(tempEntryId);

                }



                LC_DeterminationCost aLC_DeterminationCost = new LC_DeterminationCost();

                aLC_DeterminationCost.ConstructionFinishFebric = Convert.ToDecimal(constructionFinishFebricTextBox.Text);
                aLC_DeterminationCost.KnitingCost = Convert.ToInt32(kinitingCostTextBox.Text);
                aLC_DeterminationCost.DryingCostOption = dryingCostDropDownList.Text;
                aLC_DeterminationCost.DryingCost = Convert.ToInt32(dryingCostTextBox.Text);
                aLC_DeterminationCost.TotalCost = Convert.ToDecimal(totalTextBox.Text);
                aLC_DeterminationCost.UniqueId = uniqueId;
                aLC_DeterminationCost.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                aLC_DeterminationCost.CreateDate = DateTime.Now;
                aLC_DeterminationCost.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                int result = aYarnCountDeterminationBLL.SaveToDeterminationCost(aLC_DeterminationCost);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Save Successfully!!')", true);
                  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Not Save!!')", true); return;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            fabNatureDropDownList.Enabled = true;
            constructionDropDownList.Enabled = true;
            colorRangeDropDownList.Enabled = true;
            gSMTextBox.Enabled = true;

            //countDropDownList.Text = "";
            //typeDropDownList.Text = "";
            //UMDropDownList.Text = "";

            FillFabricNature();
            FillConstruction();
            FillComposition();
            //FillYarnCount();
            //FillYarnCountType();
            FillColor();
            gSMTextBox.Text = "";
            percentageTextBox.Text = "";
            priceTextBox.Text = "";
            txtStichLength.Text = "";
            txtProcessLoss.Text = "";

            kinitingCostTextBox.Text = "";
            dryingCostDropDownList.Text = "";
            dryingCostTextBox.Text = "";
            totalTextBox.Text = "";

            LoadDataInGrid();
            LoadDeterminationDataForLastGrid();
          
        }

        public int GenerateUniqueId()
        {
            int randomNumber = 0;
            
            Random random = new Random();
            
            for (int i = 0; i < 5; i++)
            {

                randomNumber = Convert.ToInt32(Convert.ToString(random.Next(999, 10000))); // to specify range for random number
            }

            int uniqueId = 0;

            uniqueId = randomNumber + DateTime.Now.Year+ DateTime.Now.Month+DateTime.Now.Day +DateTime.Now.Hour+DateTime.Now.Minute+DateTime.Now.Second + Convert.ToInt32(fabNatureDropDownList.SelectedValue.ToString()) + Convert.ToInt32(colorRangeDropDownList.SelectedValue.ToString()) + Convert.ToInt32(gSMTextBox.Text);

            return uniqueId;
        }

        public void LoadDeterminationDataForLastGrid()
        {

            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;


            List<YarnDeterminationShowRepo> aYarnDeterminationShowRepo = aYarnCountDeterminationBLL.GetAllInformationOfGridView(OCODE);

            YarnDeterminationGridView.DataSource = aYarnDeterminationShowRepo;
            YarnDeterminationGridView.DataBind();


            Guid createUser = ((SessionUser)Session["SessionUser"]).UserId;

        }

        protected void imgbtnYarnCountDetEdit2_Click(object sender, ImageClickEventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            Guid createUser = ((SessionUser)Session["SessionUser"]).UserId;

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblUniqueId = (Label)YarnDeterminationGridView.Rows[row.RowIndex].FindControl("lblUniqueId");

            int uniqueId = Convert.ToInt32(lblUniqueId.Text);


            List<LC_DeterminationCost> aDeterminationCostList = new List<LC_DeterminationCost>();
            aDeterminationCostList = aYarnCountDeterminationBLL.GetAllCost(OCODE, createUser,uniqueId);

            foreach (LC_DeterminationCost aLC_DeterminationCost in aDeterminationCostList)
            {
                constructionFabrics = constructionFabrics + Convert.ToDecimal(aLC_DeterminationCost.ConstructionFinishFebric);
                knitingCost = knitingCost + Convert.ToInt32(aLC_DeterminationCost.KnitingCost);
                dryingCost = dryingCost + Convert.ToInt32(aLC_DeterminationCost.DryingCost);
                totalCost = totalCost + Convert.ToDecimal(aLC_DeterminationCost.TotalCost);
                dryingCostDropDownList.Text = aLC_DeterminationCost.DryingCostOption.ToString();
            }

            constructionFinishFebricTextBox.Text = constructionFabrics.ToString("0.00");
            kinitingCostTextBox.Text = knitingCost.ToString();
            dryingCostTextBox.Text = dryingCost.ToString();
            totalTextBox.Text = totalCost.ToString("0.00");





      
            List<YarnDeterminationRepo> dataList = aYarnCountDeterminationBLL.LoadDataForGridFromConfirm(OCODE, createUser, uniqueId);



            foreach (YarnDeterminationRepo aYarnDeterminationRepo in dataList)
            {
                totalPrice = totalPrice + aYarnDeterminationRepo.Price;
            }

            if (dataList.Count > 0)
            {
                grdorder.DataSource = dataList.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }

            constructionFinishFebricTextBox.Text = Convert.ToString(totalPrice);






        }

        protected void constructionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            Guid createUser = ((SessionUser)Session["SessionUser"]).UserId;

            string constructionName = constructionSearchTextBox.Text;

            Inv_ProductGroup aInv_ProductGroup = new Inv_ProductGroup();

            aInv_ProductGroup = aYarnCountDeterminationBLL.GetConstructionId(constructionName);

            int constructionId = aInv_ProductGroup.GroupId;

            List<YarnDeterminationShowRepo> aYarnDeterminationShowRepo = aYarnCountDeterminationBLL.GetAllInformationOfGridViewByConstruction(OCODE, constructionId, createUser);

            YarnDeterminationGridView.DataSource = aYarnDeterminationShowRepo;
            YarnDeterminationGridView.DataBind();
        }

        protected void gsmWeightSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            Guid createUser = ((SessionUser)Session["SessionUser"]).UserId;

            string GSMNo = gsmWeightSearchTextBox.Text;
           
            List<YarnDeterminationShowRepo> aYarnDeterminationShowRepo = aYarnCountDeterminationBLL.GetAllInformationOfGridViewByGSM(OCODE, GSMNo, createUser);

            YarnDeterminationGridView.DataSource = aYarnDeterminationShowRepo;
            YarnDeterminationGridView.DataBind();
        }

        protected void compostionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            //[LC_YarnCostShowByComposition]

            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            Guid createUser = ((SessionUser)Session["SessionUser"]).UserId;

            string compositionName = compostionSearchTextBox.Text;

            LC_Composition aLC_Composition = new LC_Composition();

            aLC_Composition = aYarnCountDeterminationBLL.GetCompositionId(compositionName);

            int compositionId = aLC_Composition.Id;

            List<YarnDeterminationShowRepo> aYarnDeterminationShowRepo = aYarnCountDeterminationBLL.GetAllInformationOfGridViewByComposition(OCODE, compositionId, createUser);

            YarnDeterminationGridView.DataSource = aYarnDeterminationShowRepo;
            YarnDeterminationGridView.DataBind();

        }

    }
}