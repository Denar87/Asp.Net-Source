<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="Deshboard1.aspx.cs" Inherits="ERPSSL.Dashboard.Deshboard1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="SpryAssets/SpryMenuBarHorizontal.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
     <%--   <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>WelCome 
            </div>
        </div>
        <br />--%>
        <%--    <div class="col-md-12">--%>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
            childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Employee" ID="TabPanel1"
                OnDemandMode="None">
                                <ContentTemplate>
                    <%--<div class="col-md-12" style="padding-left: 0px">--%>
                        <div class="panel panel-info">
                            <div class="panel-heading " style="background-color: #778899; color: white">Employee Details</div>
                            <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">
                                <table class="table table-bordered">
                                     <tr class="info" style="text-align:center">
                                        <td>Total Employee</td>
                                        <td>Seperation Employee</td>
                                        <td>Current Employee</td>                                     
                                        <td>Total Male</td>
                                        <td>Total Female</td>
                                         <td>Today Join</td>
                                    </tr>
                                    <tr>

                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblTotalEmployee" runat="server" Text=""></asp:Label></td>

                                        <td style="text-align: center; color:red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblTotalSepartion" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblCurrentEmp" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblTotalMale" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblTotalFemale" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblNewjoining" runat="server" Text=""></asp:Label></td>
                                        
                                        <%-- <td>
                                <asp:Label ID="lblLWP" runat="server" Text=""></asp:Label></td>--%>
                                    </tr>

                                </table>
                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="chartdiv" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="chartdiv2" style="width: 350px; height: 300px;">
                                    </div>
                                </div>
                            </div>

                        </div>
                   <%-- </div>--%>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel runat="server" HeaderText="Attendance" ID="TabPanel2" OnDemandMode="None">

                <ContentTemplate>
                    <%--<div class="col-md-12" style="padding-left: 0px">--%>
                        <div class="panel panel-info">
                            <div class="panel-heading" style="background-color: #778899; color: white">Attendance Details</div>
                            <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">

                                <table class="table table-bordered">
                                    <tr class="info" style="text-align:center">
                                        <td>Total Employee</td>
                                        <td>On-Time Present</td>
                                        <td>Total Absent</td>
                                        <td>Total Late</td>
                                        <%--<td>This Week</td>--%>
                                        <td>Total Leave</td>
                                        <td>Total OT (hr.)</td>
                                    </tr>
                                    <tr>
                                         <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalEmp" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalPresent" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalAbsent" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalLate" runat="server" Text=""></asp:Label></td>

                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalLeave" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTOtlaOt" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="chartAttendance" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="chartAttendance2" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                            </div>
                        </div>
                    <%--</div>--%>
                </ContentTemplate>
                <%--</div>--%>
            </ajaxToolkit:TabPanel>

             <ajaxToolkit:TabPanel runat="server" HeaderText="Inventory" ID="TabPanel3" OnDemandMode="None">

                <ContentTemplate>
                    <%--<div class="col-md-12" style="padding-left: 0px">--%>
                        <div class="panel panel-info">
                            <div class="panel-heading" style="background-color: #778899; color: white">Inventory Details</div>
                            <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">

                                <table class="table table-bordered">
                                    <tr class="info" style="text-align:center">
                                        <td>Total Stock</td>
                                        <td>Total Purchase</td>
                                        <td>Total Issue</td>
                                        <%--<td>This Week</td>--%>
                                        <td>Total Damage</td>
                                        <td>Total Return</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalStock" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalPurchase" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;" >
                                            <asp:Label ID="lblTotalIssue" runat="server" Text=""></asp:Label></td>

                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalDamage" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTotalReturn" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="inv1" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="inv2" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                            </div>
                        </div>
                    <%--</div>--%>
                </ContentTemplate>
                <%--</div>--%>
            </ajaxToolkit:TabPanel>

             <ajaxToolkit:TabPanel runat="server" HeaderText="POS" ID="TabPanel4" OnDemandMode="None">

                <ContentTemplate>
                    <%--<div class="col-md-12" style="padding-left: 0px">--%>
                        <div class="panel panel-info">
                            <div class="panel-heading" style="background-color: #778899; color: white">POS Details</div>
                            <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">

                                <table class="table table-bordered">
                                    <tr class="info" style="text-align:center">
                                        <td>Ticket Sale</td>
                                        <td>Food Sale</td>
                                        
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblTicketSale" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold;  font-size:20px;">
                                            <asp:Label ID="lblFoodSale" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="pos1" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="pos2" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                            </div>
                        </div>
                    <%--</div>--%>
                </ContentTemplate>
                <%--</div>--%>
            </ajaxToolkit:TabPanel>

           <%--  <ajaxToolkit:TabPanel runat="server" HeaderText="Commercial" ID="TabPanel5" OnDemandMode="None">

                <ContentTemplate>
                   
                        <div class="panel panel-info">
                            <div class="panel-heading" style="background-color: #778899; color: white">Today Details</div>
                            <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">

                                <table class="table table-bordered">
                                    <tr class="info" style="text-align:center">
                                        <td>Total Enquery</td>
                                        <td>Total Survey</td>
                                         <td>Total Quation</td>
                                        <td>Total Job</td>
                                        
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblEnquery" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblSurvey" runat="server" Text=""></asp:Label></td>
                                         <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblQuation" runat="server" Text=""></asp:Label></td>
                                        <td style="text-align: center; color: red; font-weight: bold; font-size:20px;">
                                            <asp:Label ID="lblJob" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="com2" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding-left: 0px">
                                    <div id="com1" style="width: 350px; height: 300px;">
                                    </div>
                                </div>

                            </div>
                        </div>
                   
                </ContentTemplate>
                
            </ajaxToolkit:TabPanel>--%>

        </ajaxToolkit:TabContainer>
        <%--   </div>--%>
    </div>
    <script src="Js/min.js"></script>
    <script src="Js/core.js"></script>
    <script src="Js/jquery%201.8.2.js"></script>
    <script src="Js/jsapi.js"></script>
  <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&callback=initialize"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>--%>
    <script type="text/javascript">
        // Global variable to hold data  
        // Load the Visualization API and the piechart package.  
        // google.load('visualization', '1', { packages: ['corechart'] });      

        google.load('visualization', '1', { 'packages': ['annotatedtimeline', 'corechart'] });
    </script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Deshboard1.aspx/GetChartData',
                data: '{}',
                success: function (response) {
                    drawchart(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Emp');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].TotalActionEmp, dataValues[i].TotalNewJoin]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.PieChart(document.getElementById('chartdiv'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "12px",
                  chartArea: { width: '80%' },
              });
        }
    </script>


    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Deshboard1.aspx/GetChartData',
                data: '{}',
                success: function (response) {
                    drawchartcol(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchartcol(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Emp');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].TotalActionEmp, dataValues[i].TotalNewJoin]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.ColumnChart(document.getElementById('chartdiv2'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "12px",
                  chartArea: { width: '80%' },
              });
        }
    </script>


    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Deshboard1.aspx/GetAttendanceData',
                data: '{}',
                success: function (response) {
                    drawchart1(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchart1(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Absent');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].totalPresent, dataValues[i].totalAbsent]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.PieChart(document.getElementById('chartAttendance'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "12px",
                  chartArea: { width: '80%' },
              });
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Deshboard1.aspx/GetAttendanceData',
                data: '{}',
                success: function (response) {
                    drawchartatt(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchartatt(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Absent');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].totalPresent, dataValues[i].totalAbsent]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.ColumnChart(document.getElementById('chartAttendance2'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "12px",
                  chartArea: { width: '80%' },
              });
        }
    </script>

     <script type="text/javascript">
         $(function () {
             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 contentType: 'application/json',
                 url: 'Deshboard1.aspx/GetInventoryData',
                 data: '{}',
                 success: function (response) {
                     drawcharinv(response.d); // calling method  
                 },

                 error: function () {
                     alert("Error loading data! Please try again.");
                 }
             });
         })

         function drawcharinv(dataValues) {
             var data = new google.visualization.DataTable();

             data.addColumn('string', 'Total Stock');
             data.addColumn('number', '');

             for (var i = 0; i < dataValues.length; i++) {
                 data.addRow([dataValues[i].totalStock, dataValues[i].totalIssue]);
             }
             // Instantiate and draw our chart, passing in some options  
             var chart = new google.visualization.PieChart(document.getElementById('inv1'));

             chart.draw(data,
               {
                   title: "",
                   position: "bottom",
                   fontsize: "12px",
                   chartArea: { width: '80%' },
               });
         }
    </script>

     <script type="text/javascript">
         $(function () {
             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 contentType: 'application/json',
                 url: 'Deshboard1.aspx/GetInventoryData',
                 data: '{}',
                 success: function (response) {
                     drawcharinv1(response.d); // calling method  
                 },

                 error: function () {
                     alert("Error loading data! Please try again.");
                 }
             });
         })

         function drawcharinv1(dataValues) {
             var data = new google.visualization.DataTable();

             data.addColumn('string', 'Total Stock');
             data.addColumn('number', '');

             for (var i = 0; i < dataValues.length; i++) {
                 data.addRow([dataValues[i].totalStock, dataValues[i].totalIssue]);
             }
             // Instantiate and draw our chart, passing in some options  
             var chart = new google.visualization.ColumnChart(document.getElementById('inv2'));

             chart.draw(data,
               {
                   title: "",
                   position: "bottom",
                   fontsize: "12px",
                   chartArea: { width: '80%' },
               });
         }
    </script>

     <script type="text/javascript">
         $(function () {
             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 contentType: 'application/json',
                 url: 'Deshboard1.aspx/GettPOSData',
                 data: '{}',
                 success: function (response) {
                     drawcharPOS1(response.d); // calling method  
                 },

                 error: function () {
                     alert("Error loading data! Please try again.");
                 }
             });
         })

         function drawcharPOS1(dataValues) {
             var data = new google.visualization.DataTable();

             data.addColumn('string', 'Total Stock');
             data.addColumn('number', '');

             for (var i = 0; i < dataValues.length; i++) {
                 data.addRow([dataValues[i].Ticket_Sale, dataValues[i].Food_Sale]);
             }
             // Instantiate and draw our chart, passing in some options  
             var chart = new google.visualization.ColumnChart(document.getElementById('pos2'));

             chart.draw(data,
               {
                   title: "",
                   position: "bottom",
                   fontsize: "12px",
                   chartArea: { width: '80%' },
               });
         }
    </script>

      <script type="text/javascript">
          $(function () {
              $.ajax({
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json',
                  url: 'Deshboard1.aspx/GettPOSData',
                  data: '{}',
                  success: function (response) {
                      drawcharPOS2(response.d); // calling method  
                  },

                  error: function () {
                      alert("Error loading data! Please try again.");
                  }
              });
          })

          function drawcharPOS2(dataValues) {
              var data = new google.visualization.DataTable();

              data.addColumn('string', 'Total Stock');
              data.addColumn('number', '');

              for (var i = 0; i < dataValues.length; i++) {
                  data.addRow([dataValues[i].Ticket_Sale, dataValues[i].Food_Sale]);
              }
              // Instantiate and draw our chart, passing in some options  
              var chart = new google.visualization.PieChart(document.getElementById('pos1'));

              chart.draw(data,
                {
                    title: "",
                    position: "bottom",
                    fontsize: "12px",
                    chartArea: { width: '80%' },
                });
          }
    </script>

    <%-- <script type="text/javascript">
         $(function () {
             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 contentType: 'application/json',
                 url: 'Deshboard1.aspx/GetCommercialData',
                 data: '{}',
                 success: function (response) {
                     drawcharCommercial(response.d); // calling method  
                 },

                 error: function () {
                     alert("Error loading data! Please try again.");
                 }
             });
         })

         function drawcharCommercial(dataValues) {
             var data = new google.visualization.DataTable();

             data.addColumn('string', 'Total Number');
             data.addColumn('number', '');

             for (var i = 0; i < dataValues.length; i++) {
                 data.addRow([dataValues[i].TotalNumber, dataValues[i].TotalValue]);
             }
             // Instantiate and draw our chart, passing in some options  
             var chart = new google.visualization.ColumnChart(document.getElementById('com1'));

             chart.draw(data,
               {
                   title: "",
                   position: "bottom",
                   fontsize: "12px",
                   chartArea: { width: '80%' },
               });
         }
    </script>

      <script type="text/javascript">
          $(function () {
              $.ajax({
                  type: 'POST',
                  dataType: 'json',
                  contentType: 'application/json',
                  url: 'Deshboard1.aspx/GetCommercialData',
                  data: '{}',
                  success: function (response) {
                      drawcharCommercial2(response.d); // calling method  
                  },

                  error: function () {
                      alert("Error loading data! Please try again.");
                  }
              });
          })

          function drawcharCommercial2(dataValues) {
              var data = new google.visualization.DataTable();

              data.addColumn('string', 'Total Stock');
              data.addColumn('number', '');

              for (var i = 0; i < dataValues.length; i++) {
                  data.addRow([dataValues[i].TotalNumber, dataValues[i].TotalValue]);
              }
              // Instantiate and draw our chart, passing in some options  
              var chart = new google.visualization.PieChart(document.getElementById('com2'));

              chart.draw(data,
                {
                    title: "",
                    position: "bottom",
                    fontsize: "12px",
                    chartArea: { width: '80%' },
                });
          }
    </script>--%>

</asp:Content>

