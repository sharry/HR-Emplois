using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;

namespace HR_Emplois
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblAnnonce")).Text = Application["Annonce"].ToString();
            ((HtmlGenericControl)Master.FindControl("annonceback")).Style.Add("background-color", (bool)Application["Important"] ? "#E81123" : "#313131");
            
            if (!IsPostBack)
            {
                if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
                    HighlightDay(1);
                else if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
                    HighlightDay(2);
                else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
                    HighlightDay(3);
                else if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
                    HighlightDay(4);
                else if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
                    HighlightDay(5);
                else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                    HighlightDay(6);
                ddlFiliere.DataSource = sqlFiliere;
                ddlFiliere.DataValueField = "id";
                ddlFiliere.DataTextField = "initiales";
                ddlFiliere.DataBind();
                ddlFiliere.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFiliere.SelectedIndex = 0;
                if (Request.Cookies["LastEmplois"] != null)
                {
                    ddlFiliere.SelectedValue = Request.Cookies["LastEmplois"].Values["Filiere"].ToString();
                    ddlFiliere_SelectedIndexChanged(sender, e);
                    ddlGroupe.SelectedValue = Request.Cookies["LastEmplois"].Values["Groupe"].ToString();
                    ddlGroupe_SelectedIndexChanged(sender, e);
                }
            }
        }

        //Variables globales
        ADO ado = new ADO();
        DataTable emploi = new DataTable();

        //Fonctions auxiliaries
        protected int EmploisCount()
        {
            ado.Command = new SqlCommand("SELECT COUNT(*) FROM Emploi WHERE groupe = @gr", ado.Connection);
            SqlParameter parGroupe = new SqlParameter("@gr", SqlDbType.Int);
            parGroupe.Value = ddlGroupe.SelectedValue;
            ado.Command.Parameters.Add(parGroupe);
            ado.Open();
            int count;
            try
            {
                count = (int)ado.Command.ExecuteScalar();
                ado.Close();
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        protected void HighlightDay(int day)
        {
            switch (day)
            {
                case 1:
                    lun.Style.Add("background-color", "#3E3E42");
                    lun1.Style.Add("background-color", "#3E3E42");
                    lun2.Style.Add("background-color", "#3E3E42");
                    lun3.Style.Add("background-color", "#3E3E42");
                    lun4.Style.Add("background-color", "#3E3E42");
                    break;
                case 2:
                    mar.Style.Add("background-color", "#3E3E42");
                    mar1.Style.Add("background-color", "#3E3E42");
                    mar2.Style.Add("background-color", "#3E3E42");
                    mar3.Style.Add("background-color", "#3E3E42");
                    mar4.Style.Add("background-color", "#3E3E42");
                    break;
                case 3:
                    mer.Style.Add("background-color", "#3E3E42");
                    mer1.Style.Add("background-color", "#3E3E42");
                    mer2.Style.Add("background-color", "#3E3E42");
                    mer3.Style.Add("background-color", "#3E3E42");
                    mer4.Style.Add("background-color", "#3E3E42");
                    break;
                case 4:
                    jeu.Style.Add("background-color", "#3E3E42");
                    jeu1.Style.Add("background-color", "#3E3E42");
                    jeu2.Style.Add("background-color", "#3E3E42");
                    jeu3.Style.Add("background-color", "#3E3E42");
                    jeu4.Style.Add("background-color", "#3E3E42");
                    break;
                case 5:
                    ven.Style.Add("background-color", "#3E3E42");
                    ven1.Style.Add("background-color", "#3E3E42");
                    ven2.Style.Add("background-color", "#3E3E42");
                    ven3.Style.Add("background-color", "#3E3E42");
                    ven4.Style.Add("background-color", "#3E3E42");
                    break;
                case 6:
                    sam.Style.Add("background-color", "#3E3E42");
                    sam1.Style.Add("background-color", "#3E3E42");
                    sam2.Style.Add("background-color", "#3E3E42");
                    sam3.Style.Add("background-color", "#3E3E42");
                    sam4.Style.Add("background-color", "#3E3E42");
                    break;
            }
        }

        //Méthodes de remplissage/épuisement de l'emplois du temps
        protected void FillSeance(string jour, string temps)
        {
            string module, formateur, salle;
            bool distance;
            DataView view = emploi.DefaultView;
            view.RowFilter = "jour = " + jour + " AND temps = " + temps;
            try
            {
                ado.Open();
                ado.Command = new SqlCommand("SELECT M.libelle FROM Module AS M WHERE M.id = " + view[0][1], ado.Connection);
                module = ado.Command.ExecuteScalar().ToString();
                ado.Command = new SqlCommand("SELECT F.civilite FROM Formateur AS F WHERE F.id = " + view[0][2], ado.Connection);
                formateur = ado.Command.ExecuteScalar().ToString();
                formateur = (formateur == "Monsieur") ? ("M. ") : ((formateur == "Madame") ? "Mme. " : "Mlle. ");
                ado.Command = new SqlCommand("SELECT F.nom FROM Formateur AS F WHERE F.id = " + view[0][2], ado.Connection);
                formateur += ado.Command.ExecuteScalar().ToString().ToUpper() + " ";
                ado.Command = new SqlCommand("SELECT F.prenom FROM Formateur AS F WHERE F.id = " + view[0][2], ado.Connection);
                formateur += ado.Command.ExecuteScalar().ToString()[0] + ".";
                ado.Command = new SqlCommand("SELECT S.libelle FROM Salle AS S WHERE S.id = " + view[0][6], ado.Connection);
                try
                {
                    salle = ado.Command.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    salle = "";
                }
                distance = (bool)view[0][7];
            }
            catch (Exception)
            {
                return;
            }

            if (jour == "1" && temps == "1")
            {
                if (distance)
                    lun1.Style.Add("background-color", "#68217A");
                else
                    lun1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    lun1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    lun1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "1" && temps == "2")
            {
                if (distance)
                    lun2.Style.Add("background-color", "#68217A");
                else
                    lun2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    lun2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    lun2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "1" && temps == "3")
            {
                if (distance)
                    lun3.Style.Add("background-color", "#68217A");
                else
                    lun3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    lun3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    lun3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "1" && temps == "4")
            {
                if (distance)
                    lun4.Style.Add("background-color", "#68217A");
                else
                    lun4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    lun4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    lun4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "2" && temps == "1")
            {
                if (distance)
                    mar1.Style.Add("background-color", "#68217A");
                else
                    mar1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mar1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mar1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "2" && temps == "2")
            {
                if (distance)
                    mar2.Style.Add("background-color", "#68217A");
                else
                    mar2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mar2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mar2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "2" && temps == "3")
            {
                if (distance)
                    mar3.Style.Add("background-color", "#68217A");
                else
                    mar3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mar3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mar3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "2" && temps == "4")
            {
                if (distance)
                    mar4.Style.Add("background-color", "#68217A");
                else
                    mar4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mar4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mar4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;

            }
            else if (jour == "3" && temps == "1")
            {
                if (distance)
                    mer1.Style.Add("background-color", "#68217A");
                else
                    mer1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mer1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mer1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "3" && temps == "2")
            {
                if (distance)
                    mer2.Style.Add("background-color", "#68217A");
                else
                    mer2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mer2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mer2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "3" && temps == "3")
            {
                if (distance)
                    mer3.Style.Add("background-color", "#68217A");
                else
                    mer3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mer3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mer3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "3" && temps == "4")
            {
                if (distance)
                    mer4.Style.Add("background-color", "#68217A");
                else
                    mer4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    mer4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    mer4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "4" && temps == "1")
            {
                if (distance)
                    jeu1.Style.Add("background-color", "#68217A");
                else
                    jeu1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    jeu1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    jeu1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "4" && temps == "2")
            {
                if (distance)
                    jeu2.Style.Add("background-color", "#68217A");
                else
                    jeu2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    jeu2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    jeu2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "4" && temps == "3")
            {
                if (distance)
                    jeu3.Style.Add("background-color", "#68217A");
                else
                    jeu3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    jeu3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    jeu3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "4" && temps == "4")
            {
                if (distance)
                    jeu4.Style.Add("background-color", "#68217A");
                else
                    jeu4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    jeu4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    jeu4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "5" && temps == "1")
            {
                if (distance)
                    ven1.Style.Add("background-color", "#68217A");
                else
                    ven1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    ven1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    ven1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "5" && temps == "2")
            {
                if (distance)
                    ven2.Style.Add("background-color", "#68217A");
                else
                    ven2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    ven2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    ven2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "5" && temps == "3")
            {
                if (distance)
                    ven3.Style.Add("background-color", "#68217A");
                else
                    ven3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    ven3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    ven3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "5" && temps == "1")
            {
                if (distance)
                    ven4.Style.Add("background-color", "#68217A");
                else
                    ven4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    ven4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    ven4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "6" && temps == "1")
            {
                if (distance)
                    sam1.Style.Add("background-color", "#68217A");
                else
                    sam1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    sam1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    sam1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "6" && temps == "2")
            {
                if (distance)
                    sam2.Style.Add("background-color", "#68217A");
                else
                    sam2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    sam2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    sam2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "6" && temps == "3")
            {
                if (distance)
                    sam3.Style.Add("background-color", "#68217A");
                else
                    sam3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    sam3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    sam3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
            else if (jour == "6" && temps == "4")
            {
                if (distance)
                    sam4.Style.Add("background-color", "#68217A");
                else
                    sam4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    sam2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    sam4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
            }
        }
        protected void ClearSeances()
        {
            lun1.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                lun1.Style.Add("background-color", "#3E3E42");
            else
                lun1.Style.Add("background-color", "#2D2D30");
            lun2.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                lun2.Style.Add("background-color", "#3E3E42");
            else
                lun2.Style.Add("background-color", "#2D2D30");
            lun3.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                lun3.Style.Add("background-color", "#3E3E42");
            else
                lun3.Style.Add("background-color", "#2D2D30");
            lun4.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                lun4.Style.Add("background-color", "#3E3E42");
            else
                lun4.Style.Add("background-color", "#2D2D30");
            mar1.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                mar1.Style.Add("background-color", "#3E3E42");
            else
                mar1.Style.Add("background-color", "#2D2D30");
            mar2.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                mar2.Style.Add("background-color", "#3E3E42");
            else
                mar2.Style.Add("background-color", "#2D2D30");
            mar3.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                mar3.Style.Add("background-color", "#3E3E42");
            else
                mar3.Style.Add("background-color", "#2D2D30");
            mar4.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                mar4.Style.Add("background-color", "#3E3E42");
            else
                mar4.Style.Add("background-color", "#2D2D30");
            mer1.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                mer1.Style.Add("background-color", "#3E3E42");
            else
                mer1.Style.Add("background-color", "#2D2D30");
            mer2.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                mer2.Style.Add("background-color", "#3E3E42");
            else
                mer2.Style.Add("background-color", "#2D2D30");
            mer3.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                mer3.Style.Add("background-color", "#3E3E42");
            else
                mer3.Style.Add("background-color", "#2D2D30");
            mer4.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                mer4.Style.Add("background-color", "#3E3E42");
            else
                mer4.Style.Add("background-color", "#2D2D30");
            jeu1.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                jeu1.Style.Add("background-color", "#3E3E42");
            else
                jeu1.Style.Add("background-color", "#2D2D30");
            jeu2.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                jeu2.Style.Add("background-color", "#3E3E42");
            else
                jeu2.Style.Add("background-color", "#2D2D30");
            jeu3.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                jeu3.Style.Add("background-color", "#3E3E42");
            else
                jeu3.Style.Add("background-color", "#2D2D30");
            jeu4.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                jeu4.Style.Add("background-color", "#3E3E42");
            else
                jeu4.Style.Add("background-color", "#2D2D30");
            ven1.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                ven1.Style.Add("background-color", "#3E3E42");
            else
                ven1.Style.Add("background-color", "#2D2D30");
            ven2.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                ven2.Style.Add("background-color", "#3E3E42");
            else
                ven2.Style.Add("background-color", "#2D2D30");
            ven3.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                ven3.Style.Add("background-color", "#3E3E42");
            else
                ven3.Style.Add("background-color", "#2D2D30");
            ven4.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                ven4.Style.Add("background-color", "#3E3E42");
            else
                ven4.Style.Add("background-color", "#2D2D30");
            sam1.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                sam1.Style.Add("background-color", "#3E3E42");
            else
                sam1.Style.Add("background-color", "#2D2D30");
            sam2.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                sam2.Style.Add("background-color", "#3E3E42");
            else
                sam2.Style.Add("background-color", "#2D2D30");
            sam3.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                sam3.Style.Add("background-color", "#3E3E42");
            else
                sam3.Style.Add("background-color", "#2D2D30");
            sam4.InnerHtml = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                sam4.Style.Add("background-color", "#3E3E42");
            else
                sam4.Style.Add("background-color", "#2D2D30");
        }
        protected void SubGroupControls()
        {
            ado.Open();
            switch (EmploisCount())
            {
                case 0:
                    radSubGroupA.Visible = false;
                    radSubGroupB.Visible = false;
                    radSubGroupC.Visible = false;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    ado.Close();
                    break;
                case 1:
                    radSubGroupA.Visible = false;
                    radSubGroupB.Visible = false;
                    radSubGroupC.Visible = false;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    break;
                case 2:
                    radSubGroupA.Visible = true;
                    radSubGroupB.Checked = false;
                    radSubGroupC.Checked = false;
                    radSubGroupD.Checked = false;
                    radSubGroupE.Checked = false;
                    radSubGroupF.Checked = false;
                    radSubGroupA.Checked = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = false;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    break;
                case 3:
                    radSubGroupA.Visible = true;
                    radSubGroupB.Checked = false;
                    radSubGroupC.Checked = false;
                    radSubGroupD.Checked = false;
                    radSubGroupE.Checked = false;
                    radSubGroupF.Checked = false;
                    radSubGroupA.Checked = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    break;
                case 4:
                    radSubGroupA.Visible = true;
                    radSubGroupB.Checked = false;
                    radSubGroupC.Checked = false;
                    radSubGroupD.Checked = false;
                    radSubGroupE.Checked = false;
                    radSubGroupF.Checked = false;
                    radSubGroupA.Checked = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = true;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    break;
                case 5:
                    radSubGroupA.Visible = true;
                    radSubGroupB.Checked = false;
                    radSubGroupC.Checked = false;
                    radSubGroupD.Checked = false;
                    radSubGroupE.Checked = false;
                    radSubGroupF.Checked = false;
                    radSubGroupA.Checked = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = true;
                    radSubGroupE.Visible = true;
                    radSubGroupF.Visible = false;
                    break;
                case 6:
                    radSubGroupA.Visible = true;
                    radSubGroupB.Checked = false;
                    radSubGroupC.Checked = false;
                    radSubGroupD.Checked = false;
                    radSubGroupE.Checked = false;
                    radSubGroupF.Checked = false;
                    radSubGroupA.Checked = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = true;
                    radSubGroupE.Visible = true;
                    radSubGroupF.Visible = true;
                    break;
                default:
                    radSubGroupA.Visible = false;
                    radSubGroupB.Visible = false;
                    radSubGroupC.Visible = false;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    break;
            }
        }
        protected void FillBySubGroup(char libelle)
        {
            ado.Command = new SqlCommand("SELECT E.id FROM Emploi AS E WHERE E.groupe = @gr  AND E.libelle = '" + libelle + "'", ado.Connection);
            SqlParameter parGroupe = new SqlParameter("@gr", SqlDbType.Int);
            parGroupe.Value = ddlGroupe.SelectedValue;
            ado.Command.Parameters.Add(parGroupe);
            ado.Open();
            try
            {
                string id = ado.Command.ExecuteScalar().ToString();
                ado.Command = new SqlCommand("SELECT S.* FROM Seance AS S WHERE S.emploi = " + id, ado.Connection);
                SqlDataAdapter dataadapter = new SqlDataAdapter(ado.Command);
                dataadapter.Fill(emploi);
                ClearSeances();
                for (int jour = 1; jour < 7; jour++)
                {
                    for (int temps = 1; temps < 5; temps++)
                        FillSeance(Convert.ToString(jour), Convert.ToString(temps));
                }
            }
            catch (Exception)
            {
                ClearSeances();
                return;
            }
            ado.Close();
        }

        //Évènements
        protected void ddlGroupe_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBySubGroup('a');
            SubGroupControls();
            Response.Cookies["LastEmplois"].Values["Filiere"] = ddlFiliere.SelectedValue;
            Response.Cookies["LastEmplois"].Values["Groupe"] = ddlGroupe.SelectedValue;
        }
        protected void ddlFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiliere.SelectedIndex == 0)
            {
                ddlGroupe.Items.Clear();
                ClearSeances();
                SubGroupControls();
            }
            else
            {
                ddlGroupe.DataSource = sqlGroupe;
                ddlGroupe.DataValueField = "id";
                ddlGroupe.DataTextField = "numero";
                ddlGroupe.DataBind();
                ddlGroupe_SelectedIndexChanged(sender, e);
            }
        }
        protected void radSubGroupA_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupA.Checked)
                ddlGroupe_SelectedIndexChanged(sender, e);
        }
        protected void radSubGroupB_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupB.Checked)
                FillBySubGroup('b');
        }
        protected void radSubGroupC_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupC.Checked)
                FillBySubGroup('c');
        }
        protected void radSubGroupD_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupD.Checked)
                FillBySubGroup('d');
        }
        protected void radSubGroupE_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupE.Checked)
                FillBySubGroup('e');
        }
        protected void radSubGroupF_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupF.Checked)
                FillBySubGroup('f');
        }

        //protected void btnDownload_Click(object sender, EventArgs e)
        //{
        //    ReportDocument Report = new ReportDocument();
        //    Report.Load(Server.MapPath("Emplois.rpt"));
        //    Report.SetDatabaseLogon("", "");
        //    TextObject txtFiliere;
        //    txtFiliere = Report.ReportDefinition.ReportObjects["txtFiliere"] as TextObject;
        //    txtFiliere.Text = "TDI 205";
        //    Report.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Emplois");
        //}
    }
}