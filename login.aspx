<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.mim.js"></script>
    <script src="JavaScript.js"></script>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col" style="margin-top: 20px">
                    <asp:Image src="imap_logo_2020.png" ID="Image1" runat="server" margin="auto" CssClass="rounded mx-auto d-block" />
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-3 " style="margin: 0 auto">
                    <div class="card">
                        <div class="card-header" style="text-align: center">
                            Autenticação
                        </div>
                        <br />
                        <div class="card-body">
                            <asp:Label ID="label_usuario" runat="server">Usuário</asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_usuario" placeholder="Insira seu nome de usuário" MaxLength="20"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server"
                                ControlToValidate="txt_usuario"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                            <asp:Label ID="label_senha" Style="padding: 5px" runat="server">Senha</asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_senha" placeholder="Insira sua senha de usuário" MaxLength="20" TextMode="Password"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server"
                                ControlToValidate="txt_senha"
                                Text="Campo de preenchimento obrigatório!" CssClass="alert-success">
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:Button ID="btn_submeter" runat="server" Text="Submeter" CssClass="btn btn-primary" OnClick="btn_submeter_Click1" />
                            <cc1:MessageBox ID="MessageBox" runat="server" />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
