<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CXR5eg8B.aspx.cs" Inherits="HR_Emplois.Admin.CXR5eg8B" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style2 {
            height: 830px;
        }
        .auto-style3 {
            table-layout: fixed ;
            width: 100%;
            height: 100%;
        }
        .auto-style6 {
            width: 25%;
            }
        .auto-style7 {
            width: 864px;
            height: 70px;
        }
        .auto-style10 {
            width: 864px;
            height: 553px;
        }
        .textBox {
            font: bold 20px Century Gothic;
            color: #007ACC;
            border-top: hidden;
            border-left: hidden;
            border-right: hidden;
            border-bottom: 2px solid #007ACC;
        }
        .icon-user {
            position: absolute;
            width: 20px;
            height: 20px;
            left: 537px;
            top: 582px;
        }
        .icon-pass {
            position: absolute;
            width: 20px;
            height: 20px;
        }
        .loginButton {
            color: white;
            background-color: #007ACC;
            font: bold 18px Century Gothic;
            border: hidden;
            cursor: pointer;
        }
        .loginButton:hover{
            background-color: #0064AE;
        }
        .auto-style13 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 100%;
            height: 548px;
            }
        .auto-style14 {
            height: 110px;
            width: 50%;
        }
        .auto-style17 {
            width: 50%;
            height: 46px;
        }
        .auto-style37 {
            width: 50%;
            height: 16px;
        }
        .auto-style38 {
            width: 50%;
            height: 8px;
        }
        .auto-style21 {
            width: 50%;
            height: 35px;
        }
        .auto-style19 {
            position: relative;
            width: 50%;
            height: 50px;
            text-align:center;
    }
        .auto-style23 {
            position: absolute;
            width: 20px;
            height: 20px;
            left: 603px;
            top: 651px;
        }
        .auto-style40 {
            width: 50%;
            height: 30px;
        }
        .auto-style39 {
            text-align:center;
            width: 50%;
            height: 34px;
        }
        .auto-style15 {
            width: 50%;
        }
        .auto-style41 {
            width: 50%;
        }
        .auto-style42 {
            width: 445px;
            height: 382px;
        margin-left: 5px;
    }
        .auto-style43 {
            width: 100px;
            height: 100px;
        }
        .auto-style44 {
            position: absolute;
            left: 1px;
            top: 20px;
            width: 24px;
        }
        </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>

        <table class="auto-style3">
            <tr>
                <td class="auto-style6" rowspan="3"></td>
                <td class="auto-style7"></td>
                <td rowspan="3" class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <table class="auto-style13" style="border: 2px solid #007ACC;">
                        <tr>
                            <td class="auto-style14" style="text-align:center">&nbsp;&nbsp;
                                <img alt="" class="auto-style43" draggable="false" src="Images/logo.jpg" /></td>
                            <td class="auto-style15" style="text-align:center; background-color:#F4F4F4;" rowspan="10">
                                <img alt="" class="auto-style42" src="Images/loginArt.png" draggable="false" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style17"></td>
                        </tr>
                        <tr>
                            <td class="auto-style37" style="font:bold 24px Century Gothic; color:#282828">&nbsp;&nbsp;&nbsp;&nbsp;Se Connecter</td>
                        </tr>
                        <tr>
                            <td class="auto-style38" style="font:bold 12px Century Gothic; color:#444444">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Connectez-vous pour accéder au tableau de bord</td>
                        </tr>
                        <tr>
                            <td class="auto-style21"></td>
                        </tr>
                        <tr>
                            <td class="auto-style19">
                                <img alt="u" src="Images/user.png" style="align-self:flex-end; position:absolute; left: 83%; top: 30%;" draggable="false"/>
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="textBox" Height="30px" Width="83%" Font-Names="Century Gothic" Font-Size="Large" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin" ErrorMessage="*" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="textBox" Height="30px" Width="83%" Font-Size="Large" MaxLength="25" TextMode="Password"></asp:TextBox>
                                <img alt="p" src="Images/lock.png" style="align-self:flex-end; position:absolute; left: 83%; top: 30%;" draggable="false" />
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style40">

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style39">
                                <asp:Button ID="btnLogin" runat="server" CssClass="loginButton" Height="45px" Text="Se Connecter" Width="85%" OnClick="btnLogin_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style41" style="text-align: center">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Century Gothic" ForeColor="Red" Text="Identifiant/mot de passe incorrecte, réessayez!" Visible="False"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
            </tr>
        </table>

    </div>
</asp:Content>
