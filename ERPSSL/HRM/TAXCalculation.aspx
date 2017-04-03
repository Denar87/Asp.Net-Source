<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="TAXCalculation.aspx.cs" Inherits="ERPSSL.HRM.TAXCalculation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
         <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>TAX Calculation
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <br />
            <div class="col-md-5">
               
                <div class="col-md-12">
                    <div class="col-md-5">
                        Assessment Year
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtbxAssessmentYear" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                  </div> 

        </div>
        <div class="col-md-12">
            <br />
            <div class="col-md-5">
               
                <div class="col-md-12">
                    <div class="col-md-5">
                        Date
                    </div>
                    <div class="col-md-7">
                      <asp:TextBox  ID="txtBxDate" runat="server" Class="form-control" placeholder="MM/dd/yyyy" />
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender1" runat="server" TargetControlID="txtBxDate" PopupButtonID="txtBxDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            
                    </div>
                </div>
                  </div> 

        </div>
        <div class="col-md-12">
            <br />
            <div class="col-md-5">
               
                <div class="col-md-12">
                    <div class="col-md-5">
                       
                    </div>
                    <div class="col-md-7">
                      <asp:Button ID="btnProcess" runat="server" Text="Process"  CssClass="btn btn-info" OnClick="btnProcess_Click" />
                    </div>
                </div>
                  </div> 

        </div>
        </div>
       
     <script>

         function func(result) {
             if (result === 'Data Save Successfully') {
                 toastr.success(result);

             }
             else if (result === 'Data Update Successfully') {
                 toastr.success(result);
             }
             else
                 toastr.error(result);

             return false;
         }

   </script>

</asp:Content>
