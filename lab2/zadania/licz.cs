//zad2
public class Licz
{
    // Prywatne pole przechowujące wartość liczbową
    private int wartosc;
    // Konstruktor inicjujący pole wartość
    public Licz(int poczatkowaWartosc)
    {
        wartosc = poczatkowaWartosc;
    }
    // Publiczna metoda Dodaj
    public void Dodaj(int liczba)
    {
        wartosc += liczba;
    }
    // Publiczna metoda Odejmij
    public void Odejmij(int liczba)
    {
        wartosc -= liczba;
    }
    // Publiczna metoda wypisująca stan obiektu
    public void WypiszStan()
    {
        Console.WriteLine($"Aktualna wartość: {wartosc}");
    }
}
