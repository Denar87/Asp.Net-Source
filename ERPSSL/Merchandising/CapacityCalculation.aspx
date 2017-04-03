<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="CapacityCalculation.aspx.cs" Inherits="ERPSSL.Merchandising.CapacityCalculation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
        }

        /*.header {
            background-color: #808080;
            color: #ffffff;
            width: 100%;
        }

        .item {
            background-color: #ffffff;
            width: 100%;
        }

        .alternativeitem {
            background-color: #0094ff;
            color: #ffffff;
            width: 100%;
        }*/
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Capacity Calculation
                        </div>
                    </div>
                    <div class="row" style="margin: auto 0;" runat="server" visible="true">
                        <fieldset>
                            <legend style="line-height: 0px; padding-top: 5px; padding: 0;"><span style="background: #fff"></span></legend>
                            <div class="col-md-12" style="padding: 0; margin: auto 0;">
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Office
                                <asp:DropDownList ID="ddlOffice" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Capacity Source
                                <asp:DropDownList ID="ddlCapacitySource" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Basic SAM
                                <asp:TextBox ID="txtBasicSAM" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Efficiency %
                                <asp:TextBox ID="txtEfficiency" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Avg. Machine Line
                                <asp:TextBox ID="txtAvgMachineLine" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Remarks
                                <asp:TextBox ID="txtRemarks" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Year
                                        <asp:DropDownList ID="ddlYear" class="form-control" runat="server">
                                            <asp:ListItem Value="2015">2015</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2020">2020</asp:ListItem>
                                            <asp:ListItem Value="2021">2021</asp:ListItem>
                                            <asp:ListItem Value="2022">2022</asp:ListItem>
                                            <asp:ListItem Value="2023">2023</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Month
                                        <asp:DropDownList ID="ddlMonth" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                            <asp:ListItem Value="1">January</asp:ListItem>
                                            <asp:ListItem Value="2">February</asp:ListItem>
                                            <asp:ListItem Value="3">March</asp:ListItem>
                                            <asp:ListItem Value="4">April</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">June</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">August</asp:ListItem>
                                            <asp:ListItem Value="9">September</asp:ListItem>
                                            <asp:ListItem Value="10">October</asp:ListItem>
                                            <asp:ListItem Value="11">November</asp:ListItem>
                                            <asp:ListItem Value="12">December</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </fieldset>

                        <div class="col-md-12" style="padding-left: 0; padding-right: 0;">
                            <div class="col-md-6" style="padding: 0;">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px; padding: 0;"><span style="background: #fff"></span></legend>
                                    <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-hover table-striped"  HeaderStyle-BackColor="#d9edf7" >
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltbl_ID" runat="server" Text='<%# Eval("tbl_ID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Datetime" HeaderText="Date" HeaderStyle-BackColor="#d9edf7"  dataformatstring="{0:MM/dd/yyyy}" ></asp:BoundField>
                                            <asp:TemplateField HeaderText="Day Status" HeaderStyle-BackColor="#d9edf7">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlProductName" Width="100%" Class="form-control" runat="server">
                                                        <asp:ListItem Selected="True"> Open</asp:ListItem>
                                                        <asp:ListItem> Closed</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. of Line" HeaderStyle-BackColor="#d9edf7">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBox7" Class="form-control" Text="0" AutoPostBack="true" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Capacity (Mnt.)" HeaderStyle-BackColor="#d9edf7">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtActualQty" Class="form-control" Text="0" AutoPostBack="true" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Capacity(Pcs)" HeaderStyle-BackColor="#d9edf7">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUnit" Class="form-control" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </fieldset>
                            </div>
                            <%--<div class="col-md-6" style="padding: 0;">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px; padding: 0;"><span style="background: #fff"></span></legend>
                                    <table class="table table-bordered">
                                        <tr class="info" id="trInfoHeader" runat="server">
                                            <td>Date 
                                            </td>
                                            <td>Day Status
                                            </td>
                                            <td>No. of Line
                                            
                                            </td>
                                            <td>Capacity (Mnt.)
                                          
                                            </td>
                                            <td>Capacity(Pcs)
                                        
                                            </td>
                                        </tr>
                                        <tr id="trInfoWork" runat="server">
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox8" Class="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:DropDownList ID="ddlProductName" Class="form-control" runat="server">
                                                    <asp:ListItem> Open</asp:ListItem>
                                                    <asp:ListItem> Closed</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox7" Class="form-control" Text="0" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="txtActualQty" Class="form-control" Text="0" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="txtUnit" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>--%>
                            <div class="col-md-6" style="padding: 0;">
                                <fieldset>
                                    <legend style="line-height: 0px; padding-top: 5px; padding: 0;"><span style="background: #fff"></span></legend>
                                    <table class="table table-bordered">
                                        <tr class="info">
                                            <td>SL No. 
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ControlToValidate="ddlProductGroup"
                                                 ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td>Month
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true" ControlToValidate="ddlProductName"
                                                ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td>Working Day
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true" ControlToValidate="txtReceiveQty"
                                                ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td>Capacity (Mnt.)
                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true" ControlToValidate="txtUnit"
                                               ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td>Capacity(Pcs)
                                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" SetFocusOnError="true" ControlToValidate="txtUnit"
                                               ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>--%>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="lblSL1" Text="1" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox5" Text="January" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox6" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox9" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox10" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label1" Text="2" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox11" Text="February" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox12" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox13" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox14" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label2" Text="3" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox15" Text="March" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox16" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox17" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox18" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label3" Text="4" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox19" Text="April" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox20" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox21" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox22" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label4" Text="5" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox23" Text="May" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox24" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox25" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox26" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label5" Text="6" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox27" Text="June" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox28" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox29" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox30" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label6" Text="7" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox31" Text="July" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox32" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox33" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox34" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label7" Text="8" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox35" Text="August" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox36" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox37" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox38" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label8" Text="9" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox39" Text="September" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox40" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox41" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox42" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label9" Text="10" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox43" Text="October" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox44" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox45" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox46" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label10" Text="11" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox47" Text="November" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox48" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox49" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox50" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50px; text-align: center; padding: 0;">
                                                <asp:Label ID="Label11" Text="12" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: center; padding: 0;">
                                                <asp:Label ID="TextBox1" Text="December" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox2" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox3" Width="100%" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; padding: 0;">
                                                <asp:TextBox ID="TextBox4" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
