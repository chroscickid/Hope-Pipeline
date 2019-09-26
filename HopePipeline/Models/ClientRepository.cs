using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models
{
    public interface ClientRepository
    {
        IEnumerable<Client> Clients { get; }
    }
}
