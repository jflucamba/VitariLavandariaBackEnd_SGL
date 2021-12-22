using System.Collections.Generic;

namespace VL.Core.Shared.ModelView.Usuario
{
    public class UsuarioLogado
    {
        public string Login { get; set; }
        public ICollection<CargoView> Funcoes { get; set; }
        public string Token { get; set; }
    }
}