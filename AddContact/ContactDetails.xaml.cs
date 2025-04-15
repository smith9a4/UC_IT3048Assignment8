namespace AddContact;

using System.Threading.Tasks;
using AddContact.Models;

public partial class ContactDetails : ContentPage
{
    private readonly LocalDBService _dBService;
    public ContactDetails(LocalDBService dBService, int id)
	{
        _dBService = dBService;
		InitializeComponent();
        LoadContactAsync(id);
	}
    private async Task LoadContactAsync(int id)
    {
        var contact = await _dBService.GetContactsByIdAsync(id);
        BindingContext = contact;
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}