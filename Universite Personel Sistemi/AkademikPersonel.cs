using System;
using System.Collections.Generic;

namespace Universite_Personel_Sistemi
{
    class AkademikPersonel : Personel
    {
        public enum AkademikUnvan
        {
            ProfDr = 1,
            DoçDr,
            Dr,
            ÖğGör,
            ArsGor
        }

        public List<string> MakalelerListesi { get; private protected set; }
        public AkademikUnvan Unvan { get; private protected set; }

        public AkademikPersonel(string tcNo, string isim, decimal maas,
                                AkademikUnvan unvan, List<string> makalelerListesi)
            : base(tcNo, isim, maas)
        {

            if (!Enum.IsDefined(typeof(AkademikUnvan), unvan))
                throw new ArgumentException("Akademik unvan boş geçilemez veya geçersiz.", nameof(unvan));

            if (makalelerListesi is null || makalelerListesi.Count == 0)
                throw new ArgumentException("Makaleler listesi boş geçilemez.", nameof(makalelerListesi));
            Unvan = unvan;
            MakalelerListesi = makalelerListesi;
        }
    }
}
