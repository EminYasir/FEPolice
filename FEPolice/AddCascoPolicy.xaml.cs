using FEPolice.DataServices;
using FEPolice.Model;

namespace FEPolice;

public partial class AddCascoPolicy : ContentPage
{
    private readonly Person _person;
    List<Policys> policyList = new List<Policys>();
    private Product _product;
    private IRestDataService _dataService;
    int _id;
	DateTime now= DateTime.Now;
	Random many=new Random(10000);

    public AddCascoPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
		_person = p;
		_dataService = dataService;
		_id = productid;
		KullaniciAdi.Text= _person.Adi;
		KullaniciSoyAdi.Text = _person.Soyadi;

		
	}


    public async void Add_Casco_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) ||
            string.IsNullOrEmpty(CarBrand.Text) || string.IsNullOrEmpty(CarModel.Text) || string.IsNullOrEmpty(CarPlaka.Text) ||
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
        newPolicy.CarBrand = CarBrand.Text;
        newPolicy.CarModel = CarModel.Text;
        newPolicy.TanzimTarihi = now;
        newPolicy.VadeBaslangic = now;
        newPolicy.VadeBitis = now.AddYears(1);
        newPolicy.Prim = many.NextDouble();
        newPolicy.Discriminator = "Casco";

        
        await _dataService.AddPolicysAsync(newPolicy);
        await Navigation.PopModalAsync();
    }
}