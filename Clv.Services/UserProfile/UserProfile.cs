using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.AuthDto;
using Clv.Models.Entities.UserEntity;
using Clv.Utilities.Hashing;
using Microsoft.Extensions.Options;

namespace Clv.Services.UserProfile
{
    public class UserProfile : IUserProfile
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
       
        //Constructor
        public UserProfile(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        
    }
}
