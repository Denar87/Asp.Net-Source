<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="UserSecurity.aspx.cs" Inherits="ERPSSL.Accounting.UI_Utilities.UserSecurity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400"/>
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Security Update
                    </h5>
                    <div class="buttonPanel">
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/save29.png"
                            Width="32px" OnClick="btnSubmit_Click" ToolTip="Save Changes" ValidationGroup="validation" />
                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                            Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                            Width="32px" OnClick="btnPrint_Click" ToolTip="Print" />
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <div class="LoaderBackground_">
                                    <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <br />
                                <div class="row-fluid">
                                    <div class="span8" style="padding-left: 10px;">
                                        <h3>Fillout the form!</h3>
                                        <div class="form-horizontal">
                                            <div class="control-group">
                                                <label class="control-label" for="inputFname1">
                                                    Current Password:</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtCurPassword" runat="server" Width="50%" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCurPassword"
                                                        ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                        Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-horizontal">
                                            <div class="control-group">
                                                <label class="control-label" for="inputFname1">
                                                    New Password:</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtNewPassword" runat="server" Width="50%" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNewPassword"
                                                        ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                        Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-horizontal">
                                            <div class="control-group">
                                                <label class="control-label" for="inputFname1">
                                                    Confirm New Password:</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtRNewPassword" runat="server" Width="50%" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtRNewPassword"
                                                        ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                        Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <%-------------Panel--------------%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.onload = function () {

            var x = document.getElementById('<%= lblMessage.ClientID %>');

            if (x.innerHTML == 'message') {
                document.getElementById("<%=lblMesssge.ClientID %>").style.display = "none";
            }
            else {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=lblMesssge.ClientID %>").style.display = "none";
                }, seconds * 1000);
            }
        };
    </script>
</asp:Content>
