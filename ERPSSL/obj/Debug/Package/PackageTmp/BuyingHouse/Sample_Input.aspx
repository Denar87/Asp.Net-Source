<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Sample_Input.aspx.cs" Inherits="ERPSSL.BuyingHouse.Sample_Input" %>

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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Sample Input
                </div>
            </div>
            <div class="row" style="margin: auto 0;">
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                <div class="col-md-6" style="margin: auto 0;">
                    <div class="row">
                        <div class="col-md-4">
                            Buyer 
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlBuyer" runat="server" class="form-control"></asp:DropDownList>
                            <asp:HiddenField ID="HidId" runat="server" />
                        </div>
                    </div>

                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                            Factory
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlFactoryMame" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                            Pre Order No.
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtPreOrderNo" runat="server" placeholder="Pre Order No." class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                            Sample Date
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtSampleDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSampleDate"
                                PopupButtonID="txtSampleDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                            Sample Specification
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtSampleSpecification" runat="server" placeholder="Sample Specification" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                            1st Sample Sent Date
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txt1stSampleSentDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt1stSampleSentDate"
                                PopupButtonID="txt1stSampleSentDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-8" style="text-align: right;">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                Width="85%" />
                            <%-- <asp:Image ID="imgUploadStyle" runat="server" class="avater_details" ImageAlign="Right" Height="150px"
                                ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                Width="130px" />--%>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-8">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info  pull-right" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div style="z-index: 1; height: 300px; width: 100%; overflow: scroll; padding-top: 5px;">
                        <div class="row" style="margin: auto 0;">
                            <asp:GridView ID="grdSampleDetails" runat="server" AutoGenerateColumns="False" Width="99%"
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
                                        <ItemStyle Width="4%" HorizontalAlign="Center" />
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
    <%-- </ContentTemplate>

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
