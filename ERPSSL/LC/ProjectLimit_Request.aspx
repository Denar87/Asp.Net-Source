<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectLimit_Request.aspx.cs" Inherits="ERPSSL.LC.ProjectLimit_Request_aspx" MasterPageFile="~/LC/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
   
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Project Limit Request  
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
                                Project/Set Name
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlProjectSet" Class="form-control" AutoPostBack="false" runat="server"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Text="----Select One---- " Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStoreCode"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Store Code"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                CCN
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCCN" runat="server" class="form-control"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlCompanyType" CssClass="form-control" runat="server" AutoPostBack="false"
                                            AppendDataBoundItems="True">
                                            <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                                            <asp:ListItem>GENERAL</asp:ListItem>
                                            <asp:ListItem>CENTRAL</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCompanyType"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store Type"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Nature Of LC
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlNatureOfBG" CssClass="form-control" runat="server" AutoPostBack="false"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Text="----Select One----" Value="0"></asp:ListItem>
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
                                Confirm Type
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlConfirmType" CssClass="form-control" runat="server" AutoPostBack="false"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Text="----Select One----" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxAddress"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Store Address"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Exp Date Of LC Opning
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtExpDateBGOpning" runat="server" class="form-control" placeholder="MM/dd/yyyy"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtExpDateBGOpning" PopupButtonID="txtExpDateBGOpning" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDistrict"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select District"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="padding-top:8px;">
                    <div class="col-md-12">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-8">
                            <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-info  pull-right"  ValidationGroup="" /><%--OnClick="btnSave_Click"--%>
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

                            <asp:BoundField DataField="" HeaderText="Supplier">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="" HeaderText="Project/Set Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="" HeaderText="CCN">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="" HeaderText="Nature Of BG">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="" HeaderText="Confirm Type">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="" HeaderText="Exp Date Of BG Opning">
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
