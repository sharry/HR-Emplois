using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HR_Emplois
{
    public partial class RS5c3bbE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ADO ado = new ADO();
            ado.Command = new SqlCommand("UPDATE Administrateur SET username = 'HR_Admin', passcode = 'HR2021@@'", ado.Connection);
            ado.Open();
            ado.Command.ExecuteNonQuery();
            ado.Close();
        }
    }
}