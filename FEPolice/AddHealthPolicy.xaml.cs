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
    Random many = new Random();
    public AddHealthPolicy(IRestDataService dataService, Person p, int productid)
	{
		InitializeComponent();
        _person = p;
        _dataService = dataService;
        _id = productid;
        KullaniciAdi.Text = _person.Adi;
        KullaniciSoyAdi.Text = _person.Soyadi;
        DatePickerBitis.Date = DatePickerBaslangic.Date.AddYears(1);

    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePickerBitis.Date = DatePickerBaslangic.Date.AddYears(1);
    }

    public async void Add_Health_Policy(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(KullaniciAdi.Text) || string.IsNullOrEmpty(KullaniciSoyAdi.Text) ||
            string.IsNullOrEmpty(SigortaNumber.Text) || string.IsNullOrEmpty(HastaneAdi.Text)  ||
            DatePicker.Date.Equals(null) || 
            DatePickerBaslangic.Equals(null) || DatePickerBitis.Date.Equals(null) || string.IsNullOrEmpty(Prim.Text))
        {
            await DisplayAlert("Uyarý", "Lütfen tüm alanlarý doldurunuz.", "Tamam");
            return;
        }
        policyList = await _dataService.GetAllPolicysAsync();
        _product = await _dataService.GetProductByNumberAsync(_id);


        Policys newPolicy = new Policys();

       
        newPolicy.ProductId = _id;
        newPolicy.PersonId = _person.PersonId;
        newPolicy.SigortaNumarasi = SigortaNumber.Text;
        newPolicy.HastaneAdi= HastaneAdi.Text;
        newPolicy.TanzimTarihi = DatePicker.Date;
        newPolicy.VadeBaslangic = DatePickerBaslangic.Date;
        newPolicy.VadeBitis = DatePickerBitis.Date;
        newPolicy.Prim = Math.Round(many.NextDouble() * (1000.0 - 10.0) + 10.0, 2);
        newPolicy.Discriminator = "Health";


        await _dataService.AddPolicysAsync(newPolicy);
        //await Navigation.PopModalAsync();
    }
}