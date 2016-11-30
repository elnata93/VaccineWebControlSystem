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
                        <div class="col-md-10 ">
                        </div>
                        <div class="col-md-1 ">
                            <asp:Label ID="Label10" runat="server" Text="Fecha:"></asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="FechaLabel" runat="server"></asp:Label>
                        </div>
                    </div>
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
                            <asp:Label ID="Label2" runat="server" Text="Centro de Salud:"></asp:Label>
                            <asp:TextBox ID="CentroSaludTextBox" runat="server" CssClass="form-control " placeholder="Centro de Salud"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCentroSalud" runat="server" ErrorMessage="Campo requerido" ControlToValidate="CentroSaludTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCentro" runat="server" ErrorMessage="Solo puede ingrar letras" ControlToValidate="CentroSaludTextBox" ForeColor="Red" ValidationExpression="^[A-ZÑ]+[a-zñ\s]+[a-zñ]$" ValidationGroup="A"></asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Provincia:"></asp:Label>
                            <asp:DropDownList ID="ProvinciaDropDownList" runat="server" CssClass="form-control ">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidatorProvincias" runat="server" ErrorMessage="Seleccione la Provincia" ControlToValidate="ProvinciaDropDownList" ForeColor="Red" ValidationGroup="A"></asp:RangeValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Municipio:"></asp:Label>
                            <asp:DropDownList ID="MunicipioDropDownList" runat="server" CssClass="form-control ">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidatorMunicipios" runat="server" ErrorMessage="Seleccione el Municipio" ControlToValidate="MunicipioDropDownList" ForeColor="Red" ValidationGroup="A"></asp:RangeValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Paciente:"></asp:Label>
                            <asp:DropDownList ID="PacienteDropDownList" runat="server" CssClass="form-control ">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidatorPacientes" runat="server" ErrorMessage="Seleccione el Paciente" ControlToValidate="PacienteDropDownList" ForeColor="Red" ValidationGroup="A"></asp:RangeValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label6" runat="server" Text="Vacuna:"></asp:Label>
                            <asp:DropDownList ID="VacunaDropDownList" runat="server" CssClass="form-control ">
                            </asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidatorVacunas" runat="server" ErrorMessage="Selecione una vacuna" ControlToValidate="VacunaDropDownList" ForeColor="Red" ValidationGroup="C"></asp:RangeValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="Dosis:"></asp:Label>
                            <asp:TextBox ID="DosisTextBox" runat="server" CssClass="form-control " placeholder="Dosis"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDosis" runat="server" ErrorMessage="Campo requerido" ControlToValidate="DosisTextBox" ForeColor="Red" ValidationGroup="C"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:Label ID="Label9" runat="server" Text="Fecha:"></asp:Label>
                                <asp:TextBox ID="FechaVacunaTextBox" runat="server" CssClass="form-control" Type="date" TextMode="Date"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidatorFechaVacuna" runat="server" ErrorMessage="Seleccione la fecha" ControlToValidate="FechaVacunaTextBox" ForeColor="Red" ValidationGroup="C"></asp:RangeValidator>

                            </div>
                            <div class="col-md-8">
                            </div>
                            <div class="col-md-1">
                                <br />
                                <asp:Button ID="AgregarButton" CssClass="btn btn-warning " runat="server" Text="Agregar" OnClick="AgregarButton_Click" ValidationGroup="C" />
                            </div>
                        </div>
                    </div>
                </div>

                <asp:GridView ID="HistorialGridView" runat="server" Width="100%" Height="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="VacunaId" HeaderText="VacunaId" ReadOnly="True" SortExpression="VacunaId" />
                        <asp:BoundField DataField="Dosis" HeaderText="Dosis" ReadOnly="True" SortExpression="Dosis" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                    </Columns>
                </asp:GridView>

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
</asp:Content>
