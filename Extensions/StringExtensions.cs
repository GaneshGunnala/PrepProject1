namespace PrepProject.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace2(this string s) { 
            return String.IsNullOrWhiteSpace(s);
        }
    }
}