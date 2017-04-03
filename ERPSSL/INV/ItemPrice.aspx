<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="ItemPrice.aspx.cs" Inherits="ERPSSL.INV.ItemPrice" %>

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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Item Price
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
                                        Item Group
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlGroupName" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
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
                                        Item Name
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlProductName" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProductName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Item"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Brand
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtBrand" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBrand"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Product Brand"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Style & Size
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtStyleSize" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
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
                                        Price
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPrice" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrice"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Price"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <asp:HiddenField ID="hdfProductGroupID" runat="server" />
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Update" class="btn btn-info pull-right" ValidationGroup="Group1"
                                            OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Item List</span></legend>
                                    <div class="col-md-12">
                                        <asp:GridView ID="grdProductInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                                            PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="grdProductInfo_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGroupId" runat="server" Text='<%# Bind("GroupId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ProductName" HeaderText="Item">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Brand" HeaderText="Brand">
                                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Style/Size" DataField="StyleAndSize">
                                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Price" HeaderText="Price">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnProductEdit" runat="server" ImageUrl="img/list_edit.png"
                                                            OnClick="imgbtnProductEdit_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
                                </fieldset>
                            </div>

                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script>

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
