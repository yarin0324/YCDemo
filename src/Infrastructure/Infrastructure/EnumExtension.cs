namespace Infrastructure
{
    public static class EnumExtension
    {
        /// <summary>
        /// 取得枚舉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static T ConvertFromString<T>(this string strValue) where T : struct
        {
            T t = default;

            if (typeof(Enum) != typeof(T).BaseType)
                return t;

            return (T)Enum.Parse(typeof(T), strValue);
        }
    }
}
