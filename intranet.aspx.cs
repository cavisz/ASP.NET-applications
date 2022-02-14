using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Intranet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btn_noticias_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Noticias.aspx");
    }

    protected void btn_formularios_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn_sistemas_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn_acesso_rapido_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn_manuais_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn_logout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
}
