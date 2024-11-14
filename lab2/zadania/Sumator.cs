//zad3
public class Sumator
{
    private int[] liczby;
    // Konstruktor inicjujący pole Liczby
    public Sumator(int[] liczby)
    {
        this.liczby = liczby;
    }
    // Publiczna metoda Suma zwracająca sumę liczb z pola Liczby
    public int Suma()
    {
        int suma = 0;
        foreach (int liczba in liczby)
        {
            suma += liczba;
        }
        return suma;
    }
    // Publiczna metoda SumaPodziel3 zwracająca sumę liczb z tablicy, które są podzielne przez 3
    public int SumaPodziel3()
    {
        int suma = 0;
        foreach (int liczba in liczby)
        {
            if (liczba % 3 == 0)
            {
                suma += liczba;
            }
        }
        return suma;
    }
    // Publiczna metoda IleElementów zwracająca liczbę elementów w tablicy
    public int IleElementów()
    {
        return liczby.Length;
    }
    // Publiczna metoda wypisująca wszystkie elementy tablicy
    public void WypiszElementy()
    {
        foreach (int liczba in liczby)
        {
            Console.WriteLine(liczba);
        }
    }
    // Publiczna metoda wypisująca elementy o indeksach >= lowIndex oraz <= highIndex
    public void WypiszElementyWZakresie(int lowIndex, int highIndex)
    {
        for (int i = Math.Max(0, lowIndex); i <= Math.Min(liczby.Length - 1, highIndex); i++)
        {
            Console.WriteLine(liczby[i]);
        }
    }
}