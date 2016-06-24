namespace HelpersForNet {
    public static class StringExtensions {
        /// <summary>
        /// Returns the string with the first letter in uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UpperCaseFirstLetter(this string s) {
            if (string.IsNullOrEmpty(s)) {
                return string.Empty;
            }
            s = s.ToLower();
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
