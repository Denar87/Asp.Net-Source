﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="UserAccess.aspx.cs" Inherits="ERPSSL.Adminpanel.UserAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
   <%-- <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>User Access
        </div>
    </div>--%>
    <div class="hm_sec_2_content scrollbar">
         <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>User Access
        </div>
    </div>
        <div class="col-md-12">
            <div class="resultText">
                <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
                    Visible="false" />
                <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
                <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <label class="control-label" for="inputFname1">
                        User Name<a style="color: red; font-size: 11px">*</a></label>
                    <div class="controls">
                        <asp:DropDownList ID="drpUserName" runat="server" CssClass="form-control" Width="60%">
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label" for="inputFname1">
                        Role<a style="color: red; font-size: 11px">*</a></label>
                    <div class="controls">
                        <asp:DropDownList ID="drpRole" runat="server" CssClass="form-control" AutoPostBack="true" Width="60%" OnSelectedIndexChanged="drpRole_change">
                        </asp:DropDownList>

                    </div>
                </div>

               <%-- <div class="form-group">
                    <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                        Text="Save" OnClick="BtnSave_Clcik" />
                </div>--%>
                <div class="row" style="padding:0px;" >
                    
                       <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                        Text="Save" OnClick="BtnSave_Clcik" />
                    
                </div>

            </div>
            <div class="col-md-7">
                <asp:GridView ID="gridviewPagePermissiones" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewPagePermissiones_PageIndexChanging" PageSize="100">
                    <Columns>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
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
                                <asp:Label ID="lblPageId" runat="server" Text='<%# Eval("PageID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblcategoryhId" runat="server" Text='<%# Eval("CategoryId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblModuleId" runat="server" Text='<%# Eval("ModuleId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="15%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ModuleName" HeaderText="Module">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CategoryName" HeaderText="Feature">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="pageName" HeaderText="Page">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>


                        <asp:TemplateField HeaderText="Visit">
                            <ItemTemplate>

                                <asp:CheckBox ID="chCanVisit" runat="server" Checked='<%# bool.Parse(Eval("CanVisit").ToString() == "True" ? "True": "False")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>

                                <asp:CheckBox ID="ChCanEdit" runat="server" Checked='<%# bool.Parse(Eval("CanEdit").ToString() == "True" ? "True": "False")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>

                                <asp:CheckBox ID="ChCanDelete" runat="server" Checked='<%# bool.Parse(Eval("CanDelete").ToString() == "True" ? "True": "False")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Execute">
                            <ItemTemplate>

                                <asp:CheckBox ID="ChCanExecute" runat="server" Checked='<%# bool.Parse(Eval("CanExecute").ToString() == "True" ? "True": "False")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--  <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnModulEdit" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgbtnModulEdit_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <RowStyle CssClass="Grid_RowStyle" />
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Footer" />
                </asp:GridView>

            </div>
        </div>
    </div>
             </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }

            //else if (result === 'Data Updated Successfully') {
            //    toastr.success(result);
            //}

            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
