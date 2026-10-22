
using CinemaDomain.Base;

namespace CinemaDomain
{
    public class Filme : BaseEntity
    {
        public string Classificacao { get; set; }

        public string Nome { get; set; }

        public Genero Genero { get; set; }

        public int Duracao { get; set; }
    }
}