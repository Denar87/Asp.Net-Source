<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="Attendancebounes.aspx.cs" Inherits="ERPSSL.HRM.Attendancebounes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>
    
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Attendance Bonus
        </div>
    </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <br />
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Office
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="drpdwnOffice" AutoPostBack="True" class="form-control"
                                runat="server">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="drpdwnOffice" ErrorMessage="Select Office" InitialValue="0"></asp:RequiredFieldValidator>
                                            
                               <asp:HiddenField ID="hidAttenBounsId" runat="server" />
                        </div>
                    </div>



                </div>
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Designation
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="drpDesination" AutoPostBack="True" class="form-control"
                                runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="drpDesination" ErrorMessage="Select Designation" InitialValue="0"></asp:RequiredFieldValidator>
                                    
                        </div>
                    </div>


                   
                </div>
               
            </div>
            
            <div class="col-md-12">
                
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Attendance Day's
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxFirstAttendanceDay" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>



                </div>
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                           Amount
                        </div>
                        <div class="col-md-7">
                           <asp:TextBox ID="txtbxFirstAttendanceAmount" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    

                </div>
            </div>
            <div class="col-md-12">
               <br />
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Attendance Day's
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxSecondAttendanceDayes" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>



                </div>
                <div class="col-md-6">
                    <div class="col-md-12">

                        <div class="col-md-5">
                           Amount
                        </div>
                        <div class="col-md-7">
                           <asp:TextBox ID="txtbxSecondAttendanceAmount" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                          
                        </div>
                        <div class="col-md-7">
                           <asp:Button ID="btnAttendanceBounes"   ValidationGroup="Group2" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="btnAttendanceBounes_Click"  />
                        </div>
                    </div>

                </div>
            </div>

            

        </div>

        <div class="row">
            <br />
            <div class="col-md-12">

                   <asp:GridView ID="gridviewattendanceBonus" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True"  PageSize="10" OnPageIndexChanging="gridviewattendanceBonus_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblAttendanceBounsId" runat="server" Text='<%# Eval("attendanceBounsId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OfficeName" HeaderText="Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Desgination" HeaderText="Desgination">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                         <asp:BoundField DataField="AttendanceDays1" HeaderText="Attendance Days(26)">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Amount1" HeaderText="Amount">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="AttendanceDays2" HeaderText="Attendance Days(20)">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Amount2" HeaderText="Amount">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>


                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnRegionEdit" runat="server" ImageUrl="img/list_edit.png"
                                    OnClick="imgbtnAttendanceBonus_Click" />
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
</ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnAttendanceBounes" EventName="Click" />
<%--<asp:AsyncPostBackTrigger ControlID="drpdwnBranch" EventName="SelectedIndexChanged" />--%>
</Triggers>
</asp:UpdatePanel>
    <script>

        function func(result) {

            if (result === 'Data Save Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Update Save Successfully !') {
                toastr.success(result);
            }

            return false;
        }

   </script>
</asp:Content>
