<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZeroToProgrammer.Login" MasterPageFile="~/Site.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h1>Login</h1>

    <asp:label ID="lblUserName" runat="server" text="User Name:"></asp:label>
    <asp:TextBox ID="txtUserName" runat="server" Width="120px" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblPassword" runat="server" text="Password:"></asp:label>
    <asp:TextBox ID="txtPassword" runat="server" Width="120px" TextMode="Password" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>

    <br />
    <br />

    <p><asp:Label ID="lblWelcome" runat="server" Text="" Visible="False" ForeColor="#009933"></asp:Label></p>

</asp:Content>