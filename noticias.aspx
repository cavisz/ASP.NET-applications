<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Noticias.aspx.cs" Inherits="NoticiasEditar" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Notícias</title>
    <script src="script/js/jquery-3.3.1.mim.js"></script>
    <link href="script/Css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <cc1:MessageBox ID="MessageBox1" runat="server" />
            <div class="row">
                <div class="col">
                    <asp:Image src="Imagens/IntranetLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="200px" Height="60px" ImageAlign="Left" Style="padding-top: 10px" />
                    <asp:Image src="Imagens/CuritibaLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="60px" Height="80" ImageAlign="Right" />
                    <asp:Image src="Imagens/ImapLogo.jpg" runat="server" CssClass="img-fluid mt-2" alt="Responsive image" Width="130px" Height="80px" ImageAlign="Right" />
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align:right; margin-top:50px">
                    <asp:Button ID="btn_adicionar" runat="server" Text="Adicionar" CssClass="btn btn-outline-success" ToolTip="Adicionar Notícia" OnClick="btn_adicionar_Click"/>
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align: center; margin-top: 80px; margin-bottom: 30px; margin-right: 50px">
                    <asp:GridView ID="grid_noticias" runat="server" AutoGenerateColumns="False" CssClass="table-hover table table-secondary table-bordered" Width="70%" DataKeyNames="NOTI_INT_CODIGO" OnRowCommand="grid_noticias_RowCommand" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="NOTI_TXT_TITULO" HeaderText="TÍTULO" />
                             <asp:BoundField DataField="NOTI_CATEGORIA" HeaderText="CATEGORIA" />
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="lknEditar" runat="server" Text="Editar" CommandArgument='<%# Eval ("NOTI_INT_CODIGO")  %>' CommandName="Editar" CssClass="btn btn-secondary" tooltip="Editar Notícia"/>
                                </ItemTemplate>                             
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle VerticalAlign="Middle" />
                    </asp:GridView>
                    <div class="row">
                        <div class="col" style="text-align:left; margin-top:50px">
                            <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-dark" ToolTip="Retornar ao Menu" OnClick="btn_voltar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
