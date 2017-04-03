<%@ Page Title="" Language="C#" MasterPageFile="~/AppGateway/Site.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="ERPSSL.AppGateway.PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <div class="form-group">
            <asp:TextBox ID="txtEmail" runat="server" placeholder="E-mail" CssClass="form-control"></asp:TextBox>
        </div>
        <label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AppGateway/Login.aspx">Login my Account!</asp:HyperLink>
            </label>
        <asp:LinkButton ID="btnRecover" runat="server" class="btn btn-lg btn-info btn-block" OnClick="btnRecover_Click">Recover Account!</asp:LinkButton>
    </fieldset>
</asp:Content>
