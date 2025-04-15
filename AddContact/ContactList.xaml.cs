namespace AddContact;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AddContact.Models;
using Microsoft.Maui.Controls;

public partial class ContactList : ContentPage
{
    private readonly LocalDBService _dBService;
    private ObservableCollection<Contacts> _contacts = new ObservableCollection<Contacts>();
    
    public ObservableCollection<Contacts> Contacts
    {
        get => _contacts;
        set
        {
            _contacts = value;
            OnPropertyChanged();
        }
    }

    public ContactList(LocalDBService dBService)
	{
        _dBService = dBService;
        BindingContext = this;
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadContactsAsync();
    }

    private async void selectedChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacts selectedContact)
        {
            await Navigation.PushAsync(new ContactDetails(_dBService, selectedContact.Id));
        }
    }
    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async Task LoadContactsAsync()
    {
        List<Contacts> storedContacts = await _dBService.GetContactsAsync();
        Contacts.Clear();
        foreach (var contact in storedContacts)
        {
            Contacts.Add(contact);
        }
        Debug.WriteLine($"Loaded {Contacts.Count} contacts");
    }
}