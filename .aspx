<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>CRUD</title>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.mim.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class=" container-fluid">
            <div class="row">
                <div class="col">
                    <asp:Image src="imap_logo_2020.png" ID="Image1" runat="server" />
                    <asp:Image src="listaramais.png" ID="Image2" runat="server" />
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server">
                <%--define a página como várias "sub páginas" para apresentar na ordem definida na página cs--%>
                <asp:View ID="View1" runat="server">
                    <div class="row">
                        <div class="col-md-3" style="margin-top: 10px; margin-bottom: 5px">
                            <asp:TextBox ID="txt_pesquisa" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col">
                            <asp:ImageButton src="lupa_18.png" ID="Image3" runat="server" OnClick="Image3_Click" Style="margin-top: 15px; margin-right: 10px" />
                            <asp:Image src="printer20.png" ID="Image4" runat="server" Style="margin-bottom: 6px" />
                        </div>
                        <div class="col" style="align-content:space-around">
                            <asp:Button ID="btn_adicionar_pessoa" runat="server" Text="Adicionar Pessoa" Class="btn btn-dark" OnClick="btn_adicionar_pessoa_Click" style="align-self:stretch"/>
                        </div>
                    </div>
                    <br />
                    <%--container de apresentação--%>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="8" EnableModelValidation="true" OnRowCommand="OnRowCommand" Width="100%">
                        <%--apresenta as infomações para o usuário em forma de tabela para visualização, é sempre última instância do view e multiview--%>
                        <Columns>
                            <%--define colunas para apresentar a tabela e ordenar corretamente para apresentação--%>
                            <asp:BoundField DataField="PESS_STR_NOME" HeaderText="NOME" ItemStyle-Wrap="True" HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                                <%--boundfield conecta a amostragem de informações direto do banco de dados da minha página cs--%>
                            </asp:BoundField>
                            <asp:BoundField DataField="PESS_STR_EMAIL" HeaderText="E-MAIL" HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PESS_STR_RAMAL" HeaderText="RAMAL " HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DEPA_STR_SIGLA" HeaderText="DEPARTAMENTO " HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="LOCA_STR_SIGLA" HeaderText="LOCAL " HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Button ID="lknEditar" runat="server" Text="Editar" CommandArgument='<%# Eval ("PESS_INT_CODIGO")  %>' CommandName="Editar" CssClass="btn btn-outline-secondary" />
                                </ItemTemplate>
                                <%-- (CommandArgument)argumento para recebimento de informações para realizar a pesquisa e recebimento de informações na página cs para a asp net--%>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <%--segunda vizualização presente na multiview, para edição de informações da tabela--%>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label_nome" runat="server" Text="NOME" ></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txt_nome" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server"
                                ControlToValidate="txt_nome"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label_email" runat="server" Text="E-MAIL"></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txt_email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server"
                                ControlToValidate="txt_email"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label_ramal" runat="server" Text="RAMAL"></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txt_ramal" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                runat="server"
                                ControlToValidate="txt_ramal"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col">
                            <asp:Label ID="Label_departamentos" runat="server" Text="DEPARTAMENTOS "></asp:Label>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataValueField="DEPA_INT_CODIGO" DataTextField="DEPA_STR_SIGLA"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                runat="server"
                                ControlToValidate="DropDownList1"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label_local" runat="server" Text="LOCAL"></asp:Label>
                            <asp:DropDownList ID="DropDownList_local" runat="server" CssClass="form-control" DataValueField="LOCA_INT_CODIGO" DataTextField="LOCA_STR_SIGLA"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                runat="server"
                                ControlToValidate="DropDownList_local"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Button ID="btn_salvar" runat="server" Text="Salvar" CssClass="btn btn-outline-secondary" OnClick="btn_salvar_Click" />
                            <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CssClass="btn btn-outline-secondary" OnClick="btn_excluir_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <br />
                            <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-dark" OnClick="btn_voltar_Click" CausesValidation="false" />
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>

