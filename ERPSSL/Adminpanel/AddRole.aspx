<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="ERPSSL.Adminpanel.AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
   <%-- <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Add Role
        </div>
    </div>--%>
    <div class="hm_sec_2_content scrollbar">
         <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Add Role
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
                        Role Name:<a style="color: red; font-size: 11px">*</a></label>
                    <div class="controls">
                        <asp:TextBox ID="txtbxRoleName" runat="server"  CssClass="form-control" Width="60%"></asp:TextBox>
                        
                        <asp:HiddenField ID="hidRoleId" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxRoleName"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Role Name"
                                        Font-Size="11px" ValidationGroup="Group2"></asp:RequiredFieldValidator>

                    </div>
                </div>
               
                    <%--<div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                            Text="Save Role" OnClick="BtnSave_Click" />
                    </div>--%>
                <div class="row" style="padding:0px;" >                  
                        <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                            Text="Save Role" OnClick="BtnSave_Click" />
                    
                </div>


            </div>
            <div class="col-md-7">
                <asp:GridView ID="gridviewRole" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewRole_PageIndexChanging">
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
                                <asp:Label ID="lblRoleId" runat="server" Text='<%# Eval("RoleID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RoleName" HeaderText="Modul">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                       

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnRoleEdit" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgbtnRoleEdit_Click" />
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

            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
