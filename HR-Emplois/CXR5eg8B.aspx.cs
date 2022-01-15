using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

namespace HR_Emplois.Admin
{
    public partial class CXR5eg8B : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["User"].ToString() == "Admin")
            {
                Response.Redirect("Admin/DcQ24Dsk.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblAnnonce")).Text = Application["Annonce"].ToString();
            ((HtmlGenericControl)Master.FindControl("annonceback")).Style.Add("background-color", (bool)Application["Important"] ? "#E81123" : "#313131");
        }

        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionStrng);
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Administrateur WHERE username = @user AND passcode = @pass", connection);
            SqlParameter parUser = new SqlParameter("@user", SqlDbType.VarChar);
            SqlParameter parPass = new SqlParameter("@pass", SqlDbType.VarChar);
            parUser.Value = txtLogin.Text.Trim();
            parPass.Value = txtPassword.Text;
            command.Parameters.Add(parUser);
            command.Parameters.Add(parPass);
            connection.Open();
            string exist = command.ExecuteScalar().ToString();
            if (exist == "1")
            {
                Session["User"] = "Admin";
                Response.Redirect("Admin/DcQ24Dsk.aspx"); 
            }
            else
            {
                lblError.Visible = true;
                Session["User"] = "Anonymous";
            }
            connection.Close();
        }
    }
}