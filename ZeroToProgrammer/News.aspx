<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="ZeroToProgrammer.News"  MasterPageFile="~/Site.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h1>News</h1>

    <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Panel ID="pnlNews" runat="server"></asp:Panel>

</asp:Content>