
using SQLite;

namespace AddContact.Models;

public class LocalDBService
{
	private const string DB_NAME = "contacts_db.db3";
	private readonly SQLiteAsyncConnection _connection;

	public LocalDBService()
	{
		_connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
		_connection.CreateTableAsync<Contacts>();

	}

	public async void Insert(Contacts contact)
	{
		await _connection.InsertAsync(contact);
	}
	public async Task<List<Contacts>> GetContactsAsync()
	{
		List<Contacts> contactsList = await _connection.Table<Contacts>().OrderBy(x => x.Name).ToListAsync();
		return contactsList;

    }
    public async Task<Contacts> GetContactsByIdAsync(int id)
    {
        return await _connection.Table<Contacts>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}