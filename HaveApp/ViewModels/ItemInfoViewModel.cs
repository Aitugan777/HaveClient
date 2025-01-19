using HaveApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HaveApp.ViewModels
{
    public class ItemInfoViewModel: INotifyPropertyChanged
    {
        public ItemInfoViewModel(HProduct hProduct)
        {
            _hProduct = hProduct;
        }
        
        private HProduct _hProduct;

        public HProduct Product
        {
            get => _hProduct;
            set
            {
                _hProduct = value;
                OnPropertyChanged("Product");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
