<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Usuarios.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 951px;
            height: 316px;
        }
        .auto-style2 {
            width: 149px;
        }
    .auto-style3 {
        width: 656px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="panel panel-success">
                <div class="panel-heading">Registro de Usuarios</div>
                <div class="panel-body">
                    <div class="form-horizontal col-md-12" role="form">
                        <asp:Image ID="FotoImage" runat="server" />
                        <asp:FileUpload ID="FotoFileUpload" runat="server" />
                        <asp:Button ID="SubirButton" runat="server" Text="Subir" OnClick="SubirButton_Click" />

                        <table class="auto-style1" >
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Id</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="IdTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Nombre</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="NombreTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Apellido</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="ApellidoTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">DIreccion</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="DireccionTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Cedula</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="CedulaTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Telefono</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="TelefonoTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Email</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="EmailTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Ciudad</td>
                                <td class="auto-style3">
                                    <asp:DropDownList ID="CiudadDropDownList" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Nombre de Usuario</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Tipo de Usuario</td>
                                <td class="auto-style3">
                                    <asp:DropDownList ID="TipoUsuarioDropDownList" runat="server" Width="100%">
                                        <asp:ListItem>Administrador</asp:ListItem>
                                        <asp:ListItem>Empleado</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Contraseña</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="ContrasenaTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Confirmar Contraseña</td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="ConfContrasenaTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style3">
                                    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                                    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
