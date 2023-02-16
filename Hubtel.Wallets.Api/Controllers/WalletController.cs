using AutoMapper;
using Hubtel.Wallets.Api.Data;
using Hubtel.Wallets.Api.Dtos;
using Hubtel.Wallets.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hubtel.Wallets.Api.Controllers
{
    [Route("api/wallets")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepo _repository;
        private readonly IMapper _mapper;

        public WalletController(IWalletRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletReadDto>>> GetWallets()
        {
            try
            {
                var wallets = await _repository.GetWallets();

                if (wallets == null)
                {
                    return NotFound();
                }

                var walletsReadDto = _mapper.Map<IEnumerable<WalletReadDto>>(wallets);

                return Ok(walletsReadDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        //GET api/wallets/{Id}
        [HttpGet("{Id}", Name = "GetWalletByID")]
        public async Task<ActionResult<WalletReadDto>> GetWalletByID(int Id)
        {
            try
            {
                var wallet = await _repository.GetWalletByID(Id);

                if (wallet == null)
                {
                    return NotFound();
                }

                var walletsReadDto = _mapper.Map<WalletReadDto>(wallet);

                return Ok(walletsReadDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }


        }

        //DELETE api/wallets
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteWallet(int Id)
        {
            try
            {
                var wallet = await _repository.GetWalletByID(Id);

                if (wallet == null)
                {
                    return NotFound();
                }

                await _repository.DeleteWallet(wallet);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        //CREATE api/wallets
        [HttpPost]
        public async Task<ActionResult<WalletCreateDto>> CreateWallet([FromBody] WalletCreateDto walletCreateDto)
        {
            try
            {
                var walletModel = _mapper.Map<WalletModel>(walletCreateDto);
                await _repository.CreateWallet(walletModel);

                var walletReadDto = _mapper.Map<WalletReadDto>(walletModel);
                return CreatedAtRoute(nameof(GetWalletByID), new { Id = walletReadDto.ID }, walletReadDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
           

           
        }
        
    }
}
