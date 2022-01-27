using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pessoas : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carrega_grid();
        }
    }

    protected void carrega_grid()
    {
        string sql = "SELECT pessoal_c.PESS_INT_CODIGO," +
                        " pessoal_c.PESS_STR_NOME" +
                        " FROM pessoal_c" +
                        " ORDER BY pessoal_c.PESS_STR_NOME ASC";
        try
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);

            gridPessoas.DataSource = dataTable;
            gridPessoas.DataBind();

            da.Dispose();

        }
        catch (MySqlException ex)
        {
            MessageBox1.ShowMessage(ex.Message);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    protected void gridPessoas_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["cdpessoa"] = gridPessoas.SelectedDataKey.Value;
        Response.Redirect("PessoasEditar.aspx");
    }

    protected void gridPessoas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridPessoas.PageIndex = e.NewPageIndex;
        carrega_grid();
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btn_adicionar_pessoa_Click(object sender, EventArgs e)
    {
        Session["cdpessoa"] = 0;
        Response.Redirect("PessoasEditar.aspx");
    }

}
