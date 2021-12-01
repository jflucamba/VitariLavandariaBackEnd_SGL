using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;
using VL.Data.Context;
using VL.Manager.Interfaces;

namespace VL.Data.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly VlContext context;

        public CargoRepository(VlContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cargo>> GetCargosAsync()
        {
            return await context.Cargos.AsNoTracking().ToListAsync();
        }

        public async Task<Cargo> GetCargoAsync(int id)
        {
            return await context.Cargos.FindAsync(id);
        }

        //Insert
        public async Task<Cargo> InsertCargoAsync(Cargo novoCargo)
        {
            await context.Cargos.AddAsync(novoCargo);
            await context.SaveChangesAsync();
            return novoCargo;
        }

        //Update
        public async Task<Cargo> UpdateCargoAsync(AlterarCargo cargo)
        {
            var cargoConsultado = await context.Cargos.FindAsync(cargo.Id);

            if (cargoConsultado == null)
            {
                return null;
            }

            //clienteConsultado.Nome = cliente.Nome;
            //clienteConsultado.DataNascimento = cliente.DataNascimento;

            context.Entry(cargoConsultado).CurrentValues.SetValues(cargo);

            //context.Clientes.Update(clienteConsultado);

            await context.SaveChangesAsync();
            return cargoConsultado;
        }

        //Delete
        public async Task DeleteCargoAsync(int id)
        {
            var cargoConsultado = await context.Cargos.FindAsync(id);
            context.Cargos.Remove(cargoConsultado);
            await context.SaveChangesAsync();
        }
    }
}