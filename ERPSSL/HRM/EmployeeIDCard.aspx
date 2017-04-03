<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeIDCard.aspx.cs" Inherits="ERPSSL.HRM.EmployeeIDCard" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div class="hm_sec_2_content scrollbar">
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>ID Card
        </div>
    </div>
    
    <h4>Employee Information</h4>
    <hr />
         <div class="">
    
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                E-ID No
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtEid_TRNS" class="form-control" runat="server"
                                    OnTextChanged="txtEIdNo_TextChanged" AutoPostBack="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEid_TRNS"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-ID No"
                                    ValidationGroup="EmployeeIDCard"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Employee Name
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    

                </div>
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Department
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDepartment" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Designation
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDesignation" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Employee Photo
                            </div>
                            <div class="col-md-7">
                                <asp:Image ID="Emp_IMG_TRNS" ImageUrl="resources/no_image.png" CssClass="img-thumbnail pull-right" Width="80"
                                    runat="server" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                             <div class="col-md-5"></div>
                             <div class="col-md-7">
                            <asp:Button class="btn btn-info pull-right" ValidationGroup="EmployeeIDCard" ID="Button2" runat="server" Text="Process"
                                OnClick="btnSubmit_Click" />
                                 </div>

                        </div>
                    </div>

                </div>
                
            </div>
        </div>
        <%--            <div class="col-md-12">
            <div class="row">
                  <div  >
                <asp:Button class="btn btn-info pull-right" ID="Button1" runat="server" Text="Process" 
                    onclick="btnSubmit_Click" />
                    </div>
                    </div>
                    </div>
        --%>


        <%--      <div  style="text-align:left";>
                <asp:Button class="btn btn-info pull-right" ID="btnSubmit" runat="server" Text="Process" 
                    onclick="btnSubmit_Click" /></div>
        --%>
        <br />
        <hr />
        <%--                <rsweb:ReportViewer ID="ReportViewerEmp" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                    SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                    Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                </rsweb:ReportViewer>
        --%>
      
             <div class="col-md-12"> 
                <rsweb:ReportViewer ID="ReportViewerEmp" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                    SizeToReportContent="True" Width="100%" Height="700"  runat="server" Font-Names="Verdana"
                    Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                </rsweb:ReportViewer>
            

        </div>
    </div>
       </div>
</asp:Content>
