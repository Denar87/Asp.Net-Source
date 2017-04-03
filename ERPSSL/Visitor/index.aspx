<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor_Site.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="ERPSSL.Visitor.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>WelCome To Visitor
            </div>
        </div>


    </div>

    <script src="../Dashboard/Js/jsapi.js"></script>

   
</asp:Content>
