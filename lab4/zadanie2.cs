using System;
using System.Collections.Generic;

namespace lab4
{
    public class Osoba
    {
        public required string Imie { get; set; }
        public required string Nazwisko { get; set; }
        public required string Pesel { get; set; }

        public void UstawImie(string imie)
        {
            Imie = imie;
        }

        public void UstawNazwisko(string nazwisko)
        {
            Nazwisko = nazwisko;
        }

        public void UstawPesel(string pesel)
        {
            Pesel = pesel;
        }

        public int PobierzWiek()
        {
            if (Pesel.Length != 11 || !long.TryParse(Pesel, out _))
            {
                throw new ArgumentException("Nieprawidłowy numer PESEL.");
            }

            int rok = int.Parse(Pesel.Substring(0, 2));
            int miesiac = int.Parse(Pesel.Substring(2, 2));
            int dzien = int.Parse(Pesel.Substring(4, 2));

            if (miesiac > 80)
            {
                miesiac -= 80;
                rok += 1800;
            }
            else if (miesiac > 60)
            {
                miesiac -= 60;
                rok += 2200;
            }
            else if (miesiac > 40)
            {
                miesiac -= 40;
                rok += 2100;
            }
            else if (miesiac > 20)
            {
                miesiac -= 20;
                rok += 2000;
            }
            else
            {
                rok += 1900;
            }

            try
            {
                DateTime dataUrodzenia = new DateTime(rok, miesiac, dzien);
                int wiek = DateTime.Now.Year - dataUrodzenia.Year;

                if (DateTime.Now.DayOfYear < dataUrodzenia.DayOfYear)
                {
                    wiek--;
                }

                return wiek;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Year, Month, and Day parameters describe an un-representable DateTime.");
            }
        }

        public string PobierzPlec()
        {
            int dziesiataCyfra = int.Parse(Pesel.Substring(9, 1));
            return dziesiataCyfra % 2 == 0 ? "Kobieta" : "Mężczyzna";
        }

        public virtual string PobierzInformacjeOEdukacji()
        {
            return "Informacje o edukacji nie są dostępne.";
        }

        public virtual string PobierzPelneImieNazwisko()
        {
            return $"{Imie} {Nazwisko}";
        }

        public virtual bool CzyMozeSamWrocicDoDomu()
        {
            return false;
        }
    }

    public class Uczen : Osoba
    {
        public required string Szkola { get; set; }
        public bool MozeSamWrocicDoDomu { get; set; }

        public void UstawSzkole(string szkola)
        {
            Szkola = szkola;
        }

        public void ZmienSzkole(string szkola)
        {
            Szkola = szkola;
        }

        public void UstawCzyMozeSamWrocic(bool mozeSamWrocic)
        {
            MozeSamWrocicDoDomu = mozeSamWrocic;
        }

        public override string PobierzInformacjeOEdukacji()
        {
            return $"Uczeń w szkole: {Szkola}";
        }

        public override bool CzyMozeSamWrocicDoDomu()
        {
            int wiek = PobierzWiek();
            return wiek >= 12 || MozeSamWrocicDoDomu;
        }

        public string Informacja()
        {
            return CzyMozeSamWrocicDoDomu() ? "Uczeń może wracać samodzielnie." : "Uczeń nie może wracać samodzielnie.";
        }
    }

    public class Nauczyciel : Osoba
    {
        public required string TytulNaukowy { get; set; }
        public List<Uczen> UczniowieKlasy { get; set; } = new List<Uczen>();

        public void DodajUcznia(Uczen uczen)
        {
            UczniowieKlasy.Add(uczen);
        }

        public List<string> KtorzyUcziowieMogaWrocicSamodzielnie()
        {
            List<string> uczniowieMogaWrocic = new List<string>();

            foreach (var uczen in UczniowieKlasy)
            {
                if (uczen.CzyMozeSamWrocicDoDomu())
                {
                    uczniowieMogaWrocic.Add($"{uczen.Imie} {uczen.Nazwisko} - {uczen.PobierzPlec()}");
                }
            }
            return uczniowieMogaWrocic;
        }

        public void PodsumowanieKlasy(DateTime data)
        {
            Console.WriteLine($"Dnia: {data.ToShortDateString()}");
            Console.WriteLine($"Nauczyciel: {TytulNaukowy} {Imie} {Nazwisko}");
            Console.WriteLine("Lista studentów:");
            int lp = 1;
            foreach (var uczen in UczniowieKlasy)
            {
                string verdict = uczen.CzyMozeSamWrocicDoDomu() ? "Może wracać samodzielnie" : "Nie może wracać samodzielnie";
                string reasoning = uczen.CzyMozeSamWrocicDoDomu() ? "" : " (wiek poniżej 12 lat i brak pozwolenia)";
                Console.WriteLine($"{lp}. {uczen.Imie} {uczen.Nazwisko} - {uczen.PobierzPlec()} - {verdict}{reasoning}");
                lp++;
            }
        }
    }
}
