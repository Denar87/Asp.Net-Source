<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeEvulation.aspx.cs" Inherits="ERPSSL.HRM.EmployeeEvulation" %>
  <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>
    <div class="row">
        
       
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Employee Evaluation
            </div>
        </div>
             <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    E-ID No:
                                </div>
                                <div class="col-md-7">
                                    <asp:Label ID="lblHiddenId" runat="server" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtEid" runat="server" AutoPostBack="True" ontextchanged="txtEid_TextChanged" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RFV_EID" ValidationGroup="validation_EmpEVL" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" 
                                                                 ErrorMessage="*" ControlToValidate="txtEid" runat="server">
                                     </asp:RequiredFieldValidator>
                            </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Name
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtEmpName" ReadOnly="True" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Department
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="txtDepartment" ReadOnly="True" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Designation
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtDesignation" ReadOnly="True" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Employee Photo
                                </div>
                                <div class="col-md-7">
                                    <asp:Image ID="Emp_IMG" runat="server" class="avater_details" Height="80px" ImageUrl="resources/no_image.png"
                                        onerror="this.onerror=null; this.src='resources/no_image_found.png';" Width="80px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <br />
                <fieldset>
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Evaluation Criteris
                        </div>
                    </div>
                    <div class="panel" align="center">
                        <div class="panel-heading panel-heading-03 ">
                            <asp:Label Text="1 = Poor" ID="lbl01" runat="server"></asp:Label> &nbsp; &nbsp;
                            <asp:Label Text="2 = Fair" ID="Label1" runat="server"></asp:Label> &nbsp; &nbsp;
                            <asp:Label Text="3 = Satisfactory" ID="Label2" runat="server"></asp:Label> &nbsp; &nbsp;
                            <asp:Label Text="4 = Good" ID="Label3" runat="server"></asp:Label> &nbsp; &nbsp;
                            <asp:Label Text="5 = Excelent" ID="Label4" runat="server"></asp:Label> &nbsp; &nbsp;
                        </div>
                    </div>
                    <div>
                    <div class="row">
                          <div class="col-md-3">
                            <div class="col-md-9">
                               <b> Total Score: </b> 
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                            </div>
                          </div>
                    </div>
                    </div>
                    <br/>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Absence of Error
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="Rating_AbsErro" runat="server" BehaviorID="RatingBehavior1" OnChanged="Rating_AbsErro_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Accuracy
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingAccuracy" runat="server" BehaviorID="RatingBehavior3" OnChanged="RatingAccuracy_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Habbit
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingHabbit" runat="server" BehaviorID="RatingBehavior5" OnChanged="RatingHabbit_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Innovation
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingInnovation" runat="server" BehaviorID="RatingBehavior7" OnChanged="RatingInnovation_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Orderliness
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingOrderliness" runat="server" BehaviorID="RatingBehavior9" OnChanged="RatingOrderliness_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Attendance
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingAttendance" runat="server" BehaviorID="RatingBehavior2" OnChanged="RatingAttendance_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Co-operation
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingCo_operation" runat="server" BehaviorID="RatingBehavior4" OnChanged="RatingCo_operation_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Initiative
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingInitiative" runat="server" BehaviorID="RatingBehavior6" OnChanged="RatingInitiative_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Knowledge
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingKnowledge" runat="server" BehaviorID="RatingBehavior8" OnChanged="RatingKnowledge_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Reliability
                                </div>
                                <div class="col-md-7">
                                    <ajaxToolkit:Rating ID="RatingReliability" runat="server" BehaviorID="RatingBehavior10" OnChanged="RatingReliability_Changed"
                                        CurrentRating="1" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    <asp:Label ID="lblEmpEvaluation" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:Button ID="btnEmpEvulation"  ValidationGroup="validation_EmpEVL" runat="server" Text="Process" 
                                        class="btn btn-info pull-right " onclick="btnEmpEvulation_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <br />
                <fieldset>
                    <asp:GridView ID="GridViewEMP_EVL" runat="server" EmptyDataText="No Records Found!"
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="EVAL_ID" ShowFooter="True" CellPadding="5" 
                        onpageindexchanging="GridViewEMP_EVL_PageIndexChanging" PageSize="5">
                        <Columns>
                            <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("HRM_PersonalInformations.FirstName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ABSENCERROR" HeaderText="ABSENCERROR">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ACCURACY" HeaderText="ACCURACY">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HABBIT" HeaderText="HABBIT">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INNOVATION" HeaderText="INNOVATION">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ORDERLINES" HeaderText="ORDERLINES">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ATTENDANCE" HeaderText="ATTENDANCE">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CO_OPERATION" HeaderText="CO-OPERATION">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INITIATIVE" HeaderText="INITIATIVE">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="KNOWLEDGE" HeaderText="KNOWLEDGE">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RELIABILITY" HeaderText="RELIABILITY">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <RowStyle CssClass="Grid_RowStyle" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Left" CssClass="pagination01 pageback" />
                    </asp:GridView>
                </fieldset>
            </div>
        </div>
        </div>
    </div>
    </ContentTemplate>
<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnEmpEvulation" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="txtEid" EventName="TextChanged" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>
