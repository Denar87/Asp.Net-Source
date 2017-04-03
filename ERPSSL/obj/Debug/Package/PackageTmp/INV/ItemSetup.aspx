<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="ItemSetup.aspx.cs" Inherits="ERPSSL.INV.ItemSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Item Information
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Item Group<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlGroupName" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGroupName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Item Name<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtProductName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtProductName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Product Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                            <%--<div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Brand
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtBrand" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrand"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Product Brand"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>
                            <%--<div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Asset Type
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlAssetType" CssClass="form-control" runat="server" Enabled="false">
                                    <asp:ListItem Text="Select type" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="FixedAsset">Fixed Asset</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="ConsumableProduct">Consumable Product</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />--%>
                            <br />
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Description<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtBrand" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtStyleSize" runat="server" class="form-control" TextMode="MultiLine" Height="32px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtStyleSize"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Style/Size"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Re-order Level
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtReorder" runat="server" class="form-control"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReorder"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Re-Order Level"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>


                            <%-- <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Project<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlProject" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                        <div class="col-md-4">

                            <%--<div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Store<a style="color: red; font-size: 11px">*</a>
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
                                        Store Unit<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlStoreUnit" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />--%>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Unit<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlUnit" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlUnit"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Unit"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <asp:HiddenField ID="hdfProductID" runat="server" />
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1"
                                            OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Item List</span></legend>
                            <asp:GridView ID="grdProductInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                                PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="grdProductInfo_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="Brand" HeaderText="Brand">
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                            Width="15%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="Description" DataField="StyleAndSize">
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnProductEdit" runat="server" ImageUrl="img/list_edit.png"
                                                OnClick="imgbtnProductEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
                        </fieldset>
                        <br />
                    </div>
                </div>
                <br />
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }

            else if (result === 'Data Saving Failure') {
                toastr.error(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Sucessfully') {
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
