namespace GamesLoan.Core.Results
{
    public class TokenResult : Result
    {
        public string Token { get; set; }
        public TokenResult(bool success, string message, string token = null) : base(success, message)
        {
            Token = token;
        }
    }
}