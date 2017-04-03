<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="AssetTransfer.aspx.cs" Inherits="ERPSSL.FA.AssetTransfer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%--
<%@ Register namespace="Microsoft.Reporting.WebForms" tagprefix="WebForms" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="row">      
        

        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Asset Transfer
            </div>
        </div>
            <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
            <div class="row">

                <fieldset style="border: none;">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">From</span></legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlRegion" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRegion"
                                                SetFocusOnError="True" ValidationGroup="Transfer"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Office
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlOffice" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlDepartment" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            User
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlUser" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">To</span></legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlRegionTo" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRegionTo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRegionTo"
                                                SetFocusOnError="True" ValidationGroup="Transfer"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Office
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlOfficeTo" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOfficeTo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlDepartmentTo" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartmentTo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            User
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlUserTo" AppendDataBoundItems="true" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlUserTo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="row" style="margin: 10px 0">
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Transfer No
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtTransferNo" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTransferNo"
                                SetFocusOnError="True" ValidationGroup="Transfer"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div style="clear: both;">
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 20px;">
                    <div class="col-md-6">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Choose asset from this
                                list</span></legend>
                            <asp:GridView ID="grdAssets" runat="server" AutoGenerateColumns="False" BackColor="White"
                                Width="100%" BorderColor="#99CCFF" BorderStyle="Solid" CellPadding="5" CssClass="Grid_Border"
                                ForeColor="#339933" DataKeyNames="AssetCode" OnSelectedIndexChanged="grdAssets_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <%-- <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />--%>
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="AssetCode" HeaderText="AssetCode" ReadOnly="True" SortExpression="AssetCode" />
                                    <asp:BoundField DataField="AssetName" HeaderText="AssetName" SortExpression="AssetName"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName" />
                                    <%-- <asp:BoundField DataField="OfficeName" HeaderText="OfficeName" SortExpression="OfficeName" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />--%>
                                    <asp:CommandField SelectText="Add To Transfer List" ShowSelectButton="True" />
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" Font-Bold="True"
                                    Height="25px" />
                                <RowStyle CssClass="Grid_RowStyle" Height="25px" />
                            </asp:GridView>
                        </fieldset>
                    </div>
                    <div class="col-md-6">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Assets to transfer</span></legend>
                            <asp:GridView ID="grdTransferList" runat="server" AutoGenerateColumns="False" Width="100%"
                                BorderColor="#99CCFF" BorderStyle="Solid" CellPadding="4" ForeColor="#339933"
                                CssClass="Grid_Border" DataKeyNames="AssetCode" OnSelectedIndexChanged="grdTransferList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="AssetCode" HeaderText="AssetCode" ReadOnly="True" SortExpression="AssetCode" />
                                    <asp:BoundField DataField="AssetName" HeaderText="AssetName" SortExpression="AssetName"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName" />
                                    <%--  <asp:BoundField DataField="OfficeName" HeaderText="OfficeName" SortExpression="OfficeName" />
                            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />--%>
                                    <asp:CommandField SelectText="Undo" ShowSelectButton="True" />
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" Height="25px" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" Font-Bold="True"
                                    ForeColor="White" Height="25px" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="col-md-12">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <%-- <asp:Button ID="btnTransfer" runat="server" Text="Transfer" Style="float: right; margin-top: 15px;
                        margin-right: 20px;" class="btn btn-info" onclick="BtnSave_Click" />--%>
                    <asp:Button ID="btnTransfer" runat="server" Text="Transfer" Style="float: right; margin-top: 15px; margin-right: 20px;"
                        class="btn btn-info" OnClick="btnTransfer_Click"
                        ValidationGroup="Transfer" />
                </div>
            </div>
            <div class="row">
        <rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
            SizeToReportContent="True" Width="100%" runat="server" Font-Names="Verdana" Font-Size="8pt"
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
        </rsweb:ReportViewer>
    </div>
        </div>



    </div>

    <br />
    <br />

    



</asp:Content>
