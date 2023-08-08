using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPolice.Model
{
    public class Product
    {
        private int _id;
        public int ProductId
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

        private string _code;
        public string Code
        {
            get => _code;
            set
            {
                if (_code == value)
                {
                    return;
                }
                _code = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_code)));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_name)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
