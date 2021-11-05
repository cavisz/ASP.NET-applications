using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
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

    protected void Button1(object sender, EventArgs e)
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

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
}

protected void bnt_Editar(object sender, GridViewEditEventArgs e)
{
    MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString);

    string texto3 = "SELECT pessoal_c.PESS_STR_NOME, " +
          " pessoal_c.PESS_STR_EMAIL," +
          " pessoal_c.PESS_STR_TELEFONE" +
          " FROM pessoal_c";

    try
    {
        conexao.Open();

        MySqlCommand cmd = new MySqlCommand(texto3, conexao);

        cmd.CommandText = "INSERT INTO pessoal_c VALUES (@Nome, @Telefone, @Email)";

        cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
        cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

        cmd.ExecuteNonQuery();
        cmd.Dispose();
        //GridView1.EditIndex = -1;
        //BindGridView(); btnUpdate.Visible = false;
    }
    catch (MySqlException ex)
    {

    }
    finally
    {
        conexao.Close();
    }
}
