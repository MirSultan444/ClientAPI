using ClientAPI.Database;
using ClientAPI.Interfaces;
using ClientAPI.Models;
using ClientAPI.ViewModels.Client.Request;
using ClientAPI.ViewModels.Client.Response;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepo<Client> _client;

        public ClientService(IRepo<Client> client)
        {
            _client = client;
        }

        public void CreateClient(ClientCreateView request)
        {
            var newClient = new Client()
            {
                Name = request.Name,
                Age = request.Age,
                Diagnosis = request.Diagnosis,
            };

            _client.Create(newClient);
            _client.SaveChanges();
        }

        public void UpdateClient(ClientUpdateView request)
        {
            _client.FirstOrDefault(c => !c.IsDeleted && c.Name.ToLower().Trim() == request.Name.ToLower().Trim());

            var client = _client.FirstOrDefault(c => !c.IsDeleted && c.Id == request.Id);

            if (client == null)
                return;

            client.Name = request.Name;
            client.Age = request.Age;
            client.Diagnosis = request.Diagnosis;

            _client.SaveChanges();
        }

        public void DeleteClient(int clientId)
        {
            var client = _client.FirstOrDefault(c => !c.IsDeleted && c.Id == clientId);
            if (client == null) return; 
            client.IsDeleted = true;
            _client.SaveChanges();
        }

        public ClientDetailView GetClient(int clientId)
        {
            var client = _client.FirstOrDefault(c => !c.IsDeleted && c.Id == clientId);

            if (client == null)
                return null;

            var result = new ClientDetailView()
            {
                Id = client.Id,
                Name = client.Name,
                Age = client.Age,
                Diagnosis = client.Diagnosis,

            };

            return result;
        }

        public async Task<ClientListView> GetClients()
        {
            var clietns = await _client.GetAll(c => !c.IsDeleted)
                .Select(c => new ClientDetailView
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    Diagnosis = c.Diagnosis,
                })
                .AsNoTracking()
                .ToListAsync();

            var result = new ClientListView()
            {
                DataList = clietns,
            };

            return result;
        }
    }
}
