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
                    new List<string> { "Makine Öğrenmesi ve Veri Madenciliği: Sağlık Sektöründe Erken Tanı Sistemlerinin Geliştirilmesi", "Sosyal Bilimlerde Yeni Yaklaşımlar: Küreselleşme ve Kimlik Politikalarının İlişkisi", "Yükseköğretimde Dijitalleşme: Üniversitelerde Eğitim Teknolojilerinin Etkisi ve Geleceği" }
                )
            );
            personeller.Add(
                new AkademikPersonel(
                    "99720057784",
                    "Yağmur Aldemir",
                    6000m,
                    AkademikPersonel.AkademikUnvan.ProfDr,
                    new List<string> { "Toplumsal Cinsiyet Eşitliği ve Hukuk: Modern Hukuk Sistemlerinde Kadın Hakları Perspektifi", "İklim Değişikliği ve Sürdürülebilir Kalkınma: Yenilenebilir Enerji Kaynaklarının Ekonomik ve Çevresel Yararları" }
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

            // (+) operatorunu overload ederek personel maasina zam
            for (int i = 0; i < personeller.Count; i++)
            {
                personeller[i] += 600m;
            }

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
            foreach (var per in personeller)
            {
                if (per is AkademikPersonel akademik)
                {
                    Console.WriteLine(
                        $"{akademik.Unvan}.{akademik.Isim} - Maaş: {akademik.AylikMaas}\nMakaleler: \n {string.Join(",\n ", akademik.MakalelerListesi)}"
                    );
                }
                else if (per is IdariPersonel idari)
                {
                    Console.WriteLine(
                        $"{idari.Isim} - İdari Görev: {idari.Gorev} - Maaş: {idari.AylikMaas}"
                    );
                }
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
