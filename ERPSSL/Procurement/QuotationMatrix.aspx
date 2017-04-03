<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true"
    CodeBehind="QuotationMatrix.aspx.cs" Inherits="ERPSSL.Procurement.QuotationMatrix" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="row">
       
        <div class="hm_sec_2_content scrollbar">
             <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="glyphicon glyphicon-edit icon-padding"></i>Comparative Statement
            </div>
        </div>

            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <div class="col-md-12">
                <div class="col-md-2">
                </div>
                <div class="col-md-10">
                    <div class="col-md-12">
                        <div id="printablediv" style="clear: both; text-align: center;" class="col-md-10">
                            <%--<div style="text-align: center;">--%>
                            <h3>
                                <u>Comparative Statement</u></h3>
                            <br />
                            <asp:Table ID="Matrix" runat="server" BorderColor="Black" Font-Size="Small" HorizontalAlign="Center"
                                BorderWidth="0.5">
                            </asp:Table>
                            <%-- </div>--%>
                        </div>
                        <div style="float: right; margin-right: -60px; padding-top: 22px;" class="col-md-2">
                            <input type="button" value="Print" onclick="javascript: printDiv('printablediv')" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
