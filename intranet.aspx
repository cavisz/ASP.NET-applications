<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Intranet.aspx.cs" Inherits="Intranet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intranet</title>
    <script src="script/js/jquery-3.3.1.mim.js"></script>
    <link href="script/Css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
        rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <asp:Image src="Imagens/IntranetLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="200px" Height="60px" ImageAlign="Left" Style="padding-top: 10px" />
                    <asp:Image src="Imagens/CuritibaLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="60px" Height="80" ImageAlign="Right" />
                    <asp:Image src="Imagens/ImapLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="130px" Height="80px" ImageAlign="Right" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-6 col-sm-6" style="margin: 0 auto; margin-top: 100px">
                    <div class="card border-secondary mb-3">
                        <div class="card-header" style="text-align: center">
                            <h5>Menu</h5>
                        </div>
                        <div class="card-body" style="text-align: center">
                            <div class="row">
                                <div class="col">
                                    <h6 class="card-title">Notícias</h6>
                                    <asp:ImageButton ImageUrl="Imagens/icon_noticias.png" runat="server" ID="btn_noticias" OnClick="btn_noticias_Click" />
                                </div>
                                <div class="col">
                                    <h6 class="card-title">Acesso Rápido</h6>
                                    <asp:ImageButton ImageUrl="Imagens/icon_acesso_rapido.png" runat="server" ID="btn_acesso_rapido" OnClick="btn_acesso_rapido_Click" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <h6 class="card-title">Formulários</h6>
                                    <asp:ImageButton ImageUrl="Imagens/icon_formularios.png" runat="server" ID="btn_formularios" OnClick="btn_formularios_Click" />
                                </div>
                                <div class="col">
                                    <h6 class="card-title">Sistemas</h6>
                                    <asp:ImageButton ImageUrl="Imagens/icon_sistemas.png" runat="server" ID="btn_sistemas" OnClick="btn_sistemas_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <h6 class="card-title">Manuais</h6>
                                    <asp:ImageButton ImageUrl="Imagens/icon_manuais.png" runat="server" ID="btn_manuais" OnClick="btn_manuais_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align: right; padding-right: 100px; padding-top: 100px">
                    <asp:Button ID="btn_logout" runat="server" Text="Logout" CssClass="btn btn-danger" ToolTip="Sair do domínio" OnClick="btn_logout_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
