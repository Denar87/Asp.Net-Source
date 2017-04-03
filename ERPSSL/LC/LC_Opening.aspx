<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LC_Opening.aspx.cs" Inherits="ERPSSL.LC.LC_Opening" MasterPageFile="~/LC/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>LC Opening.  
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">

                <div class="col-md-5">
                    <fieldset>
                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Supplier Name
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlSupplier" Class="form-control" AutoPostBack="false" runat="server"
                                        AppendDataBoundItems="false">
                                        <asp:ListItem Text="----Select One---- " Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px" ErrorMessage="Enter Store Name"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Program 
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtProgram" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px" ErrorMessage="Enter Store Name"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Bank 
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlBank" Class="form-control" AutoPostBack="false" runat="server"
                                        AppendDataBoundItems="false">
                                        <asp:ListItem Text="----Select One---- " Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px" ErrorMessage="Enter Store Name"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Amount
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactPerson"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Contact Person Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Product Group
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlProductGroup" Class="form-control" AutoPostBack="false" runat="server"
                                        AppendDataBoundItems="false">
                                        <asp:ListItem Text="----Select One---- " Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactPerson"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Contact Person Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    Product 
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlProduct" Class="form-control" AutoPostBack="false" runat="server"
                                        AppendDataBoundItems="false">
                                        <asp:ListItem Text="----Select One---- " Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px" ErrorMessage="Enter Store Name"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    QTY
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtQty" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactPerson"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Contact Person Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>


                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    M/LC
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMLC" runat="server" class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactPerson"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Contact Person Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-8">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-info  pull-right" /><%--OnClick="btnSave_Click"--%>
                                </div>
                            </div>
                        </div>

                    </fieldset>
                </div>

                <div class="col-md-7">
                    <fieldset>
                        <asp:GridView ID="gridviewSection" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" PageSize="10">
                            <%--OnPageIndexChanging="gridviewSection_PageIndexChanging"--%>
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
                                        <asp:Label ID="lblLC_Request" runat="server" Text='<%# Eval("SEC_ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="" HeaderText="Transaction">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>


                                <asp:BoundField DataField="" HeaderText="To Bank">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="" HeaderText="From Bank">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="" HeaderText="Amount">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="" HeaderText="Remarks">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDepartmentEdit" runat="server" ImageUrl="img/list_edit.png" /><%--OnClick="imgbtnDepartmentEdit_Click"--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:GridView>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
