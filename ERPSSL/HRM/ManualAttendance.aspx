<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="ManualAttendance.aspx.cs" Inherits="ERPSSL.HRM.ManualAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>
       <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Manual Attendance
        </div>
    </div>
    <div class="hm_sec_2_content scrollbar">
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            </div>
        <div class="row">
            <div class="col-md-12">
                <br />
                <div class="col-md-1">
                    <asp:Button  ID="btnIntime" runat="server" CssClass="btn btn-primary" OnClick="btnIntime_Click" Text="In-Time"/>

                </div>
                <div class="col-md-1">
                      <asp:Button  ID="btnOutTime" runat="server" CssClass="btn btn-info pull-right" OnClick="btnOutTime_Click" Text="In-Time"/>
                </div>
                <div class="col-md-10"></div>

            </div>

        </div>
        </div>
    </ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnIntime" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="btnOutTime" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>
