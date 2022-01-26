using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Locais : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carrega_local();
        }
    }

    protected void btn_adicionar_local_Click(object sender, EventArgs e)
    {
        Session["cdlocal"] = 0;
        Response.Redirect("LocaisEditar.aspx");
    }

    protected void gridLocais_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["cdlocal"] = gridLocais.SelectedDataKey.Value;
        Response.Redirect("LocaisEditar.aspx");
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void carrega_local()
    {
        string sql = "SELECT local_c.LOCA_STR_SIGLA," +
                        " local_c.LOCA_STR_DESCRICAO," +
                        " local_c.LOCA_INT_CODIGO" +
                        " FROM local_c" +
                        " ORDER BY local_c.LOCA_STR_DESCRICAO ASC";

        try
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);

            gridLocais.DataSource = dataTable;
            gridLocais.DataBind();

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
}
