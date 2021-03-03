using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Results;

namespace GamesLoan.Core.Services
{
    public class GameService : IGameService
    {
        private readonly ILoginRepository _loginRepository;
        
        public GameService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;            
        }

        private async Task<Login> GetLoginIfExists(int loginId)
        {
            var login = await _loginRepository.GetById(loginId);
            if (login == null)
                throw new Exception("Your login is invalid");

            return login;
        }        

        private Game GetGame(Login login, int gameId)
        {
            var game = login.Games
                .FirstOrDefault(g => g.Id == gameId);
            
            if (game == null)
                throw new Exception("This game does not exists");

            return game;
        }        

        private Friend GetFriend(Login login, int friendId)
        {
            var friend = login.Friends
                .FirstOrDefault(f => f.Id == friendId);
            
            if (friend == null)
                throw new Exception("This friend does not exists");

            return friend;
        }

        public async Task<GameResult> GetById(int gameId, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);
                var game = GetGame(login, gameId);

                return new GameResult(true, "", new GameDto(game.Id, game.Name));
            }
            catch (Exception exception)
            {
                return new GameResult(false, exception.Message);
            }
        }

        public async Task<GameListResult> GetAll(int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId); 

                var gamesDto = login.Games
                    .Select(g => new GameDto(g.Id, g.Name))
                    .ToList();                

                return new GameListResult(true, "", gamesDto);
            }
            catch (Exception exception)
            {
                return new GameListResult(false, exception.Message);
            }
        }

        public async Task<Result> Add(GameDto gameDto, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);
                login.AddGame(gameDto.Name);
                await _loginRepository.Update(login);                
                return new Result(true, "Game added");
            }
            catch (Exception exception)
            {
                return new TokenResult(false, exception.Message);
            }
        }        

        public async Task<Result> Update(GameDto gameDto, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                

                var game = GetGame(login, gameDto.Id);
                game.Name = gameDto.Name;

                await _loginRepository.Update(login);                

                return new Result(true, "Game updated");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }
        }

        public async Task<Result> Delete(int gameId, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);
                var game = GetGame(login, gameId);
                login.RemoveGame(game);                

                await _loginRepository.Update(login);

                return new Result(true, "Game deleted");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }            
        }

        public async Task<Result> Lend(GameLoanDto gameLoanDto, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                

                var game = GetGame(login, gameLoanDto.GameId);
                var friend = GetFriend(login, gameLoanDto.FriendId);

                if (game.FriendId != null)
                    return new Result(false, "This game is already lent");

                login.LendGame(game.Id, friend.Id);

                await _loginRepository.Update(login);

                return new Result(true, "Game lent");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }
        }

        public async Task<Result> Return(GameReturnDto gameReturnDto, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);
                var game = GetGame(login, gameReturnDto.GameId);

                if (game.FriendId == null)
                    return new Result(false, "Game is not lent");

                login.ReturnGame(game.Id);

                await _loginRepository.Update(login);

                return new Result(true, "Game returned");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }
        }
    }
}