namespace Core.Utilities.Security.JWT
{
    public class CariToken
    {
        public string CariAccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
