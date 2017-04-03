<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="ShipmentCompleteList.aspx.cs" Inherits="ERPSSL.BuyingHouse.ShipmentCompleteList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Shipment Complete List 
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <div class="col-md-9">
                    <div class="col-md-5">
                        <div class="col-md-2">From</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>

                        <%-- // OnTextChanged="txtDate_TextChanged"--%>
                    </div>
                    <div class="col-md-5">
                        <div class="col-md-2">To</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info " OnClick="btnSearch_Click"  />
                    </div>
                </div>

            </div>
            <div class="col-md-12" style="padding-top:5px; margin:0 auto;">
                <asp:GridView ID="grdShipment" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdShipment_PageIndexChanging">
                    <%--OnPageIndexChanging="gridviewSection_PageIndexChanging"--%>
                    <Columns>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="OrderNo" HeaderText="Article No">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Style" HeaderText="Style">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ColorSpecification" HeaderText="Color Specification">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="OrderQuantity" HeaderText="Qty.">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="right" Width="7%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>


                        <asp:BoundField DataField="FobQty" HeaderText="FOB ($)">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="right" Width="7%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalQty" HeaderText="Total Qty.">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="right" Width="7%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ShipmentDate" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Shipment Date">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ExtendShipmentDate" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Extended Shipment Date">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Shipment_Mode"  HeaderText="Shipment Mode">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CompShipmentDate" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Shipment Complete Date">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
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



    <script type="text/JavaScript">


        +
        function func(result) {
            if (result === 'Data Added Successfully') {
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
