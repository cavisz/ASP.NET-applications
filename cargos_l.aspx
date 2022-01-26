<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cargos.aspx.cs" Inherits="Cargos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cargos</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <cc1:MessageBox ID="MessageBox1" runat="server" />
        <div class=" container-fluid">
            <div class="row">
                <div class="col" style="background-color: #F7F7F7; border-style: solid; border-width: 1px; border-radius: 5px">
                    <asp:Image src="Imagens/imap_logo_207x141.png" runat="server" CssClass="img-fluid" alt="Responsive image" Width="150px" Style="text-align: left" />
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align: right; margin-top: 30px; margin-bottom: 30px; margin-right: 50px">
                    <asp:Button ID="btn_adicionar_cargo" runat="server" Text="Adicionar" CssClass="btn btn-outline-success" ToolTip="Adicionar Cargo" OnClick="btn_adicionar_cargo_Click" />
                </div>
            </div>
            <asp:GridView ID="gridCargos" runat="server" AutoGenerateColumns="False" CssClass="table-hover"  OnSelectedIndexChanged="gridCargos_SelectedIndexChanged" Width="100%" DataKeyNames="CARG_INT_CODIGO" >
                <AlternatingRowStyle  />
                <Columns>
                    <asp:BoundField DataField="CARG_STR_DESCRICAO" HeaderText="CARGO" />
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagens/check20.png" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle BackColor="#719D51" />
                <RowStyle VerticalAlign="Middle" />
            </asp:GridView>
            <div class="row">
                <div class="col" style="margin-top: 20px; margin-left: 50px">
                    <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-success" ToolTip="Retornar ao Menu" OnClick="btn_voltar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
