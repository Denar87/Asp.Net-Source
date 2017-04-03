<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="employeeList.aspx.cs" Inherits="ERPSSL.HRM.employeeList" %>

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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:ScriptManager ID="ScriptManager2" runat="server"
EnablePageMethods = "true">
</asp:ScriptManager>--%>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>


            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Employee List
                    </div>
                </div>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
                    childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="All Employees" ID="TabPanel4"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="search_panel">
                                        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>

                                        <img id="Img3" style="visibility: hidden" src="resources/ico/ajax_loading.gif" />
                                        <div class="row" style="padding-bottom: 10px;">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtbxSearchAllEmployee" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="Button1" OnClick="btnallEmployee_Click" runat="server" Text="Search" CausesValidation="False"
                                                    CssClass="btn btn-primary" Width="70px"></asp:Button>
                                            </div>
                                            <div class="col-md-12">
                                            </div>
                                            <%--          <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmpSearch"
                                            BehaviorID="AutoCompleteEx" ServiceMethod="GetEmployeesList" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionSetCount="20" CompletionInterval="500" MinimumPrefixLength="1" OnClientPopulating="ShowIcon"
                                            OnClientPopulated="ShowIcon" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajaxToolkit:AutoCompleteExtender>--%>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchAllAllEmploye"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtbxSearchAllEmployee"
                                                ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxSearchAllEmployee"
                                                SetFocusOnError="True" ForeColor="Red" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>

                                        <%-- <div class="row" style="margin-bottom: 13px;">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtbxAllEmployee" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btnallEmployee" OnClick="btnallEmployee_Click" runat="server" Text="Search" CausesValidation="False"
                                                    CssClass="btn btn-primary" Width="80px"></asp:Button>
                                            </div>
                                        </div>--%>
                                        <%--  <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="btnTransfer"
                                            BehaviorID="AutoCompleteEx" ServiceMethod="GetEmployeesList" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionSetCount="20" CompletionInterval="500" MinimumPrefixLength="1" OnClientPopulating="ShowIcon"
                                            OnClientPopulated="ShowIcon" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="btnTransfer"
                                            SetFocusOnError="True" ForeColor="Red" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridivewAllEmployes" runat="server" EmptyDataText="No Records Found!"
                                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="EmpId" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="GridivewAllEmployes_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FullName" HeaderText="Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DesignationName" HeaderText="Designation">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <%-- <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <%-- <asp:BoundField DataField="Email" HeaderText="Email">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>--%>
                                            <asp:BoundField DataField="ResionName" HeaderText="Region">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="JoiningDate1" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Joining Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="JobTerminateDate" HeaderText="Seperation Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMP_TERMIN_STATUS" HeaderText="Status">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Image" ControlStyle-CssClass="imgwd">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' Width="100%" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnEmployeeEdit" runat="server" ImageUrl="img/list_edit.png"
                                                        OnClick="imgbtnEmployeeEdit_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle CssClass="Grid_Header" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Current Employees" ID="TabPanel1"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="search_panel">
                                        <asp:Label ID="lblOcode" runat="server" Visible="False"></asp:Label>

                                        <img alt="" id="processing" style="visibility: hidden" src="resources/ico/ajax_loading.gif" />
                                        <div class="row" style="padding-bottom: 10px;">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtEmpSearch" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Search" CausesValidation="False"
                                                    CssClass="btn btn-primary" Width="70px"></asp:Button>
                                            </div>
                                            <div class="col-md-12">
                                            </div>
                                            <%--          <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmpSearch"
                                            BehaviorID="AutoCompleteEx" ServiceMethod="GetEmployeesList" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionSetCount="20" CompletionInterval="500" MinimumPrefixLength="1" OnClientPopulating="ShowIcon"
                                            OnClientPopulated="ShowIcon" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajaxToolkit:AutoCompleteExtender>--%>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtEmpSearch"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtEmpSearch"
                                                SetFocusOnError="True" ForeColor="Red" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 0px;">
                                    <%-- <div class="col-md-12 bg-success">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </div>--%>
                                    <div class="col-md-12">


                                        <asp:GridView ID="grdemployees" runat="server" EmptyDataText="No Records Found!"
                                            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                            DataKeyNames="EID" CellPadding="5" PageSize="50" OnPageIndexChanging="grdemployees_PageIndexChanging">
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FullName" HeaderText="Name">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DesignationName" HeaderText="Designation">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ResionName" HeaderText="Region">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="JoiningDate1" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Joining Date">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' Width="100%" />
                                                    </ItemTemplate>

                                                    <ControlStyle CssClass="imgwd" />

                                                    <ItemStyle Width="6%" />

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnEmployeeEdit" runat="server" ImageUrl="img/list_edit.png"
                                                            OnClick="imgbtnEmployeeEdit_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                            <RowStyle CssClass="Grid_RowStyle" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Separated Employees" ID="TabPanel3"
                        OnDemandMode="None">
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="search_panel">
                                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>

                                        <img id="Img2" style="visibility: hidden" src="resources/ico/ajax_loading.gif" />

                                        <div class="row" style="padding-bottom: 10px;">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtbxSeparation" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="Button2" OnClick="btnSepartaion_Click" runat="server" Text="Search" CausesValidation="False"
                                                    CssClass="btn btn-primary" Width="70px"></asp:Button>
                                            </div>
                                            <div class="col-md-12">
                                            </div>
                                            <%--          <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmpSearch"
                                            BehaviorID="AutoCompleteEx" ServiceMethod="GetEmployeesList" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionSetCount="20" CompletionInterval="500" MinimumPrefixLength="1" OnClientPopulating="ShowIcon"
                                            OnClientPopulated="ShowIcon" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajaxToolkit:AutoCompleteExtender>--%>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchSeparationEmploye"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtbxSeparation"
                                                ID="AutoCompleteExtender3" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxSeparation"
                                                SetFocusOnError="True" ForeColor="Red" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>

                                        <%--<div class="row" style="margin-bottom: 13px;">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtbxSeparation" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btnSepartaion" OnClick="btnSepartaion_Click" runat="server" Text="Search" CausesValidation="False"
                                                    CssClass="btn btn-primary" Width="80px"></asp:Button>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>


                            <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">
                                <div>
                                    <link href="../css/Modal.css" rel="stylesheet" />
                                    <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                                    <div class="modal-dialog">
                                        <asp:Panel ID="Panel3" runat="server">
                                            <div class="popuHeader">
                                                <asp:LinkButton ID="CancelButton" runat="server">
                  <button type="button" class="close" data-dismiss="modal" style="color:white"  aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                </asp:LinkButton>
                                                <h4 id="myModalLabel">Update Separation</h4>
                                            </div>
                                        </asp:Panel>
                                        <div id="Div2">
                                            <div class="row">

                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <br />
                                                            <div class="col-md-3">
                                                                Date
                                                            </div>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="txtTerminateDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtTerminateDate"
                                                                    PopupButtonID="txtTerminateDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                                    Enabled="True" />

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTerminateDate"
                                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Terminate Date"
                                                                    ValidationGroup="EmployeeTermination"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <br />
                                                            <div class="col-md-3">
                                                                Remarks
                                                            </div>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="txtRemarks_TRM" runat="server" CssClass="form-control" Height="50px"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <br />
                                                            <div class="col-md-3">
                                                                Status
                                                            </div>
                                                            <div class="col-md-9">
                                                                <asp:DropDownList ID="drpstatus" runat="server" CssClass="form-control">

                                                                    <asp:ListItem Text="------- Select --------" Value="0"></asp:ListItem>
                                                                    <asp:ListItem>Resignation</asp:ListItem>
                                                                    <asp:ListItem>Termination</asp:ListItem>
                                                                    <asp:ListItem>Retirement</asp:ListItem>

                                                                    <asp:ListItem>Dismissal</asp:ListItem>
                                                                    <asp:ListItem>Died</asp:ListItem>
                                                                    <asp:ListItem>Dis-Continution</asp:ListItem>
                                                                    <asp:ListItem>Others</asp:ListItem>
                                                                    <asp:ListItem>Active</asp:ListItem>

                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hidEid" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">

                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12">

                                                            <div class="col-md-8">
                                                            </div>
                                                            <span style="float: right">
                                                                <div class="col-md-4">
                                                                    <asp:Button ID="btnJobTermntSubmit" ValidationGroup="EmployeeTermination" runat="server" Text="Submit" class="btn btn-primary"
                                                                        OnClick="btnJobTermntUpdate_Click" />
                                                                </div>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                    </div>

                                </div>

                            </asp:Panel>
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                                DropShadow="True" PopupDragHandleControlID="Panel3" DynamicServicePath="" Enabled="True" />


                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridviewSeparation" runat="server" EmptyDataText="No Records Found!"
                                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="EmpId" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="GridviewSeparation_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FullName" HeaderText="Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DesignationName" HeaderText="Designation">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                            <%-- <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                            <%-- <asp:BoundField DataField="Email" HeaderText="Email">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="ResionName" HeaderText="Region">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="JoiningDate1" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Joining Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Terminatedate" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Separation Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="EMP_TERMIN_STATUS" HeaderText="Status">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Image" ControlStyle-CssClass="imgwd">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' Width="100%" />
                                                </ItemTemplate>
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <ItemStyle Width="6%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSeparationImageEidt" runat="server" ImageUrl="img/list_edit.png"
                                                        OnClick="btnSeparationImageEidt_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle CssClass="Grid_Header" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Transfered Employees" ID="TabPanel2"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="search_panel">
                                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>

                                        <img alt="" id="Img1" style="visibility: hidden" src="resources/ico/ajax_loading.gif" />
                                        <div class="row" style="padding-bottom: 10px;">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtbxTranserfer" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnGo').click();};"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="Button3" OnClick="btnTransfer_Click" runat="server" Text="Search" CausesValidation="False"
                                                    CssClass="btn btn-primary" Width="70px"></asp:Button>
                                            </div>
                                            <div class="col-md-12">
                                            </div>
                                            <%--          <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmpSearch"
                                            BehaviorID="AutoCompleteEx" ServiceMethod="GetEmployeesList" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionSetCount="20" CompletionInterval="500" MinimumPrefixLength="1" OnClientPopulating="ShowIcon"
                                            OnClientPopulated="ShowIcon" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajaxToolkit:AutoCompleteExtender>--%>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchTransferEmployee"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtbxTranserfer"
                                                ID="AutoCompleteExtender4" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbxTranserfer"
                                                SetFocusOnError="True" ForeColor="Red" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <%--  <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="btnTransfer"
                                            BehaviorID="AutoCompleteEx" ServiceMethod="GetEmployeesList" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                            CompletionListItemCssClass="autocomplete_listItem"
                                            CompletionSetCount="20" CompletionInterval="500" MinimumPrefixLength="1" OnClientPopulating="ShowIcon"
                                            OnClientPopulated="ShowIcon" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="btnTransfer"
                                            SetFocusOnError="True" ForeColor="Red" ValidationGroup="signup" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <asp:GridView ID="GridViewEMP_TRNS" runat="server" EmptyDataText="No Records Found!"
                                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="EmpId" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="GridViewEMP_TRNS_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EmpId")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="FirstName" HeaderText="First Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="FullName" HeaderText="Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DesignationName" HeaderText="Designation">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <%--<asp:BoundField DataField="Email" HeaderText="Email">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>--%>
                                            <asp:BoundField DataField="ResionName" HeaderText="Region">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Image">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' Width="100%" />
                                                </ItemTemplate>
                                                <ItemStyle Width="6%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <HeaderStyle CssClass="Grid_Header" />
                                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <%--      <ajaxToolkit:TabPanel runat="server" HeaderText="Terminated Employees" ID="TabPanel3"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridViewEMP_TR" runat="server" EmptyDataText="No Records Found!"
                                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="EmpId" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="GridViewEMP_TR_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EmpId")%>' />
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
                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                          
                                            <asp:BoundField DataField="ResionName" HeaderText="Region">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Image">
                                                 <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' />
                                                </ItemTemplate>
                                                 <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>--%>

                    <%--<ajaxToolkit:TabPanel runat="server" HeaderText="Resignated Employees" ID="TabPanel5"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    
                                    <asp:GridView ID="gridviewResignation" runat="server" EmptyDataText="No Records Found!"
                                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="EmpId" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="gridviewResignation_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EmpId")%>' />
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
                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>                                         
                                            <asp:BoundField DataField="ResionName" HeaderText="Region">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Image">
                                                 <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' />
                                                </ItemTemplate>
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                    </asp:GridView>

                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>--%>

                    <%--<ajaxToolkit:TabPanel runat="server" HeaderText="Retired Employees" ID="TabPanel6"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="gridTetired" runat="server" EmptyDataText="No Records Found!"
                                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="EmpId" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="gridTetired_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EmpId")%>' />
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
                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                          
                                            <asp:BoundField DataField="ResionName" HeaderText="Region">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Image">
                                                 <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' />
                                                </ItemTemplate>
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>--%>
                </ajaxToolkit:TabContainer>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function func(result) {

            if (result === 'Separation Successfully!') {
                toastr.success(result);
            }

            else if (result === 'Please Select Status') {
                toastr.error(result);

            }

            return false;
        }

    </script>
</asp:Content>
