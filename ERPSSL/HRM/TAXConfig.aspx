<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="TAXConfig.aspx.cs" Inherits="ERPSSL.HRM.TAXConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>TAX Config
            </div>
        </div>
        <asp:Panel ID="pnl_result" runat="server" Visible="false">
            <div class="result">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <%-- <h2>
            Employee Setup</h2>--%>

        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
            childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TAX Liability Type" ID="TabPanel1"
                OnDemandMode="None">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                               
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>TAX Liability Type
                                            </div>
                                        </div>
                                           <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <br />
                <div class="col-md-5">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                TAX Liability Type
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxTaxLiablityType" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hidTaxId" runat="server" />
                            </div>
                        </div>
                    </div>
                    <br />
                
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                            </div>
                            <div class="col-md-7">
                                <asp:Button ID="btnTaxConfig" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="btnTaxConfig_Clcik"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <asp:GridView ID="grdTaxType" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="5" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate  >
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTaxType" runat="server" Text='<%# Eval("TAXTypeAutoID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Type" HeaderText="TAX Liability Type">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnTypeEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnTypeEdit_Click"
                                       />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <RowStyle CssClass="Grid_RowStyle" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                </div>
            </div>
        </div>

                                        
                                    
                                    
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            
                        
            
            <ajaxToolkit:TabPanel runat="server" HeaderText="TAX Liability Config." ID="TabPanel6" OnDemandMode="None">
                <ContentTemplate>
                    <%--<imageUploadControl:imageupload ID="imageUpload" runat="server" />--%>
                     <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                    <div class="row">
                       
                        <div class="col-md-12">
                        
                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>TAX Liability Config
                                    </div>
                                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-md-3">
                                         <div class="col-md-9">
                                TAX Liability Type
                            </div>
                            <div class="col-md-12">
                                <asp:DropDownList ID="drptaxLiablityType" runat="server" class="form-control"></asp:DropDownList>
                                <asp:HiddenField ID="hidConfigId" runat="server" />
                            </div>

                                        </div>
                                     <div class="col-md-3">
                                         <div class="col-md-9">
                               Income From
                            </div>
                            <div class="col-md-12">
                                 <asp:TextBox ID="txtbxIncomeFrom" runat="server" class="form-control"></asp:TextBox>
                            </div>

                                        </div>

                                     <div class="col-md-3">
                                         <div class="col-md-5">
                               Income To
                            </div>
                            <div class="col-md-12">
                                 <asp:TextBox ID="txtbxIncomeTo" runat="server" class="form-control"></asp:TextBox>
                            </div>

                                        </div>

                                       <div class="col-md-3">
                                            <div class="col-md-5">
                               % Of TAX
                            </div>
                            <div class="col-md-12">
                                 <asp:TextBox ID="txtbxOfTax" runat="server" class="form-control"></asp:TextBox>
                            </div>
                                         
                                           <%--<asp:Button ID="btnTAXLiabilityConfig" runat="server" Text="Submit" class="btn btn-info pull-left" OnClick="btnTAXLiabilityConfig_click"/>--%>
                                       
                                            </div>

                                   

                                </div>
                                <div class="row">
                                      <div class="col-md-10">
                                          </div>
                                    <div class="col-md-2" style="padding-left:60px;">
                                        <br />
                                        <asp:Button ID="btnTAXLiabilityConfig" runat="server" Text="Submit" class="btn btn-info pull-left" OnClick="btnTAXLiabilityConfig_click"/>
                                       
                                          </div>
                                </div>
                                 <div class="row">
                                     <br />
                                      <div class="col-md-12">
                                          <asp:GridView ID="grdviewTaxLiabilityTypes" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="5" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate  >
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTaxLiabiltyConfiID" runat="server" Text='<%# Eval("taxLiabilityconfiID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Type" HeaderText="Type">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                             <asp:BoundField DataField="IncomeFrom" HeaderText="Income From">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                               <asp:BoundField DataField="IncomeTo" HeaderText="Income To">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                             <asp:BoundField DataField="OFtax" HeaderText="% Of Tax">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnTaxLiabilityEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnTaxLiabilityEdit_Click"
                                       />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <RowStyle CssClass="Grid_RowStyle" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                                          </div>
                                   
                                </div>

                            </fieldset>


                        </div>
                    </div>
                             </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel runat="server" HeaderText="TAX/PF Applicable" ID="TabPanel2" OnDemandMode="None">
                <ContentTemplate>
                    <%--<imageUploadControl:imageupload ID="imageUpload" runat="server" />--%>
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                    <div class="row">
                       
                        <div class="col-md-12">
                        
                    
                              <%--  <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>TAX/PF Applicable
                                    </div>
                                </div>--%>
                               
                                <div class="col-md-12">
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0px;"><span style="background: #fff">Select for Search</span></legend>
                         
                          
                            <div class="col-md-4" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Region
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Region
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <%--<div class="col-md-6">
                                    <div class="row">
                                        <h5 style="padding-left: 0px;">Section
                                        </h5>
                                        <div class="col-md-12" style="padding-left: 0px;">
                                            <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                                runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>--%>

                            <div class="col-md-4" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Office
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Office
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <%--<div class="col-md-6">
                                    <div class="row">
                                        <h5 style="padding-left: 0px;">Sub-Section
                                        </h5>
                                        <div class="col-md-12" style="padding-left: 0px;">
                                            <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                            </asp:DropDownList>
                                           
                                        </div>
                                    </div>
                                </div>--%>

                            <div class="col-md-4" style="padding-left: 0px;">

                                <div class="row">
                                    <%-- <h5 style="padding-left: 0px;">Department
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Department
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" 
                                            runat="server" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                                           

                        
                                <div class="col-md-4" style="padding:0px;">
                                    <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Section
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Section
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    </div>
                                <div class="col-md-4">

                                    <div class="row">
                                    <%-- <h5 style="padding-left: 0px;">Sub-Section
                                    </h5>--%>
                                    <div class="col-md-3" style="padding: 0px;">
                                        Sub-Section
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSubSections"  CssClass="form-control"
                                            runat="server" >
                                        </asp:DropDownList>

                                    </div>

                                </div>
                                </div>
                            <div class="col-md-4">

                                    <div class="row">
                                    <%-- <h5 style="padding-left: 0px;">Sub-Section
                                    </h5>--%>
                                    <div class="col-md-3" style="padding: 0px;">
                                        E-ID
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px;">
                                       <asp:TextBox ID="txtbxEid" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>

                                </div>
                                </div>
                            <div class="col-md-12" style="padding-top:16px">
                                 <asp:Button ID="btnProcess" runat="server" Text="Process"  Width="80px" CssClass="btn btn-info" OnClick="btnProcess_Click" />
                                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm"  Width="80px" CssClass="btn btn-primary" OnClick="btn_Confirm_Clcik" />

                            </div>
                        
                            
                            
                                        
                                
                                <br />
                       
                    </div>
                                   

                    


                </div>
<div class="col-md-12">

                        <br />
                        <asp:GridView ID="grdview" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" BackColor="White" BorderColor="#336666"
                            BorderStyle="Solid" BorderWidth="1px" AllowPaging="false" >
                            <Columns>
                                <%--<asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>


                                <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                <asp:TemplateField Visible="False" HeaderText="EID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="EID" HeaderText="E-ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                <asp:BoundField DataField="EmployeeFullName" HeaderText="Employee Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DEG_NAME" HeaderText="Designation">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                  <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerTAXLevelCheckBox" AutoPostBack="true" Text="TAX" OnCheckedChanged="headerTAXLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelTAXCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerPFLevelCheckBox" AutoPostBack="true" Text="PF" OnCheckedChanged="headerPFLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelPFCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                 <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerMaleLevelCheckBox" AutoPostBack="true" Text="Male" OnCheckedChanged="headerMaleLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelMaleCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                 <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerFeMaleLevelCheckBox" AutoPostBack="true" Text="Female" OnCheckedChanged="headerFeMaleLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelFeMaleCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                   <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headeSeniorCitizenLevelCheckBox" AutoPostBack="true" Text="Senior Citizen" OnCheckedChanged="headerSeniorCitizenLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelSeniorCitizenCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                     <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headeDisabledLevelCheckBox" AutoPostBack="true" Text="Disabled" OnCheckedChanged="headeDisabledLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelDisabledCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headeDisabledFreedomFeighterLevelCheckBox" AutoPostBack="true" Text="Disabled freedom Fighter" OnCheckedChanged="headeDisabledFreedomFeihterLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelFreedomFeighterCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                              


                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                Font-Bold="True" ForeColor="White" />
                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>


                    
</div>
                            </fieldset>


                        </div>
                    </div>
                             </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>


        </ajaxToolkit:TabContainer>
    </div>

    <%--</ContentTemplate>--%>

        <<%--Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnimageUpload"/>
        </Triggers>
    </asp:UpdatePanel>--%>
    <script>

        function func(result) {
            if (result === 'Data Save successfully') {
                toastr.success(result);

            }           

            else if (result === 'Data Update successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }
        </script>
</asp:Content>
