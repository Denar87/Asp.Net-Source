<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeExperience.ascx.cs"
    Inherits="ERPSSL.HRM.UserControls.EmployeeExperience" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="row">
    <div class="col-md-12 bg-success">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div class="col-md-12">
        <fieldset>
            <legend></legend>
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Experience
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Company Name<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCompanyName" Class="form-control" runat="server"></asp:TextBox>

                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCompanyName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Company Name" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
               

                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Company Business<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCompanyBussiness" Class="form-control" runat="server"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompanyBussiness"Display=" Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Company Business" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
             

                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Company Location<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCompanyLocation" Class="form-control" runat="server"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyLocation" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Company Location" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
              

                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Working Department<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtWorkingDepartment" Class="form-control" runat="server"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWorkingDepartment" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Working Department" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Position Held<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtPositionHeld" Class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPositionHeld" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Position Held" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Experience Area<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtAreaOfExperience" Class="form-control" runat="server"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAreaOfExperience" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Experince Area" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Responsibilities
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtResponsibilities" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
               
                <div class="row">
                    <div class="col-md-12" style="padding-bottom: 5px;">
                        <div class="col-md-5">
                            Duration<%--<span style="color:#f00;">*</span>--%>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtDuration" Class="form-control" runat="server"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDuration" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Duration" ValidationGroup="GroupExprence"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <asp:HiddenField ID="ExperienceInfoID" runat="server" />
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnSaveExperienceInfo" runat="server" ValidationGroup="GroupExprence" Text="Save" class="btn btn-info  pull-right" OnClick="btnSaveExperienceInfo_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <br />
                    <br />
                    <asp:GridView ID="grdExpericencesInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                        BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblExpericenceId" runat="server" Text='<%# Eval("ExperienceId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEducation" runat="server" Text='<%# Bind("Experience_Company") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Business">
                                <ItemTemplate>
                                    <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Experience_CompanyBussiness") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Position Held">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Experience_PositionHeld") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Working Department">
                                <ItemTemplate>
                                    <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Experience_CompanyDepartment") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration">
                                <ItemTemplate>
                                    <asp:Label ID="lblResult" runat="server" Text='<%# Bind("Experience_Duration") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnexperienceDelete" runat="server" Text="Delete" class="btn btn-primary"
                                        OnClick="btnexperienceDelete_Click" />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <PagerSettings PageButtonCount="5" />
                        <RowStyle CssClass="Grid_RowStyle" />
                    </asp:GridView>
                </div>
            </div>
        </fieldset>

        <fieldset>
             <legend></legend>
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Skill
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom:5px">
                        <div class="col-md-5">
                            Specialization
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtSpecialization" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSpecialization" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Specialization" ValidationGroup="GroupSkill"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
               

                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Description
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtSkillDescription" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Extra-Curricular Activities
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtExtratActivities" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <asp:HiddenField ID="hdfSkill_ID" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnSaveSkill" runat="server" ValidationGroup="GroupSkill" Text="Save" class="btn btn-info  pull-right" OnClick="btnSaveSkill_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <br />
                    <br />
                    <asp:GridView ID="gradViewSkills" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                        BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSkillId" runat="server" Text='<%# Eval("SkillId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Specialization">
                                <ItemTemplate>
                                    <asp:Label ID="lblEducation" runat="server" Text='<%# Bind("Skill_Specialization") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extra-Curricular Activities">
                                <ItemTemplate>
                                    <asp:Label ID="lblMajor" runat="server" Text='<%# Bind("Skill_ExtraActivities") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Skill_Description") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnSkillceDelete" runat="server" Text="Delete" class="btn btn-primary"
                                        OnClick="btnSkillceDelete_Click" />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <PagerSettings PageButtonCount="5" />
                        <RowStyle CssClass="Grid_RowStyle" />
                    </asp:GridView>
                </div>
            </div>
        </fieldset>

        <fieldset>
             <legend></legend>
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Statment
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMgStament" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <br />
                <p class="bg-danger">Do You Have Any Relative Working in this Organization?</p>
            </div>

            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom:5px;">
                        <div class="col-md-5">
                            Name Of Relative
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxNameOfRelative" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSpecialization" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Specialization" ValidationGroup="GroupSkill"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
              

                <div class="row">
                    <div class="col-md-12" style="padding-bottom:5px;">
                        <div class="col-md-5">
                            Relation
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxRelation" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <br />
                <div class="row">
                    <div class="col-md-12" style="padding-bottom:5px;">
                        <div class="col-md-5">
                            E-ID Number
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxEidNumber" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
              

                <div class="row">
                    <div class="col-md-12" style="padding-bottom:5px;">
                        <div class="col-md-10">
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSaveStatment" runat="server" Text="Save" class="btn btn-info  pull-right" OnClick="btnSaveStatment_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</div>
