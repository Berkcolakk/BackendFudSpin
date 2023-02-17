using FudSpin.Api.Controllers.Base;
using FudSpin.Api.Filters;
using FudSpin.Api.Models;
using FudSpin.Dto.Spinners;
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
    public class SpinnerController : BaseController
    {
        private readonly ISpinnerMasterService spinnerMasterService;
        private readonly ISpinnerDetailService spinnerDetailService;
        private readonly string[] ColorList = new string[] { "#7DB9B6", "#E96479", "#AD7BE9", "#3E54AC", "#183A1D", "#B3005E", "#18122B", "#F94A29", "#FCE22A", "#B99B6B", "#698269", "#F1DBBF", "#AA5656" };
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
            User user = GetUserByJWTToken();
            List<SpinnerMasterDTO> spinnerList = await spinnerMasterService.GetMySpinnerListByUserID(user.ID, false);

            return Ok(new ResponseData()
            {
                Data = spinnerList
            });
        }

        [HttpGet]
        [Route("[controller]/GetDefaultSpinnerList")]
        public async Task<IActionResult> GetDefaultSpinnerList()
        {
            User user = GetUserByJWTToken();
            List<SpinnerMasterDTO> spinnerList = await spinnerMasterService.GetMySpinnerListByUserID(null, true);

            return Ok(new ResponseData()
            {
                Data = spinnerList
            });
        }

        [HttpGet]
        [Route("[controller]/GetSpinnerDetailByMasterID")]
        public async Task<IActionResult> GetSpinnerDetailByMasterID(Guid MasterID)
        {
            User user = GetUserByJWTToken();
            if (Guid.Empty == MasterID)
            {
                return BadRequest($"{nameof(MasterID)} cannot be null.");
            }
            SpinnerMasterDTO spinnerList = await spinnerDetailService.GetSpinnerDetailByMasterID(MasterID);

            return Ok(new ResponseData()
            {
                Data = spinnerList
            });
        }
        [HttpPost]
        [Route("[controller]/AddMySpinner")]
        public async Task<IActionResult> AddMySpinner(SpinnerAdd spinner)
        {
            User user = GetUserByJWTToken();
            if (String.IsNullOrWhiteSpace(spinner.SpinnerMaster.Name))
            {
                return BadRequest($"{nameof(spinner.SpinnerMaster.Name)} cannot be null.");
            }
            Guid MasterID = await spinnerMasterService.ReturnIDAndAdd(new SpinnerMaster()
            {
                Name = spinner.SpinnerMaster.Name,
                Description = spinner.SpinnerMaster.Description,
                UserID = Guid.Parse("c91dbe3f-ad3a-4b0a-b90a-6ff3e7506f6e")
            });

            if (MasterID == Guid.Empty)
            {
                return BadRequest();
            }
            for (int i = 0; i < spinner.SpinnerDetails.Count; i++)
            {
                await spinnerDetailService.MultipleAdd(new List<SpinnerDetail>()
                {
                    new SpinnerDetail()
                    {
                        Color = spinner.SpinnerDetails[i].Color,
                        Name = spinner.SpinnerDetails[i].Name,
                        Description = spinner.SpinnerDetails[i].Description,
                        SpinnerMasterID = MasterID
                    }
                });
            }
            SpinnerMasterDTO spinnerList = await spinnerDetailService.GetSpinnerDetailByMasterID(MasterID);
            return Ok(spinnerList);
        }
    }
}
