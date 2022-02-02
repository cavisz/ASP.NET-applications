using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PessoasEditar : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn_imap"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cdpessoa"].ToString() != "0")
            {
                carregar_pessoa();
            }
            carregar_local();
            carregar_departamentos();
            carregar_cargo();
        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {

        Response.Redirect("Pessoas.aspx");
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        salvar_editar_pessoa();
    }

    protected void carregar_pessoa()
    {
        string sql = "SELECT PESSOAL_C.PESS_INT_CODIGO," +
                       " PESSOAL_C.PESS_STR_NOME," +
                       " PESSOAL_C.PESS_STR_RAMAL," +
                       " PESSOAL_C.FK_CARG_INT_CODIGO," +
                       " PESSOAL_C.FK_DEPA_INT_CODIGO," +
                       " PESSOAL_C.FK_LOCA_INT_CODIGO," +
                       " DATE_FORMAT(PESSOAL_C.PESS_DTM_DTNASC, '%d/%m/%Y') AS PESS_DTM_DTNASC," +
                       " PESSOAL_C.PESS_STR_EMAIL," +
                       " depto_c.DEPA_STR_DESCRICAO," +
                       " cargo_c.CARG_STR_DESCRICAO," +
                       " local_c.LOCA_STR_DESCRICAO" +
                       " FROM PESSOAL_C" +
                       " INNER JOIN depto_c ON depto_c.DEPA_INT_CODIGO = PESSOAL_C.FK_DEPA_INT_CODIGO" +
                       " INNER JOIN cargo_c ON cargo_c.CARG_INT_CODIGO = PESSOAL_C.FK_CARG_INT_CODIGO" +
                       " INNER JOIN local_c ON local_c.LOCA_INT_CODIGO = PESSOAL_C.FK_LOCA_INT_CODIGO" +
                       " WHERE PESSOAL_C.PESS_INT_CODIGO LIKE @PESS_INT_CODIGO" +
                       " ORDER BY PESSOAL_C.PESS_STR_NOME ASC";

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", Session["cdpessoa"]);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txt_nome.Text = rdr["PESS_STR_NOME"].ToString();
                txt_ramal.Text = rdr["PESS_STR_RAMAL"].ToString();

                txt_datNasc.Text = rdr["PESS_DTM_DTNASC"].ToString();
                txt_email.Text = rdr["PESS_STR_EMAIL"].ToString();
                ddl_departamento.SelectedValue = rdr["FK_DEPA_INT_CODIGO"].ToString();
                ddl_cargo.SelectedValue = rdr["FK_CARG_INT_CODIGO"].ToString();
                ddl_local.SelectedValue = rdr["FK_LOCA_INT_CODIGO"].ToString();
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
    protected void carregar_local()
    {
        string sql = "SELECT local_c.LOCA_STR_DESCRICAO," +
                               " local_c.LOCA_INT_CODIGO" +
                               " FROM local_c" +
                               " ORDER BY local_c.LOCA_STR_DESCRICAO ASC";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            ddl_local.DataValueField = "LOCA_INT_CODIGO";
            ddl_local.DataTextField = "LOCA_STR_DESCRICAO";
            ddl_local.DataSource = rdr;
            ddl_local.DataBind();
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

    protected void carregar_departamentos()
    {
        string sql = "SELECT depto_c.DEPA_STR_DESCRICAO," +
                            " depto_c.DEPA_INT_CODIGO" +
                            " FROM depto_c" +
                            " ORDER BY depto_c.DEPA_STR_DESCRICAO ASC";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            ddl_departamento.DataValueField = "DEPA_INT_CODIGO";
            ddl_departamento.DataTextField = "DEPA_STR_DESCRICAO";
            ddl_departamento.DataSource = rdr;
            ddl_departamento.DataBind();
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

    protected void carregar_cargo()
    {
        string sql = "SELECT cargo_c.CARG_STR_DESCRICAO," +
                       " cargo_c.CARG_INT_CODIGO" +
                       " FROM cargo_c" +
                       " ORDER BY cargo_c.CARG_STR_DESCRICAO ASC";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            ddl_cargo.DataValueField = "CARG_INT_CODIGO";
            ddl_cargo.DataTextField = "CARG_STR_DESCRICAO";
            ddl_cargo.DataSource = rdr;
            ddl_cargo.DataBind();
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

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        string sql = "DELETE FROM PESSOAL_C " +
                     "WHERE PESS_INT_CODIGO = @PESS_INT_CODIGO";
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", Session["cdpessoa"]);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox1.ShowMessage("Registro excluido com sucesso");
            conn.Close();
            conn.Dispose();
            Response.Redirect("Pessoas.aspx");
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
    protected void salvar_editar_pessoa()
    {
        if (Page.IsValid)
        {
            MySqlCommand cmd = new MySqlCommand();

            if (Session["cdpessoa"].ToString() == "0")
            {

                cmd = new MySqlCommand("INSERT INTO PESSOAL_C" +
                               " (PESS_STR_NOME, PESS_STR_EMAIL, PESS_STR_RAMAL, PESS_DTM_DTNASC, FK_LOCA_INT_CODIGO, FK_DEPA_INT_CODIGO, FK_CARG_INT_CODIGO)" +
                               " VALUES (@PESS_STR_NOME, @PESS_STR_EMAIL, @PESS_STR_RAMAL, @PESS_DTM_DTNASC, @FK_LOCA_INT_CODIGO, @FK_DEPA_INT_CODIGO, @FK_CARG_INT_CODIGO)", conn);

            }
            else
            {
                cmd = new MySqlCommand("UPDATE PESSOAL_C" +
                " SET PESS_STR_NOME = @PESS_STR_NOME, PESS_STR_EMAIL = @PESS_STR_EMAIL, PESS_STR_RAMAL = @PESS_STR_RAMAL, PESS_DTM_DTNASC = @PESS_DTM_DTNASC, FK_LOCA_INT_CODIGO = @FK_LOCA_INT_CODIGO, FK_DEPA_INT_CODIGO = @FK_DEPA_INT_CODIGO, FK_CARG_INT_CODIGO = @FK_CARG_INT_CODIGO" +
                " WHERE PESS_INT_CODIGO = @PESS_INT_CODIGO", conn);

                cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", Session["cdpessoa"].ToString());


            }

            cmd.Parameters.AddWithValue("@PESS_STR_NOME", txt_nome.Text);
            cmd.Parameters.AddWithValue("@PESS_STR_EMAIL", txt_email.Text);
            cmd.Parameters.AddWithValue("@PESS_STR_RAMAL", txt_ramal.Text);
            DateTime date1 = DateTime.ParseExact(txt_datNasc.Text, "dd/MM/yyyy", null);
            String date2 = date1.ToString("yyyy/MM/dd");
            cmd.Parameters.AddWithValue("@PESS_DTM_DTNASC", date2);
            cmd.Parameters.AddWithValue("@FK_LOCA_INT_CODIGO", ddl_local.SelectedValue);
            cmd.Parameters.AddWithValue("@FK_DEPA_INT_CODIGO", ddl_departamento.SelectedValue);
            cmd.Parameters.AddWithValue("@FK_CARG_INT_CODIGO", ddl_cargo.SelectedValue);

            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                carregar_pessoa();
                Response.Redirect("Pessoas.aspx");

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
