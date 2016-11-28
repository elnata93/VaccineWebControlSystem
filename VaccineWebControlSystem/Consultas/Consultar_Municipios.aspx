<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Consultar_Municipios.aspx.cs" Inherits="VaccineWebControlSystem.Consultas.Consultar_Municipios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">Consulta de Municipios</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">

                    <div class="col-md-1">
                        <asp:Label ID="Label2" runat="server" Text="Buscar Por:"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="FiltroDropDownList" runat="server" CssClass="auto-style4" AutoPostBack="True">
                            <asp:ListItem Value="MunicipioId">Id</asp:ListItem>
                            <asp:ListItem>Descripcion</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="FiltroTextBox" runat="server" CssClass="form-control" pleaceholder="Filtrar"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                    <br />

                    <asp:GridView ID="ConsultaGridView" runat="server" Width="100%">
                    </asp:GridView>

                    <div class="container col-md-11">
                        <asp:Button ID="ReporteButton" CssClass="btn btn-danger" runat="server" Text="Reporte" OnClick="ReporteButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
