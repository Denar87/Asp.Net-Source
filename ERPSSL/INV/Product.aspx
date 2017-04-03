<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="ERPSSL.INV.Product" %>

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
                        <div class="row" style="padding: 0;">
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-4">
                                        Item Group
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlGroupName" CssClass="form-control" Width="110%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGroupName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtItemGroup" runat="server" Width="110%" Visible="false" Placeholder="Enter Item Group Name" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chkItemGroup" OnCheckedChanged="chkItemGroup_CheckedChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        Item Name
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlItemName" CssClass="form-control" Width="110%" runat="server" OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtProductName" Width="110%" Visible="false" Placeholder="Enter Item Name" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chkItemName" OnCheckedChanged="chkItemName_CheckedChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        Color/ Brand
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlColorBrand" CssClass="form-control" Width="110%" runat="server" OnSelectedIndexChanged="ddlColorBrand_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtBrand" runat="server" Width="110%" Visible="false" Placeholder="Enter Color/ Brand Name" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chkColorBrand" OnCheckedChanged="chkColorBrand_CheckedChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        Style & Size
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlStyleSize" CssClass="form-control" Width="110%" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtStyleSize" runat="server" Width="110%" Visible="false" Placeholder="Enter Style & Size" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chkStyleSize" OnCheckedChanged="chkStyleSize_CheckedChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        Unit
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlUnit" Width="110%" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtUnit" runat="server" Width="110%" Visible="false" Placeholder="Enter Item Unit" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chkUnit" OnCheckedChanged="chkUnit_CheckedChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        Item Type
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlItemType" Width="110%" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtItemType" runat="server" Width="110%" Visible="false" Placeholder="Enter Item Type" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chktemType" OnCheckedChanged="chktemType_CheckedChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        Re-order Level
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtReorder" runat="server" Placeholder="0.00" Text="0" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-4">
                                        <asp:HiddenField ID="hdfProductID" runat="server" />
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1"
                                            OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <div class="row" style="margin-left: 5px; margin-right: 5px;">
                                    <div style="z-index: 1; height: 440px; width: 100%; overflow: scroll; margin-right: -40px;">
                                        <asp:GridView ID="grdProductInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                                            PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="false" OnPageIndexChanging="grdProductInfo_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        Sl No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Brand" HeaderText="Color/ Brand">
                                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                        Width="15%" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Style/Size" DataField="StyleAndSize">
                                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                        Width="15%" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ProductType" HeaderText="Product Type">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
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
                                    </div>
                                </div>
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
            else if (result === 'Data Saving Failure') {
                toastr.error(result);
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
