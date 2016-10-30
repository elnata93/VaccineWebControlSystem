<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro_Hitoriales.aspx.cs" Inherits="VaccineWebControlSystem.Registros.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 36px;
        }
        .auto-style2 {
            width: 124px
        }
        .auto-style3 {
            width: 124px;
            height: 20px;
        }
        .auto-style4 {
            height: 20px;
        }
        .auto-style5 {
            width: 36px;
            height: 20px;
        }
        .auto-style6 {
            width: 428px
        }
        .auto-style7 {
            width: 234px
        }
        .auto-style10 {
            width: 126px
        }
        .auto-style11 {
            width: 766px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="panel panel-success">
                <div class="panel-heading">Registro de Historial</div>
                <div class="panel-body">
                    <div class="form-horizontal col-md-12" role="form">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style10">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Fecha:"></asp:Label>
                                    <asp:Label ID="FechaLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
					    <table class="nav-justified">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="IdTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td class="auto-style1">
                                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label2" runat="server" Text="Centro de Salud:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CentroSaludTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label3" runat="server" Text="Provincia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ProvinciaDropDownList" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label4" runat="server" Text="Municipio:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="MunicipioDropDownList" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label5" runat="server" Text="Paciente:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="PacienteDropDownList" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label6" runat="server" Text="Vacuna:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="VacunaDropDownList" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label7" runat="server" Text="EsUnica:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="SiRadioButton" runat="server" Text="Si" />
                                    <asp:RadioButton ID="NoRadioButton" runat="server" Text="No" />
                                </td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="Label8" runat="server" Text="Dosis:"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="DosisTextBox" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td class="auto-style5"></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Calendar ID="FechaCalendar" runat="server"></asp:Calendar>
                                </td>
                                <td class="auto-style1">
                                    <asp:Button ID="AgregarButton" runat="server" Text="Agregar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                            </tr>

                        </table>
                        <asp:GridView ID="HistorialGridView" runat="server" Width="100%"></asp:GridView>
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style6">&nbsp;</td>
                                <td class="auto-style7">
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
