using System.Collections.Generic;

namespace VL.Core.Shared.ModelView.Usuario
{
    public class UsuarioView
    {
        public string Login { get; set; }
        public ICollection<FuncaoView> Funcoes { get; set; }
    }
}