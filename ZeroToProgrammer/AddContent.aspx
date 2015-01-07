<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="ZeroToProgrammer.AddContent" MasterPageFile="~/Site.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h1>Add New Content</h1>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>

    <br />
    <br />

    <asp:label ID="lblTitle" runat="server" text="Title"></asp:label>
    <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox>

    <br />
    <br />

    <asp:label ID="lblContent" runat="server" text="Content"></asp:label>
    <asp:TextBox ID="txtContent" runat="server" Width="500px" Height="150px" TextMode="MultiLine"></asp:TextBox>

    <br />
    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

    <br />
    <br />

    <asp:Label ID="lblSuccess" runat="server" Text="Submission Successful" Visible="False" ForeColor="#009933"></asp:Label>

</asp:Content>