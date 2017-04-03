<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectSetup.aspx.cs" Inherits="ERPSSL.Accounting.UI_Setup.ProjectSetup" 
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Project Details
                    </h5>
                    <div class="widget-toolbar widget-toolbar-light no-border">
                    </div>
                    <div class="buttonPanel">
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/save29.png"
                            Width="32px" OnClick="btnSubmit_Click" ToolTip="Save Changes"/>
                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                            Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                            Width="32px" OnClick="btnPrint_Click" ToolTip="Print" />
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <br />
                        <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                            Visible="false">
                            <div id="lblMesssge" runat="server" class="alert alert-success">
                                <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                            </div>
                        </asp:Panel>
                        <div class="row-fluid">
                            <div class="form_left">
                                <fieldset style="padding-left: 10px;">
                                    <legend>Company Info</legend>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Company:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCompanyName" placeholder="Company" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCompanyName"
                                                    ForeColor="Red" ValidationGroup="validation" ErrorMessage="company required"
                                                    runat="server" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Country:</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="cmbCountry" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                City:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCity" placeholder="City" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Address:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtAddress" placeholder="Address" runat="server" TextMode="MultiLine"
                                                    Height="50"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Zip:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtZip" placeholder="Zip" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Phone:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtPhone" placeholder="Phone" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Email:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtEmail" placeholder="Email" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Website:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtWebsite" placeholder="Website" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="form_right">
                                <fieldset style="padding-left: 10px;">
                                    <legend>Years From</legend>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                A/C Years From:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="dtpFinancialYearFrom" placeholder="A/C Years From" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="dtpFinancialYearFrom"
                                                    PopupButtonID="dtpFinancialYearFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                    Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Book Begining:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="dtpBookYear" placeholder="Book Begining" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpBookYear"
                                                    PopupButtonID="dtpBookYear" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                                <fieldset style="padding-left: 10px;">
                                    <legend>Currency Info</legend>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Formal Name:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCurrencyName" placeholder="Formal Name" runat="server" AutoPostBack="True"
                                                    OnTextChanged="txtCurrencyName_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Currency Symbol:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCurrencySymbol" placeholder="Currency Symbol" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Sub Currency:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtSubCurrency" placeholder="Sub Currency" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                Decimal Place:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="nudDecimalPlace" placeholder="Currency Symbol" runat="server"></asp:TextBox>
                                                <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender1" Enabled="true" Step="1"
                                                    runat="server" TargetControlID="nudDecimalPlace" Minimum="0" Maximum="100" Width="230">
                                                </ajaxToolkit:NumericUpDownExtender>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
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
