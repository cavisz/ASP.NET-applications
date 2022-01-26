<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <cc1:MessageBox ID="MessageBox1" runat="server" />
        <div class="container-fluid">
            <br />
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-4  col-md-6 col-sm-8" style="margin: 0 auto">
                    <div class="card border-secondary mb-3">
                        <div class="card-header" style="text-align: center">
                            <asp:Image src="Imagens/imap_logo_207x141.png" runat="server" ImageAlign="Left" Width="150px" class="img-fluid" alt="Imagem responsiva" />
                            <div class="row">
                                <div class="col"  style="padding-top:35px">
                                    <h4>Autenticação</h4>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="label_usuario" runat="server">Usuário</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_usuario" placeholder="Insira seu nome de usuário" MaxLength="20" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server"
                                        ControlToValidate="txt_usuario"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="label_senha" Style="padding: 5px" runat="server">Senha</asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_senha" placeholder="Insira sua senha de usuário" MaxLength="20" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server"
                                        ControlToValidate="txt_senha"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col" style="text-align: center">
                                    <asp:Button ID="btn_Entrar" runat="server" Text="Entrar" CssClass="btn btn-success" OnClick="btn_Entrar_Click" Style="text-align: center" ToolTip="Logar usuário"/>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
