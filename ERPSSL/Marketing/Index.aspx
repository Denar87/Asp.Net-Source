<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ERPSSL.Marketing.Index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    <style type="text/css">
        #slideshow {
            position: relative;
            width: 500px;
            height: 200px;
        }

            #slideshow > div {
                position: absolute;
                top: 5px;
                right: 5px;
                bottom: 5px;
                height: 240px;
            }

        .iconI {
            font-size: 40px;
            padding-top: 20px;
        }

        .heights {
            height: 150px;
        }

        .backcolor1 {
            text-align: left;
        }

        .backcolor2 {
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            background-color: azure;
            text-align: center;
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


    <div class="panel" style="margin-top: 100px;">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Welcome to Sales & Marketing
        </div>
    </div>

    <%-- New Design --%>
    <!-- /.row -->
            <div class="row" style="padding-top:5px;">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-users fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="newOnGoingClients" runat="server" Text=""></asp:Label></div>
                                    <div>ON GOING CLIENTS</div>
                                </div>
                            </div>
                        </div>
                        <a href="WorkOrderSatus.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="newPrimaryClientLabel" runat="server" Text=""></asp:Label></div>
                                    <div>PRIMARY CLIENTS</div>
                                </div>
                            </div>
                        </div>
                        <a href="PrimaryClients.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-calendar fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="newCurrentMonthVisitLabel" runat="server" Text=""></asp:Label></div>
                                    <div>CURRENT MONTH VISIT</div>
                                </div>
                            </div>
                        </div>
                        <a href="CurrentMonthVisit.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-4x">&#2547</i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div style="font-size:30px;"><asp:Label ID="newCurrentMonthCollectionLabel" runat="server" Text=""></asp:Label></div>
                                    <div>CURRENT MONTH COLLECTION</div>
                                </div>
                            </div>
                        </div>
                        <a href="ViewCurrentMonthCollection.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            
            <br />
            <br />
            <%-- 2nd Row --%>
            
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-users fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="newUpComingClientsLabel" runat="server" Text=""></asp:Label></div>
                                    <div>UPCOMING CLIENTS</div>
                                </div>
                            </div>
                        </div>
                        <a href="UpComingClients.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="newMidLevelClientsLabel" runat="server" Text=""></asp:Label></div>
                                    <div>MID LEVEL CLIENTS</div>
                                </div>
                            </div>
                        </div>
                        <a href="MidLevelClient.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-calendar fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="newLastMonthVisitLabel" runat="server" Text=""></asp:Label></div>
                                    <div>LAST MONTH VISIT</div>
                                </div>
                            </div>
                        </div>
                        <a href="LastMonthVisit.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-4x">&#2547</i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div style="font-size:30px;"><asp:Label ID="newLastMonthCollectionLabel" runat="server" Text=""></asp:Label></div>
                                    <div>LAST MONTH COLLECTION</div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <a href="ViewLastMonthCollection.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            
    <%-- End of New Design --%>





    

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-6">
            <div class="panel panel-info">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Month Wise Client Visit</b> </div>
                <div class="panel-body">
                    <asp:Chart ID="Chart1" runat="server" ToolTip="Month Wise Order Ratio" Height="250px" Width="400px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="false" Name="Month Wise Client Visit" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1" LegendText="Month Wise Client Visit" ChartType="Column" ToolTip="Tolal #VALX : #VALY" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="false"  />
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>

        </div>
        <%--<div class="col-md-4 col-md-offset-1">
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

        </div>--%>

        <div class="col-md-6">
            <div class="panel panel-info">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Month Wise Collection</b> </div>
                <div class="panel-body">
                    <asp:Chart ID="Chart2" runat="server" ToolTip="Month Wise Collection" Height="250px" Width="400px">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="false" Name="Month Wise Client Visit" LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1" LegendText="Month Wise Collection" ChartType="Column" ToolTip="Tolal #VALX : #VALY" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="false"  />
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>

        </div>

    </div>
    <div class="row" style="padding-top: 8px;">
    </div>




</asp:Content>
