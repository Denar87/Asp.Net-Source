<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="BackupDatabase.aspx.cs" Inherits="ERPSSL.HRM.BackupDatabase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Backup Database 
        </div>
    </div>
       <div class="row" style="padding-top:20px;">
           <div class="col-md-3"></div>
           <div class="col-md-6" style="overflow:hidden">
                <div class="panel panel-info">
                            <div class="panel-heading " style="background-color: #778899; color: white">Data Base Backup</div>
                            <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">
                                <span>For databases that use full and bulk-logged recovery, database backups are necessary but not sufficient. Transaction log backups are also required. This includes part of the transaction log so that the full database can be recovered after a full database backup is restored. 
                                    Full database backups represent the database at the time the backup finished. </span>
                         
                    <div style="padding-top:20px;">            
             <asp:Button ID="btnBackup" runat="server" style=" float:right; " CssClass="btn btn-info"  Text="Backup DataBase" OnClick="btnBackup_Click" /> 
                        </div>
                                </div>
                    </div> 
               </div>
       </div>

    </div>
    <script>


        function func(result) {
            if (result === 'Database Backup successfully!') {
                toastr.success(result);

            }
           
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
