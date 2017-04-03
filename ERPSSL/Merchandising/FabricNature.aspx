<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="FabricNature.aspx.cs" Inherits="ERPSSL.Merchandising.FabricNature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function SuccessAlert(result) {
            swal({
                title: result,
                type: 'success',
                timer: 1000,
                showConfirmButton: false
            });
        }

        function notsuccessalert(result) {
            swal({
                title: result,
                type: 'error',
                timer: 1000,
                showConfirmButton: false
            });
        }

        function updatealert() {
            swal({
                title: 'Congratulations!',
                text: 'File Name Update',
                type: 'success'
            });
        }

        function notupdatealert() {
            swal({
                title: 'Oops...!',
                text: 'File Name Not Update',
                type: 'error'
            });
        }



        function CommonRequiredFiledError(result) {
            swal({
                title: result,
                type: 'warning',
                timer: 1500,
                showConfirmButton: false
            });
        }
    </script>

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
                            <i class="fa fa-edit fa-fw icon-padding"></i>Construction Type
                        </div>
                    </div>
                    <div class="row" style="margin: auto 0;">
                        <%--<div class="col-md-12 bg-success">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>--%>
                        <div class="col-md-5" style="margin: auto 0;">
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-3">
                                    Fabric Nature
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox ID="fabricNatureTextBox" runat="server" placeholder="Fabric Nature" class="form-control"></asp:TextBox>
                                </div>    
                                    
                            </div>
                            <div class="right" style="padding-top:10px;">
                                    <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-success" style="width:100px;" OnClick="saveButton_Click"/>
                            </div>
                           
                        </div>

                        <asp:HiddenField ID="fabricNatureHiddenField" runat="server" />
                        <div class="col-md-7" style="padding-top: 5px;">
                            <asp:GridView ID="FabricNatureInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="5" AllowPaging="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Sl No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FabricNature" HeaderText="Fabric Nature" />

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="~/Marketing/img/list_edit.png" OnClick="imgButtonEidt_Click"/>
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
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
