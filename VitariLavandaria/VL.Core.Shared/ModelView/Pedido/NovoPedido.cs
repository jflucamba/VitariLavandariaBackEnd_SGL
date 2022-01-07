using System;

namespace VL.Core.Shared.ModelView.Pedido
{
    public class NovoPedido
    {
        public string Nome { get; set; }
        public DateTime DataAbertura { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public decimal PrecoUnidade { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
    }
}