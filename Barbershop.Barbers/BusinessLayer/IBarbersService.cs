using System;
using System.Threading.Tasks;
using Barbershop.Barbers.DataAccessLayer;

namespace Barbershop.Barbers.BusinessLayer
{
    public interface IBarbersService
    {
        Task<Guid> RegisterBarber(string firstName, string lastName, string email);
        Task RemoveBarber(Guid barberId);
        Task<BarberDetails[]> GetBarbersDetails();
        Task<BarberDetails> GetBarberDetails(Guid barberId);
    }
}