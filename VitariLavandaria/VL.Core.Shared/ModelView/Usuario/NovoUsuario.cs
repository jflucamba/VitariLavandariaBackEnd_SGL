using System.Collections.Generic;

namespace VL.Core.Shared.ModelView.Usuario
{
    public class NovoUsuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<ReferenciaFuncao> Funcoes { get; set; }
    }
}