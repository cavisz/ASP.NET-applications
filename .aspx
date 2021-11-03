<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <title>Ramais - IMAP</title>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.mim.js"></script>
</head>
<body>
    <%--  inicia o container para apresentação em "fluid" para ocupar width máx da pagina--%>
    <div class="container-fluid" style="font-family: Verdana">
        <form id="form2" runat="server">
            <div class="row">
                <div class="col-md-1">
                    <asp:Image src="imap_logo_2020.png" ID="Image1" runat="server" Width="129px" Height="77px" />
                </div>
                <div class="col-md-1">
                    <asp:Image src="listaramais.png" ID="Image2" runat="server" Height="57px" Width="319px" />
                </div>
            </div>
            <div style="margin-top: 8px; margin-left: 10px">
                <div class="row">
                    <div class="col-3">
                        <asp:TextBox class="form-control" ID="TextBox1" runat="server" Height="25px" Width="400px"></asp:TextBox>
                    </div>
                    <div class="col-1">
                        <asp:ImageButton src="lupa_18.png" ID="Image3" runat="server" OnClick="Button1_Click" ImageAlign="Right" Height="18px" Width="20px" />
                    </div>
                    <div class="col-1">
                        <asp:Image src="printer20.png" ID="Image4" runat="server" ImageAlign="AbsBottom" />
                    </div>
                    <br />
                </div>
            </div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="8" HorizontalAlign="Right" Width="100%" Border="collapse" Font-Size="Small" ShowHeaderWhenEmpty="True" EnableSortingAndPagingCallbacks="True" EnableViewState="False">
                <AlternatingRowStyle Font-Bold="False" Font-Size="Smaller" />
                <Columns>
                    <asp:BoundField DataField="PESS_STR_NOME" HeaderText="NOME" ItemStyle-Wrap="True" HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White" ValidateRequestMode="Enabled">
                        <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                        <ItemStyle Wrap="True"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PESS_STR_EMAIL" HeaderText="E-MAIL" HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                        <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PESS_STR_TELEFONE" HeaderText="TELEFONE" HeaderStyle-BackColor="#80A862" HeaderStyle-ForeColor="White">
                        <HeaderStyle BackColor="#80A862" ForeColor="White"></HeaderStyle>
                    </asp:BoundField>
                </Columns>
                <EditRowStyle Font-Size="Smaller" />
                <PagerStyle Font-Size="Smaller" />
                <RowStyle Font-Size="Smaller" />
                <SelectedRowStyle Wrap="False" Font-Size="Smaller" />
                <SortedAscendingCellStyle Wrap="False" />
            </asp:GridView>
        </form>
    </div>
</body>
</html>
