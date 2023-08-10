using FEPolice.DataServices;
using FEPolice.Model;

namespace FEPolice;

public partial class AddDaskPolicy : ContentPage
{
    private readonly Person _person;
    List<Policys> policyList = new List<Policys>();
    private Product _product;
    private IRestDataService _dataService;
    int _id;
    DateTime now = DateTime.Now;
    Random many = new Random(10000);
    public AddDaskPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
        _person = p;
        _dataService = dataService;
        _id = productid;
        KullaniciAdi.Text = _person.Adi;
        KullaniciSoyAdi.Text = _person.Soyadi;
    }

    public async void Add_Dask_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) ||
            string.IsNullOrEmpty(Adress.Text) || string.IsNullOrEmpty(Il.Text) || string.IsNullOrEmpty(Ilce.Text) ||
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
        newPolicy.Ilce = Ilce.Text;
        newPolicy.Il = Il.Text;
        newPolicy.TanzimTarihi = now;
        newPolicy.VadeBaslangic = now;
        newPolicy.VadeBitis = now.AddYears(1);
        newPolicy.Prim = many.NextDouble();
        newPolicy.Discriminator = "Dask";


        await _dataService.AddPolicysAsync(newPolicy);
        //await Navigation.PopModalAsync();


    }
}