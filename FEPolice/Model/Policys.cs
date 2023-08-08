using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPolice.Model
{
    public class Policys
    {
        int _policyNumber;
        public int PolicyNumber
        {
            get => _policyNumber;
            set
            {
                if (_policyNumber == value)
                {
                    return;
                }
                _policyNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_policyNumber)));
            }
        }

        int _personId;
        public int PersonId
        {
            get => _personId;
            set
            {
                if (_personId == value)
                {
                    return;
                }
                _personId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_personId)));
            }
        }

        int _productId;
        public int ProductId
        {
            get => _productId;
            set
            {
                if (_productId == value)
                {
                    return;
                }
                _productId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_productId)));
            }
        }



        Product _Product;
        public Product Product
        {
            get => _Product;
            set
            {
                if (_Product == value)
                {
                    return;
                }
                _Product = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_Product)));
            }
        }

        Person _Person;
        public Person Person
        {
            get => _Person;
            set
            {
                if (_Person == value)
                {
                    return;
                }
                _Person = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_Person)));
            }
        }

        DateTime _VadeBaslangic;
        public DateTime VadeBaslangic
        {
            get => _VadeBaslangic;
            set
            {
                if (_VadeBaslangic == value)
                {
                    return;
                }
                _VadeBaslangic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_VadeBaslangic)));
            }
        }
        DateTime _VadeBitis;
        public DateTime VadeBitis
        {
            get => _VadeBitis;
            set
            {
                if (_VadeBitis == value)
                {
                    return;
                }
                _VadeBitis = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_VadeBitis)));
            }
        }

        DateTime _TanzimTarihi;
        public DateTime TanzimTarihi
        {
            get => _TanzimTarihi;
            set
            {
                if (_TanzimTarihi == value)
                {
                    return;
                }
                _TanzimTarihi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_TanzimTarihi)));
            }
        }

        double _prim;
        public double Prim
        {
            get => _prim;
            set
            {
                if (_prim == value)
                {
                    return;
                }
                _prim = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_prim)));
            }
        }
        private string carModel;
        public string CarModel
        {
            get => carModel;
            set
            {
                if (carModel == value)
                {
                    return;
                }
                carModel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(carModel)));
            }
        }

        private string _CarPlateNumber;
        public string CarPlateNumber
        {
            get => _CarPlateNumber;
            set
            {
                if (_CarPlateNumber == value)
                {
                    return;
                }
                _CarPlateNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_CarPlateNumber)));
            }
        }

        private string _CarBrand;
        public string CarBrand
        {
            get => _CarBrand;
            set
            {
                if (_CarBrand == value)
                {
                    return;
                }
                _CarBrand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_CarBrand)));
            }
        }

        private string _PlakaIlKodu;
        public string PlakaIlKodu
        {
            get => _PlakaIlKodu;
            set
            {
                if (_PlakaIlKodu == value)
                {
                    return;
                }
                _PlakaIlKodu = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_PlakaIlKodu)));
            }
        }

        private string _PlakaKodu;
        public string PlakaKodu
        {
            get => _PlakaKodu;
            set
            {
                if (_PlakaKodu == value)
                {
                    return;
                }
                _PlakaKodu = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_PlakaKodu)));
            }
        }


        private string _sigortaNumarasi;
        public string SigortaNumarasi
        {
            get => _sigortaNumarasi;
            set
            {
                if (_sigortaNumarasi == value)
                {
                    return;
                }
                _sigortaNumarasi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_sigortaNumarasi)));
            }
        }

        private string _hastaneAdi;
        public string HastaneAdi
        {
            get => _hastaneAdi;
            set
            {
                if (_hastaneAdi == value)
                {
                    return;
                }
                _hastaneAdi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_hastaneAdi)));
            }
        }


        private string _adress;
        public string Adress
        {
            get => _adress;
            set
            {
                if (_adress == value)
                {
                    return;
                }
                _adress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_adress)));
            }
        }

        private string _ilce;
        public string Ilce
        {
            get => _ilce;
            set
            {
                if (_ilce == value)
                {
                    return;
                }
                _ilce = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_ilce)));
            }
        }

        private string _il;
        public string Il
        {
            get => _il;
            set
            {
                if (_il == value)
                {
                    return;
                }
                _il = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_il)));
            }
        }

        private string _discriminator;
        public string Discriminator
        {
            get => _discriminator;
            set
            {
                if (_discriminator == value)
                {
                    return;
                }
                _discriminator = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_discriminator)));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
    }
}
