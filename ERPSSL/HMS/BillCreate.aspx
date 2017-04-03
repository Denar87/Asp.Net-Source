<%@ Page Title="" Language="C#" MasterPageFile="~/HMS/HMS.Master" AutoEventWireup="true"
    CodeBehind="BillCreate.aspx.cs" Inherits="ERPSSL.HMS.BillCreate" ClientIDMode="Static" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Bill Create Generate
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="15px"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">


                        <div class="col-md-6">
                            <div class="panel panel-info">
                                <div class="panel-heading " style="background-color: #778899; color: white">Patient Info </div>
                                <div class="panel-body" style="font-size: 11px; height: 240px; color: green; margin-top: 0px; margin-bottom: 0px;">


                                    
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Patient Name
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtName" class="form-control" runat="server" OnTextChanged="txtName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <cc2:AutoCompleteExtender ServiceMethod="SearchPatientByName"
                                                            MinimumPrefixLength="1"
                                                            CompletionInterval="100" EnableCaching="False"
                                                            TargetControlID="txtName"
                                                            ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                                        </cc2:AutoCompleteExtender>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row" style="padding-top: 10px;">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Patient ID
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtId" class="form-control" runat="server" OnTextChanged="txtId_TextChanged" AutoPostBack="true"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-top: 10px;">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Age
                                               
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox ID="txtAge" Class="form-control " runat="server" Enabled="false"></asp:TextBox>

                                                    </div>
                                                    <div class="col-md-4">

                                                        <asp:DropDownList ID="ddlAgeFormat" CssClass=" form-control" runat="server" Enabled="false">
                                                            <asp:ListItem Value="Day">Day</asp:ListItem>
                                                            <asp:ListItem Value="Month">Month</asp:ListItem>
                                                            <asp:ListItem Value="Year" Selected="True">Year</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-top: 10px;">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Blood Group 
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlBlood" CssClass=" form-control" runat="server" Enabled="false">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="A+">A+</asp:ListItem>
                                                            <asp:ListItem Value="A-">A-</asp:ListItem>
                                                            <asp:ListItem Value="B+">B+</asp:ListItem>
                                                            <asp:ListItem Value="B-">B-</asp:ListItem>
                                                            <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                            <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                            <asp:ListItem Value="O+">O+</asp:ListItem>
                                                            <asp:ListItem Value="O-">O-</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 10px;">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Mobile 
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtMobile" class="form-control" runat="server" Enabled="false"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                       
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel panel-info">
                                <div class="panel-heading " style="background-color: #778899; color: white">Bill Heading </div>
                                <div class="panel-body" style="font-size: 11px; height: 280px; color: green; margin-top: 0px; margin-bottom: 0px;">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Bill Collection Date
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtCollectionDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtCollectionDate"
                                                    PopupButtonID="txtCollectionDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 10px;">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Bill Category
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlCategory" CssClass=" form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 10px;">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Bill Head
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlHead" CssClass=" form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 10px;">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Price
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 10px;">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Qty
                                               
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtQty" Class="form-control " runat="server" OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtTotalAmt" Class="form-control " runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 10px;">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-info pull right" ValidationGroup="Group1" OnClick="btnAdd_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <br />

                <div class="col-md-6">
                    <fieldset style="border-color: skyblue; width: 100%">
                        <legend style="line-height: 5px; border-color: skyblue"><span style="background: #fff">Patient Bill Information Details</legend>
                        <asp:GridView ID="GridViewBillInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="True" AllowSorting="True" CellPadding="5">
                            <Columns>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        SL No.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="CategoryName" HeaderText="Bill Category">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Bill_Head_Name" HeaderText="Bill Head">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Remove">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnRemoveImg" runat="server" ImageUrl="~/HMS/img/Delete.png" OnClick="btnRemoveImg_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>

                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:GridView>
                        </span>
                    </fieldset>
                </div>

                <div class="col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading " style="background-color: #778899; color: white">Bill Information </div>
                        <div class="panel-body" style="font-size: 11px; height: 240px; color: green; margin-top: 0px; margin-bottom: 0px;">

                            <div class="col-md-3">
                                <div class="row">

                                    <div>
                                        Total Amount
                                               <asp:TextBox ID="txtTotal" Class="form-control " runat="server" Enabled="false" ForeColor="Blue"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">

                                    <div>
                                        Service Charge (%)
                                               <asp:TextBox ID="txtServiceCharge" Class="form-control " runat="server" Text="0" ForeColor="Blue" AutoPostBack="true" OnTextChanged="txtServiceCharge_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        Charge Amount
                                                <asp:TextBox ID="txtServiceAmt" runat="server" Class="form-control " ForeColor="Blue"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        Select for Discharge 
                                              <asp:CheckBox ID="chkStleWise" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkStleWise_CheckedChanged"></asp:CheckBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3" style="margin-left: 40px;">
                                <div class="row">

                                    <div>
                                        Paid Amount
                                               <asp:TextBox ID="txtPaid" class="form-control" runat="server" Enabled="false" ForeColor="Black"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">

                                    <div>
                                        Discount (%)
                                               <asp:TextBox ID="txtDiscount" Class="form-control " runat="server" Text="0" ForeColor="Blue" AutoPostBack="true" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">

                                    <div>
                                        Discount Amount
                                               <asp:TextBox ID="txtDiscountAmt" Class="form-control " runat="server" ForeColor="Blue" AutoPostBack="true" OnTextChanged="txtDiscountAmt_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div style="padding-top: 15px;">
                                        <asp:TextBox ID="txtDischargDate" Class=" form-control2 form-control " runat="server" placeholder="Discharge Date" Visible="false"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDischargDate"
                                            PopupButtonID="txtDischargDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-3" style="margin-left: 40px;">
                                <div class="row">

                                    <div>
                                        Due Amount
                                               <asp:TextBox ID="txtDue" class="form-control" runat="server" Enabled="false" ForeColor="Red"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">

                                    <div>
                                        Net Amount
                                               <asp:TextBox ID="txtNetAmount" Class="form-control " runat="server" Enabled="false" ForeColor="Blue"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        Receive Amount 
                                            <asp:TextBox ID="txtReceiveAmt" runat="server" Class="form-control " ForeColor="Blue"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">

                                    <div style="padding-top: 15px;">
                                        <asp:Button ID="txtPrint" runat="server" class="btn btn-primary pull right" Text="Print" ValidationGroup="Group1" OnClick="txtPrint_Click" Style="margin-top: 0px; margin-right: -55px;" />
                                        <asp:Button ID="btnBillAdd" runat="server" class="btn btn-info pull right" OnClick="btnBillAdd_Click" Text="Receive" ValidationGroup="Group1" Style="margin-right: 38px; padding: 5px;" />

                                    </div>
                                </div>


                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                </div>
                                <div style="margin-right: 80px;">
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <div class="row">
                        <div>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="80%"
                                Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                                PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                                InteractivityPostBackMode="AlwaysSynchronous">
                            </rsweb:ReportViewer>
                        </div>
                    </div>

                </center>

            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {

            if (result === 'Data Saved Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Deleted Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else if (result === 'The patient is Discharged !!') {
                toastr.error(result);
            }
            else if (result === 'No Data Found!') {
                toastr.error(result);
            }
            else {
                toastr.error(result);
            }

            return false;
        }
    </script>

</asp:Content>


