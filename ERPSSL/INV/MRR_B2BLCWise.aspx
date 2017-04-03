<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="MRR_B2BLCWise.aspx.cs" Inherits="ERPSSL.INV.MRR_B2BLCWise" %>

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
            <div class="row" >
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>MRR LC Wise
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row" style="margin:0 auto">
                        <%-- <div class="col-md-12" style="margin: auto 0; padding: 0px;">--%>
                        <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                           
                                
                                <div class="row" style="margin-right: 30px;">
                                <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">LC List</span></legend>
                                    <asp:GridView ID="gridBackToBack" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowCommand="gridBackToBack_RowCommand"
                                        BorderWidth="1px" AllowPaging="True">

                                        <Columns>

                                           <%-- <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblB2BId" runat="server" Text='<%# Bind("B2BId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             <asp:BoundField DataField="MasterLCNo" HeaderText="MasterLC">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="B2BLCNo" HeaderText="B2BLC No">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BBLCDate" HeaderText="BBLC Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Season" HeaderText="Season">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="POOrderNo" HeaderText="PO Order No">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="PI" HeaderText="PI">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="ExpireDate" HeaderText="Expire Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="PIDate" HeaderText="PI Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                             <asp:TemplateField HeaderText="Select" >
                                         <ItemTemplate>
                                                    <asp:LinkButton ID="link" runat="server"  commandname="Select" commandargument='<%# Eval("B2BLCNo") %>'>
                                                        <img id="Img2"  src="~/img/list_edit.png" alt="Select" runat="server" />
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
                            </div>

                        

                        </div>
                  
                                    <div class="row" style="padding-top: 8px">
                                        <div class="col-md-12" style="padding-top: 8px">
                                            <asp:GridView ID="grvOrderSheetEntry" runat="server" Width="100%" AutoGenerateColumns="False"
                                                PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Id" runat="server" Text='<%# Bind("B2BId") %>'></asp:Label>
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
                                                            <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Bind("ReqQty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   <%-- <asp:TemplateField HeaderText="Id" Visible="False">
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
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                            <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="rowLevelCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="rowLevelCheckBox_CheckedChanged" />
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
                                                    <asp:BoundField DataField="ReqQty" HeaderText="Req Qty">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="USDRate" HeaderText="USDRate">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="USDValue" HeaderText="USDValue">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="BDTRate" HeaderText="BDTRate">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="BDTValue" HeaderText="BDTValue">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                   <asp:TemplateField HeaderText="Received Qty"  ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtReceivedQty" runat="server"></asp:TextBox>
                                                        <headerstyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <itemstyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    </ItemTemplate>
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
                                <div class="row" style="padding-top: 8px;">
                                     <%--<div class="col-md-4">
                                        <%--style="margin-left: 30px;"
                                        <div class="col-md-4">
                                            Acceptance No<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">

                                             <asp:TextBox ID="txtAccNo" runat="server" placeholder="Acceptance No" class="form-control"></asp:TextBox>
                                             
                                        </div>
                                    </div>--%>
                                     <%--<div class="col-md-4">
                                        <%--style="margin-left: 30px;"
                                        <div class="col-md-4">
                                            Acceptance Date<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">
                                             <asp:TextBox ID="txtDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                           <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                            PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />                                           
                                            
                                        </div>
                                    </div>--%>
                                    <div class="col-md-12">
                                        <%--style="margin-left: 30px;"--%>
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-8" style="padding-right:40px;">

                                            <asp:Button ID="btnProcess" runat="server" Text="Process"  class="btn btn-info pull-right" OnClick="btnProcess_Click"  />
                                            
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
            else if (result === 'Data recorded successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>


</asp:Content>
