using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Mocknitor.Services.Service
{
    public class LogService : ILogService
    {
        private ConcurrentDictionary<Guid, MemoryStream> _logStream = new ConcurrentDictionary<Guid, MemoryStream>();


        public async void InitializeStream(Guid logId, IAsyncEnumerable<string> writings)
        {
            if (!_logStream.TryGetValue(logId, out var stream))
            {
                _logStream.TryAdd(logId, new MemoryStream());
                stream = _logStream[logId];
            }

            var writter = new StreamWriter(stream, Encoding.Unicode);
            await foreach (var log in writings)
            {
                stream.Seek(0, SeekOrigin.End);
                await writter.WriteLineAsync(log);
                writter.Flush();
            }
        }

        public MemoryStream GetStream(Guid logId)
        {
           if(_logStream.TryGetValue(logId,out var a)){
                a.Seek(0, SeekOrigin.Begin);
                return _logStream[logId];

            }
            return null;
        }

    }
}
