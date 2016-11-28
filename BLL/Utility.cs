using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace BLL
{
    public static class Utility
    {

        public static int ConvertirToInt(string numero)
        {
            int num;
            int.TryParse(numero, out num);
            return num;
        }

        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static void ConfigurarReporte(ReportViewer rv, string ruta, string DataSets, DataTable listado)
        {
            rv.LocalReport.DataSources.Clear();
            rv.ProcessingMode = ProcessingMode.Local;


            rv.LocalReport.ReportPath = ruta;
            ReportDataSource sourse = new ReportDataSource(DataSets, listado);

            rv.LocalReport.DataSources.Add(sourse);
            rv.LocalReport.Refresh();
        }

        //public static void ConvertToDate(string fecha)
        //{
        //    fecha = DateTime.Now.ToString("dd/MM/yyy");                                                                                                                              ch;
        //}
    }
}
