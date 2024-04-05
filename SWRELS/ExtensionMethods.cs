using System;

namespace SWRELS
{
    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return String.IsNullOrEmpty(input) || String.IsNullOrEmpty(input.Trim());
        }

        public static string TrimNull(this string input)
        {
            return String.IsNullOrEmpty(input) ? String.Empty : input.Trim();
        }

        public static int ToInt(this string input)
        {
            return Convert.ToInt32(input);
        }
    }
}