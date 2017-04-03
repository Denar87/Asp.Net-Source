<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShortAssetInfo.ascx.cs" Inherits="ERPSSL.FA.Control.ShortAssetInfo" %>
<fieldset>
        <asp:Label ID="lblAssetCode" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <div style="width: 95%">
            <hr />
        </div>
        <div style="background-color: #F1F0F0;">
            <div style="float: left; width: 35%;">
                <asp:Label ID="lblAsset" runat="server" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="lblGroup" runat="server" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblOffice" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblRegion" runat="server" Text=""></asp:Label><br />
            </div>
            <div style="float: left; width: 60%;">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="AccTax" runat="server" Text="As Per"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Tax" runat="server" Text="Accounting" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Tax" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="A/C Balance" />
                        </td>
                        <td>
                            <asp:Label ID="lblACClosingBalance" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblACClosingBalanceTax" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Acc. Dep. Balance" />
                        </td>
                        <td>
                            <asp:Label ID="lblADClosingBalance" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblADClosingBalanceTax" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Rev. Rsrv. Balance" />
                        </td>
                        <td>
                            <asp:Label ID="lblRRClosingBalance" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRRClosingBalanceTax" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Method" />
                        </td>
                        <td>
                            <asp:Label ID="lblMethod" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMethodTax" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="clear: both;">
            <div style="width: 95%">
                <hr />
            </div>
        </div>
        <asp:Label ID="lblStatus" runat="server" ForeColor="#CC3300"></asp:Label>
         <asp:Label ID="lblParentStatus" runat="server" Text=""></asp:Label>
    </fieldset>
                           

                        </div>
                        
                    </div>

                </fieldset>