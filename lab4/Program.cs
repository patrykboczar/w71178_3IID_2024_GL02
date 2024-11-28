using lab4;
using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie1.Wykonaj();

            Nauczyciel nauczyciel = new Nauczyciel
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                TytulNaukowy = "Dr"
            };

            Uczen uczen1 = new Uczen
            {
                Imie = "Anna",
                Nazwisko = "Nowak",
                Pesel = "01234567890", 
                Szkola = "Szkoła Podstawowa nr 1",
                MozeSamWrocicDoDomu = true
            };

            Uczen uczen2 = new Uczen
            {
                Imie = "Piotr",
                Nazwisko = "Wiśniewski",
                Pesel = "02070803628",
                Szkola = "Szkoła Podstawowa nr 1",
                MozeSamWrocicDoDomu = false
            };

            nauczyciel.DodajUcznia(uczen1);
            nauczyciel.DodajUcznia(uczen2);

            nauczyciel.PodsumowanieKlasy(DateTime.Now);
        }
    }
}
