<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="ReceivedByPO.aspx.cs" Inherits="ERPSSL.INV.ReceivedByPO" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <style>
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
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>

            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>

                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="col-md-12">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>MRR By PO
                       
                        </div>
                    </div>

                    <asp:HiddenField ID="hdnBarCode" runat="server" />
                    <asp:HiddenField ID="hdnEID" runat="server" />

                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>

                    <div class="col-md-12">
                        <div class="col-md-12">
                            <br />
                            <div class="panel panel-success">
                                <div class="panel-heading"><b>PO Summary List</b> </div>
                                <div class="panel-body">
                                    <div class="col-md-12">

                                        <asp:HiddenField ID="HiddenCompanyCode" runat="server" />
                                        <asp:HiddenField ID="HiddenCompanyName" runat="server" />

                                        <asp:GridView ID="grdPOList" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataKeyNames="LC_PO_No" GridLines="Both" Width="100%">
                                            <Columns>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <HeaderTemplate>
                                                        Sl.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="PO No." Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPONo" runat="server" Text='<%# Bind("LC_PO_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="LC_PO_Date" HeaderText="PO Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Buyer_Name" HeaderText="Buyer Name">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Lc_Style" HeaderText="Style">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Lc_Order" HeaderText="Order No.">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgSelect" runat="server" OnClick="imgSelect_Click" ImageUrl="img/edit.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="FinishGoods_Name" HeaderText="Item">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="FinishedGoods_Qty" HeaderText="Qty">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle BackColor="White" CssClass="Grid_RowStyle" ForeColor="#333333" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle BackColor="#336666" CssClass="pagination01 pageback" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#336666" CssClass="Grid_Header" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" Width="10%" />
                                            <FooterStyle BackColor="White" CssClass="Grid_Footer" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <br />
                            <div class="panel panel-success">
                                <div class="panel-heading"><b>Items Details</b> </div>
                                <div class="panel-body">
                                    <div class="col-md-12">
                                        <div class="row" style="display: none;">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Store
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlCompanyCode" Class="form-control" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- <asp:GridView ID="grvPOItemList" runat="server" ShowFooter="true" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataKeyNames="PrOrderNo" GridLines="Both" PageSize="20" Width="100%">--%>
                                        <asp:GridView ID="grvPOItemList" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" GridLines="Both" DataKeyNames="LC_PO_No"
                                            BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20"
                                            OnRowDataBound="grvDeliverySchedule_RowDataBound">
                                            <Columns>

                                                <asp:TemplateField ItemStyle-Width="2%">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="rowLevelCheckBox_CheckedChanged" />
                                                        <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                        <itemstyle horizontalalign="Left" width="2%" cssclass="Grid_Border" />
                                                        <footerstyle cssclass="Grid_Footer" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <HeaderTemplate>
                                                        Sl.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("LC_PurchaseOrder_Id")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("LC_PO_No")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStyleAndSize" runat="server" Text='<%# Eval("StyleAndSize")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("ProductId")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--   <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLastReceive" runat="server" Text='<%# Eval("LastReceive")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ProductName")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("LC_PO_Qty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--<asp:BoundField DataField="ProductName" HeaderText="Item" ItemStyle-Width="25%" Visible="false" />--%>

                                                <%--<asp:BoundField DataField="Brand" HeaderText="Brand" ItemStyle-Width="15%" Visible="false" />--%>

                                                <%--<asp:BoundField DataField="StyleAndSize" HeaderText="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="18%" />--%>

                                                <asp:BoundField DataField="LC_PO_Qty" HeaderText="PO Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="9%" />

                                                <asp:BoundField DataField="UnitName" HeaderText="Unit" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="8%" SortExpression="UnitName" />

                                                <%--<asp:BoundField DataField="LastReceive" HeaderText="Total Receive" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" />--%>

                                                <asp:TemplateField HeaderText="Receive Qty" Visible="true" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbxReceiveAmount" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText=" Store" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStoreName" Width="100%" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--  <asp:TemplateField HeaderText=" UM Checked Condition" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="drpumCkeck" Width="100%" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Reciept Condition" ItemStyle-Width="11%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlRecieptCondition" Width="100%" runat="server">
                                                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                            <asp:ListItem>Avarage</asp:ListItem>
                                                            <asp:ListItem>Damage</asp:ListItem>
                                                            <asp:ListItem>Good</asp:ListItem>
                                                            <asp:ListItem>Poor</asp:ListItem>
                                                            <asp:ListItem>Others</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Remarks" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarks" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right" ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotal" Text='<%# Eval("Total_Amount")%>' runat="server" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblGrandTotal" runat="server" Font-Bold="true" Font-Size="12px" />
                                                </FooterTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle Width="8%" CssClass="Grid_Border" />
                                            </asp:TemplateField>--%>
                                            </Columns>

                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                                Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>

                                        <div class="col-md-12" style="padding: 0px;" id="lblpro" runat="server">


                                            <%--<div class="col-md-3" style="padding:0px;">  
                                        <div class="col-md-12">
                                            Project Name
                                        </div>
                                        <div class="col-md-12">
                                            <asp:DropDownList ID="ddlProject" Class="form-control" runat="server" >
                                            </asp:DropDownList>
                                            </div>
                                    </div>

                                        <div class="col-md-3" style="padding:0px;">

                                            <div class="col-md-12">
                                            Store Location
                                        </div>
                                        <div class="col-md-12">
                                            <asp:DropDownList ID="ddlStoreName" Class="form-control" runat="server" >
                                            </asp:DropDownList>
                                        </div>
                                        </div>

                                          <div class="col-md-3" style="padding:0px;">

                                              <div class="col-md-12">
                                            Location Unit 
                                        </div>
                                        <div class="col-md-12">
                                            <asp:DropDownList ID="ddlStoreUnit" Class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>

                                              </div>
                                     
                                          <div class="col-md-2" style="padding:0px;">
                                                <div class="col-md-12">
                                            Remark
                                        </div>
                                        <div class="col-md-12">
                                         
                                                    <asp:TextBox ID="txtRemark"  Class="form-control" runat="server" Width="100%"></asp:TextBox>
                                                
                                        </div>
                                              </div>--%>
                                            <div class="col-md-1" style="padding-top: 12px; float: right; margin-right: -10px;">
                                                <asp:Button ID="btnTransfer" runat="server" Text="Receieve"
                                                    class="btn btn-info pull-right" OnClick="btnTransfer_Click" />
                                                <asp:HiddenField ID="hidGin" runat="server" />
                                                <asp:HiddenField ID="hidEid" runat="server" />
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <br />
                            <div class="panel panel-success">
                                <div class="panel-heading"><b>Received PO Search By Date</b></div>
                                <div class="panel-body">
                                    <div class="row">

                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-12">

                                                    <div class="col-md-4" style="padding-left: 0px;">
                                                        From Date
                                                    </div>

                                                    <div class="col-md-8" style="padding-left: 0px;">

                                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxFromDate" autocomplete="off"
                                                            placeholder="MM/dd/yyyy"></asp:TextBox>

                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxFromDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="row">
                                                    <div class="col-md-4" style="padding-left: 0px;">
                                                        To Date
                                                    </div>

                                                    <div class="col-md-8" style="padding-left: 0px;">
                                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxToDate" autocomplete="off"
                                                            placeholder="MM/dd/yyyy"></asp:TextBox>

                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxToDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="row">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search"
                                                        class="btn btn-success" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <br />
                                            <asp:GridView ID="GrdviewAfterDeiveryProduct" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" GridLines="Both" DataKeyNames="ChallanNo"
                                                BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" OnPageIndexChanging="GrdviewAfterDeiveryProduct_PageIndexChanging">
                                                <Columns>

                                                    <asp:BoundField DataField="ChallanNo" HeaderText="MRR No.">
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="Product Name">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Style/Size">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ReceiveQuantity" HeaderText="Receive Quantity">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ChallanDate" HeaderText="MRR Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                </Columns>
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                                    Font-Bold="True" ForeColor="White" />
                                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#275353" />
                                            </asp:GridView>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Purchase information posted successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }
    </script>

</asp:Content>
