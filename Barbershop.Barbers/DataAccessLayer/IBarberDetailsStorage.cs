using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.Barbers.DataAccessLayer
{
    public interface IBarberDetailsStorage
    {
        Task Store(BarberDetails details);
        Task Remove(Guid barberId);
        Task<IEnumerable<BarberDetails>> GetAll();
        Task<BarberDetails> Get(Guid barberId);
    }
}
