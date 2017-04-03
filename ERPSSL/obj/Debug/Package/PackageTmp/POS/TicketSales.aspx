<%@ Page Title="" Language="C#" MasterPageFile="~/POS/Site.Master" AutoEventWireup="true" CodeBehind="TicketSales.aspx.cs" Inherits="ERPSSL.POS.TicketSales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="row">

        <div class="box col-md-12">
            <div class="box-inner">

                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Customer Reports
                        </div>
                    </div>
                    <div class="col-md-12">
                        <%--<asp:Label ID="msgLabel" runat="server" ForeColor="#00CC66"></asp:Label>--%>

                        <div class="row">

                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 0px;"><span style="background: #fff">Select Date to Date</span></legend>
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <h5 style="padding-left: 20px">From
                                                    </h5>
                                                    <div class="col-md-12">
                                                        <asp:TextBox runat="server" ID="txtbxFrom" Class="form-control" placeholder="MM/dd/yyyy" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxFrom"
                                                            PopupButtonID="txtbxFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <h5 style="padding-left: 20px">To
                                                    </h5>
                                                    <div class="col-md-12">
                                                        <asp:TextBox runat="server" ID="txtbxTo" Class="form-control" placeholder="MM/dd/yyyy" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxTo"
                                                            PopupButtonID="txtbxTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <%--  <h5 style="padding-left: 20px">Ticket Type
                                                    </h5>--%>
                                                    <div class="col-md-12">
                                                        <asp:DropDownList ID="ddlTicketType" AutoPostBack="True" CssClass="form-control"
                                                            runat="server" OnSelectedIndexChanged="ddlTicketType_SelectedIndexChanged" Visible="false">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <%--<h5 style="padding-left: 20px">Food Type
                                                    </h5>--%>
                                                    <div class="col-md-12">
                                                        <asp:DropDownList ID="ddlFoodType" AutoPostBack="True" CssClass="form-control"
                                                            Visible="false" runat="server" OnSelectedIndexChanged="ddlFoodType_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 0;"><span style="background: #fff">Report Type</span></legend>
                                        <div style="padding: 10px">
                                            <asp:RadioButton ID="rdbItemWiseSummery" runat="server" Text="User wise Ticket Sales Summary" GroupName="rpt_Sale" Checked="true" />
                                            <br />
                                            <asp:RadioButton ID="rdbFoodWiseSummery" runat="server" Text="User wise Food Sales Summary" GroupName="rpt_Sale" />
                                            <br />
                                            <asp:RadioButton ID="rdbUserwiseISSummery" runat="server" Text="User Wise Income Statement" GroupName="rpt_Sale" />
                                            <br />
                                            <asp:RadioButton ID="rdballInvoicesaleforTicket" runat="server" Text="All Invoice Ticket Sales Summary" GroupName="rpt_Sale" />
                                            <br />
                                            <asp:RadioButton ID="rdballInvoicesaleforFood" runat="server" Text="All Invoice Food Sales Summary" GroupName="rpt_Sale" />
                                            <br />
                                            <asp:RadioButton ID="rdbcatagorywiseIncomeStatement" runat="server" Text="All Category Wise Income Statment" GroupName="rpt_Sale" />
                                            <br />
                                            <asp:RadioButton ID="rdbTicketSale" runat="server" Text="Ticket Sale" GroupName="rpt_Sale" Visible="False" />
                                            <br />
                                            <asp:RadioButton ID="rdbFoodSale" runat="server" Text="Food Sale" GroupName="rpt_Sale" Visible="False" />
                                            <br />
                                        </div>
                                    </fieldset>
                                    <div class="col-md-6 " style="margin-top: 8px;">
                                        <asp:Button ID="btnProcess" runat="server" Text="Process" Width="80px"
                                            CssClass="btn btn-info" OnClick="btnProcess_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
