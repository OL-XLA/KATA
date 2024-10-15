using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocknitor.Domain.Models;
using Mocknitor.Domain.Mock;

namespace Mocknitor.Domain.Mock
{
    public class S1 : ServiceBase , IService1
    {
        public S1() 
        {
            Name = "Service1";
            Description = "Do the thing the Service 1 do";
        }

        public async IAsyncEnumerable<string> Action10()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 10 log :{i}-  {(Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }

        public async IAsyncEnumerable<string> Action11()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 11 log :{i}-  { (Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }

        public async IAsyncEnumerable<string> Action12()
        {
            for (int i = 0; i < 180; i++)
            {
                yield return $"Action 12 log :{i}-  { (Random.Shared.Next(0, 100) * 1000).ToString()} \r";
                Thread.Sleep(1000);
            }
        }
    }
}
