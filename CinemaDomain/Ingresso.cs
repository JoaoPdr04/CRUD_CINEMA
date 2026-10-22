

using CinemaDomain.Base;

namespace CinemaDomain
{
    public class Ingresso : BaseEntity
    {

        public string Documento { get; set; }

        public System.DateTime DataCompra { get; set; }

        public Sessao Sessao { get; set; }

        public decimal ValorTotal { get; set; }

        public string FormaPagamento { get; set; }

        public System.Collections.Generic.List<IngressoItem> IngressoItens { get; set; }
    }
}