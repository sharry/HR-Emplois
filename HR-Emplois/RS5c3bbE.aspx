<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="RS5c3bbE.aspx.cs" Inherits="HR_Emplois.RS5c3bbE" %>
<head  runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 85%;
            height: 99%;
        }
        .auto-style4 {
            height: 200px;
        }
        .btn {
            border-style: none;
            width: 15%;
            height: 70px;
            font-family: 'Century Gothic';
            color: #FFFFFF;
            font-size: medium;
            background-color: #007ACC;
            text-align: center;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0064AE;
        }
    </style>
    <script>
        function home() {
            window.location.href = "Home.aspx";
        }
        function login() {
            window.location.href = "CXR5eg8B.aspx";
        }
    </script>
</head>
<body>
    <table style="width:100%;">
        <tr>
            <td colspan="2" style="width: 40%; height: 100px;">&nbsp;</td>
            <td colspan="2" style="width: 20%; height: 100px">&nbsp;</td>
            <td colspan="2" style="width: 40%; height: 100px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center;">
                <br />
                <img alt="" class="auto-style3" src="Images/reset.png" style="border-style: none; border-width: 0px; width: 200px; height: 200px;" draggable="false" /></td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center; font-family: 'Century Gothic'; font-size: medium; color: #000000">Votre identifiant et mot de passe ont été réinitialisés<br />
                avec succès</td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="6" style="text-align: center; font-family: 'Century Gothic'; font-size: medium; color: #000000"></td>
        </tr>
        <tr>
            <td style="width: 35%; height: 70px">&nbsp;</td>
            <td class="btn" colspan="2" onclick="home()">Accueil</td>
            <td class="btn" colspan="2" onclick="login()">Se Connecter</td>
            <td style="width: 35%; height: 70px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center; font-family: 'Century Gothic'; font-size: medium; color: #000000; height: 100px;">&nbsp;</td>
        </tr>
    </table>
</body>
