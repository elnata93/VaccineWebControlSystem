<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Pacientes.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Pacientes</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <br />
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
                    <div class="form-horizontal col-md-12" role="form">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                            <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control " placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="Campo requerido" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>

                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
                            <asp:TextBox ID="ApellidoTextBox" runat="server" CssClass="form-control " placeholder="Apellido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ErrorMessage="Campo requerido" ControlToValidate="ApellidoTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Edad:"></asp:Label>
                            <asp:TextBox ID="EdadTextBox" runat="server" CssClass="form-control " placeholder="Edad"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEdad" runat="server" ErrorMessage="Campo requerido" ControlToValidate="EdadTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Sexo:"></asp:Label>
                            <asp:RadioButton ID="MasculinoRadioButton" Checked="True" GroupName="RadioGroup1" runat="server" Text="Masculino" />
                            <asp:RadioButton ID="FemeninoRadioButton" GroupName="RadioGroup1" runat="server" Text="Femenino" />
                            <br />
                            <asp:RangeValidator ID="RangeValidatorSexo" runat="server" ErrorMessage="Campo requerido" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationGroup="A"></asp:RangeValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label6" runat="server" Text="Direccion:"></asp:Label>
                            <asp:TextBox ID="DireccionTextBox" runat="server" CssClass="form-control " placeholder="Direccion"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" runat="server" ErrorMessage="Campo requerido" ControlToValidate="DireccionTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="Telefono:"></asp:Label>
                            <asp:TextBox ID="TelefonoTextBox" runat="server" CssClass="form-control " placeholder="Telefono"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" ErrorMessage="Campo requerido" ControlToValidate="TelefonoTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="Cedula:"></asp:Label>
                            <asp:TextBox ID="CedulaTextBox" runat="server" CssClass="form-control " placeholder="Cedula"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCedula" runat="server" ErrorMessage="Campo requerido" ControlToValidate="CedulaTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <div class="form-horizontal col-lg-12 " role="form">
                        <br />
                        <br />
                        <br />
                        <div class="form-group ">
                            <div class="container text-center ">
                                <asp:Button ID="NuevoButton" CssClass="btn btn-primary" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                                <asp:Button ID="GuardarButton" CssClass="btn btn-success" runat="server" OnClick="GuardarButton_Click" Text="Guardar" ValidationGroup="A" />
                                <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" OnClick="EliminarButton_Click" Text="Eliminar" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
