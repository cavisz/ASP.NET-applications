using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocaisEditar : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cdlocal"].ToString() != "0")
            {
                preenche_local();
            }
        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Locais.aspx");
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string sql = "";
            if (Session["cdlocal"].ToString() == "0")
            {

                sql = "INSERT INTO LOCAL_C" +
                        " (LOCA_INT_CODIGO, LOCA_STR_DESCRICAO, LOCA_STR_SIGLA)" +
                        " VALUES(@LOCA_INT_CODIGO, @LOCA_STR_DESCRICAO, @LOCA_STR_SIGLA)";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@LOCA_STR_DESCRICAO", txt_descricao.Text);
                    cmd.Parameters.AddWithValue("@LOCA_STR_SIGLA", txt_sigla.Text);
                    cmd.Parameters.AddWithValue("@LOCA_INT_CODIGO", Session["cdlocal"].ToString());

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    preenche_local();
                    Response.Redirect("Locais.aspx");
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
            else
            {
                sql = "UPDATE LOCAL_C" +
                " SET LOCA_INT_CODIGO = @LOCA_INT_CODIGO, LOCA_STR_DESCRICAO = @LOCA_STR_DESCRICAO, LOCA_STR_SIGLA = @LOCA_STR_SIGLA" +
                " WHERE LOCA_INT_CODIGO = @LOCA_INT_CODIGO";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LOCA_INT_CODIGO", Session["cdlocal"].ToString());
                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@LOCA_STR_DESCRICAO", txt_descricao.Text);
                    cmd.Parameters.AddWithValue("@LOCA_STR_SIGLA", txt_sigla.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    preenche_local();
                    Response.Redirect("Locais.aspx");
                    MessageBox1.ShowMessage("Alterações salvas com sucesso!");
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
    }

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        string sql = "DELETE FROM LOCAL_C " +
                     "WHERE LOCA_INT_CODIGO = @LOCA_INT_CODIGO";
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@LOCA_INT_CODIGO", Session["cdlocal"]);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox1.ShowMessage("Registro excluido com sucesso");
            conn.Close();
            conn.Dispose();
            Response.Redirect("Locais.aspx");
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

    protected void preenche_local()
    {
        String sql = "SELECT LOCAL_C.LOCA_STR_SIGLA," +
                        " LOCAL_C.LOCA_STR_DESCRICAO," +
                        " LOCAL_C.LOCA_INT_CODIGO" +
                        " FROM LOCAL_C" +
                        " WHERE LOCAL_C.LOCA_INT_CODIGO LIKE @LOCA_INT_CODIGO" +
                        " ORDER BY LOCAL_C.LOCA_STR_DESCRICAO ASC";

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@LOCA_INT_CODIGO", Session["cdlocal"]);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txt_descricao.Text = rdr["LOCA_STR_DESCRICAO"].ToString();
                txt_sigla.Text = rdr["LOCA_STR_SIGLA"].ToString();

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
