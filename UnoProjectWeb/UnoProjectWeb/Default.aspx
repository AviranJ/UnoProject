<%@ Page Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UnoProjectWeb._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" style="margin:50px 50px 50px 500px;border-collapse:collapse;" align="center">
	<tr>
		<td colspan="2" align="center" style="background-image: url(Images/PanelHeaderBG.gif);color:white;font-weight:bold;white-space:nowrap;padding:5px"><asp:Label ID="LabelLoginHeader" runat="server" Text="Login" /></td>
	</tr>
	<tr>
		<td colspan="2" style="height:20px;line-height:1px;font-size:1px;background-color: #f5f4ed;">&nbsp;</td>
	</tr>
	<tr style="background-color:#f5f4ed;">
		<td style="padding:4px 20px 4px 20px;"><asp:Label ID="LabelUserName" Text="User" runat="server" />: </td>
		<td style="padding:4px 20px 4px 20px;"><asp:TextBox ID="TextBoxUserName" runat="server" ValidationGroup="Login" />
		    <asp:requiredfieldvalidator id="RequiredFieldValidator1" controltovalidate="TextBoxUserName" validationgroup="Login" errormessage="Field is empty" runat="Server"></asp:requiredfieldvalidator></td>
	</tr>
	<tr style="background-color:#f5f4ed;">
		<td style="padding:4px 20px 4px 20px;"><asp:Label ID="LabelPassword"  Text="Password" runat="server"/>:</td>
		<td style="padding:4px 20px 4px 20px;"><asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" ValidationGroup="Login" />
			<asp:requiredfieldvalidator id="RequiredFieldValidator2" controltovalidate="TextBoxPassword" validationgroup="Login" errormessage="Field is empty" runat="Server"></asp:requiredfieldvalidator></td>
	</tr>
	<tr style="background-color:#f5f4ed;text-align:center;">
		<td style="padding:4px 20px 4px 20px;">
		    <asp:Button ID="ButtonSignUp" UseSubmitBehavior="true" Text="Sign up" runat="server" ValidationGroup="Login"/> 
		    <asp:CustomValidator ID="CustomValidatorButtonSignUp" OnServerValidate="CustomValidatorButtonSignUp" />
		</td>		
		<td style="padding:4px 20px 4px 20px;">	            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>
            <asp:Button ID="ButtonLogin" UseSubmitBehavior="true" Text="Login" runat="server" ValidationGroup="Login" />            
         </td>
	</tr>	
</table>
</asp:Content>
