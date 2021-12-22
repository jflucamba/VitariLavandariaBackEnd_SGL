using System.Collections.Generic;

namespace VL.Core.Domain
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Cargo> Cargos { get; set; }

        public Usuario()
        {
            Cargos = new HashSet<Cargo>();
        }
    }
}