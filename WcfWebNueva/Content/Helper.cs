using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace WcfWebNueva.Content
{
    public static class Helper
    {

       
        public static string Encripta(string passwd)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var bytevalue = Encoding.UTF8.GetBytes(passwd);
            var bytehash = sha1.ComputeHash(bytevalue);
            sha1.Clear();
            return Convert.ToBase64String(bytehash);
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
                    var nomType = property.PropertyType.Name;
                    var valItem = row[property.Name].ToString();
                    if (nomType.Equals("String"))
                        property.SetValue(item, row[property.Name].ToString().Trim(), null);
                    else if (nomType.Equals("Int32"))
                        property.SetValue(item, valItem == "" ? 0 : int.Parse(row[property.Name].ToString().Trim()), null);
                    else if (nomType.Equals("Double"))
                        property.SetValue(item, valItem == "" ? 0.0 : double.Parse(row[property.Name].ToString().Trim()), null);
                    else if (nomType.Equals("DateTime"))
                        property.SetValue(item, valItem == "" ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(row[property.Name].ToString().Trim()), null);
                }
            }
            return item;
        }
        #endregion
    }


}