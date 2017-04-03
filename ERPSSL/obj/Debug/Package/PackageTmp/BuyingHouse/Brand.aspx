<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="ERPSSL.BuyingHouse.Brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Brand Setup 
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row" style="padding-top: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        Brand Name<span style="color: red; font-size: 11px">*</span>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtBrandName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:HiddenField ID="hidBrandId" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBrandName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Brand Name"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-9">
                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:GridView ID="grdBrand" runat="server" AutoGenerateColumns="False" Width="100%"
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
                                    <asp:Label ID="lblBrandId" runat="server" Text='<%# Eval("BrandId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="BrandName" HeaderText="Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" OnClick="imgButtonEidt_Click" />
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
