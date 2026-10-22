
namespace CinemaDomain
{
    public class IngressoItem
    {
        public int Id { get; set; }
        public int Assento { get; set; }

        public int Fileira { get; set; }

        public Ingresso Ingresso { get; set; }

        public bool MeiaEntrada { get; set; }
    }
}