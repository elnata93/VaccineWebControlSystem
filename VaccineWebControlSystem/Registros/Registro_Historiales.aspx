<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Historiales.aspx.cs" Inherits="VaccineWebControlSystem.Registros.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Historial</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="form-group ">
                        <div class="col-md-11 ">
                            <asp:Label ID="Label10" runat="server" Text="Fecha:"></asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="FechaLabel" runat="server"></asp:Label>
                        </div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    <div class="form-group">
                        <div class="col-md-11">
                            <asp:TextBox ID="IdTextBox" CssClass="form-control " placeholder="ID" runat="server" />
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
                        </div>
                    </div>
                    <asp:Label ID="Label2" runat="server" Text="Centro de Salud:"></asp:Label>

                    <asp:TextBox ID="CentroSaludTextBox" runat="server" CssClass="form-control " placeholder="Centro de Salud"></asp:TextBox>

                    <asp:Label ID="Label3" runat="server" Text="Provincia:"></asp:Label>

                    <asp:DropDownList ID="ProvinciaDropDownList" runat="server" CssClass="form-control ">
                    </asp:DropDownList>

                    <asp:Label ID="Label4" runat="server" Text="Municipio:"></asp:Label>

                    <asp:DropDownList ID="MunicipioDropDownList" runat="server" CssClass="form-control ">
                    </asp:DropDownList>

                    <asp:Label ID="Label5" runat="server" Text="Paciente:"></asp:Label>

                    <asp:DropDownList ID="PacienteDropDownList" runat="server" CssClass="form-control ">
                    </asp:DropDownList>

                    <asp:Label ID="Label6" runat="server" Text="Vacuna:"></asp:Label>

                    <asp:DropDownList ID="VacunaDropDownList" runat="server" CssClass="form-control ">
                    </asp:DropDownList>

                    <asp:Label ID="Label8" runat="server" Text="Dosis:"></asp:Label>

                    <asp:TextBox ID="DosisTextBox" runat="server" CssClass="form-control " placeholder="Dosis"></asp:TextBox>

                    <div class="form-group col-md-11">
                        <asp:Label ID="Label9" runat="server" Text="Fecha:"></asp:Label>
                        <asp:TextBox ID="FechaVacunaTextBox" runat="server" CssClass="form-control" Type="date" cssTextMode="Date"></asp:TextBox>
                    </div>

                    <br />
                    <asp:Button ID="AgregarButton" class="col-md-1" CssClass="btn btn-warning " runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                </div>

                <asp:GridView ID="HistorialGridView" runat="server" Width="100%">
                </asp:GridView>

                <div class="form-horizontal col-lg-12 " role="form">
                    <br />
                    <br />
                    <br />
                    <div class="form-group ">
                        <div class="container text-center ">
                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                            <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" OnClick="GuardarButton_Click" Text="Guardar" />
                            <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
