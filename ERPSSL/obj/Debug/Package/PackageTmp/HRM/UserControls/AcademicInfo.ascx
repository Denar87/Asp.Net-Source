<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcademicInfo.ascx.cs"
    Inherits="ERPSSL.HRM.UserControls.AcademicInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="row">
    <div class="col-md-12 bg-success">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div class="col-md-12">
        <fieldset>
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Academic Information
                </div>
            </div>
            <%--            <legend>Academic Information</legend>--%>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Education<%--<span style="color: #f00;">*</span>--%>

                        </div>
                        <div class="col-md-7">
                           <%-- <asp:DropDownList ID="ddlEducation" Class="form-control" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                <asp:ListItem>M.Sc.</asp:ListItem>
                                <asp:ListItem>B.Sc.</asp:ListItem>
                                <asp:ListItem>H.S.C</asp:ListItem>
                                <asp:ListItem>S.S.C</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ValidationGroup="GroupAcademicInfo"
                                runat="server" ControlToValidate="ddlEducation" ErrorMessage="Select Education"
                                InitialValue="0"></asp:RequiredFieldValidator>--%>
                              <asp:DropDownList ID="ddlEducation" Class="form-control" runat="server">
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>
         
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Major
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtMajor" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
              
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Institute<%--<span style="color: #f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtInstituateName" Class="form-control" runat="server"></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtInstituateName"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Institute"
                                ValidationGroup="GroupAcademicInfo"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                
            </div>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Passing Year<%--<span style="color: #f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtPassingYear" Class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassingYear"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Passing Year"
                                ValidationGroup="GroupAcademicInfo"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
             
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Duration
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtDuration" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
              
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Result<%--<span style="color: #f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxResult" Class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxResult"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Result"
                                ValidationGroup="GroupAcademicInfo"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="row">                  
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <asp:HiddenField ID="hdfAcademicInfo_ID" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnSaveAcademicInfo" runat="server" 
                                Text="Save" class="btn btn-info pull-right pull-right pull-right" OnClick="btnSaveAcademicInfo_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <br />           
                <asp:GridView ID="grdAcademicInfo" runat="server" Width="100%" DataKeyNames="AcademicId"
                    AutoGenerateColumns="False" AllowSorting="True" CellPadding="5"
                    BorderColor="#99CCFF" BorderStyle="Solid" CssClass="Grid_Border"
                    ForeColor="#339933">
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="academicId" runat="server" Text='<%# Eval("AcademicId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EDUCATION">
                            <ItemTemplate>
                                <asp:Label ID="lblEducation" runat="server" Text='<%# Bind("LevelOfEducation") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MAJOR">
                            <ItemTemplate>
                                <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Major") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="INSTITUTE">
                            <ItemTemplate>
                                <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("InstituteName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PASSED">
                            <ItemTemplate>
                                <asp:Label ID="lblPassingYear" runat="server" Text='<%# Bind("PassingYear") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DURATION">
                            <ItemTemplate>
                                <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RESULT">
                            <ItemTemplate>
                                <asp:Label ID="lblResult" runat="server" Text='<%# Bind("Result") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnAcademicinfoDelete" runat="server" Text="Delete" class="btn btn-primary"
                                    OnClick="btnAcademicinfoDelete_Click" />
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <PagerSettings PageButtonCount="5" />
                    <RowStyle CssClass="Grid_RowStyle" />
                </asp:GridView>
            </div>
        </fieldset>
    
       
        <fieldset>
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Training Information
                </div>
            </div>
            <%-- <legend>Training Information</legend>--%>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Title
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTrainingTitle" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTrainingTitle"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Title"
                                ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Topics
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTrainingTopics" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTrainingTopics"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Topics"
                                ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
         
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Institute
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTrainingInstituate" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTrainingInstituate"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Institute"
                                ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Location
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTrainingLocation" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
           
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Training year
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTrainingYear" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTrainingYear"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Traning Year"
                                ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Duration
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTrainingDuration" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTrainingDuration"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Duration"
                                ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <asp:HiddenField ID="hdfTrainingId" runat="server" />
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnSaveTrainingInfo" runat="server" ValidationGroup="GroupTraning"
                                Text="Save" class="btn btn-info pull-right pull-right" OnClick="btnSaveTrainingInfo_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <br />
                <br />
                <asp:GridView ID="grdiviewTrainings" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                    BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lbltrainingId" runat="server" Text='<%# Eval("TrainingId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Traning Title">
                            <ItemTemplate>
                                <asp:Label ID="lblTraningTitle" runat="server" Text='<%# Bind("TraningTitle") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Topics ">
                            <ItemTemplate>
                                <asp:Label ID="lblTopics" runat="server" Text='<%# Bind("TraningTopicsCovered") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="INSTITUTE">
                            <ItemTemplate>
                                <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Institue") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duration">
                            <ItemTemplate>
                                <asp:Label ID="lblDurationDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Traning Year">
                            <ItemTemplate>
                                <asp:Label ID="lblTraningYear" runat="server" Text='<%# Bind("TraningYear") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnAcademicinfoDelete" runat="server" Text="Delete" class="btn btn-primary"
                                    OnClick="btnTraningDelete_Click" />
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <PagerSettings PageButtonCount="5" />
                    <RowStyle CssClass="Grid_RowStyle" />
                </asp:GridView>
            </div>
        </fieldset>
         <fieldset>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblDrivingMessage" runat="server"></asp:Label>
            </div>
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Driving License Info
                </div>
            </div>
            <%--            <legend>Academic Information</legend>--%>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            License No
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxLicenNo" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxLicenNo"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input License No"
                                ValidationGroup="GroupLicense"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
             
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Type
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="drpdwnDriveType" Class="form-control" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                <asp:ListItem>Light</asp:ListItem>
                                <asp:ListItem>Motor Cycle</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                            </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="drpdwnDriveType"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Type"
                                                    ValidationGroup="GroupLicense"></asp:RequiredFieldValidator>
                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="GroupLicense"
                                runat="server" ControlToValidate="drpdwnDriveType" ErrorMessage="Select Type"
                                InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
             
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Issued Date/Renewal Date
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxIssUedDate" Class="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxIssUedDate"
                                PopupButtonID="txtbxIssUedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                Enabled="True" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Experired Date
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxExperiredDate" Class="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxExperiredDate"
                                PopupButtonID="txtbxExperiredDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                Enabled="True" />
                        </div>
                    </div>
                </div>
              
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Issuing Authority
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxLocation" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
             
                <div class="row">
                    <br />
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnDrivingLicence" ValidationGroup="GroupLicense" runat="server"
                                Text="Save" class="btn btn-info pull-right pull-right" OnClick="btnDrivingLicence_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <br />
                <br />
                <asp:GridView ID="gridViewDrivingLicenceInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                    BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblDrivingId" runat="server" Text='<%# Eval("DrivingId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Licence No">
                            <ItemTemplate>
                                <asp:Label ID="lblLicenNo" runat="server" Text='<%# Bind("LicenceNo") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type ">
                            <ItemTemplate>
                                <asp:Label ID="lblTopics" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Issued Date">
                            <ItemTemplate>
                                <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("IssuedDate") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Experired Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDurationDuration" runat="server" Text='<%# Bind("ExperiredDate") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                                <asp:Label ID="lblTraningYear" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteDrivingLicence" runat="server" Text="Delete" class="btn btn-primary"
                                    OnClick="btnDeleteDrivingLicence_Click" />
                            </ItemTemplate>
                            <FooterStyle CssClass="Grid_Footer" />
                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <PagerSettings PageButtonCount="5" />
                    <RowStyle CssClass="Grid_RowStyle" />
                </asp:GridView>
            </div>
        </fieldset>
        <br />
    </div>
</div>
