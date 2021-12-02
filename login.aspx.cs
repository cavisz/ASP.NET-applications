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
        if (Response.IsClientConnected)//relacionar a function login e verificar mysql
        {
            Response.Redirect("Default2.aspx", false);
        }
        else
        {
            Response.End();
            txt_usuario.Text = "";
        }
    }

    protected void btn_submeter_login()
    {
        string sql = "SELECT login_teste.usuario, login_teste.senha" +
                          " FROM login_teste" +
                          " WHERE usuario = @usuario and senha = @senha";

        if (txt_usuario.Text != "" && txt_senha.Text != "")
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@usuario", txt_usuario.Text);
                cmd.Parameters.AddWithValue("@senha", txt_senha.Text);
                cmd.ExecuteNonQuery();

                if (rdr.Read())
                {
                    txt_usuario.Text = rdr["usuario"].ToString();
                    txt_senha.Text = rdr["senha"].ToString();
                }
                else
                {
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
        else
        {
            MessageBox.ShowMessage("Usuário ou senha vazio");
        }
    }


    protected void btn_submeter_Click(object sender, EventArgs e)
    {
        btn_submeter_login();
    }
}
