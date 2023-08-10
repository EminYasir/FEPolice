using FEPolice.DataServices;
using FEPolice.Model;


namespace FEPolice;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;
    List<Person> personList;

    public MainPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
        OnAppearing();


    }

    protected async void OnAppearing()
    {
        base.OnAppearing();
        personList = await _dataService.GetAllPersonAsync();
        
    }




    private async void OnCounterClicked(object sender, EventArgs e)
    {
        string kullaniciAdi = Kullaniciadi.Text;
        string sifre = Kullanicisifre.Text;

        Person result = await _dataService.LoginAsync(kullaniciAdi, sifre);
        //var loggedInPerson = await _dataService.Person.FirstOrDefaultAsync(u => u.Adi + " " + u.Soyadi == kullaniciAdi && u.Password == sifre);
        if (result != null)
        {
            // API'den giriş başarılı yanıt aldıysak
            await Navigation.PushAsync(new Page1(_dataService,result));
            ErrorMessage.Text = "Giriş başarılı";
        }
        else
        {
            ErrorMessage.Text = "Geçersiz kullanıcı adı veya şifre.";
        }

        ErrorMessage.IsVisible = true;
    }


}

