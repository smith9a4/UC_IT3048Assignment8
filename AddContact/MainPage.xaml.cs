using AddContact.Models;

namespace AddContact
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDBService _dBService;
        Models.Contacts _newContact = new Models.Contacts();
        public MainPage(LocalDBService dBService)
        {
            _dBService = dBService;
            BindingContext = _newContact;
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _dBService.Insert(_newContact);
            
            await DisplayAlert("Success", "Contact saved successfully!", "OK");
            await Navigation.PushAsync(new ContactList(_dBService));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactList(_dBService));
        }
    }
}
