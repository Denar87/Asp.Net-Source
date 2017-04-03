<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="ERPSSL.HRM.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>WelCome To HRM
            </div>
        </div>


        <div class="col-md-12" style="padding-top: 10px;">

            <div class="col-md-4">
                <div class="panel panel-success">
                    <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Employee Details</b> </div>
                    <div class="panel-body">
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Employee
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblTotalEmployee" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Separation Employee
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblTotalSepartion" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Current Employee
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblCurrentEmp" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Male
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblTotalMale" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Female
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblTotalFemale" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Today Join
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblNewjoining" runat="server" Text="0"></asp:Label></span>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-info">
                    <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-ok"></i><b>&nbsp;Attendance Details</b> </div>
                    <div class="panel-body">
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Employee
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblTotalEmp" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            On-Time Present
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblTotalPresent" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Absent
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblTotalAbsent" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Late
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblTotalLate" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Leave
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblTotalLeave" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total OT (hr.)
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblTOtlaOt" runat="server" Text="0"></asp:Label></span>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-danger">
                    <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-list-alt"></i><b>&nbsp;Last Monthly  Details</b> </div>
                    <div class="panel-body">
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Employee
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblLastTotalEmp" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Laft Employee
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblLastLeft" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total New Joining
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblLastNewJoining" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total OT (hr.)
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblLastOTHour" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total OT (TK.)
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblLastOTTaka" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Salary
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblTotalSal" runat="server" Text="0"></asp:Label></span>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <div class="col-md-12" style="padding-top: 10px;">

            <div class="col-md-4">
                <div class="panel panel-success">
                    <div class="panel-heading" style="text-align: center"><b>Employee Details Chart</b> </div>
                    <div class="panel-body">
                        <div id="chartdivd">
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-success">
                    <div class="panel-heading" style="text-align: center"><b>Attendance Details Chart</b> </div>
                    <div class="panel-body">
                        <div id="chartAttendance2d">
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-success">
                    <div class="panel-heading" style="text-align: center"><b>Monthly Details</b> </div>
                    <div class="panel-body">
                        <div id="LastMonth">
                        </div>

                    </div>
                </div>
            </div>

        </div>



    </div>

    <script src="../Dashboard/Js/jsapi.js"></script>

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
                url: 'index.aspx/GetChartDatad',
                data: '{}',
                success: function (response) {
                    drawchartd(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchartd(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Emp');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].TotalActionEmp, dataValues[i].TotalNewJoin]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.PieChart(document.getElementById('chartdivd'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "10px",
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
                url: 'index.aspx/GetChartDatad',
                data: '{}',
                success: function (response) {
                    drawchartcold(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchartcold(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Emp');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].TotalActionEmp, dataValues[i].TotalNewJoin]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.ColumnChart(document.getElementById('chartdiv2d'));

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
                url: 'index.aspx/GetAttendanceDatad',
                data: '{}',
                success: function (response) {
                    drawchart1d(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchart1d(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Absent');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].totalPresent, dataValues[i].totalAbsent]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.PieChart(document.getElementById('chartAttendanced'));

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
                url: 'index.aspx/GetAttendanceDatad',
                data: '{}',
                success: function (response) {
                    drawchartattd(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchartattd(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total Absent');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].totalPresent, dataValues[i].totalAbsent]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.ColumnChart(document.getElementById('chartAttendance2d'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "10px",
                  chartArea: { width: '70%' },
              });
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'index.aspx/GetLastMonthEmp',
                data: '{}',
                success: function (response) {
                    drawchartLast(response.d); // calling method  
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchartLast(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Total ');
            data.addColumn('number', '');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].totalEmp, dataValues[i].TotalValue]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.PieChart(document.getElementById('LastMonth'));

            chart.draw(data,
              {
                  title: "",
                  position: "bottom",
                  fontsize: "12px",
                  chartArea: { width: '80%' },
              });
        }
    </script>
</asp:Content>
