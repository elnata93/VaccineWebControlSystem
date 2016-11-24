<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Ciudades.aspx.cs" Inherits="VaccineWebControlSystem.Registros.Registro_Ciudades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container  ">
        <div class="panel panel-success">
            <div class="panel-heading">Registro de Ciudades</div>
                <div class="panel-body">
                    <br />
                    <br />
                    <br />
                    <div class="form-horizontal col-md-12 " role="form">
                        <asp:Label ID="Label1"  runat="server" Text="ID"></asp:Label>
                        <div class="form-group">  
                                <div class="col-md-11">
                                    <asp:TextBox ID="IdTextBox" cssclass="form-control " placeholder="ID"  runat="server" />
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="BuscarButton"  Cssclass="btn btn-info" runat="server" OnClick="BuscarButton_Click" Text="Buscar" />
                                </div>
                        </div>
                            <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>   
                            <asp:TextBox ID="DescripcionTextBox" Cssclass="form-control" placeholder="Descripcion" runat="server" /> 
                    </div> 
                    <%--<link href="/Reutilizable/StarRegister.aspx" rel="stylesheet" />
                    --%>
                    <div class="form-horizontal col-lg-12 " role="form">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxDescripcion" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <br />
                        <div class="form-group ">
                            <div class="container text-center " >
                                <asp:Button ID="NuevoButton" Cssclass="btn btn-primary" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                                <asp:Button ID="GuardarButton" Cssclass="btn btn-success" runat="server" OnClick="GuardarButton_Click" Text="Guardar" ValidationGroup="A" />
                                <asp:Button ID="EliminarButton" Cssclass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                            </div> 
                        </div>
                    </div>            
                </div>   
        </div>
    </div>
    
</asp:Content>
