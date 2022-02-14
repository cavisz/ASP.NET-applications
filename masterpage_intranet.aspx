<%@ Master Language="C#" AutoEventWireup="true" CodeFile="MasterPage.master.cs" Inherits="MasterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intranet</title>
    <link href="script/Css/bootstrap.css" rel="stylesheet" />

    <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark justify-content-between " style="border-style: solid; border-width: 1px; border-radius: 5px">
                <div class="col">
                    <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="btn btn-link" Style="color: #ffffff" ToolTip="Entrar na Intranet" OnClick="btn_login_Click"/>
                </div>
                <div class="col" style="text-align: right">
                    <asp:Button ID="btn_pesquisa" runat="server" Text="Pesquisar" CssClass="btn btn-sm btn-secondary" Style="margin-right: 10px" ToolTip="Pesquisar conteúdo" OnClick="btn_pesquisa_Click" />
                    <asp:TextBox class="form-control mr-sm-2" type="search" aria-label="Search" runat="server" Width="200px" Style="float: right" Height="30px" ID="txt_pesquisa" />
                </div>

            </nav>
            <div class="row" style="margin: 20px">
                <div class="col">
                    <asp:Image src="Imagens/IntranetLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="200px" Height="60px" ImageAlign="Left" style="padding-top:10px"/>
                    <asp:Image src="Imagens/CuritibaLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="60px" Height="80" ImageAlign="Right" />
                    <asp:Image src="Imagens/ImapLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="130px" Height="80px" ImageAlign="Right" />
                </div>
            </div>
            <div class="row" style="margin: 60px 20px 20px; text-align: right">
                <div class="col">
                    <h6><a href="http://intranet.imap.curitiba.pr.gov.br/" class="text-secondary">Início</a></h6>
                </div>
                <div class="row" style="text-align: right; margin-left:10px; margin-right:10px">
                    <div class="col">
                        <h6><a href="http://intranet.imap.curitiba.pr.gov.br/index.php/imap-conecta-3/" class="text-secondary">IMAP Conecta</a></h6>
                    </div>
                </div>
                <div class="row" style="text-align: right; margin-left:10px; margin-right:10px ">
                    <div class="col">
                        <h6><a href="http://intranet.imap.curitiba.pr.gov.br/index.php/agenda-de-salas-2/" class="text-secondary">Agenda de salas</a></h6>
                    </div>
                </div>
                <div class="row" style="text-align: right; margin-left:10px; margin-right:10px">
                    <div class="col">
                        <h6><a href="#" class="text-secondary">Legislação</a></h6>
                    </div>
                </div>
                <div class="row" style="text-align: right; margin-left:10px; margin-right:10px">
                    <div class="col">
                        <h6><a href="#" class="text-secondary">Seções</a></h6>
                    </div>
                </div>
                <div class="row" style="text-align: right; margin-left:10px; margin-right:10px">
                    <div class="col">
                        <h6><a href="#" class="text-secondary">Informes RH</a></h6>
                    </div>
                </div>
                <div class="row" style="text-align: right; margin-left:10px; margin-right:10px">
                    <div class="col">
                        <h6><a href="#" class="text-secondary">Servidores</a></h6>
                    </div>
                </div>
            </div>
            <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">
            </asp:ContentPlaceHolder>
        </div>
    </form>
</body>
</html>
