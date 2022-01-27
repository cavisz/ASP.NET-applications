using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_pessoas_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Pessoas.aspx");
    }

    protected void btn_departamentos_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Departamentos.aspx");
    }

    protected void btn_cargos_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Cargos.aspx");
    }

    protected void btn_locais_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Locais.aspx");
    }

    protected void btn_sair_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Login.aspx");
    }
}
