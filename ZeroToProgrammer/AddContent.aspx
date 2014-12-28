<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="ZeroToProgrammer.AddContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmNewContent" runat="server">
        <h1>Add New Content</h1>
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:label ID="lblTitle" runat="server" text="Title"></asp:label></td>
            <td><asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: right"><asp:label ID="lblContent" runat="server" text="Content"></asp:label></td>
            <td><asp:TextBox ID="txtContent" runat="server" Width="500px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblSuccess" runat="server" Text="Submission Successful" Visible="False" ForeColor="#009933"></asp:Label></td>
        </tr>
    </table>

    </form>
</body>
</html>

