using Barbershop.Barbers.DataAccessLayer;
using Barbershop.Barbers.ServiceLayer.Model;

namespace Barbershop.Barbers.ServiceLayer.Util
{
    public static class ModelMapper
    {
        public static BarberDetailsModel ToBarberDetailsModel(this BarberDetails details)
        {
            return new BarberDetailsModel()
            {
                Id = details.Id.ToString("N"),
                FirstName = details.FirstName,
                LastName = details.LastName,
                Email = details.Email
            };
        }

    }
}
