<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.master" CodeBehind="Play.aspx.cs" Inherits="UnoProjectWeb.Play" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <script type="text/javascript" src="JS.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title> 
</head>
<body>

    <asp:HiddenField ID="User" runat="server" />
    <asp:Label Text="" ID="label1" runat="server" style="width:100%; text-align:center; font-size:xx-large ; color:red"/>
    <asp:Button ID="ButtonHistory" Text="Show History" runat="server" style="text-align:center; left:50%; font-size:xx-large; position:absolute" OnClientClick="GetHistory();return false;"/> 
    <asp:Button ID="ButtonScoreboard" Text="Show Scoreboard" runat="server" style="text-align:center; left:35%; font-size:xx-large; position:absolute" OnClientClick="GetScoreboard();return false;"/> 
    <div id="Board" style="width:80%;height:100%;float:right;" >
        <asp:Table runat="server" ID="TableMoveHistory" style="text-align:center; position:absolute; font-size:xx-large;top:10%;z-index:5; background-color:#fff; "/>
        <asp:Table runat="server" ID="TableScoreboard" style="text-align:center; position:absolute; font-size:xx-large;top:10%;left:33%;z-index:7; background-color:#bbd9ee"/>
        </div>
    
    <div id="opponent" style="width:100%; text-align:center; padding-top:4em; padding-bottom:10em">
        </div>
    <asp:Label Text="Please wait for another player to join" ID="labelWelcome" runat="server" style="width:100%; text-align:center; font-size:xx-large ; color:red"/>
    <div id="middlecards" style="width:100%; text-align:center;">
            
        </div>

    <div id="cards" style="width:100%; text-align:center;padding-top:10em; padding-bottom:4em">
         </div> 
</body>
</html>
   </asp:Content>

