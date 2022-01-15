using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HR_Emplois
{
    public class Seance
    {
        public int module { get; set; }
        public int formateur { get; set; }
        public int emploi { get; set; }
        public int jour { get; set; }
        public int temps { get; set; }
        public int salle { get; set; }
        public bool distance { get; set; }

        public Seance(int module, int formateur, int emploi, int jour, int temps, int salle, bool distance)
        {
            this.module = module;
            this.formateur = formateur;
            this.emploi = emploi;
            this.jour = jour;
            this.temps = temps;
            this.salle = salle;
            this.distance = distance;
        }

        public Seance(int module, int formateur, int salle, bool distance)
        {
            this.module = module;
            this.formateur = formateur;
            this.salle = salle;
            this.distance = distance;
        }

        public Seance(int emploi, int jour, int temps)
        {
            this.emploi = emploi;
            this.jour = jour;
            this.temps = temps;
        }

        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionStrng);

        public void Insert()
        {
            SqlCommand command = new SqlCommand("INSERT INTO Seance Values(" + this.module + ", " + this.formateur + ", " + this.emploi + ", " + this.jour + ", " + this.temps + ", " + (this.salle == -1 ? "NULL" : this.salle.ToString()) + ", " + (this.distance ? "1" : "0") + ")", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            SqlCommand command = new SqlCommand("DELETE Seance WHERE emploi = " + this.emploi + " AND jour = " + this.jour + " AND temps = " + this.temps, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            SqlCommand command = new SqlCommand("UPDATE Seance SET module = " + this.module + " formateur = " + this.formateur + " salle = " + (this.salle == -1 ? "NULL" : this.salle.ToString()) + " distance = " + (this.distance ? "1" : "0") + " WHERE emploi = " + this.emploi + " AND jour = " + this.jour + " AND temps = " + this.temps, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}