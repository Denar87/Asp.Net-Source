<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true"
    CodeBehind="ItemGroup.aspx.cs" Inherits="ERPSSL.Merchandising.ItemGroup" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Item Group Info
                        </div>
                    </div>
                    <div class="col-md-12">

                        <div class="row" style =" padding-top: 10px;">

                            <div class="col-md-12" style="background-color: #f0f5f6; padding-bottom: 10px;" >
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Item Category 
                                        <asp:DropDownList ID="drpItemCategory" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Trims Type  
                                                
                                          <asp:DropDownList ID="drpTrimsType" CssClass="form-control2 form-control" runat="server">
                                          </asp:DropDownList>

                                    </div>
                                    <div class="row">
                                        Conv. Factor 
                                          <asp:TextBox ID="txtConvFactor" runat="server" class="form-control2 form-control"></asp:TextBox>

                                    </div>
                                   

                                </div>
                                <div class="col-md-3">

                                    <div class="row">
                                        Group Code
                                             <asp:TextBox ID="txtGroupCode" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Order UOM
                                            <asp:DropDownList ID="drpOrderCom" CssClass="form-control2 form-control" runat="server">
                                            </asp:DropDownList>
                                    </div>

                                    <div class="row">
                                        Fancy Item
                                            <asp:DropDownList ID="drpFancyItem" CssClass="form-control2 form-control" runat="server">
                                            </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="col-md-3">

                                   <div class="row">
                                        Item Group
                                            <asp:TextBox ID="txtItemGroup" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Cons UOM
                                           <asp:DropDownList ID="drpConsUOM" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>

                                </div>

                                <div class="col-md-3">
                                    
                                    <div class="row">
                                        Cal Parameter
                                        <asp:DropDownList ID="drpCalParam" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>
                                     <div class="row">
                                        Status
                                            <asp:DropDownList ID="drpStatus" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row" style ="padding-top:12px;">
                                        <asp:Button ID="btnItemSubmit" runat="server" ValidationGroup="Group1" Text="Submit" CssClass="btn btn-info pull-right" />
                                    </div>
                                </div>

                            </div>


                        </div>
                         <div class="row" id="ShowGrid" runat="server" style="padding-top: 5px;">
                           
                            <div class="col-md-12" style="padding-left: 0; margin: auto 0;">
                                <div class="row" style="padding-left: 0; padding-top: 5px; margin: auto 0;">
                                    <fieldset style="margin: auto 0;">
                                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Item Group Info</span></legend>
                                        <div class="row" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto; margin: auto 0;">
                                           <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundField DataField="OrderEntryID" HeaderText="Id" Visible="false"></asp:BoundField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderEntryID" runat="server" Text='<%# Eval("OrderEntryID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Order_No" HeaderText="Order No">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Style_Description" HeaderText="Style">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PrincipalName" HeaderText="Principal">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Buyer_Name" HeaderText="Buyer">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OrderQuantity" HeaderText="Order Qty">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    
                                                    <asp:BoundField DataField="ShipmentDate" HeaderText="Shipment Date" DataFormatString="{0:MM/dd/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnItemGroupEdit" runat="server" ImageUrl="img/list_edit.png" />
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
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

 
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save successfully!') {
                toastr.success(result);

            }
            else if (result === 'Data Update successfully!') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
