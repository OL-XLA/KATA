using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocknitor.Domain.Models;
using Mocknitor.Domain.Mock;

namespace Mocknitor.Domain.Mock
{
    public class S3 : ServiceBase , IService3
    {
        public S3()
        {
            Name = "Service3";
            Description = "Do the thing the Service 3 do";
        }

        public async IAsyncEnumerable<string> Action30()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 30 log :{i}- {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }

        public async IAsyncEnumerable<string> Action31()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 31 log :{i}- {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }

        public async IAsyncEnumerable<string> Action32()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 32 log :{i}- {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }
    }
}
