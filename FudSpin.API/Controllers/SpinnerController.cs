using FudSpin.Api.Filters;
using FudSpin.Api.Models;
using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using FudSpin.Services.Services.UserServices;
using FudSpin.Services.SpinnerDetailServices;
using FudSpin.Services.SpinnerMasterServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FudSpin.Api.Controllers
{
    [ApiController]
    [AuthorizeCheckAttribute]
    public class SpinnerController : ControllerBase
    {
        private readonly ISpinnerMasterService spinnerMasterService;
        private readonly ISpinnerDetailService spinnerDetailService;
        public SpinnerController(ISpinnerMasterService spinnerMasterService,
            ISpinnerDetailService spinnerDetailService)
        {
            this.spinnerMasterService = spinnerMasterService;
            this.spinnerDetailService = spinnerDetailService;
        }

        [HttpGet]
        [Route("[controller]/GetMyMasterSpinnerList")]
        public async Task<IActionResult> GetMyMasterSpinnerList()
        {
            //if (Guid.Empty == UserID)
            //{
            //    return BadRequest($"{nameof(UserID)} cannot be null.");
            //}
            List<SpinnerMaster> spinnerList = await spinnerMasterService.GetMySpinnerListByUserID(Guid.Empty);

            return Ok(new ResponseData()
            {
                Data = spinnerList
            });
        }

        [HttpGet]
        [Route("[controller]/GetSpinnerDetailByMasterID")]
        public async Task<IActionResult> GetSpinnerDetailByMasterID(Guid MasterID)
        {
            if (Guid.Empty == MasterID)
            {
                return BadRequest($"{nameof(MasterID)} cannot be null.");
            }
            List<SpinnerDetail> spinnerList = await spinnerDetailService.GetSpinnerDetailByMasterID(MasterID);

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
