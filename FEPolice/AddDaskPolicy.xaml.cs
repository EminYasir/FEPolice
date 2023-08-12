using FEPolice.Citys;
using FEPolice.DataServices;
using FEPolice.Model;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace FEPolice;

public partial class AddDaskPolicy : ContentPage
{
    private readonly Person _person;
    List<Policys> policyList = new List<Policys>();
    private Product _product;
    private IRestDataService _dataService;
    int _id;
    DateTime now = DateTime.Now;
    Random many = new Random();
    private List<City> cities;
    public AddDaskPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
        _person = p;
        _dataService = dataService;
        _id = productid;
        KullaniciAdi.Text = _person.Adi;
        KullaniciSoyAdi.Text = _person.Soyadi;

        

        LoadCities();
    }

    private void LoadCities()
    {
        // JSON dosyasýný projenizdeki doðru yolunu belirtin
        string jsonFilePath = "C:\\Users\\eminyasircorut\\source\\repos\\FEPolice\\FEPolice\\Citys\\data.json"; // JSON dosyanýzýn yolunu buraya girin

        string jsonContent = File.ReadAllText(jsonFilePath);
        cities = JsonConvert.DeserializeObject<List<City>>(jsonContent);

        List<string> cityNames = new List<string>();
        foreach (var city in cities)
        {
            cityNames.Add(city.name);
        }

        IlPicker.ItemsSource = cityNames;
    }

    private void IlPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IlPicker.SelectedIndex != -1)
        {
            string selectedCityName = IlPicker.SelectedItem.ToString();
            City selectedCity = cities.Find(city => city.name == selectedCityName);

            List<string> districtNames = new List<string>();
            foreach (var town in selectedCity.towns)
            {
                foreach (var district in town.districts)
                {
                    districtNames.Add(district.name);
                }
            }

            IlcePicker.ItemsSource = districtNames;
            IlcePicker.IsEnabled = true;
        }
    }

    public async void Add_Dask_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) ||
            string.IsNullOrEmpty(Adress.Text) || 
            string.IsNullOrEmpty(TanzimTarihi.Text) || string.IsNullOrEmpty(VadeBaslangic.Text) ||
            string.IsNullOrEmpty(VadeBitis.Text) || string.IsNullOrEmpty(Prim.Text))
        {
            await DisplayAlert("Uyarý", "Lütfen tüm alanlarý doldurunuz.", "Tamam");
            return;
        }
        policyList = await _dataService.GetAllPolicysAsync();
        _product = await _dataService.GetProductByNumberAsync(_id);


        Policys newPolicy = new Policys();

        
        newPolicy.ProductId = _id;
        newPolicy.PersonId = _person.PersonId;
        newPolicy.Adress = Adress.Text;
        newPolicy.Ilce = IlcePicker.SelectedItem.ToString();
        newPolicy.Il = IlPicker.SelectedItem.ToString();
        newPolicy.TanzimTarihi = now;
        newPolicy.VadeBaslangic = now;
        newPolicy.VadeBitis = now.AddYears(1);
        newPolicy.Prim = Math.Round(many.NextDouble() * (1000.0 - 10.0) + 10.0, 2);
        newPolicy.Discriminator = "Dask";


        await _dataService.AddPolicysAsync(newPolicy);
        //await Navigation.PopModalAsync();


    }
}