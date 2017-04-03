<%@ Page Title="Inventory" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="ERPSSL.INV.index" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="../SpryAssets/SpryMenuBarHorizontal.css" rel="stylesheet" />

    <asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">

        <ContentTemplate>
            <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>WelCome 
                    </div>
                </div>
                <div class="col-md-12" style="padding-top: 10px;">
                    <div>
                        <marquee onmouseover="this.stop();" onmouseout="this.start();">
                            <asp:LinkButton ID="lblitem" OnClick="lblitem_Click" runat="Server"  ></asp:LinkButton>
                        </marquee>
                    </div>
                    <div class="col-md-4">
                        <div class="panel panel-success">
                            <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-shopping-cart"></i><b style="font-size: 14px; font-weight: bold;">&nbsp;Today Stock Details</b> </div>
                            <div class="panel-body">
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    MRR Qty.
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblMRRToday" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    GIN Qty.
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblGINToday" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Today Damage Qty.
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblTotalDamageToday" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Today Return Qty.
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblReturnToday" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <asp:Chart ID="Chart1" runat="server" ToolTip="Today Stock Details " Height="250px" Width="300px">
                                    <Titles>
                                        <asp:Title ShadowOffset="3" Name="Items" />
                                    </Titles>
                                    <Legends>
                                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" LegendStyle="Row" />
                                    </Legends>
                                    <Series>
                                        <asp:Series Name="Series1" ChartType="pie" ToolTip=" Tolal #VALX : #VALY" />
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" BorderWidth="0" />
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel panel-info">
                            <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-tags"></i><b style="font-size: 14px; font-weight: bold;">&nbsp;Today Requisition Details</b> </div>
                            <div class="panel-body">
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Store Requisition
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblStoreRequisition" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Approved Store Requisition
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblApproveStore" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Purchase Requisition
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblPurchaseReq" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Approved Purchase Requisition
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblApprovePurchaseReq" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <asp:Chart ID="Chart2" runat="server" ToolTip="Today Requisition Details " Height="250px" Width="300px">
                                    <Titles>
                                        <asp:Title ShadowOffset="3" Name="Items" />
                                    </Titles>
                                    <Legends>
                                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" Name="Today Requisition Details " LegendStyle="Row" />
                                    </Legends>
                                    <Series>
                                        <asp:Series Name="Series1" LegendText="Today Requisition Details" ChartType="Column" ToolTip="Tolal #VALX : #VALY" />
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" BorderWidth="0" />
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel panel-danger">
                            <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-filter"></i><b style="font-size: 14px; font-weight: bold;">&nbsp;Last Monthly  Details</b></div>
                            <div class="panel-body">
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Total Store Req
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblLastStore" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Total Purchase Req
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblLastPurchase" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Total MRR
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblLastMRR" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                                    Total GIN
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblLastGIN" runat="server" Text="0"></asp:Label></span>
                                </div>
                                <asp:Chart ID="Chart3" runat="server" ToolTip="Last Month  Details " Height="250px" Width="300px">
                                    <Titles>
                                        <asp:Title ShadowOffset="3" Name="Items" />
                                    </Titles>
                                    <Legends>
                                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="true" Name="Last Month  Details " LegendStyle="Row" />
                                    </Legends>
                                    <Series>
                                        <asp:Series Name="Series1" LegendText="Last Month  Details" ChartType="Column" ToolTip="Tolal #VALX : #VALY" />
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="false" BorderWidth="0" />
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="Panel1" runat="server" Style="width: auto;" CssClass="modalPopupFreight">
                <div>
                    <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                    <link href="../css/Modal2.css" rel="stylesheet" />
                    <div class="modal-dialog" style="width: auto;">
                        <asp:Panel ID="Panel3" runat="server">
                            <div class="popuHeader">
                                <asp:LinkButton ID="CancelButton" runat="server">
                                    <button type="button"  style="color:white" class="close" data-dismiss="modal"  aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                                <h4 id="myModalLabel">Re-Order List</h4>
                            </div>
                        </asp:Panel>
                        <div class="col-md-12 ">
                            <div class="row">
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                    SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana"
                                    WaitMessageFont-Size="14pt" BackColor="White" Style="width: auto; overflow: scroll;">
                                </rsweb:ReportViewer>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" Enabled="True" />
        </ContentTemplate>
    </asp:UpdatePanel>

 <script type="text/javascript">
     function func(result) {
         if (result === 'Product damage information inserted successfully') {
             toastr.success(result);
         }
         else
             toastr.error(result);
         return false;
     }
    </script>

</asp:Content>
