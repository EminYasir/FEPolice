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
        Person p=new Person();
        bool control = false;
        foreach (Person person in personList)
        {
            if (Kullaniciadi.Text == person.Adi+""+person.Soyadi && Kullanicisifre.Text == person.Password)
            {
                p=person;
                control = true;
                break;
            }
            
        }
        if ( control)
        {
            await Navigation.PushAsync(new Page1(_dataService, p ));
            ErrorMessage.Text = "Bağlantı başarılı";
            
        }
        else
        {
            ErrorMessage.Text = "Bağlantı başarılı değil";

        }

        ErrorMessage.IsVisible = true;

    }


}

