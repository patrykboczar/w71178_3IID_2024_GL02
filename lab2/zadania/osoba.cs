//zad1

public class Osoba
{
    // Prywatne pola
    private string imie;
    private string nazwisko;
    private int wiek;
    private string pesel;
    // Konstruktor inicjalizujący wszystkie pola
    public Osoba(string imie, string nazwisko, int wiek, string pesel)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        Wiek = wiek; // Używamy właściwości, aby zastosować walidację
        this.pesel = pesel;
    }
    // Publiczne właściwości
    public string Imie
    {
        get { return imie; }
        set { imie = value; }
    }

    public string Nazwisko
    {
        get { return nazwisko; }
        set { nazwisko = value; }
    }
    public int Wiek
    {
        get { return wiek; }
        set
        {
            if (value < 0)
            {
                wiek = 0;
            }
            else
            {
                wiek = value;
            }
        }
    }
    // Publiczna właściwość tylko do odczytu
    public string Pesel
    {
        get { return pesel; }
    }
    // Publiczna metoda PrzedstawSie
    public string PrzedstawSie()
    {
        return $"Nazywam się {imie} {nazwisko} i mam {wiek} lat";
    }
}