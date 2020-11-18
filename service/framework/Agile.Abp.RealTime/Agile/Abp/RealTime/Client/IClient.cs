using System.Threading.Tasks;

namespace Agile.Abp.RealTime.Client
{
    public interface IClient
    {
        Task OnConnectedAsync(IOnlineClient client);
        Task OnDisconnectedAsync(IOnlineClient client);
    }
}
