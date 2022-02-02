using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DepartamentosEditar : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cddepartamento"].ToString() != "0")
            {
                carrega_departamento();
            }
        }
    }
    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Departamentos.aspx");
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string sql = "";
            if (Session["cddepartamento"].ToString() == "0")
            {

                sql = "INSERT INTO DEPTO_C" +
                        " (DEPA_INT_CODIGO, DEPA_STR_DESCRICAO, DEPA_STR_SIGLA)" +
                        " VALUES(@DEPA_INT_CODIGO, @DEPA_STR_DESCRICAO, @DEPA_STR_SIGLA)";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@DEPA_STR_DESCRICAO", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@DEPA_STR_SIGLA", txt_sigla.Text);
                    cmd.Parameters.AddWithValue("@DEPA_INT_CODIGO", Session["cddepartamento"].ToString());

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    carrega_departamento();
                    Response.Redirect("Departamentos.aspx");
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
                sql = "UPDATE DEPTO_C" +
                " SET DEPA_INT_CODIGO = @DEPA_INT_CODIGO, DEPA_STR_DESCRICAO = @DEPA_STR_DESCRICAO, DEPA_STR_SIGLA = @DEPA_STR_SIGLA" +
                " WHERE DEPA_INT_CODIGO = @DEPA_INT_CODIGO";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DEPA_INT_CODIGO", Session["cddepartamento"].ToString());
                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@DEPA_STR_DESCRICAO", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@DEPA_STR_SIGLA", txt_sigla.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    carrega_departamento();
                    Response.Redirect("Departamentos.aspx");
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
        string sql = "DELETE FROM DEPTO_C " +
                     "WHERE DEPA_INT_CODIGO = @DEPA_INT_CODIGO";
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DEPA_INT_CODIGO", Session["cddepartamento"]);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox1.ShowMessage("Registro excluido com sucesso");
            conn.Close();
            conn.Dispose();
            Response.Redirect("Departamentos.aspx");
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
    protected void carrega_departamento()
    {
        string sql = "SELECT DEPTO_C.DEPA_INT_CODIGO," +
                        " DEPTO_C.DEPA_STR_DESCRICAO," +
                        " DEPTO_C.DEPA_STR_SIGLA" +
                        " FROM DEPTO_C" +
                        " WHERE DEPTO_C.DEPA_INT_CODIGO LIKE @DEPA_INT_CODIGO" +
                        " ORDER BY DEPTO_C.DEPA_STR_DESCRICAO ASC";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DEPA_INT_CODIGO", Session["cddepartamento"]);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txt_nome.Text = rdr["DEPA_STR_DESCRICAO"].ToString();
                txt_sigla.Text = rdr["DEPA_STR_SIGLA"].ToString();

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
