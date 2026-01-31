using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Incident_Check_Beta
{
    public class Incydent
    {
        public string Tytul { get; set; } = "";
        public string Opis { get; set; } = "";
        public string Priorytet { get; set; } = "";
        public DateTime Data { get; set; }

        public virtual void WyswietlPodsumowanie()
        {
            Console.WriteLine($"[{Data}] {Priorytet} | {Tytul}: {Opis}");
        }
    }

    public class IncydentSieciowy : Incydent
    {
        public string AdresIp { get; set; } = "";

        public override void WyswietlPodsumowanie()
        {
            Console.WriteLine($"[{Data}] {Priorytet} | [SIECIOWY] {Tytul} (IP: {AdresIp}): {Opis}");
        }
    }

    class Program
    {
        private static List<Incydent> _bazaDanych = new List<Incydent>();
        private static readonly string _nazwaPliku = "incydenty.json";

        static void Main()
        {
            WczytajZPliku();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM ZGŁOSZEŃ ===");
                Console.WriteLine("1. Nowy incydent");
                Console.WriteLine("2. Nowy incydent sieciowy");
                Console.WriteLine("3. Wyświetl wszystko");
                Console.WriteLine("4. Zapisz i Wyjdź");
                Console.Write("\nWybór: ");

                string? wybor = Console.ReadLine();
                if (wybor == "1") Dodaj(false);
                else if (wybor == "2") Dodaj(true);
                else if (wybor == "3") Wyswietl();
                else if (wybor == "4") { Zapisz(); break; }
            }
        }

        static void Dodaj(bool czySieciowy)
        {
            Console.Write("Tytuł: "); string t = Console.ReadLine() ?? "";
            Console.Write("Opis: "); string o = Console.ReadLine() ?? "";
            Console.Write("Priorytet: "); string p = Console.ReadLine() ?? "";

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

        static void Wyswietl()
        {
            Console.WriteLine("\n--- LISTA ---");
            foreach (var i in _bazaDanych)
            {
                i.WyswietlPodsumowanie();
            }
            Console.WriteLine("\nNaciśnij Enter...");
            Console.ReadLine();
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
                var dane = JsonSerializer.Deserialize<List<Incydent>>(json);
                if (dane != null) _bazaDanych = dane;
            }
        }
    }
}