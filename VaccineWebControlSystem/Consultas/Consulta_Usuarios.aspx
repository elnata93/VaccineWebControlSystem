<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Consulta_Usuarios.aspx.cs" Inherits="VaccineWebControlSystem.Consultas.Consulta_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80px
        }
        .auto-style2 {
            width: 941px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Consulta de Usuarios</div>
                <div class="panel-body">
                    <div class="form-horizontal col-md-12" role="form">

                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label1" runat="server" Text="Buscar Por:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="FiltroDropDownList" runat="server" AutoPostBack="True">
                                        <asp:ListItem Value="UsuarioId">Id</asp:ListItem>
                                        <asp:ListItem>Nombre</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="FiltroTextBox" runat="server" Width="742px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <asp:GridView ID="ConsultaGridView" runat="server" Width="100%">
                        </asp:GridView>

                    <table style="width:100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                <asp:Button ID="ImprimirButton" runat="server" OnClick="ImprimirButton_Click1" Text="Imprimir" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
