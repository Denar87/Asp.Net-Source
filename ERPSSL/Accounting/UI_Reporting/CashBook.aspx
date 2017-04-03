<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="CashBook.aspx.cs" Inherits="ERPSSL.Accounting.UI_Reporting.CashBook" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
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
            <%-------------Panel--------------%>
            <div class="span12">
                <br />
                <div class="col-xs-12 col-sm-6 widget-container-col">
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>Cash Book
                            </h5>
                            <ul class="SearchPanel">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        From:
                                        <asp:TextBox ID="dtpFrom" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="dtpFrom"
                                            PopupButtonID="dtpFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </label>
                                </li>
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        To:
                                        <asp:TextBox ID="dtpTo" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpTo"
                                            PopupButtonID="dtpTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/zoom77.png"
                                    Width="32px" OnClick="btnSearch_Click" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" />
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />
                                <div class="radio_panel_reporting">
                                    <div class="SingleCheckbox ">
                                        <asp:RadioButton ID="rdbViewdtod" runat="server" GroupName="print"
                                            OnCheckedChanged="rdbViewdtod_CheckedChanged"
                                            AutoPostBack="true" />
                                        <asp:Label ID="Label3" AssociatedControlID="rdbViewdtod" runat="server"
                                            Text="Periodic Records" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>

                                    <div class="SingleCheckbox margin_left">
                                        <asp:RadioButton ID="rdbViewAll" runat="server" GroupName="print" Checked="true" />
                                        <asp:Label ID="Label2" AssociatedControlID="rdbViewAll" runat="server"
                                            Text="All Record's" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>
                                </div>
                                <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                        AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                        CellPadding="1">
                                        <Columns>
                                            <asp:BoundField DataField="GroupName" HeaderText="Super Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AccountName" HeaderText="Ledger Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Debit" HeaderText="Dr." HeaderStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Credit" HeaderText="Cr." HeaderStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="DATE_JOINED" HeaderText="JOINED" DataFormatString="{0:MMMM d, yyyy}"
                                        HtmlEncode="false">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
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
                    </div>
                </div>
            </div>
            <%-------------Panel--------------%>
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
