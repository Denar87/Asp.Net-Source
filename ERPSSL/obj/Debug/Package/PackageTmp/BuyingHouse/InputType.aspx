﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="InputType.aspx.cs" Inherits="ERPSSL.BuyingHouse.InputType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Input Type Setup
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <asp:HiddenField ID="hidInputid" runat="server" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Input Category
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlDept" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:TextBox ID="txtDept" class="form-control"  runat="server" Visible="false"></asp:TextBox>

                                    </div>
                                    <div class="col-md-1" style="margin-left:0px;">
                                        <asp:CheckBox ID="chkDept" AutoPostBack="true" OnCheckedChanged="chkDept_CheckedChanged" Checked="false" runat="server" />
                                    </div>

                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Input Type
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtbxInputType" runat="server" class="form-control"></asp:TextBox>
                                        <%--<asp:HiddenField ID="hidEmployeeTypeId" runat="server" />--%>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxInputType"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Type Here"
                                            ValidationGroup="GroupInputType"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Serial No.
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtSerial" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSerial"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Serial No"
                                            ValidationGroup="GroupInputType"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="btnInputTypeSubmit" ValidationGroup="GroupInputType" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="btnInputTypeSubmit_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-7">
                            <asp:GridView ID="gridviewInputType" runat="server" AutoGenerateColumns="False"
                                Width="100%" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewInputType_PageIndexChanging">
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
                                            <asp:Label ID="lblInputTypeId" runat="server" Text='<%# Eval("InputType_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Use_Dept" HeaderText="Department">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Input_Name" HeaderText="Input Type">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sl_No" HeaderText="Serial">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnInputTypeEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnInputTypeEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnInputTypeSubmit" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>