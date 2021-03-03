using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamesLoan.Core.DTO;
using GamesLoan.Core.Entities;
using GamesLoan.Core.Interfaces;
using GamesLoan.Core.Results;
using GamesLoan.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesLoan.Api.Controllers
{    
    public class GamesController : BaseApiController
    {        
        private readonly IGameService _gameService;        
        
        public GamesController(IGameService gameService)
        {     
            _gameService = gameService;                   
        }        

        [HttpGet]   
        [Authorize]     
        public async Task<ActionResult<GameListResult>> GetAll()
        {
            var loginId = await GetLoginId();
            var result = await _gameService.GetAll(loginId);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [Authorize]     
        public async Task<ActionResult<GameResult>> GetById(int id)
        {
            var loginId = await GetLoginId();            
            var result = await _gameService.GetById(id, loginId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]     
        public async Task<ActionResult<Result>> Add(GameDto gameDto)
        {
            var loginId = await GetLoginId();
            var result = await _gameService.Add(gameDto, loginId);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [Authorize]     
        public async Task<ActionResult<Result>> Put(int id, GameDto gameDto)
        {
            if (id != gameDto.Id)
                return BadRequest();            
            
            var loginId = await GetLoginId();
            var result = await _gameService.Update(gameDto, loginId);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize]     
        public async Task<ActionResult<Result>> Delete(int id)
        {
            var loginId = await GetLoginId();
            var result = await _gameService.Delete(id, loginId);            
            return Ok(result);
        }

        [HttpPost("lend")]
        [Authorize]     
        public async Task<ActionResult<Result>> Lend(GameLoanDto gameLoanDto)
        {
            var loginId = await GetLoginId();
            var result = await _gameService.Lend(gameLoanDto, loginId);
            return Ok(result);
        }

        [HttpPost("return")]
        [Authorize]     
        public async Task<ActionResult<Result>> Return(GameReturnDto gameReturnDto)
        {
            var loginId = await GetLoginId();
            var result = await _gameService.Return(gameReturnDto, loginId);
            return Ok(result);
        }
    }
}