<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargosEditar.aspx.cs" Inherits="CargosEditar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Cargos</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Css/bootstrap.css" rel="stylesheet" />
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
            <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-dark" ToolTip="Retornar ao Menu" OnClick="btn_voltar_Click" Style="text-align: left; margin-top: 20px" CausesValidation="false" />
            <div class="row">
                <div class="col-lg-6 col-md-8 col-sm-10" style="margin: 0 auto">
                    <div class="card border-secondary mb-3">
                        <div class="card-header" style="text-align: center">
                            <h5>Cadastro de Cargos</h5>
                        </div>
                        <br />
                        <div class="card-body">
                            <div class="row form-group">
                                <asp:Label ID="lbl_descricao" runat="server" Text="Descrição:" CssClass="col-3"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_descricao" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server"
                                        ControlToValidate="txt_descricao"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 10px">
                        <div class="col" style="text-align: left">
                            <asp:Button ID="btn_salvar" runat="server" Text="Salvar" CssClass="btn btn-success" ToolTip="Salvar Alterações" OnClick="btn_salvar_Click" />
                        </div>
                        <div class="col" style="text-align: right">
                            <asp:Button ID="btn_excluir" runat="server" Text="Exluir" CssClass="btn btn-outline-danger" ToolTip="Excluir Departamento" OnClick="btn_excluir_Click" />
                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_excluir" ConfirmText="Deseja excluir o campo selecionado?" ></asp:ConfirmButtonExtender>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
