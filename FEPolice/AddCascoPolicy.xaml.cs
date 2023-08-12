using FEPolice.Cars;
using FEPolice.DataServices;
using FEPolice.Model;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace FEPolice;

public partial class AddCascoPolicy : ContentPage
{
    private readonly Person _person;
    List<Policys> policyList = new List<Policys>();
    private Product _product;
    private IRestDataService _dataService;
    int _id;
	DateTime now= DateTime.Now;
	Random many=new Random();
    private List<Car> cars;
    public AddCascoPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
		_person = p;
		_dataService = dataService;
		_id = productid;
		KullaniciAdi.Text= _person.Adi;
		KullaniciSoyAdi.Text = _person.Soyadi;


        LoadCars();
	}

    private void LoadCars()
    {
        // JSON dosyasýný projenizdeki doðru yolunu belirtin
        string jsonFilePath = "C:\\Users\\eminyasircorut\\source\\repos\\FEPolice\\FEPolice\\Cars\\carData.json"; // JSON dosyanýzýn yolunu buraya girin

        string jsonContent = File.ReadAllText(jsonFilePath);
        cars = JsonConvert.DeserializeObject<List<Car>>(jsonContent);

        List<string> carMarka = new List<string>();
        foreach (var car in cars)
        {
            carMarka.Add(car.make);
        }

        MarkaPicker.ItemsSource = carMarka;
    }

    private void MarkaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MarkaPicker.SelectedIndex != -1)
        {
            string selectedCarName = MarkaPicker.SelectedItem.ToString();
            Car selectedcar = cars.Find(car => car.make == selectedCarName);

            List<string> modelNames = new List<string>();
            foreach (var model in selectedcar.models)
            {
                modelNames.Add(model);
            }

            ModelPicker.ItemsSource = modelNames;
            ModelPicker.IsEnabled = true;
        }
    }


    public async void Add_Casco_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) || string.IsNullOrEmpty(CarPlaka.Text) ||
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
        newPolicy.CarPlateNumber = CarPlaka.Text;
        newPolicy.CarBrand = MarkaPicker.SelectedItem.ToString();
        newPolicy.CarModel = ModelPicker.SelectedItem.ToString();
        newPolicy.TanzimTarihi = now;
        newPolicy.VadeBaslangic = now;
        newPolicy.VadeBitis = now.AddYears(1);
        newPolicy.Prim = Math.Round(many.NextDouble() * (1000.0 - 10.0) + 10.0, 2);
        newPolicy.Discriminator = "Casco";

        
        await _dataService.AddPolicysAsync(newPolicy);
        //await Navigation.PopModalAsync();
    }
}