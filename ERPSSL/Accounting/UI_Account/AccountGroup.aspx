<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="AccountGroup.aspx.cs" Inherits="ERPSSL.Accounting.UI_Account.AccountGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" AsyncPostBackTimeout="2400" />
    <asp:UpdatePanel ID="upnlAjax" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="">
                <br />
                <div class="col-xs-12 col-sm-6 widget-container-col">
                    <%------------------UpdatePanel-----------------%>
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>New Accounting Group
                            </h5>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/add200.png"
                                    Width="32px" OnClick="btnAdd_Click" ToolTip="Save Changes" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" ToolTip="Print" />
                            </div>
                        </div>
                        <%------------------Sec-----------------%>
                        <div style="overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee; height: 432px;">
                            <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                CellPadding="1" OnPageIndexChanging="dtg_list_PageIndexChanging"
                                PageSize="50" OnRowDeleting="dtg_list_RowDeleting" OnRowCancelingEdit="dtg_list_RowCancelingEdit"
                                OnRowEditing="dtg_list_RowEditing" OnRowUpdating="dtg_list_RowUpdating" OnRowDataBound="dtg_list_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroup_ID" runat="server" Text='<%#Eval("Group_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroup_Name" runat="server" Text='<%#Eval("Group_Name") %>' Width="350px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtGroup_Name" runat="server" Text='<%#Eval("Group_Name") %>' Width="350px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="80%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="80%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="80%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set_1/pencil41.png"
                                                Width="16px" CommandName="Edit" ToolTip="Edit" CssClass="float_but" />
                                            <span onclick="return confirm('Are you sure want to delete?')">
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/cross106.png"
                                                    Width="16px" CommandName="Delete" ToolTip="Delete" CssClass="float_but" />
                                            </span>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/refresh69.png"
                                                Width="16px" CommandName="Update" ToolTip="Update" CssClass="float_but" />
                                            <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/cross106.png"
                                                Width="16px" CommandName="Cancel" ToolTip="Cancel" CssClass="float_but" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="Grid_Border" Width="50px" />
                                        <FooterStyle CssClass="Grid_Footer" Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                            </asp:GridView>
                        </div>
                        <%------------------pnlAddPopup-----------------%>
                        <div id="pnlAddPopup" runat="server" class="popuBody" style="display: none;">
                            <div id="popupheader" class="popuHeader">
                                <asp:Label ID="lblHeader" runat="server" Text="Add New Accounting Group" />
                                <span style="float: right">
                                    <img id="imgClose" src="../Images/btn-close.png" alt="close" title="Close" style="cursor: pointer" />
                                </span>
                            </div>
                            <%------------------ModalPopupExtender-----------------%>
                            <div class="innerBody">
                                <asp:HiddenField ID="hfPopupID" runat="server" Value="0" />
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <h4>Fillout the form!</h4>
                                <hr />
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            Group Name:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtGroupName" placeholder="Group Name" runat="server" Width="80%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtGroupName"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            Group Nature:</label>
                                        <div class="controls">
                                            <div style="display: table; margin-top: 10px;">
                                                <div class="SingleCheckbox ">
                                                    <asp:RadioButton ID="chkGrpNature" runat="server" GroupName="print"
                                                        OnCheckedChanged="chkGrpNature_CheckedChanged"
                                                        AutoPostBack="true" />
                                                    <asp:Label ID="Label3" AssociatedControlID="chkGrpNature" runat="server"
                                                        Text="Primary Group" CssClass="CheckBoxLabel"></asp:Label>
                                                </div>

                                                <div class="SingleCheckbox margin_left">
                                                    <asp:RadioButton ID="chkGrpNature_" runat="server" GroupName="print"
                                                        OnCheckedChanged="chkGrpNatureHide_CheckedChanged"
                                                        AutoPostBack="True" Checked="true" />
                                                    <asp:Label ID="Label2" AssociatedControlID="chkGrpNature_" runat="server"
                                                        Text="Upder Group" CssClass="CheckBoxLabel"></asp:Label>
                                                </div>

                                            </div>
                                            <div style="display: table; margin-top: 10px;">
                                                <asp:DropDownList ID="cmbNature" runat="server" Width="150px" Visible="false">
                                                    <asp:ListItem>DEBIT</asp:ListItem>
                                                    <asp:ListItem>CREDIT</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            Under Group:</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="cmbCategoryGroup_Parent" runat="server" Width="82%">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <div class="controls">
                                            <asp:Button ID="btnSave" runat="server" Text="  Save  " ValidationGroup="validation" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Text=" Cancel " OnClientClick="javascript:$find('mpeUserBehavior').hide();return false;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%------------------ModalPopupExtender-----------------%>
                            <ajax:ModalPopupExtender ID="mpeAjax" runat="server"
                                TargetControlID="hfPopupID"
                                PopupControlID="pnlAddPopup"
                                BehaviorID="mpeUserBehavior"
                                DropShadow="true"
                                CancelControlID="imgClose"
                                PopupDragHandleControlID="popupheader"
                                BackgroundCssClass="modalBackground_" />
                        </div>

                    </div>
                    <%------------------UpdatePanel-----------------%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
