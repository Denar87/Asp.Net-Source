<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="StoreRequisition.aspx.cs" Inherits="ERPSSL.INV.StoreRequisition" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Store Requisition
                    </div>
                </div>
                <div class="row" style="margin: 0 auto">

                    <asp:HiddenField ID="hdnDEPT_CODE" runat="server" />
                    <asp:HiddenField ID="hidReportingBossID" runat="server" />
                    <asp:HiddenField ID="hdnOfficeID" runat="server" />
                    <asp:HiddenField ID="hdReqNo" runat="server" />

                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        </center>
                    </div>

                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0"><span style="background: #fff">Requisition Information</span></legend>
                            <div class="row" style="margin: auto 0;">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-5">
                                            E-ID<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtEID" CssClass="form-control" runat="server" OnTextChanged="txtEID_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEID"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter E-ID"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5">
                                            Wing<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <%--<asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlDepartment" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDepartment"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Department"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5">
                                            Employee<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <%--<asp:TextBox ID="txtEmployee" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-5">
                                            Date<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                                PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDate"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Date"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5">
                                            Designation
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5">
                                            Requisition For/Purpose
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRequisitionFor" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5" style="color: red">
                                            Requisition No.<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRequisitionNo" CssClass="form-control" runat="server" ReadOnly="true" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5">
                                            Expected Date<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtExpectedDate" CssClass="form-control" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExpectedDate"
                                                PopupButtonID="txtExpectedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtExpectedDate"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Date"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-5">
                                            Location
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-md-12">
                        <fieldset style="background: #ccc;">
                            <div class="row" style="margin: auto 0; margin-left: -19px; padding: 0;">
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlProductGroup" CssClass="form-control" Width="106%" runat="server" OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProductGroup"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlProduct" CssClass="form-control" Width="106%" runat="server" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProduct"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtQuantity" CssClass="form-control" Width="142%" runat="server" Placeholder="Req. Qty"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Quantity"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtUnit" Class="form-control" Width="142%" runat="server" ReadOnly="true" Placeholder="Unit"></asp:TextBox>
                                </div>
                                <%--<div class="col-md-1" style="width: 20%;" >                                 
                                    <asp:DropDownList ID="ddlProgram" CssClass="form-control" runat="server" >
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" Width="142%" runat="server" Placeholder="Remarks"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <div class="row" style="float:right;">
                                        <asp:Button ID="BtnSave" runat="server" Text="Add" ValidationGroup="Group1" class="btn btn-info" OnClick="BtnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <%-- <br />--%>
                    </div>

                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0px;"><span style="background: #fff">Req. Item List</span></legend>
                            <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowCommand="grdRequisition_RowCommand"
                                BorderWidth="1px" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                    <%-- <asp:BoundField DataField="ReqNo" HeaderText="Requisition No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                    <asp:BoundField DataField="DPT_NAME" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Req. Qty">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Left" Width="8%" />
                                    </asp:BoundField>
                                    <%--  <asp:BoundField DataField="Program" HeaderText="Program" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="8%" />
                                    </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="ReqDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEditData" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                CommandName="edt" ImageUrl="img/edit.png" />
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                CommandName="dlt" ImageUrl="img/list_Delete.png" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                    Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </fieldset>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-10"></div>
                        <div class="col-md-1">
                            <div class="col-md-1">
                                <asp:Button ID="btnPost" runat="server" Text="Post" Style="margin-top: 0px; margin-right: 0px;"
                                    class="btn btn-primary" OnClick="btnPost_Click" />
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning"
                                OnClick="btnPrint_Click" />
                        </div>
                    </div>
                    <div class="col-md-12">
                        <center>
                            <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                            </rsweb:ReportViewer>
                        </center>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/JavaScript">
        function func(result) {
            if (result === 'Requisition for this item added successfully') {
                toastr.success(result);
            }
            else if (result === 'Requisition added successfully') {
                toastr.success(result);
            }
            else if (result === 'Requisition for this item updated successfully') {
                toastr.success(result);
            }
            else if (result === 'Requisition item deleted successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
