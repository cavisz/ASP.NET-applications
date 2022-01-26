using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Entrar_Click(object sender, EventArgs e)
    {
        string sql = "SELECT usuarios.USUA_STR_LOGIN," +
                       " usuarios.USUA_STR_SENHA" +
                       " FROM usuarios" +
                       " Where USUA_STR_LOGIN = @login and USUA_STR_SENHA = @senha";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", txt_usuario.Text);
            cmd.Parameters.AddWithValue("@senha", txt_senha.Text);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                FormsAuthentication.RedirectFromLoginPage(txt_usuario.Text, false);
                Response.Redirect("Default.aspx", true);
            }
            else
            {
                txt_usuario.Text = "";
                MessageBox1.ShowMessage("Senha ou usuário inválido");

            }
        }
        catch
        {
            MessageBox1.ShowMessage("Login Inválido");
        }
        finally
        {
            conn.Close();
        }
    }
}
