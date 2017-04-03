<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Supplier_Documents.ascx.cs" Inherits="ERPSSL.INV.UserControl.Supplier_Documents" %>

<div class="col-md-12">
    <asp:Label ID="lblDocmsg" runat="server" Text=""></asp:Label>
    <div class="col-md-6">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                    Description
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtDescription" Class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                    Remarks
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtRemarks" Class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                    File upload
                </div>
                <div class="col-md-8">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                       
                </div>
                <div class="col-md-8">
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btn_Submit_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
