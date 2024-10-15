using Mocknitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mocknitor.Domain.Mock
{
    public abstract class ServiceBase : IService
    {
        public string Name { get ; set; }
        public string Description { get ; set ; }

        public IEnumerable<string> Get()
        {
            MethodInfo[] info = this.GetType().GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly|BindingFlags.GetProperty);

            return info.Select(x => x.Name);
        }

        public Task<Guid> Post()
        {
            throw new NotImplementedException();
        }
    }
}
