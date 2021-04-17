namespace OwnRoshamboWeb
{
    public class AppSettings
    {
        public string DbConnectionString { get; set; }
        public string PasswordSalt { get; set; }
        public string JwtTokenSecret { get; set; }
    }
}
