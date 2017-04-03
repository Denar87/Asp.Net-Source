<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="ERPSSL.FA.Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
<div class="hm_sec_2_content scrollbar">
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Department Setup
        </div>
    </div>
    <div class="row">
    <div class="row">
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        
        <div class="col-md-12">
             <br />
            <div class="col-md-5">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Region
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="drpdwnResionForDepartment" AutoPostBack="True" class="form-control"
                                OnSelectedIndexChanged="drpdwnResionForDepartmentSelecttedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Office
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="drpdwnOffice" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="drpdwnOffice_SelecttedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Department Name
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxDepartemntName" class="form-control" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidDepartmentId" runat="server" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Code
                        </div>
                        <div class="col-md-7">
                            <asp:Label ID="lblOfficeCode" runat="server"></asp:Label>
                            <asp:TextBox ID="txtbxDepartmentCode" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnDepartmentSubmit" runat="server" OnClick="btnDepartmentSubmit_Click"
                                Text="Submit" class="btn btn-info  pull-right" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <asp:GridView ID="gridviewDepartmetn" runat="server" AutoGenerateColumns="False"
                    Width="100%" CellPadding="10" AllowPaging="True" OnPageIndexChanging="gridviewDepartmetn_PageIndexChanging" PageSize="20">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate  >
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartmetn" runat="server" Text='<%# Eval("DPT_ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ResionName" HeaderText="Region">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OfficeName" HeaderText="Office">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DPT_NAME" HeaderText="Department">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DPT_CODE" HeaderText="Department Code">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnDepartmentEdit" runat="server" ImageUrl="img/list_edit.png"
                                    OnClick="imgbtnDepartmentEdit_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <RowStyle CssClass="Grid_RowStyle" />
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <PagerStyle ForeColor="#000066" HorizontalAlign="Justify" BackColor="#6393C1" CssClass="pagination01 pageback" />
                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Footer" />
                </asp:GridView>
            </div>
        </div>
            </div>
    </div>
   </div>
</ContentTemplate>
<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnDepartmentSubmit" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="drpdwnResionForDepartment" EventName="SelectedIndexChanged" />
<asp:AsyncPostBackTrigger ControlID="drpdwnResionForDepartment" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Data Save Successfully') {
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
