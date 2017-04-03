<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="ERPSSL.INV.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Store Information
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
            </div>
            <div class="row" style="margin: auto 0;">
                <div class="col-md-6" style="margin: auto 0;">
                    <%-- <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Project Name<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlProjectName" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProjectName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Project"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Department Name<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Store In charge Name<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlStoreIncharge" CssClass="form-control" runat="server"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlStoreIncharge"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store Incharge"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="---Select One---"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Store Name<a style="color: red; font-size: 11px">*</a>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtStoreName" CssClass="form-control" placeholder="Enter Store Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Store Code<a style="color: red; font-size: 11px">*</a>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtStoreTrack" CssClass="form-control" placeholder="Enter Store Code" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Location
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtLocation" CssClass="form-control" placeholder="Enter Store Location" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Description
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" placeholder="Enter Store Description" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <asp:HiddenField ID="hdfStoreID" runat="server" />
                            </div>
                            <div class="col-md-7">
                                <asp:Button ID="BtnSave" runat="server" Text="Submit" class="btn btn-info pull-right"
                                    OnClick="btnStore_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <fieldset>
                        <legend style="line-height: 0;"><span style="background: #fff">Store List</span></legend>
                        <asp:GridView ID="grdstore" runat="server" Width="100%" AutoGenerateColumns="false"
                            AllowPaging="true" AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC"
                            BorderStyle="Solid" CssClass="Grid_Border" PageSize="10" OnPageIndexChanging="grdStoreValue_PageIndexChanging">
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
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
                                        <asp:Label ID="lblstoreId" runat="server" Text='<%# Eval("Store_Id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StoreName" HeaderText="Store Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Store_Code" HeaderText="Store Code">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Location" HeaderText="Store Location">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgBtnEdit_Click" />
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
            <div class="col-md-12">
            </div>
        </div>
    </div>

    <script type="text/javascript">

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

            else if (result === 'Data Updated Successfully') {
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
