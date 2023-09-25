using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Dominio.Util
{
    public static class EnumHelper
    {
        public static T GetValue<T>(this System.Enum enval)
        {
            Type ttype = typeof(T);
            return (T)Convert.ChangeType(enval.GetValue(), ttype);
        }

        public static object GetValue(this System.Enum enval)
        {
            Type entype = enval.GetType();
            Type undertype = System.Enum.GetUnderlyingType(entype);
            return Convert.ChangeType(enval, undertype);
        }

        public static string GetDescricao(this Enum value)
        {
            DescriptionAttribute attribute = null;
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
                attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
