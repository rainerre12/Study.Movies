namespace Movies.Models.CustomModel
{
    public class Session
    {
        public class SesssionKeys
        {
            public const string userid = "userid";
        }

        public static void SetSession(HttpContext httpContext, string key, object value)
        {
            httpContext.Session.SetString(key, value.ToString());
        }

        public static string GetSession(HttpContext httpContext, string key)
        {
            return httpContext.Session.GetString(key);
        }

        public static void RemoveSession(HttpContext httpContext, string key)
        {
            httpContext.Session.Remove(key);
        }
    }
}
