<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="AccountGroupList.aspx.cs" Inherits="ERPSSL.Accounting.UI_Account.AccountGroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Account Group List
                    </h5>
                    <ul class="SearchPanel">
                        <li>
                            <label class="control-label" for="inputFname1">
                                Input Head Name/Code:
                                        <asp:TextBox ID="LedgerSearch" runat="server" placeholder="" Width="350px"
                                            OnTextChanged="LedgerSearch_TextChanged" AutoPostBack="true">
                                        </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="LedgerSearch"
                                    ForeColor="Red" ValidationGroup="validation" ErrorMessage="*"
                                    runat="server" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </label>
                        </li>
                    </ul>
                    <div class="buttonPanel">
                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/zoom77.png"
                            Width="32px" ValidationGroup="validation" OnClick="btnSearch_Click" />
                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                            Width="32px" OnClick="btnBack_Click" ToolTip="Go Back" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                            Width="32px" OnClick="btnPrint_Click" ToolTip="Print Details" />
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <br />
                        <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                            Visible="false">
                            <div id="lblMesssge" runat="server" class="alert alert-success">
                                <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                            </div>
                        </asp:Panel>
                        <div class="row-fluid" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
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
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
