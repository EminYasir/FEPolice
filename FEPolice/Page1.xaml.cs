using FEPolice.DataServices;
using FEPolice.Model;

namespace FEPolice;

public partial class Page1 : ContentPage
{

    private readonly IRestDataService _dataService;
    private readonly Person person;
    private int productid;

    public Page1(IRestDataService dataService, Person p)
    {
        InitializeComponent();
        _dataService = dataService;
        person = p;
        User.Text = "Hoþgeldin " + person.Adi + " " + person.Soyadi;
    }



    private async void Button_Clicked_1(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new AllPolicyies(_dataService, person));

    }

    private async void Buton_Trafik(object sender, EventArgs e)
    {
        productid = 2;
        await Navigation.PushAsync(new TrafikPage(_dataService, person, productid));

    }

    private async void Buton_Kasko(object sender, EventArgs e)
    {
        productid = 1;
        await Navigation.PushAsync(new CascoPage(_dataService, person, productid));

    }
    private async void Buton_Dask(object sender, EventArgs e)
    {
        productid = 4;
        await Navigation.PushAsync(new DaskPage(_dataService, person, productid));

    }
    private async void Buton_Health(object sender, EventArgs e)
    {
        productid = 3;
        await Navigation.PushAsync(new HealthPage(_dataService, person, productid));

    }
}
