<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeTermination.aspx.cs" Inherits="ERPSSL.HRM.EmployeeTermination" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>


            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Employee Info
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblTrMessage" runat="server" Font-Bold="True"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <fieldset style="border: 0px solid Black">
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            E-ID
                               <%-- <asp:Label ID="lblHiddenIdTR" runat="server"></asp:Label>--%>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtEid_TR" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid_TR_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEid_TR"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-ID No"
                                                ValidationGroup="EmployeeTermination"></asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="hidTerminationid" runat="server" />
                                            <asp:HiddenField ID="hidEid" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            Name
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtEmpName_TR" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            Department
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtDepartment" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            Designation
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtDesignation" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            Photo
                                        </div>
                                        <div class="col-md-9">
                                            <asp:Image ID="Emp_IMG_TR" CssClass="form-control" runat="server" class="avater_details" Height="80px" ImageUrl="resources/no_image.png"
                                                onerror="this.onerror=null; this.src='resources/no_image_found.png';" Width="80px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="panel">
                                <div class="panel-heading panel-heading-01">
                                    <i class="fa fa-edit fa-fw icon-padding"></i>Separation Of
                                </div>
                            </div>
                            <div class="col-md-4">
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


                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-3">
                                            Status
                                        </div>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="drpstatus" CssClass="form-control" runat="server">

                                                <asp:ListItem Text="------- Select --------" Value="0"></asp:ListItem>
                                                <asp:ListItem>Resignation</asp:ListItem>
                                                <asp:ListItem>Termination</asp:ListItem>
                                                <asp:ListItem>Retirement</asp:ListItem>
                                                <asp:ListItem>Dismissal</asp:ListItem>
                                                <asp:ListItem>Died</asp:ListItem>
                                                <asp:ListItem>Dis-Continution</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>



                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
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


                                <div class="col-md-12">
                                    <br />
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-9">
                                        <asp:Button ID="btnJobTermntSubmit" ValidationGroup="EmployeeTermination" runat="server" Text="Submit" class="btn btn-info pull-right"
                                            OnClick="btnJobTermntSubmit_Click" />
                                    </div>
                                </div>

                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="panel">
                                <div class="panel-heading panel-heading-01">
                                    <i class="fa fa-edit fa-fw icon-padding"></i>Separation List
                                </div>
                            </div>
                            <div style="padding-left: 8px">
                                <br />
                                <asp:GridView ID="GridViewEMP_TR" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" Width="100%">
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <Columns>
                                        <%----------------------------------------------------%>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeIdId" runat="server" Text='<%# Eval("EID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTERMINATE_ID" runat="server" Text='<%# Eval("TERMINATE_ID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTERMINATE_DATE" runat="server" Text='<%# Eval("TERMINATE_DATE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblREMARKS" runat="server" Text='<%# Eval("REMARKS")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%----------------------------------------------------%>

                                        <asp:BoundField DataField="EID" HeaderText="ID">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="5%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="EmployeeFullName" HeaderText="Name">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="DEG_NAME" HeaderText="Designation">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="TERMINATE_DATE" DataFormatString="{0:MMMM d, yyyy}" HeaderText="DATE"
                                            HtmlEncode="False">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="7%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="REMARKS" HeaderText="REMARKS">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEmployeeEdit" runat="server" ImageUrl="img/list_edit.png"
                                                    OnClick="imgbtnEmployeeEdit_Click" />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>

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

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnJobTermntSubmit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txtEid_TR" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <script>

        function func(result) {

            if (result === 'Record Added successfully') {
                toastr.success(result);
            }

            return false;
        }

    </script>
</asp:Content>
