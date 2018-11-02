using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.Barbers.DataAccessLayer
{
    public class BarberDetailsStorage : IBarberDetailsStorage
    {
        private readonly List<BarberDetails> _details = new List<BarberDetails>();

        public async Task Store(BarberDetails details)
        {
            _details.Add(details);
            await Task.CompletedTask;
        }

        public async Task Remove(Guid barberId)
        {
            var details = _details.Find(x => x.Id.Equals(barberId));
            if (details != null)
                _details.Remove(details);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<BarberDetails>> GetAll()
        {
            return await Task.FromResult(_details);
        }

        public async Task<BarberDetails> Get(Guid barberId)
        {
            var barberDetails = _details.Find(x => x.Id.Equals(barberId));
            return await Task.FromResult(barberDetails);
        }
    }
}
