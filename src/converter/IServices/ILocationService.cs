using converter.Models;
using System.Collections.Generic;

namespace converter.IServices
{
    public interface ILocationService
    {
        IEnumerable<Location> Get();
    }
}
