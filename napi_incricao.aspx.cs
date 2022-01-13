using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inscricao_napitaxoline : System.Web.UI.Page
{
    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn_sinc"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                //DateTime _data1 = Convert.ToDateTime("2022/02/01"); 
                DateTime _data2 = Convert.ToDateTime("2022/02/12"); 

                if (DateTime.Now > _data2)
                {
                    MultiView1.ActiveViewIndex = 2; //view2
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }
    }

    protected void btn_enviar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (gridAnexos.Rows.Count > 0)
            {
                string sql = "INSERT INTO napitaxonline (" +
                        " napi_nome," +
                        " napi_cpf," +
                        " napi_rg," +
                        " napi_escolaridade," +
                        " napi_conclusao," +
                        " napi_curso," +
                        " napi_instituicao," +
                        " napi_endereco," +
                        " napi_numero," +
                        " napi_complemento," +
                        " napi_bairro," +
                        " napi_cidade," +
                        " napi_estado," +
                        " napi_cep," +
                        " napi_telefone," +
                        " napi_celular," +
                        " napi_email," +
                        " napi_opcao_bolsa," +
                        " napi_curriculo_lattes" +
                        " ) VALUES (" +
                        " @napi_nome," +
                        " @napi_cpf," +
                        " @napi_rg," +
                        " @napi_escolaridade," +
                        " @napi_conclusao," +
                        " @napi_curso," +
                        " @napi_instituicao," +
                        " @napi_endereco," +
                        " @napi_numero," +
                        " @napi_complemento," +
                        " @napi_bairro," +
                        " @napi_cidade," +
                        " @napi_estado," +
                        " @napi_cep," +
                        " @napi_telefone," +
                        " @napi_celular," +
                        " @napi_email," +
                        " @napi_opcao_bolsa," +
                        " @napi_curriculo_lattes )";


                MySqlCommand cmd = new MySqlCommand();
                cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@napi_nome", txt_nome.Text);
                cmd.Parameters.AddWithValue("@napi_cpf", txt_cpf.Text);
                cmd.Parameters.AddWithValue("@napi_rg", txt_rg.Text);
                cmd.Parameters.AddWithValue("@napi_escolaridade", ddl_escolaridade.SelectedValue);
                cmd.Parameters.AddWithValue("@napi_conclusao", txt_ano_conclusao.Text);
                cmd.Parameters.AddWithValue("@napi_curso", txt_curso.Text);
                cmd.Parameters.AddWithValue("@napi_instituicao", txt_instituicao.Text);
                cmd.Parameters.AddWithValue("@napi_endereco", txt_endereco.Text);
                cmd.Parameters.AddWithValue("@napi_numero", txt_numero.Text);
                cmd.Parameters.AddWithValue("@napi_complemento", txt_complemento.Text);
                cmd.Parameters.AddWithValue("@napi_bairro", txt_bairro.Text);
                cmd.Parameters.AddWithValue("@napi_cidade", txt_cidade.Text);
                cmd.Parameters.AddWithValue("@napi_estado", txt_estado.Text);
                cmd.Parameters.AddWithValue("@napi_cep", txt_cep.Text);
                cmd.Parameters.AddWithValue("@napi_telefone", txt_telefone.Text);
                cmd.Parameters.AddWithValue("@napi_celular", txt_celular.Text);
                cmd.Parameters.AddWithValue("@napi_email", txt_email.Text);
                cmd.Parameters.AddWithValue("@napi_opcao_bolsa", ddl_bolsa.SelectedValue);
                cmd.Parameters.AddWithValue("@napi_curriculo_lattes", txt_curriculo_lattes.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MultiView1.ActiveViewIndex = 1;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox1.ShowMessage("ERRO: CPF já cadastrado");
                    }
                    else
                    {
                        MessageBox1.ShowMessage("ERRO: " + ex.Message);
                    }

                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            else
            {
                MessageBox1.ShowMessage("ERRO: Nenhum arquivo foi anexado, não é possível enviar a inscrição");
            }
        }
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
            var url = "Arquivos/" + arquivo;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + url + "','_blank')", true);
        }
        else if (e.CommandName == "Excluir")
        {
            string deletaArquivo = "~/Arquivos/" + arquivo;
            File.Delete(Server.MapPath(deletaArquivo));
            MultiView1.ActiveViewIndex = 0;
            getAnexos();

        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        int _retorno = pesquisa_ja_existe();
        if (_retorno == 0)
        {

            if (IsPostBack)
            {
                lblMensagemUpload.Text = "";

                Boolean fileOK = false;

                if (file_upload.HasFile)
                {
                    //  Testa extensões válidas

                    String fileExtension = System.IO.Path.GetExtension(file_upload.FileName).ToLower();
                    String[] allowedExtensions = { ".pdf" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }

                    //  Testa tamanho do arquivo
                    if (file_upload.PostedFile.ContentLength > 5242880) //5MB

                    {
                        fileOK = false;
                    }
                }

                if (fileOK)
                {
                    string palavraSemAcento = "napitaxoline_" + txt_cpf.Text + "_" + DateTime.Now.ToString("ddMMyyyy_Hmmss") + ".pdf";

                    //  Testa se arquivo já existe

                    string caminhoArquivo = "~/Arquivos/" + palavraSemAcento;

                    if (System.IO.File.Exists(caminhoArquivo))
                    {
                        file_upload.Dispose();
                        MessageBox1.ShowMessage("ATENÇÃO: Arquivo já existente");
                    }
                    else
                    {
                        try
                        {
                            file_upload.SaveAs(Server.MapPath("~/Arquivos/") + palavraSemAcento);
                            file_upload.Dispose();
                            MultiView1.ActiveViewIndex = 0;
                            getAnexos();

                        }

                        catch (Exception ex)
                        {
                            file_upload.Dispose();
                            MultiView1.ActiveViewIndex = 0;
                            MessageBox1.ShowMessage("ERRO: " + ex.Message);
                        }
                    }
                }
                else
                {
                    file_upload.Dispose();
                    MultiView1.ActiveViewIndex = 0;
                    MessageBox1.ShowMessage("Tipo de arquivo ou tamanho inválido. Extensão permitida: .pdf no máximo 5MB");
                }
            }

            btn_enviar.Focus();
        }
        else
        {
            MessageBox1.ShowMessage("ERRO: CPF já cadastrado");
        }
    }
    protected int pesquisa_ja_existe()
    {
        int _retorno = 0;
        try
        {
            string _sql = "SELECT" +
                           " COUNT(napi_codigo) AS TOTAL" +
                           " FROM napitaxonline" +
                           " WHERE napi_cpf = " + txt_cpf.Text;

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(_sql, conn);
            _retorno = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();
            conn.Dispose();

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

        return _retorno;
    }
}
