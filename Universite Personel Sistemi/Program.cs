using System;
using System.Collections.Generic;
using System.Linq;

namespace Universite_Personel_Sistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personeller = new List<Personel>();

            personeller.Add(
                new AkademikPersonel(
                    "50899412446",
                    "Hayri Sezer",
                    5000m,
                    AkademikPersonel.AkademikUnvan.DoçDr, 
                    new List<string> { "makale1", "makale2" }
                )
            );
            personeller.Add(
                new AkademikPersonel(
                    "99720057784",
                    "Yağmur Aldemir",
                    6000m,
                    AkademikPersonel.AkademikUnvan.ProfDr,
                    new List<string> { "makale3", "makale4" }
                )
            );

            personeller.Add(
                new IdariPersonel(
                    "79855500256",
                    "Altay Tezcan",
                    4000m,
                    "Öğrenci İşleri"
                )
            );

            // (+) operatorunu overload ederek ilk personel maasina zam
            personeller[0].AylikMaas += 600m;

            // Maaş toplami ve ortalamasi
            decimal toplamMaas = 0;
            foreach (var personel in personeller)
            {
                toplamMaas += personel.AylikMaas;
            }

            decimal ortalamaMaas = 0;
            if (personeller.Count > 0)
            {
                ortalamaMaas = toplamMaas / personeller.Count;
            }

            Console.WriteLine($"Üniversitedeki toplam maaş: {toplamMaas}");
            Console.WriteLine($"Üniversitedeki ortalama maaş: {ortalamaMaas}");

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Liste:");
            foreach (var p in personeller)
            {
                if (p is AkademikPersonel ak)
                {
                    Console.WriteLine(
                        $"{ak.Unvan}.{ak.Isim} - Maaş: {ak.AylikMaas}\nMakaleler: {string.Join(", ", ak.MakalelerListesi)}"
                    );
                }
                else if (p is IdariPersonel id)
                {
                    Console.WriteLine(
                        $"{id.Isim} - İdari Görev: {id.Gorev} - Maaş: {id.AylikMaas}"
                    );
                }
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
