<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeTransfer.aspx.cs" Inherits="ERPSSL.HRM.EmployeeTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>



            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Employee Info
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblTrnsMessage" runat="server" Font-Bold="True"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <fieldset>
                            <div class="col-md-12">

                                <div class="col-md-6">

                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:CheckBox ID="chTransferWithIncrement" runat="server" Text="Transfer With Salary Increment" />
                                            <asp:HiddenField ID="hidTransferStatus" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:CheckBox ID="chePromotionWithSalaryIncrement" runat="server" Text="Promotion With Salary Increment" />
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-6">

                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:CheckBox ID="cheTransferWithoutSalaryIncrement" runat="server" Text="Transfer Without Salary Increment" />
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:CheckBox ID="ChPromotionWithoutIncrement" runat="server" Text="Promotion Without Salary Increment" />
                                        </div>
                                    </div>

                                </div>
                                <br />
                            </div>
                            <div class="col-md-12">
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            E-ID
                                <asp:Label ID="lblHiddenIdTR" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtEid_TRNS" Class="form-control" runat="server" AutoPostBack="True"
                                                OnTextChanged="txtEid_TRNS_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Employee Name
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtEmpName" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <%--<div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Department
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDepartment" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>
                                <%--<div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Designation
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDesignation" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            Photo
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Image ID="Emp_IMG_TRNS" runat="server" class="avater_details" Height="80px"
                                                ImageUrl="resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                Width="80px" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </fieldset>
                        <br />
                        <fieldset>
                            <div class="col-md-6">
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Transfer From
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRegion_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblRegion_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRegion_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS">
                                                    
                                            </asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txtOffice_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblOffice_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOffice_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txtDepartment_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblDepartment_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDepartment_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Section
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtSection_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblSection_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSection_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Sub-Section
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtSubSection_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblSubSection_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSubSection_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txtDesignation_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblDesignation_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDesignation_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <%-- <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Step
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtStep_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblStep_TRNS" runat="server" Visible="False"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStep_TRNS"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>--%>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Grade
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtGrade_TRNS" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblGrade_TRNS" runat="server" Visible="False"></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtGrade_TRNS"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Gorss Salary
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtbxGossSalary" ReadOnly="True" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblStepGrossSalary" runat="server" Visible="False"></asp:Label>
                                            <%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStep_TRNS"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="*" ValidationGroup="validation_TRNS"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Transfer To
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlRegion_TR" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlRegion_TR_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Text="------- Select ------- " Value="0"></asp:ListItem>
                                            </asp:DropDownList>
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
                                            <asp:DropDownList ID="ddlOffice_TR" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlOffice_TR_SelectedIndexChanged">
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
                                            <asp:DropDownList ID="ddlDepartment_TR" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlDepartment_TR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Section
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlSection_TR" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSection_TR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Sub-Section
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlSubSec_TR" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <%--<div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Designation
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlDesignation_TR" AppendDataBoundItems="True" CssClass="form-control"
                                        runat="server">
                                        <asp:ListItem Text="------- Select ------- " Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Step
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlStep_TR" CssClass="form-control" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlStep_TR_SelectedIndexChanged">
                                        <asp:ListItem Text="------- Select ------- " Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Step-1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Step-2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Step-3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Step-4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Step-5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Step-6" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Grade
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlGrade_TR" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />--%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Desgination
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpdwnDesigantion" Class="form-control" runat="server" OnSelectedIndexChanged="drpStep_SelecttedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="drpdwnDesigantion" ErrorMessage="Select Step" InitialValue="0"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Grade
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlGrade" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelecttedIndexChanged" Class="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="ddlGrade" ErrorMessage="Select Grade" InitialValue="0"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtbxGarde" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Gross Salary
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="drpGrossSalary" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpGrossSalary_SelecttedIndexChanged" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtbxGrossSalary" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnTrStaffSubmit" runat="server" Text="Process" class="btn btn-info pull-right"
                                                OnClick="btnTrStaffSubmit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <br />
                        <div class="col-md-12">
                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Transfer/Promotion List
                                    </div>
                                </div>
                                <div style="padding-left: 8px">
                                    <br />
                                    <asp:GridView ID="GridViewEMP_TRNS" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" Width="100%" DataKeyNames="Id" ShowFooter="True"
                                        CellPadding="5">
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>


                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="TransferDate" HeaderText="Transfer-Date" DataFormatString="{0:dd/MM/yyyy}">
                                                <FooterStyle CssClass="Grid_Footer" />
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                            </asp:BoundField>


                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle BackColor="#6393C1" ForeColor="White" HorizontalAlign="Left" CssClass="pagination01 pageback" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </div>

                    </div>
                </div>
            </div>


        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnTrStaffSubmit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRegion_TR" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlDepartment_TR" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOffice_TR" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSection_TR" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSubSec_TR" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="drpdwnDesigantion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlGrade" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtEid_TRNS" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'This Employee is Inactive!') {
                toastr.error(result);
            }
            else if (result == 'Data Save Successfully') {
                toastr.success(result);
            }
            else if (result == 'Please Select Transfer Or Promotion Type!') {
                toastr.error(result);
            }
            return false;
        }

    </script>
</asp:Content>
