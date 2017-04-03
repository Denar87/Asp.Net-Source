<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true"
    CodeBehind="Body_Parts.aspx.cs" Inherits="ERPSSL.Merchandising.Body_Parts" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ToolkitScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Body Parts
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-md-6">
                                <div class="row" style="padding-top: 3px;">
                                    <div class="col-md-5">
                                        Body Parts <a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtBodyParts" runat="server" class="form-control"></asp:TextBox>
                                        <asp:HiddenField ID="hidBodyId" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBodyParts"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Body Parts"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 8px;">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Button ID="btnSave" runat="server" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" OnClick="btnSave_Click"  /><%--OnClick="btnSave_Click"--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:GridView ID="grdBodyParts" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CellPadding="5" AllowPaging="false" PageSize="10">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
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
                                                <asp:Label ID="lblBPartId" runat="server" Text='<%# Eval("BPartId")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="BodyPart" HeaderText="Body Part">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                       
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" OnClick="imgButtonEidt_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

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
