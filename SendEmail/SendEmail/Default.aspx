<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SendEmail._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID ="SubjectLabel" runat="server" Text ="Subject" />
    <asp:TextBox id="SubjectBox" runat="server" />
<br /><br />
    <asp:Label ID ="ContentLabel" runat="server" Text ="Content" />
    <asp:TextBox id="ContentBox" runat="server" />
<br /><br />
    <asp:Label ID ="RecipientLabel" runat="server" Text ="Recipient" />
    <asp:TextBox id="RecipientBox" runat="server" />
<br /><br />
    <asp:Button id="SendEmail"
           Text="Send Mail"
           OnClick="SendEmail_Click" 
           runat="server"/>
</asp:Content>
