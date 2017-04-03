<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="WorkOrderTransaction.aspx.cs" Inherits="ERPSSL.Marketing.WorkOrderTransaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
        }

        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Work Order Transaction
                        </div>
                    </div>
                    <br />
                    <div class="row" style="margin: auto 0;">
                        <div class="col-md-5" style="margin: auto 0;">
                            <div class="row">
                                <asp:TextBox ID="searchTextBox" placeholder="Search By Client Name" Width="97%" AutoPostBack="true" CssClass="form-control" runat="server" OnTextChanged="searchTextBox_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchClientName"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="searchTextBox"
                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                                <asp:HiddenField ID="HidMarketingInfoId" runat="server" />
                                <asp:HiddenField ID="HiddwnFieldWorkOrderId" runat="server" />
                            </div>                           
                        </div>

                        <div class="col-md-7" style="margin: auto 0;" >
                            <table>
                                <tr>
                                    <td style="font-size: 15px; padding-right:4px;">Total Amount:</td>
                                    <td style="font-size: 15px;">
                                        <asp:Label ID="totalAmountLabel" runat="server" Text="0.00" ForeColor="#009900"></asp:Label></td>
                                    <td style="width:10px;"></td>
                                    <td style="font-size: 15px; padding-right:4px;">Paid Amount:</td>
                                    <td style="font-size: 15px;">
                                        <asp:Label ID="paidAmountLabel" runat="server" Text="0.00" ForeColor="#0066FF"></asp:Label></td>
                                    <td style="width:10px;"></td>
                                    <td style="font-size: 15px; padding-right:4px;">Due Amount:</td>
                                    <td style="font-size: 15px;">
                                        <asp:Label ID="dueAmountLabel" runat="server" Text="0.00" ForeColor="#CC0000"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </div>


                    <div class="row" style="margin: auto 0;">
                        <div class="col-md-12 bg-success">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                        
                        <div class="col-md-12" style="margin: auto 0; background-color: #a7c5a7; padding-bottom: 10px;">
                            <div class="col-md-4" style="margin: auto 0;">
                                <div class="row" style="padding-top: 5px;">
                                    Collection Date <span style="color: red; font-size: 11px">*</span>
                                   <asp:TextBox ID="collectionDateTextBox" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="collectionDateTextBox"
                                        PopupButtonID="collectionDateTextBox" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorWorkOrderDate" runat="server" ErrorMessage="Input Collection Date" ValidationGroup="marketing" ControlToValidate="collectionDateTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Collection Amount <span style="color: red; font-size: 11px">*</span>
                                    <asp:TextBox ID="collectionAmountTextBox" runat="server" placeholder="Collection Amount" class="form-control" AutoPostBack="True" OnTextChanged="collectionAmountTextBox_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorWorkCompletionPeriod" runat="server" ErrorMessage="Input Collection Amount" ValidationGroup="marketing" ControlToValidate="collectionAmountTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>                                                                
                                <div class="row" style="padding-top: 5px;">
                                    Remaining Amount
                                    <asp:TextBox ID="remainingAmountTextBox" runat="server" Enabled="false" placeholder="Remaining Amount" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Work Order Date
                                    <asp:TextBox ID="workorderDateTextBox" runat="server" placeholder="Work Order Date" Enabled="false" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Remarks
                                    <asp:TextBox ID="remarksTextBox"  runat="server" placeholder="Remarks" class="form-control"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-4" style="margin: auto 0;">
                                <%--<div class="row">
                                    Buyer Type
                                    <asp:DropDownList ID="ddlBuyerType" runat="server" Enabled="false" class="form-control">
                                        <asp:ListItem Text="---Select One---" Value="0"></asp:ListItem>
                                        <asp:ListItem>Foreign</asp:ListItem>
                                        <asp:ListItem>Local</asp:ListItem>
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="row" style="padding-top: 5px;">
                                    Visit Date
                                    <asp:TextBox ID="visitDateTextBox" runat="server" placeholder="MM/dd/yyyy" class="form-control" Enabled="false"></asp:TextBox>
                                    <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1"
                                        PopupButtonID="TextBox1" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Client Name
                                   <asp:TextBox ID="clientNameTextBox" runat="server" Enabled="false" placeholder="Client Name" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Contact Person
                                    <asp:TextBox ID="contactPersonTextBox" runat="server" Enabled="false" placeholder="Contact Person" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Designation
                                    <asp:TextBox ID="designationTextBox" runat="server" Enabled="false" placeholder="Designation" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Contact Number
                                   <asp:TextBox ID="contactNumberTextBox" runat="server" Enabled="false" placeholder="Contact Number" class="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4" style="margin: auto 0;">
                              <div class="row" style="padding-top: 5px;">
                                    E-Mail
                                    <asp:TextBox ID="emailTextBox" runat="server" placeholder="E-Mail" Enabled="false" class="form-control"></asp:TextBox>                                   
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Address
                                   <asp:TextBox ID="addressTextBox" runat="server" Enabled="false" placeholder="Address" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Project
                                    <asp:TextBox ID="projectTextBox" runat="server" Enabled="false" placeholder="Project" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Module
                                    <asp:TextBox ID="moduleTextBox" runat="server" Enabled="false" placeholder="Module" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    Marketing Person
                                   <asp:TextBox ID="marketingPersonTextBox" runat="server" Enabled="false" placeholder="Marketing Person" class="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 8px;">
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-9" style="padding: 0; padding-top: 11px;">
                                        <asp:Button ID="saveButton" runat="server" ValidationGroup="marketing" Text="Submit" class="btn btn-info  pull-right" OnClick="saveButton_Click"/>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>

                    <%-- Grid View --%>

                    <div class="row" style="margin: auto 0;">
                        
                        <div class="col-md-12" style="margin: auto 0; padding-top:2px;">
                            

                            <asp:GridView ID="TransactionGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="5" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Sl No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID_transaction" runat="server" Text='<%# Eval("TransactionId")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField HeaderText="Collection Date" DataField="CollectionDate" DataFormatString="{0:MM/dd/yyyy}" />

                                            <asp:BoundField DataField="CollectionAmount" HeaderText="Collection Amount" DataFormatString="{0:0.00}" />

                                            <asp:BoundField HeaderText="Remarks" DataField="Remarks" />

                                            <asp:TemplateField HeaderText="Edit" Visible="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButtonEidtWordOrder" runat="server" ImageUrl="~/img/list_edit.png"/>
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
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Save Successfully') {
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
