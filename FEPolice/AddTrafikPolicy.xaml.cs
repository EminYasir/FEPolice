using FEPolice.DataServices;
using FEPolice.Model;

namespace FEPolice;

public partial class AddTrafikPolicy : ContentPage
{
    private readonly Person _person;
    List<Policys> policyList = new List<Policys>();
    private Product _product;
    private IRestDataService _dataService;
    int _id;
    DateTime now = DateTime.Now;
    Random many = new Random();
    public AddTrafikPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
        _person = p;
        _dataService = dataService;
        _id = productid;
        KullaniciAdi.Text = _person.Adi;
        KullaniciSoyAdi.Text = _person.Soyadi;
        List<int> plakaIlKoduList = new List<int>();
        for (int i = 1; i <= 83; i++)
        {
            plakaIlKoduList.Add(i);
        }

        PlakaIlKoduPicker.ItemsSource = plakaIlKoduList;
    }


    public async void Add_Trafik_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) ||
             string.IsNullOrEmpty(PlakaKodu.Text)  ||
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
        newPolicy.PlakaKodu = PlakaKodu.Text;
        newPolicy.PlakaIlKodu = PlakaIlKoduPicker.SelectedItem.ToString();
        newPolicy.TanzimTarihi = now;
        newPolicy.VadeBaslangic = now;
        newPolicy.VadeBitis = now.AddYears(1);
        newPolicy.Prim = Math.Round(many.NextDouble() * (1000.0 - 10.0) + 10.0, 2);
        newPolicy.Discriminator = "Traffic";


        await _dataService.AddPolicysAsync(newPolicy);
        //await Navigation.PopModalAsync();
    }
}