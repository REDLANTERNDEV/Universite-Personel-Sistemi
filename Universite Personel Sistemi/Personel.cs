using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universite_Personel_Sistemi
{
    public class Personel
    {
        public string Isim { get; private protected set; }
        public decimal AylikMaas { get; set; }

        public Personel(string TCno, string isim, decimal aylikMaas)
        {
            if (string.IsNullOrWhiteSpace(isim))
                throw new ArgumentException("İsim boş olamaz.", nameof(isim));
            if (aylikMaas < 0)
                throw new ArgumentException("Aylık maaş negatif olamaz.", nameof(aylikMaas));

            Isim = isim;
            AylikMaas = aylikMaas;

            int Algoritma_Adim_Kontrol = 0, TekBasamaklarToplami = 0, CiftBasamaklarToplami = 0;

            if (TCno.Length == 11)
                Algoritma_Adim_Kontrol = 1;
            foreach (char chr in TCno)
            {
                if (char.IsNumber(chr))
                    Algoritma_Adim_Kontrol = 2;
            }
            if (TCno.Substring(0, 1) != "0")
                Algoritma_Adim_Kontrol = 3;

            int[] arrTC = System.Text.RegularExpressions.Regex.Replace(TCno, "[^0-9]", "")
                           .Select(x => (int)char.GetNumericValue(x))
                           .ToArray();

            for (int i = 0; i < TCno.Length; i++)
            {
                if (((i + 1) % 2) == 0)
                {
                    if (i + 1 != 10)
                        CiftBasamaklarToplami += Convert.ToInt32(arrTC[i]);
                    else if (i + 1 != 11)
                        TekBasamaklarToplami += Convert.ToInt32(arrTC[i]);
                }
            }

            if (Convert.ToInt32(TCno.Substring(9, 1))
               == (((TekBasamaklarToplami * 7) - CiftBasamaklarToplami) % 10))
            {
                Algoritma_Adim_Kontrol = 4;
            }
            if (Convert.ToInt32(TCno.Substring(10, 1))
               == ((arrTC.Sum() - Convert.ToInt32(TCno.Substring(10, 1))) % 10))
            {
                Algoritma_Adim_Kontrol = 5;
            }

            if (Algoritma_Adim_Kontrol != 5)
                throw new ArgumentException("TC No Yanlış", nameof(TCno));
        }

        public static Personel operator +(Personel person, decimal artisMiktari)
        {
            person.AylikMaas += artisMiktari;
            return person;

        }
    }
}
