using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Concilia_POS.Content
{
    public static class Helper
    {
       public static string CodigoEstacion(string codigo)
       {
           var cod = string.Empty;
           switch (codigo)
           {
               case "27935214": //Caja Pos Huechuraba
                   cod = "40";
                   break;
               case "27935206": //Caja Arriendo Huechuraba
                   cod = "40";
                   break;
               case "29261164": //Caja Teatinos
                   cod = "90";
                   break;
               case "29261172": //Caja Padre Hurtado
                   cod = "95";
                   break;
               case "29438250": //Ventas Web
                   cod = "40";
                   break;
               case "31175399": //Ventas Especiales (Cuando llega la venta de bodega se solicita un par de máquinas mas). 
                   cod = "40";
                   break;
           }
           return cod;
       }


       #region Extras
       public static List<T> ToList<T>(this DataTable table) where T : new()
       {
           IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

           return (from object row in table.Rows select CreateItemFromRow<T>((DataRow)row, properties)).ToList();
       }

       private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
       {
           var item = new T();
           foreach (var property in properties)
           {
               if (property.PropertyType == typeof(DayOfWeek))
               {
                   var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                   property.SetValue(item, day, null);
               }
               else
               {
                   var a = row[property.Name].ToString().Trim();
                   if (a != "")
                   {
                       property.SetValue(item, row[property.Name].ToString().Trim(), null);
                   }
                   else
                   {
                       if (property.PropertyType.Name.Equals("String"))
                       {
                           property.SetValue(item, string.Empty, null);
                       }
                       else
                       {
                           property.SetValue(item, 0.0, null);
                       }

                   }

               }
           }
           return item;
       }
       #endregion
    }
}
