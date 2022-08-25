namespace EmreUgur.BackedProject.Common.Models
{
    public class TokenInfo
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
        public int TokenExpiration { get; set; }
    }
}
