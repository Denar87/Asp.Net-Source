<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="StoreUnit.aspx.cs" Inherits="ERPSSL.INV.StoreUnit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">       
        <div class="hm_sec_2_content scrollbar">
             <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="glyphicon glyphicon-edit icon-padding"></i>Store Unit 
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
                                    Store Unit Name<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Name"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Unit Track No.<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtUnitTrackNo" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnitTrackNo"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Unit Track No"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                          
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Store Unit Type<a style="color: red; font-size: 11px">*</a> 
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlstoreunit" Class="form-control" AutoPostBack="True" runat="server">
                                    </asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlstoreunit"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Type"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br /> 
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Location
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLocation" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLocation"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Location"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Description
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDescription"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Description"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <asp:HiddenField ID="hdfID" runat="server" />
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
                            <asp:GridView ID="grdStoreUnitValue" runat="server" Width="100%" AutoGenerateColumns="false"
                                AllowPaging="true" AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC"
                                BorderStyle="Solid" CssClass="Grid_Border" PageSize="10" OnPageIndexChanging="grdStoreUnitValue_PageIndexChanging">
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Store_Unit_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Store_Unit_Name" HeaderText="Store Unit Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit_Track_No" HeaderText="Unit Track No.">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="Location">
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
                                            <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgProjectEdit_Click" />
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
