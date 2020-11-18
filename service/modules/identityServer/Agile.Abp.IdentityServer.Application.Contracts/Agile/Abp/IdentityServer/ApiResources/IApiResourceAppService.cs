using System;
using Volo.Abp.Application.Services;

namespace Agile.Abp.IdentityServer.ApiResources
{
    public interface IApiResourceAppService : 
        ICrudAppService<
            ApiResourceDto,
            Guid,
            ApiResourceGetByPagedInputDto,
            ApiResourceCreateDto,
            ApiResourceUpdateDto>
    {
    }
}
