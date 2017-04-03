<%@ Page Title="" Language="C#" MasterPageFile="~/POS/Site.Master" AutoEventWireup="true" CodeBehind="ItemSync.aspx.cs" Inherits="ERPSSL.POS.ItemSync" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        

        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="glyphicon glyphicon-edit icon-padding"></i>Item Sync
            </div>
        </div>
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <br />
            <div class="row">
                <%--  <fieldset style="border: none;">--%>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                     Food Item<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlFoodItem" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlFoodItem"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Food Item"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Inventory Item<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlInventoryItem" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlInventoryItem"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Inventory Item"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br /> 
                        <div class="row ">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    <asp:HiddenField ID="hdfPackageID" runat="server" />
                                </div>
                                <div class="col-md-7">
                                    <asp:Button ID="btnItemInfo" runat="server" Text="Submit" Style="margin-top: 6px; margin-right: 20px;"
                                        class="btn btn-info" OnClick="btnItemInfo_Click" ValidationGroup="Group1" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="col-md-6">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Item List</span></legend>
                            <asp:GridView ID="grdItemList" runat="server" Width="100%" AutoGenerateColumns="false"
                                AllowPaging="true" AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC"
                                BorderStyle="Solid" CssClass="Grid_Border" PageSize="10" OnPageIndexChanging="grdPackageInfo_PageIndexChanging">
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <Columns> 
                                    <asp:TemplateField HeaderText="SL.No">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:BoundField DataField="ItemName" HeaderText="Item Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="30%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField> 
                                    <%--<asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="~/INV/img/list_edit.png" OnClick="ImgBtnEdit_Click" />
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
                        </fieldset>
                    </div>

                </div>
                <%-- </fieldset>--%>
            </div>
            <div class="col-md-12">
            </div>
        </div>
    </div>
     <script>

         function func(result) {
             if (result === 'Data Updated Successfully') {
                 toastr.success(result);

             }
             
             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>
