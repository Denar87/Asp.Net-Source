<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="UndoDepreciation.aspx.cs" Inherits="ERPSSL.FA.UndoDepreciation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="row">


        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Depreciation Charge
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12 bg-success">
                Last Day of Depreciation Charge:
            <asp:Label ID="lblLastDepreciationDate" runat="server" Text=""></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-3">
                                    From Date
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFromDate"
                                        PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="col-md-4">
                                    <asp:HiddenField ID="hdfUndoDepreciation" runat="server" />
                                    <asp:Button ID="btnView" runat="server" Text="View Depreciation Data"
                                        class="btn btn-info" OnClick="btnView_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="grdDepreciationData" runat="server" ShowFooter="True" Width="100%"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="5"
                                BorderColor="#99CCFF" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933"
                                OnPageIndexChanging="grdUndoDepreciation_PageIndexChanging" PageSize="10">
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="AssetCode" HeaderText="Asset Code ">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DepDate" HeaderText="Date">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TDesc" HeaderText="Description">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="XDepreciationRate" HeaderText="Depreciation Rate">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="XACClosingBalance" HeaderText="Asset at Cost ClosingBalance">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="XADDepreciationCost" HeaderText="A/C Depreciation Cost">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TADDepreciationCost" HeaderText="Tax Depreciation Cost">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle CssClass="pagination01 pageback" />
                                <RowStyle CssClass="Grid_RowStyle" />
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="btnErase" runat="server" Text="Erase Depreciation"
                        class="btn btn-info" OnClick="btnErase_Click" />
                    <br />
                    <asp:Label ID="lblDepreciationStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
