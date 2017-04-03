<%@ Page Title="Subra-ERP Solution" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="ERPSSL.BuyingHouse.Index" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
     <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
   <%-- <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">--%>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- jvectormap -->
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel" style="margin-top: 100px;">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Welcome to Buying House
        </div>
    </div>
    <style type="text/css">
        #slideshow
        {
            position: relative;
            width: 500px;
            height: 200px;
        }

            #slideshow > div
            {
                position: absolute;
                top: 5px;
                right: 5px;
                bottom: 5px;
                height: 240px;
            }

        .iconI
        {
            font-size: 40px;
            padding-top: 20px;
        }

        .heights
        {
            height: 150px;
        }

        .backcolor1
        {
            text-align: left;
        }

        .backcolor2
        {
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            background-color: azure;
            text-align: center;
            font-size: 20px;
        }
    </style>
     <div class="row" style="padding-top:10px;">
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
             <asp:LinkButton ID="btnOngoingNumberOrder" Text="Ongoing Number Of Order" runat="server" PostBackUrl="~/BuyingHouse/OrderList.aspx">  <span class="info-box-icon bg-aqua"><i class="glyphicon glyphicon-play" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text">On going Orders</span>
                  <span class="info-box-number">  <asp:Label ID="lblOngoingNumberOfOrder" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                 <asp:LinkButton ID="btnShipmentDateWith7Days" Text="Shipment Date Within 7 Days" runat="server" PostBackUrl="~/BuyingHouse/ShipmentDateWiseOrderList.aspx"> <span class="info-box-icon bg-red"><i class="glyphicon glyphicon-calendar" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text">7 Days Shipment</span>
                  <span class="info-box-number"> <asp:Label ID="lblShipmentDateWith7Days" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
               <asp:LinkButton ID="btnListedNoOfFactory" Text="Listed No Of Factory" runat="server" PostBackUrl="~/BuyingHouse/FactoryList.aspx"> <span class="info-box-icon bg-green"><i class="glyphicon glyphicon-tower" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text">Active Factory</span>
                  <span class="info-box-number"> <asp:Label ID="lblListedNooFactory" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                 <asp:LinkButton ID="btnExistingActiveBuyer" Text="Existing Active Buyer" runat="server" PostBackUrl="~/BuyingHouse/BuyerList.aspx"> <span class="info-box-icon bg-yellow"><i class="ion ion-ios-people-outline" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text">Active Buyer</span>
                  <span class="info-box-number"><asp:Label ID="lblExistingBuyer" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
     <div class="row" style="padding-top:10px;">
          
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                 <asp:LinkButton ID="btnPendingTask" Text="Pending Task" runat="server" PostBackUrl="~/BuyingHouse/PendingList.aspx"> <span class="info-box-icon bg-aqua"><i class="glyphicon glyphicon-hourglass" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text"> Pending Task</span>
                  <span class="info-box-number"> <asp:Label ID="lblPendingTask" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
           <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
             <asp:LinkButton ID="LinkButton1" Text="Failed Order" runat="server" PostBackUrl="~/BuyingHouse/FailedOrderList.aspx">  <span class="info-box-icon bg-red"><i class="glyphicon glyphicon-remove" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text"> Failed Order</span>
                  <span class="info-box-number">  <asp:Label ID="lblFailedOrder" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
               <asp:LinkButton ID="LinkButton3" Text="Order Status" runat="server" PostBackUrl="~/BuyingHouse/OrderList.aspx"> <span class="info-box-icon bg-green"><i class="glyphicon glyphicon-th-list" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text">Individual Order</span>
                  <span class="info-box-number"> <asp:Label ID="lblOrderStatus" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                 <asp:LinkButton ID="btnExistingOrderAmountinUSD" Text="Existing Order Amount in USD" runat="server" href="#"><span class="info-box-icon bg-yellow"><i class="glyphicon glyphicon-usd" style="padding-top:20%;"></i></span></asp:LinkButton>
                <div class="info-box-content">
                  <span class="info-box-text">Order Amount</span>
                  <span class="info-box-number">$<asp:Label ID="lblExistingOrderinUSD" runat="server" Text="0"></asp:Label></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
    <div class="row" style="margin-top: 10px;">
         <div class="col-md-7">
            <div class="panel panel-info">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Month Wise Order Ratio</b> </div>
                <div class="panel-body">
                    <asp:Chart ID="Chart1" runat="server" ToolTip="Month Wise Order Ratio" Height="250px" Width="550px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="false" Name="Month Wise Order Ratio" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1" LegendText="Month Wise Order Ratio" ChartType="Column" ToolTip="Tolal #VALX : #VALY" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="false" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>

        </div>
        <div class="col-md-4 col-md-offset-1">
            <div class="panel panel-success">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Others Status</b> </div>
                <div class="panel-body">
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Shipment Done In Last One Month
                                   <span class="badge alert-danger  pull-right">
                                       <asp:Label ID="lblShipmentDoneInLastOneMonth" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Shipment Failed
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblShipmentFailed" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                       First Sample Sent
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblFirstSampleSent" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                         Final Sample Pending
                            <span class="badge alert-danger pull-right ">
                                <asp:Label ID="lblFinalSamplePending" runat="server" Text="0"></asp:Label></span>
                    </div>

                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        QC Inspaction And Report
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblQCInspaction" runat="server" Text="0"></asp:Label></span>
                    </div>

                   

                   


                </div>
            </div>

        </div>
    </div>
    <div class="row" style="padding-top: 8px;">
       
    </div>

</asp:Content>


