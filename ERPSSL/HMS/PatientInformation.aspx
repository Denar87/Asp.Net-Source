<%@ Page Title="" Language="C#" MasterPageFile="~/HMS/HMS.Master" AutoEventWireup="true"
    CodeBehind="PatientInformation.aspx.cs" Inherits="ERPSSL.HMS.PatientInformation" ClientIDMode="Static" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel5" ChildrenAsTriggers="true">

        <ContentTemplate>

            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Patient Information
                        </div>
                    </div>
                    <div class="col-md-12">                      
                        <div class="row" id="ShowDiv" runat="server">
                            
                            <fieldset>
                                <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff"></span></legend>
                                <div class="col-md-12" style="background-color: #f0f5f6; padding-bottom: 10px;">

                                    <div class="col-md-3" style="padding-left: 0;">
                                        <div class="row">

                                            <div>
                                                Patient Name
                                                <asp:TextBox ID="txtPatientName" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                                 <asp:HiddenField ID="hidPatientId" runat="server" />
                                                 <asp:HiddenField ID="hidPatientName" runat="server" />
                                            </div>
                                         </div>
                                         <div class="row">
  
                                              <div class="col-md-6" style="padding-left: 0px;">
                                                Age
                                                <asp:TextBox ID="txtAge" Class="form-control " runat="server"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-md-6" style="padding-right: 0px; padding-top:17px;">
                                                  <asp:DropDownList ID="ddlAgeFormat" CssClass=" form-control" runat="server">
                                                  <asp:ListItem Value ="Day">Day</asp:ListItem>
                                                  <asp:ListItem Value ="Month">Month</asp:ListItem>  
                                                   <asp:ListItem Value ="Year" Selected="True" >Year</asp:ListItem>   
                                                </asp:DropDownList>
                                            </div> 

                                         </div>
                                         <div class="row">

                                            <div>
                                                Gender
                                               <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server"> 
                                               <asp:ListItem Value ="0">--Select--</asp:ListItem> 
                                               <asp:ListItem Value ="Male">Male</asp:ListItem>
                                               <asp:ListItem Value ="Female">Female</asp:ListItem>   
                                               </asp:DropDownList>
                                            </div>

                                          </div>
                                        
                                          <div class="row">
                                               Blood Group
                                            <asp:DropDownList ID="ddlBloodGrp" CssClass="form-control2 form-control" runat="server">
                                                  <asp:ListItem Value ="0">--Select--</asp:ListItem>
                                                  <asp:ListItem Value ="A+">A+</asp:ListItem>
                                                  <asp:ListItem Value ="A-">A-</asp:ListItem>  
                                                  <asp:ListItem Value ="B+">B+</asp:ListItem>
                                                  <asp:ListItem Value ="B-">B-</asp:ListItem>  
                                                  <asp:ListItem Value ="AB+">AB+</asp:ListItem>
                                                  <asp:ListItem Value ="AB-">AB-</asp:ListItem>   
                                                  <asp:ListItem Value ="O+">O+</asp:ListItem>
                                                  <asp:ListItem Value ="O-">O-</asp:ListItem> 
                                            </asp:DropDownList>
                                        </div>
                                        
                                    </div>
                                    <div class="col-md-3">
                                        <div class="row">
                                           <div>
                                                Marital status
                                                 <asp:DropDownList ID="ddlMarital" CssClass="form-control" runat="server">  
                                                     <asp:ListItem Value ="0">--Select--</asp:ListItem>
                                                     <asp:ListItem Value ="Married">Married</asp:ListItem>
                                                     <asp:ListItem Value ="Unmarried">Unmarried</asp:ListItem>   
                                                     <asp:ListItem Value ="Divorced">Divorced/Widow</asp:ListItem> 
                                               </asp:DropDownList>
                                            </div>
                                            
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-5" style="padding: 0px;">
                                                   Mobile 
                                                </div>                                                                                            
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <asp:TextBox ID="txtMobile" Class="form-control " runat="server" ></asp:TextBox>                                               
                                            </div>
                                        </div>
                                        <div class="row">
                                             <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-3" style="padding: 0px;">
                                                    Address
                                                </div>                                                
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <asp:TextBox ID="txtAddress" Class="form-control " runat="server"></asp:TextBox>                                             
                                            </div>
                                           
                                        </div>
                                        <div class="row">
                                            Guardian Name
                                            <asp:TextBox ID="txtGuardian" Class=" form-control2 form-control " runat="server" ></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-md-3">
                                        <div class="row">
                                            Emergency Contact
                                            <asp:TextBox ID="txtEmerContact" Class=" form-control2 form-control " runat="server" ></asp:TextBox>
                                        </div>
                                        <div class="row">
                                            <div>
                                                Visit Date
                                            <asp:TextBox ID="txtVisitDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtVisitDate"
                                                    PopupButtonID="txtVisitDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                        <div class="row">
                                             Bill Category
                                         <asp:DropDownList ID="ddlCategory" CssClass="form-control2 form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" Enabled="false" > 
                                               <asp:ListItem Value ="3">IPD</asp:ListItem>  
                                        </asp:DropDownList>
                                        </div>
                                        <div class="row">
                                            Bill Head
                                             <asp:DropDownList ID="ddlHead" CssClass="form-control2 form-control" runat="server" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="col-md-3">

                                        <div class="row">
                                            Amount
                                            <asp:TextBox ID="txtAmount" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        </div>
                                        <div class="row">
                                            Bed/Cabin No
                                            <asp:TextBox ID="txtBedNo" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        </div>
                                        <div class="row">
                                           Reffered By
                                           <asp:TextBox ID="txtRefdBy" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        </div>
                                        <div class="row">
                                           Remarks
                                           <asp:TextBox ID="txtRemarks" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                            </fieldset>

                            <div class="row" style="margin-top: 3px; padding-right: 50px;" >
                               <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                           </div>
                          
                        </div>
                        <div class="row" id="ShowGrid" runat="server" style="padding-top: 5px;">
                                                
                               
                                            <asp:GridView ID="gridPatient" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="True" OnPageIndexChanging="gridPatient_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPatientId" runat="server" Text='<%# Bind("PatientID") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PatientName" HeaderText="Patient">
                                                         <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                                        <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                                        <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GuardianName" HeaderText="Guardian">
                                                        <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                                                        <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Bill_Head_Name" HeaderText="Head">
                                                        <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount">
                                                        <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VisitDate" HeaderText="Visit Date">
                                                         <HeaderStyle VerticalAlign="Middle" />
                                                         <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnImgPatientEdit" runat="server" ImageUrl="~/HMS/img/list_edit.png" OnClick="btnImgPatientEdit_Click" />
                                                        </ItemTemplate>
                                                         <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#275353" />
                                            </asp:GridView>                                                                      
                                
                        </div>
                    </div>

                         <center>
              
                            <div class="row">
                                            
                                <div >
                                                           
                                    <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="80%"
                                        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                                        PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                                        InteractivityPostBackMode="AlwaysSynchronous">

                                    </rsweb:ReportViewer>

                                </div>
                            </div>
                                  
                       </center>

                </div>
            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {

            if (result === 'Data Saved Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>


