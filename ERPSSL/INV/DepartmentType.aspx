<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentType.aspx.cs" Inherits="ERPSSL.INV.DepartmentType" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
    
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Department Type
        </div>
    </div>
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
                                Department
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
                                Type
                            </div>
                            <div class="col-md-7">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:TextBox ID="txtbxType" runat="server" class="form-control"></asp:TextBox>
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
                                    Text="Submit" class="btn btn-info pull-right" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <asp:GridView ID="gridviewDepartmetn" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="10" AllowPaging="True" OnPageIndexChanging="gridviewDepartmetn_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartmetn" runat="server" Text='<%# Eval("DepartmentTypeId")%>' />
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

                            <asp:BoundField DataField="DepartmentType" HeaderText="Dept. Type">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="DPT_CODE" HeaderText="Dep. Code">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
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
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
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
            else if (result === 'Please Select Resion!') {
                toastr.error(result);
            }
            else if (result === 'Please Input Department Name!') {
                toastr.error(result);
            }
            else if (result === 'Please Input Department Code!') {
                toastr.error(result);
            }
            else if (result === 'Department Code Minmum Length 3!') {
                toastr.error(result);
            }

            else if (result === 'Please Input Department Type!') {
                toastr.error(result);
            }
            else if (result === 'Please Input Department Type!') {
                toastr.error(result);
            }
            else if (result === 'Data Updated Sucessfully') {
                toastr.success(result);
            }
            
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
