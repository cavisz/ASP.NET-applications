using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

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
        string _usuario = txt_usuario.Text;
        string _senha = GetMd5Base64Pass(txt_senha.Text);
        int _sistema = 864;
        //string senha = txt_senha.Text;


        try
        {
            ServiceReference1.AutenticateSoapClient proxy = new ServiceReference1.AutenticateSoapClient();
            string sr = proxy.AutenticarUsuario(_usuario, _senha, _sistema).ToString();

            string sql = "SELECT login_teste.usuario, login_teste.status, login_teste.login" +
                               " FROM login_teste" +
                               " WHERE login_teste.status = 'ativo' and login = @login";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", txt_usuario.Text);
            MySqlDataReader rdr = cmd.ExecuteReader();


            if (rdr.Read())
            {
                FormsAuthentication.RedirectFromLoginPage(txt_usuario.Text, false);
                Response.Redirect("Default2.aspx", true);
            }
            else
            {
                txt_usuario.Text = "";
                MessageBox.ShowMessage("Senha ou usuário inválido");

            }
        }
        catch
        {
            MessageBox.ShowMessage("Login Inválido");
        }
        finally
        {
            conn.Close();
        }
    }
    private static string GetMd5Base64Pass(string userpwd)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        return Convert.ToBase64String(md5.ComputeHash(Encoding.ASCII.GetBytes(userpwd)));
    }
}
