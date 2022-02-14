using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NoticiasEditar : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn_intranet"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carrega_grid();
        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Intranet.aspx");
    }

    protected void carrega_grid()
    {
        string sql = "SELECT noticia.NOTI_INT_CODIGO," +
                       " noticia.NOTI_TXT_TITULO," +
                       " noticia.NOTI_CATEGORIA" +
                       " FROM noticia";

        try
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);

            grid_noticias.DataSource = dataTable;
            grid_noticias.DataBind();

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

    protected void grid_noticias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string commandName = e.CommandName;
        Session["NOTI_INT_CODIGO"] = e.CommandArgument.ToString();

        if (commandName == "Editar")
        {           
            Response.Redirect("NoticiasEditar.aspx");
        }
    }

    protected void btn_adicionar_Click(object sender, EventArgs e)
    {
        Session["NOTI_INT_CODIGO"] = 0;
        Response.Redirect("NoticiasEditar.aspx");
