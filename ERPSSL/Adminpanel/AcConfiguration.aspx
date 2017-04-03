<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="AcConfiguration.aspx.cs" Inherits="ERPSSL.Adminpanel.AcConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Accounting Configuration 
    </h3>
    <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
        <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>Sales</asp:ListItem>
        <asp:ListItem>Inventory</asp:ListItem>
        <asp:ListItem>Fixed Asset</asp:ListItem>
        <asp:ListItem>Payroll</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <asp:GridView ID="dgGridList" runat="server" AutoGenerateColumns="False" Width="100%"
        EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
        DataKeyNames="Id" OnRowCancelingEdit="dgGridList_RowCancelingEdit" OnRowCommand="dgGridList_RowCommand" OnRowDeleting="dgGridList_RowDeleting" OnRowEditing="dgGridList_RowEditing" OnRowUpdating="dgGridList_RowUpdating" OnRowDataBound="dgGridList_RowDataBound">
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

            <asp:TemplateField HeaderText="Module Id">
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

            <asp:TemplateField HeaderText="Item">
                <ItemTemplate>
                    <asp:Label ID="lblItem" runat="server" Text='<%#Eval("Item") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<asp:HiddenField runat="server" ID="hdnId" Value='<%# Eval("Item") %>' />--%>
                    <asp:DropDownList ID="cmbItem" runat="server" Height="28px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                <FooterStyle CssClass="Grid_Footer" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Ledger">
                <ItemTemplate>
                    <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnId" Value='<%# Eval("Particulars") %>' />
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
    </asp:GridView>
</asp:Content>
