using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString); //string de conexão web.config com o site 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //retorna pagina vazia caso não aja ação do usuário
        {
            carregar_grid();            //chama função para carregar grid na view inicial
            carregar_local();
            carregar_departamentos();
            MultiView1.ActiveViewIndex = 0;
        }
    }

    protected void OnRowCommand(object sender, GridViewCommandEventArgs e) //comando na row do gridview para ações dentro da tabela view
    {
        string commandName = e.CommandName; //string igualando o nome (commandname) para ações no C#
        Session["pessoa_int_cod"] = e.CommandArgument.ToString();

        if (commandName == "Editar")
        {
            preenche_editar(Session["pessoa_int_cod"].ToString());
            MultiView1.ActiveViewIndex = 1;
        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        salvar_editar_pessoas();
    }

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        excluir_pessoa(Session["pessoa_int_cod"].ToString());       
    }

    protected void carregar_grid() //função de carregamento de toda gridview
    {
        string condicao = "";
        if (txt_pesquisa.Text != "")
        {
            condicao = " WHERE pessoal_c.PESS_STR_NOME LIKE @Nome";
        }


        string texto = "SELECT depto_c.DEPA_STR_SIGLA," +
                                   " local_c.LOCA_STR_SIGLA," +
                                   " pessoal_c.PESS_INT_CODIGO," +
                                   " pessoal_c.PESS_STR_EMAIL," +
                                   " pessoal_c.PESS_STR_RAMAL," +
                                   " pessoal_c.PESS_STR_NOME" +
                                   " FROM pessoal_c" +
                                   " INNER JOIN depto_c ON depto_c.DEPA_INT_CODIGO = pessoal_c.FK_DEPA_INT_CODIGO" +
                                   " INNER JOIN local_c ON local_c.LOCA_INT_CODIGO = pessoal_c.FK_LOCA_INT_CODIGO" + condicao;

        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);                //comando que conecta string com a conexão co banco de dados
            cmd.Parameters.AddWithValue("@Nome", "%" + txt_pesquisa.Text + "%");
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);                   //adapter para apresentar a tabela no gridview do site
            DataSet ds = new DataSet();                                         //seta a gridview para apresentar as informaçoes no site
            adp.Fill(ds);                                                       //preenche a setage com as informações
            GridView1.DataSource = ds;                                          //procura as informações paraa presentar
            GridView1.DataBind();                                               //apresenta as informaçõe no site
        }
        catch (MySqlException)
        {
        }
        finally
        {
            conexao.Close();                                                    //close conection
        }
    }

    protected void carregar_departamentos()
    {
        string texto = "SELECT depto_c.DEPA_STR_SIGLA," +
                            " depto_c.DEPA_INT_CODIGO" +
                            " FROM depto_c";
        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();                  //assigning datasource to the dropdownlist 
            DropDownList1.DataValueField = "DEPA_INT_CODIGO";
            DropDownList1.DataTextField = "DEPA_STR_SIGLA";
            DropDownList1.DataSource = rdr;
            DropDownList1.DataBind();

        }
        catch (MySqlException ex)
        {
        }

        finally
        {
            conexao.Close();
        }

    }
    protected void carregar_local()
    {
        string texto = "SELECT local_c.LOCA_INT_CODIGO," +
                               " local_c.LOCA_STR_SIGLA" +
                               " FROM local_c";
        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();                  //assigning datasource to the dropdownlist 
            DropDownList_local.DataValueField = "LOCA_INT_CODIGO";
            DropDownList_local.DataTextField = "LOCA_STR_SIGLA";
            DropDownList_local.DataSource = rdr;
            DropDownList_local.DataBind();
            conexao.Close();

        }
        catch (MySqlException ex)
        {
        }

        finally
        {
            conexao.Close();
        }

    }

    protected void Image3_Click(object sender, ImageClickEventArgs e)
    {
        carregar_grid();
    }

    protected void preenche_editar(string codigo_pessoa)
    {
        string texto = "SELECT" +
        " pessoal_c.PESS_INT_CODIGO," +
        " pessoal_c.PESS_STR_EMAIL," +
        " pessoal_c.PESS_STR_RAMAL," +
        " pessoal_c.PESS_STR_NOME," +
        " local_c.LOCA_INT_CODIGO," +
        " depto_c.DEPA_INT_CODIGO" +
        " FROM pessoal_c" +
        " INNER JOIN depto_c ON depto_c.DEPA_INT_CODIGO = pessoal_c.FK_DEPA_INT_CODIGO" +
        " INNER JOIN local_c ON local_c.LOCA_INT_CODIGO = pessoal_c.FK_LOCA_INT_CODIGO" +
        " WHERE pessoal_c.PESS_INT_CODIGO LIKE @PESS_INT_CODIGO";


        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(texto, conexao);
            cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", codigo_pessoa);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                txt_nome.Text = rdr["PESS_STR_NOME"].ToString();
                txt_email.Text = rdr["PESS_STR_EMAIL"].ToString();
                txt_ramal.Text = rdr["PESS_STR_RAMAL"].ToString();
                DropDownList_local.SelectedValue = rdr["LOCA_INT_CODIGO"].ToString();
                DropDownList1.SelectedValue = rdr["DEPA_INT_CODIGO"].ToString();
            }

            rdr.Close();

        }
        catch (MySqlException ex)
        {
        }

        finally
        {
            conexao.Close();
        }



    }

    protected void btn_adicionar_pessoa_Click(object sender, EventArgs e)
    {
        Session["pessoa_int_cod"] = 0;
        txt_email.Text = "";
        txt_nome.Text = string.Empty;
        txt_ramal.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList_local.SelectedIndex = 0;
        MultiView1.ActiveViewIndex = 1;
    }
    protected void salvar_editar_pessoas()
    {
        string sql = "";
        if (Session["pessoa_int_cod"].ToString() == "0")
        {

            sql = "INSERT INTO pessoal_c" +
                           " (PESS_STR_NOME, PESS_STR_EMAIL, PESS_STR_RAMAL, FK_LOCA_INT_CODIGO, FK_DEPA_INT_CODIGO)" +
                           " VALUES (@PESS_STR_NOME, @PESS_STR_EMAIL, @PESS_STR_RAMAL, @FK_LOCA_INT_CODIGO, @FK_DEPA_INT_CODIGO)";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                cmd.Parameters.AddWithValue("@PESS_STR_NOME", txt_nome.Text);
                cmd.Parameters.AddWithValue("@PESS_STR_EMAIL", txt_email.Text);
                cmd.Parameters.AddWithValue("@PESS_STR_RAMAL", txt_ramal.Text);
                cmd.Parameters.AddWithValue("@FK_LOCA_INT_CODIGO", DropDownList_local.SelectedValue);
                cmd.Parameters.AddWithValue("@FK_DEPA_INT_CODIGO", DropDownList1.SelectedValue);
                cmd.ExecuteNonQuery();
                carregar_grid();
                MultiView1.ActiveViewIndex = 0;
                ShowMessage("Pessoa inserida com sucesso");

            }
            catch (MySqlException ex)
            {

            }

            finally
            {
                conexao.Close();
            }
        }
        else
        {
            sql = "UPDATE pessoal_c" +
                           " SET PESS_STR_NOME = @PESS_STR_NOME, PESS_STR_EMAIL = @PESS_STR_EMAIL, PESS_STR_RAMAL = @PESS_STR_RAMAL, FK_LOCA_INT_CODIGO = @LOCA_INT_CODIGO, FK_DEPA_INT_CODIGO = @DEPA_INT_CODIGO " +
                           " WHERE PESS_INT_CODIGO = @PESS_INT_CODIGO";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", Session["pessoa_int_cod"].ToString());
            try
            {
                conexao.Open();
                cmd.Parameters.AddWithValue("@PESS_STR_NOME", txt_nome.Text);
                cmd.Parameters.AddWithValue("@PESS_STR_EMAIL", txt_email.Text);
                cmd.Parameters.AddWithValue("@PESS_STR_RAMAL", txt_ramal.Text);
                cmd.Parameters.AddWithValue("@FK_LOCA_INT_CODIGO", DropDownList_local.SelectedValue);
                cmd.Parameters.AddWithValue("@FK_DEPA_INT_CODIGO", DropDownList1.SelectedValue);
                cmd.ExecuteNonQuery();
                carregar_grid();
                MultiView1.ActiveViewIndex = 0;


            }
            catch (MySqlException ex)
            {

            }

            finally
            {
                conexao.Close();
            }

        }
    }
    public void ShowMessage(string msg)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
    }
    protected void excluir_pessoa(string codigo_pessoa)
    {
        string sql = "DELETE FROM pessoal_c " +
                     "WHERE PESS_INT_CODIGO = @PESS_INT_CODIGO";
        try
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", codigo_pessoa);
            cmd.ExecuteNonQuery();
            carregar_grid();
            MultiView1.ActiveViewIndex = 0;
            ShowMessage("Pessoa excluida com sucesso!");
            conexao.Close();
        }
        catch (MySqlException ex)
        {

        }

        finally
        {
            conexao.Close();
        }
    }
}
