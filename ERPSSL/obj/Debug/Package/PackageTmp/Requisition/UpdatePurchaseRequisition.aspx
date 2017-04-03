<%@ Page Title="" Language="C#" MasterPageFile="~/Requisition/Site.Master" AutoEventWireup="true"
    CodeBehind="UpdatePurchaseRequisition.aspx.cs" Inherits="ERPSSL.INV.UpdatePurchaseRequisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Update Purchase Requisition
                    </div>
                </div>

                <div class="hm_sec_2_content scrollbar">
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <asp:HiddenField ID="hdnOfficeID" runat="server" />
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Requisition Information</span></legend>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlDepartment" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDepartment"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Department"
                                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlEmployee"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Employee"
                                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Reason/Justification
                                            </div>

                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtJustification" Width="580%" Height="33px" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Requisition No.<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRequisitionNo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRequisitionNo"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Requisition No. is Required" Font-Size="11px"
                                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Designation
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Date<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Date"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Expected Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtExpectedDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExpectedDate"
                                                    PopupButtonID="txtExpectedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                    Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtExpectedDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Date"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Reason/Justification
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="" TextMode="MultiLine" Height="130px" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>

                        </fieldset>

                    </div>

                    <div class="col-md-12">
                        <fieldset style="background: #ccc;">
                            <%--<div class="col-md-12">--%>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlProductGroup" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged"
                                    AutoPostBack="True" Width="116%">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProductGroup"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlProduct" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"
                                    AutoPostBack="True" Width="116%">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProduct"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" Placeholder="Description" Width="116%" AutoPostBack="true" OnTextChanged="txtDescription_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtBalanceQty" Class="form-control" runat="server" ReadOnly="true" placeholder="Stock" Width="144%"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:DropDownList ID="ddlUnit" CssClass="form-control" runat="server" Width="144%">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlUnit"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Unit"
                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                <%--<asp:TextBox ID="txtUnit" Class="form-control" runat="server" ReadOnly="true" Placeholder="Unit" Width="144%"></asp:TextBox>--%>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" Placeholder="Req. Qty" Width="144%"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Quantity"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Placeholder="Remarks here" Width="116%"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="BtnSave" runat="server" Text="Update" Style="margin-top: 0px; margin-right: 0px;"
                                     class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                            </div>
                            <%-- </div>--%>
                        </fieldset>

                    </div>

                    <div class="col-md-12">
                      <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Req. Item List</span></legend>
                            <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowCommand="grdRequisitions_RowCommand"
                                BorderWidth="1px" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                    <%-- <asp:BoundField DataField="ReqNo" HeaderText="Requisition No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                    <asp:BoundField DataField="DPT_NAME" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%--   <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo")%>' />
                                                    </ItemTemplate>
                                           </asp:TemplateField>--%>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Style/Size">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Req. Quantity">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="ReqDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEditData" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                CommandName="edt" ImageUrl="img/edit.png" />
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                CommandName="dlt" ImageUrl="img/list_Delete.png" />

                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
                    <div class="col-md-12" style="text-align:right;">
                        <asp:Button ID="btnBack" CssClass="btn btn-info pull-right"  runat="server" Text="Purchase Requisition List" OnClick="btnBack_Click" />

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script type="text/javascript">

        function func(result) {
            if (result === 'Requisition updated successfully') {
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
