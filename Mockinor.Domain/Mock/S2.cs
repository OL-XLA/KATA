using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocknitor.Domain.Models;
using Mocknitor.Domain.Mock;

namespace Mocknitor.Domain.Mock
{
    public class S2 : ServiceBase , IService2
    {
        public S2()
        {
            Name = "Service2";
            Description = "Do the thing the Service 2 do";
        }

        public async IAsyncEnumerable<string> Action20()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 20 log :{i}- {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }

        public async IAsyncEnumerable<string> Action21()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 21 log :{i}- {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }

        public async IAsyncEnumerable<string> Action22()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 22 log :{i}- {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }
    }
}
