﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="B2B_LC.aspx.cs" Inherits="ERPSSL.LC.B2B_LC" %>

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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ToolkitScriptManager1" />


    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>B2B LC 
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row" style="margin: 0 auto">
                        <%-- <div class="col-md-12" style="margin: auto 0; padding: 0px;">--%>
                        <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">B2B LC</span></legend>
                                <div style="padding-left: 30px">
                                    <asp:RadioButton ID="rdbForeign" GroupName="ll" Checked="true" Text="Foreign" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdbLocal" Text="Local" GroupName="ll" runat="server" />
                                </div>
                                <div class="row" style="margin-right: 30px;">
                                    <div class="col-md-4">
                                        <div class="row">
                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">PI</div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPI" runat="server" placeholder="  PI" class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        PI Date<a style="color: red; font-size: 11px">*</a>

                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPIDate" runat="server" placeholder="PI Date" class="form-control"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPIDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPIDate"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                                            Font-Size="11px" ErrorMessage="Select Date"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">Master LC </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtMasterLC" runat="server" placeholder=" Master LC" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">Season</div>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlSeason" AutoPostBack="true" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="row" style="padding-top: 8px">
                                            <div class="row">
                                                <div class="col-md-3">PO/order</div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlPoOrder" AutoPostBack="true" OnSelectedIndexChanged="ddlPoOrder_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-top: 8px">
                                            <div class="row">
                                                <div class="col-md-3">Article</div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlArticle" AutoPostBack="true" OnSelectedIndexChanged="ddlArticle_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px">
                                            <div class="row">
                                                <div class="col-md-3">Style</div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlStyle" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row" style="padding-top: 8px">
                                            <div class="row">
                                                <div class="col-md-3">BBLC Date </div>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtB2BLCDate" runat="server" placeholder="BBLC Date" class="form-control"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtB2BLCDate"
                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                            </div>
                                        </div>




                                    </div>

                                    <div class="col-md-4">
                                        <div class="row">
                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">BBLC No.</div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtB2BLCNo" runat="server" placeholder="B2B LC No." class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        BBLC Shipment Date<a style="color: red; font-size: 11px">*</a>

                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtBBLCDate" runat="server" placeholder="BBLC Date" class="form-control"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBBLCDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBBLCDate"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                                            Font-Size="11px" ErrorMessage="Select Date"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Expire Date<a style="color: red; font-size: 11px">*</a>

                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtExpireDate" runat="server" placeholder="Expire Date" class="form-control"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtExpireDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExpireDate"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                                            Font-Size="11px" ErrorMessage="Select Date"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">Sight days interest</div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtSigntDayInterest" runat="server" placeholder="Sight Day" class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                    </div>
                                                    <div class="col-md-9">
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <fieldset style="background-color: #BDBDBD">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-3">Supplier</div>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlSupplier" CssClass="form-control" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtAutoChallanId" runat="server" Visible="false" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-3">Item Category</div>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="drpItemCategory" AutoPostBack="true" OnSelectedIndexChanged="drpItemCategory_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>






                                    <div class="row" style="padding-top: 8px">
                                        <div class="col-md-12" style="padding-top: 8px">
                                            <asp:GridView ID="grvOrderSheetEntry" runat="server" Width="100%" AutoGenerateColumns="False"
                                                PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Id" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCpu" runat="server" Text='<%# Bind("CPU") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Bind("BalanceQuanity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitName" runat="server" Text='<%# Bind("UnitName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStyleSize" runat="server" Text='<%# Bind("StyleSize") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBrand" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
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
                                                    <asp:BoundField DataField="StyleSize" HeaderText="Style And Size">
                                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                            Width="15%" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="BalanceQuanity" HeaderText="Balance">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Req Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate($)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtUSDRate" runat="server" Width="100%" OnTextChanged="txtUSDRate_TextChanged" AutoPostBack="true" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value($)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Rate(BDT)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtBDTRate" runat="server" Width="100%" OnTextChanged="txtBDTRate_TextChanged" AutoPostBack="true" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value(BDT)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBDTValue" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>--%>
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
                                <div class="row" style="padding-top: 8px;">
                                    <div class="col-md-12">
                                        <%--style="margin-left: 30px;"--%>
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-8">

                                            <asp:Button ID="btnProcess" runat="server" Text="Post" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnProcess_Click" />&ensp;&ensp;
                                             <asp:Button ID="btnSubmit" runat="server" Text="Add" class="btn btn-primary pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Details</span></legend>
                                    <asp:GridView ID="gridOrderPlanning" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                        BorderWidth="1px" AllowPaging="True">

                                        <Columns>

                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderPlanningId" runat="server" Text='<%# Bind("OrderPlanningId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Article" HeaderText="Article">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Style" HeaderText="Style">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Qty" HeaderText="Qty">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CPU" HeaderText="Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalQty" HeaderText="Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%-- <asp:TemplateField HeaderText="Delete" >
                                         <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                                                        ToolTip="Delete">
                                                        <img id="Img2" src="~/img/remove.png" alt="Delete" runat="server" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                              </asp:TemplateField>--%>
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
                                </fieldset>
                            </div>

                            <div class="col-md-6" style="padding-top: 8px">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Back To Back Details</span></legend>
                                    <asp:GridView ID="GridBackToBack" runat="server" Width="100%" AutoGenerateColumns="False"
                                        PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
                                        <Columns>


                                            <asp:BoundField DataField="ProductName" HeaderText="Description">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="15%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="StyleSize" HeaderText="Style And Size">
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="15%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ReqQty" HeaderText="Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USDRate" HeaderText="USD Rate">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USDValue" HeaderText="USD Value">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="BDTRate" HeaderText="BDT Rate">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDTValue" HeaderText="BDT Value">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="pagination01 pageback" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:GridView>
                                </fieldset>
                            </div>

                        </div>

                        <%-- </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Sucessfully') {
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
