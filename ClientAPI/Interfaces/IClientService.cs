using ClientAPI.ViewModels.Client.Request;
using ClientAPI.ViewModels.Client.Response;
using System.Runtime.InteropServices;

namespace ClientAPI.Interfaces
{
    public interface IClientService
    {
        void CreateClient(ClientCreateView request);
        void UpdateClient(ClientUpdateView request);
        void DeleteClient(int clientId);
        ClientDetailView GetClient(int clientId);
        Task<ClientListView> GetClients();

    }
}
