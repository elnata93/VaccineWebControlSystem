<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Usuarios.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style type="text/css">
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
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Usuarios</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">

                    <%--<div class="form-group ">
                        <div class="container  ">
                            <asp:Image ID="FotoImage" runat="server" />
                            <asp:FileUpload ID="FotoFileUpload" runat="server" />
                            <asp:Button ID="SubirButton" runat="server" Text="Upload" OnClick="SubirButton_Click" />
                        </div>
                    </div>--%>


                    <br />
                    <br />
                    <br />
                    <div class="form-horizontal col-md-12 " role="form">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                        <div class="form-group">
                            <div class="col-md-11">
                                <asp:TextBox ID="IdTextBox" CssClass="form-control " placeholder="ID" runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorID" runat="server" ErrorMessage="Solo se puede ingresar numeros" ForeColor="Red" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$" ValidationGroup="B" ControlToValidate="IdTextBox"></asp:RegularExpressionValidator>

                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" OnClick="BuscarButton_Click" Text="Buscar" ValidationGroup="B" />
                            </div>
                        </div>
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Nombre" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="Campo requerido" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="ApellidoTextBox" CssClass="form-control" placeholder="Apellido" runat="server" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ErrorMessage="Campo requerido" ControlToValidate="ApellidoTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Sexo:"></asp:Label>
                        <br />
                        <asp:RadioButton ID="MasculinoRadioButton" Checked="True" GroupName="RadioGroup1" runat="server" Text="Masculino" />
                        <asp:RadioButton ID="FemeninoRadioButton" GroupName="RadioGroup1" runat="server" Text="Femenino" />
                        <br />
                        <%-- Validate RadioButton --%>

                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="DireccionTextBox" runat="server" CssClass="form-control" placeholder="Direccion" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" runat="server" ErrorMessage="Campo requerido" ControlToValidate="DireccionTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Cedula"></asp:Label>
                        <asp:TextBox ID="CedulaTextBox" runat="server" CssClass="form-control" placeholder="Cedula" TextMode="Number" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCedula" runat="server" ErrorMessage="Campo requerido" ControlToValidate="CedulaTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label>
                        <asp:TextBox ID="TelefonoTextBox" runat="server" CssClass="form-control" placeholder="Telefono" TextMode="Phone" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" ErrorMessage="Campo requerido" ControlToValidate="TelefonoTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email" ValidationGroup="A"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Correo invalido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="A"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Campo requerido" ControlToValidate="EmailTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Ciudad"></asp:Label>
                        <asp:DropDownList ID="CiudadDropDownList" runat="server" CssClass="form-control" ValidationGroup="A"></asp:DropDownList>
                        <asp:Label ID="Label9" runat="server" Text="Nombre de Usuario"></asp:Label>
                        <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Nombre de Usuario" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreUsuario" runat="server" ErrorMessage="Campo requerido" ControlToValidate="NombreUsuarioTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="Tipo de Usurio"></asp:Label>
                        <asp:DropDownList ID="TipoUsuarioDropDownList" runat="server" CssClass="form-control" ValidationGroup="A">
                            <asp:ListItem>Administrador</asp:ListItem>
                            <asp:ListItem>Empleado</asp:ListItem>
                        </asp:DropDownList>

                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="ContrasenaTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" ValidationGroup="A"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorContrasena" runat="server" ErrorMessage="Campo requerido" ValidationGroup="A" ControlToValidate="ContrasenaTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="Confimar Contraseña"></asp:Label>
                        <asp:TextBox ID="ConfContrasenaTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confimar Contraseña" ValidationGroup="A"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidatorContrasena" runat="server" ControlToCompare="ContrasenaTextBox" ControlToValidate="ConfContrasenaTextBox" ErrorMessage="No coinciden" ForeColor="Red" ValidationGroup="A"></asp:CompareValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmarContrasena" runat="server" ControlToValidate="ConfContrasenaTextBox" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>

                    </div>

                    <div class="form-horizontal col-lg-12 " role="form">
                        <br />
                        <br />
                        <div class="form-group ">
                            <div class="container text-center ">
                                <asp:Button ID="NuevoButton" CssClass="btn btn-primary" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                                <asp:Button ID="GuardarButton" CssClass="btn btn-success" runat="server" OnClick="GuardarButton_Click" Text="Guardar" ValidationGroup="A" />
                                <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
