<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Sample_Update.aspx.cs" Inherits="ERPSSL.BuyingHouse.Sample_Update" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="JavaScript" type="text/JavaScript">
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

    <%--  <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Sample Update
                </div>
            </div>
            <div class="row" style="margin: auto 0;">
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>

                <div class="col-md-12" id="DivUpdate" runat="server" style="padding: 0; padding-right: 7px; margin: auto 0;">
                    <div class="col-md-3" style="margin: auto 0;">
                        <div class="row">
                            Buyer 
                                        <asp:DropDownList ID="ddlBuyer" runat="server" Enabled="false" class="form-control"></asp:DropDownList>
                            <asp:HiddenField ID="HidId" runat="server" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Factory
                                        <asp:DropDownList ID="ddlFactoryMame" runat="server" Enabled="false" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Pre Order No.
                                        <asp:TextBox ID="txtPreOrderNo" runat="server" Enabled="false" placeholder="Pre Order No." class="form-control"></asp:TextBox>
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Sample Date
                                        <asp:TextBox ID="txtSampleDate" runat="server" Enabled="false" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSampleDate"
                                PopupButtonID="txtSampleDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Sample Specification
                                        <asp:TextBox ID="txtSampleSpecification" runat="server" Enabled="false" placeholder="Sample Specification" class="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="col-md-3" style="margin: auto 0;">
                        <div class="row">
                            1st Sample Sent Date
                                    <asp:TextBox ID="txt1stSampleSentDate" Enabled="false" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt1stSampleSentDate"
                                PopupButtonID="txt1stSampleSentDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Modification Receive Date 
                                        <asp:TextBox ID="txtModiReceiveDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtModiReceiveDate"
                                PopupButtonID="txtModiReceiveDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>

                        <div class="row" style="padding-top: 5px;">
                            Counter Sample Send Date
                                        <asp:TextBox ID="txtCounterSampleSendDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtCounterSampleSendDate"
                                PopupButtonID="txtCounterSampleSendDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>

                        <div class="row" style="padding-top: 5px;">
                            SizeSet_Date
                                        <asp:TextBox ID="txtSizeSetDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtSizeSetDate"
                                PopupButtonID="txtSizeSetDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>

                    </div>
                    <div class="col-md-3" style="margin: auto 0;">
                        <div class="row">
                            Costing Send Date
                                        <asp:TextBox ID="txtCostingSendDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtCostingSendDate"
                                PopupButtonID="txtCostingSendDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Production Approved Date
                                        <asp:TextBox ID="txtProductionApprovedDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtProductionApprovedDate"
                                PopupButtonID="txtProductionApprovedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>

                        <div class="row" style="padding-top: 5px;">
                            BV Test Submit Date
                                        <asp:TextBox ID="txtBVTestSubmitDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtBVTestSubmitDate"
                                PopupButtonID="txtBVTestSubmitDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            BV Test Release Date
                                        <asp:TextBox ID="txtBVTestReleaseDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtBVTestReleaseDate"
                                PopupButtonID="txtBVTestReleaseDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                    </div>
                    <div class="col-md-3" style="margin: auto 0;">
                        <div class="row">
                            Sealing Sample Submit Date
                                        <asp:TextBox ID="txtSealingSampleSubmitDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtSealingSampleSubmitDate"
                                PopupButtonID="txtSealingSampleSubmitDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Sealing Sample Release Date
                                        <asp:TextBox ID="txtSealingSampleReleaseDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtSealingSampleReleaseDate"
                                PopupButtonID="txtSealingSampleReleaseDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>

                        <div class="row" style="padding-top: 5px;">
                            Shipment Sample Send Date
                                        <asp:TextBox ID="txtShipmentSampleSendDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtShipmentSampleSendDate"
                                PopupButtonID="txtShipmentSampleSendDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            Shipment Sample Approved Date
                                        <asp:TextBox ID="txtShipmentSampleApprovedDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtShipmentSampleApprovedDate"
                                PopupButtonID="txtShipmentSampleApprovedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                        <div class="row" style="padding-top: 5px;">
                            <asp:RadioButton ID="rdbApproved" runat="server" Text="Approved" GroupName="rdbSave" />
                            <asp:RadioButton ID="rdbDecline" runat="server" Text="Decline" GroupName="rdbSave" />
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info  pull-right" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12" style="padding-top: 5px;">
                    <asp:TextBox ID="txtBuyerAndPreOrder" runat="server" placeholder="Search Here By Order No and Buyer Name"
                        OnTextChanged="txtBuyerAndPreOrder_TextChanged" AutoPostBack="true" class="form-control"></asp:TextBox>
                    <cc1:AutoCompleteExtender ServiceMethod="SearchBuyerAndPreOrder"
                        MinimumPrefixLength="1"
                        CompletionInterval="100" EnableCaching="False"
                        TargetControlID="txtBuyerAndPreOrder"
                        ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                    </cc1:AutoCompleteExtender>
                </div>
                <div class="col-md-12">
                    <div style="z-index: 1; height: 300px; width: 100%; overflow: scroll; padding-top: 5px;">
                        <div class="row" style="margin: auto 0;">
                            <asp:GridView ID="grdSampleDetails" runat="server" AutoGenerateColumns="False" Width="100%"
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
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("SampleId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Pre Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPre_OrderNo" runat="server" Text='<%# Eval("Pre_OrderNo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Image">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "SampleImage.ashx?SampleId="+ Eval("SampleId") %>' Width="60%" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        <ControlStyle CssClass="imgwd" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sample Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSampleDate" runat="server" Text='<%# Eval("SampleDate","{0:dd/MM/yyyy}")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sample Specification">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSampleSpecification" runat="server" Text='<%# Eval("SampleSpecification")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgSampleDetailsEidt" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgSampleDetailsEidt_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
            </div>
        </div>
    </div>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>

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
