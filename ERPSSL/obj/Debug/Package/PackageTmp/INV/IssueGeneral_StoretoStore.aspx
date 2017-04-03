<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="IssueGeneral_StoretoStore.aspx.cs" Inherits="ERPSSL.INV.IssueGeneral_StoretoStore" %>

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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>

            <div class="row" style="margin: 0 auto">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Goods Issue Note (GIN) - Store to Store
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        </center>
                    </div>
                    <div class="row" style="margin: 0 auto">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row" style="padding-bottom: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Store From<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlStore" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlStore"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store From"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Store To<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlStoreTo" Class="form-control" runat="server" OnSelectedIndexChanged="ddlStoreTo_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">---Select Store To---</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStoreTo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store To"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Department
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlDepartment" AutoPostBack="True" CssClass="form-control"
                                                        runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Receiver
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlReciver" CssClass="form-control" runat="server" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlReciver_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    E-ID
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtEID" CssClass="form-control" runat="server" AutoPostBack="true"
                                                        OnTextChanged="txtEID_TextChanged"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>--%>

                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Reference No.
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRefNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" Height="35px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-5">
                                        Date <a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                            PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Issue Date"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-5">
                                        GIN No. <a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtChalanNo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-5">
                                        Receiver E-ID
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtReceiverEID" placeholder="Receiver E-ID" Width="110%" OnTextChanged="txtReceiverEID_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCurrentEmployee"
                                            MinimumPrefixLength="1"
                                            CompletionInterval="100" EnableCaching="False"
                                            TargetControlID="txtReceiverEID"
                                            ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtReceiverName" Width="100%" placeholder="Receiver Name" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                        <asp:HiddenField ID="hIdEid" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-5">
                                        Company
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlSubCompany" Class="form-control" runat="server"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSubCompany"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Company"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <%-- <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtOrderNo" CssClass="form-control" runat="server" ReadOnly="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <%--  <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Issue Item
                </div>
            </div>--%>
                    <div class="row" style="padding-top: 8px; margin: 0 auto">
                        <div class="col-md-12">
                            <table class="table table-bordered">
                                <tr class="info">
                                    <td>Item Category
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" ControlToValidate="ddlItemGroup"
                                     ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Item
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true" ControlToValidate="ddlItemName"
                                    ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Unit</td>
                                    <td>Balance</td>
                                    <td>Issue Qty</td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:DropDownList ID="ddlItemGroup" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 250px">
                                        <asp:DropDownList ID="ddlItemName" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUnit" Text="0" Style="color: maroon" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBalanceQty" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIssueQty" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <%--<table class="table table-bordered">
                                    <thead>
                                        <tr class="info">
                                            <th>Item Category</th>
                                            <th>Item</th>
                                            <th>Unit</th>
                                            <th>Balance</th>
                                            <th>Issue Qty</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlItemGroup" AutoPostBack="True" CssClass="form-control" runat="server"
                                        OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlItemGroup"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Group"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlItemName" AutoPostBack="True" CssClass="form-control" runat="server"
                                        OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlItemName"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Name"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-12">
                                    <asp:TextBox ID="txtUnit" placeholder="Unit" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-12">
                                    <asp:TextBox placeholder="Bal.Qty" ID="txtBalanceQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-md-12">
                                    <asp:TextBox ID="txtIssueQty" placeholder="Iss.Qty" CssClass="form-control" AutoPostBack="true" runat="server" OnTextChanged="txtIssueQty_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtIssueQty"
                                        Display="Dynamic" ErrorMessage="Enter Issued Qty" ForeColor="Red" SetFocusOnError="True"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>--%>

                            <div class="col-md-1" style="width: 11%">
                            </div>
                            <div class="col-md-1" style="width: 11%">
                            </div>
                            <div class="col-md-1" style="width: 11%">
                            </div>
                            <div class="col-md-1" style="width: 9%">
                                <asp:TextBox ID="txtCPU" placeholder="CPU" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1" style="width: 9%">
                                <asp:TextBox placeholder="Total Cost" ID="txtTotalCost" Visible="false" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-1" style="margin: -10px -10px 0 0; float: right">
                                <asp:Button ID="BtnAdd" ValidationGroup="Group1" runat="server" Text="Add" class="btn btn-primary"
                                    OnClick="BtnAdd_Click" />
                            </div>

                            <%--</fieldset>--%>
                        </div>
                    </div>
                    <div class="row" style="margin: 0 auto">
                        <div class="col-md-12">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Item List</span></legend>
                                <asp:GridView ID="grvIssue" runat="server" AutoGenerateColumns="False" Width="100%"
                                    BorderColor="#E3F0FC" CellPadding="5" AutoGenerateSelectButton="False" OnRowDataBound="grvIssue_RowDataBound"
                                    HorizontalAlign="Left" OnRowCommand="grvIssue_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                Sl.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server"
                                                    Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="ChallanNo" HeaderText="Challan No.">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="GroupName" HeaderText="Group">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Brand" Visible="false" HeaderText="Brand">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="StyleSize" Visible="false" HeaderText="Style/Size">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Barcode" Visible="false" HeaderText="Barcode">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="CPU" HeaderText="CPU">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DPT_NAME" HeaderText="Department">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Reciever">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                        <asp:BoundField DataField="DeliveryQty" HeaderText="Delivery Qty.">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ChallanTotal" Visible="false" HeaderText="Total">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="BalanceQuanity" HeaderText="Balance Qty.">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButtonEdit" runat="server" ImageUrl="img/edit.png" CommandArgument='<%# Eval("Id") %>'
                                                    CommandName="edt" />
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_Delete.png" OnClientClick="return ConfirmDelete();" CommandName="dlt"
                                                    CommandArgument='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="pagination01 pageback" />
                                    <RowStyle CssClass="Grid_RowStyle" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <%--<PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />--%>
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>
                                <asp:Label ID="lblTotalCost" Visible="false" Style="float: right; margin-right: 80px;" runat="server" Text="" Font-Bold="true" Font-Size="12px" ForeColor="Maroon"></asp:Label>
                            </fieldset>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-7">
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlChalanNo" Visible="false" Class="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlChalanNo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1" style="padding-right: 0;">
                                <asp:Button ID="btnSave" runat="server" Text="Issue" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning pull-right" OnClick="btnPrint_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-12">
                        <rsweb:ReportViewer ID="ReportViewerS" AsyncRendering="False" interactivedeviceinfos="(Collection)"
                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>
                    </div>
                </div>
                <asp:HiddenField ID="hdnProductID" runat="server" />
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyleSize" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function ConfirmDelete() {
            var x = confirm("Do you want to delete this item?");
            if (x)
                return true;
            else
                return false;
        }


        function func(result) {
            if (result === 'Data Update Successfully.') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
        function func(result) {
            if (result === 'Issue information has been added temporarily. Please post.') {
                toastr.success(result);
            }
            else if (result === 'GIN issued successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>
</asp:Content>
