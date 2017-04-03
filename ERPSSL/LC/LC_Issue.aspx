<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="LC_Issue.aspx.cs" Inherits="ERPSSL.LC.LC_Issue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>

            <div class="row" style="margin: 0 auto">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>LC Issue
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>

                    <div class="row" style="margin: 0 auto">

                        <div class="col-md-12">
                            <div class="col-md-9">
                                <fieldset style="margin-right: 0px;">
                                    <%-- <legend style="line-height: 0;"><span style="background: #fff">Select Date</span></legend>--%>
                                    <div class="col-md-5">
                                        <div class="col-md-2">From</div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                                PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>

                                        <%-- // OnTextChanged="txtDate_TextChanged"--%>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="col-md-2">To</div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                                PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info " OnClick="btnSearch_Click" />
                                    </div>
                                </fieldset>
                            </div>


                            <div class="row" style="margin: 0 auto;">
                                <div class="row" style="margin: 0 auto;">
                                    <div class="col-md-6">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">PO Summary List</div>
                                            <div class="panel-body">
                                                <%-- <fieldset>
                                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Estimated List</span></legend>--%>
                                                <asp:GridView ID="grvLCIssue" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" OnRowCommand="gridBackToBack_RowCommand"
                                                    BorderWidth="1px" AllowPaging="True">

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLCPONo" runat="server" Text='<%# Bind("LC_PO_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="Cost_Estimate_ID" Visible="false" HeaderText="Cost Estimate ID">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Lc_Order" HeaderText="Order No.">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Buyer_Name" HeaderText="Buyer Name">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="Lc_Style" HeaderText="Style">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="OrderDate" Visible="false" HeaderText="Order Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="FinishGoods_Name" Visible="false" HeaderText="Item">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="FinishedGoods_Qty" Visible="false" HeaderText="Qty">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="link" runat="server" CommandName="View" CommandArgument='<%# Eval("Cost_Estimate_ID") %>'>
                                                                    <img id="Img2" src="~/img/list_edit.png" alt="View" runat="server" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
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
                                                <%--</fieldset>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <fieldset style="margin-right: 0px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    P.O  
                                                 <asp:TextBox ID="txtPO" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Buyer Name   
                                                            <asp:TextBox ID="txtBuyerName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Style 
                                                            <asp:TextBox ID="txtstyle" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                </div>
                                                  <div class="row">
                                                    Finished Goods
                                                            <asp:TextBox ID="txtFinishGoods_Name" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            
                                            <div class="col-md-6">
                                                <div class="row">
                                                    From Bank <a style="color: red; font-size: 11px">*</a>

                                                    <asp:TextBox ID="txtFromBank" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                </div>
                                                  <div class="row">
                                                   To Bank<a style="color: red; font-size: 11px">*</a>

                                                    <asp:TextBox ID="txtToBank" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    Branch Name<a style="color: red; font-size: 11px">*</a>
                                                    <asp:TextBox ID="txtBranchName" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                   LC Number<a style="color: red; font-size: 11px">*</a>
                                                    <asp:TextBox ID="txtLCNumber" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="row" style="margin-top:5px">
                                                    <asp:Button ID="btnLCIssue" runat="server" Text="LC Issue" CssClass="btn btn-info " OnClick="btnLCIssue_Click" />
                                                </div>

                                            </div>
                                    </div>
                                </div>

                                </fieldset>
                                 
                            </div>
                        </div>


                    </div>



                </div>

                <%-- </div>--%>
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
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Estimate Approved Successfully!') {
                toastr.success(result);
            }
            else if (result === 'Data recorded successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>


</asp:Content>
