using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CUSTOM_ATTRIBUTE
    {
        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
        public class EnumLabelAttribute : Attribute
        {
            private readonly string VALUE;

            public EnumLabelAttribute(string value)
            {
                VALUE = value;
            }

            private static T GetEnumAttribute<T>(Enum field) where T : Attribute
            {
                System.Reflection.FieldInfo fInfo = GetFieldInfo(field);

                return (T)Attribute.GetCustomAttribute(fInfo, typeof(T));
            }

            private static System.Reflection.FieldInfo GetFieldInfo(Enum field)
            {
                Type enumType = field.GetType();
                string name = Enum.GetName(enumType, field);
                return enumType.GetField(name);
            }

            public static string GetValue(Enum field)
            {
                return GetEnumAttribute<EnumLabelAttribute>(field).VALUE;
            }
        }
    }
}
