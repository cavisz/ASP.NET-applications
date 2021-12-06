using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

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
            preenche_editar(Session["pessoa_int_cod"].ToString()); //recebe variável de sessão para o preenche editar e chama  função para o if editar no coomand name no gridview
            MultiView1.ActiveViewIndex = 1;
        }
    }

    protected void btn_voltar_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btn_salvar_Click(object sender, EventArgs e)
    {
        salvar_editar_pessoas(); //chama a função de salvar e editar pessoas, a prórpia função realiza a pesquisa para salvar ou editar
    }

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        excluir_pessoa(Session["pessoa_int_cod"].ToString()); //recebe a function de excluir pessoa no btn excluir com a variavél de sessão do código
    }

    protected void carregar_grid() //função de carregamento de toda gridview
    {
        string condicao = "";
        if (txt_pesquisa.Text != "") //caso realiza pesquisa no btn sourche ele preenceh a string de condição vazia com o nome pesquisado
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
                                   " INNER JOIN local_c ON local_c.LOCA_INT_CODIGO = pessoal_c.FK_LOCA_INT_CODIGO" + condicao +
                                   " ORDER BY PESS_STR_NOME";

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
            if (ds.Tables[0].Rows.Count == 0 || txt_pesquisa.Text != "")
            {
                btn_grid_vazia.Visible = true;

            }
            else
            {
                btn_grid_vazia.Visible = false;
            }
            conexao.Close();
        }
        catch (MySqlException)
        {
        }
        finally
        {
            conexao.Close();                                                    //close conection
        }

    }

    protected void carregar_departamentos() //função de carregamento dos departamentos na dropwdownlist
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

    protected void preenche_editar(string codigo_pessoa) //preenche as labels quando o btn editar pe clickado, recebe as informações do código da pessoa clickada na gridview
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
        txt_email.Text = "";    //zera as informações na label para que o cliente receba vazia ao clickar no btnc adicionar
        txt_nome.Text = string.Empty;   //outra maneira de igualmnete erar as informações das label para o client side
        txt_ramal.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList_local.SelectedIndex = 0;
        MultiView1.ActiveViewIndex = 1;
    }
    protected void salvar_editar_pessoas() //
    {
        if (Page.IsValid)
        {
            string sql = "";
            if (Session["pessoa_int_cod"].ToString() == "0") //recebe a variavél de sessão codigo da pessoa se igual a zero significa que nao existe no banco de dados, portanto realiza o insert
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
                    conexao.Close(); //fecha a conexão antes de carregar as informações da pessoa salva na grid, é importante fechar pois pode dar erro de cone~xão já aberta é possivel fazer o mesmo com uma condição para testar conexão aberta
                    carregar_grid(); // carrega as informações na grid
                    MultiView1.ActiveViewIndex = 0;
                    ShowMessage("Pessoa inserida com sucesso"); // Informa o cliente da execução 
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
            else //caso a condição inicial n tenha sido satisfeita ele conclui que p id já é existente e portanto realiza o update no banco de dados atraés da leitura do id
            {
                sql = "UPDATE pessoal_c" +
                               " SET PESS_STR_NOME = @PESS_STR_NOME, PESS_STR_EMAIL = @PESS_STR_EMAIL, PESS_STR_RAMAL = @PESS_STR_RAMAL, FK_LOCA_INT_CODIGO = @LOCA_INT_CODIGO, FK_DEPA_INT_CODIGO = @DEPA_INT_CODIGO" +
                               " WHERE PESS_INT_CODIGO = @PESS_INT_CODIGO";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@PESS_INT_CODIGO", Session["pessoa_int_cod"].ToString());
                try
                {
                    conexao.Open();
                    cmd.Parameters.AddWithValue("@PESS_STR_NOME", txt_nome.Text);
                    cmd.Parameters.AddWithValue("@PESS_STR_EMAIL", txt_email.Text);
                    cmd.Parameters.AddWithValue("@PESS_STR_RAMAL", txt_ramal.Text);
                    cmd.Parameters.AddWithValue("@LOCA_INT_CODIGO", DropDownList_local.SelectedValue);
                    cmd.Parameters.AddWithValue("@DEPA_INT_CODIGO", DropDownList1.SelectedValue);
                    cmd.ExecuteNonQuery(); //executa a função do addwithvalue para adicionar os valores
                    conexao.Close(); //fechar a conexão novamente para chamar a carregar grid para n haver erro de conexão já aberta
                    carregar_grid();
                    MultiView1.ActiveViewIndex = 0;
                    ShowMessage("Alterações salvas com sucesso!");
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
    }
    public void ShowMessage(string msg) //function in javascript recebida em c# para apresentar mensagem no client side
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
            conexao.Close();
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

    protected void btn_grid_vazia_Click(object sender, EventArgs e)
    {
        txt_pesquisa.Text = "";
        MultiView1.ActiveViewIndex = 0;
        carregar_grid();

    }

    protected void btn_voltar_login_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }
}

