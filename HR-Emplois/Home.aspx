<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HR_Emplois.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Accueil</title>
    <style type="text/css">
        .auto-style3 {
            width: 327px;
        }
        .auto-style4 {
            width: 147px;
        }
        .auto-style13 {
            width: 100px;
            height: 50px;
        }
        .auto-style14 {
            width: 235px;
            height: 50px;
            cursor: default;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .auto-style15 {
            height: 26px;
        }
        .radioSubGroups {
            margin: 10px;
            cursor: default;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .seance-cell {
            cursor:default;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .ddl-home {
            font-family: 'Century Gothic';
            border-radius: 0px;
        }
        </style>
    <script type="text/javascript" src="js/jquery-3.1.1.js"></script>
    <script type="text/javascript" src="js/select2.js"></script>
    <link href="css/select2.css" rel="stylesheet" />
    
    <script>
        function singleSelection(rad) {
            var radio = document.getElementById(rad);
            var radls = document.getElementsByTagName("input");
            for (i = 0; i < radls.length; i++){
                if (radls[i].type == "radio" && radls[i].id !== radio.id) {
                    radls[i].checked = false;
                }
            }
        }
    </script>
    <script src="Select/jquery.min.js"></script>
    <script src="Select/select2.min.js" integrity="sha512-2ImtlRlf2VVmiGZsjm9bEyhjGW4dU7B6TNwh/hx/iSByxNENtj3WVE6o/9Lj4TJeVXPi4bnOIMXFIJJAeufa0A==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="Select/select2.min.css" integrity="sha512-nMNlpuaDPrqlEls3IX/Q56H36qvBASwb3ipuo3MxeWbsQB1881ox0cRv7UPTgBlriqoynt35KjEwgGUeUXIPnw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script>
        $(document).ready(function () {
            $(".ddl-home").select2({

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblFiliere" runat="server" Font-Names="Century Gothic" Text="Sélectionnez votre groupe:" Font-Bold="True" ForeColor="#2D2D30" CssClass="label"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlFiliere" runat="server" AutoPostBack="True" DataTextField="initiales" DataValueField="id" CssClass="ddl-home" OnSelectedIndexChanged="ddlFiliere_SelectedIndexChanged" Font-Names="Century Gothic">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqlFiliere" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT [id], [initiales] FROM [Filiere] ORDER BY [initiales]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:DropDownList ID="ddlGroupe" runat="server" AutoPostBack="True" DataTextField="numero" DataValueField="id" CssClass="ddl-home" OnSelectedIndexChanged="ddlGroupe_SelectedIndexChanged" Font-Names="Century Gothic"></asp:DropDownList>
                <asp:SqlDataSource ID="sqlGroupe" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT * FROM [Groupe] WHERE ([filiere] = @filiere) ORDER BY [numero]">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlFiliere" Name="filiere" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="background-color:#3F3F3F; height:45px; text-align:right;">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center" class="auto-style15">
                <asp:RadioButton autopostback=true ID="radSubGroupA" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="#2D2D30" Text="Sous-groupe (a)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupA_CheckedChanged" />
                <asp:RadioButton autopostback=true ID="radSubGroupB" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="#2D2D30" Text="Sous-groupe (b)" GroupName="radioSubGroups" OnCheckedChanged="radSubGroupB_CheckedChanged" Visible="False" />
                <asp:RadioButton autopostback=true ID="radSubGroupC" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="#2D2D30" Text="Sous-groupe (c)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupC_CheckedChanged" />
                <asp:RadioButton autopostback=true ID="radSubGroupD" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="#2D2D30" Text="Sous-groupe (d)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupD_CheckedChanged" />
                <asp:RadioButton autopostback=true ID="radSubGroupE" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="#2D2D30" Text="Sous-groupe (e)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupE_CheckedChanged" />
                <asp:RadioButton autopostback=true ID="radSubGroupF" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="#2D2D30" Text="Sous-groupe (f)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupF_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="3">

                <table style="width:100%;">
                    <tr>
                        <td style="background-color:#007ACC; font:14px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none; width: 100px;">Présentiel</td>
                        <td style="background-color:#68217A; font:14px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none; width: 100px;">Distanciel</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" aria-readonly="True" class="auto-style14">08:30 - 11:00</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" aria-readonly="True" class="auto-style14">11:00 - 13:30</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" aria-readonly="True" class="auto-style14">13:30 - 16:00</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" aria-readonly="True" class="auto-style14">16:00 - 18:30</td>
                    </tr>
                    <tr>
                       <td colspan="2" style="height: 100px; width: 200px !important; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;" id="lun" runat="server">Lundi</td>
                        <td id="lun1" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="lun2" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="lun3" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="lun4" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                    </tr>
                    <tr>
                       <td colspan="2" style="height: 100px; width: 200px; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;" id="mar" runat="server">Mardi</td>
                        <td id="mar1" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="mar2" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="mar3" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="mar4" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                    </tr>
                    <tr>
                       <td colspan="2" style="height: 100px; width: 200px; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;" id="mer" runat="server">Mercredi</td>
                        <td id="mer1" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="mer2" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="mer3" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="mer4" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                    </tr>
                    <tr>
                       <td colspan="2" style="height: 100px; width: 200px; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;" id="jeu" runat="server">Jeudi</td>
                        <td id="jeu1" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="jeu2" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="jeu3" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="jeu4" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                    </tr>
                    <tr>
                       <td colspan="2" style="height: 100px; width: 200px; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;" id="ven" runat="server">Vendredi</td>
                        <td id="ven1" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="ven2" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="ven3" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="ven4" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                    </tr>
                    <tr>
                       <td colspan="2" style="height: 100px; width: 200px; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;" id="sam" runat="server">Samedi</td>
                        <td id="sam1" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="sam2" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="sam3" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                        <td id="sam4" runat="server" style="background-color:#2D2D30; font:14px Century Gothic; color:white; text-align:center" class="seance-cell"></td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
</asp:Content>
