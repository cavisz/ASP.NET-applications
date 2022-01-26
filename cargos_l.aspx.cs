using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cargos : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carrega_cargos();
        }
    }

    protected void btn_adicionar_cargo_Click(object sender, EventArgs e)
    {
        Session["cdcargo"] = 0;
        Response.Redirect("CargosEditar.aspx");
    }

    protected void gridCargos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["cdcargo"] = gridCargos.SelectedDataKey.Value;
        Response.Redirect("CargosEditar.aspx");
    }
    protected void carrega_cargos()
    {
        string sql = "SELECT cargo_c.CARG_INT_CODIGO," +
                       " cargo_c.CARG_STR_DESCRICAO" +
                       " FROM cargo_c" +
                       " ORDER BY cargo_c.CARG_STR_DESCRICAO ASC";
        try
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);

            gridCargos.DataSource = dataTable;
            gridCargos.DataBind();

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

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
