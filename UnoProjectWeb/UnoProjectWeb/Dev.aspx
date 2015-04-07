<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.master" CodeBehind="Dev.aspx.cs" Inherits="UnoProjectWeb.Dev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>

<body>
    <div id="opponent" style="width:100%; text-align:center; padding-top:4em; padding-bottom:10em">
             <asp:Button ID="Button2" UseSubmitBehavior="True" Text="" runat="server" ValidationGroup="Login" Width="90" Height="120" BackColor="Red" Font-Size="XX-Large" BorderStyle="Solid" Font-Bold="true" style="left:50%;background-image: url(Images/back.png);background-size:cover;"/> 
             <asp:Button ID="Button3" UseSubmitBehavior="True" Text="" runat="server" ValidationGroup="Login" Width="90" Height="120" BackColor="Yellow" Font-Size="XX-Large" BorderStyle="Solid" Font-Bold="true"  style="left:55%;background-image: url(Images/back.png);background-size:cover"/> 
        </div>

    <div id="middlecards" style="width:100%; text-align:center;">
             <asp:Button ID="Button4" UseSubmitBehavior="True" runat="server" ValidationGroup="Login" Width="90" Height="120" BackColor="Red" Font-Size="XX-Large" BorderStyle="Solid" Font-Bold="true" style="Position:absolute; left:400px; background-attachment: scroll;background-image: url(Images/back.png); background-size:cover"/> 
             <asp:Button ID="Button5" UseSubmitBehavior="True" Text="2" runat="server" ValidationGroup="Login" Width="90" Height="120" BackColor="Blue" Font-Size="XX-Large" BorderStyle="Solid" Font-Bold="true"  style="left:50% "/> 
        </div>

    <div id="cards" style="width:100%; text-align:center;padding-top:10em; padding-bottom:4em">
         <asp:Button ID="ButtonSignUp" UseSubmitBehavior="True" Text="2" runat="server" ValidationGroup="Login" Width="90" Height="120" BackColor="Red" Font-Size="XX-Large" BorderStyle="Solid" Font-Bold="true" style="left:50% "/> 
        <asp:Button ID="Button1" UseSubmitBehavior="True" Text="2" runat="server" ValidationGroup="Login" Width="90" Height="120" BackColor="Yellow" Font-Size="XX-Large" BorderStyle="Solid" Font-Bold="true"  style="left:55% "/> 
         </div> 

</body>
    
</html>
    </asp:Content>
