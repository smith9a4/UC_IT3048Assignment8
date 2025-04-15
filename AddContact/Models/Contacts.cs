namespace AddContact.Models;
using SQLite;

public class Contacts
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
	public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Description { get; set; }
    

}