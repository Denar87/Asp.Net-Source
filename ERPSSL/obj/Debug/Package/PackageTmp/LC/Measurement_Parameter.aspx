<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="Measurement_Parameter.aspx.cs" Inherits="ERPSSL.LC.Measurement_Parameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Measurement Parameter
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
                                <div class="col-md-12" style="padding-bottom: 5px">
                                    <div class="col-md-4">
                                        Finish Goods
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlFinishGoods" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFinishGoods_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-12" style="padding-bottom: 5px">
                                    <div class="col-md-4">
                                        Measurement Parameter
                                <a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMagerment_Parameter" runat="server" class="form-control"></asp:TextBox>
                                        <asp:HiddenField ID="hidMParameter_Id" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMagerment_Parameter"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Magerment Parameter Name"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-9">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" /><%--OnClick="btnSave_Click"--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">

                    <asp:GridView ID="grdMeasurement_Parameter" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdMeasurement_Parameter_PageIndexChanging">
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
                                    <asp:Label ID="lblMagerment_Id" runat="server" Text='<%# Eval("Measurement_Id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="MagermentName" HeaderText="Measurement Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FinishGoodsName" HeaderText="Finish Goods">
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
            if (result === 'Measurement Parameter Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Measurement Parameter Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
