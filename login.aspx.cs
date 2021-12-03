using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }


    protected void btn_submeter_Click1(object sender, EventArgs e)
    {
        string sql = "SELECT login_teste.usuario, login_teste.senha" +
                                 " FROM login_teste" +
                                 " WHERE usuario = @usuario and senha = @senha";
        MessageBox.ShowMessage("Senha ou usuário inválido");
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@usuario", txt_usuario.Text);
            cmd.Parameters.AddWithValue("@senha", txt_senha.Text);
            MySqlDataReader rdr = cmd.ExecuteReader();
           

            if (rdr.Read())
            {
                Response.Redirect("Default2.aspx");

            }
            else
            {
                txt_usuario.Text = "";
                MessageBox.ShowMessage("Senha ou usuário inválido");
            }
        }
        catch
        {
        }
        finally
        {
            conn.Close();
        }
    }
}
