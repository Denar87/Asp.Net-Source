<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="company.aspx.cs" Inherits="ERPSSL.INV.company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="glyphicon glyphicon-edit icon-padding"></i>Inventory Profile Information
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Profile Name
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxName" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hidCompanyId" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                    Font-Size="11px" ErrorMessage="Enter Profile Name"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Profile Code
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtStoreCode" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStoreCode"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Profile Code"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <%--   <div class="row" style="padding-top:8px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                       Store Type
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlCompanyType" CssClass="form-control" runat="server" AutoPostBack="false"
                                            AppendDataBoundItems="True">
                                            <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                                            <asp:ListItem>GENERAL</asp:ListItem>
                                            <asp:ListItem>CENTRAL</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCompanyType"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store Type"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                    --%>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Contact Person
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtContactPerson" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactPerson"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Contact Person Name"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Address
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxAddress" TextMode="MultiLine" runat="server" class="form-control"
                                    Height="65px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxAddress"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Profile Address"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                District
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlDistrict" Class="form-control" AutoPostBack="false" runat="server"
                                    AppendDataBoundItems="false">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDistrict"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select District"
                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Phone
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxPhoneNo" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Mobile
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxMobileNo" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxMobileNo"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Mobile No."
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-8">
                                <br />
                                <asp:Image ID="Emp_IMG_TRNS" runat="server" class="avater_details" Height="150px"
                                    ImageUrl="~/INV/resources/no_image_found.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                    Width="130px" />
                            </div>
                        </div>
                        <div class="col-md-12" style="padding-top: 10px;">
                            <div class="col-md-4">
                                Logo
                            </div>
                            <div class="col-md-8">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                    Width="85%" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Fax
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxFax" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Email
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxEmail" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxEmail"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Email Address"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Web
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxWebSite" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-10">
                        </div>
                        <div class="col-md-2" style="float: right; padding-right: 0px;">
                            <span style="float: right; padding-right: 58px;">
                                <asp:Button ID="btnCompany" runat="server" ValidationGroup="Group1" Text="Submit"
                                    CssClass="btn btn-info " OnClick="btnCompany_Click" />
                            </span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                <div class="col-md-12" style="padding-right: 10px">
                    <asp:GridView ID="gridviewCompany" runat="server" AutoGenerateColumns="False" Width="100%"
                        PageSize="5" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewCompany_PageIndexChanging">
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
                                    <asp:Label ID="lblCompanyId" runat="server" Text='<%# Eval("CompanyId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CompanyName" HeaderText="Profile Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompanyCode" HeaderText="Code">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="CompanyType" HeaderText="Store Type">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                            <asp:BoundField DataField="Address" HeaderText="Address">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Justify" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Phone" HeaderText="Phone">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnCompanyEdit" runat="server" ImageUrl="img/list_edit.png"
                                        OnClick="imgbtnCompanyEdit_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle CssClass="pagination01 pageback" />
                        <RowStyle CssClass="Grid_RowStyle" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <%-- <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />--%>
                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
       
    </asp:UpdatePanel>--%>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'File is too big!! Max file size 100kb!!! Please Resize !!!!') {
                toastr.error(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
