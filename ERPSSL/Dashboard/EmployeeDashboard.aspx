<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="ERPSSL.Dashboard.EmployeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>WelCome 
            </div>
        </div>
    <div class="col-md-12" style="padding-top: 10px;">

        <div class="col-md-4">
            <div class="panel panel-success">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Employee Summary</b> </div>
                <div class="panel-body">
                    <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                        Joining Date
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblJoinDate" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                        Date of Birth
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblDOB" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                        Service Age
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblServiceAge" runat="server" Text="0">Days</asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                        Blood Group
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblBloodGroup" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                        Father Name
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblFather" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                        Mother Name
                                   <span class="badge  pull-right">
                                       <asp:Label ID="lblMother" runat="server" Text="0"></asp:Label></span>
                    </div>

                </div>
            </div>
        </div>

        <%--            <div class="col-md-4">
                <div class="panel panel-danger">
                    <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-list-alt"></i><b>&nbsp;Notification</b> </div>
                    <div class="panel-body">
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Employee
                                    <span class="badge alert-success pull-right">
                                        <asp:Label ID="lblLastTotalEmp" runat="server" Text="0"></asp:Label></span>
                        </div>
                        <div style="height: 30px; color: #2F4F4F; font-size: 15px;">
                            Total Left Employee
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
            </div>--%>
    </div>
    <div class="col-md-12" style="padding-top: 10px;">
        <div class="col-md-4">
            <div class="panel panel-info">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-ok"></i><b>&nbsp;Last Month Attendance Details</b> </div>
                <div class="panel-body">

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
    </div>
           </div>
</asp:Content>
