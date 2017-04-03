<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true"
    CodeBehind="SupplierEnlishment.aspx.cs" Inherits="ERPSSL.Procurement.SupplierEnlishment" %>

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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Supplier Information
                    </div>
                </div>

                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Supplier Name
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSupplierName" Class="form-control" runat="server" AutoPostBack="true"
                                            OnTextChanged="txtSupplierName_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hidSupplierId" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSupplierName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Supplier Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Supplier Code
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSupplierCode" Class="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSupplierCode"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Supplier Code"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Address
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtbxAddress" TextMode="MultiLine" runat="server" class="form-control"
                                            Height="90"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxAddress"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Supplier Address"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        District
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlDistrict" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ValidationGroup="Group1" ControlToValidate="ddlDistrict"
                                            SetFocusOnError="True" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select a District"
                                            Font-Size="11px" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <%--<div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Supplier Type
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlSupplierType" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>Bill To Bill</asp:ListItem>
                                    <asp:ListItem>Credit</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ValidationGroup="Group1" ControlToValidate="ddlSupplierType"
                                    SetFocusOnError="True" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select Supplier Type"
                                    Font-Size="11px" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />--%>
                            <%--<div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Credit Days
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCreditDays" Class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCreditDays"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Credit Days"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />--%>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Contact Person
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtContactPerson" Class="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtContactPerson"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Person Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Contact No.
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPhone" Class="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Contact No."
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        E-mail
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmail" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Status
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select One</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ValidationGroup="Group1" ControlToValidate="ddlStatus"
                                            SetFocusOnError="True" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Enlisted Status"
                                            Font-Size="11px" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSupplier" runat="server" ValidationGroup="Group1" Text="Submit"
                                            CssClass="btn btn-info pull-right" OnClick="btnSupplier_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gridviewSupplier" runat="server" AutoGenerateColumns="False" Width="100%"
                                PageSize="7" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewSupplier_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplierId" runat="server" Text='<%# Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SupplierCode" HeaderText="Code">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="SupplierType" HeaderText="Type">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>
                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Phone" HeaderText="Contact No.">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmailAddress" HeaderText="E-mail">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fired" HeaderText="Enlisted">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="Performance" HeaderText="Performance">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnSupplierEdit" runat="server" ImageUrl="img/edit.png" OnClick="imgbtnSupplierEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" Height="28px" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <%--<PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />--%>
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
