namespace GamesLoan.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(int loginId, string email);        
    }
}