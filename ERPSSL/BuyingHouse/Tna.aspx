<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Tna.aspx.cs" Inherits="ERPSSL.BuyingHouse.Tna" %>

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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>TNA Setup 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 bg-success">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12" style="margin: auto 0; margin-left: -11px; background-color: #a7c5a7; padding-bottom: 5px;">
                            <div class="col-md-3" style="margin: auto 0;">
                                <div class="row">
                                    Style<span style="color: red; font-size: 11px">*</span>
                                    <asp:DropDownList ID="ddlStyle" runat="server" class="form-control"></asp:DropDownList>
                                    <asp:HiddenField ID="hidtnaId" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlStyle"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Select Style"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Brand<span style="color: red; font-size: 11px">*</span>
                                    <asp:DropDownList ID="ddlBrand" runat="server" class="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBrand"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Select Brand"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Department<span style="color: red; font-size: 11px">*</span>

                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDepartment"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Department"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Intake
                                
                                    <asp:TextBox ID="txtIntake" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFactoryAddress"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Address"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Description
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDescription"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Mobile"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-3" style="margin: auto 0;">
                                <div class="row">
                                    Buyer Name
                                    <asp:DropDownList ID="ddlBuyerName" runat="server" class="form-control"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlBuyerName"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Email"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Received From Buyer
                                        <%--<span style="color: red; font-size: 11px">*</span>--%>

                                    <asp:TextBox ID="txtReceivedFromBuyer" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtReceivedFromBuyer"
                                        PopupButtonID="txtReceivedFromBuyer" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReceivedFromBuyer"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Select Style"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Factory Name
                                        <%--<span style="color: red; font-size: 11px">*</span>--%>
                                    <asp:DropDownList ID="ddlFactoryName" runat="server" class="form-control"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlFactoryName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Select Brand"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Sending Date To Factory
                                        <%--<span style="color: red; font-size: 11px">*</span>--%>

                                    <asp:TextBox ID="txtSendingDateToFactory" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSendingDateToFactory"
                                        PopupButtonID="txtSendingDateToFactory" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSendingDateToFactory"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Department"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-3" style="margin: auto 0;">
                                <div class="row">
                                    Sample Deadline
                                    <asp:TextBox ID="txtSampleDeadline" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSampleDeadline"
                                        PopupButtonID="txtSampleDeadline" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSampleDeadline"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Address"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Factory Qty.
                                
                                    <asp:TextBox ID="txtFactoryQty" runat="server" Text="0" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFactoryQty"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Mobile"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Factory Price
                                
                                    <asp:TextBox ID="txtFactoryPrice" runat="server" Text="0" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFactoryPrice"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Email"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Received Qty.
                                        <%--<span style="color: red; font-size: 11px">*</span>--%>

                                    <asp:TextBox ID="txtReceivedQty" runat="server" Text="0" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtReceivedQty"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Select Brand"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>

                            <div class="col-md-3" style="margin: auto 0;">
                                <div class="row">
                                    Received From Factory
                                        <%--<span style="color: red; font-size: 11px">*</span>--%>
                                    <asp:TextBox ID="txtReceivedFromFactory" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtReceivedFromFactory"
                                        PopupButtonID="txtReceivedFromFactory" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtReceivedFromFactory"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Please Department"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Send To Buyer
                                    <asp:TextBox ID="txtSendToBuyer" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtSendToBuyer"
                                        PopupButtonID="txtSendToBuyer" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSendToBuyer"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Address"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Buyer Qty.
                                    <asp:TextBox ID="txtBuyerQty" runat="server" Text="0" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBuyerQty"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Mobile"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 8px;">
                                    Remark
                                    <asp:TextBox ID="txtRemark" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRemark"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Factory Email"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row" style="padding-top: 8px;">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-9">
                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="margin: auto 0; padding-top: 5px;">
                            <div class="row" style="margin: auto 0;">
                                <asp:GridView ID="grdTna" runat="server" AutoGenerateColumns="False" Width="99%"
                                    CellPadding="5" AllowPaging="True" PageSize="10">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
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
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="StyleName" HeaderText="Style">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>

                                        <asp:TemplateField HeaderText="Style">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <%--<ItemTemplate>
                                                <asp:Label ID="photoNmae" runat="server" Text='<%# Eval("StyleName")%>' />
                                            </ItemTemplate>--%>
                                            <ItemTemplate>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <asp:Label ID="photoNmae" runat="server" Text='<%# Eval("StyleName")%>' />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "StlImageShow.ashx?StyleId="+ Eval("StyleId") %>' Width="100%" />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                            <ControlStyle CssClass="imgwd" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="BrandName" HeaderText="Brand">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="Intake" HeaderText="Intake">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BuyerName" HeaderText="Buyer">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReceivedFromBuyer" HeaderText="Received From Buyer">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>

                                        <%--<asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgButtonEidt_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
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
