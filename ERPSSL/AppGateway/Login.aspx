<%@ Page Title="" Language="C#" MasterPageFile="~/AppGateway/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERPSSL.AppGateway.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function EnterEvent(e) {
            if (e.keyCode == 13) {
                document.getElementById("<%=btnLogin.ClientID %>").click();
            }
        }
    </script>
    <asp:Panel ID="LodingPanel" runat="server">

        <div class="resultText">
            <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
                Visible="false" />
            <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
            <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>

        </div>
    </asp:Panel>
    <asp:Panel ID="loginPanel" runat="server">
        <fieldset>
            <div class="input-group input-group-lg" style="padding-bottom:5px">
                <span class="input-group-addon"><i class="glyphicon glyphicon-user red" style="color:#7393BF"></i></span>
                <asp:TextBox ID="txtLoginName" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
                
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLoginName"
                    ForeColor="Red" ValidationGroup="lGvalidation" ErrorMessage="Please Enter Login Name!!"
                    runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <div class="clearfix"></div>

            <div class="input-group input-group-lg">
                <span class="input-group-addon"><i class="glyphicon glyphicon-lock red" style="color:#7393BF"></i></span>
                <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" placeholder="Password" onkeypress="return EnterEvent(event)" CssClass="form-control"></asp:TextBox>
                
            </div>
          <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" ControlToValidate="txtLoginPassword" ForeColor="Red"
                    ValidationGroup="lGvalidation" ErrorMessage="Please Enter Password!!" runat="server"
                    Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <div class="checkbox">
                <label style="float:left;">
                    <asp:CheckBox ID="chkRememberMe" runat="server" Text=" Remember Me" />
                </label>
                
                <label style="float:right;">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AppGateway/PasswordRecovery.aspx">Forgot your password?</asp:HyperLink>
                </label>
            </div>
            <asp:LinkButton ID="btnLogin" runat="server" ValidationGroup="lGvalidation" class="btn btn-lg btn-info  btn-block" OnClick="btnLogin_Click">Login</asp:LinkButton>
        </fieldset>
    </asp:Panel>

</asp:Content>
