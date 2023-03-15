using FudSpin.Api.Filters;
using FudSpin.Api.Models;
using FudSpin.Dto.Spinners;
using FudSpin.Dto.Tokens;
using FudSpin.Entities.Entities;
using FudSpin.Services.SpinnerDetailServices;
using FudSpin.Services.SpinnerMasterServices;
using FudSpin.Services.TokenServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FudSpin.Api.Controllers
{
    [ApiController]
    [AuthorizeCheckAttribute]
    public class SpinnerController : ControllerBase
    {
        private readonly ISpinnerMasterService spinnerMasterService;
        private readonly ISpinnerDetailService spinnerDetailService;
        private readonly ITokenService tokenService;
        public SpinnerController(ISpinnerMasterService spinnerMasterService,
            ISpinnerDetailService spinnerDetailService,
             ITokenService tokenService)
        {
            this.spinnerMasterService = spinnerMasterService;
            this.spinnerDetailService = spinnerDetailService;
            this.tokenService = tokenService;
        }

        [HttpGet]
        [Route("[controller]/GetMyMasterSpinnerList")]
        public async Task<IActionResult> GetMyMasterSpinnerList()
        {

            TokenDTO user = tokenService.ValidationToken(HttpContext.Request.Headers.Authorization);
            List<SpinnerMasterDTO> spinnerList = await spinnerMasterService.GetMySpinnerListByUserID(user.ID, false);

            return Ok(new ResponseData()
            {
                Data = spinnerList
            });
        }

        [HttpGet]
        [Route("[controller]/GetDefaultSpinnerList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDefaultSpinnerList()
        {
            TokenDTO user = tokenService.ValidationToken(HttpContext.Request.Headers.Authorization);
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
            TokenDTO user = tokenService.ValidationToken(HttpContext.Request.Headers.Authorization);
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
            TokenDTO user = tokenService.ValidationToken(HttpContext.Request.Headers.Authorization);
            if (String.IsNullOrWhiteSpace(spinner.SpinnerMaster.Name))
            {
                return BadRequest($"{nameof(spinner.SpinnerMaster.Name)} cannot be null.");
            }
            Guid MasterID = await spinnerMasterService.ReturnIDAndAdd(new SpinnerMaster()
            {
                Name = spinner.SpinnerMaster.Name,
                Description = spinner.SpinnerMaster.Description,
                UserID = user.ID
            });

            if (MasterID == Guid.Empty)
            {
                return BadRequest();
            }
            List<string> ColorList = new() { "#7DB9B6", "#E96479", "#AD7BE9", "#3E54AC", "#183A1D", "#B3005E", "#18122B", "#F94A29", "#FCE22A", "#B99B6B", "#698269", "#F1DBBF", "#AA5656" };
            Random random = new();
            for (int i = 0; i < spinner.SpinnerDetails.Count; i++)
            {
                int randomIndex = random.Next(ColorList.Count - 1);
                await spinnerDetailService.MultipleAdd(new List<SpinnerDetail>()
                {
                    new SpinnerDetail()
                    {
                        Color = ColorList[randomIndex],
                        Name = spinner.SpinnerDetails[i].Name,
                        Description = spinner.SpinnerDetails[i].Description,
                        SpinnerMasterID = MasterID
                    }
                });
                ColorList.RemoveAt(randomIndex);
            }
            SpinnerMasterDTO spinnerList = await spinnerDetailService.GetSpinnerDetailByMasterID(MasterID);
            return Ok(spinnerList);
        }
    }
}
