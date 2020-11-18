using System.Threading;
using System.Threading.Tasks;

namespace Agile.Abp.Features.LimitValidation
{
    public interface IRequiresLimitFeatureChecker
    {
        Task<bool> CheckAsync(RequiresLimitFeatureContext context, CancellationToken cancellation = default);

        Task ProcessAsync(RequiresLimitFeatureContext context, CancellationToken cancellation = default);
    }
}
