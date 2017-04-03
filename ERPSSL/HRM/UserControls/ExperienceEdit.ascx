<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExperienceEdit.ascx.cs"
    Inherits="ERPSSL.HRM.UserControls.ExperienceEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">
    <ContentTemplate>
        <div>
            <div class="tab-header">
                Experience Detail
    <asp:Button ID="btnedit" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnEdit_Click" />
            </div>
            <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <%-- <h2>
                    Grade Info (<asp:Label ID="lblID" runat="server"></asp:Label>)</h2>--%>
                <div>
                    <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                    <link href="../../css/Modal.css" rel="stylesheet" />
                    <div class="modal-dialog">
                         <asp:Panel ID="Panel3" runat="server">
                        <div class="popuHeader">                         
                                <asp:LinkButton ID="CancelButton" runat="server">
                                  <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>                       
                            <h4 id="myModalLabel" >Experience Details</h4>
                        </div>
                                  </asp:Panel>
                        <div id="Div2">
                            <div class="row tab-data" style="padding-top:7px">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Company Name:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxCompanyName" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtbxCompanyName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Company Name"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                    <asp:HiddenField ID="ExperienceId" runat="server" />
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Company Business:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxBusiness" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxBusiness"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Company Business"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Company Location:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxCompanyLocation" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxCompanyLocation"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Company Location"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Working Department:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxWorkingLoction" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxWorkingLoction"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Working Department"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Position Held:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxPostionHeld" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbxPostionHeld"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Position Held"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Experience Area:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxExpericenceArea" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbxExpericenceArea"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Experince Area"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Responsibilities Area:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxResposibities" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Duration:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxDuration" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbxDuration"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Duration"
                                            ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="submission">
                        <%--<asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                        <div class="col-md-12">
                            <asp:Button ID="btnAdd" runat="server" ValidationGroup="GroupExprence" Text="Submit"
                                Width="80px" CssClass="btn btn-info pull-right" OnClick="btnAdd_click" Style="margin-right: 8px;" />
                        </div>
                    </div>
                    </div>
                    
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" DynamicServicePath="" Enabled="True" />

            <div id="Div1">
                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <br />
                        <asp:GridView ID="grdExpericencesInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                            BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpericenceId" runat="server" Text='<%# Eval("ExperienceId")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEducation" runat="server" Text='<%# Bind("Experience_Company") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company Business">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Experience_CompanyBussiness") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Position Held">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Experience_PositionHeld") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Working Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Experience_CompanyDepartment") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Duration">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResult" runat="server" Text='<%# Bind("Experience_Duration") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnexperienceEdit" runat="server" Text="Edit" class="btn btn-primary"
                                            OnClick="btnexperienceEdit_Click" />
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
        <br />
        <div>
            <div class="tab-header">
                Skill Detail
    <asp:Button ID="Button1s" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnEdits_Click" />
            </div>
            <asp:Panel ID="Panel2" runat="server" Style="display: none" CssClass="modalPopupFreight">
                <div>
                    <asp:Label ID="lblSkillMessage" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                         <asp:Panel ID="Panel4" runat="server">
                        <div class="popuHeader">                         
                                <asp:LinkButton ID="LinkButton2" runat="server">
                                   <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>                        
                            <h4 id="H1" >Skill Details</h4>
                        </div>
                                 </asp:Panel>
                        <div id="Div3">
                            <div class="row tab-data" style="padding-top:7px">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Specialization:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxSpecialization" runat="server" Class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbxSpecialization"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Specialization"
                                            ValidationGroup="GroupSkill"></asp:RequiredFieldValidator>--%>
                                    </div>
                                    <asp:HiddenField ID="hidSkillId" runat="server" />
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Extra-Curricular:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxExtraCrricular" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Description:
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxDescription" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="btnSkilReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnSkillUpdate" runat="server" Text="Submit" ValidationGroup="GroupSkill"
                                    Width="80px" CssClass="btn btn-info pull-right" OnClick="btnSkillUpdate_Click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton3"
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" DynamicServicePath="" Enabled="True" />

            <div id="Div4">
                <div class="row">
                    <div class="col-md-12">
                        <br />

                        <asp:GridView ID="gradViewSkills" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                            BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSkillId" runat="server" Text='<%# Eval("SkillId")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Specialization">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEducation" runat="server" Text='<%# Bind("Skill_Specialization") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Extra-Curricular Activities">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Skill_ExtraActivities") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Skill_Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSkillceedit" runat="server" Text="Edit" class="btn btn-primary"
                                            OnClick="btnSkillceedit_Click" />
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
                Statement Information
    <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnStatement_Click" />
                </div>
                <asp:Panel ID="Panel7" runat="server" Style="display: none" CssClass="modalPopupFreight">


                    <div>
                        <asp:Label ID="lblStatementMessage" runat="server" Font-Bold="true"></asp:Label>
                        <div class="modal-dialog">
                             <asp:Panel ID="Panel8" runat="server">
                           <div class="popuHeader">                              
                                    <asp:LinkButton ID="LinkButton6" runat="server">
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    </asp:LinkButton>                                
                                <h4 id="H3" >Statement Information</h4>
                            </div>
                                 </asp:Panel>
                            <div id="Div7">
                                <div class="row tab-data" style="padding-top:7px;">
                                    <div class="container-fluid tab-container">
                                        <div class="col-md-4 col-xs-4">
                                            <h4>
                                            Name Of Relative:
                                        </div>
                                        <div class="col-md-8 col-xs-8 table-content">
                                            <asp:TextBox ID="txtbxNameOfRelative" runat="server" Class="form-control"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>
                                <div class="row tab-data">
                                    <div class="container-fluid tab-container">
                                        <div class="col-md-4 col-xs-4">
                                            <h4>
                                            E-ID:
                                        </div>
                                        <div class="col-md-8 col-xs-8 table-content">
                                            <asp:TextBox ID="txtbxEId" runat="server" Class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row tab-data">
                                    <div class="container-fluid tab-container">
                                        <div class="col-md-4 col-xs-4">
                                            <h4>
                                            Relation:
                                        </div>
                                        <div class="col-md-8 col-xs-8 table-content">
                                            <asp:TextBox ID="txtbxRelation" runat="server" Class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="submission">
                            <%--<asp:Button ID="Button2" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12"><asp:Button ID="Button3" runat="server" Text="Submit"
                                Width="80px" CssClass="btn btn-info pull-right" OnClick="statemenUpdate_Click" style="margin-right:8px;"/></div>
                        </div>
                        </div>
                        
                    </div>

</asp:Panel>
            <asp:LinkButton ID="LinkButton7" runat="server"></asp:LinkButton>
<asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="LinkButton7"
    PopupControlID="Panel7" BackgroundCssClass="modalBackground" CancelControlID="LinkButton6"
    DropShadow="True" PopupDragHandleControlID="Panel8" DynamicServicePath="" Enabled="True" />

        <div id="Div8">
            <div class="row tab-data">
                <div class="container-fluid tab-container">
                    <div class="col-md-4 col-xs-4">
                        <h4>Name of Relative:
                        </h4>
                    </div>
                    <div class="col-md-8 col-xs-8 table-content">
                        <p>
                            <asp:Label ID="lblNameOfRelative" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="row tab-data">
                <div class="container-fluid tab-container">
                    <div class="col-md-4 col-xs-4">
                        <h4>E-ID:
                        </h4>
                    </div>
                    <div class="col-md-8 col-xs-8 table-content">
                        <p>
                            <asp:Label ID="lblEid" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="row tab-data">
                <div class="container-fluid tab-container">
                    <div class="col-md-4 col-xs-4">
                        <h4>Relation:
                        </h4>
                    </div>
                    <div class="col-md-8 col-xs-8 table-content">
                        <p>
                            <asp:Label ID="lblRelation" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
            </div>

        </div>
</div>
    </ContentTemplate>
</asp:UpdatePanel>
