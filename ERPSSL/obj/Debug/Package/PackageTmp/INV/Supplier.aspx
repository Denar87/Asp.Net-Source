<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="Supplier.aspx.cs" Inherits="ERPSSL.INV.Supplier" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row" style="margin: 0 auto">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Supplier Information
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 0px;">
                        <div class="col-md-5">
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Supplier Name<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSupplierName" Class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtSupplierName_TextChanged" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};">

                                        </asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchSupplier"
                                            MinimumPrefixLength="1"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                            TargetControlID="txtSupplierName"
                                            ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                        </cc1:AutoCompleteExtender>
                                        <asp:HiddenField ID="hidSupplierId" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSupplierName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Supplier Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Supplier Code<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSupplierCode" Class="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSupplierCode"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Supplier Code"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Address
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtbxAddress" TextMode="MultiLine" runat="server" class="form-control"
                                            Height="70"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        District
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlDistrict" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Location
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlLocation" Width="110%" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtLocation" Width="110%" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-md-1" style="margin-top: 7px;">
                                        <asp:CheckBox ID="chklocation" AutoPostBack="true" OnCheckedChanged="chklocation_CheckedChanged" runat="server" />
                                    </div>

                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Contact Person
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtContactPerson" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Contact No.
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPhone" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        E-mail
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmail" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Status<a style="color: red; font-size: 11px">*</a>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select One</asp:ListItem>
                                            <asp:ListItem Value="Yes">By Enlisted</asp:ListItem>
                                            <asp:ListItem Value="No"> Non Listed</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ValidationGroup="Group1" ControlToValidate="ddlStatus"
                                            SetFocusOnError="True" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Enlisted Status"
                                            Font-Size="11px" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSupplier" runat="server" ValidationGroup="Group1" Text="Submit"
                                            CssClass="btn btn-info pull-right" OnClick="btnSupplier_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Non Listed Supplier List</span></legend>
                                    <asp:GridView ID="gridviewSupplier" runat="server" AutoGenerateColumns="False" Width="100%"
                                        PageSize="10" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewSupplier_PageIndexChanging">
                                        <Columns>
                                              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        Sl.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplierId" runat="server" Text='<%# Eval("Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplierCode" runat="server" Text='<%# Eval("SupplierCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("DistrictId")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("Location")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactPerson" runat="server" Text='<%# Eval("ContactPerson")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("Phone")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailAddress")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Enlisted")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Phone" HeaderText="Contact No.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Fired" HeaderText="Enlisted">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnSupplierEdit" runat="server" ImageUrl="img/list_edit.png"
                                                        OnClick="imgbtnSupplierEdit_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="pagination01 pageback" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <%--<PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />--%>
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:GridView>
                                </fieldset>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="padding-bottom: 5px; margin: 0 auto">
                        <div class="col-md-12">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Enlisted Supplier List</span></legend>
                                    <asp:GridView ID="gridEnlistedTrue" runat="server" AutoGenerateColumns="False" Width="100%"
                                        PageSize="10" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewSupplier_PageIndexChanging">
                                        <Columns>
                                             <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        Sl.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplierId" runat="server" Text='<%# Eval("Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSupplierCode" runat="server" Text='<%# Eval("SupplierCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("DistrictId")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("Location")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactPerson" runat="server" Text='<%# Eval("ContactPerson")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("Phone")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailAddress")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Enlisted")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Phone" HeaderText="Contact No.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Fired" HeaderText="Enlisted">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnEnlistedEdit" runat="server" ImageUrl="img/list_edit.png"
                                                        OnClick="imgbtnEnlistedEdit_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="pagination01 pageback" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <%--<PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />--%>
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:GridView>
                                </fieldset>
                            </div>

                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
