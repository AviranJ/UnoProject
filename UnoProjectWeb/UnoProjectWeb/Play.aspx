<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.master" CodeBehind="Play.aspx.cs" Inherits="UnoProjectWeb.Play" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <script type="text/javascript" src="JS.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title> 
</head>
<body>
    <asp:Label Text="." ID="label1" runat="server" style="width:100%; text-align:center; font-size:xx-large ; color:red"/>
    <div id="opponent" style="width:100%; text-align:center; padding-top:4em; padding-bottom:10em">
        
        </div>

    <div id="middlecards" style="width:100%; text-align:center;">
            <asp:Label Text="Please wait for another player to join" ID="labelWelcome" runat="server" style="width:100%; text-align:center; font-size:xx-large ; color:red"/>
        </div>

    <div id="cards" style="width:100%; text-align:center;padding-top:10em; padding-bottom:4em">
         </div> 
</body>
</html>
   </asp:Content>

