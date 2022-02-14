<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticiasEditar.aspx.cs" Inherits="NoticiasEditar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Notícias</title>
    <link href="script/Css/bootstrap.css" rel="stylesheet" />
    <script src="script/js/jquery-3.3.1.mim.js"></script>
    <script src="script/js/Mascara.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:MessageBox ID="MessageBox1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <asp:Image src="Imagens/IntranetLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="200px" Height="60px" ImageAlign="Left" Style="padding-top: 10px" />
                    <asp:Image src="Imagens/CuritibaLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="60px" Height="80" ImageAlign="Right" />
                    <asp:Image src="Imagens/ImapLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="130px" Height="80px" ImageAlign="Right" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-8 col-sm-10" style="margin: 0 auto">
                    <div class="card border-secondary mb-3">
                        <div class="card-header" style="text-align: center">
                            <h5>Notícias</h5>
                        </div>
                        <div class="card-body">
                            <div class="row form-group">
                                <asp:Label runat="server" Text="Título:" CssClass="col-3" ID="lbl_titulo"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_titulo" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server"
                                        ControlToValidate="txt_titulo"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label runat="server" Text="Descrição:" CssClass="col-3" ID="lbl_descricao"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_descricao" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server"
                                        ControlToValidate="txt_descricao"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label runat="server" Text="Foto:" CssClass="col-3" ID="Label1"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_foto" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                        runat="server"
                                        ControlToValidate="txt_foto"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label runat="server" Text="Data:" CssClass="col-3" ID="Label2"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_data" runat="server" CssClass="form-control" MaxLength="10" onkeyup="formataData(this, event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                        runat="server"
                                        ControlToValidate="txt_data"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                     <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="01/01/2018" MaximumValue="31/12/2028" ControlToValidate="txt_data" Type="Date" ErrorMessage="Data Inválida!" CssClass="alert-danger"></asp:RangeValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label runat="server" Text="Categoria:" CssClass="col-3" ID="Label3"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_categoria" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                        runat="server"
                                        ControlToValidate="txt_categoria"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 20px">
                        <div class="col" style="text-align: left">
                            <asp:Button ID="btn_salvar" runat="server" Text="Salvar" CssClass="btn btn-success" ToolTip="Salvar Alterações" OnClick="btn_salvar_Click" />
                        </div>
                        <div class="col" style="text-align: right">
                            <asp:Button ID="btn_excluir" runat="server" Text="Exluir" CssClass="btn btn-outline-danger" ToolTip="Excluir Local" OnClick="btn_excluir_Click" CausesValidation="false"/>
                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_excluir" ConfirmText="Deseja excluir o campo selecionado?"></asp:ConfirmButtonExtender>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align: left; margin-top: 50px">
                    <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-dark" ToolTip="Retornar ao Menu" OnClick="btn_voltar_Click" CausesValidation="false" />
                </div>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
