using converter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace converter.IServices
{
    public interface IObservationService
    {
        IEnumerable<Observation> Get();
    }
}
