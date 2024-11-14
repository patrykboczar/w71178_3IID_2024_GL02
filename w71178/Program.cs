using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programRunning = true;

            while (programRunning)
            {
                // Wyświetlenie menu użytkownika
                Console.WriteLine("\nGłówne Menu:");
                Console.WriteLine("1. Sprawdź, czy liczba jest parzysta (Zadanie 1)");
                Console.WriteLine("2. Pokaż wszystkie parzyste liczby od 1 do N (Zadanie 2)");
                Console.WriteLine("3. Oblicz silnię (Zadanie 4)");
                Console.WriteLine("4. Gra: odgadnij liczbę (Zadanie 5)");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wybierz numer z menu: ");
                var opcjaMenu = Console.ReadLine();

                switch (opcjaMenu)
                {
                    case "1":
                        // Zadanie 1
                        Console.WriteLine("Podaj dowolną liczbę:");
                        var userInput = Console.ReadLine();

                        if (int.TryParse(userInput, out int liczba))
                        {
                            Console.WriteLine(CzyLiczbaParzysta(liczba) ? "Liczba parzysta" : "Liczba nieparzysta");
                        }
                        else
                        {
                            Console.WriteLine("Wprowadziłeś nieprawidłową wartość.");
                        }
                        break;

                    case "2":
                        // Zadanie 2
                        Console.WriteLine("Podaj liczbę N:");
                        userInput = Console.ReadLine();

                        if (int.TryParse(userInput, out int liczbaN))
                        {
                            Console.WriteLine($"Parzyste liczby z zakresu 1 do {liczbaN}:");

                            for (int i = 1; i <= liczbaN; i++)
                            {
                                if (CzyLiczbaParzysta(i))
                                {
                                    Console.WriteLine(i);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowa wartość.");
                        }
                        break;

                    case "3":
                        // Zadanie 4: Obliczanie silni
                        Console.WriteLine("Podaj liczbę, aby obliczyć jej silnię:");
                        userInput = Console.ReadLine();

                        if (int.TryParse(userInput, out int liczbaSilnia) && liczbaSilnia >= 0)
                        {
                            long wynikSilnia = Silnia(liczbaSilnia);
                            Console.WriteLine($"Silnia liczby {liczbaSilnia} wynosi: {wynikSilnia}");
                        }
                        else
                        {
                            Console.WriteLine("Wprowadziłeś niepoprawną liczbę. Podaj liczbę całkowitą nieujemną.");
                        }
                        break;

                    case "4":
                        // Zadanie 5: Gra "odgadnij liczbę"
                        GraZGadywania();
                        break;

                    case "5":
                        // Wyjście z programu
                        Console.WriteLine("Zakończono program.");
                        programRunning = false;
                        break;

                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        // Metoda sprawdzająca, czy liczba jest parzysta
        static bool CzyLiczbaParzysta(int liczba)
        {
            return liczba % 2 == 0;
        }

        // Zadanie 4: Metoda rekurencyjna do obliczania silni
        static long Silnia(int n)
        {
            if (n == 0)
                return 1;
            return n * Silnia(n - 1);
        }

        // Zadanie 5: odgadnij liczbę
        static void GraZGadywania()
        {
            Random losowanie = new Random();
            int wylosowanaLiczba = losowanie.Next(1, 101); // Losowanie liczby z zakresu 1-100
            int proba = 0;
            int iloscProb = 0;

            Console.WriteLine("Komputer wylosował liczbę z przedziału od 1 do 100. Spróbuj ją odgadnąć!");

            // Pętla zgadywania
            while (proba != wylosowanaLiczba)
            {
                Console.Write("Podaj swoją liczbę: ");
                var inputUsera = Console.ReadLine();

                if (int.TryParse(inputUsera, out proba))
                {
                    iloscProb++; // Zwiększenie licznika prób

                    if (proba < wylosowanaLiczba)
                    {
                        Console.WriteLine("Wylosowana liczba jest większa!");
                    }
                    else if (proba > wylosowanaLiczba)
                    {
                        Console.WriteLine("Wylosowana liczba jest mniejsza!");
                    }
                }
                else
                {
                    Console.WriteLine("Podano niepoprawną wartość. Spróbuj jeszcze raz.");
                }
            }

            // Użytkownik odgadł liczbę
            Console.WriteLine($" Udało Ci się odgadnąć liczbę {wylosowanaLiczba} za {iloscProb} prób.");
        }
    }
}
