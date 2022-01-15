using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Emplois
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            lblAnnonce.Text = Application["Annonce"].ToString();
            annonceback.Style.Add("background-color", (bool)Application["Important"] ? "#E81123" : "#313131");
        }
    }
}