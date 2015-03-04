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
		<td style="padding:4px 20px 4px 20px;"><asp:Label ID="LabelUserName" Text="User" />: </td>
		<td style="padding:4px 20px 4px 20px;"><asp:TextBox ID="TextBoxUserName" InputType="String" IsRequired="true" DisplayRequiredAsAsterix="true" TextBoxCssClass="AlignCenter" ValidationGroup="Login" ValidatorsPosition="Horizontal" AutoCompleteType="DisplayName" TextBoxMaxLength="20" /></td>
	</tr>
	<tr style="background-color:#f5f4ed;">
		<td style="padding:4px 20px 4px 20px;"><asp:Label ID="LabelPassword"  Value="Login_Password" />:</td>
		<td style="padding:4px 20px 4px 20px;"><asp:TextBox ID="TextBoxPassword" ValidatorDisplay="Static" InputType="Password" IsRequired="true" DisplayRequiredAsAsterix="true" TextBoxCssClass="AlignCenter" ValidationGroup="Login" ValidatorsPosition="Horizontal" TextBoxMaxLength="20" /></td>
	</tr>
	<tr style="background-color:#f5f4ed;text-align:center;">
		<td style="padding:4px 20px 4px 20px;">
		    <input type="reset" value="Reset" />
		</td>		
		<td style="padding:4px 20px 4px 20px;">	            
            <asp:Button ID="ButtonLogin" UseSubmitBehavior="true" />            
         </td>
	</tr>	
</table>
</asp:Content>
