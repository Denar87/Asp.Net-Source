<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="UserSetup.aspx.cs" Inherits="ERPSSL.Accounting.UI_Setup.UserSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function EditSelectAll(StartIndex, HeadIndex) {
            var grid = document.getElementById("<%=dtg_list.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            var isValid = false;
            for (var i = StartIndex; i < inputs.length; i += 1) {
                if (inputs[i].type == "checkbox") {
                    if (inputs[HeadIndex].checked == true) {
                        if (i != HeadIndex)
                            inputs[i].checked = true;
                    }
                    else if (inputs[HeadIndex].checked == false) {
                        if (i != HeadIndex) {
                            inputs[i].checked = false;
                        }
                    }
                }
            }
        }

        function Edit(StartIndex, HeadIndex) {
            var grid = document.getElementById("<%=dtg_list.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            var isValid = false;
            var checkedCount = 0;
            for (var i = StartIndex; i < inputs.length; i += 1) {
                if (inputs[i].type == "checkbox") {
                    if (i != HeadIndex) {
                        if (inputs[i].checked == false) {
                            ++checkedCount;
                        }
                    }
                    if (checkedCount == 0) {
                        inputs[HeadIndex].checked = true;
                    }
                    else {
                        inputs[HeadIndex].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400" />
    <div class="">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <asp:UpdatePanel ID="upnlAjax" runat="server">
                <ContentTemplate>
                    <%------------------UpdatePanel-----------------%>
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>User Setup
                            </h5>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/add199.png"
                                    Width="32px" OnClick="btnAdd_Click" ToolTip="Save Changes" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" ToolTip="Print" />
                            </div>
                        </div>
                        <%------------------Sec-----------------%>
                        <div style="overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee; height: 350px;">
                            <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True" DataKeyNames="UserID"
                                CellPadding="2" OnRowCommand="dtg_list_RowCommand" OnRowDeleting="dtg_list_RowDeleting">
                                <Columns>
                                     <asp:TemplateField HeaderText="UserID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header"/>
                                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer"/>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="UserID" HeaderText="UserID">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>

                                    <asp:TemplateField HeaderText="Login Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRoleID" runat="server" Text='<%#Eval("LoginName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>

                                    <%-- <asp:BoundField DataField="LoginName" HeaderText="Login Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>

                                    <asp:BoundField DataField="User_Level" HeaderText="User Level">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UserFullName" HeaderText="User Full Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Use_Email" HeaderText="Use Email">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="19%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RoleName" HeaderText="User Role">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Status">
                                        <HeaderTemplate>
                                            <div class="GridCheckbox_ ">
                                                <asp:CheckBox ID="chkbxEditAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(0,0)" />
                                                <asp:Label ID="LabelEdit" AssociatedControlID="chkbxEditAll_" runat="server"
                                                    Text="Sts" CssClass="CheckBoxLabel"></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="GridCheckbox ">
                                                <asp:CheckBox ID="chkbxEditItem_" runat="server" onclick="Edit(0, 0)" Checked='<%# Bind("IsActive") %>'
                                                    Enabled="true" />
                                                <asp:Label ID="LabelStatus" AssociatedControlID="chkbxEditItem_" runat="server"
                                                    Text="" CssClass="CheckBoxLabel"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="true" HeaderText="Option">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="../Resources/dg_edit.png"
                                                CommandName="Edit" Width="18px" ToolTip="Edit Details" Visible="false" />

                                            <span onclick="return confirm('Are you sure want to delete?')">
                                                <asp:ImageButton ID="btnRemove" runat="server" ImageUrl="../Resources/cross.png"
                                                    CommandName="Delete" Width="18px" ToolTip="Delete User" />
                                            </span>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="25%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                            </asp:GridView>
                        </div>
                        <%------------------pnlAddPopup-----------------%>
                        <div id="pnlAddPopup" runat="server" class="popuBody">
                            <div id="popupheader" class="popuHeader">
                                <asp:Label ID="lblHeader" runat="server" Text="Add New User" />
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
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            User Name:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtUserName" runat="server" Width="70%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUserName"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            User Full Name:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtUserFullName" runat="server" Width="70%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserFullName"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            User Email:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtEmail" runat="server" Width="70%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel runat="server" ID="panelPass">
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <label class="control-label" for="inputFname1">
                                                User Password:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtUserPass" runat="server" Width="60%" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtUserPass"
                                                    ForeColor="Red" ValidationGroup="validation" ErrorMessage="Name required" runat="server"
                                                    Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label" for="inputFname1">
                                            Role Name:</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="cmbUSerRole" runat="server" Width="73%">
                                            </asp:DropDownList>
                                            <asp:Button ID="btnNewRole" runat="server" Text=" + " OnClick="btnNewRole_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        <div class="controls">
                                            <asp:Button ID="btnSave" runat="server" Text="  Save  " ValidationGroup="validation" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Text=" Cancel " OnClientClick="javascript:$find('mpeUserBehavior').hide();return false;" />
                                        </div>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

