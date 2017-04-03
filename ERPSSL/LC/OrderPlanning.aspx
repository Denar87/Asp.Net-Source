<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="OrderPlanning.aspx.cs" Inherits="ERPSSL.LC.OrderPlanning" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>

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

    <%--<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />--%>
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Order Sheet & Planning
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                    <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                        <fieldset>
                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Planning </span></legend>
                            <div class="col-md-6">
                                <div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Season
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlSeason" AutoPostBack="true" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            PO/Order
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlPoOrder" AutoPostBack="true" OnSelectedIndexChanged="ddlPoOrder_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                  <div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Article
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlArticle" AutoPostBack="true" OnSelectedIndexChanged="ddlArticle_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                             
                               

                            </div>
                            <div class="col-md-6" style="padding-bottom: 8px;">
                                 <div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Style
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStyle"  CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                             <asp:TextBox ID="txtAutoOrderId" runat="server"  Visible="false" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Item Category
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlItemCategory" CssClass="form-control" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 8px">
                                <div class="col-md-12">
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
                                            <%--<asp:BoundField DataField="ProductName" HeaderText="Description">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ProductName")+ " " + Eval("StyleSize")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="20%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="15%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%--  <asp:BoundField DataField="StyleSize" HeaderText="Style And Size">
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="15%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="BalanceQuanity" HeaderText="Balance">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Req Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQty" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
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
                                            <%--<asp:TemplateField HeaderText="Rate(BDT)">
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
                            <div class="row" style="padding-top: 8px">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">

                                        <asp:Button ID="btnSubmit" runat="server" Text="Add" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                                    </div>

                                </div>
                            </div>
                            <div class="row" style="padding-top:10px">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Details</span></legend>
                                    <asp:GridView ID="gridOrderPlanning" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowDeleting="gridOrderPlanning_RowDeleting"
                                        BorderWidth="1px" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderPlanningId" runat="server" Text='<%# Bind("OrderPlanningId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Qty" HeaderText="Qty">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CPU" HeaderText="Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USDRate" HeaderText="USD Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USDValue" HeaderText="USD Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <%-- <asp:BoundField DataField="BDTRate" HeaderText="BDT Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDTValue" HeaderText="BDT Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="TotalQty" HeaderText="Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                                                        ToolTip="Delete">
                                                        <img id="Img2" src="~/img/remove.png" alt="Delete" runat="server" />
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
                                    <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowDeleting="GridViewOrder_RowDeleting"
                                        BorderWidth="1px" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderPlanningId" runat="server" Text='<%# Bind("OrderPlanningId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Qty" HeaderText="Qty">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CPU" HeaderText="Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USDRate" HeaderText="USD Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="USDValue" HeaderText="USD Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <%-- <asp:BoundField DataField="BDTRate" HeaderText="BDT Rate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDTValue" HeaderText="BDT Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="TotalQty" HeaderText="Value">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                                                        ToolTip="Delete">
                                                        <img id="Img2" src="~/img/remove.png" alt="Delete" runat="server" />
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
                                </fieldset>
                                <div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-8" style="padding-right: 30px">

                                            <asp:Button ID="btnPost" runat="server" Text="Post" class="btn btn-primary pull-right" ValidationGroup="Group1" OnClick="btnPost_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </fieldset>
                    </div>
                   
                 
                    <%--<div class="col-md-4">
                        <fieldset>
                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Style Description</span></legend>
                            <asp:GridView ID="GridStyle" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowCommand="GridStyle_RowCommand"
                                BorderWidth="1px" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="OrderEntryID" HeaderText="Id" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="ReqNo" HeaderText="Requisition No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                    <asp:TemplateField HeaderText="Style">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkView" CommandArgument='<%#Eval("Style") %>'
                                                CommandName="Style">
                                                <asp:Label ID="lblStyle" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="8%" />
                                    </asp:TemplateField>

                                     <asp:BoundField DataField="Style" HeaderText="Style">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    <asp:BoundField DataField="ProductName" HeaderText="Name">
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

                    </div>--%>




                    <%-- <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 0px"><span style="background: #fff">Order Sheet</span></legend>
                                        <asp:GridView ID="GridorderSheet" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridorderSheet_RowCommand" DataKeyNames="OrderEntryID"
                                            PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
                                            <Columns>
                                                 <%-- <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnProductEdit" runat="server" ImageUrl="img/list_edit.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("OrderEntryID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Order No">
                                                    <ItemTemplate>
                                                   <asp:LinkButton runat="server"   ID="lnkView" CommandArgument='<%#Eval("OrderNo") %>'
                                                     CommandName="OrderNo"> <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderNo") %>'></asp:Label></asp:LinkButton>
                                                     </ItemTemplate>
                                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                        Width="8%" />
                                                   </asp:TemplateField>                                                
                                                <asp:BoundField DataField="OrderQuantity" HeaderText="Order Quantity">
                                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                        Width="15%" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                 <asp:TemplateField HeaderText="Shipment Date" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ShipmentDate") %>'></asp:Label>
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
                                    </fieldset>
                                </div>--%>
                </div>

            </div>
            <%-- <div class="row" style="margin-left: 5px; margin-right: 5px;">
                        <div class="col-md-12">
                            <fieldset>
                                <legend style="line-height: 0px"><span style="background: #fff">Order Sheet</span></legend>
                                <asp:GridView ID="grdProductInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                                    PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Brand" HeaderText="Brand">
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="15%" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Style/Size" DataField="StyleAndSize">
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="15%" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnProductEdit" runat="server" ImageUrl="img/list_edit.png" />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
                            </fieldset>
                        </div>
                    </div>--%>
        </div>
    </div>
    
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
