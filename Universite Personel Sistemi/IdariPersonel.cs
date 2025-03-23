using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universite_Personel_Sistemi
{
    class IdariPersonel:Personel
    {
        public string Gorev { get; protected private set; }

        public IdariPersonel(string TCno, string isim, decimal maas, string gorev):base(TCno, isim, maas)
        {
            if (string.IsNullOrWhiteSpace(gorev))
                throw new ArgumentException("Görev boş olamaz.", nameof(gorev));

            Gorev = gorev;
        }
    }
}
