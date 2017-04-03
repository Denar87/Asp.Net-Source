<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="AcConfiguration.aspx.cs" Inherits="ERPSSL.PAYROLL.AcConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Accounting Configuration - Inventory
    </h3>
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

            <asp:TemplateField HeaderText="Particulars">
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

            <asp:TemplateField HeaderText="Transaction Nature">
                <ItemTemplate>
                    <asp:Label ID="lblTransactionNature" runat="server" Text='<%#Eval("TransactionNature") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:DropDownList ID="cmbTransactionNature" runat="server" Height="28px">
                         <asp:ListItem>DEBIT</asp:ListItem>
                         <asp:ListItem>CREDIT</asp:ListItem>
                    </asp:DropDownList>                    
                </EditItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
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

