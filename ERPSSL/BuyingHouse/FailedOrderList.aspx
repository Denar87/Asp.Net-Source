<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="FailedOrderList.aspx.cs" Inherits="ERPSSL.BuyingHouse.FailedOrderList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Order Status
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:HiddenField ID="hidLcNo" runat="server" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
            </div>

            <div class="col-md-12">
                                
                    <fieldset>
                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Status List</span></legend>
                        <div class="col-md-12" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto">
                            <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                BorderWidth="1px" AllowPaging="false">
                                <Columns>
                                    <asp:BoundField DataField="OrderEntryID" HeaderText="Id" Visible="false"></asp:BoundField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllblOrderEntryID" runat="server" Text='<%# Eval("TaskDetails_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                      <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder_No" runat="server" Text='<%# Eval("Order_No")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Order_No" HeaderText="Order No">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Task" HeaderText="Task">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Schedule_Date" HeaderText="Schedule_Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="OrderQuantity" HeaderText="Order Qty">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="ShipmentDate" HeaderText="Shipment Date" DataFormatString="{0:dd MMM, yyyy}" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnOrderSheetEdit" runat="server" ImageUrl="~/LC/img/list_edit.png"
                                                OnClick="imgbtnOrderSheetEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>

                                </Columns>
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                    Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>
                    </fieldset>
                 

              



            </div>
        </div>
    </div>

    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
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
