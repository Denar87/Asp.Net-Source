<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="CapacityAllocation.aspx.cs" Inherits="ERPSSL.Merchandising.CapacityAllocation" %>

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

        .header {
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
        }
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
                            <i class="fa fa-edit fa-fw icon-padding"></i>Capacity Allocation
                        </div>
                    </div>

                    <div class="row" style="margin: auto 0;" runat="server" visible="true">
                        <fieldset>
                            <legend style="line-height: 0px; padding-top: 5px; padding: 0;"><span style="background: #fff"></span></legend>
                            <div class="col-md-12" style="padding: 0; margin: auto 0;">
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Company
                                        <asp:DropDownList ID="ddlCompany" class="form-control" runat="server">                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Location
                                        <asp:DropDownList ID="ddlLocation" class="form-control" runat="server">                                            
                                        </asp:DropDownList>
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
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Month
                                        <asp:DropDownList ID="ddlMonth" class="form-control" runat="server" AutoPostBack="true">
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
                            <fieldset>
                                <legend style="line-height: 0px; padding-top: 5px; padding: 0;"><span style="background: #fff"></span></legend>
                                <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-hover table-striped" HeaderStyle-BackColor="#d9edf7">
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltbl_ID" runat="server" Text='<%# Eval("tbl_ID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Datetime" HeaderText="Date" HeaderStyle-BackColor="#d9edf7" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
