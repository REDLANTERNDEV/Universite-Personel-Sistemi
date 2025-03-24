using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universite_Personel_Sistemi
{
    public class Personel
    {
        private string tcNo;
        private string isim;
        private decimal aylikMaas;

        public string TcNo
        {
            get
            {
                return tcNo;
            }
            set
            {
                if (!TcDogrulama(value))
                    throw new ArgumentException("TC No Yanlış", nameof(value));
                tcNo = value;
            }
        }

        public string Isim
        {
            get
            {
                return isim;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("İsim boş olamaz.", nameof(value));
                isim = value;
            }
        }

        public decimal AylikMaas
        {
            get
            {
                return aylikMaas;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Aylık maaş negatif olamaz.", nameof(value));
                aylikMaas = value;
            }
        }

        public Personel(string _tcNo, string _isim, decimal _aylikMaas)
        {
            TcNo = _tcNo;
            Isim = _isim;
            AylikMaas = _aylikMaas;
        }

        private bool TcDogrulama(string _tcNo)
        {
            if (_tcNo.Length != 11) return false;
            if (!_tcNo.All(char.IsDigit)) return false;
            if (_tcNo[0] == '0') return false;

            int[] digits = _tcNo.Select(x => x - '0').ToArray();
            int teklerinToplami = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int ciftlerinToplami = digits[1] + digits[3] + digits[5] + digits[7];

           
            if ((((teklerinToplami * 7) - ciftlerinToplami) % 10) != digits[9]) return false;
            
            int ilkOnToplami = digits.Take(10).Sum();
            if ((ilkOnToplami % 10) != digits[10]) return false;

            return true;
        }

        public static Personel operator +(Personel _personel, decimal _artisMiktari)
        {
            _personel.AylikMaas += _artisMiktari;
            return _personel;
        }
    }
}
