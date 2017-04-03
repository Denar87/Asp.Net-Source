<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="acIntegrationConfig.aspx.cs" Inherits="ERPSSL.Adminpanel.acIntegrationConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Accounting Configuration
                </div>
            </div>
            <div class="col-md-12" style="padding-bottom: 10px; padding-top: 10px">
                <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" Height="28" Width="250">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Sales</asp:ListItem>
                    <asp:ListItem>Inventory</asp:ListItem>
                    <asp:ListItem>Fixed Asset</asp:ListItem>
                    <asp:ListItem>Payroll</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-12">
                <asp:GridView ID="dgGridList" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None"
                    EmptyDataText="No Records Found!"
                    EmptyDataRowStyle-Font-Bold="true"
                    EmptyDataRowStyle-ForeColor="Red"
                    AllowPaging="true" AllowSorting="True" CellPadding="5"
                    DataKeyNames="Id"
                    OnRowCancelingEdit="dgGridList_RowCancelingEdit"
                    OnRowCommand="dgGridList_RowCommand"
                    OnRowDeleting="dgGridList_RowDeleting"
                    OnRowEditing="dgGridList_RowEditing"
                    OnRowUpdating="dgGridList_RowUpdating"
                    OnRowDataBound="dgGridList_RowDataBound"
                    OnPageIndexChanging="dgGridList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Module Name">
                            <ItemTemplate>
                                <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("ModuleName") %>'></asp:Label>
                            </ItemTemplate>
                            <%--                <EditItemTemplate>
                    <asp:TextBox ID="txtModuleNameUpdate" runat="server" Text='<%#Eval("ModuleName") %>' Width="97%"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>--%>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Module Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("ModuleId") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<EditItemTemplate>
                    <asp:TextBox ID="txtModuleIdUpdate" runat="server" Text='<%#Eval("ModuleId") %>' Width="97%"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>--%>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item/User">
                            <ItemTemplate>
                                <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnId" Value='<%# Eval("ItemCode") %>' />
                            </ItemTemplate>
                            <%--<EditItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnId" Value='<%# Eval("Item") %>' />
                    <asp:DropDownList ID="cmbItem" runat="server" Height="28px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>--%>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ledger Name">
                            <ItemTemplate>
                                <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <%--<asp:HiddenField runat="server" ID="hdnId" Value='<%# Eval("Ledger_Code") %>' />--%>
                                <asp:DropDownList ID="cmbParticulars" runat="server" Height="28px">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nature">
                            <ItemTemplate>
                                <asp:Label ID="lblTransactionNature" runat="server" Text='<%#Eval("TransactionNature") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<EditItemTemplate>
                    <asp:DropDownList ID="cmbTransactionNature" runat="server" Height="28px">
                        <asp:ListItem>DEBIT</asp:ListItem>
                        <asp:ListItem>CREDIT</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>--%>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Voucher Type">
                            <ItemTemplate>
                                <asp:Label ID="lblVoucher_Type" runat="server" Text='<%#Eval("Voucher_Type") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<EditItemTemplate>
                    <asp:TextBox ID="txtVoucher_Type" runat="server" Text='<%#Eval("Voucher_Type") %>' Width="97%"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>--%>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="img/dg_edit.png"
                                    CommandName="Edit" Width="18px" ToolTip="Edit Details" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="img/tick.png"
                                    Width="18px" CommandName="Update" ToolTip="Update" CssClass="float_but" />
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="img/cross.png"
                                    Width="18px" CommandName="Cancel" ToolTip="Cancel" CssClass="float_but" />
                            </EditItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination01 pageback" />
                </asp:GridView>

            </div>
            <br />
        </div>
    </div>
</asp:Content>
