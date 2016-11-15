<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Pacientes.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="panel panel-success">
                <div class="panel-heading">Registro de Pacientes</div>
                <div class="panel-body">
                    <div class="form-horizontal col-md-12" role="form">
        
                    
                    
                        <table class="nav-justified">
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="IdTextBox" runat="server" Height="20px" Width="148px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="BuscarButton" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="NombreTextBox" runat="server"  Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="ApellidoTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label4" runat="server" Text="Edad:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="EdadTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label5" runat="server" Text="Sexo:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:RadioButton ID="MasculinoRadioButton" runat="server" Text="Masculino" />
                                    <asp:RadioButton ID="FemeninoRadioButton" runat="server" Text="Femenino" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label6" runat="server" Text="Direccion:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="DireccionTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label7" runat="server" Text="Telefono:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="TelefonoTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label8" runat="server" Text="Cedula:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="CedulaTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    &nbsp;</td>
                                <td class="auto-style5">
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">
                                    <asp:Button ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                                    <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" Text="Guardar" />
                                    <asp:Button ID="EliminarButton" runat="server" OnClick="EliminarButton_Click" Text="Eliminar" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            
                        </table>
        
                    
                    
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
