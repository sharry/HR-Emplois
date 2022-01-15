<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="DcQ24Dsk.aspx.cs" Inherits="HR_Emplois.Admin.DcQ24Dsk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel=”stylesheet” href="../Chosen/docsupport/style.css">
    <link rel=”stylesheet” href="../Chosen/docsupport/prism.css">
    <link rel=”stylesheet” href="../Chosen/chosen.css">
    <style type="text/css">
        .logout {
            background-color: #E81123;
            cursor: pointer;
        }
        .logout:hover {
            background-color: #b00e1c;
        }
        .exit {
            background-color: #2D2D30;
        }
        .exit:hover {
            background-color: #E81123;
        }
        .clear-seances {
            background-color: #CA5100;
            cursor: pointer;
        }
        .clear-seances:hover {
            background-color: #B44D07;
        }
        .btn {
            background-color: #007ACC;
            cursor: pointer;
            width: 100%;
            height: 100%;
        }
        .btn:hover {
            background-color: #0064AE;
        }
        .btn-sg {
            background-color: #007ACC;
        }
        .btn-sg:hover {
            background-color: #0064AE;
        }
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            width: 120px;
            height: 120px;
        }
        .auto-style3 {
            width: 70px;
            height: 33px;
            margin: 10px 10px 10px 10px;
        }
        .home {
            background-color: #007acc;
            font: bold 16px Century Gothic;
            color: white;
            text-align: center;
            width: 10%; 
            height: 100%;
            cursor: pointer;
        }
        .home:hover {
            background-color:#0064AE;
        }
        .add-seance {
            position: absolute;
            top: 0;
            left: 0;
            background-color: #007acc;
            opacity: 0;
            transition: 0.3s;
        }
        .add-seance:hover {
            position: absolute;
            top: 0;
            left: 0;
            background-color: #007acc;
            opacity: 0.9;
            cursor: pointer;
        }
        .delete-seance {
            position: absolute;
            top: 0;
            left: 0;
            background-color: #E81123;
            opacity: 0;
            transition: 0.3s;
        }
        .delete-seance:hover {
            position: absolute;
            top: 0;
            left: 0;
            background-color: #b00e1c;
            opacity: 0.9;
            cursor: pointer;
        }
        .edit-seance {
            position: absolute;
            top: 0;
            right: 0;
            background-color: #CA5100;
            opacity: 0;
            transition: 0.3s;
        }
        .edit-seance:hover {
            position: absolute;
            top: 0;
            right: 0;
            background-color: #B44D07;
            opacity: 0.9;
            cursor: pointer;
        }
        
        .div-seances{
            width: 100%; 
            height:100px; 
            font:14px Century Gothic; 
            color:white; 
            text-align:center; 
            display: flex;
            justify-content: center; 
            align-items: center;
        }
        
        .auto-style4 {
            width: 500px;
            height: 40px;
            background-color:#2D2D30;
        }
        
        
        .cancel {
        background-color: #2D2D30;
    }
            
        
        .auto-style5 {
            width: 40%;
            height: 32px;
        }
        .auto-style6 {
            height: 32px;
        }
            
        .cancel:hover {
            background-color: #007ACC;
        }

        .modalBackground {
            background-color: black;
            opacity: 0.6;
        }
        
        .auto-style7 {
            height: 53px;
        }
        .radiodispre {
            
            padding-left: 50px;
        }

        .ddl-width {
            width: 200px;
            max-width: 200px;
        }
        .header-text {
            cursor: default;
        }
        
        .auto-style14 {
            height: 93px;
        }
        .auto-style16 {
            height: 38px;
        }
        .auto-style17 {
            height: 50px;
        }
        .auto-style18 {
            height: 159px;
        }
        
        .auto-style19 {
            height: 20px;
        }
        
        .dropdownlist {
            width: 80% !important;
        }

                
        .auto-style20 {
            height: 32px;
            width: 28%;
        }

        .ddl-salle {
            width: 100% !important;
        }

                
        .auto-style21 {
            width: 40%;
        }

                
        .auto-style22 {
            height: 1px;
        }

                
        .auto-style23 {
            width: 515px;
            height: 216px;
        }
        .auto-style24 {
            height: 162px;
        }

        .label1 {
            margin-right: 40px;
        }
                
        .auto-style25 {
            height: 30px;
            cursor: default;
        }
                
        .auto-style26 {
            font-weight: bold;
            font-size: 100px;
        }

        .first-year-button {
            background-color: #9C460E;
            opacity: 0;
            cursor: pointer;
            border-radius: 100%;
        }
        .first-year-button:hover {
            opacity: 1;
        }
        .second-year-button {
            background-color: #542561;
            opacity: 0;
            cursor: pointer;
            border-radius: 100%;
        }
        .second-year-button:hover {
            opacity: 1;
        }
        .count-label {
            cursor: default;
        }
        .add-module {
            background-color: #007acc;
            cursor: pointer;
        }
        .add-module:hover{
            background-color: #0064AE;
        }

        .ddl-civilite {
            width: 92.8% !important;
        }
        #btn1 {
            background: url('../Image/planning.png') no-repeat;
        }
        .auto-style27 {
            width: 30%;
            height: 31px;
        }
        .credentials {
            margin-right: 20px;
        }
        </style>
    
    <script src="../Select/jquery.min.js"></script>
    <script src="../Select/select2.min.js" integrity="sha512-2ImtlRlf2VVmiGZsjm9bEyhjGW4dU7B6TNwh/hx/iSByxNENtj3WVE6o/9Lj4TJeVXPi4bnOIMXFIJJAeufa0A==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="../Select/select2.min.css" integrity="sha512-nMNlpuaDPrqlEls3IX/Q56H36qvBASwb3ipuo3MxeWbsQB1881ox0cRv7UPTgBlriqoynt35KjEwgGUeUXIPnw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script>
        $(document).ready(function () {
            $(".dropdownlist2").select2({
                
            });
            $(".ddl-other").select2({ width: '90%' });
            $(".ddl-else").select2({ width: '40%' });
        });
        
    </script>
    <script>
        function home_click() {
            window.location.href = "../Home.aspx";
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%; border-collapse:collapse;">
            <tr>
                <td style="width: 180px; height: 10%; background-color: #007acc; text-align: center; color: white; font-family: 'Bahnschrift Condensed'; font-size: 20px;">

                        <img runat="server" style="vertical-align:middle" src="../Images/ista.png" class="auto-style3" draggable="false" /></td>
                <td style="margin: 0px; background-color: #202020; font-family: 'Bahnschrift Condensed'; font-size: 20px; font-weight: bold; color: #FFFFFF; text-align: center; cursor: default; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;">

                    ISTA HAY RIAD 
                    - Gestion des emplois du temps</td>
                <td class="home" onclick="home_click()" style="cursor: pointer; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;">Accueil</td>
            </tr>
            <tr>
            <td style="width: 180px; height: 90px; background-color: #007ACC; text-align:center">
                <asp:Button ID="btn1" runat="server" Text="Gestion de emplois"  BorderStyle="None" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" OnClick="btn1_Click" Width="100%" CssClass="btn" />

            <td rowspan="6" colspan="2" style="background-color: #313131;">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width:100%; margin-top:20px;">
                            
                            <tr>
                                <td style="width: 30%; text-align:center;">
                                <asp:Label ID="lblFiliere" runat="server" Font-Names="Century Gothic" Text="Sélectionnez un groupe:" Font-Bold="True" ForeColor="White"></asp:Label>
                                </td>
                                <td style="width: 15%">
                                    <asp:DropDownList ID="ddlFiliere" runat="server" AutoPostBack="True" DataTextField="initiales" DataValueField="id" CssClass="dropdownlist2" OnSelectedIndexChanged="ddlFiliere_SelectedIndexChanged" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlFiliere" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT [id], [initiales] FROM [Filiere] ORDER BY [initiales]"></asp:SqlDataSource>
                                </td>
                                <td style="width: 15%">
                                    <asp:DropDownList ID="ddlGroupe" runat="server" AutoPostBack="True" DataTextField="numero" DataValueField="id" CssClass="dropdownlist2" OnSelectedIndexChanged="ddlGroupe_SelectedIndexChanged" Width="100px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlGroupe" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT * FROM [Groupe] WHERE ([filiere] = @filiere) ORDER BY [numero]">
                                    <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlFiliere" Name="filiere" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td style="width: 30%">
                                    &nbsp;</td>
                            </tr>
                            
                            <tr>
                                <td colspan="4">&nbsp;
                                    <table style="width:100%">
                                        <tr style="height: 100%">
                                <td colspan="2" style="text-align:center; width: 80%">
                                    <asp:RadioButton autopostback=true ID="radSubGroupA" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="White" Text="Sous-groupe (a)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupA_CheckedChanged" />
                                    <asp:RadioButton autopostback=true ID="radSubGroupB" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="White" Text="Sous-groupe (b)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupB_CheckedChanged"  />
                                    <asp:RadioButton autopostback=true ID="radSubGroupC" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="White" Text="Sous-groupe (c)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupC_CheckedChanged" />
                                    <asp:RadioButton autopostback=true ID="radSubGroupD" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="White" Text="Sous-groupe (d)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupD_CheckedChanged" />
                                    <asp:RadioButton autopostback=true ID="radSubGroupE" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="White" Text="Sous-groupe (e)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupE_CheckedChanged" />
                                    <asp:RadioButton autopostback=true ID="radSubGroupF" runat="server" CssClass="radioSubGroups" Font-Bold="True" Font-Names="Century Gothic" ForeColor="White" Text="Sous-groupe (f)" GroupName="radioSubGroups" Visible="False" OnCheckedChanged="radSubGroupF_CheckedChanged" />
                                </td>
                                <td colspan="2" style="text-align:center; width: 20%">
                                    <asp:Button ID="btnAddSubGroup" runat="server" CssClass="btn" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" Text="Ajouter un sous-groupe" Width="204px" BorderStyle="None" OnClick="btnAddSubGroup_Click" Visible="False" />
                                </td>
                            </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table style="width:100%;">
                    <tr>
                        <td style="background-color:#2D2D30; height:50px; font:14px Century Gothic; color:white; text-align:center">
                            <asp:Button ID="btnClear" runat="server" BorderStyle="None" CssClass="clear-seances" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" OnClick="btnClear_Click" Text="Vider tout" Width="100%" Visible="False" />
                        </td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; height:50px; width: 20%; text-align:center; cursor: default;" aria-readonly="True" class="auto-style14">08:30 - 11:00</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; height:50px; width: 20%; text-align:center; cursor: default;" aria-readonly="True" class="auto-style14">11:00 - 13:30</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; height:50px; width: 20%; text-align:center; cursor: default;" aria-readonly="True" class="auto-style14">13:30 - 16:00</td>
                        <td style="background-color:#2D2D30; font:14px Century Gothic; color:white; height:50px; width: 20%; text-align:center; cursor: default;" aria-readonly="True" class="auto-style14">16:00 - 18:30</td>
                    </tr>
                    <tr>
                       <td style="height: 100px; width: 20%; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default;">Lundi</td>
                        <td id="lun1" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divlun1" runat="server" class="div-seances">
                            </div>
                            <asp:Button ID="lun1Add" runat="server" BorderStyle="None" CssClass="add-seance" Height="102px" Width="100%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="+" Visible="False" OnClick="lun1_Click" />
                            <asp:Button ID="lun1Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="lun1_Click" />
                            <asp:Button ID="lun1Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="lun1_Click" />
                        </td>
                        <td id="lun2" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divlun2" runat="server" class="div-seances"></div>
                            <asp:Button ID="lun2Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="lun2_Click" />
                            <asp:Button ID="lun2Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="lun2_Click" />
                            <asp:Button ID="lun2Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="lun2_Click" />
                        </td>
                        <td id="lun3" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divlun3" runat="server" class="div-seances"></div>
                            <asp:Button ID="lun3Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="lun3_Click" />
                            <asp:Button ID="lun3Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="lun3_Click" />
                            <asp:Button ID="lun3Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="lun3_Click" />
                        </td>
                        <td id="lun4" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divlun4" runat="server" class="div-seances"></div>
                            <asp:Button ID="lun4Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="lun4_Click" />
                            <asp:Button ID="lun4Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="lun4_Click" />
                            <asp:Button ID="lun4Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="lun4_Click" />
                        </td>
                    </tr>
                    <tr>
                       <td style="height: 100px; width: 20%; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default;">Mardi</td>
                        <td id="mar1" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmar1" runat="server" class="div-seances"></div>
                            <asp:Button ID="mar1Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mar1_Click" />
                            <asp:Button ID="mar1Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mar1_Click" />
                            <asp:Button ID="mar1Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mar1_Click" />
                        </td>
                        <td id="mar2" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmar2" runat="server" class="div-seances"></div>
                            <asp:Button ID="mar2Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mar2_Click" />
                            <asp:Button ID="mar2Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mar2_Click" />
                            <asp:Button ID="mar2Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mar2_Click" />
                        </td>
                        <td id="mar3" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmar3" runat="server" class="div-seances"></div>
                            <asp:Button ID="mar3Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mar3_Click" />
                            <asp:Button ID="mar3Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mar3_Click" />
                            <asp:Button ID="mar3Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mar3_Click" />
                        </td>
                        <td id="mar4" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmar4" runat="server" class="div-seances"></div>
                            <asp:Button ID="mar4Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mar4_Click" />
                            <asp:Button ID="mar4Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mar4_Click" />
                            <asp:Button ID="mar4Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mar4_Click" />
                        </td>
                    </tr>
                    <tr>
                       <td style="height: 100px; width: 20%; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default;">Mercredi</td>
                        <td id="mer1" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmer1" runat="server" class="div-seances"></div>
                            <asp:Button ID="mer1Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mer1_Click" />
                            <asp:Button ID="mer1Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mer1_Click" />
                            <asp:Button ID="mer1Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mer1_Click" />
                        </td>
                        <td id="mer2" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmer2" runat="server" class="div-seances"></div>
                            <asp:Button ID="mer2Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mer2_Click" />
                            <asp:Button ID="mer2Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mer2_Click" />
                            <asp:Button ID="mer2Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mer2_Click"/>
                        </td>
                        <td id="mer3" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmer3" runat="server" class="div-seances"></div>
                            <asp:Button ID="mer3Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mer3_Click" />
                            <asp:Button ID="mer3Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mer3_Click" />
                            <asp:Button ID="mer3Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mer3_Click"/>
                        </td>
                        <td id="mer4" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divmer4" runat="server" class="div-seances"></div>
                            <asp:Button ID="mer4Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="mer4_Click" />
                            <asp:Button ID="mer4Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="mer4_Click" />
                            <asp:Button ID="mer4Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="mer4_Click"/>
                        </td>
                    </tr>
                    <tr>
                       <td style="height: 100px; width: 20%; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default;">Jeudi</td>
                        <td id="jeu1" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divjeu1" runat="server" class="div-seances"></div>
                            <asp:Button ID="jeu1Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="jeu1_Click" />
                            <asp:Button ID="jeu1Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="jeu1_Click" />
                            <asp:Button ID="jeu1Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="jeu1_Click" />
                        </td>
                        <td id="jeu2" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divjeu2" runat="server" class="div-seances"></div>
                            <asp:Button ID="jeu2Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="jeu2_Click" />
                            <asp:Button ID="jeu2Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="jeu2_Click" />
                            <asp:Button ID="jeu2Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="jeu2_Click" />
                        </td>
                        <td id="jeu3" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divjeu3" runat="server" class="div-seances"></div>
                            <asp:Button ID="jeu3Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="jeu3_Click" />
                            <asp:Button ID="jeu3Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="jeu3_Click" />
                            <asp:Button ID="jeu3Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="jeu3_Click" />
                        </td>
                        <td id="jeu4" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divjeu4" runat="server" class="div-seances"></div>
                            <asp:Button ID="jeu4Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="jeu4_Click" />
                            <asp:Button ID="jeu4Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="jeu4_Click" />
                            <asp:Button ID="jeu4Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="jeu4_Click" />
                        </td>
                    </tr>
                    <tr>
                       <td style="height: 100px; width: 20%; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default;">Vendredi</td>
                        <td id="ven1" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divven1" runat="server" class="div-seances"></div>
                            <asp:Button ID="ven1Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="ven1_Click" />
                            <asp:Button ID="ven1Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="ven1_Click" />
                            <asp:Button ID="ven1Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="ven1_Click" />
                        </td>
                        <td id="ven2" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divven2" runat="server" class="div-seances"></div>
                            <asp:Button ID="ven2Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="ven2_Click" />
                            <asp:Button ID="ven2Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="ven2_Click" />
                            <asp:Button ID="ven2Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="ven2_Click" />
                        </td>
                        <td id="ven3" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divven3" runat="server" class="div-seances"></div>
                            <asp:Button ID="ven3Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="ven3_Click" />
                            <asp:Button ID="ven3Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="ven3_Click" />
                            <asp:Button ID="ven3Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="ven3_Click"/>
                        </td>
                        <td id="ven4" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divven4" runat="server" class="div-seances"></div>
                            <asp:Button ID="ven4Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="ven4_Click" />
                            <asp:Button ID="ven4Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="ven4_Click" />
                            <asp:Button ID="ven4Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="ven4_Click" />
                        </td>
                    </tr>
                    <tr>
                       <td style="height: 100px; width: 20%; background-color:#2D2D30; font:16px Century Gothic; color:white; text-align:center; cursor: default;">Samedi</td>
                        <td id="sam1" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divsam1" runat="server" class="div-seances"></div>
                            <asp:Button ID="sam1Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="sam1_Click" />
                            <asp:Button ID="sam1Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="sam1_Click" />
                            <asp:Button ID="sam1Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="sam1_Click" />
                        </td>
                        <td id="sam2" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divsam2" runat="server" class="div-seances"></div>
                            <asp:Button ID="sam2Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="sam2_Click" />
                            <asp:Button ID="sam2Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="sam2_Click" />
                            <asp:Button ID="sam2Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="sam2_Click" />
                        </td>
                        <td id="sam3" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divsam3" runat="server" class="div-seances"></div>
                            <asp:Button ID="sam3Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="sam3_Click" />
                            <asp:Button ID="sam3Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="sam3_Click" />
                            <asp:Button ID="sam3Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="sam3_Click" />
                        </td>
                        <td id="sam4" runat="server" style="background-color:#2D2D30; position:relative; width: 20%; font:14px Century Gothic; color:white; text-align:center">
                            <div id="divsam4" runat="server" class="div-seances"></div>
                            <asp:Button ID="sam4Add" runat="server" BorderStyle="None" CssClass="add-seance" Font-Italic="False" Font-Size="80px" ForeColor="White" Height="100px" Text="+" Width="100%" Visible="False" OnClick="sam4_Click" />
                            <asp:Button ID="sam4Delete" runat="server" BorderStyle="None" CssClass="delete-seance" Height="102px" Width="50%" Font-Italic="False" Font-Size="80px" ForeColor="White" Text="-" Font-Names="Cambria Math" Font-Strikeout="False" Visible="False" OnClick="sam4_Click" />
                            <asp:Button ID="sam4Edit" runat="server" BorderStyle="None" CssClass="edit-seance" Height="103px" Width="50%" Font-Italic="False" Font-Size="50px" ForeColor="White" Text="!" Font-Names="Wingdings" Visible="False" OnClick="sam4_Click" />
                        </td>
                    </tr>
                </table>
                        <asp:ScriptManager ID="scrmanAddPopup" runat="server"></asp:ScriptManager>
                        <asp:Label ID="lblPopup" runat="server"></asp:Label>
                        <asp:Panel ID="AddPopupPanel" CssClass="modal" runat="server">
                            <table class="auto-style4" style="border-collapse:collapse;">
                                <tr>
                                    <td style="width: 90%; background-color:#2D2D30; border-bottom: medium solid #007ACC"><div id="header" style="font-family: 'Century Gothic'; font-size: small; color: #FFFFFF; margin: 10px 10px 10px 30px; background-color: #2D2D30;" class="header-text">Programmer la séance</div></td>
                                    <td style="width: 10%; border-bottom: medium solid #007ACC">
                                        <asp:Button ID="btnClosePopup" runat="server" Text="x" BorderStyle="None" CssClass="exit" ForeColor="White" Height="35px" Width="100%" Font-Names="Century Gothic" Font-Size="Medium" OnClick="btnClosePopup_Click" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        <div id="content" style="font-family: 'Century Gothic'; color: #FFFFFF; background-color: #2D2D30; height: 300px;">
                                            <table style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td colspan="3" class="auto-style7">
                                                        <asp:SqlDataSource ID="sqlFormateur" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT F.id, F.nom + ' ' + F.prenom AS nomcomplet FROM Formateur AS F INNER JOIN Specialite AS S ON S.formateur = F.id WHERE S.filiere = @filiere">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="ddlFiliere" Name="filiere" PropertyName="SelectedValue" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:SqlDataSource ID="sqlModule" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT P.module AS id, M.libelle FROM Programme AS P INNER JOIN Module AS M ON P.module = M.id WHERE (P.filiere = @filiere)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="ddlFiliere" Name="filiere" PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:SqlDataSource ID="sqlSalle" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT * FROM [Salle]"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: left; padding-left: 50px;">
                                                        <asp:Label ID="lblFormateur" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Text="Formateur:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style6" colspan="2">
                                                        <asp:DropDownList ID="ddlFormateur" runat="server" DataSourceID="sqlFormateur" DataTextField="nomcomplet" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" CssClass="dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 50px;" class="auto-style21">
                                                        <asp:Label ID="lblModule" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Text="Module:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style6" colspan="2">
                                                        <asp:DropDownList ID="ddlModule" runat="server" DataSourceID="sqlModule" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" CssClass="dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 50px;" class="auto-style21">
                                                        <asp:Label ID="lblSalle" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Text="Salle:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style20">
                                                        <asp:DropDownList ID="ddlSalle" runat="server" DataSourceID="sqlSalle" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" CssClass="ddl-salle" Height="21px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="auto-style6" onclick="EnableDisableCheckBox()">
                                                        <asp:CheckBox ID="chkDistanciel" runat="server" Text="Distanciel" CssClass="chk-distanciel" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style22" style="text-align: center; " colspan="3">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="height: 50px !important; text-align: center;">
                                                        <asp:Button ID="btnCancel" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnClosePopup_Click" Text="Annuler" Width="49%" />
                                                        <asp:Button ID="btnConfirm" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnConfirm_Click" Text="Confirmer" Width="49%" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                
                            </table>
                        </asp:Panel>
                        
                        <ajaxToolkit:ModalPopupExtender ID="AddPopup" BackgroundCssClass="modalBackground" PopupDragHandleControlID="header" TargetControlID="lblPopup" PopupControlID="AddPopupPanel" runat="server"></ajaxToolkit:ModalPopupExtender>
                        

                    <asp:Panel ID="DeletePopup" runat="server">
                            <table style="border-collapse:collapse; width: 500px; background-color:#2D2D30;">
                                <tr>
                                    <td style="width: 90%; background-color:#2D2D30; border-bottom: medium solid #007ACC">
                                        <div id="headerConf" style="font-family: 'Century Gothic'; font-size: small; color: #FFFFFF; margin: 10px 10px 10px 30px; background-color: #2D2D30;" class="header-text">Confirmer la suppression</div>
                                    </td>
                                    <td style="width: 10%; border-bottom: medium solid #007ACC">
                                        <asp:Button ID="btnExitSupp" runat="server" Text="x" BorderStyle="None" CssClass="exit" ForeColor="White" Height="35px" Width="100%" Font-Names="Century Gothic" Font-Size="Medium" OnClick="btnExitSupp_Click" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        <div  style="font-family: 'Century Gothic'; color: #FFFFFF; background-color: #2D2D30; " class="auto-style18">
                                            <table style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td colspan="2" class="auto-style19" style="background-color: #2D2D30">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style17" style="text-align: center; background-color: #2D2D30;" colspan="2">
                                                        Voulez-vous vraiment supprimer cette séance?</td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: #2D2D30;" class="auto-style19" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: #2D2D30;" class="auto-style16">
                                                        <asp:Button ID="btnSuprOui" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnSuprOui_Click" Text="Oui" Width="100%" />
                                                    </td>
                                                    <td class="auto-style16" style="background-color: #2D2D30">
                                                        <asp:Button ID="btnSupNon" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnExitSupp_Click" Text="Non" Width="100%" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="ConfirmDelete" BackgroundCssClass="modalBackground" PopupDragHandleControlID="headerConf" TargetControlID="lblPopup" PopupControlID="DeletePopup" runat="server"></ajaxToolkit:ModalPopupExtender>
                   
                        <asp:Panel ID="DuplicatedPanel" runat="server">
                            <table style="border-collapse:collapse; background-color:#2D2D30;" class="auto-style23">
                                <tr>
                                    <td style="width: 90%; background-color:#2D2D30; border-bottom: medium solid #007ACC">
                                        <div id="headerdup" style="font-family: 'Century Gothic'; font-size: small; color: #FFFFFF; margin: 10px 10px 10px 30px; background-color: #2D2D30;" class="header-text">Attention</div>
                                    </td>
                                    <td style="width: 10%; border-bottom: medium solid #007ACC">
                                        <asp:Button ID="btnExDup" runat="server" Text="x" BorderStyle="None" CssClass="exit" ForeColor="White" Height="35px" Width="100%" Font-Names="Century Gothic" Font-Size="Medium" OnClick="btnExDup_Click" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        <div  style="font-family: 'Century Gothic'; color: #FFFFFF; background-color: #2D2D30; " class="auto-style24">
                                            <table style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td colspan="2" class="auto-style19" style="background-color: #2D2D30">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="messagedup" runat="server" style="text-align: center; background-color: #2D2D30; padding-right: 10%; padding-left: 10%; font-family: 'Century Gothic'; font-size: small; color: #FFFFFF;" colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: #2D2D30;" class="auto-style19" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: #2D2D30; height: 50px !important" class="auto-style16">
                                                        <asp:Button ID="btnOuiDup" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%"  Text="Oui" Width="100%" OnClick="btnOuiDup_Click" />
                                                    </td>
                                                    <td class="auto-style16" style="background-color: #2D2D30">
                                                        <asp:Button ID="btnNonDup" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" Text="Non" Width="100%" OnClick="btnExDup_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <ajaxToolkit:ModalPopupExtender ID="mpeDup" BackgroundCssClass="modalBackground" PopupDragHandleControlID="headerdup" TargetControlID="lblPopup" PopupControlID="DuplicatedPanel" runat="server"></ajaxToolkit:ModalPopupExtender>

                        </asp:Panel>
                        <asp:Panel ID="pnlVider" runat="server">
                            <table style="border-collapse:collapse; width: 500px; background-color:#2D2D30;">
                                <tr>
                                    <td style="width: 90%; background-color:#2D2D30; border-bottom: medium solid #007ACC">
                                        <div id="headerVider" style="font-family: 'Century Gothic'; font-size: small; color: #FFFFFF; margin: 10px 10px 10px 30px; background-color: #2D2D30;" class="header-text">Confirmez la suppression</div>
                                    </td>
                                    <td style="width: 10%; border-bottom: medium solid #007ACC">
                                        <asp:Button ID="btnViderExit" runat="server" Text="x" BorderStyle="None" CssClass="exit" ForeColor="White" Height="35px" Width="100%" Font-Names="Century Gothic" Font-Size="Medium" OnClick="btnViderExit_Click" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        <div  style="font-family: 'Century Gothic'; color: #FFFFFF; background-color: #2D2D30; " class="auto-style18">
                                            <table style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td colspan="2" class="auto-style19" style="background-color: #2D2D30">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td runat="server" id="ViderText" class="auto-style17" style="text-align: center; background-color: #2D2D30;" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: #2D2D30;" class="auto-style19" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color: #2D2D30;" class="auto-style16">
                                                        <asp:Button ID="btnOuiVider" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnOuiVider_Click" Text="Oui" Width="100%" />
                                                    </td>
                                                    <td class="auto-style16" style="background-color: #2D2D30">
                                                        <asp:Button ID="btnNonVider" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnViderExit_Click" Text="Non" Width="100%" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="mpeVider" BackgroundCssClass="modalBackground" PopupDragHandleControlID="headervider" TargetControlID="lblPopup" PopupControlID="pnlVider" runat="server"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="pnlEdit" CssClass="modal" runat="server">
                            <table class="auto-style4" style="border-collapse:collapse;">
                                <tr>
                                    <td style="width: 90%; background-color:#2D2D30; border-bottom: medium solid #007ACC"><div id="edit-header" style="font-family: 'Century Gothic'; font-size: small; color: #FFFFFF; margin: 10px 10px 10px 30px; background-color: #2D2D30;" class="header-text">Mettez à jour la séance</div></td>
                                    <td style="width: 10%; border-bottom: medium solid #007ACC">
                                        <asp:Button ID="btnExitEdit" runat="server" Text="x" BorderStyle="None" CssClass="exit" ForeColor="White" Height="35px" Width="100%" Font-Names="Century Gothic" Font-Size="Medium" OnClick="btnExitEdit_Click" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        <div id="edit-content" style="font-family: 'Century Gothic'; color: #FFFFFF; background-color: #2D2D30; height: 300px;">
                                            <table style="width: 100%; height: 100%;">
                                                <tr>
                                                    <td colspan="3" class="auto-style7">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: left; padding-left: 50px;">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Text="Formateur:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style6" colspan="2">
                                                        <asp:DropDownList ID="ddlFormateurEdit" runat="server" DataSourceID="sqlFormateur" DataTextField="nomcomplet" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" CssClass="dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 50px;" class="auto-style21">
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Text="Module:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style6" colspan="2">
                                                        <asp:DropDownList ID="ddlModuleEdit" runat="server" DataSourceID="sqlModule" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" CssClass="dropdownlist">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 50px;" class="auto-style21">
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Text="Salle:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style20">
                                                        <asp:DropDownList ID="ddlSalleEdit" runat="server" DataSourceID="sqlSalle" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" CssClass="ddl-salle" Height="21px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="auto-style6" onclick="EnableDisableCheckBox()">
                                                        <asp:CheckBox ID="chkDistancielEdit" runat="server" Text="Distanciel" CssClass="chk-distanciel" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style22" style="text-align: center; " colspan="3">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="height: 50px !important; text-align: center;">
                                                        <asp:Button ID="btnCancelEdit" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnExitEdit_Click" Text="Annuler" Width="49%" />
                                                        <asp:Button ID="btnConfirmEdit" runat="server" BorderStyle="None" CssClass="cancel" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnConfirmEdit_Click" Text="Confirmer" Width="49%" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                
                            </table>
                        </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="mpeEdit" BackgroundCssClass="modalBackground" PopupDragHandleControlID="edit-header" TargetControlID="lblPopup" PopupControlID="pnlEdit" runat="server"></ajaxToolkit:ModalPopupExtender>

                     </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Management des groupes</legend>
                                        <br />
                                        <table style="width:100%;">
                                            <tr>
                                                <td style="width: 15%">
                                                    <asp:Label ID="lblFiliereGrpMan" runat="server" Text="Filière:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFiliereGrpMan" runat="server" AutoPostBack="True" CssClass="dropdownlist2" DataTextField="initiales" DataValueField="id" OnSelectedIndexChanged="ddlFiliereGrpMan_SelectedIndexChanged" Width="100px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table style="width:100%; border-collapse:collapse;">
                                                        <tr>
                                                            <td style="width: 25%; background-color: #CA5100;">
                                                                <table style="width:100%; height:150px">
                                                                    <tr>
                                                                        <td style="font-family: 'Century Gothic'; color: #FFFFFF; font-size: medium; padding-left: 10px;" class="auto-style25" colspan="3">Groupes de 1<sup>ère</sup> année</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20%;" class="auto-style26">
                                                                            <asp:Button ID="btnRemoveFirstYear" runat="server" BorderStyle="None" CssClass="first-year-button" Font-Size="XX-Large" ForeColor="White" Text="-" Width="100%" Height="40px" OnClick="btnRemoveFirstYear_Click" />
                                                                        </td>
                                                                        <td class="auto-style26" style="text-align: center;">
                                                                            <asp:Label ID="lblFirstYearCount" runat="server" Text="0" CssClass="count-label"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style26" style="width: 20%;">
                                                                            <asp:Button ID="btnAddFirstYear" runat="server" BorderStyle="None" CssClass="first-year-button" Text="+" Width="100%" Font-Size="XX-Large" ForeColor="White" Height="40px" OnClick="btnAddFirstYear_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 1%">&nbsp;</td>
                                                            <td style="width: 25%; background-color: #68217A;">
                                                                <table style="width:100%; height:150px">
                                                                    <tr>
                                                                        <td class="auto-style25" style="font-family: 'Century Gothic'; color: #FFFFFF; font-size: medium; padding-left: 10px;" colspan="3">Groupes de 2<sup>ème</sup> année</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td id="second-year-count"  class="auto-style26" style="width: 20%;">
                                                                            <asp:Button ID="btnRemoveSecondYear" runat="server" BorderStyle="None" CssClass="second-year-button" Font-Size="XX-Large" ForeColor="White" Height="40px" Text="-" Width="100%" OnClick="btnRemoveSecondYear_Click" />
                                                                        </td>
                                                                        <td id="second-year-count" class="auto-style26" style="text-align: center;">
                                                                            <asp:Label ID="lblSecondYearCount" runat="server" Text="0" CssClass="count-label"></asp:Label>
                                                                        </td>
                                                                        <td id="second-year-count" class="auto-style26" style="text-align: center; width: 20%;">
                                                                            <asp:Button ID="btnAddSecondYear" runat="server" BorderStyle="None" CssClass="second-year-button" Font-Size="XX-Large" ForeColor="White" Height="40px" Text="+" Width="100%" OnClick="btnAddSecondYear_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Management des modules</legend>
                                        <br />
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%">Ajouter un nouveau module:</td>
                                                <td style="width: 30%;">
                                                    &nbsp;</td>
                                                <td style="text-align: center">
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">&nbsp;</td>
                                                <td style="width: 30%;">&nbsp;</td>
                                                <td style="text-align: center">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">Le nom du module:</td>
                                                <td style="width: 30%;">
                                                    <asp:TextBox ID="txtNewModule" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" Width="90%"></asp:TextBox>
                                                </td>
                                                <td rowspan="2" style="text-align: center">
                                                    <asp:Button ID="btnAddModule" runat="server" BorderStyle="None" CssClass="add-module" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnAddModule_Click" Text="Ajouter" Width="50%" />
                                                    <br />
                                                    <asp:Label ID="lblErrorAddMod" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">
                                                    Les filières qui l&#39;on au programme:</td>
                                                <td>
                                                    <asp:CheckBoxList ID="chkListFiliere" runat="server" DataSourceID="sqlFiliere" DataTextField="initiales" DataValueField="id" RepeatColumns="4">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <br /><hr /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Modifier les modules existants:</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: center;">
                                                    
                                                    <asp:SqlDataSource ID="sqlModules" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT * FROM Module"></asp:SqlDataSource>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="ddl-modules" style="padding-left: 10px;">
                                                    <asp:DropDownList ID="ddlModules" runat="server" AutoPostBack="True" CssClass="ddl-other" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" OnSelectedIndexChanged="ddlModules_SelectedIndexChanged">
                                                    </asp:DropDownList></div>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td rowspan="3" style="text-align: center;">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td style="text-align: right; width: 25%;">
                                                                <asp:Button ID="btnUpdateModule" runat="server" BorderStyle="None" CssClass="btn" Font-Bold="False" Font-Names="Wingdings" Font-Size="40px" ForeColor="White" Height="50px" OnClick="btnUpdateModule_Click" Text="&lt;" Width="100%" Enabled="False" />
                                                            </td>
                                                            <td style="text-align: left; width: 25%;">
                                                                <asp:Button ID="btnDeleteModule" runat="server" BorderStyle="None" CssClass="logout" Font-Bold="False" Font-Names="Webdings" Font-Size="35px" ForeColor="White" Height="50px" OnClick="btnDeleteModule_Click" Text="r" Width="100%" Enabled="False" />
                                                                <asp:Button ID="btnConfirmYes" runat="server" Text="Oui" Width="45%" Height="50px" BorderStyle="None" Visible="False" CssClass="logout" OnClick="btnOuiDM_Click" Font-Names="Century Gothic" ForeColor="White" />
                                                                <asp:Button ID="btnConfirmNon" runat="server" Text="Non" Width="45%" Height="50px" BorderStyle="None"  Visible="False" CssClass="add-module" OnClick="btnNonDM_Click" Font-Names="Century Gothic" ForeColor="White" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                    <asp:Label ID="lblErrorEditMod" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">
                                                    Le nom du module:</td>
                                                <td>
                                                    <asp:TextBox ID="txtNewModuleMod" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">
                                                    Les filières qui l&#39;on au programme:</td>
                                                <td>
                                                    <asp:CheckBoxList ID="chkListFiliereMod" runat="server" DataSourceID="sqlFiliere" DataTextField="initiales" DataValueField="id" RepeatColumns="4">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Management des filières</legend>
                                        <br />
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%">Ajouter une nouvelle filière:</td>
                                                <td style="width: 30%;">
                                                    &nbsp;</td>
                                                <td style="text-align: center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">&nbsp;</td>
                                                <td style="width: 30%;">&nbsp;</td>
                                                <td style="text-align: center">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">Le nom de la fillière :</td>
                                                <td style="width: 30%;">
                                                    <asp:TextBox ID="txtNewFiliereNom" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" Width="90%" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td rowspan="2" style="text-align: center">
                                                    <asp:Button ID="btnAddFiliere" runat="server" BorderStyle="None" CssClass="add-module" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnAddFiliere_Click" Text="Ajouter" Width="50%" />
                                                    <br />
                                                    <asp:Label ID="lblAddFiliereError" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">
                                                    L&#39;abréviation de la fillière :</td>
                                                <td>
                                                    <asp:TextBox ID="txtNewFiliereAbr" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="10" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <br /><hr /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Modifier les filières existantes:</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: center;">
                                                    
                                                    <asp:SqlDataSource ID="sqlFilieres" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT id, (libelle + ' (' + initiales + ')') AS fullname FROM [Filiere] ORDER BY [initiales]"></asp:SqlDataSource>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 10px;" colspan="3">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 10px;">
                                                    <asp:DropDownList ID="ddlFilieres" runat="server" AutoPostBack="True" CssClass="ddl-other" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" OnSelectedIndexChanged="ddlFilieres_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="3" style="text-align: center;">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td style="text-align: right; width: 25%;">
                                                                <asp:Button ID="btnSaveEditsFiliere" runat="server" BorderStyle="None" CssClass="btn" Enabled="False" Font-Bold="False" Font-Names="Wingdings" Font-Size="40px" ForeColor="White" Height="50px" OnClick="btnSaveEditsFiliere_Click" Text="&lt;" Width="100%" />
                                                            </td>
                                                            <td style="text-align: left; width: 25%;">
                                                                <asp:Button ID="btnDeleteFiliere" runat="server" BorderStyle="None" CssClass="logout" Enabled="False" Font-Bold="False" Font-Names="Webdings" Font-Size="35px" ForeColor="White" Height="50px" OnClick="btnDeleteFiliere_Click" Text="r" Width="100%" />
                                                                <asp:Button ID="btnOuiDeleteFiliere" runat="server" BorderStyle="None" CssClass="logout" Font-Names="Century Gothic" ForeColor="White" Height="50px" OnClick="btnOuiDeleteFiliere_Click" Text="Oui" Visible="False" Width="45%" />
                                                                <asp:Button ID="btnNonDeleteFiliere" runat="server" BorderStyle="None" CssClass="add-module" Font-Names="Century Gothic" ForeColor="White" Height="50px" OnClick="btnNonDeleteFiliere_Click" Text="Non" Visible="False" Width="45%" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                    <asp:Label ID="lblEditFiliereError" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;"><div id="ddl-modules">
                                                    Le nom de la fillière :</div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEditFiliereNom" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" Width="90%" MaxLength="50"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">
                                                    L&#39;abréviation de la fillière :</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditFiliereAbr" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="10" Width="90%"></asp:TextBox>
                                                
                                                </td>
                            </tr>
                        </table>
                                </fieldset>
                                    </tr>
                            </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Management des formateurs</legend>
                                        <br />
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%">Ajouter un nouveau formateur:</td>
                                                <td style="width: 30%;">
                                                    &nbsp;</td>
                                                <td style="text-align: center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">&nbsp;</td>
                                                <td style="width: 30%;">&nbsp;</td>
                                                <td style="text-align: center">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">Civilitée du formateur :</td>
                                                <td style="width: 30%;">
                                                    <asp:DropDownList ID="ddlCivilite" runat="server" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" OnSelectedIndexChanged="ddlModules_SelectedIndexChanged" CssClass="ddl-civilite">
                                                        <asp:ListItem Selected="True">Monsieur</asp:ListItem>
                                                        <asp:ListItem>Madame</asp:ListItem>
                                                        <asp:ListItem>Mademoiselle</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td rowspan="4" style="text-align: center">
                                                    <asp:Button ID="btnAddFormateur" runat="server" BorderStyle="None" CssClass="add-module" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" Text="Ajouter" Width="50%" OnClick="btnAddFormateur_Click" />
                                                    <br />
                                                    <br />
                                                    <asp:Label ID="lblFormateurAddError" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">Prénom du formateur :</td>
                                                <td style="width: 30%;">
                                                    <asp:TextBox ID="txtPrenom" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" Width="90%" MaxLength="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">Nom du formateur&nbsp;:</td>
                                                <td>
                                                    <asp:TextBox ID="txtNom" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" Width="90%" MaxLength="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">
                                                    Filières qui&#39;il enseigne :</td>
                                                <td>
                                                    <asp:CheckBoxList ID="chkFilieresFormateur" runat="server" DataSourceID="sqlFiliere" DataTextField="initiales" DataValueField="id" RepeatColumns="4">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <br /><hr /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Modifier les formateurs existants:</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: center;">
                                                    
                                                    <asp:SqlDataSource ID="sqlEditFormateur" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT [id], [nom] +' ' + [prenom] as nomcomplet FROM [Formateur] ORDER BY nomcomplet"></asp:SqlDataSource>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;">
                                                    &nbsp;</td>
                                                <td rowspan="6" style="text-align: center;">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td style="text-align: right; width: 25%;">
                                                                <asp:Button ID="btnEditFormateur" runat="server" BorderStyle="None" CssClass="btn" Font-Bold="False" Font-Names="Wingdings" Font-Size="40px" ForeColor="White" Height="50px" Text="&lt;" Width="100%" Enabled="False" OnClick="btnEditFormateur_Click" />
                                                            </td>
                                                            <td style="text-align: left; width: 25%;">
                                                                <asp:Button ID="btnDeleteFormateur" runat="server" BorderStyle="None" CssClass="logout" Font-Bold="False" Font-Names="Webdings" Font-Size="35px" ForeColor="White" Height="50px" Text="r" Width="100%" Enabled="False" OnClick="btnDeleteFormateur_Click" />
                                                                <asp:Button ID="btnOuiFormateur" runat="server" Text="Oui" Width="45%" Height="50px" BorderStyle="None" Visible="False" CssClass="logout" Font-Names="Century Gothic" ForeColor="White" OnClick="btnOuiFormateur_Click" />
                                                                <asp:Button ID="btnNonFormateur" runat="server" Text="Non" Width="45%" Height="50px" BorderStyle="None"  Visible="False" CssClass="add-module" Font-Names="Century Gothic" ForeColor="White" OnClick="btnNonFormateur_Click" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                    <br />
                                                    <asp:Label ID="lblFormateurEditError" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 10px;">
                                                    <asp:DropDownList ID="ddlFormateurs" runat="server" AutoPostBack="True" CssClass="ddl-else" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" OnSelectedIndexChanged="ddlFormateurs_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">
                                                    Civilitée du formateur :&nbsp;&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCiviliteMod" runat="server" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" OnSelectedIndexChanged="ddlModules_SelectedIndexChanged" CssClass="ddl-civilite">
                                                        <asp:ListItem Selected="True">Monsieur</asp:ListItem>
                                                        <asp:ListItem>Madame</asp:ListItem>
                                                        <asp:ListItem>Mademoiselle</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">Prénom du formateur :</td>
                                                <td>
                                                    <asp:TextBox ID="txtPrenomMod" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="30" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">Nom du formateur&nbsp;:</td>
                                                <td>
                                                    <asp:TextBox ID="txtNomMod" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="30" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; font-size: 10pt; padding-left: 20px;">
                                                    Filières qui&#39;il enseigne :</td>
                                                <td>
                                                    <asp:CheckBoxList ID="chkFilieresFormateurMod" runat="server" DataSourceID="sqlFiliere" DataTextField="initiales" DataValueField="id" RepeatColumns="4">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Management des Salles</legend>
                                        <br />
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%">Ajouter une nouvelle salle:</td>
                                                <td style="width: 30%;">
                                                    &nbsp;</td>
                                                <td style="text-align: center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" rowspan="2">&nbsp;</td>
                                                <td style="text-align: center">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" style="text-align: center">
                                                    <asp:Button ID="btnNewSalle" runat="server" BorderStyle="None" CssClass="add-module" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnNewSalle_Click" Text="Ajouter" Width="50%" />
                                                    <br />
                                                    <asp:Label ID="lblAddSalleError" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">
                                                    Le libellé de la salle&nbsp; :</td>
                                                <td>
                                                    <asp:TextBox ID="txtAddSalleLibelle" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="20" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <br /><hr /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Modifier les salles existantes:</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: center;">
                                                    
                                                    <asp:SqlDataSource ID="sqlSalles" runat="server" ConnectionString="<%$ ConnectionStrings:HR_Emplois.Properties.Settings.ConnectionStrng %>" SelectCommand="SELECT * FROM [Salle]"></asp:SqlDataSource>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 10px;" colspan="2">
                                                    &nbsp;</td>
                                                <td rowspan="3" style="text-align: center;">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td style="text-align: right; width: 25%;">
                                                                <asp:Button ID="btnSaveEditsSalle" runat="server" BorderStyle="None" CssClass="btn" Font-Bold="False" Font-Names="Wingdings" Font-Size="40px" ForeColor="White" Height="50px" OnClick="btnSaveEditsSalle_Click" Text="&lt;" Width="100%" Enabled="False" />
                                                            </td>
                                                            <td style="text-align: left; width: 25%;">
                                                                <asp:Button ID="btnDeleteSalle" runat="server" BorderStyle="None" CssClass="logout" Font-Bold="False" Font-Names="Webdings" Font-Size="35px" ForeColor="White" Height="50px" OnClick="btnDeleteSalle_Click" Text="r" Width="100%" Enabled="False" />
                                                                <asp:Button ID="btnOuiSalle" runat="server" Text="Oui" Width="45%" Height="50px" BorderStyle="None" Visible="False" CssClass="logout" OnClick="btnOuiSalle_Click" Font-Names="Century Gothic" ForeColor="White" />
                                                                <asp:Button ID="btnNonSalle" runat="server" Text="Non" Width="45%" Height="50px" BorderStyle="None"  Visible="False" CssClass="add-module" OnClick="btnNonSalle_Click" Font-Names="Century Gothic" ForeColor="White" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                    <asp:Label ID="lblEditSalleError" runat="server" Text="Tous les champs sont obligatoires!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; padding-left: 20px;" colspan="2">
                                                    <asp:DropDownList ID="ddlSalles" runat="server" AutoPostBack="True" CssClass="ddl-other" DataTextField="libelle" DataValueField="id" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#202020" OnSelectedIndexChanged="ddlSalles_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">
                                                    Le libellé de la salle&nbsp; :</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditSalleLibelle" runat="server" autocomplete="off" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="20" Width="90%"></asp:TextBox>
                                                
                                                </td>
                            </tr>
                        </table>
                                </fieldset>
                                    </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Annonce</legend>
                                        <br />
                                        <table style="width:100%;">
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;">Le texte de l&#39;annonce :</td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtAnnonce" runat="server" Font-Names="Century Gothic" Font-Size="Medium" Height="50px" Rows="10" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-size: 10pt; width: 30%; padding-left: 20px;">&nbsp;</td>
                                                <td colspan="3">
                                                    <asp:CheckBox ID="chkImportant" runat="server" Text="Marquer cette annonce comme importante" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="font-size: 10pt; padding-left: 20px;">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="font-size: 10pt; padding-left: 20px;">&nbsp;</td>
                                                <td style="width: 15%; text-align: right;">
                                                    <asp:Button ID="btnDefaultAnnonce" runat="server" BorderStyle="None" CssClass="btn" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnDefaultAnnonce_Click" Text="Réinitialiser" Width="80%" />
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:Button ID="btnUpdateAnnonce" runat="server" BorderStyle="None" CssClass="btn" Font-Names="Wingdings" Font-Size="40px" ForeColor="White" Height="50px" OnClick="btnUpdateAnnonce_Click" Text="&lt;" Width="80%" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 20px 20px 20px 20px; font: medium 'Century Gothic'; text-align: center; color: #FFFFFF;">
                                    <fieldset style="padding: 0px 20px 20px 20px; text-align: left;">
                                        <legend>Sécurité</legend>
                                        <br />
                                        <table style="width:100%;">
                                            <tr>
                                                <td colspan="3">Modifier l&#39;identifiant et le mot de passe</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="font-size: 10pt; padding-left: 20px;">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; width: 30%; padding-left: 20px;" colspan="2">Identifiant :</td>
                                                <td style="width: 70%;">
                                                    <asp:TextBox ID="txtUser" runat="server" CssClass="credentials" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="30" ValidationGroup="Security" Width="40%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser" ErrorMessage="Ce champs est obligatoire" SetFocusOnError="True" ValidationGroup="Security"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="font-size: 10pt; padding-left: 20px; width: 30%;">Mot de passe :</td>
                                                <td style="width: 70%;">
                                                    <asp:TextBox ID="txtPass" runat="server" CssClass="credentials" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="30" TextMode="Password" ValidationGroup="Security" Width="40%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPass" ErrorMessage="Ce champs est obligatoire" SetFocusOnError="True" ValidationGroup="Security"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style27" colspan="2" style="font-size: 10pt; padding-left: 20px; width: 30%;">Confirmation de mot de passe :</td>
                                                <td style="width: 70%;">
                                                    <asp:TextBox ID="txtConf" runat="server" CssClass="credentials" Font-Names="Century Gothic" Font-Size="Medium" MaxLength="30" TextMode="Password" ValidationGroup="Security" Width="40%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvConf" runat="server" ControlToValidate="txtConf" ErrorMessage="Ce champs est obligatoire" SetFocusOnError="True" ValidationGroup="Security"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 10pt; padding-left: 20px; width: 30%;">&nbsp;</td>
                                                <td style="width: 70%; font-size: 10pt; padding-left: 20px;" colspan="2">
                                                    <asp:CompareValidator ID="cmvPass" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConf" ErrorMessage="Le mot de passe et sa confirmaton ne sont pas identiques" Font-Names="Century Gothic" Font-Size="Medium" ValidationGroup="Security"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td style="width: 70%; padding-left: 20px;">
                                                                <asp:Label ID="lblReset" runat="server" Text="L'identifiant et le mot de passe par défault sont appliqués" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 15%; text-align: right;">
                                                                <asp:Button ID="btnDefaultSecurity" runat="server" BorderStyle="None" CssClass="btn" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="50px" OnClick="btnDefaultSecurity_Click" Text="Réinitialiser" ValidationGroup="Security" Width="80%" />
                                                            </td>
                                                            <td style="width: 15%;">
                                                                <asp:Button ID="btnUpdateSecurity" runat="server" BorderStyle="None" CssClass="btn" Font-Names="Wingdings" Font-Size="40px" ForeColor="White" Height="50px" OnClick="btnUpdateSecurity_Click" Text="&lt;" ValidationGroup="Security" Width="80%" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td style="width: 180px; height: 90px; background-color: #007ACC;">
                <asp:Button ID="btn2" runat="server" Text="Gestion des unités"  BorderStyle="None" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" Width="100%" CssClass="btn" OnClick="btn2_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 180px; height: 90px; background-color: #007ACC;">
                <asp:Button ID="btn3" runat="server" Text="Gestion des ressources"  BorderStyle="None" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" Width="100%" CssClass="btn" OnClick="btn3_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 180px; height: 90px; background-color: #007ACC;">
                <asp:Button ID="btn4" runat="server" Text="Gestion de l'application"  BorderStyle="None" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" OnClick="btn4_Click" Width="100%" CssClass="btn" />
            </td>
        </tr>
        <tr>
            <td style="width: 180px; height: 100%; background-color: #007ACC;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 180px; height: 90px; background-color: #E81123;">
                <asp:Button ID="btnLogout" runat="server" Text="Déconnexion"  BorderStyle="None" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="100%" OnClick="btnLogout_Click" Width="100%" CssClass="logout" />
            </td>
        </tr>
    </table>
</asp:Content>
