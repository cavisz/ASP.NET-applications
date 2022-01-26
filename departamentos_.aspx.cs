using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departamentos : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carrega_grid();
        }

    }

    protected void btn_adicionar_departamento_Click(object sender, EventArgs e)
    {
        Session["cddepartamento"] = 0;
        Response.Redirect("DepartamentosEditar.aspx");
    }

    protected void gridDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["cddepartamento"] = gridDepartamentos.SelectedDataKey.Value;
        Response.Redirect("DepartamentosEditar.aspx");
    }

    protected void carrega_grid()
    {
        string sql = "SELECT depto_c.DEPA_INT_CODIGO," +
                        " depto_c.DEPA_STR_DESCRICAO," +
                        " depto_c.DEPA_STR_SIGLA" +
                        " FROM depto_c" +
                        " ORDER BY depto_c.DEPA_STR_DESCRICAO ASC";
        try
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);

            gridDepartamentos.DataSource = dataTable;
            gridDepartamentos.DataBind();

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
