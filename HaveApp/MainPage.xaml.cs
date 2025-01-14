using HaveApp.Models;
using HaveApp.ViewModels;

namespace HaveApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
