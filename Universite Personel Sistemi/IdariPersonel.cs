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

        public IdariPersonel(string _tcNo, string _isim, decimal _aylikMaas, string _gorev) : base(_tcNo, _isim, _aylikMaas)
        {
            Gorev = _gorev;
        }
    }
}
