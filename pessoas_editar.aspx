<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PessoasEditar.aspx.cs" Inherits="PessoasEditar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="ControleMessageBox" Namespace="ControleMessageBox" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar</title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/Mascara.js"></script>
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
                            <h5>Cadastro de Profissionais</h5>
                        </div>
                        <div class="card-body">
                            <div class="row form-group">
                                <asp:Label ID="lbl_nome" runat="server" Text="Nome:" CssClass="col-3"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_nome" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server"
                                        ControlToValidate="txt_nome"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class=" form-group row">
                                <asp:Label ID="lbl_ramal" runat="server" Text="Ramal:" CssClass="col-3"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_ramal" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="txt_ramal_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txt_ramal" ValidChars="0123456789/-">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server"
                                        ControlToValidate="txt_ramal"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label ID="lbl_datNasc" runat="server" Text="Data de Nascimento:" CssClass="col-3"></asp:Label>
                                <div class="col-9">
                                    <asp:TextBox ID="txt_datNasc" runat="server" CssClass="form-control" MaxLength="20" onkeyup="formataData(this, event)"></asp:TextBox>                                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                        runat="server"
                                        ControlToValidate="txt_datNasc"
                                        Text="Campo de preenchimento obrigatório!" text-align="left" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                     <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="01/01/1950" MaximumValue="31/12/2022" ControlToValidate="txt_datNasc" Type="Date" ErrorMessage="Data Inválida!" CssClass="alert-danger"></asp:RangeValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label ID="lbl_email" runat="server" Text="E-mail:" CssClass="col-3"></asp:Label>
                                <div class="col">
                                    <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" MaxLength="150" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                        runat="server"
                                        ControlToValidate="txt_datNasc"
                                        Text="Campo de preenchimento obrigatório!" CssClass="alert-danger">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label ID="lbl_departamento" runat="server" Text="Departamento:" CssClass="col-3"></asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddl_departamento" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label ID="lbl_cargo" runat="server" Text="Cargo:" CssClass="col-3"></asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddl_cargo" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label ID="lbl_local" runat="server" Text="Local:" CssClass="col-3"></asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddl_local" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 10px">
                        <div class="col" style="text-align: left">
                            <asp:Button ID="btn_salvar" runat="server" Text="Salvar" CssClass="btn btn-success" ToolTip="Salvar Alterações" OnClick="btn_salvar_Click" />
                        </div>
                        <div class="col" style="text-align: right">
                            <asp:Button ID="btn_excluir" runat="server" Text="Exluir" CssClass="btn btn-outline-danger" ToolTip="Excluir Pessoa" OnClick="btn_excluir_Click" CausesValidation="false" />
                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_excluir" ConfirmText="Deseja excluir o campo selecionado?" ></asp:ConfirmButtonExtender>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
