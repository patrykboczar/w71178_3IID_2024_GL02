using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie obiektu klasy Osoba
            Osoba osoba = new Osoba("Paweł", "Nowak", 25, "12345678901");
            // Wywołanie metody PrzedstawSie i wyświetlenie wyniku
            Console.WriteLine(osoba.PrzedstawSie());

            // Tworzenie obiektu klasy Licz
            Licz licz = new Licz(10);
            licz.Dodaj(5);
            licz.Odejmij(3);
            licz.WypiszStan();

            // Tworzenie obiektu klasy Sumator
            int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Sumator sumator = new Sumator(liczby);
            Console.WriteLine($"Suma: {sumator.Suma()}");
            Console.WriteLine($"Suma liczb podzielnych przez 3: {sumator.SumaPodziel3()}");
            Console.WriteLine($"Liczba elementów: {sumator.IleElementów()}");
            Console.WriteLine("Elementy tablicy:");
            sumator.WypiszElementy();
            Console.WriteLine("Elementy tablicy w zakresie 2-5:");
            sumator.WypiszElementyWZakresie(2, 5);
        }
    }
}


