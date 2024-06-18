namespace EKvetinarstvi_doma.Models
{
    public class Polozka
    {
        protected int pocet;

        public Polozka(string nazev, int cena)
        {
            Nazev = nazev;
            Cena = cena;
            pocet = 0;
        }

        public string Nazev { set; get; }
        public int Pocet
        {
            get => pocet;
            set
            {
                if (value < 0)
                {
                    pocet = 0;
                }
                else
                {
                    pocet = value;
                }
            }
        }
        public int Cena { get; }
        public int CelkovaCena => Cena * Pocet;
    }
}
