using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clv.Models.ApiModelsDto.AuthDto;
using Clv.Services.UserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase  //ApiController// 
    {
        
        private readonly IUserProfile _userProfile;

        public ProfileController(IUserProfile userProfile)
        {
            _userProfile = userProfile;
        }

        
    }
}