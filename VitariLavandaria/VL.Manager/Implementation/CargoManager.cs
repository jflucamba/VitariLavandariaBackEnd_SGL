using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;
using VL.Manager.Interfaces;

namespace VL.Manager.Implementation
{
    public class CargoManager : ICargoManager
    {
        private readonly ICargoRepository cargoRepository;
        private readonly IMapper mapper;

        public CargoManager(ICargoRepository cargoRepository, IMapper mapper)
        {
            this.cargoRepository = cargoRepository;
            this.mapper = mapper;
        }

        public async Task DeleteCargoAsync(int id)
        {
            await cargoRepository.DeleteCargoAsync(id);
        }

        public async Task<Cargo> GetCargoAsync(int id)
        {
            return await cargoRepository.GetCargoAsync(id);
        }

        public async Task<IEnumerable<Cargo>> GetCargosAsync()
        {
            return await cargoRepository.GetCargosAsync();
        }

        public async Task<Cargo> InsertCargoAsync(Cargo novoCargo)
        {
            var cargo = mapper.Map<Cargo>(novoCargo);
            return await cargoRepository.InsertCargoAsync(cargo);
        }

        public async Task<Cargo> UpdateCargoAsync(AlterarCargo alterarCargo)
        {
            var cargo = mapper.Map<Cargo>(alterarCargo);
            return await cargoRepository.UpdateCargoAsync(alterarCargo);
        }
    }
}