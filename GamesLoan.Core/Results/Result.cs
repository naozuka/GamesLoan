using GamesLoan.Core.Interfaces;

namespace GamesLoan.Core.Results
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}