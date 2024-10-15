using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;
using Mocknitor.Services.Service;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Channels;

namespace Mocknitor.Server.Hubs
{
    public class StreamHub : Hub
    {


        private readonly ILogService _logService;

        private static IDictionary<string, Dictionary<string, TimerManager>> clientConnections = new Dictionary<string, Dictionary<string, TimerManager>>();


        private Guid _guid;

        public StreamHub(ILogService logService)
        {
            _logService = logService;
        }

        public async void Register(string guid)
        {
            var connection = Context.ConnectionId;
            var clients = Clients;

            if (!clientConnections.ContainsKey(connection))
            {
                var dico = new Dictionary<string, TimerManager>();
                dico.Add(guid, new TimerManager(async () =>
                {
                    var client = clients.Client(connection);
                    var log = Encoding.Unicode.GetString(_logService.GetStream(Guid.Parse(guid)).ToArray());
                    await Send(log, guid, client);
                }, 250));
                clientConnections.Add(connection, dico);
            }
            else
            {
                if (!clientConnections[connection].ContainsKey(guid))
                {
                    clientConnections[connection].Add(guid, new TimerManager(async () =>
                    {
                        var client = clients.Client(connection);
                        var log = Encoding.Unicode.GetString(_logService.GetStream(Guid.Parse(guid)).ToArray());
                        await Send(log, guid, client);
                    }, 250));
                }
                else
                {
                    clientConnections[connection][guid].Stop();

                    clientConnections[connection][guid] = new TimerManager(async () =>
                    {
                        var client = clients.Client(connection);
                        var log = Encoding.Unicode.GetString(_logService.GetStream(Guid.Parse(guid)).ToArray());
                        await Send(log, guid, client);
                    }, 250);

                }
            }
        }

        public async Task Send(string log, string guid, IClientProxy client)
        {
            await client.SendAsync("UpdateLog", log, guid);
        }

        public void StopTimer()
        {
            clientConnections.TryGetValue(Context.ConnectionId, out var dico);
            if (dico != null)
            {
                foreach (var timerManager in dico)
                {
                    timerManager.Value.Stop();
                }
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            StopTimer();
            clientConnections.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }


}
