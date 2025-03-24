using System;
using System.Collections.Generic;

namespace Universite_Personel_Sistemi
{
    public class AkademikPersonel : Personel
    {
        public enum AkademikUnvan
        {
            ArsGor = 1,
            ÖğGör,
            Dr,
            DoçDr,
            ProfDr
        }

        private AkademikUnvan unvan;
        private List<string> makalelerListesi;

        public AkademikUnvan Unvan
        {
            get { return unvan; }
            set
            {
                if (!Enum.IsDefined(typeof(AkademikUnvan), value))
                    throw new ArgumentException("Akademik unvan boş geçilemez veya geçersiz.", nameof(value));
                unvan = value;
            }
        }

        public List<string> MakalelerListesi
        {
            get 
            {
                return makalelerListesi;
            } 
            set
            {
                if (value is null || value.Count == 0)
                    throw new ArgumentException("Makaleler listesi boş geçilemez.", nameof(value));
                makalelerListesi = value;
            }
        }

        public AkademikPersonel(string _tcNo, string _isim, decimal _maas,
                                AkademikUnvan _unvan, List<string> _makalelerListesi)
            : base(_tcNo, _isim, _maas)
        {
            Unvan = _unvan;
            MakalelerListesi = _makalelerListesi;
        }
    }
}
