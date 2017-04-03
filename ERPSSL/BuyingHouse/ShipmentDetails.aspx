<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="ShipmentDetails.aspx.cs" Inherits="ERPSSL.BuyingHouse.ShipmentDetails" %>


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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Shipment Details
                        </div>
                    </div>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true" childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Order Details" ID="TabPanel1" OnDemandMode="None">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6" style="padding: 0;">
                                                <fieldset>
                                                    <asp:HiddenField ID="hidorderid" runat="server" />
                                                    <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Details</span></legend>
                                                    <div class="col-md-12" style="overflow-x: hidden; overflow-y: scroll; height: auto; padding: 0;">
                                                        <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                            BorderWidth="1px" AllowPaging="false">
                                                            <Columns>
                                                                <asp:BoundField DataField="OrderEntryID" HeaderText="Id" Visible="false"></asp:BoundField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOrderEntryID" runat="server" Text='<%# Eval("OrderEntryID")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Order_No" HeaderText="Order No">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <%-- ---------------------------------- --%>
                                                                <asp:BoundField DataField="Total_Amount" HeaderText="Total Amount" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="FobQty" HeaderText="FobQty" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="SeasonName" HeaderText="Season Name" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Buyer_Department" HeaderText="Buyer Department" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Yarn_Fabrication" HeaderText="Yarn_Fabrication" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="FOB_Port" HeaderText="FOB_Port" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Shipment_Mode" HeaderText="Shipment_Mode" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="FactoryName" HeaderText="Factory Name" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Gender" HeaderText="Gender Name" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Countryof_Production" HeaderText="Country" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="UnitName" HeaderText="Unit_Name" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Style_Category" HeaderText="Style Category" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Gender" HeaderText="Gender Name" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Countryof_Production" HeaderText="Country" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="Buyer_Department" HeaderText="Department" Visible="false"></asp:BoundField>
                                                                <asp:BoundField DataField="FullName" HeaderText="Merchandiser Name" Visible="false"></asp:BoundField>
                                                                <%-- ---------------------------------- --%>
                                                                <asp:BoundField DataField="Style_Description" HeaderText="Style">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PrincipalName" HeaderText="Principal">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Buyer_Name" HeaderText="Buyer">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <%--<asp:BoundField DataField="OrderQuantity" HeaderText="Order Qty">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                                <asp:BoundField DataField="OrderQuantity" HeaderText="Order Qty">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ShipmentDate" HeaderText="Shipment Date" DataFormatString="{0:MM/dd/yyyy}">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="View">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgbtnOrderSheetView" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnOrderSheetView_Click" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                            <EmptyDataRowStyle ForeColor="Red" />
                                                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                            <PagerSettings Mode="NumericFirstLast" />
                                                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                                        </asp:GridView>

                                                    </div>
                                                </fieldset>
                                            </div>
                                            <div class="col-md-6" style="padding: 0;" id="showInfo" runat="server" visible="false">
                                                <div class="row" style="padding-top: 15px;">
                                                    <div class="col-md-6" style="padding: 0;">
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Order No
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblOrderNo" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Principal
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblPrincipal" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Order Qty
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblOrderQty" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Total Amount
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblTotal_Amount" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                FobQty
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblFobQty" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                SeasonName
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblSeasonName" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Shipment_Mode
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblShipment_Mode" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                FactoryName
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblFactoryName" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Gender
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblGender" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6" style="padding: 0;">
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Style
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblStyle" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Buyer
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblBuyer" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Shipment Date
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblShipmentDate" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Department
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblBuyer_Department" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Yarn Fabrication
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblYarn_Fabrication" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                FOB Port
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblFOB_Port" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Country
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblCountryof_Production" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Style_Category
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblStyle_Category" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <div class="col-md-5">
                                                                Name
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:Label ID="lblFullName" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 10px;">
                                                            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-info" ValidationGroup="Group1" OnClick="btnNext_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Shipment Complete" ID="TabPanel2" OnDemandMode="None">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="row" style="padding-top: 5px;" runat="server" id="ShowOrderDiv" visible="false">
                                            <div class="col-md-2">
                                                Order No : 
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Label ID="lblOrderNoLoad" runat="server" Font-Bold="true" ForeColor="Maroon" Font-Size="1em"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row" style="background-color: silver; padding-top:5px; padding-bottom: 10px; margin: auto 0;">
                                            <div class="col-md-3">
                                                <div class="row">
                                                    LC Number
                                                                <asp:HiddenField ID="hidPOrderNo" runat="server" />
                                                    <asp:TextBox ID="txtLCNumber" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                                    LC Receive Date
                                                    <asp:TextBox ID="txtLCReceiveDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLCReceiveDate"
                                                        PopupButtonID="txtLCReceiveDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    Feeder Vessel
                                                    <asp:TextBox ID="txtFeederVessel" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    FETD
                                                     <asp:TextBox ID="txtETD" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtETD"
                                                        PopupButtonID="txtETD" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    FETA
                                                     <asp:TextBox ID="txtETA" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtETA"
                                                        PopupButtonID="txtETA" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    Actual Ship Quantity
                                                     <asp:TextBox ID="txtActualShipQuantity" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Packing List Number
                                                    <asp:TextBox ID="txtPackingListNumber" Class="form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="row">
                                                    AirwayBill/Cargo Receipt No./BL No.
                                                    <asp:TextBox ID="txtAirwayBill" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Export License Number
                                                    <asp:TextBox ID="txtExportLicenseNumber" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    GSP Form A
                                                    <asp:TextBox ID="txtGSPForm" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Courier Number
                                                    <asp:TextBox ID="txtCourierNumber" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Debit Note No.
                                                    <asp:TextBox ID="txtDebitNoteNo" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Document Receive Date
                                                    <asp:TextBox ID="txtDocumentReceiveDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtDocumentReceiveDate"
                                                        PopupButtonID="txtDocumentReceiveDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    Other
                                                    <asp:TextBox ID="txtOther" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="row">
                                                    Actual FCR Date
                                                    <asp:TextBox ID="txtActualFCRDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtActualFCRDate"
                                                        PopupButtonID="txtActualFCRDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    LC Date
                                                    <asp:TextBox ID="txtLCDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtLCDate"
                                                        PopupButtonID="txtLCDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    LC Expiry Date
                                                    <asp:TextBox ID="txtLCExpiryDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtLCExpiryDate"
                                                        PopupButtonID="txtLCExpiryDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    Mother Vessel
                                                    <asp:TextBox ID="txtMotherVessel" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    METD
                                                    <asp:TextBox ID="txtETD1" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtETD1"
                                                        PopupButtonID="txtETD1" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    META
                                                    <asp:TextBox ID="txtETA1" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtETA1"
                                                        PopupButtonID="txtETA1" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="row">
                                                    Invoice Number
                                                    <asp:TextBox ID="txtInvoiceNumber" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Container Number
                                                    <asp:TextBox ID="txtContainerNumber" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Certificate Of Origin
                                                    <asp:TextBox ID="txtCertificateOfOrigin" Class="form-control2 form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Commission Rate
                                                    <asp:TextBox ID="txtCommissionRate" Class="form-control2 form-control" runat="server" Text="0"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Courier Date
                                                    <asp:TextBox ID="txtCourierDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtCourierDate"
                                                        PopupButtonID="txtCourierDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                                <div class="row">
                                                    Inspection Certification No
                                                    <asp:TextBox ID="txtInspectionCertificationNo" Class="form-control2 form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="row" style="margin-top: 5px;">
                                                    <asp:HiddenField ID="hidshipmentid" runat="server" />
                                                    <asp:Button ID="btnShipment" runat="server" Text="Save" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnShipment_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-top:5px;">
                                            <asp:GridView ID="gridShipment" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundField DataField="Shipment_Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblShipment_Id" runat="server" Text='<%# Eval("Shipment_Id")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PO_No" HeaderText="P.O No">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="LC_No" HeaderText="LC Number">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="LC_ReceiveDate" HeaderText="LC ReceiveDate">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Feeder_Vessel" HeaderText="Feeder Vessel">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Actual_Ship_Qty" HeaderText="Actual Shipv Qty">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="LC_Expiry_Date" HeaderText="LC Expiry Date" DataFormatString="{0:dd MMM, yyyy}" HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Update">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnShipmentEdit" runat="server" ImageUrl="img/list_edit.png"
                                                                OnClick="imgbtnShipmentEdit_Click" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                                    Font-Bold="True" ForeColor="White" />
                                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#275353" />
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
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
