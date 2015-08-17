﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WcfCambioUbicacion.Content
{
    public static class Helper
    {
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