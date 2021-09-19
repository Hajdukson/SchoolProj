using System;

namespace SchoolProj.Converters
{
    public static class StringToEnum
    {
        public static object Convert(Type enumType, string str) => Enum.Parse(enumType, str);
    }
}
