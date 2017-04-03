<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="AccountLedgerList.aspx.cs" Inherits="ERPSSL.Accounting.UI_Account.AccountLedgerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Account Ledger List
                    </h5>
                    <ul class="SearchPanel">
                        <li>
                            <label class="control-label" for="inputFname1">
                                Input Ledger Name/Code:
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
                                            <asp:Label ID="lblSerial" runat="server" Text='<%#Eval("Ledger_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="30px" />
                                        <ItemStyle HorizontalAlign="Left" Width="30px" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ledger Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedger_Code" runat="server" Text='<%#Eval("Ledger_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="70px" />
                                        <ItemStyle HorizontalAlign="Left" Width="70px" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="70px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ledger Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedger_Name" runat="server" Text='<%#Eval("Ledger_Name") %>' Width="350px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLedger_Name" runat="server" Text='<%#Eval("Ledger_Name") %>' Width="350px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="50%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="50%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="50%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroup_Name" runat="server" Text='<%#Eval("Group_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="25%" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="25%" />
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
