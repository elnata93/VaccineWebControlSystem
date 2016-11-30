<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Municipios.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Municipio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Municipios</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
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
                        <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox ID="DescripcionTextBox" CssClass="form-control" placeholder="Descripcion" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescripcion" runat="server" ErrorMessage="Solo se puede ingresar Letras" ControlToValidate="DescripcionTextBox" ForeColor="Red" ValidationExpression="^[A-ZÑ]+[a-zñ\s]+[a-zñ]$" ValidationGroup="A"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxDescripcion" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                                <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
