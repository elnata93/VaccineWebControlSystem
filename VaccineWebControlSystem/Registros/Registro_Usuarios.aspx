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

                    <div class="form-group ">
                        <div class="container  ">
                            <asp:Image ID="FotoImage" runat="server" />
                            <asp:FileUpload ID="FotoFileUpload" runat="server" />
                            <asp:Button ID="SubirButton" runat="server" Text="Upload" OnClick="SubirButton_Click" />
                        </div>
                    </div>


                    <br />
                    <br />
                    <br />
                    <div class="form-horizontal col-md-12 " role="form">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                        <div class="form-group">
                            <div class="col-md-11">
                                <asp:TextBox ID="IdTextBox" CssClass="form-control " placeholder="ID" runat="server" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
                            </div>
                        </div>
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="ApellidoTextBox" CssClass="form-control" placeholder="Apellido" runat="server"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="DireccionTextBox" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" Text="Cedula"></asp:Label>
                        <asp:TextBox ID="CedulaTextBox" runat="server" CssClass="form-control" placeholder="Cedula"></asp:TextBox>
                        <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label>
                        <asp:TextBox ID="TelefonoTextBox" runat="server" CssClass="form-control" placeholder="Telefono"></asp:TextBox>
                        <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" Text="Cedula"></asp:Label>
                        <asp:DropDownList ID="CiudadDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:Label ID="Label9" runat="server" Text="Nombre de Usuario"></asp:Label>
                        <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                        <asp:Label ID="Label10" runat="server" Text="Tipo de Usurio"></asp:Label>
                        <asp:DropDownList ID="TipoUsuarioDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem>Administrador</asp:ListItem>
                            <asp:ListItem>Empleado</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label11" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                        <asp:Label ID="Label12" runat="server" Text="Confimar Contraseña"></asp:Label>
                        <asp:TextBox ID="ConfContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Confimar Contraseña"></asp:TextBox>

                    </div>

                    <div class="form-horizontal col-lg-12 " role="form">
                        <br />
                        <br />
                        <br />
                        <div class="form-group ">
                            <div class="container text-center ">
                                <asp:Button ID="NuevoButton" CssClass="btn btn-primary" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                                <asp:Button ID="GuardarButton" CssClass="btn btn-success" runat="server" OnClick="GuardarButton_Click" Text="Guardar" />
                                <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
