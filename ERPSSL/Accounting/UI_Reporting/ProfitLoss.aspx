<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="ProfitLoss.aspx.cs" Inherits="ERPSSL.Accounting.UI_Reporting.ProfitLoss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Profit & Loss
                    </h5>

                    <div class="buttonPanel">
                        <asp:ImageButton ID="btnGrpList" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/speech balloon.png"
                            Width="32px" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                            Width="32px" />
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <br />
                        <div class="messagePanel" style="padding-bottom: 10px">
                            <div id="lblMesssge" runat="server" class="alert alert-success">
                                <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <asp:GridView ID="dtg_list" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" EmptyDataText="No Record Found!"
                                Width="100%">
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
</asp:Content>
