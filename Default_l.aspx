<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Localizare 2</title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="height: 100%; width: 100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <cc1:MessageBox ID="MessageBox1" runat="server" />
        <div class="container-fluid">
            <div class="row">
                <div class="col" style="background-color:#F7F7F7; border-style: solid; border-width: 1px; border-radius: 5px">
                    <asp:Image src="Imagens/imap_logo_207x141.png" runat="server" CssClass="img-fluid" alt="Responsive image" Width="150px" Style="text-align: left" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-8" style="margin: 0 auto; margin-top:60px">
                    <br />
                    <div class="card border-secondary mb-3">
                        <div class="card-header" style="text-align: center">
                            <h5>Menu</h5>
                        </div>
                        <div class="card-body">
                            <br />
                            <div class="row">
                                <div class="col" style="text-align: center">
                                    <h6 class="card-title">Pessoas</h6>
                                    <asp:ImageButton ID="btn_pessoas" runat="server" ImageUrl="~/Imagens/Users48.png" OnClick="btn_pessoas_Click" ToolTip="Editar Pessoas" />
                                </div>
                                <div class="col" style="text-align: center">
                                    <h6 class="card-title">Departamentos</h6>
                                    <asp:ImageButton ID="btn_departamentos" runat="server" ImageUrl="~/Imagens/formulario48.png" OnClick="btn_departamentos_Click" ToolTip="Editar Departamentos" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col" style="text-align: center">
                                    <h6 class="card-title">Cargos</h6>
                                    <asp:ImageButton ID="btn_cargos" runat="server" ImageUrl="~/Imagens/Doc48.png" OnClick="btn_cargos_Click" ToolTip="Editar Cargos" />
                                </div>
                                <div class="col" style="text-align: center">
                                    <h6 class="card-title">Locais</h6>
                                    <asp:ImageButton ID="btn_locais" runat="server" ImageUrl="~/Imagens/Web48.png" OnClick="btn_locais_Click" ToolTip="Editar Locais" />
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align: right; padding-right: 50px; margin-top:100px">
                    <asp:Button ID="btn_sair" runat="server" Text="Sair" CssClass="btn btn-outline-success" ToolTip="Logout" OnClick="btn_sair_Click" />
                </div>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
