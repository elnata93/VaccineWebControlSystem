<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StarRegister.aspx.cs" Inherits="VaccineWebControlSystem.Reutilizable.StarRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel">
            <div class="form-horizontal col-md-12 " role="form">
                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                <div class="form-group">
                    <div class="col-md-11">
                        <asp:TextBox ID="IdTextBox" Cssclass="form-control " placeholder="ID" runat="server" />
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" />
                    </div>
                </div>
                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="DescripcionTextBox" Cssclass="form-control" placeholder="Descripcion" runat="server"></asp:TextBox>
            </div>
        </div>

    </div>
</asp:Content>
