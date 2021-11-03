using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        string texto = "SELECT pessoal_c.PESS_STR_NOME, " +
            " pessoal_c.PESS_STR_EMAIL," +
            " pessoal_c.PESS_STR_TELEFONE" +
            " FROM pessoal_c" +
            " ORDER BY pessoal_c.PESS_STR_NOME ASC";

        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch (MySqlException ex)
        {
        }
        finally
        {
            conexao.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string texto2 = "SELECT pessoal_c.PESS_STR_NOME, " +
            " pessoal_c.PESS_STR_EMAIL," +
            " pessoal_c.PESS_STR_TELEFONE" +
            " FROM pessoal_c " +
            " WHERE pessoal_c.PESS_STR_NOME LIKE @pessoa";

        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto2, conexao);
            cmd.Parameters.AddWithValue("@pessoa", "%" + TextBox1.Text + "%");
            MySqlDataReader rdr = cmd.ExecuteReader();

            GridView1.DataSource = rdr;
            GridView1.DataBind();
        }
        catch (MySqlException ex)
        {
        }
        finally
        {
            conexao.Close();
        }

    }
}
