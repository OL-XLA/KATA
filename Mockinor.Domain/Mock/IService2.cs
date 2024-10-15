using Mocknitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocknitor.Domain.Mock
{
    public interface IService2 :IService
    {
        public IAsyncEnumerable<string> Action20();
        public IAsyncEnumerable<string> Action21();
        public IAsyncEnumerable<string> Action22();
    }
}
