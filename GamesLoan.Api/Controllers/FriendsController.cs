using System.Collections.Generic;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesLoan.Api.Controllers
{
    public class FriendsController : BaseApiController
    {
        private readonly IFriendService _friendService;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet] 
        [Authorize]            
        public async Task<ActionResult<FriendListResult>> GetAll()
        {
            var loginId = await GetLoginId();
            var result = await _friendService.GetAll(loginId);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [Authorize]     
        public async Task<ActionResult<FriendResult>> GetById(int id)
        {
            var loginId = await GetLoginId();
            var result = await _friendService.GetById(id, loginId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]     
        public async Task<ActionResult<Result>> Add(FriendDto friendDto)
        {
            var loginId = await GetLoginId();
            var result = await _friendService.Add(friendDto, loginId);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [Authorize]     
        public async Task<ActionResult<Result>> Put(int id, FriendDto friendDto)
        {
            if (id != friendDto.Id)
                return BadRequest();            
            
            var loginId = await GetLoginId();
            var result = await _friendService.Update(friendDto, loginId);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Result>> Delete(int id)
        {
            var loginId = await GetLoginId();
            var result = await _friendService.Delete(id, loginId);
            return Ok(result);
        }
    }    
}