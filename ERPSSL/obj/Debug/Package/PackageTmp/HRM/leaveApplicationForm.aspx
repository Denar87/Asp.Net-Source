<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="leaveApplicationForm.aspx.cs" Inherits="ERPSSL.HRM.leaveApplicationForm"
    ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>
--%>

    <link href="MultiCalender/css/mdp.css" rel="stylesheet" type="text/css" />
    <%--<script src="MultiCalender/js/jquery-2.1.1.js" type="text/javascript"></script>--%>
    <script src="MultiCalender/js/jquery-ui-1.11.1.js" type="text/javascript"></script>
    <script src="MultiCalender/jquery-ui.multidatespicker.js" type="text/javascript"></script>
   
   
    <div class="hm_sec_2_content scrollbar">
         <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Leave Application Form
        </div>
    </div>
    <div class="col-md-12" style="padding:0px">
        <div class="col-md-9"></div>
         <div class="col-md-3">
             <p>Leave Code :<asp:Label ID="lblLeaveId" runat="server"></asp:Label></p>
         </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-danger" style="padding:0px; padding-left:10px" role="alert">
                Applicant</div>
        </div>
        <div class="col-md-12">
            <div class="col-md-2">
               
                    <div class="col-md-12" style="padding:0px"">
                        <div class="col-md-7">
                            E-ID:
                        </div>
                        <div class="col-md-5">
                            <asp:Label ID="lblApplicantId" runat="server"></asp:Label>
                            <asp:HiddenField ID="hidReportingBossID" runat="server" />
                        </div>
                    </div>
              
            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Name:
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            Department:
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblApplicantDepartment" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                
                    <div class="col-md-12">
                        <div class="col-md-6">
                            Designation:
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblApplicantDesignation" runat="server"></asp:Label>
                        </div>
                    </div>
             
            </div>
        </div>
        <div class="col-md-12">
            <br />
            <div class="alert alert-danger" style="padding:0px; padding-left:10px" role="alert">
                Annual Leave Info</div>
        </div>
        <div class="col-md-12">
        <div class="col-md-6">
            <asp:Repeater ID="RLeaveTypes" runat="server">
                <ItemTemplate>
                    <div style="float: left; margin-right: 5px">
                        <asp:Label ID="lblLeaveTypes" CssClass="label label-primary" runat="server" Text='<%# Eval("LEV_TYPE") %>'></asp:Label>
                        <asp:Label ID="lblLeaveDay" CssClass="label label-info" runat="server" Style="margin-right: 10px"
                            Text='<%# Eval("LEV_DAYS") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-6">
           
            <div class="col-md-4">
                
                    <div class="col-md-12">
                        <div class="col-md-6" style="padding:0px">
                            <span class="label label-default">Total:</span>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </div>
                   
                </div>
            </div>
            <div class="col-md-4">
                
                    <div class="col-md-12">
                        <div class="col-md-6" style="padding:0px">
                            <span class="label label-default">Taken:</span>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblToken" runat="server"></asp:Label>
                        </div>
                   
                </div>
            </div>
            <div class="col-md-4">
               
                    <div class="col-md-12">
                        <div class="col-md-6" style="padding:0px">
                            <span class="label label-default">Balance:</span>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblBanlance" runat="server"></asp:Label>
                        </div>
                    
                </div>
            </div>
        </div>
       </div>
        <div class="col-md-12">
            <br />
            <div class="alert alert-danger" style="padding:0px" role="alert">
                Details Of Event</div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <br />
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Applied 
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblDateApplied" runat="server"></asp:Label>
                            <asp:HiddenField ID="hidLeaveId" runat="server" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Leave Type 
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="drpLeaveType" Class="form-control" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="drpLeaveType_SelectedChange">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Leave Date 
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtLeaveDate" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLeaveDate"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Total day
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtbxTotalDay" onclick="txtBox1_ClientClicked()" runat="server"
                                Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxTotalDay"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                             Reason 
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtbxLeaveReason" TextMode="MultiLine" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxLeaveReason"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div class="col-md-12">
                    <div class="col-md-4">
                       
                            Total day:
                      
                        
                            <asp:Label ID="lblTotalLeaveOFType" runat="server" Text=""></asp:Label>
                       
                    </div>
                    <div class="col-md-4">
                       
                            Taken:
                       
                       
                            <asp:Label ID="lblTTaken" runat="server" Text=""></asp:Label>
                        
                    </div>
                    <div class="col-md-4">
                       
                            Balance:
                       
                      
                            <asp:Label ID="lblTBalance" runat="server" Text=""></asp:Label>
                        
                    </div>
                </div>
                <div class="col-md-12">
                    <br />
                    <asp:GridView ID="gridviewLeaveInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblLeaveId" runat="server" Text='<%# Eval("LeaveCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LeaveAppliedDate" HeaderText="Applied">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveDates" HeaderText="Leave Dates">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalDay" HeaderText="Total Day">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Leve Status">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkStatus" CssClass="btn btn-info  pull-right" CommandArgument='<%# Eval("LeaveStatusHRM") %>'
                                        runat="server"><%# Eval("LeaveStatusHRM")%></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="DisApprove Status">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkStatus1" CssClass="btn btn-info  pull-right" CommandArgument='<%# Eval("ApproveOrDisApproveStatus") %>'
                                        runat="server"><%# Eval("ApproveOrDisApproveStatus")%></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Leave Dates">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnLeaveEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnLeaveEdit_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
        <div class="row">
            <div class="col-md-12">
                <br />
                <div class="col-md-2">
                </div>
                <div class="col-md-6">
                    <asp:Button ID="BtnLeaveSubmit" ValidationGroup="Group1" runat="server" class="btn btn-info  pull-right"
                        Text="Submit" OnClick="BtnLeaveSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
        </div>

    <script type="text/javascript">
        $('#txtLeaveDate').multiDatesPicker();

    </script>
    <script type="text/javascript">

        function txtBox1_ClientClicked() {
            var taotalDate = document.getElementById('<%=txtLeaveDate.ClientID%>').value
            var counttoatalDate = taotalDate.split(',');
            document.getElementById('<%=txtbxTotalDay.ClientID%>').value = counttoatalDate.length;
        }
                 
    </script>
 <%--   
</ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="BtnLeaveSubmit" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="drpLeaveType" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>--%>
</asp:Content>
