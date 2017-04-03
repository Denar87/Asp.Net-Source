<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="PagePermission.aspx.cs" Inherits="ERPSSL.Accounting.UI_Setup.PagePermission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function EditSelectAll(StartIndex, HeadIndex) {
            var grid = document.getElementById("<%=gvPermission.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            var isValid = false;
            for (var i = StartIndex; i < inputs.length; i += 4) {
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
            var grid = document.getElementById("<%=gvPermission.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            var isValid = false;
            var checkedCount = 0;
            for (var i = StartIndex; i < inputs.length; i += 4) {
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
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
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
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>Page Permission
                            </h5>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/settings60.png"
                                    Width="32px" OnClick="btnSubmit_Click" ToolTip="Save Changes" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" ToolTip="Print" />
                            </div>
                        </div>

                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <br />
                                <div style="overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee; height: 410px;">
                                    <div class="" style="padding-left: 10px;">
                                        <asp:DropDownList ID="drpUserRole" runat="server" Width="99%" AutoPostBack="True" OnDataBound="drpUserRole_DataBound" OnSelectedIndexChanged="drpUserRole_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:GridView ID="gvPermission" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                            AllowSorting="True" AutoGenerateColumns="False" Width="99%" ShowFooter="True"
                                            CellPadding="0" PageSize="50">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID_" runat="server" Text='<%# Bind("PageID") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Page Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPageName_" runat="server" Text='<%# Bind("PageName") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="60%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Visit">
                                                    <HeaderTemplate>
                                                        <div class="GridCheckbox_ ">
                                                            <asp:CheckBox ID="chkbxEditAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(0,0)" />
                                                            <asp:Label ID="LabelEdit" AssociatedControlID="chkbxEditAll_" runat="server"
                                                                Text="Visit" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="GridCheckbox ">
                                                            <asp:CheckBox ID="chkbxEditItem_" runat="server" onclick="Edit(0, 0)" Checked='<%# Bind("CanVisit") %>'
                                                                Enabled="true" />
                                                            <asp:Label ID="Label1" AssociatedControlID="chkbxEditItem_" runat="server"
                                                                Text="" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <HeaderTemplate>
                                                        <div class="GridCheckbox_ ">
                                                            <asp:CheckBox ID="chkbxUpdateAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(1,1)" />
                                                            <asp:Label ID="LabelUpdate" AssociatedControlID="chkbxUpdateAll_" runat="server"
                                                                Text="Edit" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="GridCheckbox ">
                                                            <asp:CheckBox ID="chkbxUpdateItem_" runat="server" onclick="Edit(1, 1)" Checked='<%# Bind("CanEdit") %>'
                                                                Enabled="true" />
                                                            <asp:Label ID="Label2" AssociatedControlID="chkbxUpdateItem_" runat="server"
                                                                Text="" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <HeaderTemplate>
                                                        <div class="GridCheckbox_ ">
                                                            <asp:CheckBox ID="chkbxDeleteAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(2,2)" />
                                                            <asp:Label ID="LabelDelete" AssociatedControlID="chkbxDeleteAll_" runat="server"
                                                                Text="Delete" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="GridCheckbox ">
                                                            <asp:CheckBox ID="chkbxDeleteItem_" runat="server" onclick="Edit(2, 2)" Checked='<%# Bind("CanDelete") %>'
                                                                Enabled="true" />
                                                            <asp:Label ID="Label3" AssociatedControlID="chkbxDeleteItem_" runat="server"
                                                                Text="" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Execute">
                                                    <HeaderTemplate>
                                                        <div class="GridCheckbox_ ">
                                                            <asp:CheckBox ID="chkbxExecuteAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(3,3)" />
                                                            <asp:Label ID="LabelExecute" AssociatedControlID="chkbxExecuteAll_" runat="server"
                                                                Text="Execute" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="GridCheckbox ">
                                                            <asp:CheckBox ID="chkbxExecuteItem_" runat="server" onclick="Edit(3, 3)" Checked='<%# Bind("CanExecute") %>'
                                                                Enabled="true" />
                                                            <asp:Label ID="Label4" AssociatedControlID="chkbxExecuteItem_" runat="server"
                                                                Text="" CssClass="CheckBoxLabel"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                        </asp:GridView>

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
</asp:Content>
