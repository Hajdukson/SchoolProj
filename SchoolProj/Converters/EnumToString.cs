using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProj.Converters
{
    public static class EnumToString
    {
        public static List<string> Convert(Type type) => type.GetEnumNames().ToList();

    }
}
