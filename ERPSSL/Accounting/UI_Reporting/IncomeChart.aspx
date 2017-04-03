<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="IncomeChart.aspx.cs" Inherits="ERPSSL.Accounting.UI_Reporting.IncomeChart" ClientIDMode="Static" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400"/>
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
                                <i class="ace-icon fa fa-table"></i>Account Charting
                            </h5>
                            <ul class="SearchPanel">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        From:
                                        <asp:TextBox ID="dtpFrom" runat="server" placeholder="MM/dd/yyyy" Enabled="False"></asp:TextBox>
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
                                <div style="position: relative">
                                    <div class="radio_panel_reporting">
                                        <div class="SingleCheckbox ">
                                            <asp:RadioButton ID="rdbViewdMonthly" runat="server" GroupName="print"
                                                OnCheckedChanged="rdbViewdMonthly_CheckedChanged"
                                                AutoPostBack="true" />
                                            <asp:Label ID="Label3" AssociatedControlID="rdbViewdMonthly" runat="server"
                                                Text="Monthly Chart" CssClass="CheckBoxLabel"></asp:Label>
                                        </div>

                                        <div class="SingleCheckbox margin_left">
                                            <asp:RadioButton ID="rdbViewYearly" runat="server" GroupName="print"
                                                OnCheckedChanged="rdbViewYearly_CheckedChanged" AutoPostBack="true"
                                                Checked="true" />
                                            <asp:Label ID="Label2" AssociatedControlID="rdbViewYearly" runat="server"
                                                Text="Yearly Chart" CssClass="CheckBoxLabel"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="height: 410px; overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:Literal ID="lt" runat="server"></asp:Literal>
                                    <div id="chart_div"></div>
                                    <div id="piechart" style="background:#fff;border:1px solid #eee;margin-top:7px;"></div>
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
</asp:Content>
