using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FEPolice.Model
{
    public class Person : INotifyPropertyChanged
    {
        private int _id;
        public int PersonId
        {
            get => _id;
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_id)));
            }
        }

        private string _kimlikNo;
        public string KimlikNo
        {
            get => _kimlikNo;
            set
            {
                if (_kimlikNo == value)
                {
                    return;
                }
                _kimlikNo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_kimlikNo)));
            }
        }

        private DateTime _dogumTarihi;
        public DateTime DogumTarihi
        {
            get => _dogumTarihi;
            set
            {
                if (_dogumTarihi == value)
                {
                    return;
                }
                _dogumTarihi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_dogumTarihi)));
            }
        }

        private string _adi;
        public string Adi
        {
            get => _adi;
            set
            {
                if (_adi == value)
                {
                    return;
                }
                _adi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_adi)));
            }
        }

        private string _soyadi;
        public string Soyadi
        {
            get => _soyadi;
            set
            {
                if (_soyadi == value)
                {
                    return;
                }
                _soyadi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_soyadi)));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                {
                    return;
                }
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_password)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
