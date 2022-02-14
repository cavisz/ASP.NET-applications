using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn_intranet"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["srch"]))
         {

         }
    }

    protected void btn_pesquisa_Click(object sender, EventArgs e)
    {
        var searchText = Server.UrlEncode(txt_pesquisa.Text);
        Response.Redirect("~/Default.aspx?srch=" + searchText);
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
