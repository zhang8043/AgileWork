using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace Agile.Abp.RealTime.SignalR
{
    [DependsOn(
        typeof(AbpRealTimeModule),
        typeof(AbpAspNetCoreSignalRModule))]
    public class AbpRealTimeSignalRModule : AbpModule
    {
    }
}
