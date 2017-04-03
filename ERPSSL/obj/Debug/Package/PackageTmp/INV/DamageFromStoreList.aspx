<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="DamageFromStoreList.aspx.cs" Inherits="ERPSSL.INV.DamageFromStoreList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Item Damage List
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
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                               Form Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                               
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                                 <div class="col-md-4">
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                              To Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtTodate" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTodate"
                                                    PopupButtonID="txtTodate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />                                               
                                            </div>
                                        </div>
                                    </div>
                                   </div>
                                 <div class="col-md-4">
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-7">
                                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" ValidationGroup="Group1" OnClick="btnConfirm_Click" class="btn btn-info pull-right"
                                                     />
                                            </div>
                                        </div>
                                    </div>
                                   </div>
                                   
                                   
                                   
                                </div>
                                <div class="col-md-12" style="padding-top: 8px;">
                                    <fieldset>
                                        <div class="row">
                                            <asp:GridView ID="grdDamage" runat="server" Width="100%" AutoGenerateColumns="false"
                                                AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC" BorderStyle="Solid"
                                                CssClass="Grid_Border">
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ChallanNo")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="DamageCategory" HeaderText="Damage Category">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DamageQty" HeaderText="Damage Qty">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgGroupEdit_Click" />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                                        </asp:TemplateField>--%>
                                                </Columns>
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle CssClass="pagination01 pageback" />
                                                <RowStyle CssClass="Grid_RowStyle" />
                                            </asp:GridView>
                                        </div>
                                    </fieldset>
                                   
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Product damage information inserted successfully!') {
                toastr.success(result);

            }
            else if (result === 'Damage Process Temporary successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
