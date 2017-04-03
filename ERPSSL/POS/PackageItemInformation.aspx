<%@ Page Title="" Language="C#" MasterPageFile="~/POS/Site.Master" AutoEventWireup="true" CodeBehind="PackageItemInformation.aspx.cs" Inherits="ERPSSL.POS.PackageItemInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>

            

                <div class="hm_sec_2_content content" id="content-1">
                    <div class="row">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Package Item Information
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
                                            Package Name<a style="color: red; font-size: 11px"></a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlPackageName" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPackageName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPackageName"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Package Name"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Package Item Name<a style="color: red; font-size: 11px"></a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlPackageItemName" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPackageItemName"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Package Item Name"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Price<a style="color: red; font-size: 11px"></a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtprice" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtprice"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Price"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Quantity<a style="color: red; font-size: 11px"></a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQty"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Quantity"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Status<a style="color: red; font-size: 11px"></a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:CheckBox ID="chkStatus" runat="server" Checked="true" />
                                        </div>
                                    </div>
                                </div> 
                                <div class="row ">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            <asp:HiddenField ID="hdfPackageID" runat="server" />
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnPackageInfo" runat="server" Text="Submit" Style="margin-top: 6px; margin-right: 20px;"
                                                class="btn btn-info" OnClick="btnPackageInfo_Click" ValidationGroup="Group1" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Package Item List</span></legend>
                                    <asp:GridView ID="grdPackageInfo" runat="server" Width="100%" AutoGenerateColumns="false"
                                        AllowPaging="true" AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC"
                                        BorderStyle="Solid" CssClass="Grid_Footer" PageSize="10" OnPageIndexChanging="grdPackageInfo_PageIndexChanging">
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPackageID" runat="server" Text='<%# Eval("PackageItemInfo_ID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SL.No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="PackageName" HeaderText="Package">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="20%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PackageItemName" HeaderText="Package Item">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="20%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Price" HeaderText="Price">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Quantity" HeaderText="Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="~/INV/img/list_edit.png" OnClick="ImgBtnEdit_Click" />
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
                                </fieldset>
                            </div>

                        </div>
                        <%-- </fieldset>--%>
                    </div>
                    <div class="col-md-12">
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
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
