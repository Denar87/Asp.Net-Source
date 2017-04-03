<%@ Page Title="" Language="C#" MasterPageFile="~/HMS/HMS.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ERPSSL.HMS.Index" %>

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
            <i class="glyphicon glyphicon-edit icon-padding"></i>Welcome to HMS
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
                                    <div class="huge"><asp:Label ID="lblAdmittedPatient" runat="server" Text=""></asp:Label></div>
                                    <div>ADMITTED PATIENT</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <div class="huge" style="font-size:30px;"><asp:Label ID="lblCurrMonthAdmitted" runat="server" Text=""></asp:Label></div>
                                    <div>CURRENT MONTH ADMITTED</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <i class="fa fa-user fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:Label ID="lblLastMonthAdmitted" runat="server" Text=""></asp:Label></div>
                                    <div>LAST MONTH ADMITTED</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <div style="font-size:30px;"><asp:Label ID="lblCurrMonthCollection" runat="server" Text=""></asp:Label></div>
                                    <div>CURRENT MONTH COLLECTION</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <div class="huge" style="font-size:30px;"><asp:Label ID="lblCurrMonthDischarge" runat="server" Text=""></asp:Label></div>
                                    <div>CURRENT MONTH DISCHARGE</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <div class="huge"><asp:Label ID="lblLastMonthDischarge" runat="server" Text=""></asp:Label></div>
                                    <div>LAST MONTH DISCHARGE</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <i class="fa fa-4x">&#2547</i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge" ><asp:Label ID="lblTotaReceivable" runat="server" Text=""></asp:Label></div>
                                    <div>TOTAL RECEIVABLE</div>
                                </div>
                            </div>
                        </div>
                        <a href="">
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
                                    <div style="font-size:30px;"><asp:Label ID="lblLastMonthCollection" runat="server" Text=""></asp:Label></div>
                                    <div>LAST MONTH COLLECTION</div>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <a href="">
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


</asp:Content>
