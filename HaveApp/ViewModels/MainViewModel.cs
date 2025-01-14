using HaveApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace HaveApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HProductPair> _productPairs;
        private string _searchQuery;

        public ObservableCollection<HProductPair> ProductPairs
        {
            get => _productPairs;
            set
            {
                _productPairs = value;
                OnPropertyChanged();
            }
        }
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        public MainViewModel()
        {
            ProductPairs = new ObservableCollection<HProductPair>();
            _httpClient = new HttpClient();
            SearchCommand = new Command(async () => await OnSearchBtnClicked());
        }

        private async Task OnSearchBtnClicked()
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                await FetchProductsAsync(SearchQuery);
            }
        }

        private readonly HttpClient _httpClient;

        private async Task FetchProductsAsync(string query)
        {
            try
            {
                // Кодируем запрос
                var encodedQuery = Uri.EscapeDataString(query);
                var url = $"http://94.41.23.37:5070/api/HProduct/search?name={encodedQuery}";

                // Выполняем запрос
                Console.WriteLine($"Request URL: {url}");
                var response = await _httpClient.GetStringAsync(url);


                // Десериализация JSON в List<HProduct>
                if (response == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Ошибка", $"Null", "ОК");
                }

                List<HProduct> products = JsonConvert.DeserializeObject<List<HProduct>>(response);
                // Обновляем коллекцию товаров
                ProductPairs.Clear();
                foreach (HProduct product in products)
                {
                    product.OnImageClickCommand = new Command(() =>
                    {
                        OnProductClicked(product);
                    });
                }
                ProductPairs = new ObservableCollection<HProductPair>(CreatePairs(products));
            }
            catch (Exception ex)
            {
                // Обработка ошибок (например, не удается выполнить запрос)
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"Ошибка при загрузке данных: {ex.Message}", "ОК");
            }
        }

        private void OnProductClicked(HProduct product)
        {
            Application.Current.MainPage.DisplayAlert("Товар выбран", $"Вы выбрали: {product.Name}", "ОК");
        }

        private List<HProductPair> CreatePairs(List<HProduct> products)
        {
            var pairs = new List<HProductPair>();
            for (int i = 0; i < products.Count; i += 2)
            {
                var pair = new HProductPair
                {
                    Column1 = products[i],
                    Column2 = i + 1 < products.Count ? products[i + 1] : null
                };
                pairs.Add(pair);
            }
            return pairs;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
