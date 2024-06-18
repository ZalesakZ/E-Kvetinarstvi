namespace EKvetinarstvi_doma.Models
{
    public class Kytka : Polozka
    {
        public Kytka(string nazev, int cena, string barva) : base(nazev, cena)
        {
            pocet = 0;
            Barva = barva;
        }
        public string Barva { get; set; }
    }
}
