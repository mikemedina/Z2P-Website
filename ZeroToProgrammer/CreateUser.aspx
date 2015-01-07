<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="ZeroToProgrammer.CreateUser" MasterPageFile="~/Site.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h1>Create User</h1>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>

    <br />
    <br />

    <asp:label ID="lblUserName" runat="server" text="User Name*:"></asp:label>
    <asp:TextBox ID="txtUserName" runat="server" Width="120px" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblPassword" runat="server" text="Password*:"></asp:label>
    <asp:TextBox ID="txtPassword" runat="server" Width="120px" TextMode="Password" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblConfirmPassword" runat="server" text="Confirm Password*:"></asp:label>
    <asp:TextBox ID="txtConfirmPassword" runat="server" Width="120px" TextMode="Password" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblEmail" runat="server" text="Email*:"></asp:label>
    <asp:TextBox ID="txtEmail" runat="server" Width="150px" MaxLength="28"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblFirstName" runat="server" text="First Name:"></asp:label>
    <asp:TextBox ID="txtFirstName" runat="server" Width="120px" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblLastName" runat="server" text="Last Name:"></asp:label>
    <asp:TextBox ID="txtLastName" runat="server" Width="120px" MaxLength="15"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblAge" runat="server" text="Age:"></asp:label>
    <asp:TextBox ID="txtAge" runat="server" Width="30px" MaxLength="3"></asp:TextBox>

    <br />
    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>

    <br />
    <br />

    <p style="font-size: 12px;"><asp:label ID="lblRequired" runat="server" text="Fields marked with * are required"></asp:label></p>
    <p><asp:Label ID="lblSuccess" runat="server" Text="Login Created Successfully" Visible="False" ForeColor="#009933"></asp:Label></p>

</asp:Content>