<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_napi.aspx.cs" Inherits="adm_napitaxoline_Login_napi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/jquery-3.3.1.mim.js"></script>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col" style="text-align: center">
                                <br />
                                <h4>NAPI TAXONLINE – Rede Paranaense de Coleções Biológicas nos Museus da Prefeitura Municipal de Curitiba.</h4>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-8 col-md-5 col-lg-3 " style="margin: 0 auto">
                                <div class="card">
                                    <div class="card-header" style="text-align: center">
                                        Autenticação
                                    </div>
                                    <div class="card-body" style="text-align: left">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_usuario" runat="server">Usuário</asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_usuario" placeholder="Insira seu nome de usuário" MaxLength="20" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                    runat="server"
                                                    ControlToValidate="txt_usuario"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="label_senha" runat="server">Senha</asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_senha" placeholder="Insira sua senha de usuário" MaxLength="20" TextMode="Password" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                    runat="server"
                                                    ControlToValidate="txt_senha"
                                                    Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col" style="text-align: center">
                                                <asp:Button ID="btn_submeter" runat="server" Text="Enviar" CssClass="btn btn-success" OnClick="btn_submeter_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <asp:Image src="../Imagens/imap_logo_2017.png" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Height="90px" Width="150px" />
                                <h4 style="text-align: center; padding-bottom: 40px">Inscrições</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col" style="text-align: right">
                                <asp:Button ID="btn_voltar_login" runat="server" CssClass="btn btn-dark" OnClick="btn_voltar_login_Click" Text="Voltar" />
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="100%" HorizontalAlign="Center" ShowHeaderWhenEmpty="true" EmptyDataText="Nenhum registro encontrado">
                            <Columns>
                                <asp:BoundField DataField="napi_nome" HeaderText="NOME" ItemStyle-Wrap="True" HeaderStyle-BackColor="#80A862" />
                                <asp:BoundField DataField="napi_cpf" HeaderText="CPF" ItemStyle-Wrap="True" HeaderStyle-BackColor="#80A862" />
                                <asp:BoundField DataField="napi_email" HeaderText="E-MAIL" ItemStyle-Wrap="True" HeaderStyle-BackColor="#80A862" />
                                <asp:TemplateField HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Button ID="lknEditar" runat="server" Text="Editar" CommandArgument='<%# Eval ("napi_codigo")  %>' CommandName="Editar" CssClass="btn btn-warning" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <div class="container-fluid">
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="btn_voltar_grid" runat="server" CssClass="btn btn-dark" OnClick="btn_voltar_grid_Click" Text="Voltar" Style="text-align: left" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-8 " style="margin: 0 auto">
                                <div class="card">
                                    <div class="card-header" style="text-align: center; font-weight: bold; font-size: large">Candidato</div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_nome" runat="server" Text="Nome:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_nome" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_cpf" runat="server" Text="CPF:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_cpf" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_rg" runat="server" Text="RG:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_rg" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_escolaridade" runat="server" Text="Escolaridade:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_escolaridade" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_ano_cnclusao" runat="server" Text="Ano de Conclusão:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_ano_conclusao" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_curso" runat="server" Text="Curso:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_curso" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_intituicao" runat="server" Text="Instituição de Ensino:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_instituicao" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_endereco" runat="server" Text="Endereço Residencial:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_endereco" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_numero_casa" runat="server" Text="N°:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_numero_casa" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_complemento" runat="server" Text="Complemento:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_complemento" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_bairro" runat="server" Text="Bairro:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_bairro" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_cidade" runat="server" Text="Cidade:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_cidade" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_estado" runat="server" Text="Estado (sigla):" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_estado" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_cep" runat="server" Text="CEP:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_cep" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_telefone" runat="server" Text="Telefone:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_telefone" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_celular" runat="server" Text="Celular:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_celular" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_email" runat="server" Text="E-mail:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_email" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_opcao_bolsa" runat="server" Text="Opção pela Bolsa:" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_opcao_bolsa" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_curriculo_lattes" runat="server" Text="Currículo Lattes atualizado (link para acesso):" Style="text-align: left"></asp:Label>
                                                <asp:TextBox ID="txt_curriculo_lattes" runat="server" Enabled="false" Style="display: block; float: right" Width="60%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col">
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
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col" style="text-align: right">
                                <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CssClass="btn btn-danger" OnClick="btn_excluir_Click" />
                                <asp:ConfirmButtonExtender ID="btnExcluir_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Deseja excluir a inscrição?" Enabled="True"
                                    TargetControlID="btn_excluir">
                                </asp:ConfirmButtonExtender>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
    <cc1:MessageBox ID="MessageBox1" runat="server" />

</body>
</html>
