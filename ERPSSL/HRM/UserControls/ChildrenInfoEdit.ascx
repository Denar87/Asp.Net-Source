<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChildrenInfoEdit.ascx.cs" Inherits="ERPSSL.HRM.UserControls.ChildrenInfoEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">

    <ContentTemplate>
        <div class="tab-header">
            Children Info
    <asp:Button ID="btnedit" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnEdit_Click" />
        </div>
        <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">

            <div>
                <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                <link href="../../css/Modal.css" rel="stylesheet" />
                <div class="modal-dialog">
                    <asp:Panel ID="Panel3" runat="server">
                        <div class="popuHeader">
                            <asp:LinkButton ID="CancelButton" runat="server" >
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            </asp:LinkButton>
                            <h4 id="myModalLabel" >Children's Info</h4>
                        </div>
                    </asp:Panel>
                    <div id="Div2">
                        <div class="row tab-data" style="padding-top:7px;">
                            <div class="container-fluid tab-container">
                                <div class="col-md-4 col-xs-4">
                                    <h4>
                                    Name:
                                </div>
                                <div class="col-md-8 col-xs-8 table-content">
                                    <asp:TextBox ID="txtbxChildrenName" runat="server" Class="form-control"></asp:TextBox>

                                </div>
                                <asp:HiddenField ID="childrenId" runat="server" />
                            </div>
                        </div>
                        <div class="row tab-data">
                            <div class="container-fluid tab-container">
                                <div class="col-md-4 col-xs-4">
                                    <h4>
                                    Gender:
                                </div>
                                <div class="col-md-8 col-xs-8 table-content">
                                    <asp:DropDownList ID="drpChildrenGender" Class="form-control" runat="server">
                                        <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="row tab-data">
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>DBO :</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txbxDBO" OnTextChanged="txtDob_TextChanged" AutoPostBack="True" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txbxDBO"
                                            PopupButtonID="txbxDBO" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row tab-data">
                            <div class="container-fluid tab-container">
                                <div class="col-md-4 col-xs-4">
                                    <h4>
                                    Age


                                </div>
                                <div class="col-md-8 col-xs-8 table-content">
                                    <asp:TextBox ID="txtbxAge" runat="server" Class="form-control"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="submission">
                        <%--<asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                        <div class="col-md-12">
                            <asp:Button ID="btnAdd" runat="server" Text="Submit"
                                Width="80px" CssClass="btn btn-info pull-right" OnClick="btnUpdate_click" Style="margin-right: 8px;" />
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
                    <asp:GridView ID="gridviewChildrenInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                        BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblChildrenID" runat="server" Text='<%# Eval("ChildId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="Name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOB">
                                <ItemTemplate>
                                    <asp:Label ID="lblDoB" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Working Department">
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="lblChildrenInfo" runat="server" Text="Edit" class="btn btn-primary"
                                        OnClick="lblChildrenInfo_Click" />
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
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

