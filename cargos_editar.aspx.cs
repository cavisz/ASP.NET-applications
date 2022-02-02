using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CargosEditar : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cdcargo"].ToString() != "0")
            {
                carrega_cargo();
            }
        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cargos.aspx");
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            MySqlCommand cmd = new MySqlCommand();

            if (Session["cdcargo"].ToString() == "0")
            {

                cmd = new MySqlCommand("INSERT INTO CARGO_C" +
                        " (CARG_INT_CODIGO, CARG_STR_DESCRICAO)" +
                        " VALUES(@CARG_INT_CODIGO, @CARG_STR_DESCRICAO)", conn);

            }
            else
            {
                cmd = new MySqlCommand("UPDATE CARGO_C" +
                " SET CARG_INT_CODIGO = @CARG_INT_CODIGO, CARG_STR_DESCRICAO = @CARG_STR_DESCRICAO" +
                " WHERE CARG_INT_CODIGO = @CARG_INT_CODIGO", conn);
            }

            cmd.Parameters.AddWithValue("@CARG_STR_DESCRICAO", txt_descricao.Text);
            cmd.Parameters.AddWithValue("@CARG_INT_CODIGO", Session["cdcargo"].ToString());

            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                carrega_cargo();
                Response.Redirect("Cargos.aspx");
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
        string sql = "DELETE FROM CARGO_C " +
                     "WHERE CARG_INT_CODIGO = @CARG_INT_CODIGO";
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CARG_INT_CODIGO", Session["cdcargo"]);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            Response.Redirect("Cargos.aspx");
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

    protected void carrega_cargo()
    {
        string sql = "SELECT CARGO_C.CARG_INT_CODIGO," +
                       " CARGO_C.CARG_STR_DESCRICAO" +
                       " FROM CARGO_C" +
                       " WHERE CARGO_C.CARG_INT_CODIGO LIKE @CARG_INT_CODIGO" +
                       " ORDER BY CARGO_C.CARG_STR_DESCRICAO ASC";

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CARG_INT_CODIGO", Session["cdcargo"]);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txt_descricao.Text = rdr["CARG_STR_DESCRICAO"].ToString();

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
