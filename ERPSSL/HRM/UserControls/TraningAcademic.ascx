<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TraningAcademic.ascx.cs"
    Inherits="ERPSSL.HRM.UserControls.TraningAcademic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
        <div>
            <div class="tab-header">
                Academic Information
    <asp:Button ID="btnAcademic" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnAcademic_Click" />
            </div>
            <asp:Panel ID="Panel2" runat="server" Style="display: none" CssClass="modalPopupFreight">



                <div>
                    <asp:Label ID="lblAcademicMessage" runat="server" Font-Bold="true"></asp:Label>
                    <link href="../../css/Modal.css" rel="stylesheet" />
                    <div class="modal-dialog">
                         <asp:Panel ID="Panel4" runat="server">
                        <div class="popuHeader">
                           
                                <asp:LinkButton ID="LinkButton2" runat="server" >
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>                       
                            <h4 id="H1" >Academic Information</h4>
                        </div>
                                  </asp:Panel>
                        <div id="Div3">
                            <div class="row tab-data" style="padding-top:7px;">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Education:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>

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
                                        </p>
                                    </div>
                                    <asp:HiddenField ID="hidAcademicId" runat="server" />
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Major:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxMajor" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Institute:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxInstitute" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtbxInstitute"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Institute"
                                            ValidationGroup="GroupAcademicInfo"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Passing Year:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxPassingYear" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxPassingYear"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Passing Year"
                                            ValidationGroup="GroupAcademicInfo"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Duration:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxDuration" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Result:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxResult" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxResult"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Result"
                                            ValidationGroup="GroupAcademicInfo"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="submission">
                        <%--<asp:Button ID="btnAcademicReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                        <div class="col-md-12">
                            <asp:Button ID="btnSaveandUpdate" runat="server" ValidationGroup="GroupAcademicInfo"
                                Text="Submit" Width="80px" CssClass="btn btn-info pull-right" OnClick="btnSaveandUpdate_Click" Style="margin-right: 8px;" />
                        </div>
                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton3"
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel4" DynamicServicePath="" Enabled="True" />

            <div id="Div4">
                <div class="row">
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
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAcademicinfoedit" runat="server" Text="Edit" class="btn btn-primary"
                                            OnClick="btnAcademicinfoedit_Ckick" />
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <PagerSettings PageButtonCount="5" />
                            <RowStyle CssClass="Grid_RowStyle" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="tab-header">
                Driving Licence Info
    <asp:Button ID="btnTrt" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnTrt_Click" />
            </div>
            <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <div>
                    <asp:Label ID="lblDrivingLicenMessage" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                         <asp:Panel ID="Panel3" runat="server">
                       <div class="popuHeader">                        
                                <asp:LinkButton ID="CancelButton" runat="server">
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>                           
                            <h4 id="myModalLabel" >Driving Licence Info</h4>
                        </div>
                              </asp:Panel>
                        <div id="Div2">
                            <div class="row tab-data" style="padding-top:7px">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Licence No:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxLiceNo" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxLiceNo"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input License No"
                                            ValidationGroup="GroupLicense"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:HiddenField ID="hidDivrIngLicenceId" runat="server" />
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Type:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:DropDownList ID="drpdwnDriveType" Class="form-control" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                                <asp:ListItem>Light</asp:ListItem>
                                                <asp:ListItem>Motor Cycle</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="GroupLicense"
                                            runat="server" ControlToValidate="drpdwnDriveType" ErrorMessage="Select Type"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Issued Date/Renewal Date :</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxIssuedDate" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxIssuedDate"
                                            PopupButtonID="txtbxIssuedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Experired Date :</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxDexperiredDate" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxDexperiredDate"
                                            PopupButtonID="txtbxDexperiredDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>lssuing Authority:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxLocation" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnDrivingSumbiandUpdate" runat="server" ValidationGroup="GroupLicense"
                                    Text="Submit" Width="80px" CssClass="btn btn-info pull-right" OnClick="btnDrivingSumbiandUpdate_Click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" DynamicServicePath="" Enabled="True" />

            <div id="Div8">
                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <asp:GridView ID="gridViewDrivingLicenceInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                            BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDrivingLicenceId" runat="server" Text='<%# Eval("DrivingId")%>' />
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
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDrivingLicence" runat="server" Text="Edit" class="btn btn-primary"
                                            OnClick="btnDrivingLicence_Click" />
                                        <footerstyle cssclass="Grid_Footer" />
                                        <headerstyle cssclass="Grid_Header" verticalalign="Middle" />
                                        <itemstyle cssclass="Grid_Border" horizontalalign="Left" width="50%" />
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <PagerSettings PageButtonCount="5" />
                            <RowStyle CssClass="Grid_RowStyle" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="tab-header">
                Traning Information
    <asp:Button ID="btnTraning" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnTraning_Click" />
            </div>
            <asp:Panel ID="Panel5" runat="server" Style="display: none" CssClass="modalPopupFreight">

                <div>
                    <asp:Label ID="lblTraniningInfoMess" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                        <asp:Panel ID="Panel6" runat="server">
                       <div class="popuHeader">                         
                                <asp:LinkButton ID="LinkButton4" runat="server">
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>                         
                            <h4 id="H2">Training Information</h4>
                        </div>
                               </asp:Panel>
                        <div id="Div5">
                            <div class="row tab-data" style="padding-top:7px">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Title:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxTile" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbxTile"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Title"
                                            ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:HiddenField ID="hidtraningId" runat="server" />
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Topics:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxTopices" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbxTopices"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Topics"
                                            ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Institute:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxTInstitute" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbxTInstitute"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Institute"
                                            ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Location:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxTLocation" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Training Year:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxTTraningYear" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxTTraningYear"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Traning Year"
                                            ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Duration:</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxTDuration" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtbxTDuration"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Duration"
                                            ValidationGroup="GroupTraning"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="Button4" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnTraingUpdateAndSumit" runat="server" ValidationGroup="GroupTraning" Text="Submit" Width="80px"
                                    CssClass="btn btn-info pull-right" OnClick="btnTraingUpdateAndSumit_Click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton5"
                PopupControlID="Panel5" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel6" DynamicServicePath="" Enabled="True" />

            <div id="Div6">
                <div class="row">
                    <div class="col-md-12">
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
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnTraining" runat="server" Text="Edit" class="btn btn-primary" OnClick="btnTrainingEdit_Click" />
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <PagerSettings PageButtonCount="5" />
                            <RowStyle CssClass="Grid_RowStyle" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
