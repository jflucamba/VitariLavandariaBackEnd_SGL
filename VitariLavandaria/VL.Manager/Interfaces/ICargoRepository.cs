using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;

namespace VL.Manager.Interfaces
{
    public interface ICargoRepository
    {
        Task DeleteCargoAsync(int id);

        Task<Cargo> GetCargoAsync(int id);

        Task<IEnumerable<Cargo>> GetCargosAsync();

        Task<Cargo> InsertCargoAsync(Cargo novoCargo);

        Task<Cargo> UpdateCargoAsync(AlterarCargo cargo);
    }
}