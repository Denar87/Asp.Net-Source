<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignToEdit.ascx.cs" Inherits="ERPSSL.HRM.UserControls.AssignToEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">
 <ContentTemplate>
     <div>
        <div class="tab-header">
            Assign To
    <asp:Button ID="btnTrt" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnTrt_Click" />
        </div>
        <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">
           

   


            <asp:Label ID="lblAssignTo" runat="server" Font-Bold="true"></asp:Label>
        <link href="../../css/Modal.css" rel="stylesheet" />
            <div class="modal-dialog">
                <div class="popuHeader">
                    <asp:LinkButton ID="CancelButton"  runat="server" >
                                   <button type="button" style="color:white"  class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </asp:LinkButton>
                    <h4 id="myModalLabel" >Assign To</h4>
                </div>
                <div id="Div2">

                    <div class="col-md-12" style="padding-top:7px">
                        <div class="row">
                            <div class="col-md-12 bg-success">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </div>

                            <div class="col-md-12">
                                <span class="label label-danger">Reporting-1</span>
                            </div>
                            <fieldset>

                                <div class="col-md-6">


                                    <div class="row">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpFirstReportingDepartment" AutoPostBack="true" OnSelectedIndexChanged="drpFirstReportingDepartment_SelecttedIndexChanged" runat="server" Class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">

                                        <div class="col-md-5">
                                            E-ID
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtbxAssignToId" AutoPostBack="True" OnTextChanged="txtbxAssignToId_TextChanged"
                                                Class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>

                                    <br />

                                </div>
                                <div class="col-md-6">

                                    <div class="row">
                                        <div class="col-md-5">
                                            Assign
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlReportingTo" OnSelectedIndexChanged="ddlReportingTo_SelecttedIndexChanged"
                                                Class="form-control" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ValidationGroup="Group3"
                                                runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-md-5">
                                            Designation
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRptBossDsg" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                        </div>



                                    </div>
                                </div>
                            </fieldset>
                            <br />
                            <div class="col-md-12">
                                <span class="label label-danger">Reporting-2</span>
                            </div>
                            <fieldset>

                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="row">


                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Department
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList runat="server" ID="drpwownSecondDepartmetn" OnSelectedIndexChanged="drpwownSecondDepartmetn_SelecttedIndexChanged" AutoPostBack="true" Class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-12">
                                                <br />
                                                <div class="col-md-5">
                                                    E-ID
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtbxSecondEdit" AutoPostBack="True" OnTextChanged="txtbxSecondEdit_TextChanged"
                                                        Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                        <br />

                                    </div>
                                </div>
                                <div class="col-md-6">

                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Assign
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpSecondReportingTo"
                                                Class="form-control" runat="server" OnSelectedIndexChanged="drpSecondReportingTo_SelecttedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ValidationGroup="Group3"
                                                runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Designation
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtbxSecondDesignation" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <br />



                                </div>
                            </fieldset>

                            <br />
                            <div class="col-md-12">
                                <span class="label label-danger">Reporting-3</span>
                            </div>

                            <fieldset>
                                <div class="col-md-6">

                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpdwnThridDepartment" OnSelectedIndexChanged="drpdwnThridDepartment_SelecttedIndexChanged" AutoPostBack="true" runat="server" Class="form-control"></asp:DropDownList>
                                        </div>

                                    </div>


                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-5">
                                            E-ID
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtbxThirdEditPerson" AutoPostBack="True" OnTextChanged="txtbxThirdEditPerson_TextChanged"
                                                Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>




                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Assign
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="drpdwnThirdReportingBoss" OnSelectedIndexChanged="drpdwnThirdReportingBoss_SelecttedIndexChanged"
                                                    Class="form-control" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ValidationGroup="Group3"
                                                    runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Designation
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtbxThirdDesignation" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>

                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="submission">
                    <%--<asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info  pull-right" />--%>
                    <asp:Button ID="btnAssignTo" runat="server"
                        Text="Submit" Width="80px" CssClass="btn btn-info  pull-right" OnClick="btnAssignTo_Click" />
                </div>
            </div>         
        </asp:Panel>
        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
        <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
            DropShadow="True" PopupDragHandleControlID="Panel3" Enabled="True" />

        <div id="Div1">
            <div class="row tab-data">
                <div class="container-fluid tab-container">
                    <div class="col-md-4 col-xs-4">
                        <h4>First Person:
                        </h4>
                    </div>
                    <div class="col-md-8 col-xs-8 table-content">
                        <p>
                            <asp:Label ID="lblFirstPerson" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="container-fluid tab-container">
                    <div class="col-md-4 col-xs-4">
                        <h4>Second Person:
                        </h4>
                    </div>
                    <div class="col-md-8 col-xs-8 table-content">
                        <p>
                            <asp:Label ID="lblSecend" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="container-fluid tab-container">
                    <div class="col-md-4 col-xs-4">
                        <h4>Third Person:
                        </h4>
                    </div>
                    <div class="col-md-8 col-xs-8 table-content">
                        <p>
                            <asp:Label ID="lblThridPerson" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
         </div>
           </ContentTemplate>
         </asp:UpdatePanel>
   