<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="New_User.aspx.cs" Inherits="ERPSSL.BuyingHouse.New_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">   

        <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ToolkitScriptManager1" />

    <asp:updatepanel id="UpdatePanel7" runat="server">
    <ContentTemplate>

    <div class="row">

        <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>New User
            </div>
            <asp:HiddenField ID="hdnUnitId" runat="server" />
        </div>
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="col-md-6">
             <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Region
                                    </h5>--%>
                                    <div class="col-md-5" style="padding-left: 0px;">
                                        Region
                                    </div>
                                    <div class="col-md-7" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>                                    
                                    </div>
                                </div>
                                <br />
                            </div>
                            

                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Office
                                    </h5>--%>
                                    <div class="col-md-5" style="padding-left: 0px;">
                                        Office
                                    </div>
                                    <div class="col-md-7" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>                          

                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                 
                                    <div class="col-md-5" style="padding-left: 0px;">
                                        Department
                                    </div>
                                    <div class="col-md-7" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                   
                                    <div class="col-md-5" style="padding-left: 0px;">
                                        Section
                                    </div>
                                    <div class="col-md-7" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSection" CssClass="form-control"  runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <%--<div class="col-md-12" style="padding-left: 0px;">
                                <div class="row">
                                
                                   
                                    <div class="col-md-5" style="padding-left: 0px;">
                                        Sub-Section
                                    </div>
                                    <div class="col-md-7" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                            runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </div>

                                </div>
                                <br />
                            </div>--%>
        </div>
        <div class="col-md-6">
   
           

            <div class="col-md-12" style="padding-left: 0px;">
                <div class="row">
                      
                    <div class="col-md-5" style="padding-left: 0px;">
                        Designations:
                    </div>
                    <div class="col-md-7" style="padding-left: 0px;">
                       
                        <asp:DropDownList ID="ddlDesignations" Class="form-control" runat="server"  AppendDataBoundItems="True">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>    
                                            </asp:DropDownList>
                    </div>
                </div>
                <br />
                
            </div>
              
            


            <div class="row">
                <div class="col-md-12" style="padding-left: 0px;">
                    <div class="col-md-5" style="padding-left: 0px;">
                        User's Name
                    </div>
                    <div class="col-md-7" style="padding-left: 0px;">
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  SetFocusOnError="true"
                            ControlToValidate="txtUserName" ValidationGroup="User"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12" style="padding-left: 0px;">
                    <div class="col-md-5" style="padding-left: 0px;">
                        Employee ID
                    </div>
                    <div class="col-md-7" style="padding-left: 0px;">
                      <%--  <asp:TextBox ID="txtEmployeeId" CssClass="form-control" runat="server" 
                            AutoPostBack="True" ontextchanged="txtEmployeeId_TextChanged"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server"></asp:Label>--%>
                        
                                                        <script src="js/CheckUser.js" type="text/javascript"></script>
                                                        <asp:UpdatePanel ID="PnlUsrDetails" runat="server">
                                                            <ContentTemplate>
                                                                <div id="Checkusername" runat="server" visible="false" class="CheckResult">
                                                                    <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" />
                                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="waitingdiv" id="loadingdiv" style="display: none">
                                                                    <img src="../resources/ico/LoadingImage.gif" alt="Loading.." class="waiting_img" />

                                                                    Please wait...
                                                                </div>
                                                                <div class="clearfix">
                                                                <asp:TextBox ID="txtEmployeeId" runat="server" placeholder="Unique Employee ID" CssClass="form-control"
                                                                    AutoPostBack="True" OnTextChanged="txtEID_TextChanged"></asp:TextBox>
                                                                    </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeId"
                                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-Id"
                                                                    ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                               
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12" style="padding-left: 0px;">
                    <div class="col-md-5" style="padding-left: 0px;">
                        Email
                    </div>
                    <div class="col-md-7" style="padding-left: 0px;">
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true" 
                            ControlToValidate="txtEmail" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12" style="padding-left: 0px;">
                    <div class="col-md-5" style="padding-left: 0px;">
                        Phone
                    </div>
                    <div class="col-md-7" style="padding-left: 0px;">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  SetFocusOnError="true"
                            ControlToValidate="txtPhone" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5" style="padding-left: 0px;">
                        
                    </div>
                    <div class="col-md-7" style="padding-left: 0px;">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save" 
                            onclick="btnSave_Click" ValidationGroup="User" />
                    </div>
                </div>
            </div>
           
            <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
            </asp:UpdatePanel>
        </div>
    </div>
    </ContentTemplate>
    </asp:updatepanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save Successfully.') {
                toastr.success(result);

            }   
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
