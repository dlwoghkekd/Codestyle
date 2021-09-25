public static class ExtensionUtil
{
    public static string Format(this string formatStr, params object[] param)
    {
        return string.Format(formatStr, param);
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
}