namespace EKvetinarstvi_doma.Models
{
    public class Doprava
    {
        public Doprava(string typ, int cena)
        {
            Typ = typ;
            Cena = cena;
        }

        public string Typ { get; set; }
        public int Cena { get; private set; }
    }
}
