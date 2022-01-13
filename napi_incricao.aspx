<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inscricao_napitaxoline.aspx.cs" Inherits="inscricao_napitaxoline" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="js/jquery-3.3.1.mim.js"></script>
    <script src="js/validacpf.js"></script>
    <script src="js/Mascara.js"></script>
    <title>Inscrição - NAPITAXOLINE</title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <cc1:MessageBox ID="MessageBox1" runat="server" />


            <div class="row">
                <div class="col">
                    <asp:Image src="Imagens/imap_logo_2017.png" runat="server" ID="logo_imap" CssClass="img-fluid mt-2" alt="Responsive image" Height="100px" Width="150px" />
                    <h3 style="text-align: center">Processo Seletivo Simplificado</h3>
                    <br />
                    <h6 style="text-align: center" class="text-secondary">Seleção de Bolsista Técnico para auxílio ao desenvolvimento do NAPI TAXONLINE – Rede Paranaense de Coleções Biológicas nos Museus da Prefeitura Municipal de Curitiba.
                    </h6>
                </div>
            </div>


            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <div class="card ">
                                    <div class="card-header" style="text-align: center; font-weight: bold; font-size: large">Inscrição</div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_nome" runat="server">Nome do candidato(o):</asp:Label>
                                                <asp:TextBox ID="txt_nome" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                    runat="server"
                                                    ControlToValidate="txt_nome"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_cpf" runat="server" Text="CPF:"></asp:Label>
                                                <asp:TextBox ID="txt_cpf" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txt_cpf_FilteredTextBoxExtender" runat="server" Enabled="True"
                                                    TargetControlID="txt_cpf" ValidChars="0123456789">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                    runat="server"
                                                    ControlToValidate="txt_cpf"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="CustomValidator3"
                                                    runat="server"
                                                    ErrorMessage="CPF inválido"
                                                    ClientValidationFunction="valida_CPF"
                                                    ControlToValidate="txt_cpf"
                                                    CssClass="alert alert-danger"
                                                    Display="Dynamic"
                                                    SetFocusOnError="True">
                                                </asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_rg" runat="server" Text="RG:"></asp:Label>
                                                <asp:TextBox ID="txt_rg" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txt_rgFilteredTextBoxExtender1" runat="server" Enabled="True"
                                                    TargetControlID="txt_rg" ValidChars="0123456789">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                                                    runat="server"
                                                    ControlToValidate="txt_rg"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_escolaridade" runat="server" Text="Escolaridade:"></asp:Label>
                                                <asp:DropDownList ID="ddl_escolaridade" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Graduação" Value="1" />
                                                    <asp:ListItem Text="Especialização" Value="2" />
                                                    <asp:ListItem Text="Mestrado" Value="3" />
                                                    <asp:ListItem Text="Doutorado" Value="4" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_ano_conclusao" runat="server" Text="Ano de Conclusão:"></asp:Label>
                                                <asp:TextBox ID="txt_ano_conclusao" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txt_ano_conclusao_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txt_ano_conclusao" ValidChars="0123456789">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                    runat="server"
                                                    ControlToValidate="txt_ano_conclusao"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_curso" runat="server" Text="Curso:"></asp:Label>
                                                <asp:TextBox ID="txt_curso" runat="server" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                    runat="server"
                                                    ControlToValidate="txt_curso"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_instituicao" runat="server" Text="Instituição de Ensino:"></asp:Label>
                                                <asp:TextBox ID="txt_instituicao" runat="server" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                    runat="server"
                                                    ControlToValidate="txt_instituicao"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_endereco" runat="server" Text="Endereço Residencial:"></asp:Label>
                                                <asp:TextBox ID="txt_endereco" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                                    runat="server"
                                                    ControlToValidate="txt_endereco"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_numero" runat="server" Text="N°:"></asp:Label>
                                                <asp:TextBox ID="txt_numero" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                    runat="server"
                                                    ControlToValidate="txt_numero"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_complemento" runat="server" Text="Complemento:"></asp:Label>
                                                <asp:TextBox ID="txt_complemento" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                    runat="server"
                                                    ControlToValidate="txt_complemento"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_bairro" runat="server" Text="Bairro:"></asp:Label>
                                                <asp:TextBox ID="txt_bairro" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                                    runat="server"
                                                    ControlToValidate="txt_bairro"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_cidade" runat="server" Text="Cidade:"></asp:Label>
                                                <asp:TextBox ID="txt_cidade" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                    runat="server"
                                                    ControlToValidate="txt_cidade"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_estado" runat="server" Text="Estado (sigla):"></asp:Label>
                                                <asp:TextBox ID="txt_estado" runat="server" CssClass="form-control text-uppercase" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                                    runat="server"
                                                    ControlToValidate="txt_estado"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_cep" runat="server" Text="CEP:"></asp:Label>
                                                <asp:TextBox ID="txt_cep" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="txt_cepFilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txt_cep" ValidChars="0123456789">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                                    runat="server"
                                                    ControlToValidate="txt_cep"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_telefone" runat="server" Text="Telefone:"></asp:Label>
                                                <asp:TextBox ID="txt_telefone" runat="server" CssClass="form-control" MaxLength="15" onkeyup="formataTelefone9(this, event);"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                                    runat="server"
                                                    ControlToValidate="txt_telefone"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_celular" runat="server" Text="Celular:"></asp:Label>
                                                <asp:TextBox ID="txt_celular" runat="server" CssClass="form-control" MaxLength="15" onkeyup="formataTelefone9(this, event);"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                                    runat="server"
                                                    ControlToValidate="txt_celular"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_email" runat="server" Text="E-mail:"></asp:Label>
                                                <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" TextMode="Email" MaxLength="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                                                    runat="server"
                                                    ControlToValidate="txt_email"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_bolsa" runat="server" Text="Opção pela Bolsa:"></asp:Label>
                                                <asp:DropDownList ID="ddl_bolsa" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Museu Botânico Municipal" Value="1" />
                                                    <asp:ListItem Text="Museu de História Natural" Value="2" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_curriculo_lattes" runat="server" Text="Currículo Lattes atualizado (link para acesso):"></asp:Label>
                                                <asp:TextBox ID="txt_curriculo_lattes" runat="server" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16"
                                                    runat="server"
                                                    ControlToValidate="txt_curriculo_lattes"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col" style="text-align: left; font-weight: bold; font-size: large; text-decoration: underline">
                                                <asp:Label ID="lbl_anexos" runat="server" Text="Anexos"></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col" style="text-align: justify; font-size: Small">
                                                Documentos digitalizados que deverão ser enviados após o preenchimento da ficha de inscrição, conforme estabelecidos no item 8.4 deste Edital: 
                                    <br />
                                                <br />
                                                - Carta de Intenção, na qual o candidato apresentará a razão pela qual deseja a bolsa; 
                                    <br />
                                                - Declaração de veracidade das informações prestadas, devidamente preenchida e assinada;
                                    <br />
                                                - Cópia digitalizada, frente e verso, do (s) diploma (s) de graduação e pós-graduação, reconhecido pelo Ministério da Educação – MEC, não sendo necessário documento autenticado;
                                    <br />
                                                - Documentos comprobatórios do currículo;
                                    <br />
                                                - Cópia digitalizada do RG e CPF do candidato;
                                    <br />
                                                - Declaração de não possuir vínculo empregatício.
                                    <br />
                                                <br />
                                                <asp:Label ID="lbl_tamanho" runat="server" Text="Arquivos no formato PDF com tamanho máximo de 5 MB. " Style="font-weight: 800; font-size: 10pt"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <div class="mb-3">
                                                    <label for="formFileSm" class="form-label" id="lbl_arquivo_upload"></label>
                                                    <asp:FileUpload class="form-control form-control-sm" ID="file_upload" runat="server" ToolTip="Indicar o caminho do arquivo a ser selecionado" />
                                                </div>
                                                <asp:Button ID="btn_upload" runat="server" Text="Upload" CssClass="btn btn-secondary btn-sm" ToolTip="Salvar anexo" OnClick="btn_upload_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <asp:Label ID="lblMensagemUpload" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:UpdatePanel ID="PanelUpload" runat="server">
                                            <ContentTemplate>
                                                <div>
                                                    <asp:GridView ID="gridAnexos" runat="server" CellPadding="0" AutoGenerateColumns="False" Width="100%"
                                                        HorizontalAlign="Center" Font-Size="Small" EmptyDataText="Não há anexo(s) cadastrado(s)" OnRowCommand="gridAnexos_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField AccessibleHeaderText="Anexo" DataField="NomeArquivo" HeaderText="Anexo(s)">
                                                                <ItemStyle Width="480px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEditar" runat="server" CommandName="Editar"
                                                                        CommandArgument='<%#Eval("NomeArquivo")%>' ImageUrl="~/Imagens/check20.png"
                                                                        ToolTip="Visualizar Anexo" Text="Visualizar" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle ForeColor="#990000" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnExcluir" runat="server" CommandName="Excluir" Text="Excluir"
                                                                        ToolTip="Excluir Anexo" CommandArgument='<%#Eval("NomeArquivo")%>' />
                                                                    <asp:ConfirmButtonExtender ID="btnExcluir_ConfirmButtonExtender" runat="server"
                                                                        ConfirmText="Deseja excluir o anexo?" Enabled="True"
                                                                        TargetControlID="btnExcluir">
                                                                    </asp:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle ForeColor="#990000" HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col" style="text-align: center">
                                                <asp:Button ID="btn_enviar" runat="server" Text="Enviar" CssClass="btn btn-success" ToolTip="Finalizar a inscrição" OnClick="btn_enviar_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="justify-content: center">
                                            <div class="col-sm-12 col-md-10 col-lg-8" style="grid-column-align: center">
                                                <span style="font-size: Small; text-align: justify">Ao clicar no botão "Enviar", o candidato aceita automaticamente e integralmente os termos e condições descritos no "Termo de Uso Sistema de Inscrições".</span>
                                                <br />
                                                <div class="col" style="text-align: center">
                                                    <a href="Arquivos/termo_de_uso_aplicacao_sistema_de_inscricoes.pdf" target="_blank"
                                                        style="font-size: Small; text-align: center; justify-content: center">Clique aqui e conheça o termo de uso</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="alert-success mt-2 text-center">
                        <asp:Label ID="Label1" runat="server" Text="Inscrição realizada com sucesso!" CssClass="h4 pl-2"></asp:Label>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <div class="alert-danger mt-2 text-center">
                        <asp:Label ID="Label4" runat="server" Text="Inscrições encerradas. Verifique o Edital para mais informações." CssClass="h4 pl-2"></asp:Label>
                    </div>                    
                </asp:View>
            </asp:MultiView>

        </form>
    </div>
</body>
</html>
