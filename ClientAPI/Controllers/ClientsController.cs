using ClientAPI.Interfaces;
using ClientAPI.ViewModels.Client.Request;
using ClientAPI.ViewModels.Client.Response;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ClientAPI.Controllers
{
    [Route("api/v1/client")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public void CreateCLient([FromBody] ClientCreateView request)
        {
            _clientService.CreateClient(request);
        }

        [HttpPatch]
        public void UpdateClient([FromBody] ClientUpdateView request)
        {
            _clientService.UpdateClient(request);
        }

        [HttpDelete]
        public void DeleteClietn(int clientId)
        {
            _clientService.DeleteClient(clientId);
        }

        [HttpGet]
        public ClientDetailView GetClint(int clientId)
        {
            var result = _clientService.GetClient(clientId);
            return result;
        }

        [HttpGet("list")]
        public async Task<ClientListView> GetClients()
        {
            var result = await _clientService.GetClients();

            return result;
        }
    }
}
