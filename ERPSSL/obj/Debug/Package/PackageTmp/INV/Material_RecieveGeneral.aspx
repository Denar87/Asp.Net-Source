<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="Material_RecieveGeneral.aspx.cs" Inherits="ERPSSL.INV.Material_RecieveGeneral" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%--<%@ Register Assembly="NumericTextBox" Namespace="LZDollarTextBox" TagPrefix="cc1" %> --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                
                <asp:HiddenField ID="hiddenCompanyType" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyle" runat="server" />
                <%--<asp:HiddenField ID="hdnProductName" runat="server" />--%>
                <div class="hm_sec_2_content scrollbar clearfix">
                    <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Material Recieve Report (MRR) - General
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <%--<fieldset>--%>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4" style="color: red">
                                            MRR No#
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtChallanNo" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Date
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate"
                                                Display="Dynamic" ErrorMessage="Select Recieved Date" ForeColor="Red" SetFocusOnError="True"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            PO No#
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPONo" Class="form-control" runat="server"></asp:TextBox>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPONo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Ref. No."
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Supplier
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStore" Class="form-control" runat="server" AutoPostBack="True"
                                                Visible="false">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlSupplier" Class="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Supplier"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Challan No#
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRefNo" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRefNo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Ref. No."
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Mode of Delivery
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlModeofDelivery" Class="form-control" runat="server" AutoPostBack="True">
                                                <asp:ListItem Text="---Select One---" Value="0"></asp:ListItem>
                                                <asp:ListItem>Delivery Mode</asp:ListItem>
                                                <asp:ListItem>Home Delivery</asp:ListItem>
                                                <asp:ListItem>Port Delivery</asp:ListItem>
                                                <asp:ListItem>Office Delivery</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlModeofDelivery"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Group"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            UM Checked Condition
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlUMCheckedCondition" Class="form-control" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Reciept Condition
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlRecieptCondition" Class="form-control" runat="server">
                                                <asp:ListItem Text="---Select One---" Value="0"></asp:ListItem>
                                                <asp:ListItem>Avarage</asp:ListItem>
                                                <asp:ListItem>Damage</asp:ListItem>
                                                <asp:ListItem>Good</asp:ListItem>
                                                <asp:ListItem>Poor</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Delivery
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlDelivery" Class="form-control" runat="server">
                                                <asp:ListItem Text="---Select One---" Value="0"></asp:ListItem>
                                                <asp:ListItem>On Time</asp:ListItem>
                                                <asp:ListItem>No Time</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Sr. Packer
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlSrpacker" Class="form-control" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Move Coordinator
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtMoveOrdinator" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Project
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlProject" Class="form-control" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4" style="width: 15%;">
                                            Supplier Information
                                        </div>
                                        <div class="col-md-8" style="width: 85%;">
                                            <asp:TextBox ID="txtSupplierInfo" CssClass="form-control" TextMode="MultiLine" runat="server" Height="32px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4" style="width: 15%;">
                                            Remarks
                                        </div>
                                        <div class="col-md-8" style="width: 85%;">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" runat="server" Height="32px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Store
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStoreName" Class="form-control" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Store Unit
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStoreUnit" Class="form-control" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <%--</fieldset>--%>

                            <%-- <div class="col-md-12">--%>
                            <fieldset style="background: #ccc;">
                                <%-- <div class="col-md-12">--%>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlProductGroup" Class="form-control" runat="server" AutoPostBack="True" Width="118%"
                                        OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProductGroup"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Group"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlProductName" Class="form-control" runat="server" AutoPostBack="True" Width="118%"
                                        OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProductName"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtBalanceQty" Class="form-control" runat="server" ReadOnly="true" placeholder="Stock" Width="144%"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtUnit" Class="form-control" runat="server" ReadOnly="true" Placeholder="Unit" Width="144%"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtReceiveQty" Class="form-control" runat="server" AutoPostBack="True" Placeholder="Rec. Qty" Width="144%" OnTextChanged="txtReceiveQty_TextChanged"></asp:TextBox>
                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                        ControlToValidate="txtReceiveQty"
                                        ValidationExpression="\d+"
                                        Display="Static"
                                        EnableClientScript="true"
                                        Font-Size="11px"
                                        ErrorMessage="Number only" ValidationGroup="Group1"
                                        runat="server" />--%>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReceiveQty"
                                        Display="Dynamic" ErrorMessage="Enter Qty" ForeColor="Red" SetFocusOnError="True"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                                </div>

                                <div class="col-md-1">
                                    <%--<cc1:NumericTextBox ID="DIO" ControlWidth="120" runat="server" AllowDecimal="True" Text="1232.2123122" DecimalPlaces="2" CanWrite="True" DollarSign="False" />--%>
                                    <asp:TextBox ID="txtCPU" Class="form-control" runat="server" AutoPostBack="true" Width="144%"
                                        OnTextChanged="txtCPU_TextChanged" Placeholder="CPU"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCPU"
                                        Display="Dynamic" ErrorMessage="Enter Rate" ForeColor="Red" SetFocusOnError="True"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtTotalCost" Class="form-control" runat="server" ReadOnly="true" Placeholder="Total Cost" Width="144%"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtItemRemarks" CssClass="form-control" runat="server" Placeholder="Remarks here" Width="116%"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="Group1" Text="Add" CssClass="btn btn-primary"
                                        OnClick="btnSubmit_Click" />
                                </div>
                                <%-- </div>--%>
                            </fieldset>
                            <br />
                            <%--</div>--%>
                        </div>
                        <br />
                        <%-- <div class="row">--%>
                        <div class="col-md-12">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Item List</span></legend>
                                <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="False" Width="100%"
                                    PageSize="5" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnRowCommand="gvPurchase_RowCommand"
                                    AutoGenerateSelectButton="False" HorizontalAlign="Left">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="SL No.">
                                             <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                             <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                             <FooterStyle CssClass="Grid_Footer" />
                                              </asp:BoundField>--%>
                                        <%--<asp:BoundField DataField="ChallanNo" HeaderText="Challan No.">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>--%>
                                        <asp:BoundField DataField="GroupName" HeaderText="Item Group">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Brand" HeaderText="Brand">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="StyleSize" HeaderText="Style/Size">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CPU" HeaderText="CPU">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReceiveQuantity" HeaderText="Rec. Qty.">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_Delete.png" CommandArgument='<%# Eval("Id") %>'
                                                    CommandName="EditProduct" />
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
                            </fieldset>
                            <br />
                        </div>
                        <%-- </div>--%>
                        <br />

                        <div class="col-md-12">
                            <div class="col-md-12">
                                <div class="col-md-8"></div>
                                <div class="col-md-3">
                                    <%-- <div class="col-md-5" style="padding-top:7px">
                                    Unposted MRR
                                </div>--%>
                                    <%--<div class="col-md-7">--%>
                                    <asp:DropDownList ID="ddlChalanNo" Class="form-control" runat="server" AutoPostBack="True" ForeColor="Gray"
                                        OnSelectedIndexChanged="ddlChalanNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%-- </div>--%>
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnSave" runat="server" Text="Post" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                                </div>

                            </div>
                            <br />

                        </div>
                    </div>

                    <div class="col-md-12">
                        <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script>

         function func(result) {
             if (result === 'Purchase information posted successfully') {
                 toastr.success(result);

             }
             else if (result === 'Purchase information has been added temporarily. Please post.') {
                 toastr.success(result);

             }
             else if (result === 'Item list is empty!') {
                 toastr.error(result);

             }
             else if (result === 'Unable to complete the operation...') {
                 toastr.error(result);

             }

             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>
