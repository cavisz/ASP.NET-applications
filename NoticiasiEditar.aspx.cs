using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (Session["NOTI_INT_CODIGO"].ToString() != "0")
            {
                carrega_noticia();
            }

        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Noticias.aspx");
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            MySqlCommand cmd = new MySqlCommand();

            if (Session["NOTI_INT_CODIGO"].ToString() == "0")
            {

                cmd = new MySqlCommand("INSERT INTO noticia" +
                        " (NOTI_TXT_TITULO, NOTI_TXT_DESCRICAO, NOTI_STR_FOTO, NOTI_DTM_DATA, NOTI_CATEGORIA)" +
                        " VALUES (@NOTI_TXT_TITULO, @NOTI_TXT_DESCRICAO, @NOTI_STR_FOTO, @NOTI_DTM_DATA, @NOTI_CATEGORIA)", conn);
            }
            else
            {
                cmd = new MySqlCommand("UPDATE noticia" +
                        " SET NOTI_TXT_TITULO = @NOTI_TXT_TITULO, NOTI_TXT_DESCRICAO = @NOTI_TXT_DESCRICAO, NOTI_STR_FOTO = @NOTI_STR_FOTO, NOTI_DTM_DATA = @NOTI_DTM_DATA, NOTI_CATEGORIA = @NOTI_CATEGORIA" +
                        " WHERE NOTI_INT_CODIGO = @NOTI_INT_CODIGO", conn);

                cmd.Parameters.AddWithValue("@NOTI_INT_CODIGO", Session["NOTI_INT_CODIGO"].ToString());
            }

            cmd.Parameters.AddWithValue("@NOTI_TXT_TITULO", txt_titulo.Text);
            cmd.Parameters.AddWithValue("@NOTI_TXT_DESCRICAO", txt_descricao.Text);
            cmd.Parameters.AddWithValue("@NOTI_STR_FOTO", txt_foto.Text);
            DateTime date1 = DateTime.ParseExact(txt_data.Text, "dd/MM/yyyy", null);
            String date2 = date1.ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@NOTI_DTM_DATA", date2);
            cmd.Parameters.AddWithValue("@NOTI_CATEGORIA", txt_categoria.Text);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                carrega_noticia();
                Response.Redirect("Noticias.aspx");
                conn.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox1.ShowMessage(ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }
    }

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        string sql = "DELETE FROM noticia " +
                     "WHERE NOTI_INT_CODIGO = @NOTI_INT_CODIGO";

        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NOTI_INT_CODIGO", Session["NOTI_INT_CODIGO"]);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            Response.Redirect("Noticias.aspx");
        }
        catch (MySqlException ex)
        {
            MessageBox1.ShowMessage("ERRO: " + ex.Message);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    protected void carrega_noticia()
    {
        string sql = "SELECT noticia.NOTI_INT_CODIGO," +
                       " noticia.NOTI_TXT_TITULO," +
                       " noticia.NOTI_TXT_DESCRICAO," +
                       " noticia.NOTI_STR_FOTO," +
                       " DATE_FORMAT(noticia.NOTI_DTM_DATA, '%d/%m/%Y') AS NOTI_DTM_DATA," +
                       " noticia.NOTI_CATEGORIA" +
                       " FROM noticia" +
                       " WHERE noticia.NOTI_INT_CODIGO LIKE @NOTI_INT_CODIGO" +
                       " ORDER BY noticia.NOTI_TXT_TITULO ASC";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NOTI_INT_CODIGO", Session["NOTI_INT_CODIGO"]);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txt_titulo.Text = rdr["NOTI_TXT_TITULO"].ToString();
                txt_descricao.Text = rdr["NOTI_TXT_DESCRICAO"].ToString();
                txt_foto.Text = rdr["NOTI_STR_FOTO"].ToString();
                txt_data.Text = rdr["NOTI_DTM_DATA"].ToString();
                txt_categoria.Text = rdr["NOTI_CATEGORIA"].ToString();
            }

            rdr.Close();
            rdr.Dispose();
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
