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
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class adm_napitaxoline_Login_napi : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn_sinc"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] + "" == "ativo")
            {
                MultiView1.ActiveViewIndex = 1;
                carrega_grid();
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }
    }


    protected void btn_submeter_Click(object sender, EventArgs e)
    {
        if (txt_usuario.Text == "imap" && txt_senha.Text == "imap-napi-2022")
        {
            Session["login"] = "ativo";
            MultiView1.ActiveViewIndex = 1;
            carrega_grid();
        }
        else
        {
            MessageBox1.ShowMessage("Senha ou usuário inválido");
            MultiView1.ActiveViewIndex = 0;
        }
    }
    protected void carrega_grid()
    {

        string sql = "SELECT napitaxonline.napi_nome," +
                            " napitaxonline.napi_cpf," +
                            " napitaxonline.napi_email," +
                            " napitaxonline.napi_codigo" +
                            " FROM napitaxonline";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
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


    protected void preenche_editar()
    {
        string sql = "SELECT napitaxonline.napi_nome," +
                           " napitaxonline.napi_cpf," +
                           " napitaxonline.napi_rg," +
                           " napitaxonline.napi_conclusao," +
                           " napitaxonline.napi_curso," +
                           " napitaxonline.napi_instituicao," +
                           " napitaxonline.napi_endereco," +
                           " napitaxonline.napi_numero," +
                           " napitaxonline.napi_complemento," +
                           " napitaxonline.napi_bairro," +
                           " napitaxonline.napi_cidade," +
                           " napitaxonline.napi_estado," +
                           " napitaxonline.napi_cep," +
                           " napitaxonline.napi_telefone," +
                           " napitaxonline.napi_celular," +
                           " napitaxonline.napi_email," +
                           " napitaxonline.napi_curriculo_lattes," +
                           " napitaxonline.napi_codigo," +
                           " CASE napi_escolaridade" +
                           " WHEN 1 THEN 'Graduação'" +
                           " WHEN 2 THEN 'Especialização'" +
                           " WHEN 3 THEN 'Mestrado'" +
                           " WHEN 4 THEN 'Doutorado'" +
                           " END AS napi_escolaridade," +
                           " CASE napi_opcao_bolsa" +
                           " WHEN 1 THEN 'Museu Botânico Municipal'" +
                           " WHEN 2 THEN 'Museu de História Natural'" +
                           " END AS napi_opcao_bolsa" +
                           " FROM napitaxonline";
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {

                txt_nome.Text = rdr["napi_nome"].ToString();
                txt_cpf.Text = rdr["napi_cpf"].ToString();
                txt_rg.Text = rdr["napi_rg"].ToString();
                txt_escolaridade.Text = rdr["napi_escolaridade"].ToString();
                txt_ano_conclusao.Text = rdr["napi_conclusao"].ToString();
                txt_curso.Text = rdr["napi_curso"].ToString();
                txt_instituicao.Text = rdr["napi_instituicao"].ToString();
                txt_endereco.Text = rdr["napi_endereco"].ToString();
                txt_numero_casa.Text = rdr["napi_numero"].ToString();
                txt_complemento.Text = rdr["napi_complemento"].ToString();
                txt_bairro.Text = rdr["napi_bairro"].ToString();
                txt_cidade.Text = rdr["napi_cidade"].ToString();
                txt_estado.Text = rdr["napi_cidade"].ToString();
                txt_cep.Text = rdr["napi_cep"].ToString();
                txt_telefone.Text = rdr["napi_telefone"].ToString();
                txt_celular.Text = rdr["napi_celular"].ToString();
                txt_email.Text = rdr["napi_email"].ToString();
                txt_opcao_bolsa.Text = rdr["napi_opcao_bolsa"].ToString();
                txt_curriculo_lattes.Text = rdr["napi_curriculo_lattes"].ToString();
            }

            rdr.Close();


        }
        catch
        {

        }
        finally
        {
            conn.Close();
        }
    }

    protected void btn_voltar_login_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string commandName = e.CommandName;
        if (commandName == "Editar")
        {
            MultiView1.ActiveViewIndex = 2;
            preenche_editar();
            getAnexos();
        }
    }

    protected void btn_voltar_grid_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }


    protected void getAnexos()
    {

        string nomearquivo = "napitaxoline_" + txt_cpf.Text + "*.pdf";

        var query = from files in Directory.GetFiles(Server.MapPath("~/Arquivos"), nomearquivo, SearchOption.TopDirectoryOnly)
                    let file = new FileInfo(files)
                    select new
                    {
                        Caminho = file.FullName,
                        NomeArquivo = file.Name,
                        Extensao = file.Extension
                    };

        gridAnexos.DataSource = query;
        gridAnexos.DataBind();

    }

    protected void gridAnexos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string arquivo = e.CommandArgument.ToString();

        if (e.CommandName == "Editar")
        {
            var url = "../Arquivos/" + arquivo;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + url + "','_blank')", true);
        }
    }

    protected void btn_excluir_Click(object sender, EventArgs e)
    {
        string sql = "DELETE FROM napitaxonline " +
                     "WHERE napi_nome ='" + this.txt_nome.Text + "';";
        string nome_pessoa = string.Empty;

        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@napi_nome", nome_pessoa);
            cmd.ExecuteNonQuery();
            conn.Close();
            carrega_grid();
            MultiView1.ActiveViewIndex = 1;
            MessageBox1.ShowMessage("Inscrição excluida com sucesso!");
            conn.Close();
        }
        catch (MySqlException ex)
        {

        }
        finally
        {
            conn.Close();
        }

    }
}
