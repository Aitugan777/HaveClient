using HaveApp.Models;
using HaveApp.ViewModels;
using System.Collections.ObjectModel;

namespace HaveApp;

public partial class ItemInfoPage : ContentPage
{
    public ItemInfoPage(HProduct product)
	{
		InitializeComponent();

        this.ItemImages.Add(new AitukImage() { ImageSource = "backpack.jpg" });
        this.ItemImages.Add(new AitukImage() { ImageSource = "m1911.jpg" });
        this.ItemImages.Add(new AitukImage() { ImageSource = "engine.jpg" });
        this.ItemImages.Add(new AitukImage() { ImageSource = "monitor.jpg" });
        cv_ItemImages.ItemsSource = this.ItemImages;

        BindingContext = new ItemInfoViewModel(product);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
    }

    public ObservableCollection<AitukImage> ItemImages = new ObservableCollection<AitukImage>();

    private async void BtnClickBack(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}

public class AitukImage
{
	public string ImageSource { get; set; }
}