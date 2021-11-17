using System;
public partial class Default2 : System.Web.UI.Page
{
    MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string texto = "SELECT pessoal_c.PESS_STR_NOME, " +
      " pessoal_.c.PESS_INT_CODIGO," +
      " pessoal_c.PESS_STR_EMAIL," +
      " pessoal_c.PESS_STR_TELEFONE" +
      " FROM pessoal_c" +
      " ORDER BY pessoal_c.PESS_STR_NOME ASC";

        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
using System;
public partial class Default2 : System.Web.UI.Page
{
    MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string texto = "SELECT pessoal_c.PESS_STR_NOME, " +
      " pessoal_.c.PESS_INT_CODIGO," +
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


    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        string commandName = e.CommandName;

        if (commandName == "Editar")
        {
           
           
        }
    }
    protected void pesquisa(object sender, EventArgs e)
    {
        string texto = "SELECT pessoal_c.PESS_STR_NOME, " +
             " pessoal_.c.PESS_INT_CODIGO," +
             " pessoal_c.PESS_STR_EMAIL," +
             " pessoal_c.PESS_STR_TELEFONE" +
             " FROM pessoal_c" +
             " WHERE pessoal_.c.PESS_INT_CODIGO LIKE @Id" +
             " ORDER BY pessoal_c.PESS_STR_NOME ASC";


        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);
            cmd.Parameters.AddWithValue("@Id", CommandArgument.ToString());

            MySqlDataReader rdr = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();



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
