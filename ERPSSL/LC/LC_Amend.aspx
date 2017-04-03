<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="LC_Amend.aspx.cs" Inherits="ERPSSL.LC.LC_Amend" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
        }

        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>LC / Contract Amend
                        </div>
                    </div>
                    <div class="row" style="margin: auto 0;">
                        <div class="col-md-12 bg-success">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-5" style="margin: auto 0;">
                            <div class="row">
                                <asp:TextBox ID="txtFillAotuLCNo" placeholder="Search By LC No." Width="97%" OnTextChanged="txtFillAotuLCNo_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtFillAotuLCNo"
                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                                <asp:HiddenField ID="HidLcNo" runat="server" />
                            </div>
                            <div style="z-index: 1; height: 300px; width: 100%; overflow: scroll; padding-top: 5px;">
                                <div class="row" style="margin: auto 0;">
                                    <asp:GridView ID="grdMasterLC" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="5" AllowPaging="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Sl No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("MlcID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LC No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLCNo" runat="server" Text='<%# Eval("LCNo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LC Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateofIssue" runat="server" Text='<%# Eval("DateofIssue","{0:dd/MM/yyyy}")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgButtonEidt_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7" style="margin: auto 0; background-color: #a7c5a7; padding-bottom: 10px;">
                            <div class="col-md-4" style="margin: auto 0;">
                                <div class="row">
                                    Sub Company<span style="color: red; font-size: 11px">*</span>
                                    <asp:DropDownList ID="ddlSubCompany" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    LC No. <span style="color: red; font-size: 11px">*</span>
                                    <asp:TextBox ID="txtLcNo" runat="server" Enabled="false" placeholder="LC No." class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Date of Issue <span style="color: red; font-size: 11px">*</span>
                                    <asp:TextBox ID="txtDateofIssue" runat="server" Enabled="false" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Date of Expiry
                                   <asp:TextBox ID="txtDateofExpiry" runat="server" Enabled="true" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateofExpiry"
                                        PopupButtonID="txtDateofExpiry" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    LC Issuing Bank
                                    <asp:TextBox ID="txtIssueBank" Width="208%" Enabled="false" runat="server" placeholder="" class="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4" style="margin: auto 0;">
                                <div class="row">
                                    Buyer Type
                                    <asp:DropDownList ID="ddlBuyerType" runat="server" Enabled="false" class="form-control">
                                        <asp:ListItem Text="---Select One---" Value="0"></asp:ListItem>
                                        <asp:ListItem>Foreign</asp:ListItem>
                                        <asp:ListItem>Local</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Buyer Name
                                    <asp:DropDownList ID="ddlBuyerName" Enabled="false" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Season
                                    <asp:TextBox ID="txtSeason" runat="server" Enabled="false" placeholder="Season" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    LC Qty
                                   <asp:TextBox ID="txtQty" runat="server" Enabled="false" placeholder="Qty" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4" style="margin: auto 0;">
                                <div class="row">
                                    <div class="col-md-12" style="padding: 0;">
                                       Actual LC Value
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtUSDV" runat="server" Enabled="false" placeholder="USD" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtBDTV" runat="server" Enabled="false" placeholder="BDT" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="padding: 0;">
                                       Total LC Value
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtTotalLCValueUSD" runat="server" Enabled="false" placeholder="USD" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtTotalLCValueBDT" runat="server" Enabled="false" placeholder="BDT" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    LC Amend Date
                                    <asp:TextBox ID="txtLCAmendDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLCAmendDate"
                                        PopupButtonID="txtLCAmendDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12" style="padding: 0;">
                                        LC Amend Value
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtLCAmend_USDValue" runat="server" placeholder="USD" class="form-control"
                                            OnTextChanged="txtLCAmend_USDValue_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtLCAmend_BDTValue" runat="server" placeholder="BDT" class="form-control"
                                            OnTextChanged="txtLCAmend_BDTValue_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12" style="padding: 0;">
                                        Total Amend Value
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtTotalAmend_USDValue" Enabled="false" runat="server" placeholder="USD" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:TextBox ID="txtTotalAmend_BDTValue" Enabled="false" runat="server" placeholder="BDT" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 8px;">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-9" style="padding: 0; padding-top: 11px;">
                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Save Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>

</asp:Content>
