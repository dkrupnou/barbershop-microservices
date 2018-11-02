using System;
using System.Linq;
using System.Threading.Tasks;
using Barbershop.Barbers.DataAccessLayer;

namespace Barbershop.Barbers.BusinessLayer
{
    public class BarbersService: IBarbersService
    {
        private readonly IBarberDetailsStorage _storage;

        public BarbersService(IBarberDetailsStorage storage)
        {
            _storage = storage;
        }

        public async Task<Guid> RegisterBarber(string firstName, string lastName, string email)
        {
            var details = new BarberDetails()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            await _storage.Store(details);
            return details.Id;
        }

        public async Task RemoveBarber(Guid barberId)
        {
            await _storage.Remove(barberId);
        }

        public async Task<BarberDetails[]> GetBarbersDetails()
        {
            var allDetails = await _storage.GetAll();
            return allDetails.ToArray();
        }

        public async Task<BarberDetails> GetBarberDetails(Guid barberId)
        {
            return await _storage.Get(barberId);
        }
    }
}
