<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="RecieveGeneral.aspx.cs" Inherits="ERPSSL.INV.RecieveGeneral" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">

                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Material Receive By Code
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <%--<fieldset>--%>
                        <div class="col-md-12" style="padding-bottom: 15px; border-bottom: 0px solid gray">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Store
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStore" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"
                                                Visible="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSupplier"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Supplier"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
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
                                            <asp:DropDownList ID="ddlSupplier" Class="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Supplier"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Ref. No./Coll. No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRefNo" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRefNo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Ref. No."
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
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
                                            MRR No.
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
                                            Order No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtOrderNo"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--</fieldset>--%>
                        <br />

                        <div class="col-md-12">
                            <fieldset style="background: #ccc; padding: 5px 0; margin-top: 6px;">

                                <div class="col-md-3">
                                    Item Category
                                            <asp:DropDownList ID="ddlProductGroup" Class="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                            </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSupplier"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Group"
                                        Font-Size="13px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-3" style="padding-left: 0;">
                                    Item
                                            <asp:DropDownList ID="ddlProductName" Class="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSupplier"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Name"
                                        Font-Size="13px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>


                                <div class="col-md-3" style="padding-left: 0; width: 20%">
                                    Code
                                            <asp:TextBox ID="txtbarcode" Class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtbarcode_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbarcode"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter a code"
                                        Font-Size="13px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>


                                <div class="col-md-1" style="padding-left: 0; width: 10%">
                                    Recieve Qty
                                            <asp:TextBox ID="txtReceiveQty" Class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReceiveQty"
                                        Display="Dynamic" ErrorMessage="Enter Recieved Quantity" ForeColor="Red" SetFocusOnError="True"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-1" style="padding-left: 0; width: 10%">
                                    CPU
                                            <asp:TextBox ID="txtCPU" Class="form-control" runat="server" AutoPostBack="true"
                                                OnTextChanged="txtCPU_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCPU"
                                        Display="Dynamic" ErrorMessage="Enter Cost Per Unit" ForeColor="Red" SetFocusOnError="True"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                                <%-- <div>Total Cost</div>--%>
                                <div class="col-md-1" style="padding-left: 0; width: 10%">
                                    Total Cost
                                            <asp:TextBox ID="txtTotalCost" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <%--  <div>Re-Order Qty</div>--%>
                                <div class="col-md-3" style="padding-left: 15px;">
                                    Re-Order Qty
                                            <asp:TextBox ID="txtReOrderQty" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <%--  <div>Balance Qty</div>--%>
                                <div class="col-md-3" style="padding-left: 0;">
                                    Balance Qty
                                            <asp:TextBox ID="txtBalanceQty" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <%--<div>Unit</div>--%>
                                <div class="col-md-3" style="padding-left: 0px; width: 20%">
                                    Unit
                                            <asp:TextBox ID="txtUnit" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <%-- <div>Floor</div>--%>
                                <div class="col-md-2" style="padding-left: 0px; width: 20%">
                                    Location
                                            <asp:TextBox ID="txtFloorName" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="padding-top: 15px; float: right">
                                    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="Group1" Text="Add" CssClass="btn btn-primary"
                                        OnClick="btnSubmit_Click" />
                                </div>
                            </fieldset>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <fieldset >
                                    <legend style="line-height: 5px;"><span style="background: #fff">Item List</span></legend>
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
                                            <asp:BoundField DataField="Barcode" HeaderText="Code">
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
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButtonEdit" runat="server"  ImageUrl="img/edit.png" CommandArgument='<%# Eval("Id") %>'
                                                        CommandName="edt" />
                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_Delete.png" CommandArgument='<%# Eval("Id") %>'
                                                        CommandName="dlt" />
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
                            </div>
                        </div>

                        <br />
                        <div class="col-md-12">
                            <div class="col-md-8">
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlChalanNo" Class="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlChalanNo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnSave" runat="server" Text="Post" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning"
                                    Visible="false" OnClick="btnPrint_Click" />
                            </div>

                        </div>


                    </div>
                    <br />



                    <div class="col-md-12">
                        <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>

                    </div>
                </div>
                <asp:HiddenField ID="hiddenCompanyType" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyle" runat="server" />
                <%--<asp:HiddenField ID="hdnProductName" runat="server" />--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Purchase information posted successfully') {
                toastr.success(result);

            }
            else if (result === 'Purchase information has been added temporarily. Please post.') {
                toastr.success(result);

            }

            else if (result === 'Data Update Successfully') {
                toastr.success(result);

            }



            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
