using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace BLL
{
    public static class Utility
    {

        public static int ConvertirToEntero(string numero)
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

        //public static void Mensajes(string mensaje)
        //{
        //    Console.Write("<script>alert('" + mensaje + "');</script>");
        //}

        //public static void FechaConvert(string fecha)
        //{
        //    fecha = DateTime.Now.ToString("dd/MM/yyy");                                                                                                                              ch;
        //}
    }
}
