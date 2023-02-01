using FudSpin.Api.Models;
using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using FudSpin.Services.Services.UserServices;
using FudSpin.Services.SpinnerMasterServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FudSpin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinnerMasterController : ControllerBase
    {
        private readonly ISpinnerMasterService spinnerMasterService;
        public SpinnerMasterController(ISpinnerMasterService spinnerMasterService)
        {
            this.spinnerMasterService = spinnerMasterService;
        }

        [HttpGet]
        [Route("[controller]/GetMySpinnerListByUserID")]
        public async Task<IActionResult> GetMySpinnerListByUserID(Guid UserID)
        {
            if (Guid.Empty == UserID)
            {
                return BadRequest($"{nameof(UserID)} cannot be null.");
            }
            List<SpinnerMaster> spinnerList = await spinnerMasterService.GetMySpinnerListByUserID(UserID);

            return Ok(new ResponseData()
            {
                Data = spinnerList
            });
        }
        [HttpPost]
        [Route("[controller]/Authentication")]
        public async Task<IActionResult> AddSpinnerMaster(SpinnerMaster spinnerMaster)
        {
            if (String.IsNullOrWhiteSpace(spinnerMaster.Name))
            {
                return BadRequest($"{nameof(spinnerMaster.Name)} cannot be null.");
            }
            bool hasAdded = await spinnerMasterService.Add(spinnerMaster);

            if (!hasAdded)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
