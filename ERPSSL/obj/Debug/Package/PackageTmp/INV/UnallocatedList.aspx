<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="UnallocatedList.aspx.cs" Inherits="ERPSSL.INV.UnallocatedList" %>

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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Unallocated List
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">

                        <div class="col-md-12" runat="server" id="ShowDiv" visible="false" style="margin: auto 0; padding: 0; margin-left: -10px;">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Store & Company<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlStore" Class="form-control" Enabled="false" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                <asp:HiddenField ID="HidBuyCentralID" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Supplier<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlSupplier" Class="form-control" runat="server" AutoPostBack="True" Enabled="false"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Ref.No./Challan No.<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtRefNo" Class="form-control" ReadOnly="true" placeholder="Ref.No./ Challan No." runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                   
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Order
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlOrder" Class="form-control" placeholder="Order" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Master L/C No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtMasterLCNo" Class="form-control" runat="server" placeholder="Master L/C No."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Date<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox Class="form-control" Enabled="false" runat="server" ID="txtDate" autocomplete="off"
                                                    placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                MRR No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox Class="form-control" runat="server" placeholder="MRR No." ID="txtMRRNo" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                   
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                B2B L/C No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtB2BLCNo" Class="form-control" runat="server" placeholder="B2B L/C No."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            P.I. No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPINo" Class="form-control" runat="server" placeholder="P. I. No"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Receiver E-ID
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtReceiverEID" Enabled="false" placeholder="Receiver E-ID" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <%--<div class="col-md-5">
                                                <asp:TextBox ID="txtReceiverName" Width="100%" placeholder="Receiver Name" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hIdEid" runat="server" />
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding-top:5px; margin-left: -10px;"">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Style="margin-right: 5px;" CssClass="btn btn-info pull-right" OnClick="btnUpdate_Click"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="padding-top: 10px;">
                            <div class="col-md-2">
                                Challan No.
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtChallanRefNo" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtChallanRefNo_TextChanged" Placeholder="Challan No."></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchChallanNo"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtChallanRefNo"
                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                            </div>
                            <div class="col-md-5">
                            </div>
                        </div>
                        <div class="col-md-12" style="padding-top: 3px;">
                            <div class="row" style="margin: auto 0;">
                                <asp:GridView ID="grdUnit" runat="server" Width="98%"
                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="20"
                                    BorderColor="#E3F0FC" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933"
                                    PageSize="10" OnPageIndexChanging="grdUnit_PageIndexChanging">
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStore_Id" runat="server" Text='<%# Eval("Store_Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupplierCode" runat="server" Text='<%# Eval("SupplierCode")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefNo_ChallanNo" runat="server" Text='<%# Eval("RefNo_ChallanNo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeasonID" runat="server" Text='<%# Eval("SeasonID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderEId" runat="server" Text='<%# Eval("OrderEId")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPurchaseDate" runat="server" Text='<%# Eval("PurchaseDate")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChallanNo" runat="server" Text='<%# Eval("ChallanNo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMasterLCNo" runat="server" Text='<%# Eval("MasterLCNo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB2BLCNo" runat="server" Text='<%# Eval("B2BLCNo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="RefNo_ChallanNo" HeaderText="Challan No">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ChallanNo" HeaderText="MRR No.">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Brand" HeaderText="Brand">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="StyleSize" HeaderText="Style">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReceiveQuantity" HeaderText="Quantity">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgUnitEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgUnitEdit_Click" />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="pagination01 pageback" />
                                    <RowStyle CssClass="Grid_RowStyle" />
                                </asp:GridView>
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
            else if (result === 'Data Saving Failure') {
                toastr.error(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>
</asp:Content>
