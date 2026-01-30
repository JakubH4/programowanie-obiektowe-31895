using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

// 1. Poprawiony Namespace zgodnie z Twoim projektem
namespace Incident_Check_Beta
{
    // 4. Wszystkie filary obiektowości
    public abstract class IncydentBazowy
    {
        // 4c. Hermetyzacja i rozwiązanie problemu "Non-nullable" (inicjalizacja = "")
        public string Tytul { get; set; } = "";
        public DateTime Data { get; set; }
        
        public abstract void WyswietlPodsumowanie();
    }

    public class Incydent : IncydentBazowy
    {
        public string Opis { get; set; } = "";
        public string Priorytet { get; set; } = "";

        public override void WyswietlPodsumowanie()
        {
            Console.WriteLine($"[{Data}] {Priorytet} | {Tytul}: {Opis}");
        }
    }

    public class IncydentSieciowy : Incydent
    {
        // Poprawka nazewnictwa na AdresIp (zgodnie z sugestią IDE)
        public string AdresIp { get; set; } = "";

        public override void WyswietlPodsumowanie()
        {
            Console.WriteLine($"[{Data}] {Priorytet} | [SIECIOWY] {Tytul} (IP: {AdresIp}): {Opis}");
        }
    }

    class Program
    {
        // Sugestia nazw dla pól statycznych: dodanie '_' na początku
        private static List<Incydent> _bazaDanych = new List<Incydent>();
        private static readonly string _nazwaPliku = "incydenty.json";

        static void Main() // Usunięto nieużywane 'args'
        {
            WczytajZPliku();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CYBER-INCIDENT TRACKER ===");
                Console.WriteLine("1. Zgłoś incydent ogólny");
                Console.WriteLine("2. Zgłoś incydent sieciowy");
                Console.WriteLine("3. Wyświetl wszystkie");
                Console.WriteLine("4. Pokaż tylko KRYTYCZNE (LINQ)");
                Console.WriteLine("5. Zapisz i Wyjdź");
                Console.Write("\nWybierz: ");

                string? wybor = Console.ReadLine();
                if (wybor == "1") Dodaj(false);
                else if (wybor == "2") Dodaj(true);
                else if (wybor == "3") Wyswietl(_bazaDanych);
                else if (wybor == "4") FiltrujKrytyczne();
                else if (wybor == "5") { Zapisz(); break; }
            }
        }

        static void Dodaj(bool czySieciowy)
        {
            Console.Write("Tytuł: "); string t = Console.ReadLine() ?? "";
            Console.Write("Opis: "); string o = Console.ReadLine() ?? "";
            
            string p = t.ToLower().Contains("ransomware") ? "KRYTYCZNY" : "Normalny";

            if (czySieciowy)
            {
                Console.Write("Adres IP: "); string ip = Console.ReadLine() ?? "";
                _bazaDanych.Add(new IncydentSieciowy { Tytul = t, Opis = o, Priorytet = p, Data = DateTime.Now, AdresIp = ip });
            }
            else
            {
                _bazaDanych.Add(new Incydent { Tytul = t, Opis = o, Priorytet = p, Data = DateTime.Now });
            }
        }

        static void Wyswietl(List<Incydent> lista)
        {
            Console.WriteLine("\n--- RAPORT ---");
            foreach (var i in lista) i.WyswietlPodsumowanie();
            Console.WriteLine("\nKliknij Enter..."); Console.ReadLine();
        }

        static void FiltrujKrytyczne()
        {
            var krytyczne = _bazaDanych.Where(x => x.Priorytet == "KRYTYCZNY").ToList();
            Wyswietl(krytyczne);
        }

        static void Zapisz()
        {
            string json = JsonSerializer.Serialize(_bazaDanych);
            File.WriteAllText(_nazwaPliku, json);
        }

        static void WczytajZPliku()
        {
            if (File.Exists(_nazwaPliku))
            {
                string json = File.ReadAllText(_nazwaPliku);
                // Obsługa potencjalnego null przy deserializacji
                var dane = JsonSerializer.Deserialize<List<Incydent>>(json);
                if (dane != null) _bazaDanych = dane;
            }
        }
    }
}