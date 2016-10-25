<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="HistorialesReportViewer.aspx.cs" Inherits="VaccineWebControlSystem.Reportes.HistorialesReportViewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="panel panel-success">
                    <div class="panel-heading">Reporte de Historiales</div>
                        <div class="panel-body">
                            <div class="form-horizontal col-md-12" role="form">
						    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <rsweb:ReportViewer ID="HistorialReportViewer" runat="server" Width="100%"></rsweb:ReportViewer>
					    </div>
			    </div>		
	    </div>				
    </div>
</asp:Content>
