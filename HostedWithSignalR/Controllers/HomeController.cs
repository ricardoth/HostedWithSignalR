using HostedWithSignalR.HostedServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HostedWithSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<UsuarioHub> _usuarioHub;

        public HomeController(IHubContext<UsuarioHub> usuarioHub)
        {
            _usuarioHub = usuarioHub;
        }

        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<IActionResult> Get()
        {
            var mensaje = "niun brillo";
            await _usuarioHub.Clients.All.SendAsync("Receive", mensaje);
            return Ok("Hecho");
        }
    }
}
