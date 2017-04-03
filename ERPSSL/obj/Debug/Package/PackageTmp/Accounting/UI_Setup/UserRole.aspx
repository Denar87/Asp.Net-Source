<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="ERPSSL.Accounting.UI_Setup.UserRole" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400" />
    <div class="">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <asp:UpdatePanel ID="upnlAjax" runat="server">
                <ContentTemplate>
                    <%------------------UpdatePanel-----------------%>
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>New User Role Setup
                            </h5>
                            <div class="buttonPanel">

                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" ToolTip="Print" />
                            </div>
                        </div>
                        <%------------------Sec-----------------%>
                        <div style="overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee; height: 350px;">
                            <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                Visible="false">
                                <div id="lblMesssge" runat="server" class="alert alert-success">
                                    <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                </div>
                            </asp:Panel>
                            <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                CellPadding="5" OnRowCancelingEdit="dtg_list_RowCancelingEdit" OnRowCommand="dtg_list_RowCommand" OnRowDeleting="dtg_list_RowDeleting" OnRowEditing="dtg_list_RowEditing" OnRowUpdating="dtg_list_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="CustID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRoleID" runat="server" Text='<%#Eval("RoleID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbladd" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRole" runat="server" Text='<%#Eval("RoleName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRoleUpdate" runat="server" Text='<%#Eval("RoleName") %>' Width="97%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtRole" runat="server" Width="97%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqPhone" ValidationGroup="ValgrpCust" SetFocusOnError="true"
                                                ControlToValidate="txtRole" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="93%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit/Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="../Resources/dg_edit.png"
                                                CommandName="Edit" Width="18px" ToolTip="Edit Details" />
                                            <span onclick="return confirm('Are you sure want to delete?')">
                                                <asp:ImageButton ID="btnRemove" runat="server" ImageUrl="../Resources/cross.png"
                                                    CommandName="Delete" Width="18px" ToolTip="Delete Role" />
                                            </span>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/refresh69.png"
                                                Width="18px" CommandName="Update" ToolTip="Update" CssClass="float_but" />
                                            <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/cross106.png"
                                                Width="18px" CommandName="Cancel" ToolTip="Cancel" CssClass="float_but" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/add200.png"
                                                Width="30px" CommandName="Insert" ValidationGroup="ValgrpCust" />
                                        </FooterTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                            </asp:GridView>
                        </div>
                    </div>
                    <%------------------UpdatePanel-----------------%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>



