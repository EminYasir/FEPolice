using FEPolice.DataServices;
using FEPolice.Model;

namespace FEPolice;

public partial class HealthPage : ContentPage
{
    private readonly IRestDataService _dataService;
    List<Policys> policyList = new List<Policys>();
    Person p;
    List<Policys> matchedPolicies = new List<Policys>();
    List<Policys> matchedProduct = new List<Policys>();
    int productid;

    public HealthPage(IRestDataService dataService, Person person, int productid)
    {
        InitializeComponent();
        _dataService = dataService;
        this.productid = productid;
        p = person;
        _ = OnAppearing(p, productid);
    }


    protected async Task OnAppearing(Person person, int productid)
    {
        base.OnAppearing();
        policyList = await _dataService.GetAllPolicysAsync();
        matchedPolicies.AddRange(policyList.Where(policy => policy.PersonId == person.PersonId));
        for (int i = 0; i < matchedPolicies.Count; i++)
        {
            if (matchedPolicies[i].Discriminator == "Health")
            {

                matchedProduct.Add((matchedPolicies[i]));
            }
        }

        collectionView.ItemsSource = matchedProduct;


    }

    public async void Sil_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int id = (int)button.CommandParameter;
        await _dataService.DeletePolicysAsync(id);

    }

    public async void Ekle_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddHealthPolicy(_dataService, p, productid));

    }
}