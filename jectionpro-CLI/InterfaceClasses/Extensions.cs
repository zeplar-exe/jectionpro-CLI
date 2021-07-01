using System;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class Extensions
    {
        public static int? ToInt32Safe(this string number)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}