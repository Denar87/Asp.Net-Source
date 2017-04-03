<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="PriceChange.aspx.cs" Inherits="ERPSSL.INV.PriceChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
    <div class="row">        
        <asp:HiddenField ID="hdnBarCode" runat="server" />        
        <div class="hm_sec_2_content scrollbar">
            <div class="col-md-12 bg-success">
                <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="glyphicon glyphicon-edit icon-padding"></i>Price Change
            </div>
        </div>
            <center>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
        </div>
            <div class="row">
                <fieldset style="border: none;">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Date
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                            PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Store
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlStore" AutoPostBack="True" CssClass="form-control" runat="server"
                                            OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStore"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Store"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Item Group
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlProductGroup" CssClass="form-control" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProductGroup"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Item Name
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlProduct" CssClass="form-control" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProduct"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Balance Qty
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtBalanceQty" CssClass="form-control" runat="server" ReadOnly=true></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Old CPU
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtOldCPU" CssClass="form-control" runat="server" ReadOnly=true></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Change CPU
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtChangeCPU" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtChangeCPU"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter New CPU"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="BtnSave" runat="server" Text="Change" class="btn btn-info pull-right" OnClick="BtnSave_Click"  ValidationGroup="Group1"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
     <script>

         function func(result) {
             if (result === 'Price has been updated successfully!') {
                 toastr.success(result);

             }
            else if (result === 'Error in updating price!') {
                 toastr.error(result);

             }
            

             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>
