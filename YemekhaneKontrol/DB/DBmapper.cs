using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Dynamic;

namespace YemekhaneKontrol.DB
{
    public class DBmapper
    {
        public Object GetDBMap(Object obj, DataTable dt)
        {
            //dynamic obje = new ExpandoObject();
            //obje = DynamicExtensions.ToDynamic(obj);

            DataTable dtMap = new DataTable();
            dtMap.Columns.Add("FIELD", typeof(PropertyInfo));
            dtMap.Columns.Add("FIELD_NAME", typeof(String));
            dtMap.Columns.Add("FIELD_TYPE", typeof(Type));
            dtMap.Columns.Add("DB_FIELD_NAME", typeof(String));

            Type type = obj.GetType();
            Int32 propCount = type.GetProperties().Count();
            PropertyInfo[] props = obj.GetType().GetProperties();
            
            String[] mapNames = new String[props.Length];
            Type[] mapTypes = new Type[props.Length];
            
            

            //dynamic obje = new ExpandoObject();
            //obje = obj;

            for(int i = 0; i < props.Length; i++)
            {
                mapNames[i] = GetAttrOfProp(props[i]);
                mapTypes[i] = props[i].PropertyType;
                
                dtMap.Rows.Add(props[i], props[i].Name, props[i].PropertyType, GetAttrOfProp(props[i]));

                //((IDictionary<string, object>)obje)[props[i].Name] = null;
            }

            Int32 dtColCount = 0;
            dtColCount = dt.Columns.Count;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dtColCount; i++)
                {
                    String dtColName = dt.Columns[i].ColumnName;
                    DataRow[] drow = dtMap.Select("DB_FIELD_NAME = '" + dtColName + "'");

                    if (drow.Length > 0)
                    {
                        String propName = Convert.ToString(drow[0]["FIELD_NAME"]);
                        PropertyInfo pi = type.GetProperty(propName);
                        pi.SetValue(obj, (Object)dt.Rows[0][dtColName]);
                        //((IDictionary<string, object>)obje)[pi.Name] = (Object)dt.Rows[0][dtColName];
                    }
                }
            }
            
            return obj;
        }

        private static String GetAttrOfProp(PropertyInfo pi)
        {
            string output = null;
            //Type type = value.GetType();
            

            //FieldInfo fi = type.GetField(value.ToString());
            //PropertyInfo pi = type.GetProperty(value.Name);
            //StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            StringValueAttribute[] attrs = pi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                //_stringValues.Add(value, attrs[0]);
                output = attrs[0].Value;
            }

            return output;
        }
    }
}
