<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pessoas.aspx.cs" Inherits="Pessoas" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pessoas</title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <cc1:MessageBox ID="MessageBox1" runat="server" />
        <div class="container-fluid">
            <div class="row">
                <div class="col" style="background-color: #F7F7F7; border-style: solid; border-width: 1px; border-radius: 5px">
                    <asp:Image src="Imagens/imap_logo_207x141.png" runat="server" CssClass="img-fluid" alt="Responsive image" Width="150px" Style="text-align: left" />
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align: right; margin-top: 30px; margin-bottom:30px; margin-right:50px">
                    <asp:Button ID="btn_adicionar_pessoa" runat="server" Text="Adicionar" CssClass="btn btn-outline-success" ToolTip="Adicionar Pessoa"  OnClick="btn_adicionar_pessoa_Click"/>
                </div>
            </div>
            <asp:GridView ID="gridPessoas" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gridPessoas_SelectedIndexChanged"  CssClass="table-hover"
                Width="100%" DataKeyNames="PESS_INT_CODIGO" AllowPaging="True" OnPageIndexChanging="gridPessoas_PageIndexChanging" PageSize="15">
                <AlternatingRowStyle BorderStyle="none" />
                <Columns>
                    <asp:BoundField DataField="PESS_STR_NOME" HeaderText="NOME" />
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagens/check20.png" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle BackColor="#719D51" />
                <RowStyle VerticalAlign="Middle" />
            </asp:GridView>
            <div class="row">
                <div class="col" style="margin-top:30px; margin-left:50px">
                    <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-dark" ToolTip="Retornar ao Menu" OnClick="btn_voltar_Click" />
                </div>               
            </div>
        </div>
    </form>
</body>
</html>
