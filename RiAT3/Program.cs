using System.Net.Http.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var users = await GetUsers();

        if (users != null)
            DisplayUsers(users);
        else
            Console.WriteLine("Ошибка при получении списка пользователей.");
    }

    static async Task<List<User>> GetUsers()
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "https://jsonplaceholder.typicode.com/users";
            var response = await client.GetFromJsonAsync<List<User>>(url);

            if (response != null)
                return response;
            else
                return null;
        }
    }

    static void DisplayUsers(List<User> users)
    {
        foreach (var user in users)
            Console.WriteLine($"{user.Name}");
    }
}

public class User
{
    public string Name { get; set; }
}