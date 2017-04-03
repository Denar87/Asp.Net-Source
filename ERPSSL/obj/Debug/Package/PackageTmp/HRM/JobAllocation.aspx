<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="JobAllocation.aspx.cs" Inherits="ERPSSL.HRM.JobAllocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ToolkitScriptManager1" />
    <style type="text/css">
        .time_section input
        {
            width: 27px !important;
            height: auto !important;
            text-align: center;
            border: none !important;
        }
    </style>
   
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>
    <div class="row">
       

        <div class="hm_sec_2_content scrollbar">
             <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Job Allocation
            </div>
        </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <fieldset style="border: none;">
                <div class="col-md-12">
                    <div class="col-md-9"></div>
                    <div class="col-md-3">
                        <p style="font-weight: bold">Job Allocation Code:<asp:Label ID="lblJobAllocationCode" runat="server"></asp:Label></p>
                    </div>
                </div>
                <div class="col-md-12" style="border-bottom: 1px solid black">
                    <div class="col-md-4">
                        <div class="row">

                            <h5 style="padding-left: 20px">Region
                            </h5>
                            <div class="col-md-12">
                                <asp:DropDownList ID="ddlRegions" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResionForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                    runat="server">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <br />
                    </div>
                    <div class="col-md-4">
                        <div class="row">

                            <h5 style="padding-left: 20px">Office
                            </h5>
                            <div class="col-md-12">
                                <asp:DropDownList ID="drpOffice" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice" CssClass="form-control"
                                    runat="server">
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row">

                            <h5 style="padding-left: 20px">Department
                            </h5>
                            <div class="col-md-12">
                                <asp:DropDownList ID="depDepartment" AutoPostBack="True" OnSelectedIndexChanged="drpdwnDepartmentSelectedIndexChange" CssClass="form-control"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>

                </div>

                <div class="col-md-12">
                    <div class="col-md-3">

                        <div class="row">

                            <h5 style="padding-left: 20px">Client
                            </h5>

                            <div class="col-md-12">
                                <asp:DropDownList ID="drpClient" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpClientOnselectedIndexChangeD" CssClass="form-control"></asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="Group2"
                                    runat="server" ControlToValidate="drpClient" ErrorMessage="Select Client" InitialValue="0"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                        <div class="row">
                            <h5 style="padding-left: 20px">Location
                            </h5>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtbxLoacation" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <h5 style="padding-left: 20px">Reason
                            </h5>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtbxRegion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtbxRegion"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Reson"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="row">
                            <h5 style="padding-left: 20px">Remark's
                            </h5>

                            <div class="col-md-12">
                                <asp:TextBox ID="txtbxRemark" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                            </div>


                        </div>



                        <div class="row">

                            <h5 style="padding-left: 20px">Request From
                            </h5>

                            <div class="col-md-12">
                                <asp:TextBox ID="txtbxRequestFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxRequestFrom"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Request From"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <%-- <div class="row">

                            <h5 style="padding-left: 20px">Status
                            </h5>

                            <div class="col-md-12">
                                <asp:DropDownList ID="drpStatus" runat="server" Class="form-control">
                                    <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>--%>

                        <div class="row">


                            <h5 style="padding-left: 20px">Date
                            </h5>

                            <div class="col-md-12">
                                <asp:TextBox runat="server" ID="txtboxDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                 <ajaxToolkit:CalendarExtender id="CalendarExtender" runat="server" targetcontrolid="txtboxDate"
                                    popupbuttonid="txtboxDate" format="MM/dd/yyyy" cssclass="ajax__calendar" enabled="True" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtboxDate"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Date"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>


                            </div>

                        </div>

                        <div class="row">

                            <h5 style="padding-left: 20px">Time
                            </h5>

                            <div class="col-md-12">
                                <div class="form-control">
                                    <cc1:timeselector id="txtbxTime" runat="server" allowsecondediting="True" ampm="PM" cssclass="time_section" selectedtimeformat="TwentyFour"
                                        bordercolor="Silver" date="01/01/0001 09:00:00" hour="9" minute="0" second="0">
                                                </cc1:timeselector>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">

                                <asp:Button ID="btnProcess" runat="server" OnClick="btnProcess_Click" ValidationGroup="Group2" Text="Process" Style="margin-top: 15px; margin-right: 20px;"
                                    class="btn btn-warning" />
                            </div>
                        </div>

                    </div>

                    <div class="col-md-9">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div>
                                    <br />
                                    <p>Employee List</p>
                                </div>

                                <asp:GridView ID="grdemployees" runat="server" EmptyDataText="No Records Found!"
                                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                    DataKeyNames="EID" ShowFooter="True" CellPadding="5" PageSize="10" OnPageIndexChanging="grdemployees_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="EID" HeaderText="E-ID">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ContactNumber" HeaderText="contact">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Add">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn-info" OnClick="btnAdd_Click" />


                                            </ItemTemplate>

                                        </asp:TemplateField>



                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle CssClass="Grid_RowStyle" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>

                            </div>

                            <div class="col-md-6">
                                <div>
                                    <br />
                                    <p>Selected Employee</p>
                                </div>

                                <asp:GridView ID="grdviewsseletedEmployee" runat="server" EmptyDataText="No Records Found!"
                                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                    DataKeyNames="EID" ShowFooter="True" CellPadding="5" PageSize="10" OnPageIndexChanging="grdemployees_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--  <asp:BoundField DataField="RegionsId" >
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResion" runat="server" Text='<%# Eval("RegionsId")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--  <asp:BoundField DataField="OfficeId" >
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfficeId" runat="server" Text='<%# Eval("OfficeId")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepartmentId" runat="server" Text='<%# Eval("DepartmentId")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--   <asp:BoundField DataField="DepartmentId" >
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>

                                        <asp:BoundField DataField="EID" HeaderText="E-ID">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ContactNumber" HeaderText="contact">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-info" OnClick="btnDelete_Delete" />
                                            </ItemTemplate>

                                        </asp:TemplateField>



                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle CssClass="Grid_RowStyle" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>

    </div>
    </ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnProcess" EventName="Click" />

</Triggers>
</asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);

            }
           

            return false;
        }

   </script>
</asp:Content>
