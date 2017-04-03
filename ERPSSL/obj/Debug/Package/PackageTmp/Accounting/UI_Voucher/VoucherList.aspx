<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="VoucherList.aspx.cs" Inherits="ERPSSL.Accounting.UI_Voucher.VoucherList" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            debugger;
            $("[id*=GridView1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="span12">
                <br />
                <div class="col-xs-12 col-sm-6 widget-container-col">
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>Voucher List
                            </h5>
                            <ul class="VoucherPanel" style="margin-right: 30px">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Voucher No:
                                <asp:TextBox ID="txtVoucherNo" runat="server" Width="150px" OnTextChanged="txtVoucherNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    </label>
                                </li>
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Voucher Date:
                                <asp:TextBox ID="dtpVoucherDate" runat="server" placeholder="MM/dd/yyyy" Width="100px">
                                </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpVoucherDate"
                                            PopupButtonID="dtpVoucherDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/zoom77.png"
                                    Width="32px" OnClick="btnSearch_Click" ToolTip="Search Voucher" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="BtnApprove" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/check60.png"
                                    Width="32px" OnClick="BtnApprove_Click" ToolTip="Approve Voucher" />
                                <asp:ImageButton ID="BtnDiscard" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/ban2.png"
                                    Width="32px" OnClick="BtnDiscard_Click" ToolTip="Discard Voucher" />
                            </div>
                        </div>

                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />
                                <div class="radio_panel">
                                    <div class="SingleCheckbox ">
                                        <asp:RadioButton ID="rdbUnaproved" runat="server" GroupName="print" Checked="true" OnCheckedChanged="rdbUnaproved_CheckedChanged"
                                            AutoPostBack="true" />
                                        <asp:Label ID="Label3" AssociatedControlID="rdbUnaproved" runat="server"
                                            Text="Pending Voucher's" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>
                                    <div class="SingleCheckbox margin_left1">
                                        <asp:RadioButton ID="rdbChecked" runat="server" GroupName="print"
                                            OnCheckedChanged="rdbChecked_CheckedChanged" AutoPostBack="true" />
                                        <asp:Label ID="Label4" AssociatedControlID="rdbChecked" runat="server"
                                            Text="Checked Voucher's" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>
                                    <div class="SingleCheckbox margin_left2">
                                        <asp:RadioButton ID="rdbAproved" runat="server" GroupName="print"
                                            OnCheckedChanged="rdbAproved_CheckedChanged" AutoPostBack="true" />
                                        <asp:Label ID="Label2" AssociatedControlID="rdbAproved" runat="server"
                                            Text="Approved Voucher's" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>
                                </div>
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:Panel ID="Panel1" runat="server" Style="padding: 10px" class="messagePanel"
                                        Visible="false">
                                        <asp:Label ID="Label1" runat="server" Text="message"></asp:Label>
                                    </asp:Panel>
                                    <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                        AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                        CellPadding="0" PageSize="50" DataKeyNames="Voucher_No,Voucher_Date,Narration" OnRowDataBound="OnRowDataBound"
                                        OnSelectedIndexChanged="OnSelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="Voucher_No" HeaderText="Voucher No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Voucher_Date" HeaderText="Voucher Date" DataFormatString="{0:MM/dd/yyyy}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Dr" HeaderText="Dr." DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cr" HeaderText="Cr." DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Narration" HeaderText="Narration">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="50%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnView" runat="server" ToolTip="View Details" CommandName="Select">
                                                        <img src="../Resources/details-icon.png" width="18"/>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="3%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <HeaderTemplate>
                                                    <div class="GridCheckbox_ ">
                                                        <asp:CheckBox ID="chkbxEditAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(0,0)" />
                                                        <asp:Label ID="LabelEdit" AssociatedControlID="chkbxEditAll_" runat="server"
                                                            Text="All" CssClass="CheckBoxLabel"></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="GridCheckbox ">
                                                        <asp:CheckBox ID="chkbxEditItem_" runat="server" onclick="Edit(0, 0)" Enabled="true" />
                                                        <asp:Label ID="LabelStatus" AssociatedControlID="chkbxEditItem_" runat="server" ForeColor="Black"
                                                            Text="!" CssClass="CheckBoxLabel"></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                    </asp:GridView>

                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <%-------------Panel--------------%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
