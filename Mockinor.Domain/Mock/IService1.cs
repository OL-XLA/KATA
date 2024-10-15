using Mocknitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocknitor.Domain.Mock
{
    public interface IService1 : IService
    {
        public IAsyncEnumerable<string> Action10();
        public IAsyncEnumerable<string> Action11();
        public IAsyncEnumerable<string> Action12();
    }
}
