﻿using ECourse.Services.Basket.Dtos;
using ECourse.Services.Basket.Services;
using ECourse.Shared.ControllerBases;
using ECourse.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECourse.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController:CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService) 
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            var response = await _basketService.SaveOrUpdate(basketDto);
            return CreateActionResultInstance(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
