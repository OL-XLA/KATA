using Mocknitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocknitor.Domain.Mock
{
    public interface IService3 : IService
    {
        public IAsyncEnumerable<string> Action30();
        public IAsyncEnumerable<string> Action31();
        public IAsyncEnumerable<string> Action32();
    }
}
