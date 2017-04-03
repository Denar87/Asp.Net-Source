<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="SalaryHeldUpList.aspx.cs" Inherits="ERPSSL.PAYROLL.SalaryHeldUpList" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>

                </ProgressTemplate>
            </asp:UpdateProgress>

            <div class="row">
                <asp:HiddenField ID="hdnAdminEID" runat="server" />
                <asp:HiddenField ID="hdnOfficeID" runat="server" />
                <asp:HiddenField ID="hdnId" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Salary Held Up List
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <br />

                    <div class="col-md-12">
                        <fieldset>
                            <%--  <legend style="line-height: 0;"><span style="background: #fff"></span></legend>--%>
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-2">Salary Month</div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                            PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" Style="margin-right: 5px;" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" ValidationGroup="Group1" Style="margin-right: 5px;"
                                            class="btn btn-active " OnClick="btnPrint_Click" />
                                        <asp:Button ID="btnReleaseHeldUpSalary" runat="server" Text="Release" ValidationGroup="Group1"
                                            class="btn btn-info " OnClick="btnReleaseHeldUpSalary_Click" />
                                    </div>
                                </div>
                            </div>

                            <br />
                        </fieldset>
                    </div>

                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Held Up Salary List</span></legend>
                            <asp:GridView ID="GridViewSalaryList" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No Records Found!" AllowSorting="True" CellPadding="5"
                                DataKeyNames="PaySalary_Temp_ID">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                            <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                            <itemstyle horizontalalign="Center" cssclass="Grid_Border" />
                                            <footerstyle cssclass="Grid_Footer" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalaryId" runat="server" Text='<%# Eval("PaySalary_ID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False" HeaderText="EID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="EID" HeaderText="E-ID">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FullName" HeaderText="Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesginationName" HeaderText="Designation">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="Grade" HeaderText="Grade">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Total_Basic_New" HeaderText="Basic" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HOUSE_RENT" HeaderText="House Rent" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MEDICAL" HeaderText="Medical" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="CONVEYANCE" HeaderText="Conveyance" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FixedAllowance" HeaderText="Fixed Allowance" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="GROSS_SAL" HeaderText="Gross" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Worked_Day" HeaderText="Pay Days">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attendance_Bonus" HeaderText="Att. Bonus" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Over_Time" HeaderText="OT (hrs)">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OT_Taka" HeaderText="OT Amt." DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Gross_Sal" HeaderText="Total Gross" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Deduction" HeaderText="Total Deduct" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Net_Payable" HeaderText="Net Payable" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--  <asp:TemplateField ItemStyle-Width="2%" HeaderText="Held Up" ItemStyle-HorizontalAlign="Center">

                                        <ItemTemplate>
                                            <asp:CheckBox ID="rowheldupCheckBox" runat="server" onclick="Check_Click(this)"
                                                Checked='<%# bool.Parse(Eval("IsSalaryHeldup").ToString() == "True" ? "True": "False")%>' />
                                            <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                            <itemstyle horizontalalign="Center" cssclass="Grid_Border" />
                                            <footerstyle cssclass="Grid_Footer" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
                        </fieldset>
                    </div>
                    <div class="col-md-12">


                        <div class="row ">
                            <div class="col-md-12">
                                <div class="col-md-8">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                                <div class="col-md-4">
                                    <div class="pull-right">
                                    </div>
                                </div>

                            </div>
                        </div>
                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-11"></div>
                        <div class="col-md-1">
                            <%--     <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning"
                                OnClick="btnPrint_Click" />--%>
                        </div>
                    </div>
                    <%-- <div class="col-md-12">
                        <center>
                            <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                            </rsweb:ReportViewer>
                        </center>


                    </div>--%>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function Check_Click(objRef) {


            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "GreenYellow";
                row.checked = false;
            }
            else {

                row.style.backgroundColor = "white";
                row.checked = true;
            }
        }
    </script>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Processed Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
