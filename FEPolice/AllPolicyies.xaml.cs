using FEPolice.DataServices;
using FEPolice.Model;
using System;

namespace FEPolice;

public partial class AllPolicyies : ContentPage
{
    private IRestDataService _dataService;
    List<Policys> policyList = new List<Policys>();
    private readonly Person p;
    List<Policys> matchedPolicies = new List<Policys>();

    public AllPolicyies(IRestDataService dataService, Person person)
    {
        InitializeComponent();
        p = person;
        _dataService = dataService;
        _ = OnAppearing(p);
    }

    protected async Task OnAppearing(Person person)
    {
        base.OnAppearing();

        policyList = await _dataService.GetAllPolicysAsync();
        matchedPolicies.AddRange(policyList.Where(policy => policy.PersonId == person.PersonId));

        collectionView.ItemsSource = matchedPolicies;


    }
    


}