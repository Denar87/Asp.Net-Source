<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="MaterialIssueGeneral.aspx.cs" Inherits="ERPSSL.INV.MaterialIssueGeneral" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyleSize" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Goods Issue Note (GIN) - General
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                E-ID<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEID" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnTextChanged="txtEID_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlDepartment" AutoPostBack="True" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Receiver<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlReciver" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlReciver_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Project Name
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlProject" Class="form-control" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Store Name
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
                                                Store Unit Name
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlStoreUnit" Class="form-control" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5" style="color: red">
                                                GIN No#
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtChalanNo" CssClass="form-control" runat="server" ReadOnly="true" Width="106%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" Width="106%"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Issue Date"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Remarks
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" runat="server" Height="35px" Width="106%"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <%--  <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Issue Item
                </div>
            </div>--%>
                    <div class="row">

                        <div class="col-md-12">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Select Item</span></legend>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item Group<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlItemGroup" AutoPostBack="True" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlItemGroup"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Group"
                                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item Name<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlItemName" AutoPostBack="True" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlItemName"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Item Name"
                                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Unit
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <%--  <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Brand
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />--%>
                                </div>
                                <div class="col-md-6">
                                    <%-- <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Style/Size
                                    </div>
                                    <div class="col-md-7">--%>
                                    <asp:TextBox ID="txtStyleSize" CssClass="form-control" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                    <%-- </div>
                                </div>
                            </div>
                            <br />--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Balance Qty
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBalanceQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Issue Qty<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtIssueQty" CssClass="form-control" runat="server" OnTextChanged="txtIssueQty_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtIssueQty"
                                                    Display="Dynamic" ErrorMessage="Enter Issued Qty" ForeColor="Red" SetFocusOnError="True"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="BtnAdd" ValidationGroup="Group1" runat="server" Text="Add" class="btn btn-primary"
                                                    OnClick="BtnAdd_Click" />
                                            </div>
                                            <div class="col-md-5">
                                                <asp:Button ID="btnSave" runat="server" Text="Issue" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Item List</span></legend>
                                <asp:GridView ID="grvIssue" runat="server" AutoGenerateColumns="False" Width="100%"
                                    PageSize="5" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" AutoGenerateSelectButton="False"
                                    HorizontalAlign="Left" OnRowCommand="grvIssue_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="SL No." Visible="false">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="ChallanNo" HeaderText="Challan No.">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
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
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Brand" HeaderText="Brand">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
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
                                        <%--<asp:BoundField DataField="CPU" HeaderText="CPU">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DPT_NAME" HeaderText="Department">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Reciever">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                        <asp:BoundField DataField="DeliveryQty" HeaderText="Delivery Qty.">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="BalanceQuanity" HeaderText="Balance Qty.">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_Delete.png" CommandName="EditProduct"
                                                    CommandArgument='<%# Eval("Id") %>' />
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script>

         function func(result) {
             if (result === 'Issue information has been added temporarily. Please post.') {
                 toastr.error(result);

             }
            else if (result === 'GIN Issued successfully!') {
                 toastr.error(result);

             }
             else if (result === 'No Item is available of this group!') {
                 toastr.error(result);

             }
             else if (result === 'Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data') {
                 toastr.error(result);

             }
             else if (result === 'Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity') {
                 toastr.error(result);

             }

             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>
