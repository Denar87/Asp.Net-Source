<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterLC.aspx.cs" Inherits="ERPSSL.LC.MasterLC" MasterPageFile="~/LC/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Master LC
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row" style="margin: auto 0;">
                        <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                            <div class="row">
                                <div class="col-md-6" style="margin: auto 0; padding: 0px;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Sub Company<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlSubCompany" class="form-control" runat="server"></asp:DropDownList>
                                                <asp:HiddenField ID="HidLcNo" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                LC No. <a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtLcNo" runat="server" placeholder="LC No." class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Date of Issue <a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDateofIssue" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateofIssue"
                                                    PopupButtonID="txtDateofIssue" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Date of Expiry<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDateofExpiry" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateofExpiry"
                                                    PopupButtonID="txtDateofExpiry" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                LC Issuing Bank<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtIssueBank" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtIssueBank"
                                                            PopupButtonID="txtDateofExpiry" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Buyer Type<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlBuyerType" OnSelectedIndexChanged="ddlBuyerType_SelectedIndexChanged" AutoPostBack="true"
                                                    class="form-control" runat="server">
                                                    <asp:ListItem Text="---Select One---" Value="0"></asp:ListItem>
                                                    <asp:ListItem>Foreign</asp:ListItem>
                                                    <asp:ListItem>Local</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12" style="padding-top: 0px">
                                            <div class="col-md-4">
                                                Buyer Name<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlBuyerName" OnSelectedIndexChanged="ddlBuyerName_SelectedIndexChanged" class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px"  runat="server" visible="false">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Season
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlSeason" runat="server" Width="110%" placeholder="Season" class="form-control"></asp:DropDownList>
                                                <asp:TextBox ID="txtSeason" runat="server" Visible="true" Width="110%" placeholder="Season" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1" style="margin-top: 7px;">
                                                <asp:CheckBox ID="chkSeason" runat="server" AutoPostBack="true" OnCheckedChanged="chkSeason_CheckedChanged" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                LC Qty
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtQty" runat="server" placeholder="Qty" class="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                LC Value
                                            </div>
                                            <div class="col-md-3">
                                                <div class="row">
                                                    <asp:TextBox ID="txtUSDV" runat="server" placeholder="USD" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="row" style="margin-left: -8px;">
                                                    <asp:TextBox ID="txtConvRate" runat="server" Width="110%" placeholder="Conv. Rate" AutoPostBack="true"
                                                        OnTextChanged="txtConvRate_TextChanged" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtBDTV" runat="server" Enabled="false" placeholder="BDT" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div class="row" style="padding-top: 5px">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    LC Amend Date
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtLCAmendDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLCAmendDate"
                                                        PopupButtonID="txtLCAmendDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                            </div>
                                        </div>--%>
                                    <%--<div class="row" style="padding-top: 5px">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    LC Amend Value
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="row">
                                                        <asp:TextBox ID="txtLCAmend_USDValue" runat="server" placeholder="USD" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtLCAmend_BDTValue" runat="server" placeholder="BDT" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>--%>
                                    <%--<div class="row" style="padding-top: 5px">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Total Amend Value
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="row">
                                                        <asp:TextBox ID="txtTotalAmend_USDValue" runat="server" Enabled="false" placeholder="USD" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtTotalAmend_BDTValue" runat="server" Enabled="false" placeholder="BDT" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>--%>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1"
                                            OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px; margin-left: 10px; margin-right: 10px;">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFillAotuLCNo" placeholder="Search By LC No." Width="100%" OnTextChanged="txtFillAotuLCNo_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtFillAotuLCNo"
                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            <asp:GridView ID="grdMasterLC" runat="server" Width="100%" AutoGenerateColumns="False"
                                PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
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

                                    <asp:TemplateField HeaderText="LC Date Issue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateofIssue" runat="server" Text='<%# Eval("DateofIssue","{0:dd/MM/yyyy}")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="LC Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLCType" runat="server" Text='<%# Eval("LCType")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date of Expiry">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateofExpiry" runat="server" Text='<%# Eval("DateofExpiry","{0:dd/MM/yyyy}")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Season" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSeason" runat="server" Text='<%# Eval("Season")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgButtonEidt_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle CssClass="pagination01 pageback" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
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
