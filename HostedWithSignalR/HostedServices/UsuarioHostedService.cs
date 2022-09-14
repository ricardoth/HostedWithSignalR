using HostedWithSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace HostedWithSignalR.HostedServices
{
    public class UsuarioHostedService : IHostedService, IDisposable
    {
        private readonly IHubContext<UsuarioHub> _usuarioHUb;
        private Timer _timer;

        public UsuarioHostedService(IHubContext<UsuarioHub> usuarioHUb)
        {
            _usuarioHUb = usuarioHUb;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(HacerAlgo, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        public void HacerAlgo(object state)
        {
            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new Usuario(1, "Ricardo", "Tilleria"));
            usuarios.Add(new Usuario(2, "Jimmy", "Neutron"));

            _usuarioHUb.Clients.All.SendAsync("Receive", usuarios);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
