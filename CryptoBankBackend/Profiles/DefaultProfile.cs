using CryptoBankBackend.Core.Models.Entities;
using CryptoBankBackend.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoBankBackend.Web.Profiles
{
    public class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<UserEntity, UserApi>();
            CreateMap<UserApi, UserEntity>();

            CreateMap<OperationEntity, OperationApi>();
            CreateMap<OperationApi, OperationEntity>();
        }
    }
}
