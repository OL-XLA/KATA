using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Mocknitor.Services.Service
{
    public interface ILogService
    {
        public void InitializeStream(Guid logId, IAsyncEnumerable<string> writings);
        public MemoryStream GetStream(Guid logId);

    }
}
