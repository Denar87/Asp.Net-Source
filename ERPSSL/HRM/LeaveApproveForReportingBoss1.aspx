<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="LeaveApproveForReportingBoss1.aspx.cs" Inherits="ERPSSL.HRM.LeaveApproveForReportingBoss1" ClientIDMode="Static"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <link href="MultiCalender/css/mdp.css" rel="stylesheet" type="text/css" />
    <script src="MultiCalender/js/jquery-2.1.1.js" type="text/javascript"></script>
    <script src="MultiCalender/js/jquery-ui-1.11.1.js" type="text/javascript"></script>
    <script src="MultiCalender/jquery-ui.multidatespicker.js" type="text/javascript"></script>
    
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Leave Approve For Reporting Boss 1
        </div>
    </div>
    <div class="col-md-12">
        <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
            Applicant
        </div>
    </div>
    <div class="col-md-12">
            <div class="col-md-2">
               
                    <div class="col-md-12" style="padding:0px"">
                        <div class="col-md-7">
                            E-ID:
                        </div>
                        <div class="col-md-5">
                            <asp:Label ID="lblApplicantId" runat="server"></asp:Label>
                            <asp:HiddenField ID="hidReportingBossID" runat="server" />
                        </div>
                    </div>
              
            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Name:
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            Department:
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblApplicantDepartment" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                
                    <div class="col-md-12">
                        <div class="col-md-6">
                            Designation:
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblApplicantDesignation" runat="server"></asp:Label>
                        </div>
                    </div>
             
            </div>
        </div>
         <div class="col-md-12">
        <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
            Approve Status
        </div>
    </div>
            <div class="col-md-12">
            <div class="col-md-4">
               
                    <div class="col-md-12" style="padding:0px"">
                        <div class="col-md-7">
                          1st Approve By:
                        </div>
                        <div class="col-md-5">
                            <asp:Label ID="lbl1ApproveBy" runat="server"></asp:Label>
                            
                        </div>
                    </div>
              
            </div>
                  <div class="col-md-8">
                
                      </div>

         
        </div>
        <div class="col-md-12">
            <div class="col-md-4">
               
                    <div class="col-md-12" style="padding:0px"">
                        <div class="col-md-7">
                          2nd Approve By:
                        </div>
                        <div class="col-md-5">
                            <asp:Label ID="lblSecond" runat="server"></asp:Label>
                            
                        </div>
                    </div>
              
            </div>
                  <div class="col-md-8">
                
                      </div>

         
        </div>
         <div class="col-md-12">
            <div class="col-md-4">
               
                    <div class="col-md-12" style="padding:0px"">
                        <div class="col-md-7">
                          HRM Approve By:
                        </div>
                        <div class="col-md-5">
                            <asp:Label ID="lblHRMApproveBY" runat="server"></asp:Label>
                            
                        </div>
                    </div>
              
            </div>
                  <div class="col-md-8">
                
                      </div>

         
        </div>
    <div class="col-md-12">
        <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
            Approve
        </div>
    </div>
    <div class="col-md-12">
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Are you want to Update?" AutoPostBack="true"
            OnCheckedChanged="CheckBox1_CheckChanged" />
        <br />
    </div>
    <div class="col-md-12 bg-success">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                     Applied Date :
                </div>             
                <div class="col-md-6">
                    <asp:Label ID="lblDateApplied" runat="server"></asp:Label>
                    <asp:HiddenField ID="hidLeaveCode" runat="server" />
                </div>
            </div>
        </div>
         <div class="row">
                <br />
            <div class="col-md-12">
                <div class="col-md-3">
                    Leave Dates :
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblLeaveDates" runat="server"></asp:Label>
                   
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                    Leave Type :
                </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="drpLeaveType" Class="form-control" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                    Leave Date :
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtLeaveDate" runat="server" Class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                    Total day:
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtbxTotalDay" onclick="txtBox1_ClientClicked()" runat="server"
                        Class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3">
                    Lave Reason :
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtbxLeaveReason" TextMode="MultiLine" runat="server" Class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <br />
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <asp:Button ID="BtnAprove" runat="server" class="btn btn-primary" Text="Approve"
                        OnClick="BtnAprove_Click" />
                    <asp:Button ID="btnDisapporve" runat="server" class="btn btn-info  pull-right" Text="Disapprove"
                       OnClick="btnDisapporve_Click" />
                </div>
            </div>
        </div>
        <br />
    </div>
        </div>
    <script type="text/javascript">
        $('#txtLeaveDate').multiDatesPicker();

    </script>
    <script type="text/javascript">

        function txtBox1_ClientClicked() {
            var taotalDate = document.getElementById('<%=txtLeaveDate.ClientID%>').value
            var counttoatalDate = taotalDate.split(',');
            document.getElementById('<%=txtbxTotalDay.ClientID%>').value = counttoatalDate.length;
        }

    </script>
</asp:Content>
