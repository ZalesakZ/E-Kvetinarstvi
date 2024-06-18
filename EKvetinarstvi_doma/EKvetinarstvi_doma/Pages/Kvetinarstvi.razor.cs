using EKvetinarstvi_doma.Models;
using System.Security.Cryptography.X509Certificates;

namespace EKvetinarstvi_doma.Pages
{
    public partial class Kvetinarstvi
    {
        public void Inicializace()
        {
            Polozka[] dekoraceItems = new Polozka[]
            {
                new Polozka("List palmy", 45),
                new Polozka("Gypsophila", 39),
                new Polozka("Santinka", 35),
                new Polozka("Pedik – různé barvy", 23),
                new Polozka("Další zeleň", 35),
                new Polozka("Stužka úzká", 25),
                new Polozka("Stužka široká", 45)
            };

            foreach (var item in dekoraceItems)
                DekoraceList.Add(item);
            
            Kytka[] kytkyItems = new Kytka[]
            {
                new Kytka("Růže", 59, "Rudá"),
                new Kytka("Růže", 75, "Žlutá"),
                new Kytka("Růže", 65, "Růžová"),
                new Kytka("Růže", 89, "Modrá"),

                new Kytka("Tulipán", 35, "Červená"),
                new Kytka("Tulipán", 35, "Žlutá"),
                new Kytka("Tulipán", 42, "Fialová"),

                new Kytka("Gerbera", 49, "Červená"),
                new Kytka("Gerbera", 45, "Žlutá"),
                new Kytka("Gerbera", 65, "Fialová")
            };

            foreach (var item in kytkyItems)
                KvetinyList.Add(item);

            Doprava[] dopravy = new Doprava[]
            {
                new Doprava("Expresní kurýr – jen v Plzni", 1200),
                new Doprava("Doručení dnes – jen v Plzni", 700),
                new Doprava("ČR do 48 h", 250),
                new Doprava("ČR do 24 h – jen v Plzni", 950)
            };

            foreach (var doprava in dopravy)
                DopravaList.Add(doprava);

        }

        public List<Polozka> Kosik = new List<Polozka>();
        public List<Polozka> DekoraceList = new List<Polozka>();
        public List<Kytka> KvetinyList = new List<Kytka>();
        public List<Doprava> DopravaList = new List<Doprava>();

        public Kytka Kvetina = new Kytka("Zadejte název", 0, "Zadejte barvu");
        public Polozka Dekorace = new Polozka("Zadejte dekoraci", 0);

        public Doprava Doprava = new Doprava("Zadejte způsob dopravy", 0);
        public Doprava ZvolenaDoprava = new Doprava("", 0);

        public bool Editace = false;
        public int CenaComplet = 0;

        public Kvetinarstvi()
        {
            Inicializace();
        }

        public void Pridat()
        {
            if (Kvetina.Pocet > 0)
            {
                for (int i = 0; i < KvetinyList.Count(); i++)
                {
                    if ((Kvetina.Nazev.ToLower().Trim() == KvetinyList[i].Nazev.ToLower()) && (Kvetina.Barva.ToLower().Trim() == KvetinyList[i].Barva.ToLower()))
                    {
                        KvetinyList[i].Pocet = Kvetina.Pocet;
                        Kosik.Add(KvetinyList[i]);
                        KvetinyList[i] = new Kytka(KvetinyList[i].Nazev, KvetinyList[i].Cena, KvetinyList[i].Barva);
                        break;
                    }
                }
            }
            Kvetina = new Kytka("Zadejte název", 0, "Zadejte barvu");
            Suma();
        }

        public void PridatDekoraci()
        {
            if (Dekorace.Pocet > 0)
            {
                for (int i = 0; i < DekoraceList.Count(); i++)
                {
                    if (Dekorace.Nazev.ToLower().Trim() == DekoraceList[i].Nazev.ToLower())
                    {
                        DekoraceList[i].Pocet = Dekorace.Pocet;
                        Kosik.Add(DekoraceList[i]);
                        DekoraceList[i] = new Polozka(DekoraceList[i].Nazev, DekoraceList[i].Cena);
                        break;
                    }
                }
            }
            Dekorace = new Polozka("Zadejte dekoraci", 0);
            Suma();
        }

        public void ZvolitDopravu()
        {
            for (int i = 0; i < DopravaList.Count(); i++)
            {
                if (Doprava.Typ.ToLower().Trim() == DopravaList[i].Typ.ToLower())
                {
                    ZvolenaDoprava = DopravaList[i];
                    break;
                }
            }
            Doprava = new Doprava("Zadejte způsob dopravy", 0);
            Suma();
        }

        public void Edit(int index)
        {
            if (Kosik[index].GetType() == Kvetina.GetType())
            {
                Kvetina = (Kytka)Kosik[index];
            }
            else
            {
                Dekorace = Kosik[index];
            }
            Editace = true;
        }

        public void StopEdit()
        {
            Kvetina = new Kytka("Zadejte název", 0, "Zadejte barvu");
            Dekorace = new Polozka("Zadejte dekoraci", 0);
            Editace = false;
            Suma();
        }

        public void Del(int index)
        {
            Kosik.RemoveAt(index);
            Suma();
        }

        public void Suma()
        {
            CenaComplet = 0;
            for (int i = 0; i < Kosik.Count(); i++)
            {
                CenaComplet += Kosik[i].CelkovaCena;
            }
            CenaComplet += ZvolenaDoprava.Cena;

            if (CenaComplet < 500)
            {
                CenaComplet = 500;
            }
        }

        public void Predpripraveno(int varianta)
        {
            if (varianta == 1) //Valentýn: 7x červených růží, 10x červený pedik, 1x list palmy
            {
                KvetinyList[0].Pocet = 7;
                DekoraceList[3].Pocet = 10;
                DekoraceList[0].Pocet = 1;

                Kosik.Add(KvetinyList[0]);
                Kosik.Add(DekoraceList[3]);
                Kosik.Add(DekoraceList[0]);

                KvetinyList[0] = new Kytka(KvetinyList[0].Nazev, KvetinyList[0].Cena, KvetinyList[0].Barva);
                DekoraceList[3] = new Polozka(DekoraceList[3].Nazev, DekoraceList[3].Cena);
                DekoraceList[0] = new Polozka(DekoraceList[0].Nazev, DekoraceList[0].Cena);
            }
            else if (varianta == 2) //Růže od srdce: 11x červených růží, 2x gypsophila, 3x další zeleň, stužka široká
            {
                KvetinyList[0].Pocet = 11;
                DekoraceList[1].Pocet = 2;
                DekoraceList[4].Pocet = 3;
                DekoraceList[6].Pocet = 1;

                Kosik.Add(KvetinyList[0]);
                Kosik.Add(DekoraceList[1]);
                Kosik.Add(DekoraceList[4]);
                Kosik.Add(DekoraceList[6]);

                KvetinyList[0] = new Kytka(KvetinyList[0].Nazev, KvetinyList[0].Cena, KvetinyList[0].Barva);
                DekoraceList[1] = new Polozka(DekoraceList[1].Nazev, DekoraceList[1].Cena);
                DekoraceList[4] = new Polozka(DekoraceList[4].Nazev, DekoraceList[4].Cena);
                DekoraceList[6] = new Polozka(DekoraceList[6].Nazev, DekoraceList[6].Cena);
            }
            else //Velké vyznání: 40x červená růže, 10x žlutá růže
            {
                KvetinyList[0].Pocet = 40;
                KvetinyList[1].Pocet = 10;

                Kosik.Add(KvetinyList[0]);
                Kosik.Add(KvetinyList[1]);

                KvetinyList[0] = new Kytka(KvetinyList[0].Nazev, KvetinyList[0].Cena, KvetinyList[0].Barva);
                KvetinyList[1] = new Kytka(KvetinyList[1].Nazev, KvetinyList[1].Cena, KvetinyList[1].Barva);
            }
            Suma();
        }
    }
}