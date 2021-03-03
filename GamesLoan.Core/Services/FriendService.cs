using System;
using System.Linq;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Results;

namespace GamesLoan.Core.Services
{
    public class FriendService : IFriendService
    {
        private readonly ILoginRepository _loginRepository;                

        public FriendService(ILoginRepository loginRepository)
        
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

        private Friend GetFriend(Login login, int friendId)
        {
            var friend = login.Friends
                .FirstOrDefault(f => f.Id == friendId);
            
            if (friend == null)
                throw new Exception("This friend does not exists");

            return friend;
        }

        public async Task<Result> Add(FriendDto friendDto, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                

                login.AddFriend(friendDto.Name, friendDto.PhoneNumber);

                await _loginRepository.Update(login);

                return new Result(true, "Friend added");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }
        }

        public async Task<Result> Delete(int friendId, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                
                var friend = GetFriend(login, friendId);

                login.RemoveFriend(friend);                
                await _loginRepository.Update(login);

                return new Result(true, "Friend deleted");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            } 
        }

        public async Task<FriendListResult> GetAll(int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                

                var friendsDto = login.Friends
                    .Select(f => new FriendDto(f.Id, f.Name, f.PhoneNumber))
                    .ToList();

                return new FriendListResult(true, "", friendsDto);
            }
            catch (Exception exception)
            {
                return new FriendListResult(false, exception.Message);
            }
        }

        public async Task<FriendResult> GetById(int friendId, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                
                var friend = GetFriend(login, friendId);

                return new FriendResult(true, "", new FriendDto(friend.Id, friend.Name, friend.PhoneNumber));
            }
            catch (Exception exception)
            {
                return new FriendResult(false, exception.Message);
            }
        }

        public async Task<Result> Update(FriendDto friendDto, int loginId)
        {
            try
            {
                var login = await GetLoginIfExists(loginId);                
                var friend = GetFriend(login, friendDto.Id);
                friend.Name = friendDto.Name;
                friend.PhoneNumber = friendDto.PhoneNumber;
                
                await _loginRepository.Update(login);

                return new Result(true, "Friend updated");
            }
            catch (Exception exception)
            {
                return new Result(false, exception.Message);
            }
        }
    }
}