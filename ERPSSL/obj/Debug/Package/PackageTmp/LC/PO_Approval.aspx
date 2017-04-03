﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="PO_Approval.aspx.cs" Inherits="ERPSSL.LC.PO_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxtoolkit:toolkitscriptmanager runat="Server" enablepagemethods="true" enablepartialrendering="true" id="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>

            <div class="row" style="margin: 0 auto">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>PO Approval
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>

                    <div class="row" style="margin: 0 auto">

                        <div class="col-md-12">
                            <div class="col-md-9">
                                <fieldset style="margin-right: 0px;">
                                    <%-- <legend style="line-height: 0;"><span style="background: #fff">Select Date</span></legend>--%>
                                    <div class="col-md-5">
                                        <div class="col-md-2">From</div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtFromDate"
                                                popupbuttonid="txtFromDate" format="MM/dd/yyyy" cssclass="ajax__calendar" enabled="True" />
                                        </div>

                                        <%-- // OnTextChanged="txtDate_TextChanged"--%>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="col-md-2">To</div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxtoolkit:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txtToDate"
                                                popupbuttonid="txtToDate" format="MM/dd/yyyy" cssclass="ajax__calendar" enabled="True" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info " OnClick="btnSearch_Click" />
                                    </div>
                                </fieldset>
                            </div>


                            <div class="row" style="margin: 0 auto;">
                                <div class="row" style="margin: 0 auto;">
                                    <div class="col-md-12">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">PO Summary List</div>
                                            <div class="panel-body">
                                                <%-- <fieldset>
                                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Estimated List</span></legend>--%>
                                                <asp:GridView ID="grvPOSummary" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowCommand="gridBackToBack_RowCommand"
                                                    BorderWidth="1px" AllowPaging="True">

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="PO No." Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPONo" runat="server" Text='<%# Bind("LC_PO_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="LC_PO_Date" HeaderText="PO Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Buyer_Name" HeaderText="Buyer Name">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Lc_Style" HeaderText="Style">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Lc_Order" HeaderText="Order No.">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <%--<asp:BoundField DataField="FinishGoods_Name" HeaderText="Item">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="FinishedGoods_Qty" HeaderText="Qty">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>--%>

                                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="link" runat="server" CommandName="View" CommandArgument='<%# Eval("LC_PO_No") %>'>
                                                                    <img id="Img2" src="~/img/list_edit.png" alt="View" runat="server" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                    <EmptyDataRowStyle ForeColor="Red" />
                                                    <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                    <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                                        Font-Bold="True" ForeColor="White" />
                                                    <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                                </asp:GridView>
                                                <%--</fieldset>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 8px; margin: 0 auto">
                                    <div class="col-md-12" style="padding-top: 0px">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">Item Details</div>
                                            <div class="panel-body">
                                                <asp:GridView ID="gridApprovalDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBuyerID" runat="server" Text='<%# Bind("Buyer_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitId" runat="server" Text='<%# Bind("UnitId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLc_Style" runat="server" Text='<%# Bind("Lc_Style") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLc_Order" runat="server" Text='<%# Bind("Lc_Order") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGroupId" runat="server" Text='<%# Bind("GroupId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSupplierCode" runat="server" Text='<%# Bind("SupplierCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                                <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                                <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                                <footerstyle cssclass="Grid_Footer" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" CssClass="Grid_Border" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ProductName" HeaderText="Description">
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                                Width="15%" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="GroupName" HeaderText="Group Name">
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                                Width="15%" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name">
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="LC_PO_Qty" HeaderText="PO Qty">
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="Approve Qty">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtApproveQty" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
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
                            </div>

                            <div class="row" style="padding-top: 8px;">
                                <div class="col-md-4">
                                    <%--style="margin-left: 30px;"--%>
                                    <div class="col-md-4">
                                        PO No.<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPONo" runat="server" placeholder="PO No." class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <%--style="margin-left: 30px;"--%>
                                    <div class="col-md-4">
                                        Approve Date<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                        <ajaxtoolkit:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtDate"
                                            popupbuttonid="txtDate" format="MM/dd/yyyy" cssclass="ajax__calendar" enabled="True" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <%--style="margin-left: 30px;"--%>
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnProcess" runat="server" Text="Process" class="btn btn-info pull-right" OnClick="btnProcess_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>

                        <%-- </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {

            if (result === 'Data Approved Successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }

    </script>


</asp:Content>