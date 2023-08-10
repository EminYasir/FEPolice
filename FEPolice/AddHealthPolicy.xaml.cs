using FEPolice.DataServices;
using FEPolice.Model;

namespace FEPolice;

public partial class AddHealthPolicy : ContentPage
{
    private readonly Person _person;
    List<Policys> policyList = new List<Policys>();
    private Product _product;
    private IRestDataService _dataService;
    int _id;
    DateTime now = DateTime.Now;
    Random many = new Random(10000);
    public AddHealthPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
        _person = p;
        _dataService = dataService;
        _id = productid;
        KullaniciAdi.Text = _person.Adi;
        KullaniciSoyAdi.Text = _person.Soyadi;

    }

    public async void Add_Health_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) ||
            string.IsNullOrEmpty(SigortaNumber.Text) || string.IsNullOrEmpty(HastaneAdi.Text)  ||
            string.IsNullOrEmpty(TanzimTarihi.Text) || string.IsNullOrEmpty(VadeBaslangic.Text) ||
            string.IsNullOrEmpty(VadeBitis.Text) || string.IsNullOrEmpty(Prim.Text))
        {
            await DisplayAlert("Uyar�", "L�tfen t�m alanlar� doldurunuz.", "Tamam");
            return;
        }
        policyList = await _dataService.GetAllPolicysAsync();
        _product = await _dataService.GetProductByNumberAsync(_id);


        Policys newPolicy = new Policys();

       
        newPolicy.ProductId = _id;
        newPolicy.PersonId = _person.PersonId;
        newPolicy.SigortaNumarasi = SigortaNumber.Text;
        newPolicy.HastaneAdi= HastaneAdi.Text;
        newPolicy.TanzimTarihi = now;
        newPolicy.VadeBaslangic = now;
        newPolicy.VadeBitis = now.AddYears(1);
        newPolicy.Prim = many.NextDouble();
        newPolicy.Discriminator = "Health";


        await _dataService.AddPolicysAsync(newPolicy);
        await Navigation.PopModalAsync();
    }
}