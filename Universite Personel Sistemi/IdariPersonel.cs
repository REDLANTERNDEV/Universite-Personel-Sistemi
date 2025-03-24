using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universite_Personel_Sistemi
{
    class IdariPersonel : Personel
    {
        private string gorev;

        public string Gorev
        {
            get 
            { 
                return gorev;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Görev boş olamaz.", nameof(value));
                gorev = value;
            }
        }

        public IdariPersonel(string _TCno, string _isim, decimal _maas, string _gorev) : base(_TCno, _isim, _maas)
        {
            Gorev = _gorev;
        }
    }
}
