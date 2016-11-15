<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Provincias.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Provincia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Provincias</div>
            <div class="panel-body  ">
                <div class="form-horizontal col-md-12" role="form">
                    <br />
                    <br />
                    <br />
                    <div class="form-horizontal col-md-12 " role="form">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                        <div class="form-group">
                            <div class="col-md-11">
                                <asp:TextBox ID="IdTextBox" Cssclass="form-control " placeholder="ID" runat="server" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
                            </div>
                        </div>
                        <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox ID="DescripcionTextBox" Cssclass="form-control" placeholder="Descripcion" runat="server" />
                    </div>
                    <%--<link href="/Reutilizable/StarRegister.aspx" rel="stylesheet" />
                    --%>
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
