namespace Users.API.Model
{
    public static class Settings
    {
        public static string Secret = Environment.GetEnvironmentVariable("SECRET");
    }
}