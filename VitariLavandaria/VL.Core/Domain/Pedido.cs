using System;
using System.Collections.Generic;
using System.Text;

namespace VL.Core.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataAbertura { get; set; }        
        public int Quantidade { get; set; }
        
    }
}
