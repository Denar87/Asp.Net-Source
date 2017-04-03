<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="DeliveryMode.aspx.cs" Inherits="ERPSSL.INV.DeliveryMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server"> 
            <div class="row">
               
                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Delivery Mode
                    </div>
                </div> 
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 10px;">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Delivery Mode 
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDelivery" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDelivery"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Delivery Mode"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <asp:HiddenField ID="hdfDeliveryID" runat="server" />
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1"
                                                OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <asp:GridView ID="grdDelivery" runat="server" Width="100%" AutoGenerateColumns="false"
                                        AllowPaging="true" AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC"
                                        BorderStyle="Solid" CssClass="Grid_Border" PageSize="10" OnPageIndexChanging="grdDelivery_PageIndexChanging">
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="Id" HeaderText="SL No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Delevery_Mode" HeaderText="Delivery Mode">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgEdit_Click" />
                                                </ItemTemplate>
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="pagination01 pageback" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
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
