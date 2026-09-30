using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MikulasLib;

namespace MikulasCukrazdaja
{
    // crasy AI cook
    internal class Program
    {
        static void Main(string[] args)
        {
            string keszitesPath = GetFilePath("keszites.txt");
            var keszitesAdatokLista = File.ReadAllLines(keszitesPath)
                .Skip(1)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line =>
                {
                    string[] parts = line.Split(';');
                    return new KeszitesAdat(parts[0], parts[1], int.Parse(parts[2]));
                });
            var keszitesAdatok = new KeszitesAdatok(keszitesAdatokLista);

            Console.WriteLine($"Elérhető sütemény készítési azonosítók: {string.Join("; ", keszitesAdatok.ElerhetoKeszitesAzonositok)}");
            Console.WriteLine();

            string sutemenyekPath = GetFilePath("sutemenyek.txt");
            var sutemenyLista = File.ReadAllLines(sutemenyekPath)
                .Skip(1)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => SutemenyFactory.Factory(line, keszitesAdatok));
            var sutemenyek = new Sutemenyek(sutemenyLista);

            Console.WriteLine("A készíthető sütemények:");
            foreach (var sutemeny in sutemenyek.SutemenyTipusok)
            {
                Console.WriteLine($"\t{sutemeny}");
            }
            Console.WriteLine();

            string hibalistaPath = "hibalista.txt";
            File.WriteAllText(hibalistaPath, string.Empty);

            List<string> hibak = new();
            Feladatok feladatok = new();

            string feladatokPath = GetFilePath("feladatok.txt");
            var feladatSorok = File.ReadAllLines(feladatokPath)
                .Skip(1)
                .Where(line => !string.IsNullOrWhiteSpace(line));

            foreach (var sor in feladatSorok)
            {
                string[] parts = sor.Split(';');
                string azonosito = parts[0];
                int adag = int.Parse(parts[1]);

                var sutemeny = sutemenyek.SutemenyTipusok.FirstOrDefault(s => s.Azonosito == azonosito);
                if (sutemeny == null)
                {
                    hibak.Add($"{azonosito}: Ilyen azonosítójú süteményt nem készítenek.");
                    continue;
                }

                try
                {
                    var feladat = new Feladat(sutemeny, adag);
                    feladatok = feladatok + feladat;
                }
                catch (TulSokFeladatException ex)
                {
                    hibak.Add($"{ex.Message} - {adag} adag {sutemeny.Megnevezes}: {adag * sutemeny.ElkeszitesiIdo} perc");
                }
            }

            File.WriteAllLines(hibalistaPath, hibak);

            Console.WriteLine("Az elvégzendő feladatok:");
            foreach (var feladat in feladatok.FeladatLista)
            {
                Console.WriteLine($"\t{feladat}");
            }
            Console.WriteLine();

            Console.WriteLine("Süteményenként az elkészítendő adagok száma:");
            var sutemenyAdagok = feladatok.FeladatLista
                .GroupBy(f => f.Sutemeny.Megnevezes)
                .Select(g => new { Megnevezes = g.Key, OsszAdag = g.Sum(f => f.Adag) });

            foreach (var item in sutemenyAdagok)
            {
                Console.WriteLine($"\t{item.Megnevezes}: {item.OsszAdag} adag");
            }
        }

        static string GetFilePath(string fileName)
        {
            string[] candidates =
            {
                fileName,
                Path.Combine("Input", fileName),
                Path.Combine("..", "Input", fileName),
                Path.Combine("..", "..", "Input", fileName),
                Path.Combine("..", "..", "..", "Input", fileName),
                Path.Combine(AppContext.BaseDirectory, fileName),
                Path.Combine(AppContext.BaseDirectory, "Input", fileName),
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Input", fileName)
            };

            foreach (var candidate in candidates)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            return fileName;
        }
    }
}
