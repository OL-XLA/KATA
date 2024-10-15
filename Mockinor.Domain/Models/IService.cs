using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mocknitor.Domain.Models
{
    public interface IService
    {

        public string Name { get; set; }

        public string Description { get; set; }
        /// <summary>
        /// Get Fuction that returns all available Actions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get();

        /// <summary>
        /// Receive instruction on a desired Action to execute inside of a JSON Body
        /// </summary>
        /// <returns></returns>
        public Task<Guid> Post();

    }
}
