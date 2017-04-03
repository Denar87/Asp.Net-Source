<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="ERPSSL.Accounting.UI_Gateway.CompanyList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Financial Mgt Systeam</title>

    <link href="../content/css/base.css" rel="stylesheet" media="screen" />
    <!-- Bootstrap style responsive -->
    <link href="../content/bootshop/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="../content/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../content/css/styles.css" type="text/css" />
    <link href="../content/SpryAssets/SpryMenuBarVertical.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
    <script type="text/javascript" src="../content/js/script.js"></script>
    <script src="../content/SpryAssets/SpryMenuBar.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.min.css" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <link rel="stylesheet" href="../assets/css/ace.min.css" />
    <link id="callCss" rel="stylesheet" href="../content/bootshop/bootstrap.min.css" media="screen" />

    <link href="../content/css/ContentStyle.css" rel="stylesheet" type="text/css" />
    <link href="../content/css/GridStyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" AsyncPostBackTimeout="2400" />
        <div id="header">
            <!-- Navbar ================================================== -->
            <div class="userPanelBar">
                <div id='cssmenu'>
                    <div class="userPanel">
                        <img id="Img3" runat="server" src="../content/images/FilledStar00.png" class="img-circle profile-pic">
                        <span style="margin-right: 5px; font-weight: normal; color: green">
                            <asp:Label ID="lblUser" runat="server"></asp:Label>
                        </span>
                        <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click" Style="color: white">
                     <img src="../Resources/logout.png" width="16px" /> Logout
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-------------Panel--------------%>
                <div id="MasterBody">
                    <div class="container">

                        <%--<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400" />--%>
                        <asp:UpdatePanel ID="upnlAjax" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="LoaderBackground_">
                                            <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="">
                                    <br />
                                    <div class="col-xs-12 col-sm-6 widget-container-col">
                                        <%------------------UpdatePanel-----------------%>
                                        <div class="widget-box">
                                            <br />
                                            <img src="../Resources/logo.png" style="position: absolute; top: 80px; right: 25px; width: 200px;" />
                                            <asp:Button ID="btnAdd" runat="server" Text="Create New Project" Width="180px" ToolTip="Save Changes" OnClick="btnAdd_Click" />
                                            <br />
                                            <%------------------Sec-----------------%>
                                            <div style="margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee; height: 410px;">

                                                <asp:Repeater ID="RepterDetails" runat="server" OnItemCommand="RepterDetails_ItemCommand">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="company_base">
                                                            <strong>

                                                                <asp:LinkButton ID="lbtnCompany" runat="server" CommandName="ClickCompany" CommandArgument='<%# Eval("Company_Code") %>'>
                                                                    <asp:Label ID="lblCompany_Namee" runat="server" Text='<%#Eval("Company_Name") %>' />
                                                                </asp:LinkButton>

                                                            </strong>
                                                            <asp:Label ID="lblCompany_Code" runat="server" Text='<%#Eval("Company_Code") %>' Visible="false" />

                                                            <p>
                                                                Email:
                                                        <asp:Label ID="lblE_mail" runat="server" Text='<%#Eval("E_mail") %>' />
                                                                || Created:
                                                        <asp:Label ID="lblCreate_Date" runat="server" Text='<%#Eval("Create_Date") %>' />
                                                            </p>

                                                            <div class="btnpanel_cmp">

                                                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="../Images/edit.png" CommandName="EditProject" CommandArgument='<%# Eval("Company_Code") %>'
                                                                    ToolTip="Edit Project" Width="24" />

                                                                <asp:ImageButton ID="ibtnBackup" runat="server" ImageUrl="../Images/btn-backup.png" CommandName="BkpProject" CommandArgument='<%# Eval("Company_Code") %>'
                                                                    ToolTip="Backup Project" Width="28" />

                                                                <span onclick="return confirm('Are you sure want to delete?')">
                                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="../Images/delete.png" CommandName="DeleteProject" CommandArgument='<%# Eval("Company_Code") %>'
                                                                        Width="24px" ToolTip="Delete Project" />
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <%------------------pnlAddPopup-----------------%>
                                            <div id="pnlAddPopup" runat="server" class="popuBody_cmp" style="display: none;">
                                                <div id="popupheader" class="popuHeader_cmp">
                                                    <asp:Label ID="lblHeader" runat="server" Text="Create New Project" />
                                                    <span style="float: right">
                                                        <img id="imgClose" src="../Images/btn-close.png" alt="close" title="Close" style="cursor: pointer" />
                                                    </span>
                                                </div>
                                                <%------------------ModalPopupExtender-----------------%>
                                                <div class="innerBody">
                                                    <asp:HiddenField ID="hfPopupID" runat="server" Value="0" />
                                                    <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                                        Visible="false">
                                                        <div id="lblMesssge" runat="server" class="alert alert-success">
                                                            <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                                        </div>
                                                    </asp:Panel>
                                                    <h4>Fillout the form!</h4>
                                                    <hr />
                                                    <div class="form_left">
                                                        <fieldset>
                                                            <legend>Project Info</legend>
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
                                                        <fieldset>
                                                            <legend>Years From</legend>
                                                            <div class="form-horizontal">
                                                                <div class="control-group">
                                                                    <label class="control-label" for="inputFname1">
                                                                        A/C Years From:</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="dtpFinancialYearFrom" placeholder="A/C Years From" runat="server"></asp:TextBox>
                                                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="dtpFinancialYearFrom"
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
                                                                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpBookYear"
                                                                            PopupButtonID="dtpBookYear" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                        <fieldset>
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
                                                                        <asp:TextBox ID="nudDecimalPlace" placeholder="Currency Symbol" runat="server" Width="250px"></asp:TextBox>
                                                                        <ajax:NumericUpDownExtender ID="NumericUpDownExtender1" Enabled="true" Step="1"
                                                                            runat="server" TargetControlID="nudDecimalPlace" Minimum="0" Maximum="100" Width="230">
                                                                        </ajax:NumericUpDownExtender>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                        <div class="btn_controls">
                                                            <asp:Button ID="btnSave" runat="server" Text="  Save  " ValidationGroup="validation" OnClick="btnSave_Click" Width="100px" />
                                                            <asp:Button ID="btnCancel" runat="server" Text=" Cancel " OnClientClick="javascript:$find('mpeUserBehavior').hide();return false;" Width="100px" />
                                                        </div>
                                                    </div>
                                                    <%--form--%>
                                                    <div class="form-horizontal">
                                                        <div class="control-group">
                                                        </div>
                                                    </div>
                                                </div>
                                                <%------------------ModalPopupExtender-----------------%>
                                                <ajax:ModalPopupExtender ID="mpeAjax" runat="server"
                                                    TargetControlID="hfPopupID"
                                                    PopupControlID="pnlAddPopup"
                                                    BehaviorID="mpeUserBehavior"
                                                    DropShadow="true"
                                                    CancelControlID="imgClose"
                                                    PopupDragHandleControlID="popupheader"
                                                    BackgroundCssClass="modalBackground_" />
                                            </div>

                                        </div>
                                        <%------------------UpdatePanel-----------------%>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%-------------Panel--------------%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="footerSection">
            <div class="container">
                <div class="row-fluid">
                    <%-- <div class="span6">
                        <ul class="inline">
                            <li><a href="">About</a> </li>
                            <li><a href="">Privacy policy</a></li>
                            <li><a href="">Terms of use</a></li>
                            <li><a href="">Help & Contact</a></li>
                        </ul>
                    </div>--%>
                    <div class="span6">
                        <p class="pull-right">
                            &copy; Subra Systems Limited. All rights reserved.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
