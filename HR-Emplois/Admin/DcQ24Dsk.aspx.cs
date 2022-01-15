using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace HR_Emplois.Admin
{
    public partial class DcQ24Dsk : System.Web.UI.Page
    {
        //Securité
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"].ToString() != "Admin")
                {
                    Response.Redirect("~/CXR5eg8B.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/CXR5eg8B.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"].ToString() != "Admin")
                {
                    Response.Redirect("~/CXR5eg8B.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/CXR5eg8B.aspx");
            }
            if (!IsPostBack)
            {
                ddlFiliere.DataSource = sqlFiliere;
                ddlFiliere.DataValueField = "id";
                ddlFiliere.DataTextField = "initiales";
                ddlFiliere.DataBind();
                ddlFiliere.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFiliere.SelectedIndex = 0;

                ddlFiliereGrpMan.DataSource = sqlFiliere;
                ddlFiliereGrpMan.DataValueField = "id";
                ddlFiliereGrpMan.DataTextField = "initiales";
                ddlFiliereGrpMan.DataBind();
                ddlFiliereGrpMan.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFiliereGrpMan.SelectedIndex = 0;
                btnRemoveFirstYear.Visible = false;
                btnRemoveSecondYear.Visible = false;
                btnAddFirstYear.Visible = false;
                btnAddSecondYear.Visible = false;

                ddlModules.DataSource = sqlModules;
                ddlModules.DataValueField = "id";
                ddlModules.DataTextField = "libelle";
                ddlModules.DataBind();
                ddlModules.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlModules.SelectedIndex = 0;

                ddlFormateurs.DataSource = sqlEditFormateur;
                ddlFormateurs.DataValueField = "id";
                ddlFormateurs.DataTextField = "nomcomplet";
                ddlFormateurs.DataBind();
                ddlFormateurs.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFormateurs.SelectedIndex = 0;

                ddlFilieres.DataSource = sqlFilieres;
                ddlFilieres.DataValueField = "id";
                ddlFilieres.DataTextField = "fullname";
                ddlFilieres.DataBind();
                ddlFilieres.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFilieres.SelectedIndex = 0;

                ddlSalles.DataSource = sqlSalles;
                ddlSalles.DataValueField = "id";
                ddlSalles.DataTextField = "libelle";
                ddlSalles.DataBind();
                ddlSalles.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlSalles.SelectedIndex = 0;

                txtAnnonce.Text = Application["Annonce"].ToString();
                chkImportant.Checked = (bool)Application["Important"];

                btn1_Click(sender, e);
            }
            else
            {
                btnConfirmNon.Visible = false;
                btnConfirmYes.Visible = false;
                btnOuiFormateur.Visible = false;
                btnNonFormateur.Visible = false;
                btnOuiDeleteFiliere.Visible = false;
                btnNonDeleteFiliere.Visible = false;
                btnOuiSalle.Visible = false;
                btnNonSalle.Visible = false;
                btnDeleteSalle.Visible = true;
                btnDeleteFiliere.Visible = true;
                btnDeleteFormateur.Visible = true;
                btnDeleteModule.Visible = true;
                lblReset.Visible = false;
            }
        }

        //Variables globales
        ADO ado = new ADO();
        DataTable emploi = new DataTable();

        //Boutons interface
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = "Anonymous";
            Response.Redirect("../Home.aspx");
        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            btn1.BackColor = System.Drawing.Color.FromArgb(0, 100, 174);
            btn2.BackColor = System.Drawing.Color.Empty;
            btn3.BackColor = System.Drawing.Color.Empty;
            btn4.BackColor = System.Drawing.Color.Empty;
            MultiView1.SetActiveView(View1);

        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            btn2.BackColor = System.Drawing.Color.FromArgb(0, 100, 174);
            btn1.BackColor = System.Drawing.Color.Empty;
            btn3.BackColor = System.Drawing.Color.Empty;
            btn4.BackColor = System.Drawing.Color.Empty;
            MultiView1.SetActiveView(View2);
        }
        protected void btn3_Click(object sender, EventArgs e)
        {
            btn3.BackColor = System.Drawing.Color.FromArgb(0, 100, 174);
            btn2.BackColor = System.Drawing.Color.Empty;
            btn1.BackColor = System.Drawing.Color.Empty;
            btn4.BackColor = System.Drawing.Color.Empty;
            MultiView1.SetActiveView(View3);
        }
        protected void btn4_Click(object sender, EventArgs e)
        {
            btn4.BackColor = System.Drawing.Color.FromArgb(0, 100, 174);
            btn2.BackColor = System.Drawing.Color.Empty;
            btn3.BackColor = System.Drawing.Color.Empty;
            btn1.BackColor = System.Drawing.Color.Empty;
            MultiView1.SetActiveView(View4);
        }

        //Fonctions auxiliaires
        protected string JourByNumber(int number)
        {
            if (number == 1)
                return ("lun");
            else if (number == 2)
                return ("mar");
            else if (number == 3)
                return ("mer");
            else if (number == 4)
                return ("jeu");
            else if (number == 5)
                return ("ven");
            else
                return ("sam");
        }
        protected string EmploisLibelle()
        {
            if (!radSubGroupA.Visible)
                return "a";
            else if (radSubGroupB.Checked)
                return "b";
            else if (radSubGroupC.Checked)
                return "c";
            else if (radSubGroupD.Checked)
                return "d";
            else if (radSubGroupE.Checked)
                return "e";
            else if (radSubGroupF.Checked)
                return "f";
            else
                return "a";
        }
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
            }
            catch(Exception)
            {
                count = 0;
            }
            ado.Close();
            return count;
        }
        protected void InsertEmploi(string libelle)
        {
            ado.Open();
            ado.Command = new SqlCommand("INSERT INTO Emploi VALUES(" + ddlGroupe.SelectedValue.ToString() + ", '" + libelle + "')", ado.Connection);
            ado.Command.ExecuteNonQuery();
            ado.Close();
        }
        protected bool SalleReserved()
        {
            ado.Command = new SqlCommand("SELECT COUNT(*) FROM Seance WHERE jour = " + int.Parse(Session["jour"].ToString()) + " AND temps = " + int.Parse(Session["temps"].ToString()) + " AND salle = " + int.Parse(ddlSalle.SelectedValue.ToString()), ado.Connection);
            ado.Open();
            int count = (int)ado.Command.ExecuteScalar();
            ado.Close();
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        protected bool FormateurReserved()
        {
            ado.Command = new SqlCommand("SELECT COUNT(*) FROM Seance WHERE jour = " + int.Parse(Session["jour"].ToString()) + " AND temps = " + int.Parse(Session["temps"].ToString()) + " AND formateur = " + int.Parse(ddlFormateur.SelectedValue.ToString()), ado.Connection);
            ado.Open();
            int count = (int)ado.Command.ExecuteScalar();
            ado.Close();
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        protected string Reservers(string target)
        {
            ado.Command = new SqlCommand("SELECT dbo." + target + "Reserver(@j, @t, @trgt)", ado.Connection);
            SqlParameter par = new SqlParameter("@j", SqlDbType.Int);
            par.Value = int.Parse(Session["jour"].ToString());
            ado.Command.Parameters.Add(par);
            par = new SqlParameter("@t", SqlDbType.Int);
            par.Value = int.Parse(Session["temps"].ToString());
            ado.Command.Parameters.Add(par);
            par = new SqlParameter("@trgt", SqlDbType.Int);
            par.Value = target == "Salle" ? int.Parse(ddlSalle.SelectedValue.ToString()) : int.Parse(ddlFormateur.SelectedValue.ToString());
            ado.Command.Parameters.Add(par);
            ado.Open();
            string res = ado.Command.ExecuteScalar().ToString();
            ado.Close();
            return res;
        }
        protected int SeanceID()
        {
            ado.Command = new SqlCommand("SELECT id FROM Emploi WHERE groupe = " + ddlGroupe.SelectedValue + " AND libelle = '" + EmploisLibelle() + "'", ado.Connection);
            ado.Open();
            int emploiId = (int)ado.Command.ExecuteScalar();
            ado.Command = new SqlCommand("SELECT id FROM Seance WHERE emploi = " + emploiId + " AND jour = " + Session["jour"] + " AND temps = " + Session["temps"], ado.Connection);
            int seanceId = (int)ado.Command.ExecuteScalar();
            ado.Close();
            return seanceId;
        }
        protected void AdjustEditControls()
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionStrng))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT formateur FROM Seance WHERE id = " + SeanceID(), con);
                string formateur = command.ExecuteScalar().ToString();
                ddlFormateurEdit.SelectedValue = formateur;
                command = new SqlCommand("SELECT module FROM Seance WHERE id = " + SeanceID(), con);
                string module = command.ExecuteScalar().ToString();
                ddlModuleEdit.SelectedValue = module;
                command = new SqlCommand("SELECT salle FROM Seance WHERE id = " + SeanceID(), con);
                string salle = command.ExecuteScalar().ToString();
                try { ddlSalleEdit.SelectedValue = salle; }
                catch (Exception) { }
                command = new SqlCommand("SELECT distance FROM Seance WHERE id = " + SeanceID(), con);
                bool distance = bool.Parse(command.ExecuteScalar().ToString());
                chkDistancielEdit.Checked = distance;
                con.Close();
            }
        }
        protected int NumberOfFirstYearGroups(int filiere)
        {
            ado.Command = new SqlCommand("SELECT COUNT(*) FROM Groupe WHERE filiere = @f and numero < 200", ado.Connection);
            SqlParameter fil = new SqlParameter("@f", SqlDbType.Int);
            fil.Value = filiere;
            ado.Command.Parameters.Add(fil);
            ado.Open();
            int count = (int)ado.Command.ExecuteScalar();
            ado.Close();
            return count;
        }
        protected int NumberOfSecondYearGroups(int filiere)
        {
            ado.Command = new SqlCommand("SELECT COUNT(*) FROM Groupe WHERE filiere = @f and numero > 200", ado.Connection);
            SqlParameter fil = new SqlParameter("@f", SqlDbType.Int);
            fil.Value = filiere;
            ado.Command.Parameters.Add(fil);
            ado.Open();
            int count = (int)ado.Command.ExecuteScalar();
            ado.Close();
            return count;
        }

        //Méthodes de remplissage/épuisement de l'emplois du temps
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
                ShowAddSeance();
            }
            catch (Exception)
            {
                ClearSeances();
                return;
            }
            ado.Close();
        }
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
                    divlun1.Style.Add("background-color", "#68217A");
                else
                    divlun1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divlun1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divlun1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                lun1Add.Visible = false;
                lun1Delete.Visible = true;
                lun1Edit.Visible = true;
            }
            else if (jour == "1" && temps == "2")
            {
                if (distance)
                    divlun2.Style.Add("background-color", "#68217A");
                else
                    divlun2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divlun2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divlun2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                lun2Add.Visible = false;
                lun2Delete.Visible = true;
                lun2Edit.Visible = true;
            }
            else if (jour == "1" && temps == "3")
            {
                if (distance)
                    divlun3.Style.Add("background-color", "#68217A");
                else
                    divlun3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divlun3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divlun3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                lun3Add.Visible = false;
                lun3Delete.Visible = true;
                lun3Edit.Visible = true;
            }
            else if (jour == "1" && temps == "4")
            {
                if (distance)
                    divlun4.Style.Add("background-color", "#68217A");
                else
                    divlun4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divlun4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divlun4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                lun4Add.Visible = false;
                lun4Delete.Visible = true;
                lun4Edit.Visible = true;
            }
            else if (jour == "2" && temps == "1")
            {
                if (distance)
                    divmar1.Style.Add("background-color", "#68217A");
                else
                    divmar1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmar1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmar1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mar1Add.Visible = false;
                mar1Delete.Visible = true;
                mar1Edit.Visible = true;
            }
            else if (jour == "2" && temps == "2")
            {
                if (distance)
                    divmar2.Style.Add("background-color", "#68217A");
                else
                    divmar2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmar2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmar2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mar2Add.Visible = false;
                mar2Delete.Visible = true;
                mar2Edit.Visible = true;
            }
            else if (jour == "2" && temps == "3")
            {
                if (distance)
                    divmar3.Style.Add("background-color", "#68217A");
                else
                    divmar3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmar3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmar3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mar3Add.Visible = false;
                mar3Delete.Visible = true;
                mar3Edit.Visible = true;
            }
            else if (jour == "2" && temps == "4")
            {
                if (distance)
                    divmar4.Style.Add("background-color", "#68217A");
                else
                    divmar4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmar4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmar4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mar4Add.Visible = false;
                mar4Delete.Visible = true;
                mar4Edit.Visible = true;
            }
            else if (jour == "3" && temps == "1")
            {
                if (distance)
                    divmer1.Style.Add("background-color", "#68217A");
                else
                    divmer1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmer1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmer1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mer1Add.Visible = false;
                mer1Delete.Visible = true;
                mer1Edit.Visible = true;
            }
            else if (jour == "3" && temps == "2")
            {
                if (distance)
                    divmer2.Style.Add("background-color", "#68217A");
                else
                    divmer2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmer2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmer2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mer2Add.Visible = false;
                mer2Delete.Visible = true;
                mer2Edit.Visible = true;
            }
            else if (jour == "3" && temps == "3")
            {
                if (distance)
                    divmer3.Style.Add("background-color", "#68217A");
                else
                    divmer3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmer3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmer3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mer3Add.Visible = false;
                mer3Delete.Visible = true;
                mer3Edit.Visible = true;
            }
            else if (jour == "3" && temps == "4")
            {
                if (distance)
                    divmer4.Style.Add("background-color", "#68217A");
                else
                    divmer4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divmer4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divmer4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                mer4Add.Visible = false;
                mer4Delete.Visible = true;
                mer4Edit.Visible = true;
            }
            else if (jour == "4" && temps == "1")
            {
                if (distance)
                    divjeu1.Style.Add("background-color", "#68217A");
                else
                    divjeu1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divjeu1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divjeu1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                jeu1Add.Visible = false;
                jeu1Delete.Visible = true;
                jeu1Edit.Visible = true;
            }
            else if (jour == "4" && temps == "2")
            {
                if (distance)
                    divjeu2.Style.Add("background-color", "#68217A");
                else
                    divjeu2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divjeu2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divjeu2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                jeu2Add.Visible = false;
                jeu2Delete.Visible = true;
                jeu2Edit.Visible = true;
            }
            else if (jour == "4" && temps == "3")
            {
                if (distance)
                    divjeu3.Style.Add("background-color", "#68217A");
                else
                    divjeu3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divjeu3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divjeu3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                jeu3Add.Visible = false;
                jeu3Delete.Visible = true;
                jeu3Edit.Visible = true;
            }
            else if (jour == "4" && temps == "4")
            {
                if (distance)
                    divjeu4.Style.Add("background-color", "#68217A");
                else
                    divjeu4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divjeu4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divjeu4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                jeu4Add.Visible = false;
                jeu4Delete.Visible = true;
                jeu4Edit.Visible = true;
            }
            else if (jour == "5" && temps == "1")
            {
                if (distance)
                    divven1.Style.Add("background-color", "#68217A");
                else
                    divven1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divven1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divven1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                ven1Add.Visible = false;
                ven1Delete.Visible = true;
                ven1Edit.Visible = true;
            }
            else if (jour == "5" && temps == "2")
            {
                if (distance)
                    divven2.Style.Add("background-color", "#68217A");
                else
                    divven2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divven2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divven2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                ven2Add.Visible = false;
                ven2Delete.Visible = true;
                ven2Edit.Visible = true;
            }
            else if (jour == "5" && temps == "3")
            {
                if (distance)
                    divven3.Style.Add("background-color", "#68217A");
                else
                    divven3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divven3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divven3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                ven3Add.Visible = false;
                ven3Delete.Visible = true;
                ven3Edit.Visible = true;
            }
            else if (jour == "5" && temps == "1")
            {
                if (distance)
                    divven4.Style.Add("background-color", "#68217A");
                else
                    divven4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divven4.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divven4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                ven4Add.Visible = false;
                ven4Delete.Visible = true;
                ven4Edit.Visible = true;
            }
            else if (jour == "6" && temps == "1")
            {
                if (distance)
                    divsam1.Style.Add("background-color", "#68217A");
                else
                    divsam1.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divsam1.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divsam1.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                sam1Add.Visible = false;
                sam1Delete.Visible = true;
                sam1Edit.Visible = true;
            }
            else if (jour == "6" && temps == "2")
            {
                if (distance)
                    divsam2.Style.Add("background-color", "#68217A");
                else
                    divsam2.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divsam2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divsam2.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                sam2Add.Visible = false;
                sam2Delete.Visible = true;
                sam2Edit.Visible = true;
            }
            else if (jour == "6" && temps == "3")
            {
                if (distance)
                    divsam3.Style.Add("background-color", "#68217A");
                else
                    divsam3.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divsam3.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divsam3.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                sam3Add.Visible = false;
                sam3Delete.Visible = true;
                sam3Edit.Visible = true;
            }
            else if (jour == "6" && temps == "4")
            {
                if (distance)
                    divsam4.Style.Add("background-color", "#68217A");
                else
                    divsam4.Style.Add("background-color", "#007ACC");
                if (salle == "")
                    divsam2.InnerHtml = formateur + "<br/>" + module + "<br/>En ligne";
                else
                    divsam4.InnerHtml = formateur + "<br/>" + module + "<br/>" + salle;
                sam4Add.Visible = false;
                sam4Delete.Visible = true;
                sam4Edit.Visible = true;
            }
        }
        protected void RenderUpdates()
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            if (!radSubGroupA.Visible)
                ddlGroupe_SelectedIndexChanged(sender, e);
            else if (radSubGroupA.Checked)
                ddlGroupe_SelectedIndexChanged(sender, e);
            else if (radSubGroupB.Checked)
                radSubGroupB_CheckedChanged(sender, e);
            else if (radSubGroupC.Checked)
                radSubGroupC_CheckedChanged(sender, e);
            else if (radSubGroupD.Checked)
                radSubGroupD_CheckedChanged(sender, e);
            else if (radSubGroupE.Checked)
                radSubGroupE_CheckedChanged(sender, e);
            else if (radSubGroupF.Checked)
                radSubGroupF_CheckedChanged(sender, e);
        }
        protected void ClearSeances(bool KeepAddSeance = false)
        {
            divlun1.InnerHtml = "";
            divlun1.Style.Add("background-color", "#2D2D30");
            divlun2.InnerHtml = "";
            divlun2.Style.Add("background-color", "#2D2D30");
            divlun3.InnerHtml = "";
            divlun3.Style.Add("background-color", "#2D2D30");
            divlun4.InnerHtml = "";
            divlun4.Style.Add("background-color", "#2D2D30");
            divmar1.InnerHtml = "";
            divmar1.Style.Add("background-color", "#2D2D30");
            divmar2.InnerHtml = "";
            divmar2.Style.Add("background-color", "#2D2D30");
            divmar3.InnerHtml = "";
            divmar3.Style.Add("background-color", "#2D2D30");
            divmar4.InnerHtml = "";
            divmar4.Style.Add("background-color", "#2D2D30");
            divmer1.InnerHtml = "";
            divmer1.Style.Add("background-color", "#2D2D30");
            divmer2.InnerHtml = "";
            divmer2.Style.Add("background-color", "#2D2D30");
            divmer3.InnerHtml = "";
            divmer3.Style.Add("background-color", "#2D2D30");
            divmer4.InnerHtml = "";
            divmer4.Style.Add("background-color", "#2D2D30");
            divjeu1.InnerHtml = "";
            divjeu1.Style.Add("background-color", "#2D2D30");
            divjeu2.InnerHtml = "";
            divjeu2.Style.Add("background-color", "#2D2D30");
            divjeu3.InnerHtml = "";
            divjeu3.Style.Add("background-color", "#2D2D30");
            divjeu4.InnerHtml = "";
            divjeu4.Style.Add("background-color", "#2D2D30");
            divven1.InnerHtml = "";
            divven1.Style.Add("background-color", "#2D2D30");
            divven2.InnerHtml = "";
            divven2.Style.Add("background-color", "#2D2D30");
            divven3.InnerHtml = "";
            divven3.Style.Add("background-color", "#2D2D30");
            divven4.InnerHtml = "";
            divven4.Style.Add("background-color", "#2D2D30");
            divsam1.InnerHtml = "";
            divsam1.Style.Add("background-color", "#2D2D30");
            divsam2.InnerHtml = "";
            divsam2.Style.Add("background-color", "#2D2D30");
            divsam3.InnerHtml = "";
            divsam3.Style.Add("background-color", "#2D2D30");
            divsam4.InnerHtml = "";
            divsam4.Style.Add("background-color", "#2D2D30");

            lun1Add.Visible = KeepAddSeance;
            lun2Add.Visible = KeepAddSeance;
            lun3Add.Visible = KeepAddSeance;
            lun4Add.Visible = KeepAddSeance;
            mar1Add.Visible = KeepAddSeance;
            mar2Add.Visible = KeepAddSeance;
            mar3Add.Visible = KeepAddSeance;
            mar4Add.Visible = KeepAddSeance;
            mer1Add.Visible = KeepAddSeance;
            mer2Add.Visible = KeepAddSeance;
            mer3Add.Visible = KeepAddSeance;
            mer4Add.Visible = KeepAddSeance;
            jeu1Add.Visible = KeepAddSeance;
            jeu2Add.Visible = KeepAddSeance;
            jeu3Add.Visible = KeepAddSeance;
            jeu4Add.Visible = KeepAddSeance;
            ven1Add.Visible = KeepAddSeance;
            ven2Add.Visible = KeepAddSeance;
            ven3Add.Visible = KeepAddSeance;
            ven4Add.Visible = KeepAddSeance;
            sam1Add.Visible = KeepAddSeance;
            sam2Add.Visible = KeepAddSeance;
            sam3Add.Visible = KeepAddSeance;
            sam4Add.Visible = KeepAddSeance;

            lun1Delete.Visible = false;
            lun2Delete.Visible = false;
            lun3Delete.Visible = false;
            lun4Delete.Visible = false;
            mar1Delete.Visible = false;
            mar2Delete.Visible = false;
            mar3Delete.Visible = false;
            mar4Delete.Visible = false;
            mer1Delete.Visible = false;
            mer2Delete.Visible = false;
            mer3Delete.Visible = false;
            mer4Delete.Visible = false;
            jeu1Delete.Visible = false;
            jeu2Delete.Visible = false;
            jeu3Delete.Visible = false;
            jeu4Delete.Visible = false;
            ven1Delete.Visible = false;
            ven2Delete.Visible = false;
            ven3Delete.Visible = false;
            ven4Delete.Visible = false;
            sam1Delete.Visible = false;
            sam2Delete.Visible = false;
            sam3Delete.Visible = false;
            sam4Delete.Visible = false;


            lun1Edit.Visible = false;
            lun2Edit.Visible = false;
            lun3Edit.Visible = false;
            lun4Edit.Visible = false;
            mar1Edit.Visible = false;
            mar2Edit.Visible = false;
            mar3Edit.Visible = false;
            mar4Edit.Visible = false;
            mer1Edit.Visible = false;
            mer2Edit.Visible = false;
            mer3Edit.Visible = false;
            mer4Edit.Visible = false;
            jeu1Edit.Visible = false;
            jeu2Edit.Visible = false;
            jeu3Edit.Visible = false;
            jeu4Edit.Visible = false;
            ven1Edit.Visible = false;
            ven2Edit.Visible = false;
            ven3Edit.Visible = false;
            ven4Edit.Visible = false;
            sam1Edit.Visible = false;
            sam2Edit.Visible = false;
            sam3Edit.Visible = false;
            sam4Edit.Visible = false;
        }

        //Méthodes des manipulations des séances
        private void InsertSeance(int module, int formateur, int salle, bool distance, int jour, int temps)
        {
            ado.Command = new SqlCommand("SELECT id from Emploi WHERE groupe = " + ddlGroupe.SelectedValue + " AND libelle = '" + EmploisLibelle() + "'", ado.Connection);
            ado.Open();
            int emploi = int.Parse(ado.Command.ExecuteScalar().ToString());
            ado.Close();
            Seance newSeance = new Seance(module, formateur, emploi, jour, temps, salle, distance);
            newSeance.Insert();
        }
        private void DeleteSeance(int jour, int temps)
        {
            ado.Command = new SqlCommand("SELECT id from Emploi WHERE groupe = " + ddlGroupe.SelectedValue + " AND libelle = '" + EmploisLibelle() + "'", ado.Connection);
            ado.Open();
            int emploi = int.Parse(ado.Command.ExecuteScalar().ToString());
            ado.Close();
            Seance newSeance = new Seance(emploi, jour, temps);
            newSeance.Delete();
        }

        //Contrôles para-emplois
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
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
                    break;
                case 1:
                    radSubGroupA.Visible = false;
                    radSubGroupB.Visible = false;
                    radSubGroupC.Visible = false;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
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
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
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
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
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
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
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
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
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
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.FromArgb(202, 81, 0);
                    btnAddSubGroup.Text = "MAX";
                    btnAddSubGroup.Enabled = false;
                    break;
                default:
                    radSubGroupA.Visible = false;
                    radSubGroupB.Visible = false;
                    radSubGroupC.Visible = false;
                    radSubGroupD.Visible = false;
                    radSubGroupE.Visible = false;
                    radSubGroupF.Visible = false;
                    btnAddSubGroup.Visible = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
                    break;
            }
        }
        protected void SwitchToDelete(bool delete = true)
        {
            btnClear.Visible = true;
            if (delete)
            {
                btnClear.Text = "Supprimer le sous-groupe";
                btnClear.CssClass = "logout";
            }
            else
            {
                btnClear.Text = "Vider tout";
                btnClear.CssClass = "clear-seances";
            }
        }
        protected void ShowAddSeance()
        {
            if (!lun1Delete.Visible)
                lun1Add.Visible = true;
            if (!lun2Delete.Visible)
                lun2Add.Visible = true;
            if (!lun3Delete.Visible)
                lun3Add.Visible = true;
            if (!lun4Delete.Visible)
                lun4Add.Visible = true;
            if (!mar1Delete.Visible)
                mar1Add.Visible = true;
            if (!mar2Delete.Visible)
                mar2Add.Visible = true;
            if (!mar3Delete.Visible)
                mar3Add.Visible = true;
            if (!mar4Delete.Visible)
                mar4Add.Visible = true;
            if (!mer1Delete.Visible)
                mer1Add.Visible = true;
            if (!mer2Delete.Visible)
                mer2Add.Visible = true;
            if (!mer3Delete.Visible)
                mer3Add.Visible = true;
            if (!mer4Delete.Visible)
                mer4Add.Visible = true;
            if (!jeu1Delete.Visible)
                jeu1Add.Visible = true;
            if (!jeu2Delete.Visible)
                jeu2Add.Visible = true;
            if (!jeu3Delete.Visible)
                jeu3Add.Visible = true;
            if (!jeu4Delete.Visible)
                jeu4Add.Visible = true;
            if (!ven1Delete.Visible)
                ven1Add.Visible = true;
            if (!ven2Delete.Visible)
                ven2Add.Visible = true;
            if (!ven3Delete.Visible)
                ven3Add.Visible = true;
            if (!ven4Delete.Visible)
                ven4Add.Visible = true;
            if (!sam1Delete.Visible)
                sam1Add.Visible = true;
            if (!sam2Delete.Visible)
                sam2Add.Visible = true;
            if (!sam3Delete.Visible)
                sam3Add.Visible = true;
            if (!sam4Delete.Visible)
                sam4Add.Visible = true;
        }

        //Évènements
        protected void ddlFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiliere.SelectedIndex == 0)
            {
                ddlGroupe.Items.Clear();
                ClearSeances();
                SubGroupControls();
                btnClear.Visible = false;
                btnAddSubGroup.Visible = false;
            }
            else
            {
                try
                {
                    ddlGroupe.DataSource = sqlGroupe;
                    ddlGroupe.DataValueField = "id";
                    ddlGroupe.DataTextField = "numero";
                    ddlGroupe.DataBind();
                    ddlGroupe_SelectedIndexChanged(sender, e);
                }
                catch (Exception) { }
            }
        }
        protected void ddlGroupe_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBySubGroup('a');
            SubGroupControls();
            SwitchToDelete(false);
        }
        protected void radSubGroupA_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupA.Checked)
                ddlGroupe_SelectedIndexChanged(sender, e);
        }
        protected void radSubGroupB_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupB.Checked)
            {
                FillBySubGroup('b');
                if (!radSubGroupC.Visible)
                {
                    SwitchToDelete();
                }
                else
                {
                    SwitchToDelete(false);
                }
            }
        }
        protected void radSubGroupC_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupC.Checked)
            {
                FillBySubGroup('c');
                if (!radSubGroupD.Visible)
                {
                    SwitchToDelete();
                }
                else
                {
                    SwitchToDelete(false);
                }
            }
        }
        protected void radSubGroupD_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupD.Checked)
            {
                FillBySubGroup('d');
                if (!radSubGroupE.Visible)
                    SwitchToDelete();
                else
                    SwitchToDelete(false);
            }
        }
        protected void radSubGroupE_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupE.Checked)
            {
                FillBySubGroup('e');
                if (!radSubGroupF.Visible)
                    SwitchToDelete();
                else
                    SwitchToDelete(false);
            }
        }
        protected void radSubGroupF_CheckedChanged(object sender, EventArgs e)
        {
            if (radSubGroupF.Checked)
            {
                FillBySubGroup('f');
                SwitchToDelete(); ;
            }
            else
            {
                SwitchToDelete(false);
            }
        }
        protected void btnAddSubGroup_Click(object sender, EventArgs e)
        {
            switch (EmploisCount())
            {
                case 0:
                    InsertEmploi("a");
                    return;
                case 1:
                    InsertEmploi("b");
                    radSubGroupA.Visible = true;
                    radSubGroupB.Visible = true;
                    radSubGroupB.Checked = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
                    FillBySubGroup('b');
                    break;
                case 2:
                    InsertEmploi("c");
                    radSubGroupA.Visible = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupC.Checked = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
                    FillBySubGroup('c');
                    break;
                case 3:
                    InsertEmploi("d");
                    radSubGroupA.Visible = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = true;
                    radSubGroupD.Checked = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
                    FillBySubGroup('d');
                    break;
                case 4:
                    InsertEmploi("e");
                    radSubGroupA.Visible = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = true;
                    radSubGroupE.Visible = true;
                    radSubGroupE.Checked = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                    btnAddSubGroup.Text = "Ajouter un sous-groupe";
                    btnAddSubGroup.Enabled = true;
                    FillBySubGroup('e');
                    break;
                case 5:
                    InsertEmploi("f");
                    radSubGroupA.Visible = true;
                    radSubGroupB.Visible = true;
                    radSubGroupC.Visible = true;
                    radSubGroupD.Visible = true;
                    radSubGroupE.Visible = true;
                    radSubGroupF.Visible = true;
                    radSubGroupF.Checked = true;
                    btnAddSubGroup.BackColor = System.Drawing.Color.FromArgb(202, 81, 0);
                    btnAddSubGroup.Text = "MAX";
                    btnAddSubGroup.Enabled = false;
                    FillBySubGroup('f');
                    break;
                default:
                    break;
            }
            SwitchToDelete();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.Text == "Vider tout")
            {
                ViderText.InnerHtml = "Voulez-vous vraiment vider tout pour ce groupe?";
                mpeVider.Show();
            }
            else if (btnClear.Text == "Supprimer le sous-groupe")
            {
                ViderText.InnerHtml = "Voulez-vous vraiment supprimer ce sous-groupe?";
                mpeVider.Show();
            }
        }

        //Évènement click des Boutons des manipulations des séances
        protected void lun1_Click(object sender, EventArgs e)
        {
            Session["jour"] = 1;
            Session["temps"] = 1;
            if (sender.Equals(lun1Add))
                AddPopup.Show();
            else if (sender.Equals(lun1Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void lun2_Click(object sender, EventArgs e)
        {
            Session["jour"] = 1;
            Session["temps"] = 2;
            if (sender.Equals(lun2Add))
                AddPopup.Show();
            else if (sender.Equals(lun2Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void lun3_Click(object sender, EventArgs e)
        {
            Session["jour"] = 1;
            Session["temps"] = 3;
            if (sender.Equals(lun3Add))
                AddPopup.Show();
            else if (sender.Equals(lun3Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void lun4_Click(object sender, EventArgs e)
        {
            Session["jour"] = 1;
            Session["temps"] = 4;
            if (sender.Equals(lun4Add))
                AddPopup.Show();
            else if (sender.Equals(lun4Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mar1_Click(object sender, EventArgs e)
        {
            Session["jour"] = 2;
            Session["temps"] = 1;
            if (sender.Equals(mar1Add))
                AddPopup.Show();
            else if (sender.Equals(mar1Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mar2_Click(object sender, EventArgs e)
        {
            Session["jour"] = 2;
            Session["temps"] = 2;
            if (sender.Equals(mar2Add))
                AddPopup.Show();
            else if (sender.Equals(mar2Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mar3_Click(object sender, EventArgs e)
        {
            Session["jour"] = 2;
            Session["temps"] = 3;
            if (sender.Equals(mar3Add))
                AddPopup.Show();
            else if (sender.Equals(mar3Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mar4_Click(object sender, EventArgs e)
        {
            Session["jour"] = 2;
            Session["temps"] = 4;
            if (sender.Equals(mar4Add))
                AddPopup.Show();
            else if (sender.Equals(mar4Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mer1_Click(object sender, EventArgs e)
        {
            Session["jour"] = 3;
            Session["temps"] = 1;
            if (sender.Equals(mer1Add))
                AddPopup.Show();
            else if (sender.Equals(mer1Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mer2_Click(object sender, EventArgs e)
        {
            Session["jour"] = 3;
            Session["temps"] = 2;
            if (sender.Equals(mer2Add))
                AddPopup.Show();
            else if (sender.Equals(mer2Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mer3_Click(object sender, EventArgs e)
        {
            Session["jour"] = 3;
            Session["temps"] = 3;
            if (sender.Equals(mer3Add))
                AddPopup.Show();
            else if (sender.Equals(mer3Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void mer4_Click(object sender, EventArgs e)
        {
            Session["jour"] = 3;
            Session["temps"] = 4;
            if (sender.Equals(mer4Add))
                AddPopup.Show();
            else if (sender.Equals(mer4Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void jeu1_Click(object sender, EventArgs e)
        {
            Session["jour"] = 4;
            Session["temps"] = 1;
            if (sender.Equals(jeu1Add))
                AddPopup.Show();
            else if (sender.Equals(jeu1Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void jeu2_Click(object sender, EventArgs e)
        {
            Session["jour"] = 4;
            Session["temps"] = 2;
            if (sender.Equals(jeu2Add))
                AddPopup.Show();
            else if (sender.Equals(jeu2Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void jeu3_Click(object sender, EventArgs e)
        {
            Session["jour"] = 4;
            Session["temps"] = 3;
            if (sender.Equals(jeu3Add))
                AddPopup.Show();
            else if (sender.Equals(jeu3Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void jeu4_Click(object sender, EventArgs e)
        {
            Session["jour"] = 4;
            Session["temps"] = 4;
            if (sender.Equals(jeu4Add))
                AddPopup.Show();
            else if (sender.Equals(jeu4Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void ven1_Click(object sender, EventArgs e)
        {
            Session["jour"] = 5;
            Session["temps"] = 1;
            if (sender.Equals(ven1Add))
                AddPopup.Show();
            else if (sender.Equals(ven1Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void ven2_Click(object sender, EventArgs e)
        {
            Session["jour"] = 5;
            Session["temps"] = 2;
            if (sender.Equals(ven2Add))
                AddPopup.Show();
            else if (sender.Equals(ven2Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void ven3_Click(object sender, EventArgs e)
        {
            Session["jour"] = 5;
            Session["temps"] = 3;
            if (sender.Equals(ven3Add))
                AddPopup.Show();
            else if (sender.Equals(ven3Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void ven4_Click(object sender, EventArgs e)
        {
            Session["jour"] = 5;
            Session["temps"] = 4;
            if (sender.Equals(ven4Add))
                AddPopup.Show();
            else if (sender.Equals(ven4Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void sam1_Click(object sender, EventArgs e)
        {
            Session["jour"] = 6;
            Session["temps"] = 1;
            if (sender.Equals(sam1Add))
                AddPopup.Show();
            else if (sender.Equals(sam1Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void sam2_Click(object sender, EventArgs e)
        {
            Session["jour"] = 6;
            Session["temps"] = 2;
            if (sender.Equals(sam2Add))
                AddPopup.Show();
            else if (sender.Equals(sam2Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void sam3_Click(object sender, EventArgs e)
        {
            Session["jour"] = 6;
            Session["temps"] = 3;
            if (sender.Equals(sam3Add))
                AddPopup.Show();
            else if (sender.Equals(sam3Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }
        protected void sam4_Click(object sender, EventArgs e)
        {
            Session["jour"] = 6;
            Session["temps"] = 4;
            if (sender.Equals(sam4Add))
                AddPopup.Show();
            else if (sender.Equals(sam4Delete))
                ConfirmDelete.Show();
            else
            {
                AdjustEditControls();
                mpeEdit.Show();
            }
        }

        //Popups évènements
        protected void btnClosePopup_Click(object sender, EventArgs e)
        {
            AddPopup.Hide();
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (FormateurReserved())
            {
                Session["reserved"] = ddlFormateur.Items[ddlFormateur.SelectedIndex].Text + " a une scéance ici avec ce groupe:<br/>" + Reservers("Formateur") + "</br>Veuillez procéder quand même?";
                messagedup.InnerHtml = Session["reserved"].ToString();
                mpeDup.Show();
                return;
            }
            if ((!chkDistanciel.Checked) && SalleReserved())
            {
                Session["reserved"] = "Cette salle (" + ddlSalle.Items[ddlSalle.SelectedIndex].Text + ") est déjà réservée ici par ce groupe:<br/>" + Reservers("Salle") + "<br/>Veuillez procéder quand même?";
                messagedup.InnerHtml = Session["reserved"].ToString();
                mpeDup.Show();
                return;
            }
            try
            {
                InsertSeance(int.Parse(ddlModule.SelectedValue.ToString()), int.Parse(ddlFormateur.SelectedValue.ToString()), chkDistanciel.Checked ? -1 : int.Parse(ddlSalle.SelectedValue.ToString()), chkDistanciel.Checked, int.Parse(Session["jour"].ToString()), int.Parse(Session["temps"].ToString()));
                RenderUpdates();
            }
            catch (Exception) { }
        }
        protected void btnExitSupp_Click(object sender, EventArgs e)
        {
            AddPopup.Hide();
        }
        protected void btnSuprOui_Click(object sender, EventArgs e)
        {
            DeleteSeance((int)Session["jour"], (int)Session["temps"]);
            RenderUpdates();
        }
        protected void btnExDup_Click(object sender, EventArgs e)
        {
            mpeDup.Hide();
        }
        protected void btnOuiDup_Click(object sender, EventArgs e)
        {
            try
            {
                InsertSeance(int.Parse(ddlModule.SelectedValue.ToString()), int.Parse(ddlFormateur.SelectedValue.ToString()), chkDistanciel.Checked ? -1 : int.Parse(ddlSalle.SelectedValue.ToString()), chkDistanciel.Checked, int.Parse(Session["jour"].ToString()), int.Parse(Session["temps"].ToString()));
                RenderUpdates();
            }
            catch (Exception) { }

        }
        protected void btnOuiVider_Click(object sender, EventArgs e)
        {
            if (btnClear.Text == "Vider tout")
            {
                SqlCommand command = new SqlCommand("DELETE Seance WHERE emploi = (SELECT E.id FROM Emploi AS E WHERE groupe = @grp AND libelle = @lib)", ado.Connection);
                SqlParameter parGroupe = new SqlParameter("@grp", SqlDbType.Int);
                parGroupe.Value = ddlGroupe.SelectedValue;
                command.Parameters.Add(parGroupe);
                SqlParameter parLibelle = new SqlParameter("@lib", SqlDbType.VarChar, 1);
                parLibelle.Value = EmploisLibelle();
                command.Parameters.Add(parLibelle);
                ado.Open();
                command.ExecuteNonQuery();
                ado.Close();
                ClearSeances(true);
            }
            else if (btnClear.Text == "Supprimer le sous-groupe")
            {
                SqlCommand command = new SqlCommand("DELETE Emploi WHERE groupe = @grp AND libelle = @lib", ado.Connection);
                SqlParameter parGroupe = new SqlParameter("@grp", SqlDbType.Int);
                parGroupe.Value = ddlGroupe.SelectedValue;
                command.Parameters.Add(parGroupe);
                SqlParameter parLibelle = new SqlParameter("@lib", SqlDbType.VarChar, 1);
                if (radSubGroupB.Checked)
                {
                    parLibelle.Value = 'b';
                    radSubGroupB.Visible = false;
                    radSubGroupA.Visible = false;
                    btnClear.Text = "Vider tout";
                    btnClear.CssClass = "clear-seances";
                    FillBySubGroup('a');
                }
                else if (radSubGroupC.Checked)
                {
                    parLibelle.Value = 'c';
                    radSubGroupC.Visible = false;
                    radSubGroupB.Checked = true;
                    FillBySubGroup('b');
                }
                else if (radSubGroupD.Checked)
                {
                    parLibelle.Value = 'd';
                    radSubGroupD.Visible = false;
                    radSubGroupC.Checked = true;
                    FillBySubGroup('c');
                }
                else if (radSubGroupE.Checked)
                {
                    parLibelle.Value = 'e';
                    radSubGroupE.Visible = false;
                    radSubGroupD.Checked = true;
                    FillBySubGroup('d');
                }
                else if (radSubGroupF.Checked)
                {
                    parLibelle.Value = 'f';
                    radSubGroupF.Visible = false;
                    radSubGroupE.Checked = true;
                    FillBySubGroup('e');
                }
                command.Parameters.Add(parLibelle);
                ado.Open();
                command.ExecuteNonQuery();
                ado.Close();
                btnAddSubGroup.BackColor = System.Drawing.Color.Empty;
                btnAddSubGroup.Text = "Ajouter un sous-groupe";
                btnAddSubGroup.Enabled = true;
            }
            
        }
        protected void btnViderExit_Click(object sender, EventArgs e)
        {
            mpeVider.Hide();
        }
        protected void btnExitEdit_Click(object sender, EventArgs e)
        {
            mpeEdit.Hide();
        }
        protected void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("UPDATE Seance SET formateur = " + ddlFormateurEdit.SelectedValue + ", module = " + ddlModuleEdit.SelectedValue + ", salle = " + (chkDistancielEdit.Checked ? "NULL" : ddlSalleEdit.SelectedValue) + ", distance = " + (chkDistancielEdit.Checked ? "1" : "0") + " WHERE id = " + SeanceID(), ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            RenderUpdates();
        }

        protected void ddlFiliereGrpMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiliereGrpMan.SelectedIndex == 0)
            {
                btnRemoveFirstYear.Visible = false;
                btnRemoveSecondYear.Visible = false;
                btnAddFirstYear.Visible = false;
                btnAddSecondYear.Visible = false;
                lblFirstYearCount.Text = "0";
                lblSecondYearCount.Text = "0";
            }
            else
            {
                btnAddFirstYear.Visible = true;
                btnAddSecondYear.Visible = true;
                lblFirstYearCount.Text = NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)).ToString();
                lblSecondYearCount.Text = NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)).ToString();
                btnRemoveFirstYear.Visible = !(NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) == 1);
                btnRemoveSecondYear.Visible = !(NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) == 0);
            }
            
        }

        protected void btnAddFirstYear_Click(object sender, EventArgs e)
        {
            if (NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) >= 1)
                btnRemoveFirstYear.Visible = true;
            else
                btnRemoveFirstYear.Visible = false;
            ado.Command = new SqlCommand("INSERT INTO Groupe(numero, filiere) VALUES(" + (101 + NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue))) + "," + ddlFiliereGrpMan.SelectedValue + ")", ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            lblFirstYearCount.Text = NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)).ToString();
            ddlGroupe.DataBind();
        }
        protected void btnAddSecondYear_Click(object sender, EventArgs e)
        {
            if (NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) >= 0)
                btnRemoveSecondYear.Visible = true;
            else
                btnRemoveSecondYear.Visible = false;
            ado.Command = new SqlCommand("INSERT INTO Groupe(numero, filiere) VALUES(" + (201 + NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue))) + "," + ddlFiliereGrpMan.SelectedValue + ")", ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            lblSecondYearCount.Text = NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)).ToString();
            ddlGroupe.DataBind();
        }
        protected void btnRemoveFirstYear_Click(object sender, EventArgs e)
        {
            if (NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) >= 2)
            {
                if (NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) == 2)
                    btnRemoveFirstYear.Visible = false;
                ado.Command = new SqlCommand("DELETE FROM Groupe WHERE numero = " + (100 + NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue))) + " AND filiere = " + ddlFiliereGrpMan.SelectedValue, ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                lblFirstYearCount.Text = NumberOfFirstYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)).ToString();
                ddlGroupe.DataBind();
            }
            else
            {
                btnRemoveSecondYear.Visible = false;
            }
        }
        protected void btnRemoveSecondYear_Click(object sender, EventArgs e)
        {
            if (NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) >= 1)
            {
                if (NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)) == 1)
                    btnRemoveSecondYear.Visible = false;
                ado.Command = new SqlCommand("DELETE FROM Groupe WHERE numero = " + (200 + NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue))) + " AND filiere = " + ddlFiliereGrpMan.SelectedValue, ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                lblSecondYearCount.Text = NumberOfSecondYearGroups(int.Parse(ddlFiliereGrpMan.SelectedValue)).ToString();
                ddlGroupe.DataBind();
            }
            else
            {
                btnRemoveSecondYear.Visible = false;
            }
        }

        protected bool AuthorizeForModule(string target = "Add")
        {
            if (target == "Add")
            {
                int count = 0;
                foreach (ListItem filiere in chkListFiliere.Items)
                {
                    if (filiere.Selected)
                        count++;
                }
                if (String.IsNullOrWhiteSpace(txtNewModule.Text) || count == 0)
                    return false;
                return true;
            }
            else
            {
                int count = 0;
                foreach (ListItem filiere in chkListFiliereMod.Items)
                {
                    if (filiere.Selected)
                        count++;
                }
                if (String.IsNullOrWhiteSpace(txtNewModuleMod.Text) || count == 0)
                    return false;
                return true;
            }
        }

        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            if (AuthorizeForModule())
            {
                lblErrorAddMod.Visible = false;
                ado.Command = new SqlCommand("INSERT INTO Module(libelle) VALUES('" + txtNewModule.Text + "')", ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                foreach (ListItem filiere in chkListFiliere.Items)
                {
                    if (filiere.Selected)
                    {
                        ado.Open();
                        ado.Command = new SqlCommand("INSERT INTO Programme(module, filiere) VALUES((SELECT IDENT_CURRENT('Module')), " + filiere.Value + ")", ado.Connection);
                        ado.Command.ExecuteNonQuery();
                        ado.Close();
                        filiere.Selected = false;
                    }
                }
                ddlModule.DataBind();
                ddlModules.DataSource = sqlModules;
                ddlModules.DataValueField = "id";
                ddlModules.DataTextField = "libelle";
                ddlModules.DataBind();
                ddlModules.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlModules.SelectedIndex = 0;
                ddlModuleEdit.DataBind();
                txtNewModule.Text = String.Empty;
                foreach (ListItem filiere in chkListFiliere.Items)
                {
                    filiere.Selected = false;
                }
            }
            else
                lblErrorAddMod.Visible = true;
        }

        protected void ddlModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModules.SelectedIndex == 0)
            {
                btnUpdateModule.Enabled = false;
                btnDeleteModule.Enabled = false;
                foreach (ListItem item in chkListFiliereMod.Items)
                {
                    item.Selected = false;
                }
                txtNewModuleMod.Text = String.Empty;
            }
            else
            {
                btnUpdateModule.Enabled = true;
                btnDeleteModule.Enabled = true;
                ado.Command = new SqlCommand("SELECT filiere FROM Programme WHERE module = " + ddlModules.SelectedValue.ToString(), ado.Connection);
                DataTable filiere = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(ado.Command);
                da.Fill(filiere);
                foreach (ListItem item in chkListFiliereMod.Items)
                {
                    item.Selected = false;
                    foreach (DataRow row in filiere.Rows)
                    {
                        if (row[0].ToString() == (item.Value).ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
                txtNewModuleMod.Text = ddlModules.SelectedItem.Text;
            }
            
        }

        protected void btnUpdateModule_Click(object sender, EventArgs e)
        {
            if (AuthorizeForModule("Update"))
            {
                lblErrorEditMod.Visible = false;
                ado.Command = new SqlCommand("UPDATE Module SET libelle = '" + txtNewModuleMod.Text + "' WHERE id = " + ddlModules.SelectedValue.ToString(), ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Command = new SqlCommand("DELETE Programme WHERE module = " + ddlModules.SelectedValue.ToString(), ado.Connection);
                ado.Command.ExecuteNonQuery();
                foreach (ListItem filiere in chkListFiliereMod.Items)
                {
                    if (filiere.Selected)
                    {
                        ado.Command = new SqlCommand("INSERT INTO Programme(module, filiere) VALUES(" + ddlModules.SelectedValue.ToString() + ", " + filiere.Value + ")", ado.Connection);
                        ado.Command.ExecuteNonQuery();
                        filiere.Selected = false;
                    }
                }
                ado.Close();
                ddlModule.DataBind();
                ddlModuleEdit.DataBind();
                ddlModules.DataSource = sqlModules;
                ddlModules.DataValueField = "id";
                ddlModules.DataTextField = "libelle";
                ddlModules.DataBind();
                ddlModules.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlModules.SelectedIndex = 0;
                txtNewModuleMod.Text = String.Empty;
                foreach (ListItem filiere in chkListFiliereMod.Items)
                {
                    filiere.Selected = false;
                }
            }
            else
                lblErrorEditMod.Visible = true;
            
        }

        protected void btnDeleteModule_Click(object sender, EventArgs e)
        {
            btnDeleteModule.Visible = false;
            btnConfirmNon.Visible = true;
            btnConfirmYes.Visible = true;
        }

        protected void btnNonDM_Click(object sender, EventArgs e)
        {
            btnConfirmNon.Visible = false;
            btnConfirmYes.Visible = false;
            btnDeleteModule.Visible = true;
        }

        protected void btnOuiDM_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("DELETE Module WHERE id = " + ddlModules.SelectedValue.ToString(), ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            ddlModule.DataBind();
            ddlModules.DataSource = sqlModules;
            ddlModules.DataValueField = "id";
            ddlModules.DataTextField = "libelle";
            ddlModules.DataBind();
            ddlModules.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlModules.SelectedIndex = 0;
            ddlModuleEdit.DataBind();
            txtNewModuleMod.Text = String.Empty;
            foreach (ListItem filiere in chkListFiliereMod.Items)
            {
                filiere.Selected = false;
            }
        }

        protected bool AuthorizeForFormateur(string target = "Add")
        {
            if (target == "Add")
            {
                int count = 0;
                foreach (ListItem filiere in chkFilieresFormateur.Items)
                {
                    if (filiere.Selected)
                        count++;
                }
                if (String.IsNullOrWhiteSpace(txtPrenom.Text) || String.IsNullOrWhiteSpace(txtNom.Text) || count == 0)
                    return false;
                return true;
            }
            else
            {
                int count = 0;
                foreach (ListItem filiere in chkFilieresFormateurMod.Items)
                {
                    if (filiere.Selected)
                        count++;
                }
                if (String.IsNullOrWhiteSpace(txtPrenomMod.Text) || String.IsNullOrWhiteSpace(txtNomMod.Text) || count == 0)
                    return false;
                return true;
            }
        }
        protected bool AuthorizeForFiliere(string target = "Add")
        {
            if (target == "Add")
                return (!(String.IsNullOrWhiteSpace(txtNewFiliereAbr.Text) || String.IsNullOrWhiteSpace(txtNewFiliereNom.Text)));
            else
                return (!(String.IsNullOrWhiteSpace(txtEditFiliereAbr.Text) || String.IsNullOrWhiteSpace(txtEditFiliereNom.Text)));
        }

        protected void btnAddFormateur_Click(object sender, EventArgs e)
        {
            if (AuthorizeForFormateur())
            {
                lblFormateurAddError.Visible = false;
                ado.Command = new SqlCommand("INSERT INTO Formateur(civilite, prenom, nom) VALUES('" + ddlCivilite.SelectedItem.Text + "', '" + txtPrenom.Text + "', '" + txtNom.Text + "')", ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                foreach (ListItem filiere in chkFilieresFormateur.Items)
                {
                    if (filiere.Selected)
                    {
                        ado.Open();
                        ado.Command = new SqlCommand("INSERT INTO Specialite(formateur, filiere) VALUES((SELECT IDENT_CURRENT('Formateur')), " + filiere.Value + ")", ado.Connection);
                        ado.Command.ExecuteNonQuery();
                        ado.Close();
                        filiere.Selected = false;
                    }
                }
                ddlFormateurs.DataSource = sqlEditFormateur;
                ddlFormateurs.DataValueField = "id";
                ddlFormateurs.DataTextField = "nomcomplet";
                ddlFormateurs.DataBind();
                ddlFormateurs.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFormateurs.SelectedIndex = 0;
                ddlFormateur.DataBind();
                ddlFormateurEdit.DataBind();
                txtNom.Text = String.Empty;
                txtPrenom.Text = String.Empty;
                foreach (ListItem filiere in chkFilieresFormateur.Items)
                {
                    filiere.Selected = false;
                }
            }
            else
                lblFormateurAddError.Visible = true;
        }

        protected void btnEditFormateur_Click(object sender, EventArgs e)
        {
            if (AuthorizeForFormateur("Update"))
            {
                lblFormateurEditError.Visible = false;
                ado.Command = new SqlCommand("UPDATE Formateur SET nom = '" + txtNomMod.Text + "', prenom = '" + txtPrenomMod.Text + "', civilite = '" + ddlCiviliteMod.SelectedItem.Text + "' WHERE id = " + ddlFormateurs.SelectedValue.ToString(), ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Command = new SqlCommand("DELETE Specialite WHERE formateur = " + ddlFormateurs.SelectedValue.ToString(), ado.Connection);
                ado.Command.ExecuteNonQuery();
                foreach (ListItem filiere in chkFilieresFormateurMod.Items)
                {
                    if (filiere.Selected)
                    {
                        ado.Command = new SqlCommand("INSERT INTO Specialite(formateur, filiere) VALUES(" + ddlFormateurs.SelectedValue.ToString() + ", " + filiere.Value + ")", ado.Connection);
                        ado.Command.ExecuteNonQuery();
                        filiere.Selected = false;
                    }
                }
                ado.Close();
                ddlFormateurs.DataSource = sqlEditFormateur;
                ddlFormateurs.DataValueField = "id";
                ddlFormateurs.DataTextField = "nomcomplet";
                ddlFormateurs.DataBind();
                ddlFormateurs.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlFormateurs.SelectedIndex = 0;
                ddlFormateur.DataBind();
                ddlFormateurEdit.DataBind();
                foreach (ListItem filiere in chkFilieresFormateurMod.Items)
                {
                    filiere.Selected = false;
                }
                txtNomMod.Text = String.Empty;
                txtPrenomMod.Text = String.Empty;
                ddlCiviliteMod.SelectedIndex = 0;
            }
            else
                lblFormateurEditError.Visible = true;
        }

        protected void ddlFormateurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnDeleteFormateur.Enabled = true;
                btnEditFormateur.Enabled = true;
                ado.Command = new SqlCommand("SELECT filiere FROM Specialite WHERE formateur = " + ddlFormateurs.SelectedValue.ToString(), ado.Connection);
                DataTable filiere = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(ado.Command);
                da.Fill(filiere);
                foreach (ListItem item in chkFilieresFormateurMod.Items)
                {
                    item.Selected = false;
                    foreach (DataRow row in filiere.Rows)
                    {
                        if (row[0].ToString() == (item.Value).ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
                DataTable formateur = new DataTable();
                ado.Command = new SqlCommand("SELECT nom, prenom, civilite FROM Formateur WHERE id = " + ddlFormateurs.SelectedValue.ToString(), ado.Connection);
                da = new SqlDataAdapter(ado.Command);
                da.Fill(formateur);
                txtNomMod.Text = formateur.Rows[0][0].ToString();
                txtPrenomMod.Text = formateur.Rows[0][1].ToString();
                if (formateur.Rows[0][2].ToString() == "Monsieur")
                    ddlCiviliteMod.SelectedIndex = 0;
                else if (formateur.Rows[0][2].ToString() == "Madame")
                    ddlCiviliteMod.SelectedIndex = 1;
                else
                    ddlCiviliteMod.SelectedIndex = 2;
            }
            catch (Exception)
            {
                btnEditFormateur.Enabled = false;
                btnDeleteFormateur.Enabled = false;
                foreach (ListItem item in chkFilieresFormateurMod.Items)
                {
                    item.Selected = false;
                }
                ddlCivilite.SelectedIndex = 0;
                txtPrenomMod.Text = String.Empty;
                txtNomMod.Text = String.Empty;
            }
        }

        protected void btnDeleteFormateur_Click(object sender, EventArgs e)
        {
            btnDeleteFormateur.Visible = false;
            btnOuiFormateur.Visible = true;
            btnNonFormateur.Visible = true;
        }

        protected void btnNonFormateur_Click(object sender, EventArgs e)
        {
            btnNonFormateur.Visible = false;
            btnOuiFormateur.Visible = false;
            btnDeleteFormateur.Visible = true;
        }

        protected void btnOuiFormateur_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("DELETE Formateur WHERE id = " + ddlFormateurs.SelectedValue.ToString(), ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            ddlFormateur.DataBind();
            ddlFormateurs.DataSource = sqlEditFormateur;
            ddlFormateurs.DataValueField = "id";
            ddlFormateurs.DataTextField = "nomcomplet";
            ddlFormateurs.DataBind();
            ddlFormateurs.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlFormateurs.SelectedIndex = 0;
            ddlFormateurEdit.DataBind();
            txtNomMod.Text = String.Empty;
            txtPrenomMod.Text = String.Empty;
            ddlCiviliteMod.SelectedIndex = 0;
            foreach (ListItem filiere in chkFilieresFormateurMod.Items)
            {
                filiere.Selected = false;
            }
        }

        protected void RefreshFiliereControls()
        {
            ddlFiliere.DataSource = sqlFiliere;
            ddlFiliere.DataValueField = "id";
            ddlFiliere.DataTextField = "initiales";
            ddlFiliere.DataBind();
            ddlFiliere.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlFiliere.SelectedIndex = 0;

            ddlFiliereGrpMan.DataSource = sqlFiliere;
            ddlFiliereGrpMan.DataValueField = "id";
            ddlFiliereGrpMan.DataTextField = "initiales";
            ddlFiliereGrpMan.DataBind();
            ddlFiliereGrpMan.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlFiliereGrpMan.SelectedIndex = 0;

            chkFilieresFormateur.DataBind();
            chkFilieresFormateurMod.DataBind();
            chkListFiliere.DataBind();
            chkListFiliereMod.DataBind();

            ddlFilieres.DataSource = sqlFilieres;
            ddlFilieres.DataValueField = "id";
            ddlFilieres.DataTextField = "fullname";
            ddlFilieres.DataBind();
            ddlFilieres.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlFilieres.SelectedIndex = 0;
        }
        protected void RefreshSalleControls()
        {
            ddlSalle.DataBind();
            ddlSalleEdit.DataBind();

            ddlSalles.DataSource = sqlSalles;
            ddlSalles.DataValueField = "id";
            ddlSalles.DataTextField = "libelle";
            ddlSalles.DataBind();
            ddlSalles.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlSalles.SelectedIndex = 0;
        }
        protected bool AuthorizeForSalle(string target = "Add")
        {
            if (target == "Add")
                return (!String.IsNullOrWhiteSpace(txtAddSalleLibelle.Text));
            else
                return (!String.IsNullOrWhiteSpace(txtEditSalleLibelle.Text));
        }


        protected void btnAddFiliere_Click(object sender, EventArgs e)
        {
            if (AuthorizeForFiliere())
            {
                lblAddFiliereError.Visible = false;
                ado.Command = new SqlCommand("INSERT INTO Filiere(libelle, initiales) VALUES('" + txtNewFiliereNom.Text + "', '" + txtNewFiliereAbr.Text + "')", ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                RefreshFiliereControls();
                txtNewFiliereAbr.Text = String.Empty;
                txtNewFiliereNom.Text = String.Empty;
            }
            else
                lblAddFiliereError.Visible = true;
        }

        protected void ddlFilieres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFilieres.SelectedIndex > 0)
            {
                btnSaveEditsFiliere.Enabled = true;
                btnDeleteFiliere.Enabled = true;
                SqlDataAdapter da = new SqlDataAdapter(ado.Command);
                DataTable filiere = new DataTable();
                ado.Command = new SqlCommand("SELECT libelle, initiales FROM Filiere WHERE id = " + ddlFilieres.SelectedValue.ToString(), ado.Connection);
                da = new SqlDataAdapter(ado.Command);
                da.Fill(filiere);
                txtEditFiliereNom.Text = filiere.Rows[0][0].ToString();
                txtEditFiliereAbr.Text = filiere.Rows[0][1].ToString();
            }
            else
            {
                btnSaveEditsFiliere.Enabled = false;
                btnDeleteFiliere.Enabled = false;
                txtEditFiliereNom.Text = String.Empty;
                txtEditFiliereAbr.Text = String.Empty;
            }
        }

        protected void btnDeleteFiliere_Click(object sender, EventArgs e)
        {
            btnDeleteFiliere.Visible = false;
            btnOuiDeleteFiliere.Visible = true;
            btnNonDeleteFiliere.Visible = true;
        }

        protected void btnOuiDeleteFiliere_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("DELETE Filiere WHERE id = " + ddlFilieres.SelectedValue.ToString(), ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            RefreshFiliereControls();
            txtEditFiliereAbr.Text = String.Empty;
            txtEditFiliereNom.Text = String.Empty;
        }

        protected void btnNonDeleteFiliere_Click(object sender, EventArgs e)
        {
            btnOuiDeleteFiliere.Visible = false;
            btnNonDeleteFiliere.Visible = false;
            btnDeleteFiliere.Visible = true;
        }

        protected void btnSaveEditsFiliere_Click(object sender, EventArgs e)
        {
            if (AuthorizeForFiliere("Edit"))
            {
                lblEditFiliereError.Visible = false;
                ado.Command = new SqlCommand("UPDATE Filiere SET libelle = '" + txtEditFiliereNom.Text + "', initiales = '" + txtEditFiliereAbr.Text + "' WHERE id = " + ddlFilieres.SelectedValue.ToString() , ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                RefreshFiliereControls();
                txtEditFiliereAbr.Text = String.Empty;
                txtEditFiliereNom.Text = String.Empty;
            }
            else
                lblEditFiliereError.Visible = true;
        }

        protected void btnNewSalle_Click(object sender, EventArgs e)
        {
            if (AuthorizeForSalle())
            {
                lblAddSalleError.Visible = false;
                ado.Command = new SqlCommand("INSERT INTO Salle(libelle) VALUES('" + txtAddSalleLibelle.Text + "')", ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                RefreshSalleControls();
                txtAddSalleLibelle.Text = String.Empty;
            }
            else
                lblAddSalleError.Visible = true;
        }

        protected void ddlSalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSalles.SelectedIndex > 0)
            {
                btnSaveEditsSalle.Enabled = true;
                btnDeleteSalle.Enabled = true;
                SqlDataAdapter da = new SqlDataAdapter(ado.Command);
                DataTable salle = new DataTable();
                ado.Command = new SqlCommand("SELECT libelle FROM Salle WHERE id = " + ddlSalles.SelectedValue.ToString(), ado.Connection);
                da = new SqlDataAdapter(ado.Command);
                da.Fill(salle);
                txtEditSalleLibelle.Text = salle.Rows[0][0].ToString();
            }
            else
            {
                btnSaveEditsSalle.Enabled = false;
                btnDeleteSalle.Enabled = false;
                txtEditSalleLibelle.Text = String.Empty;
            }
        }

        protected void btnSaveEditsSalle_Click(object sender, EventArgs e)
        {
            if (AuthorizeForSalle("Edit"))
            {
                lblEditSalleError.Visible = false;
                ado.Command = new SqlCommand("UPDATE Salle SET libelle = '" + txtEditSalleLibelle.Text + "' WHERE id = " + ddlSalles.SelectedValue.ToString(), ado.Connection);
                ado.Open();
                ado.Command.ExecuteNonQuery();
                ado.Close();
                RefreshSalleControls();
                txtEditSalleLibelle.Text = String.Empty;
            }
            else
                lblEditSalleError.Visible = true;
        }

        protected void btnDeleteSalle_Click(object sender, EventArgs e)
        {
            btnDeleteSalle.Visible = false;
            btnOuiSalle.Visible = true;
            btnNonSalle.Visible = true;
        }

        protected void btnNonSalle_Click(object sender, EventArgs e)
        {
            btnOuiSalle.Visible = false;
            btnNonSalle.Visible = false;
            btnDeleteSalle.Visible = true;
        }

        protected void btnOuiSalle_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("DELETE Salle WHERE id = " + ddlSalles.SelectedValue.ToString(), ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            RefreshSalleControls();
            txtEditSalleLibelle.Text = String.Empty;
        }

        protected void btnUpdateAnnonce_Click(object sender, EventArgs e)
        {
            Application["Annonce"] = txtAnnonce.Text;
            Application["Important"] = chkImportant.Checked;
        }

        protected void btnDefaultAnnonce_Click(object sender, EventArgs e)
        {
            txtAnnonce.Text = "Consulter les emplois du temps de l'ISTA Hay Riad, Rabat.";
            chkImportant.Checked = false;
            btnUpdateAnnonce_Click(sender, e);
        }

        protected void btnUpdateSecurity_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("UPDATE Administrateur SET username = '" + txtUser.Text + "', passcode = '" + txtConf.Text + "'", ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            lblReset.Visible = false;
        }

        protected void btnDefaultSecurity_Click(object sender, EventArgs e)
        {
            ado.Command = new SqlCommand("UPDATE Administrateur SET username = 'HR_Admin', passcode = 'HR2021@@'", ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
            lblReset.Visible = true;
        }
    }
}